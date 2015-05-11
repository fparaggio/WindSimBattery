using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindSim.Batch.Core
{
    public class FileGws
    {
        public enum MapType
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

        public string filepath;
        
        public MyMath.DoubleMap Map(MapType type)
        {
            int xNodes = Npx;
            int yNodes = Npy;
            double[,] dataset = new double[xNodes, yNodes];
            for (int i = 0; i < xNodes; i++)
            {
                for (int j = 0; j < yNodes; j++)
                {
                    double value;
                    switch (type)
                    {
                        case MapType.Height:
                            value = data[i, j].height;
                            break;
                        case MapType.Rough:
                            value = data[i, j].rough;
                            break;
                        default:
                            value = data[i, j].rough;
                            break;
                    }
                    dataset[i, j] = value;
                }
            }

            MyMath.DoubleMap result = new MyMath.DoubleMap(xmin, xmax, ymin, ymax, dataset);
            return result;
        }

        public FileGws(int nx, int ny, double xMin, double xMax, double yMin, double yMax, string windsimVer, string areaName, int coordinatesyst, string gws_filepath) 
        {
            data = new GwsNode[nx, ny];
            WindsimVersion= windsimVer;
            AreaName = areaName;
            CoordinateSystem = coordinatesyst;
            xmin = xMin; 
            xmax = xMax;
            ymin = yMin;
            ymax = yMax;
            filepath = gws_filepath;
        }

    }

    public class GwsNode
    {
        public double height;
        public double rough;
    }
    
}
