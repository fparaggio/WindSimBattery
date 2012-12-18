using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindSim.Batch.Core;

namespace WindSim.Batch.Core.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Test_MyMath
    {
        public Test_MyMath()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region LeastSquaresBestFitLine

        [TestMethod]
        public void Test_LeastSquaresBestFitLine_intercept_1()
        {
            double[] xdata = new double[]{12.0,13.0,12.0,45.0,56.0,23.0,89.0,65.0,251.0,12.0};
            double[] ydata = new double[]{54.0,27.0,7.0,324.0,17.0,28.0,36.0,12.0,245.0,22.0};
            double[] result = MyMath.LeastSquaresBestFitLine(xdata,ydata);
            Assert.AreEqual(Math.Round(result[0],3), 31.012);
        }

        [TestMethod]
        public void Test_LeastSquaresBestFitLine_slope_1()
        {
            double[] xdata = new double[] { 12.0, 13.0, 12.0, 45.0, 56.0, 23.0, 89.0, 65.0, 251.0, 12.0 };
            double[] ydata = new double[] { 54.0, 27.0, 7.0, 324.0, 17.0, 28.0, 36.0, 12.0, 245.0, 22.0 };
            double[] result = MyMath.LeastSquaresBestFitLine(xdata, ydata);
            Assert.AreEqual(Math.Round(result[1], 4), 0.7991);
        }

        [TestMethod]
        public void Test_LeastSquaresBestFitLine_r2_1()
        {
            double[] xdata = new double[] { 12.0, 13.0, 12.0, 45.0, 56.0, 23.0, 89.0, 65.0, 251.0, 12.0 };
            double[] ydata = new double[] { 54.0, 27.0, 7.0, 324.0, 17.0, 28.0, 36.0, 12.0, 245.0, 22.0 };
            double[] result = MyMath.LeastSquaresBestFitLine(xdata, ydata);
            Assert.AreEqual(Math.Round(result[3], 4), 0.2736);
        }

        [TestMethod]
        public void Test_LeastSquaresBestFitLine_intercept_2()
        {
            double[] xdata = new double[] { 0.929713,0.059222,0.414344,0.064404,0.103987 };
            double[] ydata = new double[] { 0.792837,0.6631,0.43534,0.432,0.709669 };
            double[] result = MyMath.LeastSquaresBestFitLine(xdata, ydata);
            Assert.AreEqual(Math.Round(result[0], 4), 0.5477);
        }

        [TestMethod]
        public void Test_LeastSquaresBestFitLine_slope_2()
        {
            double[] xdata = new double[] { 0.929713, 0.059222, 0.414344, 0.064404, 0.103987 };
            double[] ydata = new double[] { 0.792837, 0.6631, 0.43534, 0.432, 0.709669 };
            double[] result = MyMath.LeastSquaresBestFitLine(xdata, ydata);
            Assert.AreEqual(Math.Round(result[1], 4), 0.1874);
        }

        [TestMethod]
        public void Test_LeastSquaresBestFitLine_r2_2()
        {
            double[] xdata = new double[] { 0.929713, 0.059222, 0.414344, 0.064404, 0.103987 };
            double[] ydata = new double[] { 0.792837, 0.6631, 0.43534, 0.432, 0.709669 };
            double[] result = MyMath.LeastSquaresBestFitLine(xdata, ydata);
            Assert.AreEqual(Math.Round(result[3], 4), 0.1817);
        }
        
        #endregion

        #region Rmse
        [TestMethod]
        public void Test_rsme()
        {
            double[] xdata = new double[] { 63.0, 31.0, 61.0, 52.0, 69.0 };
            double[] ydata = new double[] { 74.0, 54.0, 33.0, 72.0, 19.0 };
            double result = MyMath.rmse(xdata, ydata);
            Assert.AreEqual(29.4414674,Math.Round(result,7));
        }

        [TestMethod]
        public void Test_rsme_error()
        {
            double[] xdata = new double[] { 63.0, 31.0, 61.0, 52.0 };
            double[] ydata = new double[] { 74.0, 54.0, 33.0, 72.0, 19.0 };
            double result = MyMath.rmse(xdata, ydata);
            Assert.AreEqual(-99999.0, result);
        }

        #endregion

        #region DatafirstMaxDerivate
        // data from testMyMathGws.xlsx
        [TestMethod]
        public void Test_DatafirstMaxDerivate1()
        {
            double[,] arrayToDerive = new double[3,3] { {4.0,1.0,3.0},{4.0,5.0,8.0},{1.0,8.0,3.0} };

            double[,] result = MyMath.DatafirstMaxDerivate(arrayToDerive, 4.0, 2.5);
            Assert.AreEqual(1.75, Math.Round(result[0,0]),2);
        }

        [TestMethod]
        public void Test_DatafirstMaxDerivate2()
        {
            double[,] arrayToDerive = new double[3, 3] { { 4.0, 1.0, 3.0 }, { 4.0, 5.0, 8.0 }, { 1.0, 8.0, 3.0 } };

            double[,] result = MyMath.DatafirstMaxDerivate(arrayToDerive, 4.0, 2.5);
            Assert.AreEqual(1.2, Math.Round(result[0, 1]), 1);
        }

        [TestMethod]
        public void Test_DatafirstMaxDerivate3()
        {
            double[,] arrayToDerive = new double[3, 3] { { 4.0, 1.0, 3.0 }, { 4.0, 5.0, 8.0 }, { 1.0, 8.0, 3.0 } };

            double[,] result = MyMath.DatafirstMaxDerivate(arrayToDerive, 4.0, 2.5);
            Assert.AreEqual(0.75, Math.Round(result[0, 2]), 2);
        }

        [TestMethod]
        public void Test_DatafirstMaxDerivate4()
        {
            double[,] arrayToDerive = new double[3, 3] { { 4.0, 1.0, 3.0 }, { 4.0, 5.0, 8.0 }, { 1.0, 8.0, 3.0 } };

            double[,] result = MyMath.DatafirstMaxDerivate(arrayToDerive, 4.0, 2.5);
            Assert.AreEqual(1.75, Math.Round(result[1,0]), 2);
        }

        [TestMethod]
        public void Test_DatafirstMaxDerivate5()
        {
            double[,] arrayToDerive = new double[3, 3] { { 4.0, 1.0, 3.0 }, { 4.0, 5.0, 8.0 }, { 1.0, 8.0, 3.0 } };

            double[,] result = MyMath.DatafirstMaxDerivate(arrayToDerive, 4.0, 2.5);
            Assert.AreEqual(1.6, Math.Round(result[1, 1]), 1);
        }

        [TestMethod]
        public void Test_DatafirstMaxDerivate6()
        {
            double[,] arrayToDerive = new double[3, 3] { { 4.0, 1.0, 3.0 }, { 4.0, 5.0, 8.0 }, { 1.0, 8.0, 3.0 } };

            double[,] result = MyMath.DatafirstMaxDerivate(arrayToDerive, 4.0, 2.5);
            Assert.AreEqual(1.6, Math.Round(result[1, 2]), 1);
        }

        [TestMethod]
        public void Test_DatafirstMaxDerivate7()
        {
            double[,] arrayToDerive = new double[3, 3] { { 4.0, 1.0, 3.0 }, { 4.0, 5.0, 8.0 }, { 1.0, 8.0, 3.0 } };

            double[,] result = MyMath.DatafirstMaxDerivate(arrayToDerive, 4.0, 2.5);
            Assert.AreEqual(2.0, Math.Round(result[2, 0]), 1);
        }

        [TestMethod]
        public void Test_DatafirstMaxDerivate8()
        {
            double[,] arrayToDerive = new double[3, 3] { { 4.0, 1.0, 3.0 }, { 4.0, 5.0, 8.0 }, { 1.0, 8.0, 3.0 } };

            double[,] result = MyMath.DatafirstMaxDerivate(arrayToDerive, 4.0, 2.5);
            Assert.AreEqual(2.0, Math.Round(result[2, 1]), 1);
        }

        [TestMethod]
        public void Test_DatafirstMaxDerivate9()
        {
            double[,] arrayToDerive = new double[3, 3] { { 4.0, 1.0, 3.0 }, { 4.0, 5.0, 8.0 }, { 1.0, 8.0, 3.0 } };

            double[,] result = MyMath.DatafirstMaxDerivate(arrayToDerive, 4.0, 2.5);
            Assert.AreEqual(2.0, Math.Round(result[2, 2]), 1);
        }
        #endregion

        #region GetSmooth
        // data from testMyMathGws.xlsx
        [TestMethod]
        public void Test_GetSmooth1()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 1, 1, 8);

            Assert.AreEqual(2.06, Math.Round(result,2));
        }

        [TestMethod]
        public void Test_GetSmooth2()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 2, 2, 8);

            Assert.AreEqual(5.1, Math.Round(result, 1));
        }

        [TestMethod]
        public void Test_GetSmooth3()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 3, 3, 8);

            Assert.AreEqual(9.5, Math.Round(result, 1));
        }

        [TestMethod]
        public void Test_GetSmooth4()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 4, 4, 8);

            Assert.AreEqual(5.1, Math.Round(result, 1));
        }

        [TestMethod]
        public void Test_GetSmoothBoundary_0_0()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 0, 0, 8);

            Assert.AreEqual(1.17, Math.Round(result, 2));
        }
        [TestMethod]
        public void Test_GetSmoothBoundary_nx_0()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 5, 0, 8);

            Assert.AreEqual(5.5, Math.Round(result, 1));
        }

        [TestMethod]
        public void Test_GetSmoothBoundary_nx_ny()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 5, 5, 8);

            Assert.AreEqual(3.5, Math.Round(result, 1));
        }

        [TestMethod]
        public void Test_GetSmoothBoundary_0_ny()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 0, 5, 8);

            Assert.AreEqual(1.17, Math.Round(result, 2));
        }

        [TestMethod]
        public void Test_GetSmoothBoundary_g0_ny()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 2, 5, 8);

            Assert.AreEqual(2.5, Math.Round(result, 1));
        }
        [TestMethod]
        public void Test_GetSmoothBoundary_0_lny()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 0, 3, 8);

            Assert.AreEqual(1.5, Math.Round(result, 1));
        }

        [TestMethod]
        public void Test_GetSmoothBoundary_g0_0()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 3, 0, 8);

            Assert.AreEqual(4.6, Math.Round(result, 1));
        }

        [TestMethod]
        public void Test_GetSmoothBoundary_g0_lny()
        {
            double[,] arrayToSmooth = new double[6, 6] { { 1, 1, 2, 1, 1, 1 }, { 1, 2, 3, 2, 2, 1 }, { 1, 3, 5, 8, 5, 2 }, { 5, 4, 8, 12, 5, 2 }, { 5, 8, 12, 8, 5, 3 }, { 5, 5, 4, 5, 4, 3 } };

            double result = MyMath.GetSmooth(arrayToSmooth, 5, 2, 8);

            Assert.AreEqual(5.8, Math.Round(result, 1));
        }
        #endregion

        #region Trend Surface
        [TestMethod]
        public void Test_FirstOrderTrendSurface()
        {
            //
            // example from 
            // www.geology.wmich.edu/sultan/5350/Spring2011/Lectures/Lecture8_interpolationf_2011.pdf
            //
            double[][] XYZpoints = new double[5][];
            XYZpoints[0]= new double[3]{69,76,20.82};
            XYZpoints[1] = new double[3] { 59, 64, 10.91 };
            XYZpoints[2] = new double[3] { 75, 52, 10.38 };
            XYZpoints[3] = new double[3] { 86, 73, 14.6 };
            XYZpoints[4] = new double[3] { 88, 53, 10.56 };
            Assert.AreEqual(14.507, Math.Round(MyMath.FirstOrderTrendSurface(69,67,XYZpoints),3));
            // 14.507 instead of 14.535 because the example at the link above rounds b0, b1 and b2 before calculating Zxy
        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface2()
        {

            double[][] XYZpoints = new double[5][];
            XYZpoints[0] = new double[3] { 69, 76, 10 };
            XYZpoints[1] = new double[3] { 59, 64, 10 };
            XYZpoints[2] = new double[3] { 75, 52, 10 };
            XYZpoints[3] = new double[3] { 86, 73, 10 };
            XYZpoints[4] = new double[3] { 88, 53, 10 };
            Assert.AreEqual(10, Math.Round(MyMath.FirstOrderTrendSurface(69, 67, XYZpoints), 3));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest0_0()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 0.0, 0.0, 3.12 };
            XYZpoints[1] = new double[3] { 4.0, 0.0, 10.95 };
            XYZpoints[2] = new double[3] { 0.0, 2.5, 7.20 };
            XYZpoints[3] = new double[3] { 4.0, 2.5, 7.54 };
            Assert.AreEqual(4.99, Math.Round(MyMath.FirstOrderTrendSurface(0.0, 0.0, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest4_0()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 4.0, 0.0, 10.95 };
            XYZpoints[1] = new double[3] { 4.0, 2.5, 7.54 };
            XYZpoints[2] = new double[3] { 8.0, 2.5, 10.95 };
            XYZpoints[3] = new double[3] { 8.0, 0.0, 6.05 };
            Assert.AreEqual(8.87, Math.Round(MyMath.FirstOrderTrendSurface(4.0, 0.0, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest4_2dot5()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 4.0, 2.5, 7.54 };
            XYZpoints[1] = new double[3] { 8.0, 2.5, 10.95 };
            XYZpoints[2] = new double[3] { 4.0, 5.0, 5.52 };
            XYZpoints[3] = new double[3] { 8.0, 5.0, 6.05 };
            Assert.AreEqual(8.26, Math.Round(MyMath.FirstOrderTrendSurface(4.0, 2.5, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest0_2dot5()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 0.0, 2.5, 7.20 };
            XYZpoints[1] = new double[3] { 4.0, 2.5, 7.54 };
            XYZpoints[2] = new double[3] { 0.0, 5.0, 7.20 };
            XYZpoints[3] = new double[3] { 4.0, 5.0, 5.52 };
            Assert.AreEqual(7.7, Math.Round(MyMath.FirstOrderTrendSurface(0.0, 2.5, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest0_0b()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 0.0, 0.0, 3.12 };
            XYZpoints[1] = new double[3] { 4.0, 0.0, 10.95 };
            XYZpoints[2] = new double[3] { 0.0, 2.5, 7.20 };
            XYZpoints[3] = new double[3] { 4.0, 2.5, 7.54 };
            Assert.AreEqual(9.08, Math.Round(MyMath.FirstOrderTrendSurface(4.0, 0.0, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest0_0c()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 0.0, 0.0, 3.12 };
            XYZpoints[1] = new double[3] { 4.0, 0.0, 10.95 };
            XYZpoints[2] = new double[3] { 0.0, 2.5, 7.20 };
            XYZpoints[3] = new double[3] { 4.0, 2.5, 7.54 };
            Assert.AreEqual(9.41, Math.Round(MyMath.FirstOrderTrendSurface(4.0, 2.5, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest0_0d()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 0.0, 0.0, 3.12 };
            XYZpoints[1] = new double[3] { 4.0, 0.0, 10.95 };
            XYZpoints[2] = new double[3] { 0.0, 2.5, 7.20 };
            XYZpoints[3] = new double[3] { 4.0, 2.5, 7.54 };
            Assert.AreEqual(5.33, Math.Round(MyMath.FirstOrderTrendSurface(0.0, 2.5, XYZpoints), 2));

        }


        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest_a()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 0.0, 0.0, 3.12 };
            XYZpoints[1] = new double[3] { 4.0, 0.0, 10.95 };
            XYZpoints[2] = new double[3] { 0.0, 2.5, 7.20 };
            XYZpoints[3] = new double[3] { 4.0, 2.5, 7.54 };
            Assert.AreEqual(7.2, Math.Round(MyMath.FirstOrderTrendSurface(2.0, 1.25, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest_b()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 0.0, 2.5, 7.20 };
            XYZpoints[1] = new double[3] { 4.0, 2.5, 7.54 };
            XYZpoints[2] = new double[3] { 0.0, 5.0, 7.20 };
            XYZpoints[3] = new double[3] { 4.0, 5.0, 5.52 };
            Assert.AreEqual(6.87, Math.Round(MyMath.FirstOrderTrendSurface(2.0, 3.75, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest_c()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 4.0, 2.5, 7.54 };
            XYZpoints[1] = new double[3] { 8.0, 2.5, 10.95 };
            XYZpoints[2] = new double[3] { 4.0, 5.0, 5.52 };
            XYZpoints[3] = new double[3] { 8.0, 5.0, 6.05 };
            Assert.AreEqual(7.52, Math.Round(MyMath.FirstOrderTrendSurface(6.0, 3.75, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest_d()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 4.0, 0.0, 10.95 };
            XYZpoints[1] = new double[3] { 4.0, 2.5, 7.54 };
            XYZpoints[2] = new double[3] { 8.0, 2.5, 10.95 };
            XYZpoints[3] = new double[3] { 8.0, 0.0, 6.05 };
            Assert.AreEqual(8.87, Math.Round(MyMath.FirstOrderTrendSurface(6.0, 1.25, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest_upright_b()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 4.0, 2.5, 7.54 };
            XYZpoints[1] = new double[3] { 8.0, 2.5, 10.95 };
            XYZpoints[2] = new double[3] { 4.0, 5.0, 5.52 };
            XYZpoints[3] = new double[3] { 8.0, 5.0, 6.05 };
            Assert.AreEqual(5.79, Math.Round(MyMath.FirstOrderTrendSurface(6.0, 5.0, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest_upright_c()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 4.0, 2.5, 7.54 };
            XYZpoints[1] = new double[3] { 8.0, 2.5, 10.95 };
            XYZpoints[2] = new double[3] { 4.0, 5.0, 5.52 };
            XYZpoints[3] = new double[3] { 8.0, 5.0, 6.05 };
            Assert.AreEqual(6.77, Math.Round(MyMath.FirstOrderTrendSurface(8.0, 5.0, XYZpoints), 2));

        }

        [TestMethod]
        public void Test_FirstOrderTrendSurface3x3ForInterpolatedTest_upright_d()
        {

            double[][] XYZpoints = new double[4][];
            XYZpoints[0] = new double[3] { 4.0, 2.5, 7.54 };
            XYZpoints[1] = new double[3] { 8.0, 2.5, 10.95 };
            XYZpoints[2] = new double[3] { 4.0, 5.0, 5.52 };
            XYZpoints[3] = new double[3] { 8.0, 5.0, 6.05 };
            Assert.AreEqual(8.5, Math.Round(MyMath.FirstOrderTrendSurface(8.0, 3.75, XYZpoints), 2));

        }
        #endregion

        #region FindClosestLowerIndex
        [TestMethod]
        public void Test_FindClosestLowerIndex()
        {
            double[] array = new double[4] { 1, 2, 3, 4};
            Assert.AreEqual(2, MyMath.FindClosestLowerIndex(3.5,array));
        }
        [TestMethod]
        public void Test_FindClosestLowerIndex2()
        {
            double[] array = new double[4] { 1, 2, 3, 4 };
            Assert.AreEqual(0, MyMath.FindClosestLowerIndex(1, array));
        }
        [TestMethod]
        public void Test_FindClosestLowerIndex3()
        {
            double[] array = new double[4] { 1, 2, 3, 4 };
            Assert.AreEqual(0, MyMath.FindClosestLowerIndex(2, array));
        }
        [TestMethod]
        public void Test_FindClosestLowerIndex4()
        {
            double[] array = new double[4] { 1, 2, 3, 4 };
            Assert.AreEqual(1, MyMath.FindClosestLowerIndex(2.000001, array));
        }
        [TestMethod]
        public void Test_FindClosestLowerIndex5()
        {
            double[] array = new double[4] { 1, 2, 3, 4 };
            Assert.AreEqual(-1, MyMath.FindClosestLowerIndex(4.5, array));
        }
        [TestMethod]
        public void Test_FindClosestLowerIndex6()
        {
            double[] array = new double[4] { 1, 2, 3, 4 };
            Assert.AreEqual(2, MyMath.FindClosestLowerIndex(4, array));
        }
        #endregion
    }
}
