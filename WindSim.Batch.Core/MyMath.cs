using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindSim.Batch.Core
{
    public class MyMath
    {    
        public static double[] LeastSquaresBestFitLine(double[] x, double[] y)
        {
            int n = x.Length;
            double xSum = 0.0;
            double ySum = 0.0;
            double xySum = 0.0;
            double xSqrSum = 0.0;
            double denominator = 0.0;
            double bNumerator = 0.0;
            double mNumerator = 0.0;
            double bestfitYintercept = 0.0;
            double bestfitSlope = 0.0;
            double sigma = 0.0;
            double sumOfResidualsSquared = 0.0;
            double totalSumOfSquares = 0.0;
            double yAverage = y.Average();
            double r_2 = 0.0;
            double xAverage = x.Average();

            double sumOfxMinusXAverageSquared = 0.0;
            double sigmaIntercept = 0.0;
            double sigmaSlope = 0.0;

            //calculate sums
            for (int i = 0; i < n; i++)
            {
                xSum += x[i];
                ySum += y[i];
                xySum += x[i] * y[i];
                xSqrSum += x[i] * x[i];
            }

            denominator = n * xSqrSum - xSum * xSum;
            bNumerator = xSqrSum * ySum - xSum * xySum;
            mNumerator = n * xySum - xSum * ySum;

            //calculate best-fit y-intercept
            bestfitYintercept = bNumerator / denominator;

            //calculate best-fit slope
            bestfitSlope = mNumerator / denominator;

            //calculate best-fit standard deviation
            for (int i = 0; i < n; i++)             
            {
                sumOfResidualsSquared +=
                    (y[i] - bestfitYintercept - bestfitSlope * x[i]) *
                    (y[i] - bestfitYintercept - bestfitSlope * x[i]);
            }

            //calculate total sum of squares
            for (int i = 0; i < n; i++)             
            {
                totalSumOfSquares +=
                    (y[i] - yAverage) *
                    (y[i] - yAverage);
            }
            sigma = Math.Sqrt(sumOfResidualsSquared / (n - 2));
           
            

            // calculate r2
            r_2 = 1 - (sumOfResidualsSquared / totalSumOfSquares);

            // calculate sum of x-xave squared
            for (int i = 0; i < n; i++)
            {
                sumOfxMinusXAverageSquared +=
                    (x[i] - xAverage ) *
                    (x[i] - xAverage );
            }

            // calculate sigmaSlope
            sigmaSlope= sigma  / ( Math.Sqrt(sumOfxMinusXAverageSquared));

            // calculate sigmaIntercept
            sigmaIntercept = sigma * Math.Sqrt(((1 / n) + ((xAverage * xAverage) / sumOfxMinusXAverageSquared)));

            //  { bestfitYintercept, bestfitSlope, sigma, r_2, sigmaIntercept, sigmaSlope };
            return new double[] { bestfitYintercept, bestfitSlope, sigma, r_2, sigmaIntercept, sigmaSlope };
        }

        public static double Max(params double[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values");

            double result = double.MinValue;

            for (int i = 0; i < values.Length; i++)
            {
                result = Math.Max(result, values[i]);
            }

            return result;
        }

        public static double AverageFromDoubleArray(double[] dblArray)
        {
            double dblResult = 0;
            foreach (double dblValue in dblArray)
                dblResult += dblValue;
            return dblResult / dblArray.Length;
        }

        public delegate double nonLinearEquationFunction(double x);

        public static double SecantMethod(nonLinearEquationFunction f, double a, double b, double epsilon)
        {
            double x1 = a;
            double x2 = b;
            double fb = f(b);
            while (Math.Abs(f(x2)) > epsilon)
            {
                double mpoint = x2 - (x2 - x1) * fb / (fb - f(x1));
                x1 = x2;
                x2 = mpoint;
                fb = f(x2);
            }
            return x2;
        }


        public static double NewtonRaphsonMethod(nonLinearEquationFunction f, nonLinearEquationFunction fprime, double x0, double epsilon)
        {
            double f0 = f(x0);
            double x = x0;
            while (Math.Abs(f(x)) > epsilon) 
            {
                x -= f0/fprime(x);
                f0 = f(x);
            }
            return x;
        }

        public static double rmse(double[] data, double[] reference) 
        {
            if (data.Length == reference.Length) 
            {
                double sumOfResidualsSquared =0.0;
                int n = data.Length;

                for (int i = 0; i < data.Length; i++)
                {
                    sumOfResidualsSquared +=
                        (data[i] - reference[i]) * (data[i] - reference[i]);
                }

                return Math.Sqrt(sumOfResidualsSquared / n);
            }
            else return -99999.0;
        
        }

        public static double ustar_neutral(double u, double z, double z0, double k)
        {
            double ustar = new double();
            ustar = (u * k) / (Math.Log(z / z0));
            return ustar;
        }

        public static double[] mo_neutral_u(double[] z, double k, double ustar, double z0 ) 
        {
            double[] mo = new double[z.Length];
            for (int i = 0; i < z.Length; i++) 
            {
                mo[i] = (ustar / k) * (Math.Log(z[i] / z0)); ;
            }
            return mo;
        }

    }
}
