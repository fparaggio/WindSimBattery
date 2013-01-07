using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindSim.Batch.Core
{
    class ComplexityDataPoint
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
                              where (n[4] < distance) && (n[5] < bearingMax) && (n[5] > bearingMin)
                              select n;
                return sublist.ToList();
            }
            else
            {
                var sublist = from n
                              in dataset
                              where (n[4] < distance) && (((n[5]>=0 ) && (n[5] < bearingMax)) || ((n[5] > bearingMin) &&  (n[5] <= 360)))
                              select n;
                return sublist.ToList();
            }
            
        
        }

        ComplexityDataPoint(FileGws Map, double xObject, double yObject, double zObject) 
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
