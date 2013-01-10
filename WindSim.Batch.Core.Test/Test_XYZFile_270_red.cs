﻿using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace WindSim.Batch.Core.Test
{
    
    
    /// <summary>
    ///This is a test class for XYZFileTest and is intended
    ///to contain all XYZFileTest Unit Tests
    ///</summary>
    [TestClass()]
    [DeploymentItem("WindSim.Batch.Core.Test\\TestFiles\\270_red.xyz")]
    public class Test_XYZFile_270_red
    {
        static string fileName = "270_red.xyz";
        public XYZFile file_xyz = new XYZFile(fileName);

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
        public void Test_XYZObject_X()
        {
            XYZObject point = new XYZObject(11, 12, 13);
            Assert.AreEqual(11, point.X);
        }

        [TestMethod]
        public void Test_XYZObject_toArray_x()
        {
            XYZObject point = new XYZObject(11, 12, 13);
            double[] array = point.toArray();
            Assert.AreEqual(11, array[0]);
        }

        [TestMethod]
        public void Test_XYZObject_toArray_y()
        {
            XYZObject point = new XYZObject(11, 12, 13);
            double[] array = point.toArray();
            Assert.AreEqual(12, array[1]);
        }


        [TestMethod]
        public void Test_XYZObject_toArray_z()
        {
            XYZObject point = new XYZObject(11, 12, 13);
            double[] array = point.toArray();
            Assert.AreEqual(13, array[2]);
        }

        [TestMethod]
        public void Test_XYZObject_Y()
        {
            XYZObject point = new XYZObject(11, 12, 13);
            Assert.AreEqual(12, point.Y);
        }

        [TestMethod]
        public void Test_XYZObject_Z()
        {
            XYZObject point = new XYZObject(11, 12, 13);
            Assert.AreEqual(13, point.Z);
        }


        [TestMethod]
        public void Test_xyz_0_FindResourcefile_Test()
        {
            Assert.IsTrue(System.IO.File.Exists(fileName));
        }

        [TestMethod()]
        public void test_xyz_0_ni_length()
        {
            Assert.AreEqual(31,file_xyz.ni);
        }

        [TestMethod()]
        public void test_xyz_0_nj_length()
        {
            Assert.AreEqual(6,file_xyz.nj);
        }

        [TestMethod()]
        public void test_xyz_0_nk_length()
        {
            Assert.AreEqual(7,file_xyz.nk);
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        [TestMethod()]
        public void test_xyz_0_vertical_profile_all()
        {
            int x_ran = 0;//file_xyz.ni - 1;//RandomNumber(0,file_xyz.ni-1);
            int y_ran = 0;// file_xyz.nj - 1;//RandomNumber(0, file_xyz.nj - 1);
            double[] vertical_profile = { file_xyz.values[x_ran, y_ran, 0, 2], file_xyz.values[x_ran, y_ran, 1, 2], file_xyz.values[x_ran, y_ran, 2, 2], file_xyz.values[x_ran, y_ran, 3, 2], file_xyz.values[x_ran, y_ran, 4, 2], file_xyz.values[x_ran, y_ran, 5, 2], file_xyz.values[x_ran, y_ran, 6, 2]};
            int errors = 0;
            for (int i = 0; i < file_xyz.ni; i++)
            {
                for (int j = 0; j < file_xyz.nj; j++)
                {
                    double[] parsed_profile = { file_xyz.values[i, j, 0, 2], file_xyz.values[i, j, 1, 2], file_xyz.values[i, j, 2, 2], file_xyz.values[i, j, 3, 2], file_xyz.values[i, j, 4, 2], file_xyz.values[i, j, 5, 2], file_xyz.values[i, j, 6, 2] };
                    if (!Enumerable.SequenceEqual(vertical_profile, parsed_profile)) errors++;
                    //CollectionAssert.AreEqual(vertical_profile, parsed_profile);
                }
            }
            Assert.AreEqual(0, errors);
        }



        //[TestMethod()]
        //public void test_x_axis_all()
        //{

        //    double[] orizontal_profile = { 0.0, 250.0,500.0,750.0,1000.0,1250.0,1500.0,1750.0,2000.0,2250.0,2500.0,2750.0,3000.0 };
        //    int errors = 0;
        //    for (int j = 0; j < file_xyz.nj; j++)
        //    {
        //        for (int k = 0; k < file_xyz.nk; k++)
        //        {
        //            double[] parsed_orizontal_profile = { file_xyz.values[0, j, k, 0], file_xyz.values[1, j, k, 0], file_xyz.values[2, j, k, 0], file_xyz.values[3, j, k, 0], file_xyz.values[4, j, k, 0], file_xyz.values[5, j, k, 0], file_xyz.values[6, j, k, 0], file_xyz.values[7, j, k, 0], file_xyz.values[8, j, k, 0], file_xyz.values[9, j, k, 0], file_xyz.values[10, j, k, 0], file_xyz.values[11, j, k, 0], file_xyz.values[12, j, k, 0] };
        //            if (!Enumerable.SequenceEqual(orizontal_profile, parsed_orizontal_profile)) errors++;
        //            //CollectionAssert.AreEqual(vertical_profile, parsed_profile);
        //        }
        //    }
        //    Assert.AreEqual(0, errors);
        //}

        [TestMethod()]
        public void test_xyz_0_y_axis_all()
        {

            double[] orizontal_y_profile = { file_xyz.values[0, 0, 0, 1], file_xyz.values[0, 1, 0, 1], file_xyz.values[0, 2, 0, 1], file_xyz.values[0, 3, 0, 1], file_xyz.values[0, 4, 0, 1], file_xyz.values[0, 5, 0, 1] };
            int errors = 0;
            for (int i = 0; i < file_xyz.ni; i++)
            {
                for (int k = 0; k < file_xyz.nk; k++)
                {
                    double[] parsed_orizontal_profile = { file_xyz.values[i, 0, k, 1], file_xyz.values[i, 1, k, 1], file_xyz.values[i, 2, k, 1], file_xyz.values[i, 3, k, 1], file_xyz.values[i, 4, k, 1], file_xyz.values[i, 5, k, 1] };
                    if (!Enumerable.SequenceEqual(orizontal_y_profile, parsed_orizontal_profile)) errors++;
                    //CollectionAssert.AreEqual(vertical_profile, parsed_profile);
                }
            }
            Assert.AreEqual(0, errors);
        }

    }
}
