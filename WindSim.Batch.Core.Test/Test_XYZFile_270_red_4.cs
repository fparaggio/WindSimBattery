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

using ConsoleApplication1;
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
    [DeploymentItem("TestFiles\\270_red_4.xyz")]
    public class Test_XYZFile_270_red_4
    {
        static string fileName = "270_red_4.xyz";
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
        public void test_xyz_4_FindResourcefile_Test()
        {
            Assert.IsTrue(System.IO.File.Exists(fileName));
        }

        [TestMethod()]
        public void test_xyz_4_ni_length()
        {  
            Assert.AreEqual(601,file_xyz.ni);
        }

        [TestMethod()]
        public void test_xyz_4_nj_length()
        {
            Assert.AreEqual(11,file_xyz.nj);
        }

        [TestMethod()]
        public void test_xyz_4_nk_length()
        {
            Assert.AreEqual(5,file_xyz.nk);
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        [TestMethod()]
        public void test_xyz_4_vertical_profile_all()
        {
            int x_ran = RandomNumber(0,file_xyz.ni-1);
            int y_ran = RandomNumber(0, file_xyz.nj - 1);
            double[] vertical_profile = { file_xyz.values[x_ran, y_ran, 0, 2], file_xyz.values[x_ran, y_ran, 1, 2], file_xyz.values[x_ran, y_ran, 2, 2], file_xyz.values[x_ran, y_ran, 3, 2], file_xyz.values[x_ran, y_ran, 4, 2] };
            int errors = 0;
            for (int i = 0; i < file_xyz.ni; i++)
            {
                for (int j = 0; j < file_xyz.nj; j++)
                {
                    double[] parsed_profile = { file_xyz.values[i, j, 0, 2], file_xyz.values[i, j, 1, 2], file_xyz.values[i, j, 2, 2], file_xyz.values[i, j, 3, 2], file_xyz.values[i, j, 4, 2] };
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
        public void test_xyz_4_y_axis_all()
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
