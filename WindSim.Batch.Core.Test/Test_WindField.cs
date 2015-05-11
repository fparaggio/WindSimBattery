using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace WindSim.Batch.Core.Test
{
    [TestClass]
    [DeploymentItem("TestFiles\\project1", "project1")]
    [DeploymentItem("TestFiles\\Ionic.Zip.dll")]
    public class Test_WindField
    {

        // verifico la presenza dei files ed inizializo l-ogetto
        static string dir_name = "project1";
        static DirectoryInfo projectdir = new DirectoryInfo(dir_name);
        static string filepath = projectdir.FullName + "\\MoninObukhov_ref.ws";
        static FileInfo project_file = new FileInfo(filepath);
        static string phi_file270_path = projectdir.FullName + "\\windfield\\270_red.phi";
        static string xyz_file270_path = projectdir.FullName + "\\windfield\\270_red.xyz";
        static string phi_file_zipped = projectdir.FullName + "\\windfield\\270.phi.Z";
        static WSProject reference_project = new WSProject(project_file.FullName);
        static WindField target =new WindField(reference_project, 270);
        WindField target2 = new WindField(reference_project, 270, PhiFileType.notReduced);
        WindField target2_reduced = new WindField(reference_project, 270, PhiFileType.reduced);

        public Test_WindField() 
        { 
        

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
        public void WindField_phi_file_zipped()
        {
            FileInfo file = new FileInfo(phi_file_zipped);
            Assert.IsTrue(file.Exists);
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
            Assert.AreEqual(target.phi.vars_phi[2, 1, 1, 5], target.ucrt(3, 2)[1]);
        }
  
        [TestMethod]
        public void WindField_ucrt_1_notreduced()
        {
            
            Assert.AreEqual(target.phi.vars_phi[2, 1, 1, 5], target2.phi.value(PhiFileDataType.Ucrt, 2, 1, 1));
        }

        [TestMethod]
        public void WindField_ucrt_2()
        {
            Assert.AreEqual(target.phi.vars_phi[1, 1, 2, 5], target.ucrt(2, 2)[2]);
        }

        [TestMethod]
        public void WindField_ucrt_2_notreduced()
        {
            WindField target2 = new WindField(reference_project, 270, PhiFileType.notReduced);
            Assert.AreEqual(target.phi.vars_phi[1, 1, 2, 5], target2.phi.value(PhiFileDataType.Ucrt, 1, 1, 2));
        }
        
        [TestMethod]
        public void WindField_zcen_length()
        {
            FileInfo xyz_file = new FileInfo(xyz_file270_path);
            XYZFile expected = new XYZFile(xyz_file.FullName);
            Assert.AreEqual(expected.nk - 1, target.ucrt(1, 1).Length);
        }

        [TestMethod]
        public void WindField_zcen_floor()
        {
            FileInfo xyz_file = new FileInfo(xyz_file270_path);
            XYZFile expected = new XYZFile(xyz_file.FullName);
            double expected_value = expected.values[1, 1, 0, 2] + ((expected.values[1, 1, 1, 2] - expected.values[1, 1, 0, 2]) / 2);
            Assert.AreEqual(expected_value, target.zcen(2, 2)[0]);
        }

        [TestMethod]
        public void WindField_zcen_top()
        {
            FileInfo xyz_file = new FileInfo(xyz_file270_path);
            XYZFile expected = new XYZFile(xyz_file.FullName);
            double expected_value = expected.values[1, 1, (target.xyz.nk - 2), 2] + ((expected.values[1, 1, (target.xyz.nk - 1), 2] - expected.values[1, 1, (target.xyz.nk - 2), 2]) / 2);
            Assert.AreEqual(expected_value, target.zcen(2, 2)[(target.xyz.nk - 2)]);
        }

        [TestMethod]
        public void WindField_z0_1()
        {
            double[] zcen = target.zcen(1, 1);
            double[] ucrt = target.ucrt(1, 1);
            //Tools.write_excel_arrays(@"c:\WindField_z0_1.xls", zcen, ucrt);
            //The file as modified for calculation purpose is attached in WindSim.Batch.Core.Test\\Test_windField_z0_support_files
            Assert.AreEqual(0.0465, Math.Round(target.z0(2, 2)[0], 4));
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

        [TestMethod]
        public void WindField_PhiAndXyzDimensionsAreOK_x()
        {
            Assert.AreEqual(target.phi.vars_phi.GetLength(0), target.xyz.values.GetLength(0) - 1);
        }

        [TestMethod]
        public void WindField_PhiAndXyzDimensionsAreOK_y()
        {
            Assert.AreEqual(target.phi.vars_phi.GetLength(1), target.xyz.values.GetLength(1) - 1);
        }

        [TestMethod]
        public void WindField_PhiAndXyzDimensionsAreOK_z()
        {
            Assert.AreEqual(target.phi.vars_phi.GetLength(2), target.xyz.values.GetLength(2) - 1);
        }

        [TestMethod]
        public void WindField_WindFieldCell_p1()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)

            Assert.AreEqual(1, cella.P1);
        }

        [TestMethod]
        public void WindField_WindFieldCell_ke()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)

            Assert.AreEqual(2, cella.Ke);
        }
        [TestMethod]
        public void WindField_WindFieldCell_ep()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)

            Assert.AreEqual(3, cella.Ep);
        }

        [TestMethod]
        public void WindField_WindFieldCell_wcrt()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)

            Assert.AreEqual(4, cella.Wcrt);
        }

        [TestMethod]
        public void WindField_WindFieldCell_vcrt()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)

            Assert.AreEqual(5, cella.Vcrt);
        }

        [TestMethod]
        public void WindField_WindFieldCell_Ucrt()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)

            Assert.AreEqual(6, cella.Ucrt);
        }

        [TestMethod]
        public void WindField_WindFieldCell_Tem1()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            cella.AddTem1(8);
            Assert.AreEqual(8, cella.Tem1);
        }

        [TestMethod]
        public void WindField_WindFieldCell_AddPoint_cen()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            XYZObject point = new XYZObject(11, 12, 13);
            cella.AddPoint(WindFieldCell.PointPosition.Center, point);
            Assert.AreEqual(point, cella.Cen);
        }

        [TestMethod]
        public void WindField_WindFieldCell_AddPoint_nwu()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            XYZObject point = new XYZObject(11, 122, 13);
            cella.AddPoint(WindFieldCell.PointPosition.NorthWestUp, point);
            Assert.AreEqual(point, cella.Nwu);
        }

        [TestMethod]
        public void WindField_WindFieldCell_AddPoint_neu()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            XYZObject point = new XYZObject(121, 122, 13);
            cella.AddPoint(WindFieldCell.PointPosition.NorthEastUp, point);
            Assert.AreEqual(point, cella.Neu);
        }

        [TestMethod]
        public void WindField_WindFieldCell_AddPoint_swu()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            XYZObject point = new XYZObject(121, 1232, 13);
            cella.AddPoint(WindFieldCell.PointPosition.SouthWestUp, point);
            Assert.AreEqual(point, cella.Swu);
        }

        [TestMethod]
        public void WindField_WindFieldCell_AddPoint_seu()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            XYZObject point = new XYZObject(121, 1232, 133456);
            cella.AddPoint(WindFieldCell.PointPosition.SouthEastUp, point);
            Assert.AreEqual(point, cella.Seu);
        }

        [TestMethod]
        public void WindField_WindFieldCell_AddPoint_nwl()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            XYZObject point = new XYZObject(121, 1232, 133456);
            cella.AddPoint(WindFieldCell.PointPosition.NorthWestLow, point);
            Assert.AreEqual(point, cella.Nwl);
        }

        [TestMethod]
        public void WindField_WindFieldCell_AddPoint_nel()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            XYZObject point = new XYZObject(121, 1232, 133456);
            cella.AddPoint(WindFieldCell.PointPosition.NorthEastLow, point);
            Assert.AreEqual(point, cella.Nel);
        }

        [TestMethod]
        public void WindField_WindFieldCell_AddPoint_swl()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            XYZObject point = new XYZObject(121, 441232, 133456);
            cella.AddPoint(WindFieldCell.PointPosition.SouthWestLow, point);
            Assert.AreEqual(point, cella.Swl);
        }

        [TestMethod]
        public void WindField_WindFieldCell_AddPoint_sel()
        {

            WindFieldCell cella = new WindFieldCell(1, 2, 3, 4, 5, 6);
            //public WindFieldCell(double p1, double ke, double ep, double wcrt, double vcrt, double ucrt)
            XYZObject point = new XYZObject(121, 441232, 133456);
            cella.AddPoint(WindFieldCell.PointPosition.SouthEastLow, point);
            Assert.AreEqual(point, cella.Sel);
        }

        //private XYZObject _nwu, _neu, _swu, _seu;
        //private XYZObject _nwl, _nel, _swl, _sel;
        //private XYZObject _cen;

        [TestMethod]
        public void WindField_reduced_field_P1()
        {
            Assert.AreEqual(target.Field[1,1,1].P1, target.phi.value(PhiFileDataType.P1, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_reduced_field_Ke()
        {
            Assert.AreEqual(target.Field[1, 1, 1].Ke, target.phi.value(PhiFileDataType.Ke, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_reduced_field_Ep()
        {
            Assert.AreEqual(target.Field[1, 1, 1].Ep, target.phi.value(PhiFileDataType.Ep, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_reduced_field_Tem1()
        {
            Assert.AreEqual(target.Field[1, 1, 1].Tem1, target.phi.value(PhiFileDataType.Tem1, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_reduced_field_Wcrt()
        {
            Assert.AreEqual(target.Field[1, 1, 1].Wcrt, target.phi.value(PhiFileDataType.Wcrt, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_reduced_field_Vcrt()
        {
            Assert.AreEqual(target.Field[1, 1, 1].Vcrt, target.phi.value(PhiFileDataType.Vcrt, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_reduced_field_Ucrt()
        {
            Assert.AreEqual(target.Field[1, 1, 1].Ucrt, target.phi.value(PhiFileDataType.Ucrt, 1, 1, 1));
        }
        //           NWU+--------------------+NEU 
        //             /|                   /|
        //            / |                  / |
        //           /  |                 /  |
        // k+1   SWU+--------------------+SEU|  
        //          |   |                |   |
        //          |   |                |   |
        //          |   |                |   |
        //          |   |       *CEN     |   |
        //          |   |                |   |
        //          |   |                |   |
        //   Z j+1  |NWL+----------------|---+NEL
        //   ^      |  /                 |  /
        //   |      | /	                | /
        //   |      |/		            |/
        // k | j SWL+--------------------+SEL
        //   |     i                       i+1
        //   |  >Y
        //   | /
        //   |/
        //   +------------------------>X
        //NorthWestUp [i,j+1,k+1], 
        [TestMethod]
        public void WindField_reduced_field_NorthWestUp()
        {
            CollectionAssert.AreEqual(target.Field[1, 1, 1].Nwu.toArray(), new double[] { target.xyz.values[1, 2, 2, 0], target.xyz.values[1, 2, 2, 1], target.xyz.values[1, 2, 2, 2] });
        }
        //NorthEastUp, 
        [TestMethod]
        public void WindField_reduced_field_NorthEastUp()
        {
            CollectionAssert.AreEqual(target.Field[1, 1, 1].Neu.toArray(), new double[] { target.xyz.values[2, 2, 2, 0], target.xyz.values[2, 2, 2, 1], target.xyz.values[2, 2, 2, 2] });
        }
        //SouthWestUp,
        [TestMethod]
        public void WindField_reduced_field_SouthWestUp()
        {
            CollectionAssert.AreEqual(target.Field[1, 1, 1].Swu.toArray(), new double[] { target.xyz.values[1, 1, 2, 0], target.xyz.values[1, 1, 2, 1], target.xyz.values[1, 1, 2, 2] });
        }
        //SouthEastUp,
        [TestMethod]
        public void WindField_reduced_field_SouthEastUp()
        {
            CollectionAssert.AreEqual(target.Field[1, 1, 1].Seu.toArray(), new double[] { target.xyz.values[2, 1, 2, 0], target.xyz.values[2, 1, 2, 1], target.xyz.values[2, 1, 2, 2] });
        }       
        //NorthWestLow,
        [TestMethod]
        public void WindField_reduced_field_NorthWestLow()
        {
            CollectionAssert.AreEqual(target.Field[1, 1, 1].Nwl.toArray(), new double[] { target.xyz.values[1, 2, 1, 0], target.xyz.values[1, 2, 1, 1], target.xyz.values[1, 2, 1, 2] });
        }   
        //NorthEastLow,
        [TestMethod]
        public void WindField_reduced_field_NorthEastLow()
        {
            CollectionAssert.AreEqual(target.Field[1, 1, 1].Nel.toArray(), new double[] { target.xyz.values[2, 2, 1, 0], target.xyz.values[2, 2, 1, 1], target.xyz.values[2, 2, 1, 2] });
        } 
        //SouthWestLow,
        [TestMethod]
        public void WindField_reduced_field_SouthWestLow()
        {
            CollectionAssert.AreEqual(target.Field[1, 1, 1].Swl.toArray(), new double[] { target.xyz.values[1, 1, 1, 0], target.xyz.values[1, 1, 1, 1], target.xyz.values[1, 1, 1, 2] });
        } 
        //SouthEastLow, 
        [TestMethod]
        public void WindField_reduced_field_SouthEastLow()
        {
            CollectionAssert.AreEqual(target.Field[1, 1, 1].Sel.toArray(), new double[] { target.xyz.values[2, 1, 1, 0], target.xyz.values[2, 1, 1, 1], target.xyz.values[2, 1, 1, 2] });
        }

        [TestMethod]
        public void WindField_NotReduced_field_P1()
        {
            Assert.AreEqual(target2.Field[1, 1, 1].P1, target2.phi.value(PhiFileDataType.P1, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_NotReduced_field_Ke()
        {
            Assert.AreEqual(target2.Field[1, 1, 1].Ke, target2.phi.value(PhiFileDataType.Ke, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_NotReduced_field_Ep()
        {
            Assert.AreEqual(target2.Field[1, 1, 1].Ep, target2.phi.value(PhiFileDataType.Ep, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_NotReduced_field_Tem1()
        {
            Assert.AreEqual(target2.Field[1, 1, 1].Tem1, target2.phi.value(PhiFileDataType.Tem1, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_NotReduced_field_Wcrt()
        {
            Assert.AreEqual(target2.Field[1, 1, 1].Wcrt, target2.phi.value(PhiFileDataType.Wcrt, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_NotReduced_field_Vcrt()
        {
            Assert.AreEqual(target2.Field[1, 1, 1].Vcrt, target2.phi.value(PhiFileDataType.Vcrt, 1, 1, 1));
        }

        [TestMethod]
        public void WindField_NotReduced_field_Ucrt()
        {
            Assert.AreEqual(target2.Field[1, 1, 1].Ucrt, target2.phi.value(PhiFileDataType.Ucrt, 1, 1, 1));
        }
        //           NWU+--------------------+NEU 
        //             /|                   /|
        //            / |                  / |
        //           /  |                 /  |
        // k+1   SWU+--------------------+SEU|  
        //          |   |                |   |
        //          |   |                |   |
        //          |   |                |   |
        //          |   |       *CEN     |   |
        //          |   |                |   |
        //          |   |                |   |
        //   Z j+1  |NWL+----------------|---+NEL
        //   ^      |  /                 |  /
        //   |      | /	                 | /
        //   |      |/		             |/
        // k | j SWL+--------------------+SEL
        //   |     i                       i+1
        //   |  >Y
        //   | /
        //   |/
        //   +------------------------>X
        //NorthWestUp [i,j+1,k+1], 
        [TestMethod]
        public void WindField_NotReduced_field_NorthWestUp()
        {
            CollectionAssert.AreEqual(target2.Field[1, 1, 1].Nwu.toArray(), new double[] { target2.xyz.values[1, 2, 2, 0], target2.xyz.values[1, 2, 2, 1], target2.xyz.values[1, 2, 2, 2] });
        }
        //NorthEastUp, 
        [TestMethod]
        public void WindField_NotReduced_field_NorthEastUp()
        {
            CollectionAssert.AreEqual(target2.Field[1, 1, 1].Neu.toArray(), new double[] { target2.xyz.values[2, 2, 2, 0], target2.xyz.values[2, 2, 2, 1], target2.xyz.values[2, 2, 2, 2] });
        }
        //SouthWestUp,
        [TestMethod]
        public void WindField_NotReduced_field_SouthWestUp()
        {
            CollectionAssert.AreEqual(target2.Field[1, 1, 1].Swu.toArray(), new double[] { target2.xyz.values[1, 1, 2, 0], target2.xyz.values[1, 1, 2, 1], target2.xyz.values[1, 1, 2, 2] });
        }
        //SouthEastUp,
        [TestMethod]
        public void WindField_NotReduced_field_SouthEastUp()
        {
            CollectionAssert.AreEqual(target2.Field[1, 1, 1].Seu.toArray(), new double[] { target2.xyz.values[2, 1, 2, 0], target2.xyz.values[2, 1, 2, 1], target2.xyz.values[2, 1, 2, 2] });
        }
        //NorthWestLow,
        [TestMethod]
        public void WindField_NotReduced_field_NorthWestLow()
        {
            CollectionAssert.AreEqual(target2.Field[1, 1, 1].Nwl.toArray(), new double[] { target2.xyz.values[1, 2, 1, 0], target2.xyz.values[1, 2, 1, 1], target2.xyz.values[1, 2, 1, 2] });
        }
        //NorthEastLow,
        [TestMethod]
        public void WindField_NotReduced_field_NorthEastLow()
        {
            CollectionAssert.AreEqual(target2.Field[1, 1, 1].Nel.toArray(), new double[] { target2.xyz.values[2, 2, 1, 0], target2.xyz.values[2, 2, 1, 1], target2.xyz.values[2, 2, 1, 2] });
        }
        //SouthWestLow,
        [TestMethod]
        public void WindField_NotReduced_field_SouthWestLow()
        {
            CollectionAssert.AreEqual(target2.Field[1, 1, 1].Swl.toArray(), new double[] { target2.xyz.values[1, 1, 1, 0], target2.xyz.values[1, 1, 1, 1], target2.xyz.values[1, 1, 1, 2] });
        }
        //SouthEastLow, 
        [TestMethod]
        public void WindField_NotReduced_field_SouthEastLow()
        {
            CollectionAssert.AreEqual(target2.Field[1, 1, 1].Sel.toArray(), new double[] { target2.xyz.values[2, 1, 1, 0], target2.xyz.values[2, 1, 1, 1], target2.xyz.values[2, 1, 1, 2] });
        }
        //SouthEastLow, 
        [TestMethod]
        public void WindField_NotReduced_field_LowerCenterXY_X()
        {
            int[] CellIndex = target2.LowerCenterXY(500,300);
            int i = CellIndex[0];
            int j = CellIndex[1];
            Assert.IsTrue(target2.Field[i, j, 0].Cen.X <= 500 && target2.Field[i+1, j, 0].Cen.X >= 500);
        }

        [TestMethod]
        public void WindField_NotReduced_field_LowerCenterXY_Y()
        {
            int[] CellIndex = target2.LowerCenterXY(500, 300);
            int i = CellIndex[0];
            int j = CellIndex[1];
            Assert.IsTrue(target2.Field[i, j, 0].Cen.Y <= 300 && target2.Field[i, j+1, 0].Cen.Y >= 300);
        }

        [TestMethod]
        public void WindField_NotReduced_field_LowerCenterZ()
        {
            int CellIndex = target2.LowerCenterZ(49, 2, 100);
            Assert.IsTrue(target2.Field[49, 2, CellIndex].Cen.Z <= 100 && target2.Field[49, 2, CellIndex+1].Cen.Z >= 100);
        } 

        [TestMethod]
        public void WindField_lowerSurfaceInterpolation()
        {
            XYZObject point1 = new XYZObject(0, 0, 1);
            XYZObject point2 = new XYZObject(1, 0, 12.5);
            XYZObject point3 = new XYZObject(0, 1, 12.5);
            XYZObject point4 = new XYZObject(1, 1, 2.5);
            double x = 0.5;
            double y = 0.5;
            double[][] arrayOfPoints = new double[4][];
            arrayOfPoints[0] = point1.toArray();
            arrayOfPoints[1] = point2.toArray();
            arrayOfPoints[2] = point3.toArray();
            arrayOfPoints[3] = point4.toArray();
            WindFieldCell cell = new WindFieldCell(1, 1, 1, 1, 1, 1);
            cell.AddPoint(WindFieldCell.PointPosition.SouthWestLow, point1);
            cell.AddPoint(WindFieldCell.PointPosition.SouthEastLow, point2);
            cell.AddPoint(WindFieldCell.PointPosition.NorthWestLow, point3);
            cell.AddPoint(WindFieldCell.PointPosition.NorthEastLow, point4);
            double expectedResult = MyMath.FirstOrderTrendSurface(x, y, arrayOfPoints);
            Assert.AreEqual(expectedResult,cell.lowerSurfaceInterpolation(x,y));
        }


        
        [TestMethod]
        public void WindField_contain_true()
        {
            XYZObject point1 = new XYZObject(0, 0, 1);
            XYZObject point2 = new XYZObject(1, 0, 12.5);
            XYZObject point3 = new XYZObject(0, 1, 12.5);
            XYZObject point4 = new XYZObject(1, 1, 2.5);
            //double[][] arrayOfPoints = new double[4][];
            //arrayOfPoints[0] = point1.toArray();
            //arrayOfPoints[1] = point2.toArray();
            //arrayOfPoints[2] = point3.toArray();
            //arrayOfPoints[3] = point4.toArray();
            WindFieldCell cell = new WindFieldCell(1, 1, 1, 1, 1, 1);
            cell.AddPoint(WindFieldCell.PointPosition.SouthWestLow, point1);
            cell.AddPoint(WindFieldCell.PointPosition.SouthEastLow, point2);
            cell.AddPoint(WindFieldCell.PointPosition.NorthWestLow, point3);
            cell.AddPoint(WindFieldCell.PointPosition.NorthEastLow, point4);
            //double expectedResult = MyMath.FirstOrderTrendSurface(x, y, arrayOfPoints);
            Assert.IsTrue(cell.contains(0.5, 0.5));
        }

        [TestMethod]
        public void WindField_contain_false()
        {
            XYZObject point1 = new XYZObject(0, 0, 1);
            XYZObject point2 = new XYZObject(1, 0, 12.5);
            XYZObject point3 = new XYZObject(0, 1, 12.5);
            XYZObject point4 = new XYZObject(1, 1, 2.5);
            //double[][] arrayOfPoints = new double[4][];
            //arrayOfPoints[0] = point1.toArray();
            //arrayOfPoints[1] = point2.toArray();
            //arrayOfPoints[2] = point3.toArray();
            //arrayOfPoints[3] = point4.toArray();
            WindFieldCell cell = new WindFieldCell(1, 1, 1, 1, 1, 1);
            cell.AddPoint(WindFieldCell.PointPosition.SouthWestLow, point1);
            cell.AddPoint(WindFieldCell.PointPosition.SouthEastLow, point2);
            cell.AddPoint(WindFieldCell.PointPosition.NorthWestLow, point3);
            cell.AddPoint(WindFieldCell.PointPosition.NorthEastLow, point4);
            //double expectedResult = MyMath.FirstOrderTrendSurface(x, y, arrayOfPoints);
            Assert.IsFalse(cell.contains(1.5, 0.5));
        }


        [TestMethod]
        [DeploymentItem("TestFiles\\test_absolute_height", "test_absolute_height")] 
        public void WindField_test_that_xyz_has_absolute_height()
        {
        string ab_dir_name = "test_absolute_height";
        DirectoryInfo ab_projectdir = new DirectoryInfo(ab_dir_name);
        string ab_filepath = ab_projectdir.FullName + "\\test_absolute_height.ws";
        FileInfo ab_project_file = new FileInfo(ab_filepath);
        //string ab_phi_file270_path = ab_projectdir.FullName + "\\windfield\\270_red.phi";
        //string ab_xyz_file270_path = ab_projectdir.FullName + "\\windfield\\270_red.xyz";
        //string ab_phi_file_zipped = ab_projectdir.FullName + "\\windfield\\270.phi.Z";
        WSProject ab_reference_project = new WSProject(ab_project_file.FullName);
        WindField ab_target =new WindField(ab_reference_project, 270,PhiFileType.notReduced);
        //WindField ab_target2 = new WindField(ab_reference_project, 270, PhiFileType.reduced);
        //Assert.AreEqual(12.0, ab_target.Field[0,0,0].Nwl.Z);
        int x = ab_target.Field.GetLength(0);
        int y = ab_target.Field.GetLength(1);
        Assert.AreEqual(12.0, ab_target.Field[MyMath.RandomNumber(0, x - 1), MyMath.RandomNumber(0, y - 1), 0].Swl.Z);
        }


    }
}
