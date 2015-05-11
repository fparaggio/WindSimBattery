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
    ///This is a test class for ProjectParametersCFDTest and is intended
    ///to contain all ProjectParametersCFDTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectParametersCFDTest
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
        ///A test for ProjectParametersCFD Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectParametersCFDConstructorTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BorderWidth
        ///</summary>
        [TestMethod()]
        public void BorderWidthTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.BorderWidth = expected;
            actual = target.BorderWidth;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CellsZ
        ///</summary>
        [TestMethod()]
        public void CellsZTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.CellsZ = expected;
            actual = target.CellsZ;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DistributionFactor
        ///</summary>
        [TestMethod()]
        public void DistributionFactorTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.DistributionFactor = expected;
            actual = target.DistributionFactor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Height
        ///</summary>
        [TestMethod()]
        public void HeightTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Height = expected;
            actual = target.Height;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HorizontalGridingType
        ///</summary>
        [TestMethod()]
        public void HorizontalGridingTypeTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.HorizontalGridingType = expected;
            actual = target.HorizontalGridingType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HorizontalResolution
        ///</summary>
        [TestMethod()]
        public void HorizontalResolutionTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.HorizontalResolution = expected;
            actual = target.HorizontalResolution;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NodesMax
        ///</summary>
        [TestMethod()]
        public void NodesMaxTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.NodesMax = expected;
            actual = target.NodesMax;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumberSpacings
        ///</summary>
        [TestMethod()]
        public void NumberSpacingsTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.NumberSpacings = expected;
            actual = target.NumberSpacings;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Orthogonalize
        ///</summary>
        [TestMethod()]
        public void OrthogonalizeTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Orthogonalize = expected;
            actual = target.Orthogonalize;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RatioAdditiveLengthToResolution
        ///</summary>
        [TestMethod()]
        public void RatioAdditiveLengthToResolutionTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.RatioAdditiveLengthToResolution = expected;
            actual = target.RatioAdditiveLengthToResolution;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RefinementFileName
        ///</summary>
        [TestMethod()]
        public void RefinementFileNameTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.RefinementFileName = expected;
            actual = target.RefinementFileName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RefinementType
        ///</summary>
        [TestMethod()]
        public void RefinementTypeTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.RefinementType = expected;
            actual = target.RefinementType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimpleRefinementXMax
        ///</summary>
        [TestMethod()]
        public void SimpleRefinementXMaxTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SimpleRefinementXMax = expected;
            actual = target.SimpleRefinementXMax;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimpleRefinementXMin
        ///</summary>
        [TestMethod()]
        public void SimpleRefinementXMinTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SimpleRefinementXMin = expected;
            actual = target.SimpleRefinementXMin;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimpleRefinementYMax
        ///</summary>
        [TestMethod()]
        public void SimpleRefinementYMaxTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SimpleRefinementYMax = expected;
            actual = target.SimpleRefinementYMax;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimpleRefinementYMin
        ///</summary>
        [TestMethod()]
        public void SimpleRefinementYMinTest()
        {
            ProjectParametersCFD target = new ProjectParametersCFD(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SimpleRefinementYMin = expected;
            actual = target.SimpleRefinementYMin;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
