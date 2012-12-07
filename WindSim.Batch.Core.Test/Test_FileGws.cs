using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindSim.Batch.Core.Test
{
    [TestClass]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\test.gws")]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\5x5.gws")]
    public class Test_FileGws
    {
        static string gwsFileName = "test.gws";
        static string gws5x5 = "5x5.gws";

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

        [TestMethod]
        public void TestFileGwsParser5x5Ymax()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws5x5);
            Assert.AreEqual(500.0, gws.ymax);
        }

    }
}
