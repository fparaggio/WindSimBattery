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

        #region Trend surface passing for a point

        [TestMethod]
        public void Test_FirstOrderTrendSurfacePassingForAPoint()
        {
            double[][] XYZpoints = new double[5][];
            XYZpoints[0]= new double[3]{69,76,20.82};
            XYZpoints[1] = new double[3] { 59, 64, 10.91 };
            XYZpoints[2] = new double[3] { 75, 52, 10.38 };
            XYZpoints[3] = new double[3] { 86, 73, 14.6 };
            XYZpoints[4] = new double[3] { 88, 53, 10.56 };
            double[] plane = MyMath.FirstOrderTrendSurfacePassingForAPoint(69, 76, 20.82, XYZpoints);
            // plane[0] * x + plane[1] * y + plane[2] * z + plane[3] = 0
            // z = (plane[0] * x + plane[1] * y + plane[3]) / ( -1 * plane[2] )
            Assert.AreEqual(20.82, (plane[0] * 69 + plane[1] * 76 + plane[3])/(-1*plane[2]));
        }

        #endregion 

        #region PlanePassingThroughtThreePoints

        [TestMethod]
        public void Test_PlanePassingThroughtThreePoints_point0() 
        {
            double[][] points = new double[3][];
            points[0] = new double[3] { 69, 76, 20.82 };
            points[1] = new double[3] { 59, 64, 10.91 };
            points[2] = new double[3] { 75, 52, 10.38 };
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            Assert.AreEqual(-1 * plane[3], points[0][0] * plane[0] + points[0][1] * plane[1] + points[0][2] * plane[2]);
        }

        [TestMethod]
        public void Test_PlanePassingThroughtThreePoints_point1()
        {
            double[][] points = new double[3][];
            points[0] = new double[3] { 69, 76, 20.82 };
            points[1] = new double[3] { 59, 64, 10.91 };
            points[2] = new double[3] { 75, 52, 10.38 };
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            double test1 = -1 * plane[3];
            double test2 = points[1][0] * plane[0] + points[1][1] * plane[1] + points[1][2] * plane[2];
            Assert.AreEqual(Math.Round(-1 * plane[3],2),Math.Round(points[1][0] * plane[0] + points[1][1] * plane[1] + points[1][2] * plane[2],2));
        }

        [TestMethod]
        public void Test_PlanePassingThroughtThreePoints_point2()
        {
            double[][] points = new double[3][];
            points[0] = new double[3] { 69, 76, 20.82 };
            points[1] = new double[3] { 59, 64, 10.91 };
            points[2] = new double[3] { 75, 52, 10.38 };
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            double test1 = points[2][0] * plane[0] + points[2][1] * plane[1] + points[2][2] * plane[2];
            double test2 = -1 * plane[3];
            Assert.AreEqual(-1 * plane[3], points[2][0] * plane[0] + points[2][1] * plane[1] + points[2][2] * plane[2]);
        }

        [TestMethod]
        public void Test_PlanePassingThroughtThreePoints_point0_A()
        {
            double[][] points = new double[3][];
            points[0] = new double[3] { -1, -6, 0 };
            points[1] = new double[3] { -4, 2, -2 };
            points[2] = new double[3] { -2, 4, 1 };
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            Assert.AreEqual(-1 * plane[3], points[0][0] * plane[0] + points[0][1] * plane[1] + points[0][2] * plane[2]);
        }

        [TestMethod]
        public void Test_PlanePassingThroughtThreePoints_point1_A()
        {
            double[][] points = new double[3][];
            points[0] = new double[3] { -1, -6, 0 };
            points[1] = new double[3] { -4, 2, -2 };
            points[2] = new double[3] { -2, 4, 1 };
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            Assert.AreEqual(-1 * plane[3], points[1][0] * plane[0] + points[1][1] * plane[1] + points[1][2] * plane[2]);
        }

        [TestMethod]
        public void Test_PlanePassingThroughtThreePoints_point2_A()
        {
            double[][] points = new double[3][];
            points[0] = new double[3] { -1, -6, 0 };
            points[1] = new double[3] { -4, 2, -2 };
            points[2] = new double[3] { -2, 4, 1 };
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            Assert.AreEqual(-1 * plane[3], points[2][0] * plane[0] + points[2][1] * plane[1] + points[2][2] * plane[2]);
        }

        #endregion 

        #region DirectionOfIntersectionOfTwoPlanes

        [TestMethod]
        public void Test_DirectionOfIntersectionOfTwoPlanes_1_a()
        {
            double[][] twoPlanes = new double[2][];
            twoPlanes[0] = new double[3] { 2, -5, 3 };
            twoPlanes[1] = new double[3] { 3, 4, -3 };
            Assert.AreEqual(3,MyMath.DirectionOfIntersectionOfTwoPlanes(twoPlanes)[0]);
        }

        [TestMethod]
        public void Test_DirectionOfIntersectionOfTwoPlanes_1_b()
        {
            double[][] twoPlanes = new double[2][];
            twoPlanes[0] = new double[3] { 2, -5, 3 };
            twoPlanes[1] = new double[3] { 3, 4, -3 };
            Assert.AreEqual(15, MyMath.DirectionOfIntersectionOfTwoPlanes(twoPlanes)[1]);
        }

        [TestMethod]
        public void Test_DirectionOfIntersectionOfTwoPlanes_1_c()
        {
            double[][] twoPlanes = new double[2][];
            twoPlanes[0] = new double[3] { 2, -5, 3 };
            twoPlanes[1] = new double[3] { 3, 4, -3 };
            Assert.AreEqual(23, MyMath.DirectionOfIntersectionOfTwoPlanes(twoPlanes)[2]);
        }

        [TestMethod]
        public void Test_DirectionOfIntersectionOfTwoPlanes_2_a()
        {
            double[][] twoPlanes = new double[2][];
            twoPlanes[0] = new double[3] { 1, -1, 3 };
            twoPlanes[1] = new double[3] { 1, 2, -1 };
            Assert.AreEqual(-5, MyMath.DirectionOfIntersectionOfTwoPlanes(twoPlanes)[0]);
        }

        [TestMethod]
        public void Test_DirectionOfIntersectionOfTwoPlanes_2_b()
        {
            double[][] twoPlanes = new double[2][];
            twoPlanes[0] = new double[3] { 1, -1, 3 };
            twoPlanes[1] = new double[3] { 1, 2, -1 };
            Assert.AreEqual(4, MyMath.DirectionOfIntersectionOfTwoPlanes(twoPlanes)[1]);
        }

        [TestMethod]
        public void Test_DirectionOfIntersectionOfTwoPlanes_2_c()
        {
            double[][] twoPlanes = new double[2][];
            twoPlanes[0] = new double[3] { 1, -1, 3 };
            twoPlanes[1] = new double[3] { 1, 2, -1 };
            Assert.AreEqual(3, MyMath.DirectionOfIntersectionOfTwoPlanes(twoPlanes)[2]);
        }

        #endregion

        #region angleDegreesBetweenLineAndPlane

        [TestMethod]
        public void Test_angleDegreesBetweenLineAndPlane_1() 
        {            
            double[] line = new double[]{2,1,2};
            double[] plane = new double[] { 1, 1, 0 };
            Assert.AreEqual(45.000, Math.Round(MyMath.angleDegreesBetweenLineAndPlane(line,plane),3));
        }

        [TestMethod]
        public void Test_angleDegreesBetweenLineAndPlane_2_composite()
        {
            double[][] planes = new double[2][];
            planes[0] = new double[] { 1, 3, -1,3 };
            planes[1] = new double[] { 2, -1, -1, -1 };
            double[] planePI = new double[] { 2, -1, 3 };
            double[] line = MyMath.DirectionOfIntersectionOfTwoPlanes(planes);
            Assert.AreEqual(67.09, Math.Round(MyMath.angleDegreesBetweenLineAndPlane(line, planePI), 2));
        }

        [TestMethod]
        public void Test_angleDegreesBetweenLineAndPlane_parallels()
        {
            double[] line = new double[] { 2, 1, 2 };
            double[] plane = new double[] { 4, 2, 4 };
            Assert.AreEqual(0, MyMath.angleDegreesBetweenLineAndPlane(line, plane));
        }

        [TestMethod]
        public void Test_angleDegreesBetweenLineAndPlane_3()
        {
            double[] line = new double[] { Math.Sqrt(3), 0, 3 };
            double[] plane = new double[] { 1, 0, 0 };
            Assert.AreEqual(30.000, Math.Round(MyMath.angleDegreesBetweenLineAndPlane(line, plane), 3));
        }

        #endregion 

        #region angleDegreeAlongDirection

        [TestMethod]
        public void Test_angleDegreeAlongDirection()
        {
            double[][] points = new double[3][];
            points[0] = new double[]{0,0,0};
            points[1] = new double[]{0,1,0};
            points[2] = new double[]{1,0,1};
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            double bearing = 90;
            double angle = MyMath.angleDegreeAlongDirection(plane, bearing);
            Assert.AreEqual(45.0, Math.Round(angle,2));
        }

        [TestMethod]
        public void Test_angleDegreeAlongDirection2()
        {
            double[][] points = new double[3][];
            points[0] = new double[] { 0, 0, 0 };
            points[1] = new double[] { 1, 0, 0 };
            points[2] = new double[] { 0, Math.Sqrt(3)/2, 0.5 };
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            double bearing = 0;
            double angle = MyMath.angleDegreeAlongDirection(plane, bearing);
            Assert.AreEqual(30.0, Math.Round(angle, 2));
        }

        #endregion 

        #region MaximumAngleDegreeOfAPlane

        [TestMethod]
        public void Test_MaximumAngleDegreeOfAPlane()
        {
            double[][] points = new double[3][];
            points[0] = new double[] { 0, 0, 0 };
            points[1] = new double[] { 1, 0, 0 };
            points[2] = new double[] { 0, Math.Sqrt(3)/2, 0.5 };
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            Assert.AreEqual(30.000, Math.Round(MyMath.MaximumAngleDegreeOfAPlane(plane),3));
        }

        [TestMethod]
        public void Test_MaximumAngleDegreeOfAPlane2()
        {
            double[][] points = new double[3][];
            points[0] = new double[] { 0, 0, 0 };
            points[1] = new double[] { 0, 1, 0 };
            points[2] = new double[] { 1, 0, 1 };
            double[] plane = MyMath.PlanePassingThroughtThreePoints(points);
            Assert.AreEqual(45.0, MyMath.MaximumAngleDegreeOfAPlane(plane));
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

        #region extractArrayFromJagged
        [TestMethod]
        public void Test_extractArrayFromJagged()
        {
            double[,][] jaggedArray = new double[2, 2][];
            jaggedArray[0, 0] = new double[] { 3.0, 5.0, 7.0, };
            jaggedArray[0, 1] = new double[] { 1.0, 0.0, 2.0, 4.0, 6.0 };
            jaggedArray[1, 0] = new double[] { 1.0, 6.0 };
            jaggedArray[1, 1] = new double[] { 1.0, 0.0, 2.0, 4.0, 6.0, 45.0, 67.0, 78.0 };
            double[,] extractArrayFromJagged = MyMath.extractArrayFromJagged(jaggedArray, 1);
            Assert.IsTrue(extractArrayFromJagged[0, 0] == 5.0 && extractArrayFromJagged[0, 1] == 0.0 && extractArrayFromJagged[1, 0] == 6.0 && extractArrayFromJagged[1, 1] == 0.0);
        }

        [TestMethod]
        public void Test_extractArrayFromJagged_exception()
        {
            double[,][] jaggedArray = new double[2, 2][];
            jaggedArray[0, 0] = new double[] { 3.0, 5.0, 7.0, };
            jaggedArray[0, 1] = new double[] { 1.0, 0.0, 2.0, 4.0, 6.0 };
            jaggedArray[1, 0] = new double[] { 1.0, 6.0 };
            jaggedArray[1, 1] = new double[] { 1.0, 0.0, 2.0, 4.0, 6.0, 45.0, 67.0, 78.0 };
            double[,] extractArrayFromJagged = MyMath.extractArrayFromJagged(jaggedArray, 2);
            Assert.IsTrue(extractArrayFromJagged == null);
        }
        #endregion

        #region MaxOfBidimensionalDoubleArray
        [TestMethod]
        public void Test_MaxOfBidimensionalDoubleArray()
        {
            double[,] BidimensionalArray = new double[2, 2];
            BidimensionalArray[0, 0] = 5.0;
            BidimensionalArray[0, 1] = 2.0;
            BidimensionalArray[1, 0] = 1.0;
            BidimensionalArray[1, 1] = 4.0;
            Assert.AreEqual(5.0, MyMath.MaxOfBidimensionalDoubleArray(BidimensionalArray));
        }

        [TestMethod]
        public void Test_MaxOfBidimensionalDoubleArray_2()
        {
            double[,] BidimensionalArray = new double[2, 2];
            BidimensionalArray[0, 0] = 6.0;
            BidimensionalArray[0, 1] = 2.0;
            BidimensionalArray[1, 0] = 1.0;
            Assert.AreEqual(6.0, MyMath.MaxOfBidimensionalDoubleArray(BidimensionalArray));
        }
        #endregion

        #region planarXYDistanceBetweenTwoPoints

        [TestMethod]
        public void Test_planarXYDistanceBetweenTwoPoints()
        {
            double[] point1 = new double[] { 0, 0, 0 };
            double[] point2 = new double[] { 29,-13,12};
            Assert.AreEqual(31.8, Math.Round(MyMath.planarXYDistanceBetweenTwoPoints(point1, point2),1));
        }

        [TestMethod]
        public void Test_planarXYDistanceBetweenTwoPoints_1()
        {
            double[] point1 = new double[] { 30, 11, 34 };
            double[] point2 = new double[] { 13, -29, 12 };
            Assert.AreEqual(43.5, Math.Round(MyMath.planarXYDistanceBetweenTwoPoints(point1, point2), 1));
        }

        [TestMethod]
        public void Test_planarXYDistanceBetweenTwoPoints_2()
        {
            double[] point1 = new double[] { 30, 11, 34 };
            double[] point2 = new double[] { -11, -14, 15 };
            Assert.AreEqual(48.0, Math.Round(MyMath.planarXYDistanceBetweenTwoPoints(point1, point2), 1));
        }

        [TestMethod]
        public void Test_planarXYDistanceBetweenTwoPoints_3()
        {
            double[] point1 = new double[] { -10, -8, -134 };
            double[] point2 = new double[] { -10, -26, 1245 };
            Assert.AreEqual(18.0, Math.Round(MyMath.planarXYDistanceBetweenTwoPoints(point1, point2), 1));
        }

        [TestMethod]
        public void Test_planarXYDistanceBetweenTwoPoints_4()
        {
            double[] point1 = new double[] { -11, 10, 34 };
            double[] point2 = new double[] { -10, -26, 145 };
            Assert.AreEqual(36.0, Math.Round(MyMath.planarXYDistanceBetweenTwoPoints(point1, point2), 1));
        }

        #endregion 

        #region planarAzimuthDegreesBetweenTwoPoints

        [TestMethod]
        public void Test_planarAzimuthDegreesBetweenTwoPoints()
        {
            double[] center = new double[] { 0, 0, 34 };
            double[] point = new double[] { 1, 1, 145 };
            Assert.AreEqual(45.0,MyMath.planarAzimuthDegreesBetweenTwoPoints(point,center));
        }

        [TestMethod]
        public void Test_planarAzimuthDegreesBetweenTwoPoints_2()
        {
            double[] center = new double[] { 0, 0, 34 };
            double[] point = new double[] { 1, -1, 145 };
            Assert.AreEqual(135.0, MyMath.planarAzimuthDegreesBetweenTwoPoints(point, center));
        }


        [TestMethod]
        public void Test_planarAzimuthDegreesBetweenTwoPoints_3()
        {
            double[] center = new double[] { 0, 0, 34 };
            double[] point = new double[] { -1, -1, 145 };
            Assert.AreEqual(225.0, MyMath.planarAzimuthDegreesBetweenTwoPoints(point, center));
        }


        [TestMethod]
        public void Test_planarAzimuthDegreesBetweenTwoPoints_4()
        {
            double[] center = new double[] { 0, 0, 34 };
            double[] point = new double[] { -1, 1, 145 };
            Assert.AreEqual(315.0, MyMath.planarAzimuthDegreesBetweenTwoPoints(point, center));
        }

        [TestMethod]
        public void Test_planarAzimuthDegreesBetweenTwoPoints_5()
        {
            double[] center = new double[] { 0, 0, 34 };
            double[] point = new double[] { 0, 1, 145 };
            Assert.AreEqual(0.0, MyMath.planarAzimuthDegreesBetweenTwoPoints(point, center));
        }


        #endregion 

        #region DoubleMap

        [TestMethod]
        public void Test_DoubleMap()
        {
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 100, 20, 2000, 3, 2);
            Assert.AreEqual(10, map.data[0,0][0]);
        }

        [TestMethod]
        public void Test_DoubleMap_2()
        {
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 100, 20, 2000, 3, 2);
            Assert.AreEqual(55, map.data[1,0][0]);
        }

        [TestMethod]
        public void Test_DoubleMap_3()
        {
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 100, 20, 2000, 3, 2);
            Assert.AreEqual(100, map.data[2, 0][0]);
        }

        [TestMethod]
        public void Test_DoubleMap_4()
        {
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 100, 20, 2000, 3, 2);
            Assert.AreEqual(20, map.data[0, 0][1]);
        }

        [TestMethod]
        public void Test_DoubleMap_5()
        {
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 100, 20, 2000, 3, 2);
            Assert.AreEqual(20, map.data[1, 0][1]);
        }

        [TestMethod]
        public void Test_DoubleMap_6()
        {
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 100, 20, 2000, 3, 2);
            Assert.AreEqual(20, map.data[2, 0][1]);
        }

        [TestMethod]
        public void Test_DoubleMap_7()
        {
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 100, 20, 2000, 3, 2);
            Assert.AreEqual(2000, map.data[0, 1][1]);
        }

        [TestMethod]
        public void Test_DoubleMap_8()
        {
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 100, 20, 2000, 3, 2);
            Assert.AreEqual(2000, map.data[1, 1][1]);
        }

        [TestMethod]
        public void Test_DoubleMap_9()
        {
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 100, 20, 2000, 3, 2);
            Assert.AreEqual(2000, map.data[2, 1][1]);
        }

        [TestMethod]
        public void Test_DoubleMap_second_constructor()
        {
            double[,] dataExample = new double[3,4];
            dataExample[0, 0] = 1;
            dataExample[1, 0] = 2;
            dataExample[2, 0] = 3;
            dataExample[0, 1] = 4;
            dataExample[1, 1] = 5;
            dataExample[2, 1] = 6;
            dataExample[0, 2] = 7;
            dataExample[1, 2] = 8;
            dataExample[2, 2] = 9;
            dataExample[0, 3] = 10;
            dataExample[1, 3] = 11;
            dataExample[2, 3] = 12;
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 30, 100, 160, dataExample);
            Assert.AreEqual(20,map.data[1,2][0] );
        }

        [TestMethod]
        public void Test_DoubleMap_second_constructor_2()
        {
            double[,] dataExample = new double[3, 4];
            dataExample[0, 0] = 1;
            dataExample[1, 0] = 2;
            dataExample[2, 0] = 3;
            dataExample[0, 1] = 4;
            dataExample[1, 1] = 5;
            dataExample[2, 1] = 6;
            dataExample[0, 2] = 7;
            dataExample[1, 2] = 8;
            dataExample[2, 2] = 9;
            dataExample[0, 3] = 10;
            dataExample[1, 3] = 11;
            dataExample[2, 3] = 12;
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 30, 100, 160, dataExample);
            Assert.AreEqual(140, map.data[1, 2][1]);
        }

        [TestMethod]
        public void Test_DoubleMap_second_constructor_3()
        {
            double[,] dataExample = new double[3, 4];
            dataExample[0, 0] = 1;
            dataExample[1, 0] = 2;
            dataExample[2, 0] = 3;
            dataExample[0, 1] = 4;
            dataExample[1, 1] = 5;
            dataExample[2, 1] = 6;
            dataExample[0, 2] = 7;
            dataExample[1, 2] = 8;
            dataExample[2, 2] = 9;
            dataExample[0, 3] = 10;
            dataExample[1, 3] = 11;
            dataExample[2, 3] = 12;
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 30, 100, 160, dataExample);
            Assert.AreEqual(8, map.data[1, 2][2]);
        }

        [TestMethod]
        public void Test_DoubleMap_second_constructor_4()
        {
            double[,] dataExample = new double[3, 4];
            dataExample[0, 0] = 1;
            dataExample[1, 0] = 2;
            dataExample[2, 0] = 3;
            dataExample[0, 1] = 4;
            dataExample[1, 1] = 5;
            dataExample[2, 1] = 6;
            dataExample[0, 2] = 7;
            dataExample[1, 2] = 8;
            dataExample[2, 2] = 9;
            dataExample[0, 3] = 10;
            dataExample[1, 3] = 11;
            dataExample[2, 3] = 12;
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 30, 100, 160, dataExample);
            Assert.AreEqual(10, map.data[0,0][0]);
        }

        [TestMethod]
        public void Test_DoubleMap_second_constructor_5()
        {
            double[,] dataExample = new double[3, 4];
            dataExample[0, 0] = 1;
            dataExample[1, 0] = 2;
            dataExample[2, 0] = 3;
            dataExample[0, 1] = 4;
            dataExample[1, 1] = 5;
            dataExample[2, 1] = 6;
            dataExample[0, 2] = 7;
            dataExample[1, 2] = 8;
            dataExample[2, 2] = 9;
            dataExample[0, 3] = 10;
            dataExample[1, 3] = 11;
            dataExample[2, 3] = 12;
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 30, 100, 160, dataExample);
            Assert.AreEqual(100, map.data[0, 0][1]);
        }

        [TestMethod]
        public void Test_DoubleMap_second_constructor_6()
        {
            double[,] dataExample = new double[3, 4];
            dataExample[0, 0] = 1;
            dataExample[1, 0] = 2;
            dataExample[2, 0] = 3;
            dataExample[0, 1] = 4;
            dataExample[1, 1] = 5;
            dataExample[2, 1] = 6;
            dataExample[0, 2] = 7;
            dataExample[1, 2] = 8;
            dataExample[2, 2] = 9;
            dataExample[0, 3] = 10;
            dataExample[1, 3] = 11;
            dataExample[2, 3] = 12;
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 30, 100, 160, dataExample);
            Assert.AreEqual(30, map.data[2, 3][0]);
        }

        [TestMethod]
        public void Test_DoubleMap_second_constructor_7()
        {
            double[,] dataExample = new double[3, 4];
            dataExample[0, 0] = 1;
            dataExample[1, 0] = 2;
            dataExample[2, 0] = 3;
            dataExample[0, 1] = 4;
            dataExample[1, 1] = 5;
            dataExample[2, 1] = 6;
            dataExample[0, 2] = 7;
            dataExample[1, 2] = 8;
            dataExample[2, 2] = 9;
            dataExample[0, 3] = 10;
            dataExample[1, 3] = 11;
            dataExample[2, 3] = 12;
            MyMath.DoubleMap map = new MyMath.DoubleMap(10, 30, 100, 160, dataExample);
            Assert.AreEqual(160, map.data[2, 3][1]);
        }

        #endregion

    }
}
