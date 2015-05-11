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

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProjectTest and is intended
    ///to contain all ProjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectTest
    {


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


        /// <summary>
        ///A test for Project Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectConstructorTest()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            Project target = new Project(file_path);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for run_default
        ///</summary>
        [TestMethod()]
        public void run_defaultTest()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            Project target = new Project(file_path); // TODO: Initialize to an appropriate value
            string core_path = string.Empty; // TODO: Initialize to an appropriate value
            string layout_path = string.Empty; // TODO: Initialize to an appropriate value
            string environment_path = string.Empty; // TODO: Initialize to an appropriate value
            int module = 0; // TODO: Initialize to an appropriate value
            target.run_default(core_path, layout_path, environment_path, module);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for save_to_file
        ///</summary>
        [TestMethod()]
        public void save_to_fileTest()
        {
            string file_path = string.Empty; // TODO: Initialize to an appropriate value
            Project target = new Project(file_path); // TODO: Initialize to an appropriate value
            string file_path1 = string.Empty; // TODO: Initialize to an appropriate value
            target.save_to_file(file_path1);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
