using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindSim.Batch.Core;
using System.IO;
using System.Reflection;


namespace WindSim.Batch.Core.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Test_Tools
    {
        public Test_Tools()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]
        [DeploymentItem("TestFiles\\270.phi.Z", "zipfile")]
        public void test_ExtractionOfAZipFile()
        {
            string dir_name = "zipfile";
            DirectoryInfo filedir = new DirectoryInfo(dir_name);
            string filepath = filedir.FullName + "\\270.phi.Z";
            FileInfo file = new FileInfo(filepath);
            string dir_name_dest = "unzipped_file2";
            DirectoryInfo filedir_dest = new DirectoryInfo(dir_name_dest);
            Tools.UnZipFile(file.FullName, filedir_dest.FullName);
            string filepath_dest = filedir_dest.FullName + "\\270.phi";
            FileInfo file_dest = new FileInfo(filepath_dest);
            Assert.IsTrue(file_dest.Exists);
        }

    }
}



     