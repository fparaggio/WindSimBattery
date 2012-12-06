using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindSim.Batch.Core.Test
{
    [TestClass]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\test.gws")]
    public class Test_FileGws
    {
        static string gwsFileName = "test.gws";

        [TestMethod]
        public void TestFileGwsFindResourcefile()
        {
            Assert.IsTrue(System.IO.File.Exists(gwsFileName));
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

    }
}
