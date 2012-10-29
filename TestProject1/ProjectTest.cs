﻿using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProjectTest and is intended
    ///to contain all ProjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectTest
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
        ///A test for Project Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectConstructorTest()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            Project target = new Project(file_path);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for run_default
        ///</summary>
        [TestMethod()]
        public void run_defaultTest()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            Project target = new Project(file_path); // TODO: Initialize to an appropriate value
            string core_path = string.Empty; // TODO: Initialize to an appropriate value
            string layout_path = string.Empty; // TODO: Initialize to an appropriate value
            string environment_path = string.Empty; // TODO: Initialize to an appropriate value
            int module = 0; // TODO: Initialize to an appropriate value
            target.run_default(core_path, layout_path, environment_path, module);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for save_to_file
        ///</summary>
        [TestMethod()]
        public void save_to_fileTest()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            Project target = new Project(file_path); // TODO: Initialize to an appropriate value
            string file_path1 = string.Empty; // TODO: Initialize to an appropriate value
            target.save_to_file(file_path1);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
