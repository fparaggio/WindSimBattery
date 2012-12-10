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


        public double GetSmooth(int x, int y, SmoothType type, double centerWeight) 
        {
            switch (type)
            { 
                case SmoothType.Height:
                    return (this.data[x - 1, y + 1].height + this.data[x, y + 1].height + this.data[x + 1, y + 1].height + this.data[x - 1, y].height + centerWeight*this.data[x, y].height + this.data[x + 1, y].height + this.data[x - 1, y - 1].height + this.data[x, y - 1].height + this.data[x + 1, y - 1].height) / (8+centerWeight);
                    break;
                case SmoothType.Rough:
                    return (this.data[x - 1, y + 1].rough + this.data[x, y + 1].rough + this.data[x + 1, y + 1].rough + this.data[x - 1, y].rough + centerWeight * this.data[x, y].rough + this.data[x + 1, y].rough + this.data[x - 1, y - 1].rough + this.data[x, y - 1].rough + this.data[x + 1, y - 1].rough) / (8+centerWeight);
                    break;
                default:
                    return -1;
                    break;
            }

            
        }
    }

    public class GwsNode
    {
        public double height;
        public double rough;
    }
}
