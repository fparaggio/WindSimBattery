using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for WSProjectTest and is intended
    ///to contain all WSProjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WSProjectTest
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
        ///A test for WSProject Constructor
        ///</summary>
        [TestMethod()]
        public void WSProjectConstructorTest()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            string target_directory = string.Empty; // TODO: Initialize to an appropriate value
            WSProject target = new WSProject(file_path, target_directory);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for WSProject Constructor
        ///</summary>
        [TestMethod()]
        public void WSProjectConstructorTest1()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            WSProject target = new WSProject(file_path);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for run
        ///</summary>
        [TestMethod()]
        public void runTest()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            WSProject target = new WSProject(file_path); // TODO: Initialize to an appropriate value
            int module = 0; // TODO: Initialize to an appropriate value
            string option1 = string.Empty; // TODO: Initialize to an appropriate value
            string option2 = string.Empty; // TODO: Initialize to an appropriate value
            target.run(module, option1, option2);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for run
        ///</summary>
        [TestMethod()]
        public void runTest1()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            WSProject target = new WSProject(file_path); // TODO: Initialize to an appropriate value
            int module = 0; // TODO: Initialize to an appropriate value
            string option = string.Empty; // TODO: Initialize to an appropriate value
            target.run(module, option);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for run
        ///</summary>
        [TestMethod()]
        public void runTest2()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            WSProject target = new WSProject(file_path); // TODO: Initialize to an appropriate value
            int module = 0; // TODO: Initialize to an appropriate value
            target.run(module);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for save
        ///</summary>
        [TestMethod()]
        public void saveTest()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            WSProject target = new WSProject(file_path); // TODO: Initialize to an appropriate value
            target.save();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for save
        ///</summary>
        [TestMethod()]
        public void saveTest1()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            WSProject target = new WSProject(file_path); // TODO: Initialize to an appropriate value
            string file_path1 = string.Empty; // TODO: Initialize to an appropriate value
            target.save(file_path1);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
