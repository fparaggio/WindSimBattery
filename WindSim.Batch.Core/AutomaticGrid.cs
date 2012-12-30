using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindSim.Batch.Core
{
    public class AutomaticGrid
    {
        public class Geometrical
        {
            public GeometricalColumn[,] data;
            public MyMath.DoubleMap firstCellHeightMap;
            public MyMath.DoubleMap GroundHeightMap;
           
            public int xNodes
            {
                get { return data.GetLength(0); }
            }
            public int yNodes
            {
                get { return data.GetLength(1); }
            }
            public int slabs;
            double xmin, xmax, ymin, ymax;
            public double maxGroungHeight
            {
                get { return MyMath.MaxOfBidimensionalDoubleArray(MyMath.extractArrayFromJagged(GroundHeightMap.data, 2)); }
            }
            public double[] minSlabHeight 
            {
                get 
                {
                    double[] result = new double[slabs];
                    int x = xNodes;
                    int y = yNodes;

                    for (int z = 0; z < slabs; z++) 
                    {
                        List<double> temp = new List<double>();
                        for (int i = 0; i < x; i++)
                            {
                                for (int j = 0; j < y; j++)
                                {
                                   temp.Add(data[i, j].nodes[z]);
                                }
                            }
                    result[z] = temp.Min();
                    }
                    return result;
                }
            }
            public double[] maxSlabHeight
            {
                get
                {
                    double[] result = new double[slabs];
                    int x = xNodes;
                    int y = yNodes;

                    for (int z = 0; z < slabs; z++)
                    {
                        List<double> temp = new List<double>();
                        for (int i = 0; i < x; i++)
                        {
                            for (int j = 0; j < y; j++)
                            {
                                temp.Add(data[i, j].nodes[z]);
                            }
                        }
                        result[z] = temp.Max();
                    }
                    return result;
                }
            }
            public Geometrical(FileGws gws, double threshold, double iXmin, double iXmax, double iYmin, double iYmax, int iXcells, int iYcells, double totalH, int numOfL)
            {
                slabs= numOfL;

                firstCellHeightMap = MyMath.interpolatedMap(iXmin, iXmax, iYmin, iYmax, iXcells, iYcells, MyMath.SmoothedMap(HFirstCell(gws.Map(FileGws.MapType.Rough)), threshold));
                GroundHeightMap = MyMath.interpolatedMap(iXmin, iXmax, iYmin, iYmax, iXcells, iYcells, gws.Map(FileGws.MapType.Height));
              
                xmin = iXmin;
                xmax = iXmax;
                ymin = iYmin; 
                ymax = iYmax; 

                int x,y;
                x = firstCellHeightMap.data.GetLength(0);
                y = firstCellHeightMap.data.GetLength(1);

                data = new GeometricalColumn[x, y];
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        GeometricalColumn column = new GeometricalColumn(firstCellHeightMap.data[i, j][2], totalH, numOfL, firstCellHeightMap.data[i, j][0], firstCellHeightMap.data[i, j][1], GroundHeightMap.data[i,j][2]);
                        data[i, j] = column;
                    }
                }
            }


            public static MyMath.DoubleMap HFirstCell(MyMath.DoubleMap roughnessMap, double a = 3.1175, double b = -0.396)
            {
                int x = roughnessMap.Npx;
                int y = roughnessMap.Npy;
                double[,] dataset = new double[x, y];
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        dataset[i, j] = roughnessMap.data[i, j][2] * a * Math.Pow(roughnessMap.data[i, j][2], b);
                    }
                }

                MyMath.DoubleMap result = new MyMath.DoubleMap(roughnessMap.xmin, roughnessMap.xmax, roughnessMap.ymin, roughnessMap.ymax, dataset);
                return result;
            }

            public class GeometricalColumn
            {
                public double expansionFactor;
                public double heightFirstLayer;
                private double totalHeight;
                private int numbersOfVericalLayer;
                public double xCoord, yCoord;
                public double[] nodes;
                public double terrainHeight;
                public double expansionFactorNonLinearEquationFunction(double x)
                {
                    double result = heightFirstLayer * Math.Pow(x, numbersOfVericalLayer) - (totalHeight * x) + totalHeight - heightFirstLayer;
                    return result;
                }

                public double expansionFactorNonLinearEquationFunctionPrime(double x)
                {
                    double result = numbersOfVericalLayer * heightFirstLayer * Math.Pow(x, numbersOfVericalLayer - 1) - totalHeight;
                    return result;
                }

                public GeometricalColumn(double heightFirstL, double totalH, int numOfL, double x, double y, double terrainH)
                {
                    heightFirstLayer = heightFirstL;
                    totalHeight = totalH;
                    numbersOfVericalLayer = numOfL;
                    terrainHeight = terrainH;
                    xCoord = x;
                    yCoord = y;
                    expansionFactor = MyMath.NewtonRaphsonMethod(expansionFactorNonLinearEquationFunction, expansionFactorNonLinearEquationFunctionPrime, 5.0, 0.000000001);
                    nodes = new double[numbersOfVericalLayer];
                    for (int i = 1; i < numbersOfVericalLayer + 1; i++)
                    {
                        nodes[i - 1] = heightFirstLayer * (Math.Pow(expansionFactor, i) - 1) / (expansionFactor - 1); 
                    }

                }
            }

            //public bool SaveToBws(WSProject project, string bws_filename)
            //{

            //    StringBuilder sb = new StringBuilder();

            //    header(sb, xNodes, yNodes);
            //    verticalLayers(sb, zNodes);
            //    footer(sb, xmax, ymax);

            //    File.WriteAllText(project.file.Directory.FullName + "\\dtm\\" + bws_filename + ".bws", sb.ToString());
            //    project.parameters.CFD.RefinementFileName = bws_filename + ".bws";
            //    project.parameters.CFD.RefinementType = 2;
            //    project.save();
            //    return true;
            //}

            public bool SaveToBws(WSProject project, string bws_filename)
            {

                StringBuilder sb = new StringBuilder();
                header(sb);
                logicals(sb, xNodes - 1, yNodes - 1, slabs);
                junctions(sb, xNodes, yNodes);
                junctions_obstacles(sb, xNodes, yNodes, slabs);
                footer(sb, xmax, ymax);

                //File.WriteAllText("c:\\test.bws", sb.ToString());
                File.WriteAllText(project.file.Directory.FullName + "\\dtm\\" + bws_filename + ".bws", sb.ToString());
                project.parameters.CFD.RefinementFileName = bws_filename + ".bws";
                project.parameters.CFD.RefinementType = 2;
                project.save();
                return true;

            }

            private void header(StringBuilder sb)
            {
                sb.AppendLine("WindSim version    : 480");
                sb.AppendLine("");
                sb.AppendLine("local_co-ordsys    :  type  x_trans  y_trans    angle");
                sb.AppendLine("");
            }

            private void logicals(StringBuilder sb, int nx, int nj, int numberOfSlabs){
                double layer_height;
                sb.AppendLine("i-logical          :    line_i  points   distribution");
                for (int i = 1; i < nx + 1; i++)
                {
                    sb.AppendFormat("{0,30}{1,8}{2,10}{3}", i, "0", "1.000", Environment.NewLine);
                }

                sb.AppendLine("");
                sb.AppendLine("j-logical          :    line_j  points   distribution");
                for (int j = 1; j < nj + 1; j++)
                {
                    sb.AppendFormat("{0,30}{1,8}{2,10}{3}", j, "0", "1.000", Environment.NewLine);
                }
                sb.AppendLine("");
                sb.AppendLine("k-logical          :    line_k  points   distribution  z_upper");
                for (int k = 0; k < numberOfSlabs; k++)
                {
                    layer_height = maxSlabHeight[k];
                    sb.AppendFormat("{0,30}{1,7}{2,11}{3,13:0.0}{4}", k+1, 0, "1.000", layer_height, Environment.NewLine);
                }
                sb.AppendLine("");
            }

            private void junctions(StringBuilder sb, int ni, int nj)
            {
                
                sb.AppendLine("junctions          :         i       j       k  co-ord       x         y         z");
                for (int j = 1; j < nj + 1; j++)
                {
                    for (int i = 1; i < ni + 1; i++) 
                    {
                        sb.AppendFormat("{0,30}{1,8}{2,8}{3,8}{4,10:0.0}{5,10:0.0}{6,10:0.0}{7}", i, j, 1, 3, data[i - 1, j - 1].xCoord, data[i - 1, j - 1].yCoord, 0, Environment.NewLine);
                    }
                }
                
                
                sb.AppendLine("");
            }

            private void junctions_obstacles(StringBuilder sb, int ni, int nj, int numberOfSlabs)
            {
                sb.AppendLine("junctions_obstacle :         i       j       k  co-ord       x         y         z");
                for (int k = 0; k < numberOfSlabs; k++)
                {
                    for (int j = 1; j < nj + 1; j++)
                    {
                        for (int i = 1; i < ni + 1; i++)
                        {
                            sb.AppendFormat("{0,30}{1,8}{2,8}{3,8}{4,10:0.0}{5,10:0.0}{6,10:0.0}{7}", i, j, k+2, 3, data[i - 1, j - 1].xCoord, data[i - 1, j - 1].yCoord, data[i - 1, j - 1].nodes[k], Environment.NewLine);
                        }
                    }
                }
                sb.AppendLine("");
            }
            
            private void footer(StringBuilder sb, double xmax, double ymax)
            {
                sb.AppendLine("surfaces_obstacle  :       i_s     i_e     j_s     j_e     k_s     k_e    type");
                sb.AppendLine("");
                sb.AppendLine("volumes_obstacle   :       i_s     i_e     j_s     j_e     k_s     k_e    kind    type      c1      c2");
                sb.AppendLine("");
            }

        }
    }
}