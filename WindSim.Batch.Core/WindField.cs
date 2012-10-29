using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindSim.Batch.Core
{
    public class WindField
    {
        public PhiFile phi=null;
        public XYZFile xyz=null;

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


        public double[] z0(int x, int y)
        {
         double[] arr = MyMath.LeastSquaresBestFitLine(this.zcen_log(x,y),this.ucrt(x,y));
          //  { AbestfitYintercept, BbestfitSlope, sigma, AsigmaIntercept, BsigmaSlope};
         double A = arr[1];
         double B = arr[0];
         double z0 = Math.Exp(-1 * B / A);
         double sigmaA = arr[3];
         double sigmaB = arr[4];
         double sigmaz0 = z0 * (-1 * (B / A) * ((sigmaB / B) + (sigmaA / A)));
         
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

        public WindField(WSProject project ,int settore) 
        
        {
            // inistialize phi and xyz

            string  phi_file = project.file.DirectoryName + "\\windfield\\" + settore + "_red.phi";
            string  xyz_file = project.file.DirectoryName + "\\windfield\\" + settore + "_red.xyz";
            
            FileInfo phi_file_check = new FileInfo(phi_file);
            FileInfo xyz_file_check = new FileInfo(xyz_file);

            // check if required files exists

            if (phi_file_check.Exists && xyz_file_check.Exists)
            {
                phi = new PhiFile(phi_file);
                xyz = new XYZFile(xyz_file);
            }
            else
            {
                phi = null;
                xyz = null;
            }

        }
    }

}
