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



            // MONIN OBUKHOV BATCH CASE
            // string proj = Tools.SelectTextFile(@"C:\Users\WindSim\Desktop\Francesco\WindSim_Projects\", "ws");
            // WSProject prova = new WSProject(proj);
            // string excelfile_path = Tools.SelectTextFile(prova.file.Directory.Parent.FullName, "xls");
            // FileInfo excelfile = new FileInfo(excelfile_path);
            // ThesisBatch.MoninExcelBatch battery = new ThesisBatch.MoninExcelBatch(prova, excelfile);

            // ----------------------------------------------------------------------------

            // ASKERVEIN BATCH CASE DOPPI COMMENTI, TOGLIERNE SOLO 1

            string excelfile_path = Tools.SelectTextFile(@"c:\\", "xls");


            //string excelfile_path = Tools.SelectTextFile(@"C:\Users\Francesco\Desktop", "xls");
            FileInfo excelfile = new FileInfo(excelfile_path);
            ThesisBatch.AskerveinBatch battery = new ThesisBatch.AskerveinBatch(excelfile);
            Console.ReadKey();

            //// devo ancora assegnare il file gws e avviare il modulo terrain.. 

            

            ////GwsGenerator griglie = new GwsGenerator();
            ////griglie.plane(606, 101, 3000, 500);
            ////griglie.plane(306, 51, 3000, 500);
            ////griglie.plane(186, 31, 3000, 500);
            ////griglie.plane(150, 25, 3000, 500);


            ///// RECUPERA PROFILI

            //string proj = Tools.SelectTextFile(@"C:\ProgettiTesi\", "ws");
            //WSProject prova = new WSProject(proj);
            //double a = prova.WField[prova.parameters.WindField.Sector[0]].xyzSpeed(2863, 2881, 35);
            //double rs_a = prova.WField[prova.parameters.WindField.Sector[0]].xyzSpeed(1487, 395, 35);

            //double b = prova.WField[prova.parameters.WindField.Sector[0]].xyzSpeed(2863, 2881, 25);
            //double rs_b = prova.WField[prova.parameters.WindField.Sector[0]].xyzSpeed(1487, 395, 25);

            //double c = prova.WField[prova.parameters.WindField.Sector[0]].xyzSpeed(2863, 2881, 15);
            //double rs_c = prova.WField[prova.parameters.WindField.Sector[0]].xyzSpeed(1487, 395, 15);

            //double d = prova.WField[prova.parameters.WindField.Sector[0]].xyzSpeed(2863, 2881, 8);
            //double rs_d = prova.WField[prova.parameters.WindField.Sector[0]].xyzSpeed(1487, 395, 8);
            //double rs_speed = prova.WField[prova.parameters.WindField.Sector[0]].xyzSpeed(1487, 395, 10);

            //double fsr_a = (a - rs_a) / rs_a;
            //double fsr_b = (b - rs_b) / rs_b;
            //double fsr_c = (c - rs_c) / rs_c;
            //double fsr_d = (d - rs_d) / rs_d;

            //Console.WriteLine(fsr_a);
            //Console.WriteLine(fsr_b);
            //Console.WriteLine(fsr_c);
            //Console.WriteLine(fsr_d);
            //Console.WriteLine(rs_speed);

            //Console.ReadKey();


        }
    }
}
