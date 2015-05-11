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
using System.IO;

namespace WindSim.Batch.Core.Test
{
    [TestClass]
    [DeploymentItem("TestFiles\\test.gws")]
    [DeploymentItem("TestFiles\\5x5.gws")]
    [DeploymentItem("TestFiles\\3x3.gws")]
    [DeploymentItem("TestFiles\\project1", "project1")]
    public class Test_AutomaticGrid
    {
        static string gwsFileName = "test.gws";
        static string gws5x5 = "5x5.gws";
        static string gws3x3 = "3x3.gws";
        static string dir_name = "project1";
        static DirectoryInfo projectdir = new DirectoryInfo(dir_name);
        static string filepath = projectdir.FullName + "\\MoninObukhov_ref.ws";
        FileInfo project_file = new FileInfo(filepath);
        
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
        #endregion

        #region height of firt cell smoothed array
        [TestMethod]
        public void TestFileHFirstCellArray1_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            MyMath.DoubleMap hfirstcellmap = AutomaticGrid.Geometrical.HFirstCell(gws.Map(FileGws.MapType.Rough));
            MyMath.DoubleMap tempMap = MyMath.SmoothedMap(hfirstcellmap, 2.0);
            Assert.AreEqual(7.54, Math.Round(tempMap.data[1, 1][2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray0_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            MyMath.DoubleMap hfirstcellmap = AutomaticGrid.Geometrical.HFirstCell(gws.Map(FileGws.MapType.Rough));
            MyMath.DoubleMap tempMap = MyMath.SmoothedMap(hfirstcellmap, 2.0);
            Assert.AreEqual(3.12, Math.Round(tempMap.data[0, 0][2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray1_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            MyMath.DoubleMap hfirstcellmap = AutomaticGrid.Geometrical.HFirstCell(gws.Map(FileGws.MapType.Rough));
            MyMath.DoubleMap tempMap = MyMath.SmoothedMap(hfirstcellmap, 2.0);
            Assert.AreEqual(10.95, Math.Round(tempMap.data[1, 0][2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray2_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            MyMath.DoubleMap hfirstcellmap = AutomaticGrid.Geometrical.HFirstCell(gws.Map(FileGws.MapType.Rough));
            MyMath.DoubleMap tempMap = MyMath.SmoothedMap(hfirstcellmap, 2.0);
            Assert.AreEqual(6.05, Math.Round(tempMap.data[2, 0][2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray0_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            MyMath.DoubleMap hfirstcellmap = AutomaticGrid.Geometrical.HFirstCell(gws.Map(FileGws.MapType.Rough));
            MyMath.DoubleMap tempMap = MyMath.SmoothedMap(hfirstcellmap, 2.0);
            Assert.AreEqual(7.20, Math.Round(tempMap.data[0, 1][2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray2_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            MyMath.DoubleMap hfirstcellmap = AutomaticGrid.Geometrical.HFirstCell(gws.Map(FileGws.MapType.Rough));
            MyMath.DoubleMap tempMap = MyMath.SmoothedMap(hfirstcellmap, 2.0);
            Assert.AreEqual(10.95, Math.Round(tempMap.data[2, 1][2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray0_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            MyMath.DoubleMap hfirstcellmap = AutomaticGrid.Geometrical.HFirstCell(gws.Map(FileGws.MapType.Rough));
            MyMath.DoubleMap tempMap = MyMath.SmoothedMap(hfirstcellmap, 2.0);
            Assert.AreEqual(7.20, Math.Round(tempMap.data[0, 2][2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray1_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            MyMath.DoubleMap hfirstcellmap = AutomaticGrid.Geometrical.HFirstCell(gws.Map(FileGws.MapType.Rough));
            MyMath.DoubleMap tempMap = MyMath.SmoothedMap(hfirstcellmap, 2.0);
            Assert.AreEqual(5.52, Math.Round(tempMap.data[1, 2][2], 2));
        }

        [TestMethod]
        public void TestFileHFirstCellArray2_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            MyMath.DoubleMap hfirstcellmap = AutomaticGrid.Geometrical.HFirstCell(gws.Map(FileGws.MapType.Rough));
            MyMath.DoubleMap tempMap = MyMath.SmoothedMap(hfirstcellmap, 2.0);
            Assert.AreEqual(6.05, Math.Round(tempMap.data[2, 2][2], 2));
        }
        #endregion

        #region interpolated data

        [TestMethod]
        public void interpolatedData3x3_0_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(4.99, Math.Round(result.firstCellHeightMap.data[0, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_1_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(9.41, Math.Round(result.firstCellHeightMap.data[1, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_0_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(5.33, Math.Round(result.firstCellHeightMap.data[0, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_1_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(9.07, Math.Round(result.firstCellHeightMap.data[1, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_x_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(0.0, Math.Round(result.firstCellHeightMap.data[0, 0][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_x_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(4.0, Math.Round(result.firstCellHeightMap.data[1, 0][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_x_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(0.0, Math.Round(result.firstCellHeightMap.data[0, 1][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_x_3()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(4.0, Math.Round(result.firstCellHeightMap.data[1, 1][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_y_0()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(0.0, Math.Round(result.firstCellHeightMap.data[0, 0][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_y_1()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(0.0, Math.Round(result.firstCellHeightMap.data[1, 0][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_y_2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(2.5, Math.Round(result.firstCellHeightMap.data[0, 1][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_y_3()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 4.0, 0.0, 2.5, 1, 1, 1, 1);
            Assert.AreEqual(2.5, Math.Round(result.firstCellHeightMap.data[1, 1][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375a()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(7.2, Math.Round(result.firstCellHeightMap.data[0, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375b()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(6.87, Math.Round(result.firstCellHeightMap.data[0, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375c()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(7.51, Math.Round(result.firstCellHeightMap.data[1, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375d()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(8.87, Math.Round(result.firstCellHeightMap.data[1, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375ax()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(2.0, Math.Round(result.firstCellHeightMap.data[0, 0][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375bx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(2.0, Math.Round(result.firstCellHeightMap.data[0, 1][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375cx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(6.0, Math.Round(result.firstCellHeightMap.data[1, 1][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375dx()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(6.0, Math.Round(result.firstCellHeightMap.data[1, 0][0], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375ay()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(1.25, Math.Round(result.firstCellHeightMap.data[0, 0][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375by()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(3.75, Math.Round(result.firstCellHeightMap.data[0, 1][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375cy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(3.75, Math.Round(result.firstCellHeightMap.data[1, 1][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_2_6_125_375dy()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 2.0, 6.0, 1.25, 3.75, 1, 1, 1, 1);
            Assert.AreEqual(1.25, Math.Round(result.firstCellHeightMap.data[1, 0][1], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5a()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 6.0, 8.0, 3.75, 5.0, 1, 1, 1, 1);
            Assert.AreEqual(7.51, Math.Round(result.firstCellHeightMap.data[0, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5b()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 6.0, 8.0, 3.75, 5.0, 1, 1, 1, 1);
            Assert.AreEqual(5.79, Math.Round(result.firstCellHeightMap.data[0, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5c()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 6.0, 8.0, 3.75, 5.0, 1, 1, 1, 1);
            Assert.AreEqual(6.77, Math.Round(result.firstCellHeightMap.data[1, 1][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5d()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 6.0, 8.0, 3.75, 5.0, 1, 1, 1, 1);
            Assert.AreEqual(8.5, Math.Round(result.firstCellHeightMap.data[1, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5a10()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 6.0, 8.0, 3.75, 5.0, 1, 1, 1, 1);
            Assert.AreEqual(7.51, Math.Round(result.firstCellHeightMap.data[0, 0][2], 2));
        }

        [TestMethod]
        public void interpolatedData3x3_6_8_375_5a10x2()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 6.0, 8.0, 3.75, 5.0, 10, 10, 1, 1);
            Assert.AreEqual(6.4, Math.Round(result.firstCellHeightMap.data[2, 0][0], 2));
        }
        #endregion 

        #region GeometricalColumn
        [TestMethod]
        public void test_nodes_array_dimension()
        {

            AutomaticGrid.Geometrical.GeometricalColumn column = new AutomaticGrid.Geometrical.GeometricalColumn(0.5, 200, 20, 1, 1,1);
            Assert.AreEqual(20, column.nodes.Length);
        }

        [TestMethod]
        public void test_last_node()
        {

            AutomaticGrid.Geometrical.GeometricalColumn column = new AutomaticGrid.Geometrical.GeometricalColumn(0.5, 200, 20, 1, 1, 1);
            Assert.AreEqual(200, Math.Round(column.nodes[19],2));
        }

        [TestMethod]
        public void test_first_node()
        {

            AutomaticGrid.Geometrical.GeometricalColumn column = new AutomaticGrid.Geometrical.GeometricalColumn(0.5, 200, 20, 1, 1, 1);
            Assert.AreEqual(0.5, Math.Round(column.nodes[0], 1));
        }

        [TestMethod]
        public void test_column_exp_factor_1()
        {

            AutomaticGrid.Geometrical.GeometricalColumn column = new AutomaticGrid.Geometrical.GeometricalColumn(0.5, 200, 20, 1, 1, 1);
            Assert.AreEqual(Math.Round(column.expansionFactor,4), Math.Round((column.nodes[1] - column.nodes[0]) / column.nodes[0],4));
        }
        [TestMethod]
        public void test_column_exp_factor_2()
        {

            AutomaticGrid.Geometrical.GeometricalColumn column = new AutomaticGrid.Geometrical.GeometricalColumn(0.5, 200, 20, 1, 1, 1);
            Assert.AreEqual(Math.Round(column.expansionFactor, 4), Math.Round(((column.nodes[19] - column.nodes[18]) / (column.nodes[18]-column.nodes[17])), 4));
        }

        [TestMethod]
        public void test_column_exp_factor_3()
        {

            AutomaticGrid.Geometrical.GeometricalColumn column = new AutomaticGrid.Geometrical.GeometricalColumn(0.5, 200, 20, 1, 1, 1);
            Assert.AreEqual(Math.Round(column.expansionFactor, 4), Math.Round(((column.nodes[10] - column.nodes[9]) / (column.nodes[9] - column.nodes[8])), 4));
        }

        #endregion

        #region maxGroungHeight
        
        [TestMethod]
        public void test_maxGroungHeight_to_be_verified()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 8.0, 0.0, 5.0, 10, 10, 100, 10);
            // valore da verificare!
            Assert.AreEqual(6.25, Math.Round(result.maxGroungHeight,2));
       
        }
        
        #endregion
        

        #region save_to_bws
        [TestMethod]
        public void Test_save_to_bws()
        {
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 8.0, 0.0, 5.0, 10, 12, 100, 10);
            WSProject project = new WSProject(project_file.FullName);
            Assert.IsTrue(result.SaveToBws(project, "test"));
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_write_the_bws_file_in_the_proper_Directory()
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filename = "test_bws_position";
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 8.0, 0.0, 5.0, 10, 12, 100, 10);
            bool save = result.SaveToBws(project, bws_filename);
            string expected_file_path = project.file.Directory.FullName + "\\dtm\\" + "test_bws_position" + ".bws"; ;
            FileInfo expected_file = new FileInfo(expected_file_path);
            Assert.IsTrue(expected_file.Exists);
            //
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_write_the_bws_file_in_the_proper_Directory_aritm()
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filename = "test_bws_position234";
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 8.0, 0.0, 5.0, 10, 12, 100, 10);
            bool save = result.SaveToBws(project, bws_filename);
            string expected_file_path = project.file.Directory.FullName + "\\dtm\\" + "test_bws_position234" + ".bws"; ;
            FileInfo expected_file = new FileInfo(expected_file_path);
            Assert.IsTrue(expected_file.Exists);
            //

        }

        [TestMethod]
        [DeploymentItem("TestFiles\\bws_test.bws")]
        public void test_RefinementGenerator_load_proper_bws_file_name_project_parameters()
        {
            WSProject project = new WSProject(project_file.FullName);
            string bws_filename = "test_bws_position";
            string bws_file = bws_filename + ".bws";
            ParseManager parser = new ParseManager();
            FileGws gws = parser.ParseGws(gws3x3);
            AutomaticGrid.Geometrical result = new AutomaticGrid.Geometrical(gws, 2.0, 0.0, 8.0, 0.0, 5.0, 10, 12, 100, 10);
            bool save = result.SaveToBws(project, bws_filename);
            Assert.AreEqual(bws_file, project.parameters.CFD.RefinementFileName);
        }
        #endregion
    }
}
