//------------------------------------------------------------------------------
// Copyright (c) 2012, 2013, 2014, 2015 Francesco Paraggio.
// 
// Author: Francesco Paraggio fparaggio@gmail.com
// 
// This file is part of WindSimBattery
// 
// WindSimBattery is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License along with this program. If not, see http://www.gnu.org/licenses/.
// 
// The usage of a range of years within a copyright statement contained within this distribution should be interpreted as being equivalent to a list of years including the first and last year specified and all consecutive years between them. For example, a copyright statement that reads 'Copyright (c) 2005, 2007- 2009, 2011-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2007, 2008, 2009, 2011, 2012' and a copyright statement that reads "Copyright (c) 2005-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012'."
//------------------------------------------------------------------------------

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
