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
    [DeploymentItem("TestFiles\\project1", "project1")]
    public class Test_project
    {
        public Test_project()
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
                
        
        [TestMethod]
        public void test_check_phifile_exist()
        {
            FileInfo phif = new FileInfo(phifile270_path);
            Assert.IsTrue(phif.Exists);
        }


        //[TestMethod]
        //public void test_project_fill_phifiles_on_construct()
        //{
        //    WSProject project = new WSProject(project_file.FullName);
        //    PhiFile settore_270 = new PhiFile(phifile270_path);
        //    Assert.IsTrue(project.WField[270].phi.Equals(settore_270)); //remeber that Phifile equals do not compare vars_phi[,,,] !
        //    // should test if the file do not exist project_fill_phifiles_on_construct()
        //}

        //[TestMethod]
        //public void test_project_fill_xyz_on_construct()
        //{
        //    WSProject project = new WSProject(project_file.FullName);
        //    XYZFile settore_270 = new XYZFile(xyzfile270_path);
        //    Assert.IsTrue(project.WField[270].xyz.Equals(settore_270)); //remeber that Phifile equals do not compare vars_phi[,,,] !
        //    // should test if the file do not exist project_fill_xyzfiles_on_construct()
        //}

        [TestMethod]
        public void test_project_constructor_with_target_directory_create_same_size_project_dir()
        {
            string target_directory_for_testing = "temp_project_test";
            WSProject project = new WSProject(project_file.FullName, target_directory_for_testing);
            Assert.AreEqual(Tools.GetDirectorySize(dir_name), Tools.GetDirectorySize(target_directory_for_testing));
            //DirectoryInfo target_dir_obj = new DirectoryInfo(target_directory_for_testing);
            //target_dir_obj.Delete();
        }

        [TestMethod]
        public void test_project_constructor_with_target_directory_refer_to_the_right_project_file()
        {
            string target_directory_string_for_testing = "temp_project_test";
            WSProject project = new WSProject(project_file.FullName, target_directory_string_for_testing);
            DirectoryInfo target_dir_obj = new DirectoryInfo(target_directory_string_for_testing);
            Assert.AreEqual(project.file.FullName, target_dir_obj.FullName + "\\" + project.file.Name);
            //DirectoryInfo target_dir_obj = new DirectoryInfo(target_directory_for_testing);
            //target_dir_obj.Delete();

        }

        [TestMethod]
        public void test_project_run_string_1_var()
        {
            WSProject project = new WSProject(project_file.FullName);
            Assert.AreEqual(project.run_string(1, "b"), " \"" + project.file.FullName + "\"" + " \"Layout 1.lws\" \"C:\\Program Files\\WindSim\\WindSim 5.1.0\\Environment.xml\" 1 /b ");
        }
        //TestContext.TestDeploymentDir
        // "C:\Users\WindSim\Documents\Visual Studio 2010\Projects\windsim_batch\TestResults\WindSim_DAVID-LAPTOP 2012-10-03 13_29_37\Out\project1\MoninObukhov_ref.ws" "Layout 1.lws" "C:\Program Files\WindSim\WindSim 5.1.0\Environment.xml" 1 /b 
        
        [TestMethod]
        public void test_project_run_string_2_var()
        {
            WSProject project = new WSProject(project_file.FullName);
            Assert.AreEqual(project.run_string(1, "b","m"), " \"" + project.file.FullName + "\"" + " \"Layout 1.lws\" \"C:\\Program Files\\WindSim\\WindSim 5.1.0\\Environment.xml\" 1 /b /m");
        }

        [TestMethod]
        public void test_project_run_string_3_var()
        {
            WSProject project = new WSProject(project_file.FullName);
            Assert.AreEqual(project.run_string(4, "b", "m"), " \"" + project.file.FullName + "\"" + " \"Layout 1.lws\" \"C:\\Program Files\\WindSim\\WindSim 5.1.0\\Environment.xml\" 4 /b /m");
        }

        [TestMethod]
        public void test_new_project_RanOnCurrentGws_false()
        {
            WSProject project = new WSProject(project_file.FullName);
            Assert.AreEqual(false, project.terrainRanOnCurrentGws);
        }

        [TestMethod]
        public void test_project_run_terrain_set_RanOnCurrentGws_true()
        {
            WSProject project = new WSProject(project_file.FullName);
            project.run(1);
            Assert.AreEqual(true,project.terrainRanOnCurrentGws);
        }

        [TestMethod]
        public void test_project_save()
        {
            WSProject project = new WSProject(project_file.FullName);
            project.parameters.DTM.Roughness = 912.1F;
            project.save();
            WSProject project2 = new WSProject(project_file.FullName);
            Assert.AreEqual(project2.parameters.DTM.Roughness, 912.1F);
        }

        
        [TestMethod]
        [DeploymentItem("TestFiles\\bws_test.bws")]
        public void test_check_bws_file()
        {
            string bws_filepath = "bws_test.bws";
            FileInfo bws_file = new FileInfo(bws_filepath);
            Assert.IsTrue(bws_file.Exists);
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\bws_test.bws")]
        public void test_project_load_bws_proper_file_positioning() 
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filepath = "bws_test.bws";
            FileInfo bws_file = new FileInfo(bws_filepath);
            bool check = project.load_bws(bws_file.FullName);
            string expected_file_path = project.file.Directory.FullName + "\\dtm\\" + bws_file.Name;
            FileInfo expected_file = new FileInfo(expected_file_path);
            Assert.IsTrue(expected_file.Exists);
            //

        }


        [TestMethod]
        [DeploymentItem("TestFiles\\bws_test.bws")]
        public void test_project_load_bws_proper_file_referencing_in_project_parameters()
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filepath = "bws_test.bws";
            FileInfo bws_file = new FileInfo(bws_filepath);
            bool check = project.load_bws(bws_file.FullName);
            Assert.AreEqual(bws_filepath,project.parameters.CFD.RefinementFileName) ;
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\bws_test.bws")]
        public void test_project_load_bws_proper_refinement_type_in_project_parameters()
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filepath = "bws_test.bws";
            FileInfo bws_file = new FileInfo(bws_filepath);
            bool check = project.load_bws(bws_file.FullName);
            Assert.AreEqual(2,project.parameters.CFD.RefinementType);
        }


        [TestMethod]
        [DeploymentItem("TestFiles\\gws_test.gws")]
        public void test_check_gws_file()
        {
            string gws_filepath = "gws_test.gws";
            FileInfo gws_file = new FileInfo(gws_filepath);
            Assert.IsTrue(gws_file.Exists);
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\gws_test.gws")]
        public void test_project_load_gws_proper_file_renaming()
        {
            WSProject project = new WSProject(project_file.FullName);
            string gws_filepath = "gws_test.gws";
            FileInfo bws_file = new FileInfo(gws_filepath);
            bool check = project.load_gws(bws_file.FullName);
            string expected_file_path = project.file.Directory.FullName + "\\dtm\\grid.backup_fbatch_0.gws";
            FileInfo expected_file = new FileInfo(expected_file_path);
            Assert.IsTrue(expected_file.Exists);
            //

        }

        [TestMethod]
        [DeploymentItem("TestFiles\\gws_test.gws")]
        public void test_project_load_gws_proper_file_renaming_2()
        {
            WSProject project = new WSProject(project_file.FullName);
            string gws_filepath = "gws_test.gws";
            FileInfo bws_file = new FileInfo(gws_filepath);
            bool check = project.load_gws(bws_file.FullName);
            bool check2 = project.load_gws(bws_file.FullName);
            string expected_file_path = project.file.Directory.FullName + "\\dtm\\grid.backup_fbatch_1.gws";
            FileInfo expected_file = new FileInfo(expected_file_path);
            Assert.IsTrue(expected_file.Exists);
            //
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\gws_test.gws")]
        public void test_project_properly_load_gws_file()
        {
            WSProject project = new WSProject(project_file.FullName);
            string gws_filepath = "gws_test.gws";
            FileInfo gws_file = new FileInfo(gws_filepath);
            bool check = project.load_gws(gws_file.FullName);
            string expected_file_path = project.file.Directory.FullName + "\\dtm\\grid.gws";
            string sourceContent = File.ReadAllText(gws_file.FullName);
            string destinationContent = File.ReadAllText(expected_file_path);
            Assert.AreEqual(sourceContent, destinationContent);
            //

        }

        [TestMethod]
        [DeploymentItem("TestFiles\\gws_test.gws")]
        public void test_project_load_gws_proper_file_referencing_in_project_terrainRanOnCurrentGws()
        {
            WSProject project = new WSProject(project_file.FullName);
            string gws_filepath = "gws_test.gws";
            FileInfo gws_file = new FileInfo(gws_filepath);
            project.terrainRanOnCurrentGws = true;
            bool check = project.load_gws(gws_file.FullName);
            Assert.AreEqual(false, project.terrainRanOnCurrentGws);
        }

    }
}



     