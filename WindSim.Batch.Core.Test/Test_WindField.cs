using WindSim.Batch.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ExcelLibrary;


namespace WindSim.Batch.Core.Test
{
    
    

    [TestClass()]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\project1", "project1")]
    public class Test_WindField
    {

        // verifico la presenza dei files ed inizializo l-ogetto
        static string dir_name = "project1";
        static DirectoryInfo projectdir = new DirectoryInfo(dir_name);
        static string filepath = projectdir.FullName + "\\MoninObukhov_ref.ws";
        static FileInfo project_file = new FileInfo(filepath);
        static string phi_file270_path = projectdir.FullName + "\\windfield\\270_red.phi";
        static string xyz_file270_path = projectdir.FullName + "\\windfield\\270_red.xyz";
        static private WSProject reference_project = new WSProject(project_file.FullName);
        private WindField target = new WindField(reference_project, 270);


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
        [TestMethod]
        public void WindField_Check_project_directory()
        {
            Assert.IsTrue(projectdir.Exists);
        }

        [TestMethod]
        public void WindField_check_project_file()
        {
            Assert.IsTrue(project_file.Exists);
        }

        [TestMethod]
        public void WindField_check_270phi_file()
        {
            FileInfo file = new FileInfo(phi_file270_path);
            Assert.IsTrue(file.Exists);
        }

        [TestMethod]
        public void WindField_check_270xyz_file()
        {
            FileInfo file = new FileInfo(xyz_file270_path);
            Assert.IsTrue(file.Exists);
        }


        [TestMethod]
        public void WindField_constructor_phi()
        {
            FileInfo phi_file = new FileInfo(phi_file270_path);
            PhiFile expected = new PhiFile(phi_file.FullName);
            Assert.IsTrue(expected.Equals(target.phi));
        }

        [TestMethod]
        public void WindField_constructor_xyz()
        {
            FileInfo xyz_file = new FileInfo(xyz_file270_path);
            XYZFile expected = new XYZFile(xyz_file.FullName);
            Assert.IsTrue(target.xyz.Equals(expected));
        }

        [TestMethod]
        public void WindField_ucrt_1()
        {
            Assert.AreEqual(target.phi.vars_phi[2, 1, 1, 5],target.ucrt(3, 2)[1]);
        }

        [TestMethod]
        public void WindField_ucrt_2()
        {
            Assert.AreEqual(target.phi.vars_phi[1, 1, 2, 5], target.ucrt(2, 2)[2]);
        }
        [TestMethod]
        public void WindField_zcen_length()
        {
            FileInfo xyz_file = new FileInfo(xyz_file270_path);
            XYZFile expected = new XYZFile(xyz_file.FullName);
            Assert.AreEqual(expected.nk-1, target.ucrt(1,1).Length);
        }

        [TestMethod]
        public void WindField_zcen_floor()
        {
            FileInfo xyz_file = new FileInfo(xyz_file270_path);
            XYZFile expected = new XYZFile(xyz_file.FullName);
            double expected_value = expected.values[1, 1, 0, 2] + ((expected.values[1, 1, 1, 2] - expected.values[1, 1, 0, 2]) / 2);
            Assert.AreEqual(expected_value ,target.zcen(2, 2)[0]);
        }

        [TestMethod]
        public void WindField_zcen_top()
        {
            FileInfo xyz_file = new FileInfo(xyz_file270_path);
            XYZFile expected = new XYZFile(xyz_file.FullName);
            double expected_value = expected.values[1, 1, (target.xyz.nk - 2), 2] + ((expected.values[1, 1, (target.xyz.nk - 1), 2] - expected.values[1, 1, (target.xyz.nk - 2), 2]) / 2);
            Assert.AreEqual(expected_value, target.zcen(2,2)[(target.xyz.nk - 2)]);
        }

        [TestMethod]
        public void WindField_z0_1()
        {
            double[] zcen = target.zcen(1,1);
            double[] ucrt = target.ucrt(1,1);
            //Tools.write_excel_arrays(@"c:\WindField_z0_1.xls", zcen, ucrt);
            //The file as modified for calculation purpose is attached in WindSim.Batch.Core.Test\\Test_windField_z0_support_files
            Assert.AreEqual(0.0465,Math.Round(target.z0(2, 2)[0],4)); 
         }

        [TestMethod]
        public void WindField_z0_2()
        {
            double[] zcen = target.zcen(6, 2);
            double[] ucrt = target.ucrt(6, 2);
            //Tools.write_excel_arrays(@"c:\WindField_z0_2.xls", zcen, ucrt);
            //The file as modified for calculation purpose is attached in WindSim.Batch.Core.Test\\Test_windField_z0_support_files
            Assert.AreEqual(0.0568, Math.Round(target.z0(7, 3)[0], 4));
        }
    }
}



