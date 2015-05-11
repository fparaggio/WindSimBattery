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

using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using ExcelLibrary.SpreadSheet;
using System;
using System.Diagnostics;


namespace WindSim.Batch.Core
{

    public class WSProject
    {

        public FileInfo file;
        public string name;
        public ProjectParameters parameters;
        public string layout_file = "Layout 1.lws";
        string environment_file = @"C:\Program Files\WindSim\WindSim 5.1.0\Environment.xml";
        string core_file = @"C:\Program Files\WindSim\WindSim 5.1.0\bin\WindSim_core.exe";
        public Layout[] layout;
        public Dictionary<int, WindField> WField = new Dictionary<int, WindField>();
        public bool terrainRanOnCurrentGws = false;
        private double altezzaMaxTem1 = 0.0;

        // Constructors
        public WSProject(string file_path, PhiFileType type = PhiFileType.notReduced)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ProjectParameters));
            TextReader textReader = new StreamReader(file_path);
            parameters = (ProjectParameters)deserializer.Deserialize(textReader);
            textReader.Close();
            file = new FileInfo(file_path);
            // inizializzo i phifile
            this.load_windfields(type);

            //inizializzo il layout
            layout = new Layout[1];
            layout[0] = new Layout("Layout 1.lws", file.Directory);

        }

        public WSProject(string file_path, string target_directory)
        {
            
            // create a new project given a reference project and a target directory 
            // file_path : reference project file
            // target_directory : directory where the new project will be created

            //CopyAll(DirectoryInfo source, DirectoryInfo target);

            FileInfo source_file = new FileInfo(file_path);
            DirectoryInfo target = new DirectoryInfo(target_directory);
            Tools.CopyAll(source_file.Directory, target);
            XmlSerializer deserializer = new XmlSerializer(typeof(ProjectParameters));
            TextReader textReader = new StreamReader(target.FullName + "\\"+ source_file.Name);
            parameters = (ProjectParameters)deserializer.Deserialize(textReader);
            textReader.Close();
            file = new FileInfo(target.FullName + "\\" + source_file.Name);
            this.save();
        }

        // WindSimCore runners
        // windsim_core.exe var1 var2 var3 var4
        //                  [/b] [/m] [/si<index>]
        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //  1 - Terrain
        //  2 - Wind Fields
        //  3 - Objects
        //  4 - Results
        //  5 - Wind Resources
        //  6 - Energy
        //  7 - phi2vtf
        //  8 - Vertical profiles
        //  9 - Limits
        // 10 - Export HTML report

        public string run_string(int module, string option1 = "", string option2="") 
        {
            if (option1 == "b") { option1 = "/b"; };
            if (option2 == "b") { option2 = "/b"; };
            if (option1 == "m") { option1 = "/m"; };
            if (option2 == "m") { option2 = "/m"; };
            if (option1 == "pre") { option1 = "/pre"; };
            if (option2 == "pre") { option2 = "/pre"; };
            string strCmdText = " " + "\"" + file.FullName + "\"" + " \"" + layout_file + "\" " + "\"" + environment_file + "\"" + " " + module + " " + option1 + " " + option2;
            return strCmdText;
        }

        public void run_core(string core_string) 
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(core_file, core_string);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.EnableRaisingEvents = false;
            p.Start();
            p.WaitForExit();
        }

        public void run(int module, string option1="",string option2="")
        {
            // 1 - Terrain
            // 2 - WindFields
            // 3 - objects
            // 4 - results
            // 5 - Wind Resources
            // 6 - Energy
            // 7 - phi2vtf
            // 8 - vertical profiles
            // 9 - Limits
            // 10- Export HTML Report

            string strCmdText = run_string(module,option1,option2);
            run_core(strCmdText);
            if (module == 1) this.terrainRanOnCurrentGws = true;
            if (module == 2) this.load_windfields();
        }

        public void save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectParameters));
            TextWriter textWriter = new StreamWriter(file.FullName);
            serializer.Serialize(textWriter, parameters);
            //file = new FileInfo(file.FullName);
            textWriter.Close();
        }

        public void load_windfields(PhiFileType type = PhiFileType.notReduced)
        {
            WField.Clear();

            foreach (int settore in parameters.WindField.Sector)
            {
                
                string sector_phifile_reduced = file.DirectoryName + "\\windfield\\" + settore + "_red.phi";
                string sector_phifile_not_reduced = file.DirectoryName + "\\windfield\\" + settore + ".phi.Z";

                FileInfo sector_phifile_check_reduced = new FileInfo(sector_phifile_reduced);
                
                FileInfo sector_phifile_check_not_reduced = new FileInfo(sector_phifile_not_reduced);

                if (sector_phifile_check_not_reduced.Exists && type == PhiFileType.notReduced)
                {
                    WindField sector_windfield = new WindField(this,settore, PhiFileType.notReduced);
                    WField.Add(settore, sector_windfield);
                }
                else if (sector_phifile_check_reduced.Exists && type == PhiFileType.reduced)
                {
                    WindField sector_windfield = new WindField(this, settore, PhiFileType.reduced);
                    WField.Add(settore, sector_windfield);
                }
                else
                {
                    WindField sector_windfield_array_null = null;
                    WField.Add(settore, sector_windfield_array_null);
                }

            }
        }

        public double[] run_windfield_z0_conv(double threshold, int sweeps, int cycle_to_be_checked, int monitoring_node_x, int monitoring_node_y, bool restart, int max_cycles = 30, double z0 = 0.0)
        {
            
            
            if (z0 == 0.0)
            {
                z0 = parameters.DTM.Roughness;
            }
            // INITIALIZE EXCEL FILE
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("z0 convergence monitor");
            workbook.Worksheets.Add(worksheet);
            string status = "new";
            if (restart == true) 
            { 
                status = "restart"; 
            }
            string excelfile_path = file.Directory.FullName + @"\z0_conv_monitoring_"+status+".xls";
            // write header
            // this cycle add some null cells because when on Windows 7 Office need at least 6000byte files.
            //----------------------------------------------
            for (var k = 0; k < 200; k++)
                worksheet.Cells[k, 0] = new Cell(null);
            // ---------------------------------------------
            worksheet.Cells[1,1] = new Cell("Project");
            worksheet.Cells[1,2] = new Cell(name);
            worksheet.Cells[2,1] = new Cell("Sweeps each cycle");
            worksheet.Cells[2,2] = new Cell(sweeps);
            worksheet.Cells[3, 1] = new Cell("z0ref");
            worksheet.Cells[3, 2] = new Cell(z0);
            worksheet.Cells[4, 1] = new Cell("Threshold value (z0stim-z0)/z0");
            worksheet.Cells[4, 2] = new Cell(threshold);

            worksheet.Cells[5,1] = new Cell("Cycle");
            worksheet.Cells[5,2] = new Cell("z0stim");
            worksheet.Cells[5, 3] = new Cell("z0stim/z0ref");
            worksheet.Cells[5,4] = new Cell("r_2");
            worksheet.Cells[5,5] = new Cell("sigma");
            worksheet.Cells[5, 6] = new Cell("sigmaz0");
            worksheet.Cells[5,7] = new Cell("elapsed time [s]");
            workbook.Save(excelfile_path);
            // SWEEPS CYCLE
            DateTime windfield_z0_conv_startTime = DateTime.Now;
            int cycle = 0;
            bool exit = false;
            bool last = false;
            double[] last_cycles_zstim = new double[cycle_to_be_checked];
            double[] last_cycles_convc = new double[cycle_to_be_checked];
            while (!exit)
            {
                DateTime cycle_startTime = DateTime.Now;
                if (cycle == 0)
                {
                    // First run
                    if (restart == true) 
                    {
                        parameters.WindField.UseInputPreviousRun = true;
                    }
                    else if (restart == false) 
                    {
                        parameters.WindField.UseInputPreviousRun = false;
                    }
                    parameters.WindField.Sweep = sweeps;
                    save();
                    run(2);
                }
                else if (cycle == 1)
                {
                    parameters.WindField.UseInputPreviousRun = true;
                    parameters.WindField.Sweep = sweeps;
                    save();
                }
                
                if (cycle >0 )
                {
                    if (last == false)
                    {
                    run(2, "pre"); // if time it too much set no graphics no others...
                    }
                    else
                    {
                    parameters.WindField.UseInputPreviousRun = true;
                    parameters.WindField.Sweep = 1;
                    save();
                    run(2);
                        exit=true;
                    }
                }


                // IT WORKS ONLY WITH ONE SECTOR, THE FIRST ONE!!!!
                if (last == false)
                {
                    if (this.parameters.WindField.Temperature == 1) { altezzaMaxTem1 = 80.0; }
                double[] z0stim = this.WField[this.parameters.WindField.Sector[0]].z0(monitoring_node_x, monitoring_node_y, altezzaMaxTem1);
                last_cycles_zstim[cycle % cycle_to_be_checked] = Math.Abs(z0stim[0] / z0);
                // z0_stim  { z0 , (u*/k) , sigma, r2 } 
                DateTime cycle_stopTime = DateTime.Now;
                TimeSpan cycle_timespan = cycle_stopTime - cycle_startTime;

                worksheet.Cells[6 + cycle, 1] = new Cell(cycle);
                worksheet.Cells[6 + cycle, 2] = new Cell(z0stim[0]);
                worksheet.Cells[6 + cycle, 3] = new Cell(z0stim[0] / z0);
                worksheet.Cells[6 + cycle, 4] = new Cell(z0stim[3]);
                worksheet.Cells[6 + cycle, 5] = new Cell(z0stim[2]);
                worksheet.Cells[6 + cycle, 6] = new Cell(z0stim[4]);
                worksheet.Cells[6 + cycle, 7] = new Cell(cycle_timespan.TotalSeconds);
                workbook.Save(excelfile_path);
                }

                // check convergence criteria
                if (cycle > cycle_to_be_checked - 1)
                {
                    for(int i = 0; i < cycle_to_be_checked; i++)
                    {
                        last_cycles_convc[i] = Math.Abs(last_cycles_zstim[0] - last_cycles_zstim[i]);
                    }

                    if (MyMath.Max(last_cycles_convc) < threshold) last = true;
                    if (cycle == max_cycles) last = true;
                }
                
                // record cycle stop time
                
                
                // write parameter in the excel


                cycle++;
            }
            //each run it write z0 and all other parameters in the excel
            // first run parameters.WindField.UseInputPreviousRun = false;
            // fom second run to end parameters.WindField.UseInputPreviousRun = true;

            //  at end exit parameters.WindField.UseInputPreviousRun = false;  
            // each run i write also the cycle elapsed time.

            // write total time in minutes
            DateTime windfield_z0_conv_stopTime = DateTime.Now;
            TimeSpan windfield_z0_conv_elapsedTime = windfield_z0_conv_stopTime - windfield_z0_conv_startTime;
            worksheet.Cells[6 + cycle, 6] = new Cell("Total Time [s]");
            worksheet.Cells[6 + cycle, 7] = new Cell(windfield_z0_conv_elapsedTime.TotalSeconds);

            

            // saving the excel file

            workbook.Save(excelfile_path);
            return this.WField[this.parameters.WindField.Sector[0]].z0(monitoring_node_x, monitoring_node_y);

        }

        public bool load_bws(string bws_fullpath) 
        {
            FileInfo bws_file = new FileInfo(bws_fullpath);
            if (bws_file.Exists)
            {
                //check the target directory exist
                // --> to be insered into project class refactoring
                //copy the file to the project directory
                bws_file.CopyTo(file.Directory.FullName + "\\dtm\\" + bws_file.Name,true);
                //set the project parameters
                parameters.CFD.RefinementFileName = bws_file.Name;
                parameters.CFD.RefinementType = 2;
                save();
                //save the project
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool load_gws(string gws_fullpath)
        {
            FileInfo gws_file = new FileInfo(gws_fullpath);
            if (gws_file.Exists)
            {
                //check the target directory exist
                DirectoryInfo dtm_directory = new DirectoryInfo(file.Directory.FullName+"\\dtm");
                if (dtm_directory.Exists)
                {
                    FileInfo old_grid_file = new FileInfo(dtm_directory.FullName + "\\grid.gws");
                    if (old_grid_file.Exists)
                    {
                        bool exit = false;

                        for (int i = 0; exit == false; i++)
                        {
                            FileInfo check_file = new FileInfo(old_grid_file.Directory.FullName + "\\grid.backup_fbatch_" + i + ".gws");
                            if (!check_file.Exists)
                            {
                                old_grid_file.MoveTo(check_file.FullName);
                                exit = true;
                            }
                        }

                    }

                    // copiare il file grid.gws di partena nella directory dtm
                    

                }
                else 
                {
                    // creare la directory \dtm
                    System.IO.Directory.CreateDirectory(dtm_directory.FullName);
                    
                }
                // copiare il file grid.gws di partena nella directory dtm
                
                gws_file.CopyTo(dtm_directory.FullName + "\\grid.gws");
                
                terrainRanOnCurrentGws = false;
                ////copy the file to the project directory
                //bws_file.CopyTo(file.Directory.FullName + "\\dtm\\" + bws_file.Name, true);
                ////set the project parameters
                //parameters.CFD.RefinementFileName = bws_file.Name;
                //parameters.CFD.RefinementType = 2;
                //save();
                ////save the project

                return true;
            }
            else
            {
                return false;
            }
        }

        public void load_parameters_from_excel(Worksheet sheet)
        {
            this.parameters.DTM.CoordSys = Convert.ToInt32(sheet.Cells[2, 1].Value);
            this.parameters.DTM.XMin = Convert.ToInt32(sheet.Cells[3, 1].Value);
            this.parameters.DTM.XMax = Convert.ToInt32(sheet.Cells[3, 3].Value);
            this.parameters.DTM.YMin = Convert.ToInt32(sheet.Cells[4, 1].Value);
            this.parameters.DTM.YMax = Convert.ToInt32(sheet.Cells[4, 3].Value);
        }

        public AskerveinConvergenceResult run_windfield_askervein_conv(double threshold, int sweeps, int cycle_to_be_checked, bool restart, Anemometer[] sensors, int max_cycles = 15)
        {


            int anemometers = sensors.Length;
            // INITIALIZE EXCEL FILE
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Askervein convergence monitor");
            workbook.Worksheets.Add(worksheet);

            string status = "new";
            if (restart == true)
            {
                status = "restart";
            }
            string excelfile_path = file.Directory.FullName + @"\Askervein_conv_monitoring_" + status + ".xls";
            workbook.Save(excelfile_path);
            // write header
            // this cycle add some null cells because when on Windows 7 Office need at least 6000byte files.
            //----------------------------------------------
            for (var k = 0; k < 200; k++)
                worksheet.Cells[k, 0] = new Cell(null);
            // ---------------------------------------------
            worksheet.Cells[1, 1] = new Cell("Project");
            worksheet.Cells[1, 2] = new Cell(name);
            worksheet.Cells[2, 1] = new Cell("Sweeps each cycle");
            worksheet.Cells[2, 2] = new Cell(sweeps);
            worksheet.Cells[3, 1] = new Cell("Threshold value (z0stim-z0)/z0");
            worksheet.Cells[3, 2] = new Cell(threshold);
            worksheet.Cells[4, 1] = new Cell("X");
            worksheet.Cells[4, 2] = new Cell("Y");
            worksheet.Cells[4, 3] = new Cell("zAbGround");

            for (int i=0; i<anemometers; i++){
                worksheet.Cells[5 + i, 1] = new Cell(sensors[i].x);
                worksheet.Cells[5 + i, 2] = new Cell(sensors[i].y);
                worksheet.Cells[5 + i, 3] = new Cell(sensors[i].height);
            }
           
            

            // SWEEPS CYCLE
            DateTime askervein_conv_startTime = DateTime.Now;
            int cycle = 0;
            bool exit = false;
            bool last = false;
            double[][] last_cycles_vel = new double[cycle_to_be_checked][];
            double[][] last_cycles_conv = new double[cycle_to_be_checked][];
            double[] cycles_max_speedVariation = new double[cycle_to_be_checked];
            double[] speeds = new double[anemometers];     
            double[] temp_speed_variation = new double[anemometers];
            
            while (!exit)
            {
                DateTime cycle_startTime = DateTime.Now;
                if (cycle == 0)
                {
                    // First run
                    if (restart == true)
                    {
                        parameters.WindField.UseInputPreviousRun = true;
                    }
                    else if (restart == false)
                    {
                        parameters.WindField.UseInputPreviousRun = false;
                    }
                    parameters.WindField.Sweep = sweeps;
                    save();
                    run(2);
                }
                else if (cycle == 1)
                {
                    parameters.WindField.UseInputPreviousRun = true;
                    parameters.WindField.Sweep = sweeps;
                    save();
                }

                if (cycle > 0)
                {
                    if (last == false)
                    {
                        run(2, "pre"); // if time it too much set no graphics no others...
                    }
                    else
                    {
                        parameters.WindField.UseInputPreviousRun = true;
                        parameters.WindField.Sweep = 1;
                        save();
                        run(2);
                        exit = true;
                    }
                }


                // IT WORKS ONLY WITH ONE SECTOR, THE FIRST ONE!!!!
                if (last == false)
                {
                    

                    for (int i = 0; i < anemometers; i++)
                    {

                        speeds[i] = this.WField[this.parameters.WindField.Sector[0]].xyzSpeed(sensors[i].x, sensors[i].y, sensors[i].height);
                        worksheet.Cells[4, 4 + cycle] = new Cell(cycle);
                        worksheet.Cells[5 + i, 4 + cycle] = new Cell(speeds[i]);
                        if (cycle > 0)
                        {
                            int last_cycle = cycle - 1;
                            temp_speed_variation[i] = (Math.Abs(speeds[i] - last_cycles_conv[last_cycle % cycle_to_be_checked][i])) / speeds[i];
                        }

                    }


                    last_cycles_conv[cycle % cycle_to_be_checked] = speeds;
                    cycles_max_speedVariation[cycle % cycle_to_be_checked] = MyMath.Max(temp_speed_variation);
                 
                    DateTime cycle_stopTime = DateTime.Now;
                    TimeSpan cycle_timespan = cycle_stopTime - cycle_startTime;

                    worksheet.Cells[5 + anemometers, 4 + cycle] = new Cell(cycles_max_speedVariation[cycle % cycle_to_be_checked]);
                    worksheet.Cells[6 + anemometers, 4 + cycle] = new Cell(cycle_timespan.TotalSeconds);
                    workbook.Save(excelfile_path);
                }

                // check convergence criteria
                if (cycle > cycle_to_be_checked - 1)
                {

                    if (MyMath.Max(cycles_max_speedVariation) < threshold) last = true;
                    if (cycle == max_cycles) last = true;
                }

                cycle++;
            }
  
            DateTime windfield_askervein_conv_stopTime = DateTime.Now;
            TimeSpan windfield_askervein_conv_elapsedTime = windfield_askervein_conv_stopTime - askervein_conv_startTime;
            
            worksheet.Cells[1, 3] = new Cell("Total Time [s]");
            worksheet.Cells[1, 4] = new Cell(windfield_askervein_conv_elapsedTime.TotalSeconds);
            
             

            bool criteriaReached;

            if (cycle == max_cycles)
            {
                worksheet.Cells[2, 3] = new Cell("MAX CYCLES REACHED");
                criteriaReached = false;
            }
            else
            {
                worksheet.Cells[2, 3] = new Cell("CONVERGENCE CRITERIA REACHED");
                criteriaReached = true;
            }

            // saving the excel file

            workbook.Save(excelfile_path);
            FileInfo excelFile = new FileInfo(excelfile_path);
            AskerveinConvergenceResult risultati = new AskerveinConvergenceResult(sensors, speeds, cycle, windfield_askervein_conv_elapsedTime, criteriaReached, threshold, sweeps, cycle_to_be_checked, excelFile);
            return risultati;

        }

        
    }

    public class AskerveinConvergenceResult
    {
        private bool _criteriaReached;
        private int _cycles;
        private TimeSpan _totaltime;
        private Anemometer[] _sensors;
        private double[] _speeds;
        private List<string> _messaggi;
        private double _threshold;
        private int _sweeps;
        private int _cycle_to_be_checked;
        private DateTime _lastRun;
        private bool _error;
        private FileInfo _excelFile;

        public bool criteriaReached
        {
            get { return _criteriaReached; }
        }
        public int cycles
        {
            get { return _cycles; }
        }
        public TimeSpan totaltime
        {
            get { return _totaltime; }
        }
        public Anemometer[] sensors
        {
            get { return _sensors; }
        }
        public double[] speeds
        {
            get { return _speeds; }
        }
        public List<string> messaggi
        {
            get { return _messaggi; }
        }
        public double threshold
        {
            get { return _threshold; }
        }
        public int sweeps
        {
            get { return _sweeps; }
        }
        public int cycle_to_be_checked
        {
            get { return _cycle_to_be_checked; }
        }
        public DateTime lastRun
        {
            get { return _lastRun; }
        }
        private bool error
        {
            get { return _error; }
        }
        private FileInfo excelFile
        {
            get { return _excelFile; }
        }

        public AskerveinConvergenceResult(Anemometer[] sensors, double[] speeds, int cycles, TimeSpan totaltime, bool criteriaReached, double threshold, int sweeps, int cycle_to_be_checked, FileInfo excelFile)
        {
            if (sensors.Length == speeds.Length)
            {
                _sensors = sensors;
                _speeds = speeds;
                _cycles = cycles;
                _totaltime = totaltime;
                _criteriaReached = criteriaReached;
                _threshold = threshold;
                _sweeps = sweeps;
                _cycle_to_be_checked = cycle_to_be_checked;
                _lastRun = DateTime.Now;
                _error = false;
                _excelFile = excelFile;
            }
            else
            {
                _messaggi.Add("sensors.lenght not equal to speeds.lenght !!!!");
                _error = true;
            }

        }

    }
}

    