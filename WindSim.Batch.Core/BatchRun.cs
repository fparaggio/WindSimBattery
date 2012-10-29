using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace WindSim.Batch.Core
{
    public class BatchRun
    {
        public DirectoryInfo batch_dir;
        public FileInfo excel_file;
        public DirectoryInfo refinery_dir;
        private int check_passed = 0;
        private string excelfile_name = @"\batch.xls";
        private string refineries_directory_name = @"\refinements";

        // costructor 
        // starting from an existing batch folder
        public BatchRun(string batch_directory_passed)
        {
            this.batch_dir = new DirectoryInfo(batch_directory_passed);
            this.excel_file = new FileInfo(this.batch_dir.FullName + excelfile_name);
            this.refinery_dir = new DirectoryInfo(this.batch_dir.FullName + refineries_directory_name);
            //  Checking that everything is ok   
            //      checking that folders and excel file exist 
                        if (this.batch_dir.Exists)
                                                    {
                                                        Console.WriteLine(this.batch_dir.FullName + " directory found.");
                                                        check_passed++;
                                                    }
                        else 
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERROR: " + this.batch_dir.FullName + " project directory not found.");
                                Console.ResetColor();
                                
                            }

            
                        if (this.excel_file.Exists)
                                                    {

                                                     Console.WriteLine(this.excel_file.FullName + " file found.");
                                                     check_passed++;                           
                        }
                        else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: "+ this.excel_file.FullName +" not found.");
                            Console.ResetColor();    
                        }


                        if (this.refinery_dir.Exists)
                                                        {
                                                        Console.WriteLine(this.refinery_dir.FullName + " directory found.");
                                                        check_passed++;                                
                        }
                        else 
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERROR: " + this.refinery_dir.FullName +  " directory not found.");
                                Console.ResetColor();        
                        }



            //      checking that excel file is ok.



                        Console.WriteLine("total checks passed " + check_passed);
            return;
            

            //  files are ok    
            
          
        }


         // inizialize folders 
        // starting from an existing project
 
        

    }
        

}
