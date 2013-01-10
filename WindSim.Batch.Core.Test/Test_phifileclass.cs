using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System.Globalization;

namespace WindSim.Batch.Core.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\270.phi")]
    public class Test_phifileclass
    {
        static string fileName = "270.phi";
        public PhiFile target = new PhiFile(fileName);

        public Test_phifileclass()
        {

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
        public void FindResourcefile_Test()
        {
            Assert.IsTrue(System.IO.File.Exists(fileName));
        }

        [TestMethod]
        public void Test_XcenRandValue()
        {
            Assert.AreEqual(499.9500,target.value(PhiFileDataType.Xcen,1,0,1));
        }

        [TestMethod]
        public void Test_YcenRandValue()
        {
            Assert.AreEqual(125.3000, target.value(PhiFileDataType.Ycen, 1, 0, 1));
        }

        [TestMethod]
        public void Test_ZcenRandValue()
        {
            Assert.AreEqual(197.5000, target.value(PhiFileDataType.Zcen, 1, 0, 1));
        }

        [TestMethod]
        public void Test_P1RandValue()
        {
            Assert.AreEqual(3.284502, target.value(PhiFileDataType.P1, 1, 0, 1));
        }

        [TestMethod]
        public void Test_U1RandValue()
        {
            Assert.AreEqual(9.187250, target.value(PhiFileDataType.U1, 1, 0, 1));
        }

        [TestMethod]
        public void Test_V1RandValue()
        {
            Assert.AreEqual(0.03085714, target.value(PhiFileDataType.V1, 1, 0, 1));
        }

        [TestMethod]
        public void Test_W1RandValue()
        {
            Assert.AreEqual(0.1252597, target.value(PhiFileDataType.W1, 1, 0, 1));
        }

        [TestMethod]
        public void Test_KeRandValue()
        {
            Assert.AreEqual(0.06461227, target.value(PhiFileDataType.Ke, 1, 0, 1));
        }

        [TestMethod]
        public void Test_EpRandValue()
        {
            Assert.AreEqual(0.0002615851, target.value(PhiFileDataType.Ep, 1, 0, 1));
        }

        [TestMethod]
        public void Test_EpkeRandValue()
        {
            Assert.AreEqual(0.004055142, target.value(PhiFileDataType.Epke, 1, 0, 1));
        }

        [TestMethod]
        public void Test_GrRandValue()
        {
            Assert.AreEqual(0.0, target.value(PhiFileDataType.Gr, 1, 0, 1));
        }

        [TestMethod]
        public void Test_WaddRandValue()
        {
            Assert.AreEqual(0.0000000001, target.value(PhiFileDataType.Wadd, 1, 0, 1));
        }

        [TestMethod]
        public void Test_TrefRandValue()
        {
            Assert.AreEqual(0.0000000001, target.value(PhiFileDataType.Tref, 1, 0, 1));
        }
        
        [TestMethod]
        public void Test_Rho1RandValue()
        {
            Assert.AreEqual(1.225000, target.value(PhiFileDataType.Rho1, 1, 0, 1));
        }

        [TestMethod]
        public void Test_VporRandValue()
        {
            Assert.AreEqual(1.0, target.value(PhiFileDataType.Vpor, 1, 0, 1));
        }

        [TestMethod]
        public void Test_EporRandValue()
        {
            Assert.AreEqual(1.0, target.value(PhiFileDataType.Epor, 1, 0, 1));
        }
        
        [TestMethod]
        public void Test_NporRandValue()
        {
            Assert.AreEqual(1.0, target.value(PhiFileDataType.Npor, 1, 0, 1));
        }
        
        [TestMethod]
        public void Test_HporRandValue()
        {
            Assert.AreEqual(1.0, target.value(PhiFileDataType.Hpor, 1, 0, 1));
        }

        [TestMethod]
        public void Test_RougRandValue()
        {
            Assert.AreEqual(0.001, target.value(PhiFileDataType.Roug, 1, 0, 1));
        }

        [TestMethod]
        public void Test_EnutRandValue()
        {
            Assert.AreEqual(1.436404, target.value(PhiFileDataType.Enut, 1, 0, 1));
        }

        [TestMethod]
        public void Test_WcrtRandValue()
        {
            Assert.AreEqual(0.1248508, target.value(PhiFileDataType.Wcrt, 1, 0, 1));
        }

        [TestMethod]
        public void Test_VcrtRandValue()
        {
            Assert.AreEqual(0.05780130, target.value(PhiFileDataType.Vcrt, 1, 0, 1));
        }
        
        [TestMethod]
        public void Test_UcrtRandValue()
        {
            Assert.AreEqual(9.680700, target.value(PhiFileDataType.Ucrt, 1, 0, 1));
        }

        [TestMethod]
        public void Test_XcenRandValue_2()
        {
            Assert.AreEqual(499.9500, target.value(PhiFileDataType.Xcen, 1, 1, 1));
        }

        [TestMethod]
        public void Test_YcenRandValue_2()
        {
            Assert.AreEqual(375.300, target.value(PhiFileDataType.Ycen, 1, 1, 1));
        }

        [TestMethod]
        public void Test_ZcenRandValue_2()
        {
            Assert.AreEqual(145.0, target.value(PhiFileDataType.Zcen, 1, 1, 1));
        }

        [TestMethod]
        public void Test_P1RandValue_2()
        {
            Assert.AreEqual(2.552497, target.value(PhiFileDataType.P1, 1, 1, 1));
        }

        [TestMethod]
        public void Test_U1RandValue_2()
        {
            Assert.AreEqual(9.283736, target.value(PhiFileDataType.U1, 1, 1, 1));
        }

        [TestMethod]
        public void Test_V1RandValue_2()
        {
            Assert.AreEqual(0.0, target.value(PhiFileDataType.V1, 1, 1, 1));
        }

        [TestMethod]
        public void Test_W1RandValue_2()
        {
            Assert.AreEqual(0.1164399, target.value(PhiFileDataType.W1, 1, 1, 1));
        }

        [TestMethod]
        public void Test_KeRandValue_2()
        {
            Assert.AreEqual(0.07857770, target.value(PhiFileDataType.Ke, 1, 1, 1));
        }

        [TestMethod]
        public void Test_EpRandValue_2()
        {
            Assert.AreEqual(0.0003030338, target.value(PhiFileDataType.Ep, 1, 1, 1));
        }

        [TestMethod]
        public void Test_EpkeRandValue_2()
        {
            Assert.AreEqual(0.003857994, target.value(PhiFileDataType.Epke, 1, 1, 1));
        }

        [TestMethod]
        public void Test_GrRandValue_2()
        {
            Assert.AreEqual(0.0, target.value(PhiFileDataType.Gr, 1, 1, 1));
        }

        [TestMethod]
        public void Test_WaddRandValue_2()
        {
            Assert.AreEqual(0.0000000001, target.value(PhiFileDataType.Wadd, 1, 1, 1));
        }

        [TestMethod]
        public void Test_TrefRandValue_2()
        {
            Assert.AreEqual(0.0000000001, target.value(PhiFileDataType.Tref, 1, 1, 1));
        }

        [TestMethod]
        public void Test_Rho1RandValue_2()
        {
            Assert.AreEqual(1.225000, target.value(PhiFileDataType.Rho1, 1, 1, 1));
        }

        [TestMethod]
        public void Test_VporRandValue_2()
        {
            Assert.AreEqual(1.0, target.value(PhiFileDataType.Vpor, 1, 1, 1));
        }

        [TestMethod]
        public void Test_EporRandValue_2()
        {
            Assert.AreEqual(1.0, target.value(PhiFileDataType.Epor, 1, 1, 1));
        }
        
        [TestMethod]
        public void Test_NporRandValue_2()
        {
            Assert.AreEqual(1.0, target.value(PhiFileDataType.Npor, 1, 1, 1));
        }
        
        [TestMethod]
        public void Test_HporRandValue_2()
        {
            Assert.AreEqual(1.0, target.value(PhiFileDataType.Hpor, 1, 1, 1));
        }

        [TestMethod]
        public void Test_RougRandValue_2()
        {
            Assert.AreEqual(0.001, target.value(PhiFileDataType.Roug, 1, 1, 1));
        }

        [TestMethod]
        public void Test_EnutRandValue_2()
        {
            Assert.AreEqual(1.833864, target.value(PhiFileDataType.Enut, 1, 1, 1));
        }

        [TestMethod]
        public void Test_WcrtRandValue_2()
        {
            Assert.AreEqual(0.1155226, target.value(PhiFileDataType.Wcrt, 1, 1, 1));
        }

        [TestMethod]
        public void Test_VcrtRandValue_2()
        {
            Assert.AreEqual(0.05584234, target.value(PhiFileDataType.Vcrt, 1, 1, 1));
        }

        [TestMethod]
        public void Test_UcrtRandValue_2()
        {
            Assert.AreEqual(9.415277, target.value(PhiFileDataType.Ucrt, 1, 1, 1));
        }

        [TestMethod]
        public void Test_XcenRandValue_3()
        {
            Assert.AreEqual(166.6500, target.value(PhiFileDataType.Xcen, 0, 0, 0));
        }

        [TestMethod]
        public void Test_YcenRandValue_3()
        {
            Assert.AreEqual(125.3000, target.value(PhiFileDataType.Ycen, 0, 0, 0));
        }

        [TestMethod]
        public void Test_ZcenRandValue_3()
        {
            Assert.AreEqual(27.50000, target.value(PhiFileDataType.Zcen, 0, 0, 0));
        }

    }
}
