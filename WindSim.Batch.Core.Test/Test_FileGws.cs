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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindSim.Batch.Core;

namespace WindSim.Batch.Core.Test
{
    [TestClass]
    [DeploymentItem("TestFiles\\test.gws")]
    [DeploymentItem("TestFiles\\5x5.gws")]
    [DeploymentItem("TestFiles\\3x3.gws")]
    public class Test_FileGws
    {
        static string gwsFileName = "test.gws";
        static string gws5x5 = "5x5.gws";
        static string gws3x3 = "3x3.gws";

        #region resource files
        [TestMethod]
        public void TestFileGwsFindResourcefile()
        {
            Assert.IsTrue(System.IO.File.Exists(gwsFileName));
        }
        [TestMethod]
        public void TestFileGwsFindResourcefile2()
        {
            Assert.IsTrue(System.IO.File.Exists(gws5x5));
        }
        [TestMethod]
        public void TestFileGwsFindResourcefile3()
        {
            Assert.IsTrue(System.IO.File.Exists(gws3x3));
        }
        #endregion

        #region Parsing height
        [TestMethod]
        public void TestFileGwsParser()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(416.00, gws.data[4, 0].height);
        }
        [TestMethod]
        public void TestFileGwsParser1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(390.00, gws.data[1, 3].height);
        }
        [TestMethod]
        public void TestFileGwsParser2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(373.00, gws.data[0, 3].height);
        }
        [TestMethod]
        public void TestFileGwsParser3()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(430.00, gws.data[10, 3].height);
        }
        #endregion

        #region parsing rough
        [TestMethod]
        public void TestFileGwsParserRough()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(0.01, gws.data[4, 0].rough);
        }
        [TestMethod]
        public void TestFileGwsParserRough1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(0.02, gws.data[1, 3].rough);
        }
        [TestMethod]
        public void TestFileGwsParserRough2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(0.004, gws.data[0, 3].rough);
        }
        [TestMethod]
        public void TestFileGwsParserRough3()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(12.3, gws.data[10, 3].rough);
        }
        #endregion

        #region parsing header
        [TestMethod]
        public void TestFileGwsDimX()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(11, gws.Npx);
        }

        [TestMethod]
        public void TestFileGwsParserDimY()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(4, gws.Npy);
        }

        [TestMethod]
        public void TestFileGwsParserVersion()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual("430", gws.WindsimVersion);
        }

        [TestMethod]
        public void TestFileGwsParserAreaName()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual("demo", gws.AreaName);
        }

        [TestMethod]
        public void TestFileGwsParserCoordSystem()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(3, gws.CoordinateSystem);
        }

        [TestMethod]
        public void TestFileGwsParserXmin()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(1234567.0, gws.xmin);
        }

        [TestMethod]
        public void TestFileGwsParserYmin()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(0.0, gws.ymin);
        }

        [TestMethod]
        public void TestFileGwsParserXmax()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(123456789.0, gws.xmax);
        }

        [TestMethod]
        public void TestFileGwsParserYmax()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(-400.0, gws.ymax);
        }

        #endregion

        #region parsing 5x5
        [TestMethod]
        public void TestFileGwsParser5x5Ymax()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws5x5);
            Assert.AreEqual(500.0, gws.ymax);
        }


        [TestMethod]
        public void TestFileGwsParser5x5Dx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws5x5);
            Assert.AreEqual(125, gws.Dx);
        }

        [TestMethod]
        public void TestFileGwsParser5x5Dy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws5x5);
            Assert.AreEqual(125, gws.Dy);
        }
        
        [TestMethod]
        public void TestFileGwsParser5x5Dxy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws5x5);
            Assert.AreEqual(176.777, Math.Round(gws.Dxy,3) );
        }
        #endregion

        #region calculating dx dy dxy
        [TestMethod]
        public void TestFileGwsParserDx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(12222222.2, Math.Round(gws.Dx,1));
        }

        [TestMethod]
        public void TestFileGwsParserDy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(133.33, Math.Round(gws.Dy,2));
        }

        [TestMethod]
        public void TestFileGwsParserDxy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gwsFileName);
            Assert.AreEqual(12222222.200727, Math.Round(gws.Dxy, 6));
        }
        #endregion

    }
}
