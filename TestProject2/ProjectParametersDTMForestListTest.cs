﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for ProjectParametersDTMForestListTest and is intended
    ///to contain all ProjectParametersDTMForestListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectParametersDTMForestListTest
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
        ///A test for ProjectParametersDTMForestList Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectParametersDTMForestListConstructorTest()
        {
            ProjectParametersDTMForestList target = new ProjectParametersDTMForestList();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ForestC1
        ///</summary>
        [TestMethod()]
        public void ForestC1Test()
        {
            ProjectParametersDTMForestList target = new ProjectParametersDTMForestList(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.ForestC1 = expected;
            actual = target.ForestC1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ForestC2
        ///</summary>
        [TestMethod()]
        public void ForestC2Test()
        {
            ProjectParametersDTMForestList target = new ProjectParametersDTMForestList(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.ForestC2 = expected;
            actual = target.ForestC2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ForestCellsZ
        ///</summary>
        [TestMethod()]
        public void ForestCellsZTest()
        {
            ProjectParametersDTMForestList target = new ProjectParametersDTMForestList(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ForestCellsZ = expected;
            actual = target.ForestCellsZ;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ForestHeight
        ///</summary>
        [TestMethod()]
        public void ForestHeightTest()
        {
            ProjectParametersDTMForestList target = new ProjectParametersDTMForestList(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.ForestHeight = expected;
            actual = target.ForestHeight;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ForestPorosity
        ///</summary>
        [TestMethod()]
        public void ForestPorosityTest()
        {
            ProjectParametersDTMForestList target = new ProjectParametersDTMForestList(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.ForestPorosity = expected;
            actual = target.ForestPorosity;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ForestRoughness
        ///</summary>
        [TestMethod()]
        public void ForestRoughnessTest()
        {
            ProjectParametersDTMForestList target = new ProjectParametersDTMForestList(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.ForestRoughness = expected;
            actual = target.ForestRoughness;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
