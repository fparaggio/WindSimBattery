using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace WindSim.Batch.Core
{
    public class WindField
    {
        private PhiFile _phi = null;
        private XYZFile _xyz = null;
        private bool _isReduced;
        public bool IsReduced
        {
            get { return _isReduced; }
        }   
        public PhiFile phi
         {
            get { return _phi;}
         }   
        public XYZFile xyz
        {
            get { return _xyz; }
        }   

        public WindFieldCell[,,] Field;
 
        public double[] ucrt(int x_cell, int y_cell)
        {
            int ucrt_index = Array.IndexOf(phi.variables_name, "UCRT");
            double[] arr = new double[phi.z_high_cell_face.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = phi.vars_phi[x_cell-1, y_cell-1, i, ucrt_index];
            }
            return arr;
        }

        public double[] ke(int x_cell, int y_cell)
        {
            int ke_index = Array.IndexOf(phi.variables_name, "KE");
            double[] arr = new double[phi.z_high_cell_face.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = phi.vars_phi[x_cell - 1, y_cell - 1, i, ke_index];
            }
            return arr;
        }

        public double[] tem1(int x_cell, int y_cell)
        {
            int tem1_index = Array.IndexOf(phi.variables_name, "TEM1");
            double[] arr = new double[phi.z_high_cell_face.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = phi.vars_phi[x_cell - 1, y_cell - 1, i, tem1_index];
            }
            return arr;
        }

        public double[] zcen(int x_cell, int y_cell)
        {
            double[] arr = new double[phi.z_high_cell_face.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                double zcen_i =   xyz.values[x_cell-1, y_cell-1, i, 2] + ( (xyz.values[x_cell-1, y_cell-1, i+1, 2] -  xyz.values[x_cell-1, y_cell-1, i, 2]) / 2);        
                arr[i] = zcen_i;
            }
            return arr;
        }


        public double[] z0(int x, int y, double maxHeight = 10.0, double r2Threshold = 0.95)
        {
            double[] arr = MyMath.LeastSquaresBestFitLine(this.zcen_log(x, y), this.ucrt(x, y));;

            if (maxHeight > 0)
            {
                int i = this.zcen_log(x, y).Length;
                while (MyMath.LeastSquaresBestFitLine(this.zcen_log(x, y).Take(i).ToArray(), this.ucrt(x, y).Take(i).ToArray())[0] > r2Threshold && this.zcen_log(x, y).Take(i).Max() > maxHeight)
                {
                    arr = MyMath.LeastSquaresBestFitLine(this.zcen_log(x, y).Take(i).ToArray(), this.ucrt(x, y).Take(i).ToArray());
                    i--;
                }
            }

         //{ BbestfitYintercept, AbestfitSlope, sigma, r_2, BsigmaIntercept, AsigmaSlope };
         double A = arr[1];
         double B = arr[0];
         double z0 = Math.Exp(-1 * B / A);
         double sigmaA = arr[5];
         double sigmaB = arr[4];
         double sigmaz0 = z0 * ((B / A) * ((sigmaB / B) + (sigmaA / A)));
         
            //  it returns following values
            //  { z0 , (u*/k) , sigma, r2 , sigmaz0 } 
         double[] result = {z0, A, arr[2], arr[3], sigmaz0 };
         return result;
        }

        public double[] zcen_log(int x,int y)
        {
 	    double[] zcen = this.zcen(x,y);
        double[] arr = new double[zcen.Length];
            for (int i = 0; i < zcen.Length; i++)
            {
            arr[i] = Math.Log(zcen[i]);
            }
            return arr;
        }

        //        public double ucrt(int x, int y, int z)
        //{
        //    int ucrt_index = Array.IndexOf(variables_name, "UCRT");
        //    return vars_phi[x, y, z, ucrt_index];
        //}

        //public double[] ucrt(int x, int y)
        //{
        //    ///inserire exeptions
            
        //    int ucrt_index = Array.IndexOf(variables_name, "UCRT");
        //    double[] arr = new double[z_high_cell_face.Length];
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        arr[i] = vars_phi[x, y, i, ucrt_index];
        //    }
        //    return arr;
        //}

        ////public double z0(int x, int y)
        ////{
        ////    int len = z_high_cell_face.Length;
        ////    double[] logz = new double[len];
        ////    double[] u = ucrt(x, y);
        ////    for (int i = 0; i < len; i++)
        ////    {
        ////        double zcen;
        ////        if (i == 0) zcen = z_high_cell_face[i] / 2;
        ////        else zcen = z_high_cell_face[i] - z_high_cell_face[i - 1];
        ////        logz[i] = Math.Log(zcen);
        ////    }

        ////}

        public WindField(WSProject project ,int settore, PhiFileType phifileType = PhiFileType.reduced) 
        
        {
            // inistialize phi and xyz
            string phi_file;
            string xyz_file;
        
            switch (phifileType)
            {
                case PhiFileType.reduced:
                    phi_file = project.file.DirectoryName + "\\windfield\\" + settore + "_red.phi";
                    xyz_file = project.file.DirectoryName + "\\windfield\\" + settore + "_red.xyz";
                    this._isReduced = true;
                    break;
                case PhiFileType.notReduced:
                    string phi_file_zipped = project.file.DirectoryName + "\\windfield\\" + settore + ".phi.Z";
                    string xyz_file_zipped = project.file.DirectoryName + "\\windfield\\" + settore + ".xyz.Z";
                    FileInfo phi_file_check_zipped = new FileInfo(phi_file_zipped);
                    FileInfo xyz_file_check_zipped = new FileInfo(xyz_file_zipped);
                    Tools.UnZipFile(phi_file_zipped, phi_file_check_zipped.DirectoryName + "\\unzip\\");
                    Tools.UnZipFile(xyz_file_zipped, xyz_file_check_zipped.DirectoryName + "\\unzip\\");
                    phi_file = phi_file_check_zipped.DirectoryName + "\\unzip\\" + settore + ".phi";
                    xyz_file = xyz_file_check_zipped.DirectoryName + "\\unzip\\" + settore + ".xyz";
                    this._isReduced = false;
                    break;
                default:
                    phi_file = project.file.DirectoryName + "\\windfield\\" + settore + "_red.phi";
                    xyz_file = project.file.DirectoryName + "\\windfield\\" + settore + "_red.xyz";
                    this._isReduced = true;
                    break;
            }

            FileInfo phi_file_check = new FileInfo(phi_file);
            FileInfo xyz_file_check = new FileInfo(xyz_file);

            // check if required files exists

            if (phi_file_check.Exists && xyz_file_check.Exists)
            {
                _phi = new PhiFile(phi_file_check.FullName);
                _xyz = new XYZFile(xyz_file);
                // Fill the Field array
                Field = new WindFieldCell[phi.nx, phi.ny, phi.nz];

                for (int i = 0; i < phi.nx; i++) 
                {
                    for (int j = 0; j < phi.ny; j++) 
                    {
                        for (int k = 0; k < phi.nz; k++) 
                        {
                            WindFieldCell cell = new WindFieldCell(phi.value(PhiFileDataType.P1, i, j, k), phi.value(PhiFileDataType.Ke, i, j, k), phi.value(PhiFileDataType.Ep, i, j, k), phi.value(PhiFileDataType.Wcrt, i, j, k), phi.value(PhiFileDataType.Vcrt, i, j, k), phi.value(PhiFileDataType.Ucrt, i, j, k));
                            
                            //centro
                            

                            
                            XYZObject center = new XYZObject(phi.value(PhiFileDataType.Xcen, i, j, k),phi.value(PhiFileDataType.Ycen, i, j, k),phi.value(PhiFileDataType.Zcen, i, j, k));

                            cell.AddPoint(WindFieldCell.PointPosition.Center, center);
                            cell.AddTem1(phi.value(PhiFileDataType.Tem1, i, j, k));

                             //          NWU+--------------------+NEU 
                             //            /|                   /|
                             //           / |                  / |
                             //          /  |                 /  |
                             //k+1   SWU+--------------------+SEU|  
                             //         |   |                |   |
                             //         |   |                |   |
                             //         |   |                |   |
                             //         |   |       *CEN     |   |
                             //         |   |                |   |
                             //         |   |                |   |
                             //  Z j+1  |NWL+----------------|---+NEL
                             //  ^      |  /                 |  /
                             //  |      | /	                | /
                             //  |      |/		            |/
                             //k | j SWL+--------------------+SEL
                             //  |     i                       i+1
                             //  |  >Y
                             //  | /
                             //  |/
                             //  +------------------------>X
                            //NorthWestUp 
                            cell.AddPoint(WindFieldCell.PointPosition.NorthWestUp, new XYZObject(xyz.values[i, j + 1, k + 1, 0], xyz.values[i, j + 1, k + 1, 1], xyz.values[i, j + 1, k + 1, 2]));
                            //NorthEastUp 
                            cell.AddPoint(WindFieldCell.PointPosition.NorthEastUp, new XYZObject(xyz.values[i + 1, j + 1, k + 1, 0], xyz.values[i + 1, j + 1, k + 1, 1], xyz.values[i + 1, j + 1, k + 1, 2]));
                            //SouthWestUp
                            cell.AddPoint(WindFieldCell.PointPosition.SouthWestUp, new XYZObject(xyz.values[i, j, k + 1, 0], xyz.values[i, j, k + 1, 1], xyz.values[i, j, k + 1, 2]));
                            //SouthEastUp
                            cell.AddPoint(WindFieldCell.PointPosition.SouthEastUp, new XYZObject(xyz.values[i + 1, j, k + 1, 0], xyz.values[i + 1, j, k + 1, 1], xyz.values[i + 1, j, k + 1, 2]));
                            //NorthWestLow
                            cell.AddPoint(WindFieldCell.PointPosition.NorthWestLow, new XYZObject(xyz.values[i, j + 1, k, 0], xyz.values[i, j + 1, k, 1], xyz.values[i, j + 1, k, 2]));
                            //NorthEastLow
                            cell.AddPoint(WindFieldCell.PointPosition.NorthEastLow, new XYZObject(xyz.values[i + 1, j + 1, k, 0], xyz.values[i + 1, j + 1, k, 1], xyz.values[i + 1, j + 1, k, 2]));
                            //SouthWestLow
                            cell.AddPoint(WindFieldCell.PointPosition.SouthWestLow, new XYZObject(xyz.values[i, j, k, 0], xyz.values[i, j, k, 1], xyz.values[i, j, k, 2]));
                            //SouthEastLow 
                            cell.AddPoint(WindFieldCell.PointPosition.SouthEastLow, new XYZObject(xyz.values[i + 1, j, k, 0], xyz.values[i + 1, j, k, 1], xyz.values[i + 1, j, k, 2]));

                            
                            Field[i, j, k] = cell;
                        }
                    }
                }

            }
            else
            {
                _phi = null;
                _xyz = null;
            }

        }

        private int LowerCenterX(double x) 
        {
            double[] array = new double[phi.nx];
            for (int i = 0; i < array.Length; i++) 
            {
                array[i] = Field[i, 0, 0].Cen.X;
            }

            return MyMath.FindClosestLowerIndex(x, array);
        }

        private int LowerCenterY(double y)
        {
            double[] array = new double[phi.ny];
            for (int j = 0; j < array.Length; j++)
            {
                array[j] = Field[0, j, 0].Cen.Y;
            }
            return MyMath.FindClosestLowerIndex(y, array);
        }

        public int[] LowerCenterXY(double x, double y) 
        {
            // return [i,j] indexes of the lower left cell of the Centers square containing the point (x,y);
            //
            //
            //
            //       +-------------+-------------+
            //       |             |             |
            //       |    CEN      |     CEN     |
            //       |      *..............*     | j+1
            //       |      .      |       .     |
            //  Y    |      .      |       .     |
            //  ^    +------.------+-------.-----+
            //  |    |      .  X (x,y,z)   .     |
            //  |    |      .      |       .     |
            //  |    |      *..............*     | j
            //  |    |    CEN      |      CEN    |
            //  |    |             |             |
            //  |    +-------------+-------------+ 
            //  |          i            i+1
            //  |
            //  +-----------------------------------------> X
            int[] result = new int[2];
            result[0] = LowerCenterX(x);
            result[1] = LowerCenterY(y);
            return result;
        }

        public int LowerCenterZ(int i, int j, double heigth)
        {

            // it finds the value of k such that Field[i,j,k].Cen.Z <= height <= Field[i,j,k+1].Cen.Z
            if (!this.IsReduced)
            {
                double[] array = new double[phi.nz];
                for (int k = 0; k < array.Length; k++)
                {
                    array[k] = Field[i, j, k].Cen.Z;
                }
                return MyMath.FindClosestLowerIndex(heigth, array);
            }
            else throw new System.ArgumentException("WindField should be not reduced", "original");

        }

        public double interpolationForAutomaticGrid(double x, double y, double heightAboveGround, WindFieldCell.WindFieldCellDataType type) 
        {
            if (this.IsReduced) 
            {
                throw new System.ArgumentException("WindField cannot be reduced", "original");
            }
            double result = 0.0;
            int[] SouthWest = LowerCenterXY(x, y);
            int i = SouthWest[0];
            int j = SouthWest[1];
            int SwX = i;
            int SwY = j;
            int SeX = i + 1;
            int SeY = j;
            int NwX = i;
            int NwY = j + 1;
            int NeX = i + 1;
            int NeY = j + 1;

             

            //
            //    Nw - NorthWest cell        Ne - NorthEast cell
            //       +-------------+-------------+
            //       |             |             |
            //       |    CEN      |     CEN     |
            //       |      *..............*     | j+1
            //       |      .      |       .     |
            //  Y    |      .      |       .     |
            //  ^    +------.------+-------.-----+
            //  |    |      .  X (x,y,z)   .     |
            //  |    |      .      |       .     |
            //  |    |      *..............*     | j
            //  |    |    CEN      |      CEN    |
            //  |    |             |             |
            //  |    +-------------+-------------+ 
            //  |Sw- SouthWest i            i+1   Se - SouthEast cell
            //  |    cell
            //  +-----------------------------------------> X

            WindFieldCell cellWhereCalculateGroundHeight;
            // Calcolo la quota sul terreno di (x,y)
            if (Field[SwX, SwY, 0].contains(x,y))
            {
                cellWhereCalculateGroundHeight = Field[SwX, SwY, 0];
            }
            else if(Field[SeX, SeY, 0].contains(x,y))
            {
                cellWhereCalculateGroundHeight = Field[SeX, SeY, 0];
            }
            else if (Field[NwX, NwY, 0].contains(x, y))
            {
                cellWhereCalculateGroundHeight = Field[NwX, NwY, 0];
            }
            else
            {
                cellWhereCalculateGroundHeight = Field[NeX, NeY, 0];
            }
                // trovo in quale delle quattro celle sta
            double groundHeight = cellWhereCalculateGroundHeight.lowerSurfaceInterpolation(x, y);

            XYZObject point = new XYZObject(x,y,groundHeight+heightAboveGround);
            
            double SwGroundHeight = Field[SwX, SwY, 0].lowerSurfaceInterpolation(Field[SwX, SwY, 0].Cen.X, Field[SwX, SwY, 0].Cen.Y);
            double SeGroundHeight = Field[SeX, SeY, 0].lowerSurfaceInterpolation(Field[SeX, SeY, 0].Cen.X, Field[SeX, SeY, 0].Cen.Y);
            double NwGroundHeight = Field[NwX, NwY, 0].lowerSurfaceInterpolation(Field[NwX, NwY, 0].Cen.X, Field[NwX, NwY, 0].Cen.Y);
            double NeGroundHeight = Field[NeX, NeY, 0].lowerSurfaceInterpolation(Field[NeX, NeY, 0].Cen.X, Field[NeX, NeY, 0].Cen.Y);

            int SwZ = LowerCenterZ(SwX, SwY, SwGroundHeight + heightAboveGround);
            int SeZ = LowerCenterZ(SeX, SeY, SeGroundHeight + heightAboveGround);
            int NwZ = LowerCenterZ(NwX, NwY, NwGroundHeight + heightAboveGround);
            int NeZ = LowerCenterZ(NeX, NeY, NeGroundHeight + heightAboveGround);

            double SwInterpVal = MyMath.LinearInterpolation(new double[] { Field[SwX, SwY, SwZ].Cen.Z, Field[SwX, SwY, SwZ + 1].Cen.Z }, new double[] { Field[SwX, SwY, SwZ].value(type), Field[SwX, SwY, SwZ + 1].value(type) }, SwGroundHeight + heightAboveGround);
            double SeInterpVal = MyMath.LinearInterpolation(new double[] { Field[SeX, SeY, SeZ].Cen.Z, Field[SeX, SeY, SeZ + 1].Cen.Z }, new double[] { Field[SeX, SeY, SeZ].value(type), Field[SeX, SeY, SeZ + 1].value(type) }, SeGroundHeight + heightAboveGround);
            double NwInterpVal = MyMath.LinearInterpolation(new double[] { Field[NwX, NwY, NwZ].Cen.Z, Field[NwX, NwY, NwZ + 1].Cen.Z }, new double[] { Field[NwX, NwY, NwZ].value(type), Field[NwX, NwY, NwZ + 1].value(type) }, NwGroundHeight + heightAboveGround);
            double NeInterpVal = MyMath.LinearInterpolation(new double[] { Field[NeX, NeY, NeZ].Cen.Z, Field[NeX, NeY, NeZ + 1].Cen.Z }, new double[] { Field[NeX, NeY, NeZ].value(type), Field[NeX, NeY, NeZ + 1].value(type) }, NeGroundHeight + heightAboveGround);

            double SwDist = MyMath.distance(Field[SwX, SwY, SwZ].Cen, point);
            double SeDist = MyMath.distance(Field[SeX, SeY, SeZ].Cen, point);
            double NwDist = MyMath.distance(Field[NwX, NwY, NwZ].Cen, point);
            double NeDist = MyMath.distance(Field[NeX, NeY, NeZ].Cen, point);

            ////    Inserire cil calcolo del result. 

            double InvSwDist = 1 / SwDist;
            double InvSeDist = 1 / SeDist;
            double InvNwDist = 1 / NwDist;
            double InvNeDist = 1 / NeDist;
            double TotalInvDist = InvSwDist + InvSeDist + InvNwDist + InvNeDist;
            double InvSwDistNorm = InvSwDist / TotalInvDist;
            double InvSeDistNorm = InvSeDist / TotalInvDist;
            double InvNwDistNorm = InvNwDist / TotalInvDist;
            double InvNeDistNorm = InvNeDist / TotalInvDist;
            result = InvSwDistNorm * SwInterpVal + InvSeDistNorm * SeInterpVal + InvNwDistNorm * NwInterpVal + InvNeDistNorm * NeInterpVal;
            return result;
        
        }

        public double xyzSpeed(double x, double y,double heightAboveGround) 
        {
            //Speed scalar XYZ - wind speed scalar in 3D space, SQRT(UCRT2+VCRT2+WCRT2) 
            double ucrt = this.interpolationForAutomaticGrid(x, y, heightAboveGround, WindFieldCell.WindFieldCellDataType.Ucrt);
            double vcrt = this.interpolationForAutomaticGrid(x, y, heightAboveGround, WindFieldCell.WindFieldCellDataType.Vcrt);
            double wcrt = this.interpolationForAutomaticGrid(x, y, heightAboveGround, WindFieldCell.WindFieldCellDataType.Wcrt);
            return Math.Sqrt(Math.Pow(ucrt, 2) + Math.Pow(vcrt, 2) + Math.Pow(wcrt, 2));
        }

        public double xySpeed(double x, double y, double heightAboveGround)
        {
            //Speed scalar XY - wind speed scalar in horizontal plane, SQRT(UCRT2+VCRT2) (m/s).
            double ucrt = this.interpolationForAutomaticGrid(x, y, heightAboveGround, WindFieldCell.WindFieldCellDataType.Ucrt);
            double vcrt = this.interpolationForAutomaticGrid(x, y, heightAboveGround, WindFieldCell.WindFieldCellDataType.Vcrt);
            return Math.Sqrt(Math.Pow(ucrt, 2) + Math.Pow(vcrt, 2));
        }

        public double inflowAngle(double x, double y, double heighAboveGround)
        {
            //Inflow angle - angle with respect to the horizontal, ATAN(WCRT/Speed_2D) (deg)
            double wcrt = this.interpolationForAutomaticGrid(x, y, heighAboveGround, WindFieldCell.WindFieldCellDataType.Wcrt);
            double xy = this.xySpeed(x, y, heighAboveGround);
            return Math.Atan(wcrt/xy);
        }

    }
    

    public class WindFieldCell
    {
        // 
        //       NOTATION:
        //       NWU - NorthWestUpper / NWL - NorthWestLower
        //       NEU - NorthEastUpper / NEL - NorthEastLower
        //       SWU - SouthWestUpper / SWL - SouthWestLower
        //       SEU - SouthEastUpper / SEL - SouthEastLower
        //       CEN - Center of the cell;
        //
        //           NWU+--------------------+NEU 
        //             /|                   /|
        //            / |                  / |
        //           /  |                 /  |
        //       SWU+--------------------+SEU|  
        //          |   |                |   |
        //          |   |                |   |
        //          |   |                |   |
        //          |   |       *CEN     |   |
        //          |   |                |   |
        //          |   |                |   |
        //   Z      |NWL+----------------|---+NEL
        //   ^      |  /                 |  /
        //   |      | /	                 | /
        //   |      |/		             |/
        //   |   SWL+--------------------+SEL
        //   |
        //   |  >Y
        //   | /
        //   |/
        //   +------------------------>X


        public double P1
         {
            get { return _p1;}
         }     
        public double Ke
        {
            get { return _ke;}
        }
        public double Ep
        {
            get { return _ep;}
        }
        public double Tem1 
        {
            get { return _tem1;}
        }
        public double Wcrt
        {
            get { return _wcrt;}
        }
        public double Vcrt 
        {
            get { return _vcrt;}
        }
        public double Ucrt
        {
            get { return _ucrt; }
        }
        public XYZObject Nwu
        {
            get { return _nwu; }
        }
        public XYZObject Neu
        {
            get { return _neu; }
        }
        public XYZObject Swu
        {
            get { return _swu; }
        }
        public XYZObject Seu
        {
            get { return _seu; }
        }
        public XYZObject Nwl
        {
            get { return _nwl; }
        }
        public XYZObject Nel
        {
            get { return _nel; }
        }
        public XYZObject Swl
        {
            get { return _swl; }
        }
        public XYZObject Sel
        {
            get { return _sel; }
        }
        public XYZObject Cen
        {
            get { return _cen; }
        }

        private double _p1, _ke, _ep, _tem1, _wcrt, _vcrt, _ucrt;
        private XYZObject _nwu, _neu, _swu, _seu;
        private XYZObject _nwl, _nel, _swl, _sel;
        private XYZObject _cen;

        public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt) 
        { 
            _p1 = p1; 
            _ke = ke;
            _ep = ep;
            _wcrt = wcrt;
            _vcrt = vcrt;
            _ucrt = ucrt;
        
        }

        public void AddTem1(double tem1)
        {
            _tem1 = tem1;
        }

        public enum PointPosition
        {

            // nodes around ..
            // errore dovuto allo squeeze della cella.
            // 
            //       NOTATION:
            //       NWU - NorthWestUpper / NWL - NorthWestLower
            //       NEU - NorthEastUpper / NEL - NorthEastLower
            //       SWU - SouthWestUpper / SWL - SouthWestLower
            //       SEU - SouthEastUpper / SEL - SouthEastLower
            //       CEN - Center of the cell;
            //
            //           NWU+--------------------+NEU 
            //             /|                   /|
            //            / |                  / |
            //           /  |                 /  |
            //       SWU+--------------------+SEU|  
            //          |   |                |   |
            //          |   |                |   |
            //          |   |                |   |
            //          |   |       *CEN     |   |
            //          |   |                |   |
            //          |   |                |   |
            //   Z      |NWL+----------------|---+NEL
            //   ^      |  /                 |  /
            //   |      | /	                | /
            //   |      |/		            |/
            //   |   SWL+--------------------+SEL
            //   |
            //   |  >Y
            //   | /
            //   |/
            //   +------------------------>X

        NorthWestUp, 
        NorthEastUp, 
        SouthWestUp,
        SouthEastUp,
        NorthWestLow,
        NorthEastLow,
        SouthWestLow,
        SouthEastLow, 
        Center
        }

        public void AddPoint(PointPosition position, XYZObject point)
        {
            switch (position)
            {
                case PointPosition.Center:
                    _cen = point;
                    break;
                case PointPosition.NorthWestUp:
                    _nwu = point;
                    break;
                case PointPosition.NorthWestLow:
                    _nwl = point;
                    break;
                case PointPosition.NorthEastUp:
                    _neu = point;
                    break;
                case PointPosition.NorthEastLow:
                    _nel = point;
                    break;
                case PointPosition.SouthWestUp:
                    _swu = point;
                    break;
                case PointPosition.SouthWestLow:
                    _swl = point;
                    break;
                case PointPosition.SouthEastUp:
                    _seu = point;
                    break;
                case PointPosition.SouthEastLow:
                    _sel = point;
                    break;
            }
        }

        public double value(WindFieldCellDataType type)
        {


            switch (type)
            {
                case WindFieldCellDataType.Ep :
                    return this.Ep;

                case WindFieldCellDataType.Ke :
                    return this.Ke;

                case WindFieldCellDataType.P1 :
                    return this.P1;         

                case WindFieldCellDataType.Tem1 :
                    return this.Tem1;              

                case WindFieldCellDataType.Ucrt :
                    return this.Ucrt;

                case WindFieldCellDataType.Vcrt :
                    return this.Vcrt;

                case WindFieldCellDataType.Wcrt :
                    return this.Wcrt;

                default :
                    return this.Ucrt;
           }

        }

        public enum WindFieldCellDataType
        {
            P1,
            Ke,
            Ep,
            Tem1,
            Wcrt,
            Vcrt,
            Ucrt
        }

        public bool contains(double x, double y) 
        { 
            // it works only if there is no horizontal distorsion !!!!!!!!!!!!!!!!!

            if (x <= Sel.X && x >= Swl.X && y >= Swl.Y && y <= Nwl.Y)
            {
                return true;
            }
            else 
            {
                return false;
            } 
        
        }

        public double lowerSurfaceInterpolation(double x, double y) 
        {
            //if ((x > this.Sel.X) || (x < this.Swl.X) || (y > this.Nwl.X) || (y < this.Swl.Y))
            //{
            //    throw new System.ArgumentException("(x,y) cannot be outside the square swl sel nwl nel", "original");
            //}
            double[][] terrainPoints = new double[][] { this.Swl.toArray(), this.Nwl.toArray(), this.Nel.toArray(), this.Sel.toArray() };
            return MyMath.FirstOrderTrendSurface(x, y, terrainPoints);
        }
    }

}
