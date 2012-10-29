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
    }
}
