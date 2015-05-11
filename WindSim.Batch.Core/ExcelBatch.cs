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
    public class ExcelBatch
    {
        public WSProject referenceProject;
        public FileInfo excelBatchFile;
        public DirectoryInfo batchDirectory;
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
        
        public ExcelBatch(WSProject referenceProject, FileInfo excelBatchFile)
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
                    #region read batch case parameters
  
                    FileInfo gwsfile = new FileInfo(excelBatchFile.Directory.FullName + "\\gws_files\\" + sheet.Cells[12, i + 1].ToString());
                    testcase.parameters.CFD.Height = totalHeight;
                    testcase.parameters.DTM.Roughness = roughness;

                    testcase.save();
                    testcase.load_gws(gwsfile.FullName);
                    // run the case of geometrical grid..
                    
                    geom_refinement.Rectangle(testcase,"autogenerated_geometrical_bws_"+nx+"_"+nj, testcase.parameters.DTM.XMax,testcase.parameters.DTM.YMax,nx,nj);
                    #endregion
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
                    
                    double[] z0results_arit = testcase_arit.run_windfield_z0_conv(z0_convergence_treshold, z0_convergence_sweeps, z0_cycles_to_be_checked, z0_monitoring_x, z0_monioring_y,restart);

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
                        results_arit.Cells[count+3, i] = new Cell(profile_arit[count]);
                        results_zcen_arit.Cells[count+3, i] = new Cell(zcen_arit[count]);
                        results_ke_arit.Cells[count+3, i] = new Cell(profile_arit_ke[count]);
                      
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


            else
            {
                throw new System.ArgumentException("Some error occurred regarding the excel file");
            }

        }
    }
}
