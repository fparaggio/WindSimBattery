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
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\000_red.phi")]
    public class Test_phifile_parser_red_000
    {
        static string fileName = "000_red.phi";
        public PhiFile target = new PhiFile(fileName);

        public Test_phifile_parser_red_000()
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
        //       600        10        50        50        41        -3        43
        //        npor,   hpor,     vpor,    lenrec,   numblk,   nmatst,   nfmak1;
        //        44        45        42       256         0         0      1249

        [TestMethod]
        public void test_phi_nx()
        {
            Assert.AreEqual(600, target.nx);
        }

        [TestMethod]
        public void test_phi_ny()
        {
            Assert.AreEqual(10, target.ny);
        }

        [TestMethod]
        public void test_phi_nz()
        {
            Assert.AreEqual(50, target.nz);
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
            Assert.AreEqual(1249, target.nfmak1);
        }
        #endregion

        #region line 4: RINNER,FLOAT(NPRPHI),RNFPWV,FLOAT(NFMAK2),RDMAT1,FLOAT(IDMAT2)  (format 1X, 6(1PE13.6))
        //    rinner,      f_nprphi,    rnfPWV,      f_nfmak2,     rdmat1,    f_idmat2;
        // 0.000000E+00 0.000000E+00-9.000000E+00 1.152580E+05 0.000000E+00 0.000000E+00
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
            Assert.AreEqual(-9.0, target.rnfPWV);
        }
        [TestMethod]
        public void test_phi_f_nfmak2()
        {
            Assert.AreEqual(115258.0, target.f_nfmak2);
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
        //nul nul nul nul nul nul nul nul nul nul nul nul nul nul nul GR  WADDTREFYCEN
        //XCENZCENRHO1VPOREPORNPORHPORROUGENUTWCRTVCRTUCRT
        // three lines? i should check if there are phifiles with more than three lines of it!
        //public string[] variables_name;
        [TestMethod]
        public void test_phi_all_variables_name()
        {
            Array variables_name_data = new []{"P1","P2",  "U1",  "nul", "V1",  "nul", "W1",  "nul", "R1",  "R2",  "nul", "KE",  "EP",  "nul", "nul", "nul", "nul", "nul", "nul", "nul" ,"nul" ,"nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "GR",  "WADD","TREF","YCEN", "XCEN","ZCEN","RHO1","VPOR","EPOR","NPOR","HPOR","ROUG","ENUT","WCRT","VCRT","UCRT"};
            Array actual = target.all_variables_name;
            CollectionAssert.AreEqual(variables_name_data,actual);
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
            //double[] variables_name_data = new[] { 0.001666667, 0.003333333, 0.005000000, 0.006666667, 0.008333334, 0.01000000 };
            Assert.AreEqual(0.001666667, target.x_east_cell_face[0]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_second()
        {
            //double[] variables_name_data = new[] { 0.001666667, 0.003333333, 0.005000000, 0.006666667, 0.008333334, 0.01000000 };
            Assert.AreEqual(0.003333333, target.x_east_cell_face[1]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_last_in_row()
        {
            //double[] variables_name_data = new[] { 0.001666667, 0.003333333, 0.005000000, 0.006666667, 0.008333334, 0.01000000 };
            Assert.AreEqual(0.01000000, target.x_east_cell_face[5]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_first_in_second_row()
        {
            // 1.166667E-02 1.333333E-02 1.500000E-02 1.666667E-02 1.833333E-02 2.000000E-02
            Assert.AreEqual(0.01166667, target.x_east_cell_face[6]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_last_in_second_row()
        {
            // 1.166667E-02 1.333333E-02 1.500000E-02 1.666667E-02 1.833333E-02 2.000000E-02
            Assert.AreEqual(0.02000000, target.x_east_cell_face[11]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_last()
        {
            // 9.916667E-01 9.933333E-01 9.950000E-01 9.966667E-01 9.983333E-01 1.000000E+00
            Assert.AreEqual(1.0, target.x_east_cell_face[target.nx-1]);
        }
        #endregion 

        #region line : y locations of north cell faces ( ie. NY reals , 1X, format 6(1PE13.6)).
        //public double[] y_north_cell_face;
        [TestMethod]
        public void test_phi_y_north_cell_first()
        {
                //1.000000E-01 2.000000E-01 3.000000E-01 4.000000E-01 5.000000E-01 6.000000E-01
                //7.000000E-01 8.000000E-01 9.000000E-01 1.000000E+00
            Assert.AreEqual(0.1, target.y_north_cell_face[0]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_second()
        {
            //1.000000E-01 2.000000E-01 3.000000E-01 4.000000E-01 5.000000E-01 6.000000E-01
            //7.000000E-01 8.000000E-01 9.000000E-01 1.000000E+00
            Assert.AreEqual(0.2, target.y_north_cell_face[1]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_first_second_row()
        {
            //1.000000E-01 2.000000E-01 3.000000E-01 4.000000E-01 5.000000E-01 6.000000E-01
            //7.000000E-01 8.000000E-01 9.000000E-01 1.000000E+00
            Assert.AreEqual(0.7, target.y_north_cell_face[6]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_second_last()
        {
            //1.000000E-01 2.000000E-01 3.000000E-01 4.000000E-01 5.000000E-01 6.000000E-01
            //7.000000E-01 8.000000E-01 9.000000E-01 1.000000E+00
            Assert.AreEqual(0.9, target.y_north_cell_face[target.y_north_cell_face.Count()-2]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_last()
        {
            //1.000000E-01 2.000000E-01 3.000000E-01 4.000000E-01 5.000000E-01 6.000000E-01
            //7.000000E-01 8.000000E-01 9.000000E-01 1.000000E+00
            Assert.AreEqual(1.0, target.y_north_cell_face[target.y_north_cell_face.Count() - 1]);
        }
        #endregion 

        #region line : z locations of high cell faces ( ie. NZ reals, 1X, format 6(1PE13.6) ).
        //public double[] z_high_cell_face;
        [TestMethod]
        public void test_phi_z_high_cell_face_first()
        {
         //1.666667E-02 3.333334E-02 5.000000E-02 6.666667E-02 8.333334E-02 1.000000E-01
         //1.166667E-01 1.333333E-01 1.500000E-01 1.666667E-01 1.833333E-01 2.000000E-01
            Assert.AreEqual(0.01666667, target.z_high_cell_face[0]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_second()
        {
            //1.666667E-02 3.333334E-02 5.000000E-02 6.666667E-02 8.333334E-02 1.000000E-01
            //1.166667E-01 1.333333E-01 1.500000E-01 1.666667E-01 1.833333E-01 2.000000E-01
            Assert.AreEqual(0.03333334, target.z_high_cell_face[1]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_first_second_row()
        {
            //1.666667E-02 3.333334E-02 5.000000E-02 6.666667E-02 8.333334E-02 1.000000E-01
            //1.166667E-01 1.333333E-01 1.500000E-01 1.666667E-01 1.833333E-01 2.000000E-01
            Assert.AreEqual(0.1166667, target.z_high_cell_face[6]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_second_last()
        {
         //7.166666E-01 7.333333E-01 7.500000E-01 7.666667E-01 7.833334E-01 8.000000E-01
         //8.166667E-01 8.333333E-01
            Assert.AreEqual(0.8166667, target.z_high_cell_face[target.z_high_cell_face.Count() - 2]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_last()
        {
            //7.166666E-01 7.333333E-01 7.500000E-01 7.666667E-01 7.833334E-01 8.000000E-01
            //8.166667E-01 8.333333E-01
            Assert.AreEqual(0.8333333, target.z_high_cell_face[target.z_high_cell_face.Count() - 1]);
        }
        #endregion

        #region line 9: mean pressure corrections at each slab ( ie. NZ reals, format 1X, 6(1PE13.6) ).
        //public double[] slab_mean_pressure_correction;
         //1.666667E-02 3.333334E-02 5.000000E-02 6.666667E-02 8.333334E-02 1.000000E-01
         //1.166667E-01 1.333333E-01 1.500000E-01 1.666667E-01 1.833333E-01 2.000000E-01
         // .................
         //7.166666E-01 7.333333E-01 7.500000E-01 7.666667E-01 7.833334E-01 8.000000E-01
         //8.166667E-01 8.333333E-01
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_first()
        {
            Assert.AreEqual(0.01666667, target.slab_mean_pressure_correction[0]);
        }
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_second()
        {
            Assert.AreEqual(0.03333334, target.slab_mean_pressure_correction[1]);
        }
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_first_second_row()
        {
            Assert.AreEqual(0.1166667, target.slab_mean_pressure_correction[6]);
        }
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_second_last()
        {
            Assert.AreEqual(0.8166667, target.slab_mean_pressure_correction[target.slab_mean_pressure_correction.Count() - 2]);
        }
        [TestMethod]
        public void test_phi_slab_mean_pressure_correction_face_last()
        {
            Assert.AreEqual(0.8333333, target.z_high_cell_face[target.slab_mean_pressure_correction.Count() - 1]);
        }
        #endregion

        #region line 10: (STORE(I),I=1,NPHI) ( ie. NPHI logicals indicating which of the NPHI possible ones are stored in the file, format 1X, 79L1).
        // public double[, , ,] vars_phi;
        // vars_phi[nx_index, ny_index, nz_index, var_index]
        // {  "0",  "1",  "2",    "3",    "4",    "5" }
        // { "P1", "KE", "EP", "WCRT", "VCRT", "UCRT" };
        // testing the four corner and a random position into each array of stored values
        // test data have been taken using Phoenix Reader Software

        //Testing "P1"
        [TestMethod]
        public void test_phi_var_values_0_first_corner_z0()
        {
            Assert.AreEqual(0.002783706, target.vars_phi[0, 0, 0, 0]);
        }

        [TestMethod]
        public void test_phi_var_values_0_first_corner_z0_value()
        {
            Assert.AreEqual(0.002783706, target.value(PhiFileDataType.P1, 0, 0, 0));
        }

        [TestMethod]
        public void test_phi_var_values_0_second_corner_z0()
        {
            Assert.AreEqual(0.002783706, target.vars_phi[target.nx - 1, 0, 0, 0]);
        }
        
        [TestMethod]
        public void test_phi_var_values_0_second_corner_z0_value()
        {
            Assert.AreEqual(0.002783706, target.value(PhiFileDataType.P1,target.nx - 1, 0, 0));
        }

        [TestMethod]
        public void test_phi_var_values_0_third_corner_z0()
        {
            Assert.AreEqual(0.1287082, target.vars_phi[0, target.ny - 1, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_fourth_corner_z0()
        {
            Assert.AreEqual(0.1286893, target.vars_phi[target.nx - 1, target.ny - 1, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_first_corner_nz()
        {
            Assert.AreEqual(0.01125507, target.vars_phi[0, 0, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_second_corner_nz()
        {
            Assert.AreEqual(0.01125507, target.vars_phi[target.nx - 1, 0, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_third_corner_nz()
        {
            Assert.AreEqual(0.04553252, target.vars_phi[0, target.ny - 1, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_fourth_corner_nz()
        {
            Assert.AreEqual(0.04551651, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_rand()
        {
            Assert.AreEqual(0.1287886, target.vars_phi[429, 6, 21, 0]);
        }

        [TestMethod]
        public void test_phi_var_values_0_rand_value()
        {
            Assert.AreEqual(0.1287886, target.value(PhiFileDataType.P1, 429, 6, 21));
        }



        // Testing "KE"
        [TestMethod]
        public void test_phi_var_values_1_first_corner_z0()
        {
            Assert.AreEqual(0.4838448, target.vars_phi[0, 0, 0, 1]);
        }

        [TestMethod]
        public void test_phi_var_values_1_first_corner_z0_value()
        {
            Assert.AreEqual(0.4838448, target.value(PhiFileDataType.Ke,0, 0, 0));
        }

        [TestMethod]
        public void test_phi_var_values_1_second_corner_z0()
        {
            Assert.AreEqual(0.4838446, target.vars_phi[target.nx - 1, 0, 0, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_third_corner_z0()
        {
            Assert.AreEqual(0.4539784, target.vars_phi[0, target.ny - 1, 0, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_fourth_corner_z0()
        {
            Assert.AreEqual(0.4539786, target.vars_phi[target.nx - 1, target.ny - 1, 0, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_first_corner_nz()
        {
            Assert.AreEqual(0.1665777, target.vars_phi[0, 0, target.nz - 1, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_second_corner_nz()
        {
            Assert.AreEqual(0.1665776, target.vars_phi[target.nx - 1, 0, target.nz - 1, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_third_corner_nz()
        {
            Assert.AreEqual(0.1636692, target.vars_phi[0, target.ny - 1, target.nz - 1, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_fourth_corner_nz()
        {
            Assert.AreEqual(0.1636692, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 1]);
        }
        [TestMethod]
        public void test_phi_var_values_1_rand()
        {
            Assert.AreEqual(0.9827104, target.vars_phi[344, 4, 22, 1]);
        }

        [TestMethod]
        public void test_phi_var_values_1_rand_value()
        {
            Assert.AreEqual(0.9827104, target.value(PhiFileDataType.Ke,344, 4, 22));
        }

        // Testing "VCRT"
        [TestMethod]
        public void test_phi_var_values_4_first_corner_z0()
        {
            Assert.AreEqual(-0.6444173, target.vars_phi[0, 0, 0, 4]);
        }
        [TestMethod]
        public void test_phi_var_values_4_second_corner_z0()
        {
            Assert.AreEqual(-0.6444172, target.vars_phi[target.nx - 1, 0, 0, 4]);
        }
        [TestMethod]
        public void test_phi_var_values_4_third_corner_z0()
        {
            Assert.AreEqual(-0.6237223, target.vars_phi[0, target.ny - 1, 0, 4]);
        }
        [TestMethod]
        public void test_phi_var_values_4_fourth_corner_z0()
        {
            Assert.AreEqual(-0.6237224, target.vars_phi[target.nx - 1, target.ny - 1, 0, 4]);
        }
        [TestMethod]
        public void test_phi_var_values_4_first_corner_nz()
        {
            Assert.AreEqual(-9.187802, target.vars_phi[0, 0, target.nz - 1, 4]);
        }
        [TestMethod]
        public void test_phi_var_values_4_second_corner_nz()
        {
            Assert.AreEqual(-9.187800, target.vars_phi[target.nx - 1, 0, target.nz - 1, 4]);
        }
        [TestMethod]
        public void test_phi_var_values_4_third_corner_nz()
        {
            Assert.AreEqual(-9.187381, target.vars_phi[0, target.ny - 1, target.nz - 1, 4]);
        }
        [TestMethod]
        public void test_phi_var_values_4_fourth_corner_nz()
        {
            Assert.AreEqual(-9.187382, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 4]);
        }
        [TestMethod]
        public void test_phi_var_values_4_rand()
        {
            Assert.AreEqual(-7.660147, target.vars_phi[255, 2, 38, 4]);
        }

        [TestMethod]
        public void test_phi_var_values_4_rand_Value()
        {
            Assert.AreEqual(-7.660147, target.value(PhiFileDataType.Vcrt,255, 2, 38));
        }
        #endregion
    }
}

