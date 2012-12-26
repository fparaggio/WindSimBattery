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
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\project1", "project1")]
    public class Test_RefinementGenerator
    {
        public Test_RefinementGenerator()
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

        static string dir_name = "project1";
        static DirectoryInfo projectdir = new DirectoryInfo(dir_name);
        static string filepath = projectdir.FullName + "\\MoninObukhov_ref.ws";
        static string phifile270_path = projectdir.FullName +"\\windfield\\270_red.phi";
        static string xyzfile270_path = projectdir.FullName + "\\windfield\\270_red.xyz";
        FileInfo project_file = new FileInfo(filepath);




        [TestMethod]
        public void test_Check_project_directory()
        {
            Assert.IsTrue(projectdir.Exists);
        }

        [TestMethod]
        public void test_check_project_file()
        {
            Assert.IsTrue(project_file.Exists);
        }
                
        // i should write some test about the file file compliance but no manual has been provided! :D .!!.!.!..further seems to be a big work because i should write a parser.


        [TestMethod]
        [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_write_the_bws_file_in_the_proper_Directory() 
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filename = "test_bws_position";
            RefinementGenerator.GeometricalGrading test_grading = new RefinementGenerator.GeometricalGrading(0.02, 1000, 20);
            test_grading.Rectangle(project, bws_filename, 50, 50, 50, 50);
            string expected_file_path = project.file.Directory.FullName + "\\dtm\\" + "test_bws_position" + ".bws";;
            FileInfo expected_file = new FileInfo(expected_file_path);
            Assert.IsTrue(expected_file.Exists);
            //

        }

        [TestMethod]
        [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_write_the_bws_file_in_the_proper_Directory_aritm()
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filename = "test_bws_position";
            RefinementGenerator.AritmeticalGrading test_grading = new RefinementGenerator.AritmeticalGrading(1.2,12,400.0);
            test_grading.Rectangle(project, bws_filename, 50, 50, 50, 50);
            string expected_file_path = project.file.Directory.FullName + "\\dtm\\" + "test_bws_position" + ".bws"; ;
            FileInfo expected_file = new FileInfo(expected_file_path);
            Assert.IsTrue(expected_file.Exists);
            //

        }

        [TestMethod]
        [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_load_proper_bws_file_name_project_parameters()
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filename = "test_bws_position";
            
            string bws_file = bws_filename +".bws";
                        RefinementGenerator.GeometricalGrading test_grading = new RefinementGenerator.GeometricalGrading(0.02, 1000, 20);
            test_grading.Rectangle(project, bws_filename, 50, 50, 50, 50);
            Assert.AreEqual(bws_file,project.parameters.CFD.RefinementFileName);
        }


        [TestMethod]
        [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_load__proper_bws_type_in_project_parameters()
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filename = "test_bws_position";
            RefinementGenerator.GeometricalGrading test_grading = new RefinementGenerator.GeometricalGrading(0.02, 1000, 20);
            test_grading.Rectangle(project, bws_filename, 50, 50, 50, 50);
            Assert.AreEqual(2, project.parameters.CFD.RefinementType);
        }

        [TestMethod]
        [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_GeometricalGrading()
        {
            RefinementGenerator.GeometricalGrading test_grading = new RefinementGenerator.GeometricalGrading(0.02,1000,20);
            Assert.AreEqual(Math.Round(1.685591820,4), Math.Round(test_grading.expansionFactor,4));
        }

        [TestMethod]
        [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_AritmeticalGrading_heightDistributionFactor()
        {
            RefinementGenerator.AritmeticalGrading test_grading = new RefinementGenerator.AritmeticalGrading(1.2,10,10);
            Assert.AreEqual(Math.Round(0.3571428571429, 4), Math.Round(test_grading.heightDistributionFactor, 4));
        }

        [TestMethod]
        [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_AritmeticalGrading_additiveCostant()
        {
            RefinementGenerator.AritmeticalGrading test_grading = new RefinementGenerator.AritmeticalGrading(1.2, 10, 10);
            Assert.AreEqual(Math.Round(0.1052633157894737, 4), Math.Round(test_grading.additiveCostant, 4));
        }

        [TestMethod]
        [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_AritmeticalGrading_heightFirstLayer()
        {
            RefinementGenerator.AritmeticalGrading test_grading = new RefinementGenerator.AritmeticalGrading(1.2, 10, 10);
            Assert.AreEqual(Math.Round(0.5263157894737, 4), Math.Round(test_grading.heightFirstLayer, 4));
        }
  
    }
}



     