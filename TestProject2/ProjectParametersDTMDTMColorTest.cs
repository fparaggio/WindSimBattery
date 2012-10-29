using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for ProjectParametersDTMDTMColorTest and is intended
    ///to contain all ProjectParametersDTMDTMColorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectParametersDTMDTMColorTest
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
        ///A test for ProjectParametersDTMDTMColor Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectParametersDTMDTMColorConstructorTest()
        {
            ProjectParametersDTMDTMColor target = new ProjectParametersDTMDTMColor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for B
        ///</summary>
        [TestMethod()]
        public void BTest()
        {
            ProjectParametersDTMDTMColor target = new ProjectParametersDTMDTMColor(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.B = expected;
            actual = target.B;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for G
        ///</summary>
        [TestMethod()]
        public void GTest()
        {
            ProjectParametersDTMDTMColor target = new ProjectParametersDTMDTMColor(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.G = expected;
            actual = target.G;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for R
        ///</summary>
        [TestMethod()]
        public void RTest()
        {
            ProjectParametersDTMDTMColor target = new ProjectParametersDTMDTMColor(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.R = expected;
            actual = target.R;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
