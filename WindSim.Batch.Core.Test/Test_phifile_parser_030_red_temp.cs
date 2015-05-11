//------------------------------------------------------------------------------
// Copyright (c) 2012, 2013, 2014, 2015 Francesco Paraggio.
// 
// Author: Francesco Paraggio fparaggio@gmail.com
// 
// This file is part of WindSimBattery
// 
// WindSimBattery is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License along with this program. If not, see http://www.gnu.org/licenses/.
// 
// The usage of a range of years within a copyright statement contained within this distribution should be interpreted as being equivalent to a list of years including the first and last year specified and all consecutive years between them. For example, a copyright statement that reads 'Copyright (c) 2005, 2007- 2009, 2011-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2007, 2008, 2009, 2011, 2012' and a copyright statement that reads "Copyright (c) 2005-2012' should be interpreted as being identical to a statement that reads 'Copyright (c) 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012'."
//------------------------------------------------------------------------------

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace WindSim.Batch.Core.Test
{
    /// <summary>
    /// Summary description for Test_030_red_temp
    /// </summary>
    [TestClass]
    [DeploymentItem("TestFiles\\030_red_temp.phi")]
    public class Test_phifile_parser_030_red_temp
    {
        static string fileName = "030_red_temp.phi";
        public PhiFile target = new PhiFile(fileName);
        public Test_phifile_parser_030_red_temp()
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
        //       66        66        11        50        40        -3        42
        //        npor,   hpor,     vpor,    lenrec,   numblk,   nmatst,   nfmak1;
        //        43        44        41       256         0         0      1134

        [TestMethod]
        public void test_phi_nx()
        {
            Assert.AreEqual(66, target.nx);
        }

        [TestMethod]
        public void test_phi_ny()
        {
            Assert.AreEqual(66, target.ny);
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
            Assert.AreEqual(40, target.den1);
        }

        [TestMethod]
        public void test_phi_den2()
        {
            Assert.AreEqual(-3, target.den2);
        }

        [TestMethod]
        public void test_phi_epor()
        {
            Assert.AreEqual(42, target.epor);
        }

        [TestMethod]
        public void test_phi_npor()
        {
            Assert.AreEqual(43, target.npor);
        }

        [TestMethod]
        public void test_phi_hpor()
        {
            Assert.AreEqual(44, target.hpor);
        }

        [TestMethod]
        public void test_phi_vpor()
        {
            Assert.AreEqual(41, target.vpor);
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
            Assert.AreEqual(1134, target.nfmak1);
        }
        #endregion

        #region line 4: RINNER,FLOAT(NPRPHI),RNFPWV,FLOAT(NFMAK2),RDMAT1,FLOAT(IDMAT2)  (format 1X, 6(1PE13.6))
        //    rinner,      f_nprphi,    rnfPWV,      f_nfmak2,     rdmat1,    f_idmat2;
        // 0.000000E+00 0.000000E+00-1.300000E+01 4.563100E+04 0.000000E+00 0.000000E+00
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
            Assert.AreEqual(-13.0, target.rnfPWV);
        }
        [TestMethod]
        public void test_phi_f_nfmak2()
        {
            Assert.AreEqual(45631.00, target.f_nfmak2);
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
        //nul nul nul nul nul nul nul nul nul nul nul nul nul EPKEGR  WADDTREFYCENXCEN
        //ZCENRHO1VPOREPORNPORHPORROUGENUTTEM1WCRTVCRTUCRT
        // three lines? i should check if there are phifiles with more than three lines of it! --- CHeck with Bele
        //public string[] variables_name;

        [TestMethod]
        public void test_phi_all_variables_name()
        {
            //                                  P1      P2   U1     nul   V1    nul    W1    nul    R1    R2    nul    KE    EP    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul    nul   EPKE     GR     WADD  TREF   YCEN    XCEN      ZCEN    RHO1    VPOR    EPOR    NPOR    HPOR    ROUG    ENUT   TEM1     WCRT    VCRT    UCRT
            //                                  T        F    F      F     F     F      F     F      F     F     F     T     T      F      F      F      F      F      F      F      F      F      F      F      F      F      F      F      F      F      F      F     F        F      F     F      F       F         F       F       F       F       F       F        F      F      T        T        T       T
            Array variables_name_data = new[] { "P1", "P2", "U1", "nul", "V1", "nul", "W1", "nul", "R1", "R2", "nul", "KE", "EP", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "nul", "EPKE", "GR", "WADD", "TREF", "YCEN", "XCEN", "ZCEN", "RHO1", "VPOR", "EPOR", "NPOR", "HPOR", "ROUG", "ENUT", "TEM1", "WCRT", "VCRT", "UCRT" };
            Array actual = target.all_variables_name;
            CollectionAssert.AreEqual(variables_name_data, actual);
        }

        [TestMethod]
        public void test_phi_variables_name()
        {
           //  TFFFFFFFFFFTTFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFTTTT
            Array variables_name_data = new[] { "P1", "KE", "EP","TEM1", "WCRT", "VCRT", "UCRT" };
            Array actual = target.variables_name;
            CollectionAssert.AreEqual(variables_name_data, actual);

        }
        #endregion

        #region line 6: x locations of east cell faces ( ie. NX reals, 1X,format 6(1PE13.6) ).
        //double[] x_east_cell_face;
        [TestMethod]
        public void test_phi_x_east_cell_face_first()
        {
            //1.515152E-02 3.030303E-02 4.545455E-02 6.060606E-02 7.575758E-02 9.090909E-02
            //...
            Assert.AreEqual(0.01515152, target.x_east_cell_face[0]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_second()
        {
            //1.515152E-02 3.030303E-02 4.545455E-02 6.060606E-02 7.575758E-02 9.090909E-02
            //...
            Assert.AreEqual(0.03030303, target.x_east_cell_face[1]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_last_in_row()
        {
            //1.515152E-02 3.030303E-02 4.545455E-02 6.060606E-02 7.575758E-02 9.090909E-02
            //...
            Assert.AreEqual(0.09090909, target.x_east_cell_face[5]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_first_in_second_row()
        {
            // 1.515152E-02 3.030303E-02 4.545455E-02 6.060606E-02 7.575758E-02 9.090909E-02
            // 1.060606E-01 1.212121E-01 1.363636E-01 1.515152E-01 1.666667E-01 1.818182E-01
            // ....
            Assert.AreEqual(0.1060606, target.x_east_cell_face[6]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_last_in_second_row()
        {
            // 1.515152E-02 3.030303E-02 4.545455E-02 6.060606E-02 7.575758E-02 9.090909E-02
            // 1.060606E-01 1.212121E-01 1.363636E-01 1.515152E-01 1.666667E-01 1.818182E-01
            // ....
            Assert.AreEqual(0.1818182, target.x_east_cell_face[11]);
        }
        [TestMethod]
        public void test_phi_x_east_cell_second_last()
        {
            // ....
            // 9.242424E-01 9.393939E-01 9.545454E-01 9.696970E-01 9.848485E-01 1.000000E+00
            Assert.AreEqual(0.9848485, target.x_east_cell_face[target.nx - 2]);
        }

        [TestMethod]
        public void test_phi_x_east_cell_last()
        {
            // ....
            // 9.242424E-01 9.393939E-01 9.545454E-01 9.696970E-01 9.848485E-01 1.000000E+00
            Assert.AreEqual(1.0, target.x_east_cell_face[target.nx - 1]);
        }
        #endregion

        #region line : y locations of north cell faces ( ie. NY reals , 1X, format 6(1PE13.6)).
        //public double[] y_north_cell_face;
        //1.515152E-02 3.030303E-02 4.545455E-02 6.060606E-02 7.575758E-02 9.090909E-02
        //1.060606E-01 1.212121E-01 1.363636E-01 1.515152E-01 1.666667E-01 1.818182E-01
        //........
        //9.242424E-01 9.393939E-01 9.545454E-01 9.696970E-01 9.848485E-01 1.000000E+00
        [TestMethod]
        public void test_phi_y_north_cell_first()
        {
            Assert.AreEqual(0.01515152, target.y_north_cell_face[0]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_second()
        {
            Assert.AreEqual(0.03030303, target.y_north_cell_face[1]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_first_second_row()
        {
            Assert.AreEqual(0.1060606, target.y_north_cell_face[6]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_second_last()
        {

            Assert.AreEqual(0.9848485, target.y_north_cell_face[target.y_north_cell_face.Count() - 2]);
        }
        [TestMethod]
        public void test_phi_y_north_cell_last()
        {
            Assert.AreEqual(1.0, target.y_north_cell_face[target.y_north_cell_face.Count() - 1]);
        }
        #endregion

        #region line : z locations of high cell faces ( ie. NZ reals, 1X, format 6(1PE13.6) ).
        //public double[] z_high_cell_face;
        //5.000000E-02 1.000000E-01 1.500000E-01 2.000000E-01 2.500000E-01 3.000000E-01
        //3.500000E-01 4.000000E-01 4.500000E-01 5.000000E-01 5.500000E-01
        [TestMethod]
        public void test_phi_z_high_cell_face_first()
        {
            Assert.AreEqual(0.05, target.z_high_cell_face[0]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_second()
        {
            Assert.AreEqual(0.1, target.z_high_cell_face[1]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_first_second_row()
        {
            Assert.AreEqual(0.3500000, target.z_high_cell_face[6]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_second_last()
        {
            Assert.AreEqual(0.5, target.z_high_cell_face[target.z_high_cell_face.Count() - 2]);
        }
        [TestMethod]
        public void test_phi_z_high_cell_face_last()
        {
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
        // {  "0",  "1",  "2", "3",    "4",    "5" ,    "6" }
        // { "P1", "KE", "EP","TEM1", "WCRT", "VCRT", "UCRT" };
        // testing the four corner and a random position into each array of stored values
        // test data have been taken using Phoenix Reader Software

        #region  Testing "P1"
        [TestMethod]
        public void test_phi_var_values_0_first_corner_z0()
        {
            Assert.AreEqual(-0.0007547156, target.vars_phi[0, 0, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_second_corner_z0()
        {
            Assert.AreEqual(0.002550554, target.vars_phi[target.nx - 1, 0, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_third_corner_z0()
        {
            Assert.AreEqual(0.001424946, target.vars_phi[0, target.ny - 1, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_fourth_corner_z0()
        {
            Assert.AreEqual(-2.241246, target.vars_phi[target.nx - 1, target.ny - 1, 0, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_first_corner_nz()
        {
            Assert.AreEqual(0.005083670, target.vars_phi[0, 0, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_second_corner_nz()
        {
            Assert.AreEqual(0.007237458, target.vars_phi[target.nx - 1, 0, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_third_corner_nz()
        {
            Assert.AreEqual(0.004284483, target.vars_phi[0, target.ny - 1, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_fourth_corner_nz()
        {
            Assert.AreEqual(-2.508730, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_rand()
        {
            Assert.AreEqual(-0.3677424, target.vars_phi[9, 29, 2, 0]);
        }
        [TestMethod]
        public void test_phi_var_values_0_rand2()
        {
            Assert.AreEqual(0.6341587, target.vars_phi[21, 21, 4, 0]);
        }
        #endregion

        #region Testing "TEM1"
        [TestMethod]
        public void test_phi_var_values_3_first_corner_z0()
        {
            Assert.AreEqual(288.0057, target.vars_phi[0, 0, 0, 3]);
        }
        [TestMethod]
        public void test_phi_var_values_3_second_corner_z0()
        {
            Assert.AreEqual(288.0178, target.vars_phi[target.nx - 1, 0, 0, 3]);
        }
        [TestMethod]
        public void test_phi_var_values_3_third_corner_z0()
        {
            Assert.AreEqual(288.0056, target.vars_phi[0, target.ny - 1, 0, 3]);
        }
        [TestMethod]
        public void test_phi_var_values_3_fourth_corner_z0()
        {
            Assert.AreEqual(288.1180, target.vars_phi[target.nx - 1, target.ny - 1, 0, 3]);
        }
        [TestMethod]
        public void test_phi_var_values_3_first_corner_nz()
        {
            Assert.AreEqual(288.3834, target.vars_phi[0, 0, target.nz - 1, 3]);
        }
        [TestMethod]
        public void test_phi_var_values_3_second_corner_nz()
        {
            Assert.AreEqual(288.3903, target.vars_phi[target.nx - 1, 0, target.nz - 1, 3]);
        }
        [TestMethod]
        public void test_phi_var_values_3_third_corner_nz()
        {
            Assert.AreEqual(288.3818, target.vars_phi[0, target.ny - 1, target.nz - 1, 3]);
        }
        [TestMethod]
        public void test_phi_var_values_3_fourth_corner_nz()
        {
            Assert.AreEqual(288.4596, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 3]);
        }
        [TestMethod]
        public void test_phi_var_values_3_rand1()
        {
            Assert.AreEqual(288.0816, target.vars_phi[9, 29, 2, 3]);
        }
        [TestMethod]
        public void test_phi_var_values_3_rand2()
        {
            Assert.AreEqual(288.2223, target.vars_phi[21, 21, 4, 3]);
        }

        [TestMethod]
        public void test_phi_var_values_3_rand2_value()
        {
            Assert.AreEqual(288.2223, target.value(PhiFileDataType.Tem1,21, 21, 4));
        }
        #endregion

        #region Testing "VCRT"
        [TestMethod]
        public void test_phi_var_values_5_first_corner_z0()
        {
            Assert.AreEqual(-0.04162261, target.vars_phi[0, 0, 0, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_second_corner_z0()
        {
            Assert.AreEqual(-1.655442, target.vars_phi[target.nx - 1, 0, 0, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_third_corner_z0()
        {
            Assert.AreEqual(-2.045375, target.vars_phi[0, target.ny - 1, 0, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_fourth_corner_z0()
        {
            Assert.AreEqual(-1.938252, target.vars_phi[target.nx - 1, target.ny - 1, 0, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_first_corner_nz()
        {
            Assert.AreEqual(-5.362649, target.vars_phi[0, 0, target.nz - 1, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_second_corner_nz()
        {
            Assert.AreEqual(-5.834744, target.vars_phi[target.nx - 1, 0, target.nz - 1, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_third_corner_nz()
        {
            Assert.AreEqual(-6.067747, target.vars_phi[0, target.ny - 1, target.nz - 1, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_fourth_corner_nz()
        {
            Assert.AreEqual(-5.690291, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 5]);
        }
        [TestMethod]
        public void test_phi_var_values_5_rand()
        {
            Assert.AreEqual(-2.867275, target.vars_phi[29, 9, 4, 5]);
        }

        public void test_phi_var_values_5_rand_value()
        {
            Assert.AreEqual(-2.867275, target.value(PhiFileDataType.Vcrt,29, 9, 4));
        }
        #endregion

        #region Testing "UCRT"
        [TestMethod]
        public void test_phi_var_values_6_first_corner_z0()
        {
            Assert.AreEqual(-0.04451315, target.vars_phi[0, 0, 0, 6]);
        }
        [TestMethod]
        public void test_phi_var_values_6_second_corner_z0()
        {
            Assert.AreEqual(-1.118945, target.vars_phi[target.nx - 1, 0, 0, 6]);
        }
        [TestMethod]
        public void test_phi_var_values_6_third_corner_z0()
        {
            Assert.AreEqual(-1.162952, target.vars_phi[0, target.ny - 1, 0, 6]);
        }
        [TestMethod]
        public void test_phi_var_values_6_fourth_corner_z0()
        {
            Assert.AreEqual(-1.267319, target.vars_phi[target.nx - 1, target.ny - 1, 0, 6]);
        }
        [TestMethod]
        public void test_phi_var_values_6_first_corner_nz()
        {
            Assert.AreEqual(-2.917156, target.vars_phi[0, 0, target.nz - 1, 6]);
        }
        [TestMethod]
        public void test_phi_var_values_6_second_corner_nz()
        {
            Assert.AreEqual(-3.407043, target.vars_phi[target.nx - 1, 0, target.nz - 1, 6]);
        }
        [TestMethod]
        public void test_phi_var_values_6_third_corner_nz()
        {
            Assert.AreEqual(-3.497323, target.vars_phi[0, target.ny - 1, target.nz - 1, 6]);
        }
        [TestMethod]
        public void test_phi_var_values_6_fourth_corner_nz()
        {
            Assert.AreEqual(-3.307976, target.vars_phi[target.nx - 1, target.ny - 1, target.nz - 1, 6]);
        }
        [TestMethod]
        public void test_phi_var_values_6_rand()
        {
            Assert.AreEqual(-1.987989, target.vars_phi[29, 9, 4, 6]);
        }
        [TestMethod]
        public void test_phi_var_values_6_rand2()
        {
            Assert.AreEqual(-1.197942, target.vars_phi[8, 4, 3, 6]);
        }
        #endregion

        #endregion




 
    }
}
