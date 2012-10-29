﻿using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for LayoutTest and is intended
    ///to contain all LayoutTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LayoutTest
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
        ///A test for Layout Constructor
        ///</summary>
        [TestMethod()]
        public void LayoutConstructorTest()
        {
            string layout_file = string.Empty; // TODO: Initialize to an appropriate value
            DirectoryInfo project_dir = null; // TODO: Initialize to an appropriate value
            Layout target = new Layout(layout_file, project_dir);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
