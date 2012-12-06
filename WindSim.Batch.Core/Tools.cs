using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ExcelLibrary;
using ExcelLibrary.SpreadSheet;
using System.Xml;
using System.Windows.Forms;

namespace WindSim.Batch.Core
{
    public class Tools
    {
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
        // Check if the target directory exists, if not, create it.
        if (Directory.Exists(target.FullName) == false)
        {
            Directory.CreateDirectory(target.FullName);
        }

        // Copy each file into it’s new directory.
        foreach (FileInfo fi in source.GetFiles())
        {
            //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
            fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
        }

        // Copy each subdirectory using recursion.
        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        {
            DirectoryInfo nextTargetSubDir =
                target.CreateSubdirectory(diSourceSubDir.Name);
            CopyAll(diSourceSubDir, nextTargetSubDir);
        }
    }
        
        public static string SelectTextFile(string initialDirectory, string extension)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "WindSim Projects (*."+extension+")|*."+extension+"|All files (*.*)|*.*";
            dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Select a text file";
            return (dialog.ShowDialog() == DialogResult.OK)
               ? dialog.FileName : null;
        }

        public static string SelectPhiFile(string initialDirectory)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "Phi files (*.phi)|*.phi|All files (*.*)|*.*";
            dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Select a phi file";
            return (dialog.ShowDialog() == DialogResult.OK)
               ? dialog.FileName : null;
        }
        


        public static string inizialize_batch(string project_file, bool prooo) 
        {
         string batch_directory = "none";
         FileInfo pfile = new FileInfo(project_file);
         DirectoryInfo tdir = new DirectoryInfo(pfile.DirectoryName);
  
            // check that the project file exist
               if (pfile.Exists)
               {
               Console.WriteLine(pfile.FullName + " file found.");

            // check that the batch directory  exist   
            
               }
               else
                                {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERROR project file not found: " + pfile.FullName);
                                Console.ResetColor();
                                }

         // check that the batch directory  exist
         // check taht the initialed excel file do not exist (ask to overwrite)
         // parse the project to create the excel file
         // return the batch_directory
         
         return batch_directory;
        }

        public static void excel_batch_template(WSProject p) 
        {

            string file = @"C:\Users\WindSim\Desktop\Francesco\WindSim_Projects\MoninObukhov\batch.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Batch Data");

            // this cycle add some null cells because when on Windows 7 Office need at least 6000byte files.
            //----------------------------------------------
            for (var k = 0; k < 200; k++)
                worksheet.Cells[k, 0] = new Cell(null);
            // ---------------------------------------------
 
          
      

            XmlReader reader = XmlReader.Create(p.file.FullName);
            int i = 0;
            while (reader.Read()) 
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    worksheet.Cells[i, 0] = new Cell(reader.Name);
                    if (reader.Read())
                    {
                        worksheet.Cells[i, 1] = new Cell(reader.Value.Trim());
                       
                    }
                    i++;
                }
            }

            workbook.Worksheets.Add(worksheet);

            workbook.Save(file);


        }

        public static Worksheet excel_batch_worksheet(WSProject p)
        {           
            Worksheet worksheet = new Worksheet("Run Parameters Data");

            // this cycle add some null cells because when on Windows 7 Office need at least 6000byte files.
            //----------------------------------------------
            for (var k = 0; k < 200; k++)
                worksheet.Cells[k, 0] = new Cell(null);
            // ---------------------------------------------




            XmlReader reader = XmlReader.Create(p.file.FullName);
            int i = 0;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    worksheet.Cells[i, 0] = new Cell(reader.Name);
                    if (reader.Read())
                    {
                        worksheet.Cells[i, 1] = new Cell(reader.Value.Trim());
                    }
                    i++;
                }
            }



            return worksheet;


        }


        public static void write_excel_arrays(string path, double[] array1, double[] array2)
        {
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Excel arrays");

            // this cycle add some null cells because when on Windows 7 Office need at least 6000byte files.
            //----------------------------------------------
            for (var k = 0; k < 200; k++)
                worksheet.Cells[k, 0] = new Cell(null);
            // ---------------------------------------------
            for (int i = 0; i < array1.Length; i++)
            {
                worksheet.Cells[i, 1] = new Cell(array1[i]);
            }
            for (int a = 0; a < array2.Length; a++)
            {
                worksheet.Cells[a, 2] = new Cell(array2[a]);
            }
            workbook.Worksheets.Add(worksheet);
            workbook.Save(path);
        }

        public static bool tf_char2bool(char a)
        {
            if (a.Equals('f') || a.Equals('F')) { return false; }
            else return true;
        }

        public static long GetDirectorySize(string p)
        {
            string[] a = Directory.GetFiles(p, "*.*");
            long b = 0;
            foreach (string name in a) 
            {
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            return b;
        }
     }
 }
  

