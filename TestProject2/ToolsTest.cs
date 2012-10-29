using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for ToolsTest and is intended
    ///to contain all ToolsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ToolsTest
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
        ///A test for Tools Constructor
        ///</summary>
        [TestMethod()]
        public void ToolsConstructorTest()
        {
            Tools target = new Tools();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CopyAll
        ///</summary>
        [TestMethod()]
        public void CopyAllTest()
        {
            DirectoryInfo source = null; // TODO: Initialize to an appropriate value
            DirectoryInfo target = null; // TODO: Initialize to an appropriate value
            Tools.CopyAll(source, target);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SelectPhiFile
        ///</summary>
        [TestMethod()]
        public void SelectPhiFileTest()
        {
            string initialDirectory = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Tools.SelectPhiFile(initialDirectory);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectTextFile
        ///</summary>
        [TestMethod()]
        public void SelectTextFileTest()
        {
            string initialDirectory = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Tools.SelectTextFile(initialDirectory);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for excel_batch_template
        ///</summary>
        [TestMethod()]
        public void excel_batch_templateTest()
        {
            WSProject p = null; // TODO: Initialize to an appropriate value
            Tools.excel_batch_template(p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for inizialize_batch
        ///</summary>
        [TestMethod()]
        public void inizialize_batchTest()
        {
            string project_file = string.Empty; // TODO: Initialize to an appropriate value
            bool prooo = false; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Tools.inizialize_batch(project_file, prooo);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tf_bool
        ///</summary>
        [TestMethod()]
        public void tf_boolTest()
        {
            char a = '\0'; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = Tools.tf_bool(a);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
