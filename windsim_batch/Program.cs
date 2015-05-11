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
