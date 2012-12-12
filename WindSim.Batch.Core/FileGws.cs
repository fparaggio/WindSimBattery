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
            Rough
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
