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
    public class ComplexityDataPoint
    {
        private double centerX;
        private double centerY;
        private double centerZ;
        public double Xcen
         {
            get { return centerX; }
         }
        public double Ycen
        {
            get { return centerY; }
        }
        public double Zcen
        {
            get { return centerZ; }
        }
        private List<double[]> dataset = new List<double[]>();
        public List<double[]> XYZRougDistAzim(double bearingMin, double bearingMax, double distance) 
        {
            
            if (bearingMax >= bearingMin)
            {
                var sublist = from n
                              in dataset
                              where (n[4] < distance) && (n[5] <= bearingMax) && (n[5] >= bearingMin)
                              select n;
                return sublist.ToList();
            }
            else
            {
                var sublist = from n
                              in dataset
                              where (n[4] < distance) && (((n[5]>=0 ) && (n[5] <= bearingMax)) || ((n[5] >= bearingMin) &&  (n[5] <= 360)))
                              select n;
                return sublist.ToList();
            }
            
        
        }

        public ComplexityDataPoint(FileGws Map, double xObject, double yObject, double zObject) 
        { 
        // check (xObject,yObject)
            if (xObject > Map.xmin && xObject < Map.xmax && yObject > Map.ymin && yObject < Map.ymax) 
            {
                centerX = xObject;
                centerY = yObject;
                centerZ = zObject;

            for(int i = 0; i < Map.Npx; i++)
                {
                    for (int j = 0; j < Map.Npy; j++) 
                    {
                        double[] point = new double[6];
                        GwsNode node = Map.data[i, j];
                        point[0] = node.x;
                        point[1] = node.y;
                        point[2] = node.height;
                        point[3] = node.rough;
                        double[] nodeCoordinates = new double[] { node.x, node.y };
                        double[] centerCoordinates = new double[] { xObject, yObject };
                        point[4] = MyMath.planarXYDistanceBetweenTwoPoints(nodeCoordinates, centerCoordinates);
                        point[5] = MyMath.planarAzimuthDegreesBetweenTwoPoints(nodeCoordinates, centerCoordinates);

                        dataset.Add(point);

                    }
                }
            
            
            
            
            } 

        }

    }
}
