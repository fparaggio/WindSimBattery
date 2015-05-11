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
