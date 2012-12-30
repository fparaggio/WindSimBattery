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

        public static double[,] DatafirstMaxDerivate(double[,] arrayToBeDerived, double _dx, double _dy)
        {
            int _npx = arrayToBeDerived.GetLength(0);
            int _npy = arrayToBeDerived.GetLength(1);
            double _dxy = Math.Sqrt(Math.Pow(_dx, 2) + Math.Pow(_dx, 2));
            double[,] firstderivate = new double[_npx, _npy];

            for (int i = 0; i < _npx; i++)
            {
                for (int j = 0; j < _npy; j++)
                {

                    double[] derivates = new double[8];

                    if (i != _npx - 1)
                    {
                        derivates[0] = Math.Abs((arrayToBeDerived[i + 1, j] - arrayToBeDerived[i, j]) / _dx);
                    }
                    else derivates[0] = 0;
                    //(0,0)
                    if (i != 0 & j != 0)
                    {
                        derivates[3] = Math.Abs((arrayToBeDerived[i - 1, j - 1] - arrayToBeDerived[i, j]) / _dxy);
                    }
                    else derivates[3] = 0;

                    //(0,-)
                    if (i != 0)
                    {
                        derivates[4] = Math.Abs((arrayToBeDerived[i - 1, j] - arrayToBeDerived[i, j]) / _dx);
                    }
                    else derivates[4] = 0;

                    //(0,npy)
                    if (i != 0 & j != _npy - 1)
                    {
                        derivates[5] = Math.Abs((arrayToBeDerived[i - 1, j + 1] - arrayToBeDerived[i, j]) / _dxy);
                    }
                    else derivates[5] = 0;

                    //(npx,-)


                    //(npx, 0)
                    if (i != _npx - 1 & j != 0)
                    {
                        derivates[1] = Math.Abs((arrayToBeDerived[i + 1, j - 1] - arrayToBeDerived[i, j]) / _dxy);
                    }
                    else derivates[1] = 0;

                    //(-,0)
                    if (j != 0)
                    {
                        derivates[2] = Math.Abs((arrayToBeDerived[i, j - 1] - arrayToBeDerived[i, j]) / _dy);
                    }
                    else derivates[2] = 0;

                    //(-,npy)
                    if (j != _npy - 1)
                    {
                        derivates[6] = Math.Abs((arrayToBeDerived[i, j + 1] - arrayToBeDerived[i, j]) / _dy);
                    }
                    else derivates[6] = 0;

                    // (npx,npy)
                    if (i != _npx - 1 & j != _npy - 1)
                    {
                        derivates[7] = Math.Abs((arrayToBeDerived[i + 1, j + 1] - arrayToBeDerived[i, j]) / _dxy);
                    }
                    else derivates[7] = 0;

                    firstderivate[i, j] = MyMath.Max(derivates);
                }
            }

            return firstderivate;

        }

        public static double GetSmooth(double[,] data, int x, int y, double centerWeight=8.0)
        {
            int _nx = data.GetLength(0);
            int _ny = data.GetLength(1);
            if (x == 0)
            {
                if (y == 0)
                {
                    return ((data[x + 1, y + 1] + data[x, y + 1] + data[x + 1, y] + 3 * data[x, y]) / 6);
                }
                else if (y == _ny - 1)
                {
                    return ((data[x + 1, y - 1] + data[x, y - 1] + data[x + 1, y] + 3 * data[x, y]) / 6);
                }
                else
                {
                    return ((data[x + 1, y - 1] + data[x, y - 1] + data[x + 1, y] + data[x + 1, y + 1] + data[x, y + 1] + 5 * data[x, y]) / 10);
                }

            }


            else if (x == _nx - 1)
            {
                if (y == 0)
                {
                    return ((data[x - 1, y] + data[x, y + 1] + data[x - 1, y + 1] + 3 * data[x, y]) / 6);
                }
                else if (y == _ny - 1)
                {
                    return ((data[x - 1, y - 1] + data[x, y - 1] + data[x - 1, y] + 3 * data[x, y]) / 6);
                }
                else
                {
                    return ((data[x, y + 1] + data[x - 1, y + 1] + data[x - 1, y] + data[x - 1, y - 1] + data[x, y - 1] + 5 * data[x, y]) / 10);
                }
            }

            else if (y == 0)
            {
                //if (x != 0 && x != _nx - 1)
                //{
                    return ((data[x - 1, y] + data[x - 1, y + 1] + data[x, y + 1] + data[x + 1, y + 1] + data[x + 1, y] + 5 * data[x, y]) / 10);
                //}
            }

            else if (y == _ny - 1)
            {
                //if (x != 0 && x != _nx - 1)
                //{
                    return ((data[x - 1, y] + data[x - 1, y - 1] + data[x, y - 1] + data[x + 1, y - 1] + data[x + 1, y] + 5 * data[x, y]) / 10);
                //}
            }

            else
            {
                return (data[x - 1, y + 1] + data[x, y + 1] + data[x + 1, y + 1] + data[x - 1, y] + centerWeight * data[x, y] + data[x + 1, y] + data[x - 1, y - 1] + data[x, y - 1] + data[x + 1, y - 1]) / (8 + centerWeight);
            }
        }

        public static double FirstOrderTrendSurface(double x, double y, double[][] XYZpoints) 
        {
            int n;
            double Sx = 0.0, Sy = 0.0, Sz = 0.0, Sx2 = 0.0, Sy2 = 0.0, Sxy = 0.0, Syz = 0.0, Sxz = 0.0;
            n = XYZpoints.Length;
            for (int i = 0; i < n; i++) 
            {
                Sx += XYZpoints[i][0];
                Sy += XYZpoints[i][1];
                Sz += XYZpoints[i][2];
                Sx2 += XYZpoints[i][0] * XYZpoints[i][0];
                Sy2 += XYZpoints[i][1] * XYZpoints[i][1];
                Sxy += XYZpoints[i][0] * XYZpoints[i][1];
                Syz += XYZpoints[i][1] * XYZpoints[i][2];
                Sxz += XYZpoints[i][0] * XYZpoints[i][2];
            }
            double[,] coefficients = new double[3, 3];
            coefficients[0, 0] = n;
            coefficients[0, 1] = Sx;
            coefficients[0, 2] = Sy;
            coefficients[1, 0] = Sx;
            coefficients[1, 1] = Sx2;
            coefficients[1, 2] = Sxy;
            coefficients[2, 0] = Sy;
            coefficients[2, 1] = Sxy;
            coefficients[2, 2] = Sy2;
            int info;
            alglib.matinvreport rep;
            alglib.rmatrixinverse(ref coefficients, out info, out rep);
            
            // moltiplicare l'inveersa per la matrice [Sz, Sxz , Syz]

            double[,] b_matrix = new double[,] { {Sz},{Sxz},{Syz}};
            int m = coefficients.GetLength(0);
            int num = b_matrix.GetLength(1);
            int k = coefficients.GetLength(1);
            double[,] c = new double[m, num];
            alglib.rmatrixgemm(m, num, k, 1, coefficients, 0, 0, 0, b_matrix, 0, 0, 0, 0, ref c, 0, 0);
            // il risultato sara' la matrice c [{b0},{b1},{b2}] 
            // b0 = c[0,0];
            // b1 = c[1,0];
            // b2 = c[2,0];

            // return Zxy = b0 + b1 * x + b2 * y
            return c[0, 0] + x * c[1, 0] + y * c[2, 0];
        }

        public static int FindClosestLowerIndex(double value, double[] array) 
        {
            for (int i = 0; i < array.Length - 1; i++) 
            {
                if (value >= array[i] && value <= array[i + 1]) 
                {
                    return i;
                }
            }
            return -1;
        }

        public static double[,] extractArrayFromJagged(double[,][] origin, int jaggedIndex) 
        {
            int x = origin.GetLength(0);
            int y = origin.GetLength(1);
            int check = 0;
            double[,] result = new double[x, y];
            for (int i = 0; i < x; i++) 
            {
                for (int j = 0; j < y; j++) 
                {
                    if (origin[i, j].Length <= jaggedIndex) 
                    { 
                        check++; 
                    } 
                    else 
                    {
                        result[i, j] = origin[i, j][jaggedIndex];
                    }
                }
            }

            if (check == 0)
            {
                return result;
            }
            else return null;
    
        }

        public static double MaxOfBidimensionalDoubleArray(double[,] origin) 
        {
            return origin.Cast<double>().Max();  
        }

        public class DoubleMap 
        { 
            public double[,][] data;
            public double xmin, xmax, ymin, ymax;
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
            public DoubleMap(double xMin, double xMax, double yMin, double yMax, int npx, int npy) 
            {
                data = new double[npx, npy][];
                xmin = xMin;
                xmax = xMax;
                ymin = yMin;
                ymax = yMax;
                double stepX = (xMax - xMin) / npx;
                double stepY = (yMax - yMin) / npy;
                for (int i = 0; i < npx; i++) 
                {
                    for (int j = 0; j < npy; j++) 
                    {
                        double[] point = new double[3];
                        point[0] = stepX * i;
                        point[1] = stepY * j;
                        data[i, j] = point;
                    }
                }
            }  
            public DoubleMap(double xMin, double xMax, double yMin, double yMax, double[,] dataset) 
            {
                int npx = dataset.GetLength(0);
                int npy = dataset.GetLength(1);
                data = new double[npx, npy][];
                xmin = xMin;
                xmax = xMax;
                ymin = yMin;
                ymax = yMax;
                double stepX = (xMax - xMin) / npx;
                double stepY = (yMax - yMin) / npy;
                for (int i = 0; i < npx; i++)
                {
                    for (int j = 0; j < npy; j++)
                    {
                        double[] point = new double[3];
                        point[0] = stepX * i;
                        point[1] = stepY * j;
                        point[2] = dataset[i,j];
                        data[i, j] = point;
                    }
                }
            }
        }

        public static DoubleMap interpolatedMap(double iXmin, double iXmax, double iYmin, double iYmax, int iXcells, int iYcells, DoubleMap origin)
        {
            // SE non sono nei confini del gws
            //    return null per ora...
            if (iXmin < origin.xmin || iXmax > origin.xmax || iYmin < origin.ymin || iYmax > origin.ymax) { return null; }
            DoubleMap result = new DoubleMap(iXmin, iXmax, iYmin, iYmax, iXcells, iYcells);

            // Ora sono nei confini del gws
            // creo l'array result  e ci infilo le coordinate del bws
            result.data = new double[iXcells + 1, iYcells + 1][];

            // per ogni coordinata del bws trovo i 4 punti vicini del gws
            // 2 cicli for negli array gwsXcoord e gwsYcoord        
            // x [xmin, xmin+stepx, xmin+2*stepx, ........, xmin +n*stepx]
            // y [ymin, ymin+stepy, ymin+2*stepy, ........, ymin +n*stepy]

            double[] gwsXcoord = new double[origin.Npx];
            double[] gwsYcoord = new double[origin.Npy];
            double stepx = origin.Dx;
            double stepy = origin.Dy;
            double bwsStepX = (iXmax - iXmin) / iXcells;
            double bwsStepY = (iYmax - iYmin) / iYcells;
            for (int i = 0; i < origin.Npx; i++) { gwsXcoord[i] = origin.xmin + stepx * i; }
            for (int j = 0; j < origin.Npy; j++) { gwsYcoord[j] = origin.ymin + stepy * j; }

            for (int i = 0; i < iXcells + 1; i++)
            {
                for (int j = 0; j < iYcells + 1; j++)
                {
                    double[] BwsPoint = new double[3];
                    BwsPoint[0] = iXmin + i * bwsStepX;
                    BwsPoint[1] = iYmin + j * bwsStepY;
                    int Xindex = MyMath.FindClosestLowerIndex(BwsPoint[0], gwsXcoord);
                    int Yindex = MyMath.FindClosestLowerIndex(BwsPoint[1], gwsYcoord);
                    double[][] closestPoints = new double[4][];
                    closestPoints[0] = new double[3];
                    closestPoints[0][0] = gwsXcoord[Xindex];
                    closestPoints[0][1] = gwsYcoord[Yindex];
                    closestPoints[1] = new double[3];
                    closestPoints[1][0] = gwsXcoord[Xindex + 1];
                    closestPoints[1][1] = gwsYcoord[Yindex];
                    closestPoints[2] = new double[3];
                    closestPoints[2][0] = gwsXcoord[Xindex + 1];
                    closestPoints[2][1] = gwsYcoord[Yindex + 1];
                    closestPoints[3] = new double[3];
                    closestPoints[3][0] = gwsXcoord[Xindex];
                    closestPoints[3][1] = gwsYcoord[Yindex + 1];
                    
                    closestPoints[0][2] = origin.data[Xindex, Yindex][2];
                    closestPoints[1][2] = origin.data[Xindex + 1, Yindex][2];
                    closestPoints[2][2] = origin.data[Xindex + 1, Yindex + 1][2];
                    closestPoints[3][2] = origin.data[Xindex, Yindex + 1][2];
                 
                    // calcolo il valore e lo schiaffo nell'array del result.
                    BwsPoint[2] = MyMath.FirstOrderTrendSurface(BwsPoint[0], BwsPoint[1], closestPoints);
                    result.data[i, j] = BwsPoint;
                }
            }

            // restituisco il valore del result 
            return result;
        }
        
        public static DoubleMap SmoothedMap(DoubleMap origin, double slopeThreshold)
        {
            int npx = origin.Npx;
            int npy = origin.Npy;

            double[,] dataset = new double[npx, npy];

            for (int i = 0; i < npx; i++)
            {
                for (int j = 0; j < npy; j++)
                {
                    dataset[i, j] = origin.data[i, j][2];
                }
            }

            double[,] maxDerivate = MyMath.DatafirstMaxDerivate(dataset, origin.Dx, origin.Dy);
            double max = maxDerivate.Cast<double>().Max();

            while (max > slopeThreshold)
            {
                List<double[]> temp = new List<double[]>();
                for (int i = 0; i < npx; i++)
                {
                    for (int j = 0; j < npy; j++)
                    {
                        if (maxDerivate[i, j] > slopeThreshold)
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
                maxDerivate = MyMath.DatafirstMaxDerivate(dataset, origin.Dx, origin.Dy);
                max = maxDerivate.Cast<double>().Max();
            }

            DoubleMap result = new DoubleMap(origin.xmin, origin.xmax, origin.ymin, origin.ymax, dataset);
            return result;
        }

        public static double[] FirstOrderTrendSurfacePassingForAPoint(double x0, double y0, double z0, double[][] XYZpoints)
        {
            int n;
            double  Su2 = 0.0, Sv2 = 0.0, Suv = 0.0, Suw = 0.0, Svw = 0.0;
            n = XYZpoints.Length;
            for (int i = 0; i < n; i++)
            {
                Su2 += (XYZpoints[i][0]-x0) * (XYZpoints[i][0]-x0);
                Sv2 += (XYZpoints[i][1]-y0) * (XYZpoints[i][1]-y0);
                Suv += (XYZpoints[i][0]-x0) * (XYZpoints[i][1]-y0);
                Svw += (XYZpoints[i][1]-y0) * (XYZpoints[i][2]-z0);
                Suw += (XYZpoints[i][0]-x0) * (XYZpoints[i][2]-z0);
            }
            
            double[,] coefficients = new double[2, 2];
            coefficients[0, 0] = Su2;
            coefficients[1, 1] = Sv2;
            coefficients[0, 1] = Suv;
            coefficients[1, 0] = Suv;

            int info;
            alglib.matinvreport rep;
            alglib.rmatrixinverse(ref coefficients, out info, out rep);

            // moltiplicare l'inversa per la matrice [Sz, Sxz , Syz]

            double[,] b_matrix = new double[,] { { Suw }, { Svw } };
            int m = coefficients.GetLength(0);
            int num = b_matrix.GetLength(1);
            int k = coefficients.GetLength(1);
            double[,] c = new double[m, num];
            alglib.rmatrixgemm(m, num, k, 1, coefficients, 0, 0, 0, b_matrix, 0, 0, 0, 0, ref c, 0, 0);
            double[] results = new double[3];
            results[0] = c[0, 0];
            results[1] = c[1, 0];
            results[2] = z0 - c[0, 0] * x0 - c[1, 0] * y0;
            return results;
        }
    }
}

