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
using ExcelLibrary.SpreadSheet;

namespace WindSim.Batch.Core
{
    
  public class ThesisBatch
  {  
    public abstract class ExcelBatch
    {
        public WSProject referenceProject;
        public FileInfo excelBatchFile;
        public DirectoryInfo batchDirectory;

    }

    public class MoninExcelBatch : ExcelBatch
    {
        public Dictionary<int, WSProject> experimentBatch_geom = new Dictionary<int, WSProject>();
        public Dictionary<int, WSProject> experimentBatch_arit = new Dictionary<int, WSProject>();
        public bool verifyExcelFile(FileInfo file)
        {
            if (file.Exists)
            {
                int counter = 0;
                Workbook book = Workbook.Load(file.FullName);
                Worksheet sheet = book.Worksheets[0];
                int numberOfEsperiments = Convert.ToInt32(sheet.Cells[1, 1].Value);
                for (int i = 0; i < numberOfEsperiments; i++)
                {
                    string filename = sheet.Cells[13, i + 1].ToString();
                    string gwsFileNamePath = file.Directory.FullName + "\\gws_files\\" + filename;
                    FileInfo gwsfile = new FileInfo(gwsFileNamePath);
                    if (gwsfile.Exists) { counter++; }
                }
                if (counter == numberOfEsperiments) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }
        public bool verifyProjectFiles(FileInfo file, WSProject reference)
        {
            if (file.Exists)
            {
                int counter = 0;
                Workbook book = Workbook.Load(file.FullName);
                Worksheet sheet = book.Worksheets[0];
                int numberOfEsperiments = Convert.ToInt32(sheet.Cells[1, 1].Value);
                int rerun_cases = 0;
                for (int i = 0; i < numberOfEsperiments; i++)
                {
                    string batteryName = sheet.Cells[0, 1].StringValue;
                    string testCasetargetDirectory = file.Directory.FullName + "\\" + batteryName + "_" + sheet.Cells[7, i + 1].StringValue;
                    // se il caso e' re-run
                    int todo = Convert.ToInt32(sheet.Cells[6, i + 1].Value);
                    if (todo == 2)
                    {
                        rerun_cases++;
                        FileInfo geometrico = new FileInfo(testCasetargetDirectory + "_geom\\" + reference.file.Name);
                        FileInfo aritmetico = new FileInfo(testCasetargetDirectory + "_arit\\" + reference.file.Name);
                        // allora verifica che esista sia l'aritmetica che la geometrica
                        if (aritmetico.Exists && geometrico.Exists) { counter++; }
                    }


                }
                if (counter == rerun_cases) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public MoninExcelBatch(WSProject referenceProject, FileInfo excelBatchFile)
        {
            // controllo l-esistenza del file excel        
            if (verifyExcelFile(excelBatchFile) && verifyProjectFiles(excelBatchFile, referenceProject))
            {
                // setto la directory
                // riempo l'experimentBatch
                Workbook book = Workbook.Load(excelBatchFile.FullName);
                Worksheet sheet = book.Worksheets[0];
                string batteryName = sheet.Cells[0, 1].StringValue;
                double numberOfEsperiments = Convert.ToInt32(sheet.Cells[1, 1].Value);
                Worksheet results_geom = book.Worksheets[1];
                results_geom.Cells[0, 0] = new Cell("UCRT Profiles for Geometrical Grading");
                Worksheet results_ke_geom = book.Worksheets[2];
                results_ke_geom.Cells[0, 0] = new Cell("KE Profiles for Geometrical Grading");
                Worksheet results_zcen_geom = book.Worksheets[3];
                results_zcen_geom.Cells[0, 0] = new Cell("Z Profiles for Geometrical Grading");
                Worksheet results_arit = book.Worksheets[4];
                results_arit.Cells[0, 0] = new Cell("UCRT Profiles for Aritmetical Grading");
                Worksheet results_ke_arit = book.Worksheets[5];
                results_ke_arit.Cells[0, 0] = new Cell("KE Profiles for Aritmetical Grading");
                Worksheet results_zcen_arit = book.Worksheets[6];
                results_zcen_arit.Cells[0, 0] = new Cell("Z Profiles for Aritmetical Grading");
                Worksheet results_tem1_arit = book.Worksheets[7];
                results_tem1_arit.Cells[0, 0] = new Cell("TEM1 Profiles for Aritmetical Grading");
                Worksheet results_tem1_geom = book.Worksheets[8];
                results_tem1_geom.Cells[0, 0] = new Cell("TEM1 Profiles for Geometrical Grading");
                Console.WriteLine("Total simulations in the excel :"+ numberOfEsperiments);
                for (int i = 0; i < numberOfEsperiments; i++)
                {
                  int todo = Convert.ToInt32(sheet.Cells[6, i + 1].Value);

                  if (todo == 0)
                  {
                      Console.WriteLine("Skipping case : " + i);
                  }

                  if( todo == 1 || todo == 2)
                  {
                    Console.WriteLine("Running case : " + i + " todo " + todo);
                    WSProject testcase = null;
                    WSProject testcase_arit = null;


                    bool restart = false;
                    string testCasetargetDirectory = excelBatchFile.Directory.FullName + "\\" + batteryName + "_" + sheet.Cells[7, i + 1].StringValue;
                    double z0_convergence_treshold = Convert.ToDouble(sheet.Cells[14, i + 1].Value);
                    int z0_convergence_sweeps = Convert.ToInt32(sheet.Cells[15, i + 1].Value);
                    int z0_cycles_to_be_checked = Convert.ToInt32(sheet.Cells[16, i + 1].Value);



                    int z0_monitoring_x = Convert.ToInt32(sheet.Cells[17, i + 1].Value);
                    int z0_monioring_y = Convert.ToInt32(sheet.Cells[18, i + 1].Value);
                    int skipArit = Convert.ToInt32(sheet.Cells[19, i + 1].Value); // 0 do both, 1 skip aritmeticsl grading
                    int nx = Convert.ToInt32(sheet.Cells[8, i + 1].Value);
                    int nj = Convert.ToInt32(sheet.Cells[9, i + 1].Value);
                    int verticalResolution = Convert.ToInt32(sheet.Cells[10, i + 1].Value);
                    float totalHeight = (float)Convert.ToDouble(sheet.Cells[11, i + 1].Value);

                    float roughness = (float)Convert.ToDouble(sheet.Cells[12, i + 1].Value);

                    double heithFirstLayerGeometrical = Convert.ToDouble(sheet.Cells[21, i + 1].Value);

                    RefinementGenerator.GeometricalGrading geom_refinement = new RefinementGenerator.GeometricalGrading(heithFirstLayerGeometrical, totalHeight, verticalResolution);

                    if (todo == 1) { 
                    
                    testcase = new WSProject(referenceProject.file.FullName, testCasetargetDirectory+"_geom");
                    testcase.load_parameters_from_excel(sheet);
                   
  
                    FileInfo gwsfile = new FileInfo(excelBatchFile.Directory.FullName + "\\gws_files\\" + sheet.Cells[13, i + 1].ToString());
                    testcase.parameters.CFD.Height = totalHeight;
                    testcase.parameters.DTM.Roughness = roughness;

                    testcase.save();
                    testcase.load_gws(gwsfile.FullName);


                    // run the case of geometrical grid..
                    
                    geom_refinement.Rectangle(testcase,"autogenerated_geometrical_bws_"+nx+"_"+nj, testcase.parameters.DTM.XMax,testcase.parameters.DTM.YMax,nx,nj);
                    
                    testcase.run(1);
                    }
                   else if (todo == 2) 
                    {
                       restart = true; 
                       z0_convergence_treshold = Convert.ToDouble(sheet.Cells[37, i + 1].Value);
                       z0_convergence_sweeps = Convert.ToInt32(sheet.Cells[38, i + 1].Value);
                       z0_cycles_to_be_checked = Convert.ToInt32(sheet.Cells[39, i + 1].Value);
                       FileInfo geometrico = new FileInfo(testCasetargetDirectory + "_geom\\" + referenceProject.file.Name);
                       testcase = new WSProject(geometrico.FullName);
                   }

                    Console.WriteLine("...G");
                    double[] z0results_geom = testcase.run_windfield_z0_conv(z0_convergence_treshold,z0_convergence_sweeps,z0_cycles_to_be_checked,z0_monitoring_x,z0_monioring_y, restart);
                    int resultRowShift = 0;
                    if (todo == 2) { resultRowShift = 21;}
                    #region write results geometrical

                    // write results
                    sheet.Cells[20 + resultRowShift, i + 1] = new Cell(geom_refinement.expansionFactor);
                    //height first cell
                    sheet.Cells[21 + resultRowShift, i + 1] = new Cell(geom_refinement.heightFirstLayer);
                    //z0
                    ////  { z0 , (u*/k) , sigma, r2 , sigmaz0 }
                    sheet.Cells[22 + resultRowShift, i + 1] = new Cell(z0results_geom[0]);
                    //sigma z0
                    sheet.Cells[23 + resultRowShift, i + 1] = new Cell(z0results_geom[4]);
                    //r2
                    sheet.Cells[24 + resultRowShift, i + 1] = new Cell(z0results_geom[3]);
                   
                    // add ustar
                    double ustar_geom = MyMath.ustar_neutral(testcase.parameters.WindField.VelocityBoundaryLayer, testcase.parameters.WindField.HeightBoundaryLayer, testcase.parameters.DTM.Roughness, 0.4);
                    if (testcase.parameters.WindField.Temperature == 1)
                    {
                        ustar_geom = MyMath.ustar_neutral(testcase.parameters.WindField.WindspeedInReferenceHeight, testcase.parameters.WindField.ReferenceHeight, testcase.parameters.DTM.Roughness, 0.4);
                    }
                    sheet.Cells[25 + resultRowShift, i + 1] = new Cell(ustar_geom);


                    //add the project to the dictionary  
 
                    book.Save(excelBatchFile.FullName);
                    #endregion 
                    #region write profiles geometrical

                    // write the profile in the profiles file
                    double[] profile_geom = testcase.WField[270].ucrt(z0_monitoring_x, z0_monioring_y);
                    double[] zcen_geom = testcase.WField[270].zcen(z0_monitoring_x, z0_monioring_y);
                    double[] profile_geom_ke = testcase.WField[270].ke(z0_monitoring_x, z0_monioring_y);
                    double[] theoretical_mo_neural_geom = MyMath.mo_neutral_u(zcen_geom, 0.4, ustar_geom, roughness);                   
                    double rmse_geom = MyMath.rmse(profile_geom, theoretical_mo_neural_geom);
                    sheet.Cells[26 + resultRowShift, i + 1] = new Cell(rmse_geom);

                    results_geom.Cells[1, i] = new Cell(i + 1);
                    results_zcen_geom.Cells[1, i] = new Cell(i + 1);
                    results_ke_geom.Cells[1, i] = new Cell(i + 1);
                    for (int count = 0; count < profile_geom.Length; count++)
                    {
                       results_geom.Cells[count+3, i] = new Cell(profile_geom[count]);
                       results_zcen_geom.Cells[count+3, i] = new Cell(zcen_geom[count]);
                       results_ke_geom.Cells[count + 3, i] = new Cell(profile_geom_ke[count]);
                    }
                    if (testcase.parameters.WindField.Temperature == 1)
                    {
                        double[] profile_geom_tem1 = testcase.WField[270].tem1(z0_monitoring_x, z0_monioring_y);
                        for (int count = 0; count < profile_geom.Length; count++)
                        {
                            results_tem1_geom.Cells[count + 3, i] = new Cell(profile_geom_tem1[count]);
                        }
                    }
                    book.Save(excelBatchFile.FullName);
                    #endregion


                    if (skipArit != 1)
                    {
                        Console.WriteLine("...A");
                        RefinementGenerator.AritmeticalGrading arit_refinement = new RefinementGenerator.AritmeticalGrading(geom_refinement.expansionFactor, geom_refinement.numbersOfVericalLayer, geom_refinement.totalHeight);
                        if (todo == 1)
                        {
                            // duplicate the project
                            testcase_arit = new WSProject(testcase.file.FullName, testCasetargetDirectory + "_arit");
                            // create the bws
                            // assign the bws
                            arit_refinement.Rectangle(testcase_arit, "autogenerated_aritmeical_bws_" + nx + "_" + nj, testcase_arit.parameters.DTM.XMax, testcase_arit.parameters.DTM.YMax, nx, nj);
                            // run terrain
                            testcase_arit.run(1);
                            // run the project
                        }
                        else if (todo == 2)
                        {
                            z0_convergence_treshold = Convert.ToDouble(sheet.Cells[37, i + 1].Value);
                            z0_convergence_sweeps = Convert.ToInt32(sheet.Cells[38, i + 1].Value);
                            z0_cycles_to_be_checked = Convert.ToInt32(sheet.Cells[39, i + 1].Value);
                            FileInfo aritmetico = new FileInfo(testCasetargetDirectory + "_arit\\" + referenceProject.file.Name);
                            testcase_arit = new WSProject(aritmetico.FullName);
                        }

                        double[] z0results_arit = testcase_arit.run_windfield_z0_conv(z0_convergence_treshold, z0_convergence_sweeps, z0_cycles_to_be_checked, z0_monitoring_x, z0_monioring_y, restart);

                        #region write resuls aritmetical

                        // write he results z0
                        sheet.Cells[28 + resultRowShift, i + 1] = new Cell(arit_refinement.heightDistributionFactor);
                        //height first cell
                        sheet.Cells[29 + resultRowShift, i + 1] = new Cell(arit_refinement.heightFirstLayer);
                        //z0
                        ////  { z0 , (u*/k) , sigma, r2 , sigmaz0 }
                        sheet.Cells[30 + resultRowShift, i + 1] = new Cell(z0results_arit[0]);
                        //sigma z0
                        sheet.Cells[31 + resultRowShift, i + 1] = new Cell(z0results_arit[4]);
                        //r2
                        sheet.Cells[32 + resultRowShift, i + 1] = new Cell(z0results_arit[3]);


                        // add ustar
                        double ustar_arit = MyMath.ustar_neutral(testcase_arit.parameters.WindField.VelocityBoundaryLayer, testcase_arit.parameters.WindField.HeightBoundaryLayer, testcase_arit.parameters.DTM.Roughness, 0.4);
                        if (testcase.parameters.WindField.Temperature == 1)
                        {
                            ustar_arit = MyMath.ustar_neutral(testcase_arit.parameters.WindField.WindspeedInReferenceHeight, testcase_arit.parameters.WindField.ReferenceHeight, testcase_arit.parameters.DTM.Roughness, 0.4);
                        }
                        sheet.Cells[25 + resultRowShift, i + 1] = new Cell(ustar_geom);

                        sheet.Cells[33 + resultRowShift, i + 1] = new Cell(ustar_arit);


                        //add the project to the dictionary   
                        book.Save(excelBatchFile.FullName);
                        #endregion

                        #region write profiles aritmetical

                        // write the profile in the profiles file
                        double[] profile_arit = testcase_arit.WField[270].ucrt(z0_monitoring_x, z0_monioring_y);
                        double[] zcen_arit = testcase_arit.WField[270].zcen(z0_monitoring_x, z0_monioring_y);
                        double[] profile_arit_ke = testcase_arit.WField[270].ke(z0_monitoring_x, z0_monioring_y);

                        // add rmse
                        double[] theoretical_mo_neural_arit = MyMath.mo_neutral_u(zcen_arit, 0.4, ustar_arit, roughness);
                        double rmse_arit = MyMath.rmse(profile_arit, theoretical_mo_neural_arit);
                        sheet.Cells[34 + resultRowShift, i + 1] = new Cell(rmse_arit);

                        results_arit.Cells[1, i] = new Cell(i + 1);
                        results_zcen_arit.Cells[1, i] = new Cell(i + 1);
                        results_ke_arit.Cells[1, i] = new Cell(i + 1);
                        for (int count = 0; count < profile_arit.Length; count++)
                        {
                            results_arit.Cells[count + 3, i] = new Cell(profile_arit[count]);
                            results_zcen_arit.Cells[count + 3, i] = new Cell(zcen_arit[count]);
                            results_ke_arit.Cells[count + 3, i] = new Cell(profile_arit_ke[count]);

                        }

                        if (testcase.parameters.WindField.Temperature == 1)
                        {
                            double[] profile_arit_tem1 = testcase_arit.WField[270].tem1(z0_monitoring_x, z0_monioring_y);
                            for (int count = 0; count < profile_arit.Length; count++)
                            {
                                results_tem1_arit.Cells[count + 3, i] = new Cell(profile_arit_tem1[count]);
                            }
                        }
                        book.Save(excelBatchFile.FullName);
                        //add the project to the dictionary    
                        #endregion
                    }

                 }
                }
              }


            else
            {
                throw new System.ArgumentException("Some error occurred regarding the excel file");
            }

        }
    }

    public class AskerveinBatch : ExcelBatch 
    {
        private bool _readyToRun;
        public bool readyToRun
        {
            get { return _readyToRun; }
        }

        int numberOfSimulations;
        int numberOfSensors;
        static Anemometer[] sensors;
        List<AskerveinSimulation> simulations = new List<AskerveinSimulation>();
        public static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        public string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        private FileInfo referenceProject;

        private FileInfo excelBatchFile;

        private DirectoryInfo _batteryDirectory;
        public DirectoryInfo batteryDirectory
        {
            get { return _batteryDirectory; }
        }
        private FileGws _fileGws;
        public FileGws fileGws
        {
            get { return _fileGws; }

        }


        public class AskerveinSimulation 
        {
            private int _index;
            public int index
            {
                get { return _index; }
            }
            private double _ConvThreshold;
            public double ConvThreshold
            {
                get { return _ConvThreshold; }
            }          
            private int _ConvSweeps;
            public int ConvSweeps
            {
                get { return _ConvSweeps; }
            }
            private int _ConvCycleToBeChecked;
            public int ConvCycleToBeChecked
            {
                get { return _ConvCycleToBeChecked; }
            }
            private int _ConvMaxCycles;
            public int ConvMaxCycles
            {
                get { return _ConvMaxCycles; }
            }
            private bool _ConvRestart;
            public bool ConvRestart
            {
                get { return _ConvRestart; }
            }
            private double _GridThreshold;
            public double GridThreshold
            {
                get { return _GridThreshold; }
            }
            private double _GridIXmin;
            public double GridIXmin
            {
                get { return _GridIXmin; }
            }
            private double _GridIXmax;
            public double GridIXmax
            {
                get { return _GridIXmax; }
            }
            private double _GridIYmin;
            public double GridIYmin
            {
                get { return _GridIYmin; }
            }
            private double _GridIYmax;
            public double GridIYmax
            {
                get { return _GridIYmax; }
            }
            private int _GridIXcells;
            public int GridIXcells
            {
                get { return _GridIXcells; }
            }
            private int _GridIYcells;
            public int GridIYcells
            {
                get { return _GridIYcells; }
            }
            private double _GridTotalH;
            public double GridTotalH
            {
                get { return _GridTotalH; }
            }
            private int _GridNumOfLayer;
            public int GridNumOfLayer
            {
                get { return _GridNumOfLayer; }
            }
            private int _excelColumn;
            public int excelColumn
            {
                get { return _excelColumn; }
            }
            private WSProject _project;
            public WSProject project
            {
                get { return _project; }
            }
            private FileGws _fileGWS;
            public FileGws fileGWS
            {
                get { return _fileGWS; }
            }
            private bool _bwsDone;
            public bool bwsDone
            {
                get { return _bwsDone; }
            }
            private bool _gwsDone;
            public bool gwsDone
            {
                get { return _gwsDone; }
            }


            private AskerveinSimulationResults _result;
            public AskerveinSimulationResults result
            {
                get { return _result; }
            }
            public AskerveinSimulation(FileInfo reference_project, FileInfo excelFile, FileGws fileGws, int numberOfAnemometers, int index, double ConvThreshold, int ConvSweeps, int ConvCycleToBeChecked, int ConvMaxCycles, bool ConvRestart, double GridThreshold, double GridIXmin, double GridIXmax, double GridIYmin, double GridIYmax, int GridIXcells, int GridIYcells, double GridTotalH, int GridNumOfLayer, int excelColumn) 
            {
                
                _fileGWS = fileGws;

                //_anemometersSpeeds = new double[numberOfAnemometers];
                _index = index;
                _ConvThreshold = ConvThreshold;
                _ConvSweeps = ConvSweeps;
                _ConvCycleToBeChecked = ConvCycleToBeChecked;
                _ConvMaxCycles = ConvMaxCycles;
                _ConvRestart = ConvRestart;
                _GridThreshold = GridThreshold;
                _GridIXmin = GridIXmin;
                _GridIXmax = GridIXmax;
                _GridIYmin = GridIYmin;
                _GridIYmax = GridIYmax;
                _GridIXcells = GridIXcells;
                _GridIYcells = GridIYcells;
                _GridTotalH = GridTotalH;
                _GridNumOfLayer = GridNumOfLayer;
                _excelColumn = excelColumn;

                
                string projectDirectoryName = excelFile.Directory.FullName + "\\"+ index + "_" + GridIXcells.ToString() + "_" + GridIYcells.ToString() + "\\";
                _project = new WSProject(reference_project.FullName, projectDirectoryName);
                _gwsDone = project.load_gws(fileGWS.filepath);
                //project.parameters.CFD.RefinementFileName
                AutomaticGrid.Geometrical automaticGrid = new AutomaticGrid.Geometrical(fileGWS,GridThreshold,GridIXmin,GridIXmax,GridIYmin, GridIYmax, GridIXcells,GridIYcells,GridTotalH,GridNumOfLayer);
                string bwsFileName = "bws_" + GridIXcells.ToString() + "_" + GridIYcells.ToString() + ".bws";
                // salvo il file bws
                _bwsDone = automaticGrid.SaveToBws(project, bwsFileName);

                _result = new AskerveinSimulationResults(this);
            }

            public bool run() 
            {
                
               // try
               // {
                    
                    if (result.readyToRun)
                    {
                          project.run(1);
                          this.result.AddConvergence(project.run_windfield_askervein_conv(ConvThreshold, ConvSweeps, ConvCycleToBeChecked, ConvRestart, sensors, ConvMaxCycles));
                          return true;
                    }
                    else
                    {
                        return false;
                    }

                //}
                //catch (Exception e)
                //{
                //    this.result.messaggi.Add(e.ToString());
                //    return false;
                //}
            }


            public string name 
            {
                get { return index.ToString(); } 
            }
        }

        public class AskerveinSimulationResults
        {
            private bool _readyToRun;
            public bool readyToRun
            {
                get { return _readyToRun; }
            }

            private List<string> _messaggi = new List<string>();
            public List<string> messaggi 
            {
                get { return _messaggi; }
            }

            private AskerveinConvergenceResult _convergence;
            public AskerveinConvergenceResult convergence
            {
                get { return _convergence; }
            }

            public AskerveinSimulationResults(AskerveinSimulation sim)
            {

                if (!sim.project.file.Exists) _messaggi.Add("Project file do not exists!");
                if (sensors.Length == 0) _messaggi.Add("No sensors found!");
                if (sim.ConvThreshold <= 0) _messaggi.Add("ConvThreshold <= 0!");
                if (sim.ConvSweeps <= 0) _messaggi.Add("ConvSweeps <= 0!");
                if (sim.ConvCycleToBeChecked <= 0) _messaggi.Add("ConvCycleToBeChecked <= 0!");
                if (sim.ConvMaxCycles < sim.ConvCycleToBeChecked) _messaggi.Add("ConvMaxCycles < ConvCycleToBeChecked!");
                if (sim.GridThreshold <= 0) _messaggi.Add("GridThreshold <= 0!");
                if (sim.GridIXmin < sim.fileGWS.xmin) _messaggi.Add("GridIXmin < fileGWS.xmin !");
                if (sim.GridIXmax > sim.fileGWS.xmax) _messaggi.Add("GridIXmax > fileGWS.xmin !");
                if (sim.GridIYmin < sim.fileGWS.ymin) _messaggi.Add("GridIYmin < fileGWS.ymin !");
                if (sim.GridIYmax > sim.fileGWS.ymax) _messaggi.Add("GridIYmax > fileGWS.ymin !");
                if (!sim.gwsDone) _messaggi.Add("gws not loaded, some problem occourred!");
                if (!sim.bwsDone) _messaggi.Add("bws not saved, some problem occourred!");
                if (_messaggi.Count == 0) { 
                                            _readyToRun = true; 
                                         }
                else { _readyToRun = false; }

            }
            public void AddConvergence(AskerveinConvergenceResult convergenceRun) 
            {
                _convergence = convergenceRun;
            }
        }

        public AskerveinBatch(FileInfo excelBatchFileInput)
        {
            excelBatchFile = excelBatchFileInput;

            // controllo l-esistenza del file excel  

            Workbook book = Workbook.Load(excelBatchFile.FullName);
            Worksheet sheet = book.Worksheets[0];
            numberOfSimulations = Convert.ToInt32(sheet.Cells[0, 0].Value);
            numberOfSensors = Convert.ToInt32(sheet.Cells[1, 0].Value);
            referenceProject = new FileInfo(sheet.Cells[2, 0].Value.ToString());
            _batteryDirectory = new DirectoryInfo(sheet.Cells[3, 0].Value.ToString());
            FileInfo fileGws_fileinfo = new FileInfo(sheet.Cells[4, 0].Value.ToString());

            int checkFiles = 0;

            if (referenceProject.Exists)
            {
                Console.WriteLine("Reference project file found.");
                checkFiles++;
            }
            else
            {
                Console.WriteLine("Reference project file do not exist !");
            }


            if (fileGws_fileinfo.Exists)
            {
                Console.WriteLine("Gws file found.");
                try
                    {
                        ParseManager parser = new ParseManager();
                        _fileGws = parser.ParseGws(fileGws_fileinfo.FullName);
                        checkFiles++;
                    }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e);
                }

            }
            else 
            {
                Console.WriteLine("FileGws file do not exist !");           
            }

            if (batteryDirectory.Exists) 
            {
                Console.WriteLine("Battery directory found.");
                checkFiles++;
            } 
            else 
            {
                Console.WriteLine("Battery directory do not exist!");
            }

            if (checkFiles == 3)
            {
                Console.WriteLine("Project ready to run.");
                _readyToRun = true;
            }
            else 
            {
                Console.WriteLine("Above problems occurred, check before run");
                _readyToRun = false;
            }

            sensors = new Anemometer[numberOfSensors];

            if (readyToRun)
            {
                for (int i = 0; i < numberOfSensors; i++)
                {
                    int row = 20 + i;
                    Anemometer anemometro = new Anemometer(i, sheet.Cells[row, 1].StringValue, sheet.Cells[row, 2].StringValue, Convert.ToDouble(sheet.Cells[row, 3].Value), Convert.ToDouble(sheet.Cells[row, 4].Value), Convert.ToDouble(sheet.Cells[row, 5].Value), row);
                    sensors[i] = anemometro;
                }

                for (int i = 0; i < numberOfSimulations; i++)
                {
                    int column = 6 + i;

                    double ConvThreshold = Convert.ToDouble(sheet.Cells[1, column].Value);
                    int ConvSweeps = Convert.ToInt32(sheet.Cells[2, column].Value);
                    int ConvCycleToBeChecked = Convert.ToInt32(sheet.Cells[3, column].Value);
                    int ConvMaxCycles = Convert.ToInt32(sheet.Cells[4, column].Value);
                    bool ConvRestart = Convert.ToBoolean(sheet.Cells[5, column].Value);

                    double GridThreshold = Convert.ToDouble(sheet.Cells[7, column].Value);
                    double GridIXmin = Convert.ToDouble(sheet.Cells[8, column].Value);
                    double GridIXmax = Convert.ToDouble(sheet.Cells[9, column].Value);
                    double GridIYmin = Convert.ToDouble(sheet.Cells[10, column].Value);
                    double GridIYmax = Convert.ToDouble(sheet.Cells[11, column].Value);
                    int GridIXcells = Convert.ToInt32(sheet.Cells[12, column].Value);
                    int GridIYcells = Convert.ToInt32(sheet.Cells[13, column].Value);
                    double GridTotalH = Convert.ToDouble(sheet.Cells[14, column].Value);
                    int GridNumOfLayer = Convert.ToInt32(sheet.Cells[15, column].Value);

                    AskerveinSimulation simulation = new AskerveinSimulation(referenceProject, excelBatchFile, _fileGws, numberOfSensors, i, ConvThreshold, ConvSweeps, ConvCycleToBeChecked, ConvMaxCycles, ConvRestart, GridThreshold, GridIXmin, GridIXmax, GridIYmin, GridIYmax, GridIXcells, GridIYcells, GridTotalH, GridNumOfLayer, column);
                    simulations.Add(simulation);
                }




                // per ogni simulazione creo un progetto e lo assegno

                simulations.ForEach(
                         delegate(AskerveinSimulation sim)
                         {
                             
                             
                             Console.WriteLine("sim " + sim.name + " - " + "running ");
                             if (sim.run()) 
                             {
                                 Console.WriteLine("sim " + sim.name + " - " + " done.");
                                 // scrivo i risultati in excel
                                 for (int i = 0; i < sim.result.convergence.sensors.Length; i++) 
                                 {
                                     sheet.Cells[sim.result.convergence.sensors[i].excelRow, sim.excelColumn] = new Cell(sim.result.convergence.speeds[i]);
                                 } 
                            
                                 // salvo l'excel
                                 book.Save(excelBatchFile.FullName);
                                 Console.WriteLine("sim " + sim.name +" - "+ "result saved in the excel file" );

                             } 
                             else 
                             {
                                 Console.WriteLine("sim " + sim.name + " - " + "some problem occourred");
                                 sim.result.messaggi.ForEach(delegate(string mess) { Console.WriteLine(mess); });
                                 sim.result.convergence.messaggi.ForEach(delegate(string mess) { Console.WriteLine(mess); });
                             }

                         }
                         );



            }

        
        }








    }

  }

  public class Anemometer
  {
      private int _index;
      private string _name, _sensorName;
      private double _x, _y, _height;
      private int _excelRow;
      
      public int index
      {
          get { return _index; }
      }

      public string name
      {
          get { return _name; }
      }
      public string sensorName
      {
          get { return _sensorName; }
      }
      public double x
      {
          get { return _x; }
      }
      public double y
      {
          get { return _y; }
      }
      public double height
      {
          get { return _height; }
      }
      public int excelRow
      {
          get { return _excelRow; }
      }

      public Anemometer(int index, string name, string sensorName, double x, double y, double height, int excelRow)
      {
          _name = name;
          _sensorName = sensorName;
          _x = x;
          _y = y;
          _height = height;
          _excelRow = excelRow;
      }
  }

  

}
