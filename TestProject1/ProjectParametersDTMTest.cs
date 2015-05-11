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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProjectParametersDTMTest and is intended
    ///to contain all ProjectParametersDTMTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectParametersDTMTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ProjectParametersDTM Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectParametersDTMConstructorTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CoordSys
        ///</summary>
        [TestMethod()]
        public void CoordSysTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.CoordSys = expected;
            actual = target.CoordSys;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DTMColor
        ///</summary>
        [TestMethod()]
        public void DTMColorTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            ProjectParametersDTMDTMColor expected = null; // TODO: Initialize to an appropriate value
            ProjectParametersDTMDTMColor actual;
            target.DTMColor = expected;
            actual = target.DTMColor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Elongation
        ///</summary>
        [TestMethod()]
        public void ElongationTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Elongation = expected;
            actual = target.Elongation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ForestList
        ///</summary>
        [TestMethod()]
        public void ForestListTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            ProjectParametersDTMForestList expected = null; // TODO: Initialize to an appropriate value
            ProjectParametersDTMForestList actual;
            target.ForestList = expected;
            actual = target.ForestList;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ForestType
        ///</summary>
        [TestMethod()]
        public void ForestTypeTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ForestType = expected;
            actual = target.ForestType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenerateCFDModel
        ///</summary>
        [TestMethod()]
        public void GenerateCFDModelTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.GenerateCFDModel = expected;
            actual = target.GenerateCFDModel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenerateGLViewFine
        ///</summary>
        [TestMethod()]
        public void GenerateGLViewFineTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.GenerateGLViewFine = expected;
            actual = target.GenerateGLViewFine;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenerateVTF
        ///</summary>
        [TestMethod()]
        public void GenerateVTFTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.GenerateVTF = expected;
            actual = target.GenerateVTF;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HashCodeLastRun
        ///</summary>
        [TestMethod()]
        public void HashCodeLastRunTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.HashCodeLastRun = expected;
            actual = target.HashCodeLastRun;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LastChanged
        ///</summary>
        [TestMethod()]
        public void LastChangedTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.LastChanged = expected;
            actual = target.LastChanged;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumberForests
        ///</summary>
        [TestMethod()]
        public void NumberForestsTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.NumberForests = expected;
            actual = target.NumberForests;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Roughness
        ///</summary>
        [TestMethod()]
        public void RoughnessTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Roughness = expected;
            actual = target.Roughness;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SmoothingLimit
        ///</summary>
        [TestMethod()]
        public void SmoothingLimitTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.SmoothingLimit = expected;
            actual = target.SmoothingLimit;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SmoothingType
        ///</summary>
        [TestMethod()]
        public void SmoothingTypeTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SmoothingType = expected;
            actual = target.SmoothingType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SmoothingWeighting
        ///</summary>
        [TestMethod()]
        public void SmoothingWeightingTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.SmoothingWeighting = expected;
            actual = target.SmoothingWeighting;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TextureFile
        ///</summary>
        [TestMethod()]
        public void TextureFileTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.TextureFile = expected;
            actual = target.TextureFile;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Type = expected;
            actual = target.Type;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for XMax
        ///</summary>
        [TestMethod()]
        public void XMaxTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.XMax = expected;
            actual = target.XMax;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for XMin
        ///</summary>
        [TestMethod()]
        public void XMinTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.XMin = expected;
            actual = target.XMin;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for YMax
        ///</summary>
        [TestMethod()]
        public void YMaxTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.YMax = expected;
            actual = target.YMax;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for YMin
        ///</summary>
        [TestMethod()]
        public void YMinTest()
        {
            ProjectParametersDTM target = new ProjectParametersDTM(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.YMin = expected;
            actual = target.YMin;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
