using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindSim.Batch.Core
{
    public class FileGws
    {
        public enum SmoothType
        {
            Height,
            Rough,
            HFirstcell
        }
        public GwsNode[,] data;
        
        public string WindsimVersion, AreaName;
        public int CoordinateSystem;
        public double xmin, xmax, ymin, ymax,zmin,zmax;

        public int Npx
         {
            get { return data.GetLength(0);}
         }

        public int Npy
        {
            get { return data.GetLength(1); }
        }

        public double Dx
        {
            get { return Math.Abs((xmax-xmin)/(Npx-1)); }
        }
        
        public double Dy
        {
            get { return Math.Abs((ymax - ymin) / (Npy - 1)); }
        }

        public double Dxy
        {
            get { return Math.Sqrt(Math.Pow(Dx, 2) + Math.Pow(Dy, 2)); }
        }  
       
        public FileGws(int nx, int ny, double xMin, double xMax, double yMin, double yMax, string windsimVer, string areaName, int coordinatesyst) 
        {
            data = new GwsNode[nx, ny];
            WindsimVersion= windsimVer;
            AreaName = areaName;
            CoordinateSystem = coordinatesyst;
            xmin = xMin; 
            xmax = xMax;
            ymin = yMin;
            ymax = yMax; 
        }
        
        public double[,] hFirstCellArray(double slopeThreshold)
        {
            double[,] dataset = new double[Npx, Npy];
            
            for (int i=0; i < Npx; i++) 
            {
                for (int j = 0; j < Npy; j++) 
                {
                    dataset[i, j] = this.data[i, j].HFirstCell(); 
                }
            }

            double[,] maxDerivate = MyMath.DatafirstMaxDerivate(dataset, Dx, Dy);
            double max = maxDerivate.Cast<double>().Max();  

            while (max > slopeThreshold)
            {
                List<double[]> temp = new List<double[]>();
                for (int i=0; i < Npx; i++) 
                 {
                    for (int j = 0; j < Npy; j++) 
                    {
                        if(maxDerivate[i,j]>slopeThreshold)
                        {
                            double[] temp_array = new double[3];
                            temp_array[0] = i;
                            temp_array[1] = j;
                            temp_array[2] = MyMath.GetSmooth(dataset, i, j, 8);
                            temp.Add(temp_array);
                        }
                    }
                 }
                foreach (double[] modified_point in temp) 
                {
                    dataset[Convert.ToInt32(modified_point[0]), Convert.ToInt32(modified_point[1])] = modified_point[2];
                }
                 maxDerivate = MyMath.DatafirstMaxDerivate(dataset, Dx, Dy);
                 max = maxDerivate.Cast<double>().Max();    
            }
            return dataset;    
        }

        public double[,][] interpolatedData(double iXmin, double iXmax, double iYmin, double iYmax, int iXcells, int iYcells, SmoothType dataToInterpolate) 
        { 
                // SE non sono nei confini del gws
                //    return null per ora...
                if (iXmin < xmin || iXmax > xmax || iYmin < ymin || iYmax > ymax) { return null; }
                double[,] firstcellsArray = hFirstCellArray(2);
                // Ora sono nei confini del gws
                // creo l'array result  e ci infilo le coordinate del bws
                double[,][] result = new double[iXcells + 1, iYcells + 1][];

                // per ogni coordinata del bws trovo i 4 punti vicini del gws
                // 2 cicli for negli array gwsXcoord e gwsYcoord        
                // x [xmin, xmin+stepx, xmin+2*stepx, ........, xmin +n*stepx]
                    // y [ymin, ymin+stepy, ymin+2*stepy, ........, ymin +n*stepy]
                
                    double[] gwsXcoord = new double[Npx];
                    double[] gwsYcoord = new double[Npy];
                    double stepx = Dx;
                    double stepy = Dy;
                    double bwsStepX = (iXmax - iXmin)/iXcells;
                    double bwsStepY = (iYmax - iYmin)/iYcells;
                    for (int i = 0; i < Npx; i++) { gwsXcoord[i] = xmin + stepx * i; }
                    for (int j = 0; j < Npy; j++) { gwsYcoord[j] = ymin + stepy * j; }

                    for (int i = 0; i < iXcells + 1; i++) 
                    {
                        for (int j = 0; j < iYcells + 1; j++) 
                        {
                            double[] BwsPoint = new double[3];
                            BwsPoint[0] = iXmin + i * bwsStepX;
                            BwsPoint[1] = iYmin + j * bwsStepY;
                            int Xindex = MyMath.FindClosestLowerIndex(BwsPoint[0], gwsXcoord);
                            int Yindex = MyMath.FindClosestLowerIndex(BwsPoint[1], gwsYcoord);
                            double[][] closestPoints = new double[4][];
                            closestPoints[0] = new double[3];
                            closestPoints[0][0] = gwsXcoord[Xindex];
                            closestPoints[0][1] = gwsYcoord[Yindex];
                            closestPoints[1] = new double[3];
                            closestPoints[1][0] = gwsXcoord[Xindex+1];
                            closestPoints[1][1] = gwsYcoord[Yindex];
                            closestPoints[2] = new double[3];
                            closestPoints[2][0] = gwsXcoord[Xindex + 1];
                            closestPoints[2][1] = gwsYcoord[Yindex + 1];
                            closestPoints[3] = new double[3];
                            closestPoints[3][0] = gwsXcoord[Xindex];
                            closestPoints[3][1] = gwsYcoord[Yindex + 1];
                            switch (dataToInterpolate)
                            {
                                case SmoothType.HFirstcell:
                                    closestPoints[0][2] = firstcellsArray[Xindex, Yindex];
                                    closestPoints[1][2] = firstcellsArray[Xindex+1, Yindex];
                                    closestPoints[2][2] = firstcellsArray[Xindex + 1, Yindex + 1];
                                    closestPoints[3][2] = firstcellsArray[Xindex, Yindex + 1];
                                    break;
                                case SmoothType.Rough:
                                    closestPoints[0][2] = data[Xindex, Yindex].rough;
                                    closestPoints[1][2] = data[Xindex+1, Yindex].rough;
                                    closestPoints[2][2] = data[Xindex + 1, Yindex + 1].rough;
                                    closestPoints[3][2] = data[Xindex, Yindex + 1].rough;
                                    break;
                                case SmoothType.Height:
                                    closestPoints[0][2] = data[Xindex, Yindex].height;
                                    closestPoints[1][2] = data[Xindex+1, Yindex].height;
                                    closestPoints[2][2] = data[Xindex + 1, Yindex + 1].height;
                                    closestPoints[3][2] = data[Xindex + 1, Yindex + 1].height;
                                    break;
                            }
                            // calcolo il valore e lo schiaffo nell'array del result.
                            BwsPoint[2] = MyMath.FirstOrderTrendSurface(BwsPoint[0], BwsPoint[1], closestPoints);
                            result[i, j] = BwsPoint;
                        }
                    }

                // restituisco il valore del result 
                    return result;
        }
    }

    public class GwsNode
    {
        public double height;
        public double rough;
        public double HFirstCell()
        {
            double y = 3.1175* Math.Pow(rough,-0.396);
            return rough*y;
        }
    }
}
