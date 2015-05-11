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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelLibrary;
using ExcelLibrary.SpreadSheet;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;
using WindSim.Batch.Core;




namespace ConsoleApplication1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string proj = Tools.SelectTextFile(@"C:\Users\WindSim\Desktop\Francesco\WindSim_Projects\", "ws");
            WSProject prova = new WSProject(proj);

            string excelfile_path = Tools.SelectTextFile(prova.file.Directory.Parent.FullName, "xls");
            FileInfo excelfile = new FileInfo(excelfile_path);



            ////prova.run_windfield_z0_conv(0.00001, 5, 5, 25, 2);
            ////RefinementGenerator.AritmeticalGrading test_grading = new RefinementGenerator.AritmeticalGrading(1.2,30,400);
            ////test_grading.Rectangle(prova, "sti_cazzi",3000,500,300,15);




            ExcelBatch battery = new ExcelBatch(prova, excelfile);


            //GwsGenerator griglie = new GwsGenerator();
            //griglie.plane(606, 101, 3000, 500);
            //griglie.plane(306, 51, 3000, 500);
            //griglie.plane(186, 31, 3000, 500);
            //griglie.plane(150, 25, 3000, 500);

        }
    }
}
