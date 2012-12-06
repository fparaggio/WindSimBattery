using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindSim.Batch.Core
{
    public class FileGws
    {
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


    }

    public class GwsNode
    {
        public double height;
        public double rough;
    }
}
