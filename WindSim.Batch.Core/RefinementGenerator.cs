using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
// Everybody is a genius. But if you judge a fish bu its ability to climb a tree, it will live its whole life believing that it is stupid.

namespace WindSim.Batch.Core
{
    public class RefinementGenerator
    {

        public abstract class Grading
        {
            public double heightFirstLayer;
            public double totalHeight;
            public int numbersOfVericalLayer;
            public bool Rectangle(WSProject project, string bws_filename, double xmax, double ymax, int nx,int nj)
            {
                
                StringBuilder sb = new StringBuilder();
                
                header(sb,nx,nj);
                verticalLayers(sb, numbersOfVericalLayer);
                footer(sb,xmax,ymax);

                File.WriteAllText(project.file.Directory.FullName + "\\dtm\\" + bws_filename + ".bws", sb.ToString());
                project.parameters.CFD.RefinementFileName = bws_filename + ".bws";
                project.parameters.CFD.RefinementType = 2;
                project.save();
                return true;
            }

            private void header(StringBuilder sb, int nx, int nj)
            {
                sb.AppendLine("WindSim version    : 480");
                sb.AppendLine("");
                sb.AppendLine("local_co-ordsys    :  type  x_trans  y_trans    angle");
                sb.AppendLine("");
                sb.AppendLine("i-logical          :    line_i  points   distribution");
                sb.AppendFormat("{0,30}{1,8}{2,10}{3}", 1, nx - 1, "1.000", Environment.NewLine);
                sb.AppendLine("");
                sb.AppendLine("j-logical          :    line_j  points   distribution");
                sb.AppendFormat("{0,30}{1,8}{2,10}{3}", 1, nj - 1, "1.000", Environment.NewLine);
                sb.AppendLine("");
                sb.AppendLine("k-logical          :    line_k  points   distribution  z_upper");
            }

            public virtual void verticalLayers(StringBuilder sb, int nz)
            {
               
            }
     
            private void footer(StringBuilder sb, double xmax, double ymax)
                {
 	            sb.AppendLine("");
                sb.AppendLine("junctions          :         i       j       k  co-ord       x         y         z");
                sb.AppendFormat("{0,30}{1,8}{2,8}{3,8}{4,12:0.0}{5,12:0.0}{6,12:0.0}{7}", 1, 1, 1, 3, 0, 0, 0, Environment.NewLine);
                sb.AppendFormat("{0,30}{1,8}{2,8}{3,8}{4,12:0.0}{5,12:0.0}{6,12:0.0}{7}", 1, 2, 1, 3, 0, ymax, 0, Environment.NewLine);
                sb.AppendFormat("{0,30}{1,8}{2,8}{3,8}{4,12:0.0}{5,12:0.0}{6,12:0.0}{7}", 2, 1, 1, 3, xmax, 0, 0, Environment.NewLine);
                sb.AppendFormat("{0,30}{1,8}{2,8}{3,8}{4,12:0.0}{5,12:0.0}{6,12:0.0}{7}", 2, 2, 1, 3, xmax, ymax, 0, Environment.NewLine);
                sb.AppendLine("");
                sb.AppendLine("junctions_obstacle :         i       j       k  co-ord       x         y         z");
                sb.AppendLine("");
                sb.AppendLine("surfaces_obstacle  :       i_s     i_e     j_s     j_e     k_s     k_e    type");
                sb.AppendLine("");
                sb.AppendLine("volumes_obstacle   :       i_s     i_e     j_s     j_e     k_s     k_e    kind    type      c1      c2");
                sb.AppendLine("");
                }

        }

        public class GeometricalGrading:Grading
        {
            
            public double expansionFactor;



            public double expansionFactorNonLinearEquationFunction(double x)
            {
                double result = heightFirstLayer * Math.Pow(x, numbersOfVericalLayer) - (totalHeight * x) + totalHeight - heightFirstLayer;
                return result;
            }

            public double expansionFactorNonLinearEquationFunctionPrime(double x)
            {
                double result = numbersOfVericalLayer* heightFirstLayer * Math.Pow(x, numbersOfVericalLayer - 1) - totalHeight ;
                return result;
            }

            public GeometricalGrading(double heightFirstL, double totalH, int numOfL)
            {
                heightFirstLayer = heightFirstL;
                totalHeight = totalH;
                numbersOfVericalLayer = numOfL;
                expansionFactor = MyMath.NewtonRaphsonMethod(expansionFactorNonLinearEquationFunction,expansionFactorNonLinearEquationFunctionPrime, 5.0, 0.000000001);
            }

            public override void verticalLayers(StringBuilder sb, int nz)
            {
                double layer_height;

                for (int i = 1; i < nz + 1; i++)
                {
                    layer_height = heightFirstLayer * (Math.Pow(expansionFactor, i) - 1) / (expansionFactor - 1);
                    sb.AppendFormat("{0,30}{1,8}{2,10}{3,13:0.0000}{4}", i, 0, "1.000", layer_height, Environment.NewLine);                   
                }
            }
        }


        public class AritmeticalGrading:Grading
        {

            public double heightDistributionFactor;
            public double additiveCostant;

            public AritmeticalGrading(double expansion, int layers, double height) 
            {
                totalHeight = height;
                numbersOfVericalLayer = layers;
                heightDistributionFactor = -1 / (expansion - (expansion * layers) + layers - 2);
                double first_term = numbersOfVericalLayer * heightDistributionFactor * (numbersOfVericalLayer - 1) / (1 - heightDistributionFactor);
                double second_term = numbersOfVericalLayer*(numbersOfVericalLayer -1)/2;
                additiveCostant = totalHeight / (first_term + second_term);
                heightFirstLayer = additiveCostant*heightDistributionFactor*(numbersOfVericalLayer-1)/(1-heightDistributionFactor);
            }

            public override void verticalLayers(StringBuilder sb, int nz)
            {
                double layer_height = heightFirstLayer;
                double absolute_height = heightFirstLayer;
                for (int i = 1; i < nz + 1; i++)
                {
                    sb.AppendFormat("{0,30}{1,8}{2,10}{3,13:0.0000}{4}", i, 0, "1.000", absolute_height, Environment.NewLine);
                    layer_height = layer_height + additiveCostant;
                    absolute_height = absolute_height + layer_height;
                    
                }
            }

        
        }

    }
}
