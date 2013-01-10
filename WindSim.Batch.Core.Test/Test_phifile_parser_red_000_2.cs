using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace WindSim.Batch.Core.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\000_red_2.phi")]
    public class Test_phifile_parser_red_000_2
    {
        static string fileName = "000_red_2.phi";
        public PhiFile target = new PhiFile(fileName);
        public Test_phifile_parser_red_000_2()
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
        public void FindResourcefile_Test()
        {
            Assert.IsTrue(System.IO.File.Exists(fileName));
        }


        #region line 2: CARTES, ONEPHS, BFC, XCYCLE, CCM, LCMPRS ( ie. 6 logicals ). (format 1X,6L1)
        //public bool cartes, onephs, bfc, xcycle, ccm, lcmprs;
        [TestMethod]
        public void test_phi_cartes()
        {
            Assert.AreEqual(true, target.cartes);
        }

        [TestMethod]
        public void test_phi_onephs()
        {
            Assert.AreEqual(true, target.onephs);
        }

        [TestMethod]
        public void test_phi_bfc()
        {
            Assert.AreEqual(true, target.bfc);
        }

        [TestMethod]
        public void test_phi_xcycle()
        {
            Assert.AreEqual(false, target.xcycle);
        }

        [TestMethod]
        public void test_phi_ccm()
        {
            Assert.AreEqual(false, target.ccm);
        }

        [TestMethod]
        public void test_phi_lcmprs()
        {
            Assert.AreEqual(false, target.lcmprs);
        }
        #endregion


        #region line 3: NX,NY,NZ,NPHI,DEN1,DEN2,EPOR,NPOR,HPOR,VPOR,LENREC,NUMBLK, nmatst,   nfmak1;
        //public int nx, ny, nz, nphi, den1, den2, epor, npor, hpor, vpor, lenrec, numblk, nmatst, nfmak1;
        //        nx,      ny,         nz,     nphi,    den1,      den2,   epor, 
        //        243       342        11        50        41        -3        43
        //        npor,   hpor,     vpor,    lenrec,   numblk,   nmatst,   nfmak1;
        //          44        45        42       256         0         0    196881

        [TestMethod]
        public void test_phi_nx()
        {
            Assert.AreEqual(243, target.nx);
        }

        [TestMethod]
        public void test_phi_ny()
        {
            Assert.AreEqual(342, target.ny);
        }

        [TestMethod]
        public void test_phi_nz()
        {
            Assert.AreEqual(11, target.nz);
        }

        [TestMethod]
        public void test_phi_nphi()
        {
            Assert.AreEqual(50, target.nphi);
        }

        [TestMethod]
        public void test_phi_den1()
        {
            Assert.AreEqual(41, target.den1);
        }

        [TestMethod]
        public void test_phi_den2()
        {
            Assert.AreEqual(-3, target.den2);
        }

        [TestMethod]
        public void test_phi_epor()
        {
            Assert.AreEqual(43, target.epor);
        }

        [TestMethod]
        public void test_phi_npor()
        {
            Assert.AreEqual(44, target.npor);
        }

        [TestMethod]
        public void test_phi_hpor()
        {
            Assert.AreEqual(45, target.hpor);
        }

        [TestMethod]
        public void test_phi_vpor()
        {
            Assert.AreEqual(42, target.vpor);
        }

        [TestMethod]
        public void test_phi_lenrec()
        {
            Assert.AreEqual(256, target.lenrec);
        }

        [TestMethod]
        public void test_phi_numblk()
        {
            Assert.AreEqual(0, target.numblk);
        }

        [TestMethod]
        public void test_phi_nmatst()
        {
            Assert.AreEqual(0, target.nmatst);
        }

        [TestMethod]
        public void test_phi_nfmak1()
        {
            Assert.AreEqual(196881, target.nfmak1);
        }
        #endregion

        #region line 4: RINNER,FLOAT(NPRPHI),RNFPWV,FLOAT(NFMAK2),RDMAT1,FLOAT(IDMAT2)  (format 1X, 6(1PE13.6))
        //    rinner,      f_nprphi,    rnfPWV,      f_nfmak2,     rdmat1,    f_idmat2;
        // 0.000000E+00 0.000000E+00-1.000000E+01 8.714590E+05 0.000000E+00 0.000000E+00
        [TestMethod]
        public void test_phi_rinner()
        {
            Assert.AreEqual(0.0, target.rinner);
        }
        [TestMethod]
        public void test_phi_f_nprphi()
        {
            Assert.AreEqual(0.0, target.f_nprphi);
        }
        [TestMethod]
        public void test_phi_f_rnfPWV()
        {
            Assert.AreEqual(-10.0, target.rnfPWV);
        }
        [TestMethod]
        public void test_phi_f_nfmak2()
        {
            Assert.AreEqual(871459.0, target.f_nfmak2);
        }
        [TestMethod]
        public void test_phi_rdmat1()
        {
            Assert.AreEqual(0.0, target.rdmat1);
        }
        [TestMethod]
        public void test_phi_f_idmat2()
        {
            Assert.AreEqual(0.0, target.f_idmat2);
        }
        #endregion

        #region line 5: (NAME(I),I=1,NPHI) (format 1X, 19A4).
        //P1  P2  U1  nul V1  nul W1  nul R1  R2  nul KE  EP  nul nul nul nul nul nul 
        //nul nul nul nul nul nul nul nul nul nul nul nul nul nul EPKEGR  WADDTREFYCEN
        //XCENZCENRHO1VPOREPORNPORHPORROUGENUTWCRTVCRTUCRT
        // three lines? i should check if there are phifiles with more than three lines of it! --- CHeck with Bele
        //public string[] variables_name;
        [TestMethod]
        public void test_phi_all_variables_name()
        {
            Array variables_name_data = new[] { "P1", "P2", "U1", "nul", "V1", "nul", "W1", "nul", "R1", "R2", "nul", "KE", "EP", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "EPKE", "GR", "WADD", "TREF", "YCEN", "XCEN", "ZCEN", "RHO1", "VPOR", "EPOR", "NPOR", "HPOR", "ROUG", "ENUT", "WCRT", "VCRT", "UCRT" };
            Array actual = target.all_variables_name;
            CollectionAssert.AreEqual(variables_name_data, actual);
        }

        [TestMethod]
        public void test_phi_variables_name()
        {
            // TFFFFFFFFFFTTFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFTTT
            Array variables_name_data = new[] { "P1", "KE", "EP", "WCRT", "VCRT", "UCRT" };
            Array actual = target.variables_name;
            CollectionAssert.AreEqual(variables_name_data, actual);

        }
        #endregion

        #region line 6: x locations of east cell faces ( ie. NX reals, 1X,format 6(1PE13.6) ).
        //double[] x_east_cell_face;
        [TestMethod]
        public void test_phi_x_east_cell_face_first()
        {
            //4.115226E-03 8.230452E-03 1.234568E-02 1.646090E-02 2.057613E-02 2.469136E-02
            Assert.AreEqual(0.004115226, target.x_east_cell_face[0]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_second()
        {
            //4.115226E-03 8.230452E-03 1.234568E-02 1.646090E-02 2.057613E-02 2.469136E-02
            Assert.AreEqual(0.008230452, target.x_east_cell_face[1]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_last_in_row()
        {
            //4.115226E-03 8.230452E-03 1.234568E-02 1.646090E-02 2.057613E-02 2.469136E-02
            Assert.AreEqual(0.02469136, target.x_east_cell_face[5]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_first_in_second_row()
        {
            // 2.880658E-02 3.292181E-02 3.703704E-02 4.115226E-02 4.526749E-02 4.938272E-02
            Assert.AreEqual(0.02880658, target.x_east_cell_face[6]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_last_in_second_row()
        {
            // 2.880658E-02 3.292181E-02 3.703704E-02 4.115226E-02 4.526749E-02 4.938272E-02
            Assert.AreEqual(0.04938272, target.x_east_cell_face[11]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_last()
        {
            // 9.917696E-01 9.958848E-01 1.000000E+00
            Assert.AreEqual(1.0, target.x_east_cell_face[target.nx-1]);
        }
        #endregion

        #region line : y locations of north cell faces ( ie. NY reals , 1X, format 6(1PE13.6)).
        //public double[] y_north_cell_face;
        [TestMethod]
        public void test_phi_y_north_cell_first()
        {
            //2.923977E-03 5.847953E-03 8.771930E-03 1.169591E-02 1.461988E-02 1.754386E-02
            //2.046784E-02 2.339181E-02 2.631579E-02 2.923977E-02 3.216374E-02 3.508772E-02
            //.....
            Assert.AreEqual(0.002923977, target.y_north_cell_face[0]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_second()
        {
            //2.923977E-03 5.847953E-03 8.771930E-03 1.169591E-02 1.461988E-02 1.754386E-02
            //2.046784E-02 2.339181E-02 2.631579E-02 2.923977E-02 3.216374E-02 3.508772E-02
            //.....
            Assert.AreEqual(0.005847953, target.y_north_cell_face[1]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_first_second_row()
        {
            //2.923977E-03 5.847953E-03 8.771930E-03 1.169591E-02 1.461988E-02 1.754386E-02
            //2.046784E-02 2.339181E-02 2.631579E-02 2.923977E-02 3.216374E-02 3.508772E-02
            //.....
            Assert.AreEqual(0.02046784, target.y_north_cell_face[6]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_second_last()
        {
        //.....
        //9.678363E-01 9.707602E-01 9.736842E-01 9.766082E-01 9.795322E-01 9.824561E-01
        //9.853801E-01 9.883041E-01 9.912280E-01 9.941521E-01 9.970760E-01 1.000000E+00
            Assert.AreEqual(0.9970760, target.y_north_cell_face[target.y_north_cell_face.Count() - 2]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_last()
        {
            //.....
            //9.678363E-01 9.707602E-01 9.736842E-01 9.766082E-01 9.795322E-01 9.824561E-01
            //9.853801E-01 9.883041E-01 9.912280E-01 9.941521E-01 9.970760E-01 1.000000E+00
            Assert.AreEqual(1.0, target.y_north_cell_face[target.y_north_cell_face.Count() - 1]);
        }
        #endregion

        #region line : z locations of high cell faces ( ie. NZ reals, 1X, format 6(1PE13.6) ).
        //public double[] z_high_cell_face;
        [TestMethod]
        public void test_phi_z_high_cell_face_first()
        {
            //5.000000E-02 1.000000E-01 1.500000E-01 2.000000E-01 2.500000E-01 3.000000E-01
            //3.500000E-01 4.000000E-01 4.500000E-01 5.000000E-01 5.500000E-01
            Assert.AreEqual(0.05000000, target.z_high_cell_face[0]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_second()
        {
            //5.000000E-02 1.000000E-01 1.500000E-01 2.000000E-01 2.500000E-01 3.000000E-01
            //3.500000E-01 4.000000E-01 4.500000E-01 5.000000E-01 5.500000E-01
            Assert.AreEqual(0.1, target.z_high_cell_face[1]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_first_second_row()
        {
            //5.000000E-02 1.000000E-01 1.500000E-01 2.000000E-01 2.500000E-01 3.000000E-01
            //3.500000E-01 4.000000E-01 4.500000E-01 5.000000E-01 5.500000E-01
            Assert.AreEqual(0.35, target.z_high_cell_face[6]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_second_last()
        {
            //5.000000E-02 1.000000E-01 1.500000E-01 2.000000E-01 2.500000E-01 3.000000E-01
            //3.500000E-01 4.000000E-01 4.500000E-01 5.000000E-01 5.500000E-01
            Assert.AreEqual(0.5, target.z_high_cell_face[target.z_high_cell_face.Count() - 2]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_last()
        {
            //5.000000E-02 1.000000E-01 1.500000E-01 2.000000E-01 2.500000E-01 3.000000E-01
            //3.500000E-01 4.000000E-01 4.500000E-01 5.000000E-01 5.500000E-01
            Assert.AreEqual(0.55, target.z_high_cell_face[target.z_high_cell_face.Count() - 1]);
        }
        #endregion

        #region line 9: mean pressure corrections at each slab ( ie. NZ reals, format 1X, 6(1PE13.6) ).
        //public double[] slab_mean_pressure_correction;
        //5.000000E-02 1.000000E-01 1.500000E-01 2.000000E-01 2.500000E-01 3.000000E-01
        //3.500000E-01 4.000000E-01 4.500000E-01 5.000000E-01 5.500000E-01
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_first()
        {
            Assert.AreEqual(0.05, target.slab_mean_pressure_correction[0]);
        }
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_second()
        {
            Assert.AreEqual(0.1, target.slab_mean_pressure_correction[1]);
        }
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_first_second_row()
        {
            Assert.AreEqual(0.35, target.slab_mean_pressure_correction[6]);
        }
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_second_last()
        {
            Assert.AreEqual(0.5, target.slab_mean_pressure_correction[target.slab_mean_pressure_correction.Count() - 2]);
        }
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_face_last()
        {
            Assert.AreEqual(0.55, target.z_high_cell_face[target.slab_mean_pressure_correction.Count() - 1]);
        }
        #endregion

        #region line 10: (STORE(I),I=1,NPHI) ( ie. NPHI logicals indicating which of the NPHI possible ones are stored in the file, format 1X, 79L1).
        // public double[, , ,] vars_phi;
        // vars_phi[nx_index, ny_index, nz_index, var_index]
        // {  "0",  "1",  "2",    "3",    "4",    "5" }
        // { "P1", "KE", "EP", "WCRT", "VCRT", "UCRT" };
        // testing the four corner and a random position into each array of stored values
        // test data have been taken using Phoenix Reader Software

        #region  Testing "P1"
        [TestMethod]
        public void test_phi_var_values_0_first_corner_z0()
        {
            Assert.AreEqual(-0.003129839, target.vars_phi[0, 0, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_second_corner_z0()
        {
            Assert.AreEqual(0.007895137, target.vars_phi[target.nx - 1, 0, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_third_corner_z0()
        {
            Assert.AreEqual(4.998838, target.vars_phi[0, target.ny - 1, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_fourth_corner_z0()
        {
            Assert.AreEqual(11.10286, target.vars_phi[target.nx - 1, target.ny - 1, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_first_corner_nz()
        {
            Assert.AreEqual(0.008118187, target.vars_phi[0, 0, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_second_corner_nz()
        {
            Assert.AreEqual(0.007940828, target.vars_phi[target.nx - 1, 0, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_third_corner_nz()
        {
            Assert.AreEqual(2.392802, target.vars_phi[0, target.ny - 1, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_fourth_corner_nz()
        {
            Assert.AreEqual(5.313346, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_rand()
        {
            Assert.AreEqual(0.1812799, target.vars_phi[109, 99, 8, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_rand2()
        {
            Assert.AreEqual(1.385817, target.vars_phi[232, 309, 1, 0]);
        }
        #endregion

        #region Testing "KE"
        [TestMethod]
        public void test_phi_var_values_1_first_corner_z0()
        {
            Assert.AreEqual(0.04479509, target.vars_phi[0, 0, 0, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_second_corner_z0()
        {
            Assert.AreEqual(0.04340811, target.vars_phi[target.nx - 1, 0, 0, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_third_corner_z0()
        {
            Assert.AreEqual(0.1983655, target.vars_phi[0, target.ny - 1, 0, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_fourth_corner_z0()
        {
            Assert.AreEqual(0.7099546, target.vars_phi[target.nx - 1, target.ny - 1, 0, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_first_corner_nz()
        {
            Assert.AreEqual(0.5881938, target.vars_phi[0, 0, target.nz - 1, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_second_corner_nz()
        {
            Assert.AreEqual(0.5156872, target.vars_phi[target.nx - 1, 0, target.nz - 1, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_third_corner_nz()
        {
            Assert.AreEqual(0.05379503, target.vars_phi[0, target.ny - 1, target.nz - 1, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_fourth_corner_nz()
        {
            Assert.AreEqual(0.02203434, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_rand1()
        {
            Assert.AreEqual(0.4390517, target.vars_phi[11, 299, 2, 1]);
        }
        public void test_phi_var_values_1_rand2()
        {
            Assert.AreEqual(0.5604756, target.vars_phi[149, 9, 7, 1]);
        }
        #endregion

        #region Testing "UCRT"
        [TestMethod]
        public void test_phi_var_values_5_first_corner_z0()
        {
            Assert.AreEqual(0.09140025, target.vars_phi[0, 0, 0, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_second_corner_z0()
        {
            Assert.AreEqual(0.07505618, target.vars_phi[target.nx - 1, 0, 0, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_third_corner_z0()
        {
            Assert.AreEqual(-0.1144520, target.vars_phi[0, target.ny - 1, 0, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_fourth_corner_z0()
        {
            Assert.AreEqual(-0.1449594, target.vars_phi[target.nx - 1, target.ny - 1, 0, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_first_corner_nz()
        {
            Assert.AreEqual(0.1278558, target.vars_phi[0, 0, target.nz - 1, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_second_corner_nz()
        {
            Assert.AreEqual(0.05918280, target.vars_phi[target.nx - 1, 0, target.nz - 1, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_third_corner_nz()
        {
            Assert.AreEqual(-0.009009102, target.vars_phi[0, target.ny - 1, target.nz - 1, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_fourth_corner_nz()
        {
            Assert.AreEqual(-0.04824149, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_rand()
        {
            Assert.AreEqual(0.1275028, target.vars_phi[100, 45, 4, 5]);
        }

        [TestMethod]
        public void test_phi_var_values_5_rand_value()
        {
            Assert.AreEqual(0.1275028, target.value(PhiFileDataType.Ucrt,100, 45, 4));
        }
        #endregion 

        #endregion


    }
}
