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
            string excelfile_path = Tools.SelectTextFile(@"C:\Users\WindSim\Desktop\Francesco\WindSim_Projects\batches", "xls");
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
