//------------------------------------------------------------------------------
// Copyright (c) 2012, 2013, 2014, 2015 Francesco Paraggio.
// 
// Author: Francesco Paraggio fparaggio@gmail.com
// 
// This file is part of WindSimBattery
// 
// WindSimBattery is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License along with this program. If not, see http://www.gnu.org/licenses/.
// 
// The usage of a range of years within a copyright statement contained within this distribution should be interpreted as being equivalent to a list of years including the first and last year specified and all consecutive years between them. For example, a copyright statement that reads 'Copyright (c) 2005, 2007- 2009, 2011-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2007, 2008, 2009, 2011, 2012' and a copyright statement that reads "Copyright (c) 2005-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012'."
//------------------------------------------------------------------------------

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
    [DeploymentItem("TestFiles\\270.phi")]
    [DeploymentItem("TestFiles\\error.phi")]
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


        [TestMethod]
        public void Test_errorPhi_1_zcen()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(24.41625, target.value(PhiFileDataType.Zcen, 11, 11, 7));
        }

        [TestMethod]
        public void Test_errorPhi_2_zcen()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(400.9050, target.value(PhiFileDataType.Zcen, 44, 44, 14));
        }

        [TestMethod]
        public void Test_errorPhi_3_zcen()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(409.8940, target.value(PhiFileDataType.Zcen, 49, 49, 14));
        }

        [TestMethod]
        public void Test_errorPhi_1_xcen()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(879.3008, target.value(PhiFileDataType.Xcen, 11, 11, 7));
        }

        [TestMethod]
        public void Test_errorPhi_2_xcen()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(3402.453, target.value(PhiFileDataType.Xcen, 44, 38, 14));
        }

        [TestMethod]
        public void Test_errorPhi_3_xcen()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(3784.750, target.value(PhiFileDataType.Xcen, 49, 49, 14));
        }

        [TestMethod]
        public void Test_errorPhi_1_enut()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(2.083966, target.value(PhiFileDataType.Enut, 11, 11, 7));
        }

        [TestMethod]
        public void Test_errorPhi_2_enut()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(31592.87, target.value(PhiFileDataType.Enut, 44, 38, 14));
        }

        [TestMethod]
        public void Test_errorPhi_3_enut()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(15578.10, target.value(PhiFileDataType.Enut, 49, 49, 14));
        }

        [TestMethod]
        public void Test_errorPhi_1_Ucrt()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(3.371978, target.value(PhiFileDataType.Ucrt, 11, 13, 7));
        }

        [TestMethod]
        public void Test_errorPhi_2_Ucrt()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(-4354.532, target.value(PhiFileDataType.Ucrt, 44, 38, 14));
        }

        [TestMethod]
        public void Test_errorPhi_3_Ucrt()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(-6406.749, target.value(PhiFileDataType.Ucrt, 49, 49, 14));
        }

        [TestMethod]
        public void Test_errorPhi_1_Vcrt()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(5.630201, target.value(PhiFileDataType.Vcrt, 11, 13, 7));
        }

        [TestMethod]
        public void Test_errorPhi_2_Vcrt()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(2449.135, target.value(PhiFileDataType.Vcrt, 44, 38, 14));
        }

        [TestMethod]
        public void Test_errorPhi_3_Vcrt()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(442.0277, target.value(PhiFileDataType.Vcrt, 49, 49, 14));
        }

        [TestMethod]
        public void Test_errorPhi_1_Wcrt()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(-0.005028980, target.value(PhiFileDataType.Wcrt, 11, 13, 7));
        }

        [TestMethod]
        public void Test_errorPhi_2_Wcrt()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(-12686.50, target.value(PhiFileDataType.Wcrt, 44, 38, 14));
        }

        [TestMethod]
        public void Test_errorPhi_3_Wcrt()
        {
            string fileName = "error.phi";
            PhiFile target = new PhiFile(fileName);

            Assert.AreEqual(-4601.597, target.value(PhiFileDataType.Wcrt, 49, 49, 14));
        }
    }
}
