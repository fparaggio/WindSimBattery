using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProjectParametersTest and is intended
    ///to contain all ProjectParametersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectParametersTest
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
        ///A test for ProjectParameters Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectParametersConstructorTest()
        {
            ProjectParameters target = new ProjectParameters();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CFD
        ///</summary>
        [TestMethod()]
        public void CFDTest()
        {
            ProjectParameters target = new ProjectParameters(); // TODO: Initialize to an appropriate value
            ProjectParametersCFD expected = null; // TODO: Initialize to an appropriate value
            ProjectParametersCFD actual;
            target.CFD = expected;
            actual = target.CFD;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DTM
        ///</summary>
        [TestMethod()]
        public void DTMTest()
        {
            ProjectParameters target = new ProjectParameters(); // TODO: Initialize to an appropriate value
            ProjectParametersDTM expected = null; // TODO: Initialize to an appropriate value
            ProjectParametersDTM actual;
            target.DTM = expected;
            actual = target.DTM;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WindField
        ///</summary>
        [TestMethod()]
        public void WindFieldTest()
        {
            ProjectParameters target = new ProjectParameters(); // TODO: Initialize to an appropriate value
            ProjectParametersWindField expected = null; // TODO: Initialize to an appropriate value
            ProjectParametersWindField actual;
            target.WindField = expected;
            actual = target.WindField;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WindSim
        ///</summary>
        [TestMethod()]
        public void WindSimTest()
        {
            ProjectParameters target = new ProjectParameters(); // TODO: Initialize to an appropriate value
            ProjectParametersWindSim expected = null; // TODO: Initialize to an appropriate value
            ProjectParametersWindSim actual;
            target.WindSim = expected;
            actual = target.WindSim;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
