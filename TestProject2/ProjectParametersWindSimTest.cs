using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for ProjectParametersWindSimTest and is intended
    ///to contain all ProjectParametersWindSimTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectParametersWindSimTest
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
        ///A test for ProjectParametersWindSim Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectParametersWindSimConstructorTest()
        {
            ProjectParametersWindSim target = new ProjectParametersWindSim();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Customer
        ///</summary>
        [TestMethod()]
        public void CustomerTest()
        {
            ProjectParametersWindSim target = new ProjectParametersWindSim(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.Customer = expected;
            actual = target.Customer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LicenseHolder
        ///</summary>
        [TestMethod()]
        public void LicenseHolderTest()
        {
            ProjectParametersWindSim target = new ProjectParametersWindSim(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.LicenseHolder = expected;
            actual = target.LicenseHolder;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProjectType
        ///</summary>
        [TestMethod()]
        public void ProjectTypeTest()
        {
            ProjectParametersWindSim target = new ProjectParametersWindSim(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ProjectType = expected;
            actual = target.ProjectType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpgradedFromVersion
        ///</summary>
        [TestMethod()]
        public void UpgradedFromVersionTest()
        {
            ProjectParametersWindSim target = new ProjectParametersWindSim(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.UpgradedFromVersion = expected;
            actual = target.UpgradedFromVersion;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            ProjectParametersWindSim target = new ProjectParametersWindSim(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Version = expected;
            actual = target.Version;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
