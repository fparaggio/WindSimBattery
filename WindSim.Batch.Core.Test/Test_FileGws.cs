using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindSim.Batch.Core;

namespace WindSim.Batch.Core.Test
{
    [TestClass]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\test.gws")]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\5x5.gws")]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\3x3.gws")]
    public class Test_FileGws
    {
        static string gwsFileName = "test.gws";
        static string gws5x5 = "5x5.gws";
        static string gws3x3 = "3x3.gws";

        #region resource files
        [TestMethod]
        public void TestFileGwsFindResourcefile()
        {
            Assert.IsTrue(System.IO.File.Exists(gwsFileName));
        }
        [TestMethod]
        public void TestFileGwsFindResourcefile2()
        {
            Assert.IsTrue(System.IO.File.Exists(gws5x5));
        }
        [TestMethod]
        public void TestFileGwsFindResourcefile3()
        {
            Assert.IsTrue(System.IO.File.Exists(gws3x3));
        }
        #endregion

        #region Parsing height
        [TestMethod]
        public void TestFileGwsParser()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(416.00, gws.data[4, 0].height);
        }
        [TestMethod]
        public void TestFileGwsParser1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(390.00, gws.data[1, 3].height);
        }
        [TestMethod]
        public void TestFileGwsParser2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(373.00, gws.data[0, 3].height);
        }
        [TestMethod]
        public void TestFileGwsParser3()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(430.00, gws.data[10, 3].height);
        }
        #endregion

        #region parsing rough
        [TestMethod]
        public void TestFileGwsParserRough()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(0.01, gws.data[4, 0].rough);
        }
        [TestMethod]
        public void TestFileGwsParserRough1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(0.02, gws.data[1, 3].rough);
        }
        [TestMethod]
        public void TestFileGwsParserRough2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(0.004, gws.data[0, 3].rough);
        }
        [TestMethod]
        public void TestFileGwsParserRough3()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(12.3, gws.data[10, 3].rough);
        }
        #endregion

        #region parsing header
        [TestMethod]
        public void TestFileGwsDimX()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(11, gws.Npx);
        }

        [TestMethod]
        public void TestFileGwsParserDimY()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(4, gws.Npy);
        }

        [TestMethod]
        public void TestFileGwsParserVersion()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual("430", gws.WindsimVersion);
        }

        [TestMethod]
        public void TestFileGwsParserAreaName()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual("demo", gws.AreaName);
        }

        [TestMethod]
        public void TestFileGwsParserCoordSystem()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(3, gws.CoordinateSystem);
        }

        [TestMethod]
        public void TestFileGwsParserXmin()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(1234567.0, gws.xmin);
        }

        [TestMethod]
        public void TestFileGwsParserYmin()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(0.0, gws.ymin);
        }

        [TestMethod]
        public void TestFileGwsParserXmax()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(123456789.0, gws.xmax);
        }

        [TestMethod]
        public void TestFileGwsParserYmax()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(-400.0, gws.ymax);
        }

        #endregion

        #region parsing 5x5
        [TestMethod]
        public void TestFileGwsParser5x5Ymax()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws5x5);
            Assert.AreEqual(500.0, gws.ymax);
        }


        [TestMethod]
        public void TestFileGwsParser5x5Dx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws5x5);
            Assert.AreEqual(125, gws.Dx);
        }

        [TestMethod]
        public void TestFileGwsParser5x5Dy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws5x5);
            Assert.AreEqual(125, gws.Dy);
        }
        
        [TestMethod]
        public void TestFileGwsParser5x5Dxy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws5x5);
            Assert.AreEqual(176.777, Math.Round(gws.Dxy,3) );
        }
        #endregion

        #region calculating dx dy dxy
        [TestMethod]
        public void TestFileGwsParserDx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(12222222.2, Math.Round(gws.Dx,1));
        }

        [TestMethod]
        public void TestFileGwsParserDy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(133.33, Math.Round(gws.Dy,2));
        }

        [TestMethod]
        public void TestFileGwsParserDxy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(12222222.200727, Math.Round(gws.Dxy, 6));
        }
        #endregion

        #region height of firt cell smoothed array
        [TestMethod]
        public void TestFileHFirstCellArray1_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,] resultarray = gws.hFirstCellArray(2.0);
            Assert.AreEqual(7.54, Math.Round(resultarray[1,1], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray0_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,] resultarray = gws.hFirstCellArray(2.0);
            Assert.AreEqual(3.12, Math.Round(resultarray[0,0], 2));
        }
        
        [TestMethod]
        public void TestFileHFirstCellArray1_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,] resultarray = gws.hFirstCellArray(2.0);
            Assert.AreEqual(10.95, Math.Round(resultarray[1, 0], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray2_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,] resultarray = gws.hFirstCellArray(2.0);
            Assert.AreEqual(6.05, Math.Round(resultarray[2, 0], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray0_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,] resultarray = gws.hFirstCellArray(2.0);
            Assert.AreEqual(7.20, Math.Round(resultarray[0, 1], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray2_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,] resultarray = gws.hFirstCellArray(2.0);
            Assert.AreEqual(10.95, Math.Round(resultarray[2, 1], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray0_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,] resultarray = gws.hFirstCellArray(2.0);
            Assert.AreEqual(7.20, Math.Round(resultarray[0, 2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray1_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,] resultarray = gws.hFirstCellArray(2.0);
            Assert.AreEqual(5.52, Math.Round(resultarray[1, 2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray2_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,] resultarray = gws.hFirstCellArray(2.0);
            Assert.AreEqual(6.05, Math.Round(resultarray[2, 2], 2));
        }
        #endregion

        #region interpolated data
        
        [TestMethod]
        public void interpolatedData3x3_0_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(4.99, Math.Round(resultarray[0, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_1_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(9.41, Math.Round(resultarray[1, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_0_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(5.33, Math.Round(resultarray[0, 1][2], 2));
        }
        
        [TestMethod]
        public void interpolatedData3x3_1_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(9.07, Math.Round(resultarray[1, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_x_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(0.0, Math.Round(resultarray[0, 0][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_x_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(4.0, Math.Round(resultarray[1, 0][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_x_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(0.0, Math.Round(resultarray[0, 1][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_x_3()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(4.0, Math.Round(resultarray[1, 1][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_y_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(0.0, Math.Round(resultarray[0, 0][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_y_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(0.0, Math.Round(resultarray[1, 0][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_y_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(2.5, Math.Round(resultarray[0, 1][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_y_3()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(0.0, 4.0, 0.0, 2.5, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(2.5, Math.Round(resultarray[1, 1][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375a()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(7.2, Math.Round(resultarray[0, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375b()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(6.87, Math.Round(resultarray[0, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375c()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(7.51, Math.Round(resultarray[1, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375d()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(8.87, Math.Round(resultarray[1, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375ax()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(2.0, Math.Round(resultarray[0, 0][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375bx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(2.0, Math.Round(resultarray[0, 1][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375cx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(6.0, Math.Round(resultarray[1, 1][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375dx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(6.0, Math.Round(resultarray[1, 0][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375ay()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(1.25, Math.Round(resultarray[0, 0][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375by()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(3.75, Math.Round(resultarray[0, 1][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375cy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(3.75, Math.Round(resultarray[1, 1][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375dy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(2.0, 6.0, 1.25, 3.75, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(1.25, Math.Round(resultarray[1, 0][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5a()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(6.0, 8.0, 3.75, 5.0, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(7.51, Math.Round(resultarray[0, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5b()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(6.0, 8.0, 3.75, 5.0, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(5.79, Math.Round(resultarray[0, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5c()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(6.0, 8.0, 3.75, 5.0, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(6.77, Math.Round(resultarray[1, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5d()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(6.0, 8.0, 3.75, 5.0, 1, 1, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(8.5, Math.Round(resultarray[1, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5a10()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(6.0, 8.0, 3.75, 5.0, 10, 10, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(7.51, Math.Round(resultarray[0, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5a10x2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            double[,][] resultarray = gws.interpolatedMap(6.0, 8.0, 3.75, 5.0, 10, 10, FileGws.SmoothType.HFirstcell, 2.0);
            Assert.AreEqual(6.4, Math.Round(resultarray[2, 0][0], 2));
        }
        #endregion 

    }
}
