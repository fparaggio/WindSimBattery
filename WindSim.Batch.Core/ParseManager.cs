﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace WindSim.Batch.Core
{
    public class ParseManager
    {
        
        
        public FileGws ParseGws(string filepath)
        {
   
            FileGws gws=null;
            if (File.Exists(filepath))
            {
                
                
                using (TextReader tr = new StreamReader(filepath))
                {
                    string line="";

                    bool header = true;
                        //                                               ! comments not belonging to the format
                        //WindSim version    : 430                       ! mandatory; .gws format version
                        //area name          : demo                      ! optional;  area name
                        //#nodes nxp nyp     : 21  11                    ! mandatory; number of nodes in west-east and north-south direction
                        //co-ordinate system : 3                         ! mandatory; co-ordinate system: (1)local, (3)global
                        //ext. xmin xmax     :  975000.0    977000.0     ! mandatory; min. and max extension in east-west direction
                        //ext. ymin ymax     : 7915000.0   7916000.0     ! mandatory; min. and max extension in north-south direction
                        //ext. zmin zmax     :       0.0         0.0     ! optional;  min. and max extension in vertical-direction
                        //
                        //HEIGHT             :
                        //
                    string windSimversion="", areaname="";
                    int nxp=0, nyp=0, coordinatesystem=0;
                    double xmin=0.0, xmax=0.0, ymin=0.0, ymax=0.0;
                    while (header) 
                    {
                        line = tr.ReadLine();
                        string uncommented = line.Split('!')[0];
                        string a = "";
                        
                        if (uncommented.Replace(" ", "").Length > 0) 
                        {
                            a = uncommented.Substring(0, 20).Replace(" ", "").Replace(":", "");
                            if (a == "WindSimversion") { windSimversion = uncommented.Substring(21, uncommented.Length - 21).Replace(" ", ""); }
                            else if (a == "areaname") { areaname = uncommented.Substring(21, uncommented.Length - 21).Trim(); }
                            else if (a == "#nodesnxpnyp") 
                                                        {
                                                            string[] nodesnxpnyp = Regex.Split(uncommented.Substring(21, uncommented.Length - 21).Trim(), @"\D+");  
                                                            nxp = Convert.ToInt32(nodesnxpnyp[0]);
                                                            nyp = Convert.ToInt32(nodesnxpnyp[1]);
                                                        }
                            else if (a == "co-ordinatesystem") {
                                coordinatesystem = Convert.ToInt32(uncommented.Substring(21, uncommented.Length - 21).Trim());
                                                               }
                            else if (a == "ext.xminxmax") {

                                string[] xminxmax = Regex.Split(uncommented.Substring(21, uncommented.Length - 21).Trim(), @"[^\d.-]+");
                                xmin = double.Parse(xminxmax[0], CultureInfo.InvariantCulture);
                                xmax = double.Parse(xminxmax[1], CultureInfo.InvariantCulture);

                            }
                            else if (a == "ext.yminymax") 
                            {
                                string[] yminymax = Regex.Split(uncommented.Substring(21, uncommented.Length - 21).Trim(), @"[^\d.-]+");
                                ymin = double.Parse(yminymax[0], CultureInfo.InvariantCulture);
                                ymax = double.Parse(yminymax[1], CultureInfo.InvariantCulture);
    

                            }
                            //else if (a == "ext.zminzmax") { }
                            //  #nodes nxp nyp
                            else if (a == "HEIGHT") header = false;
                        }

          
                                             
                    }
                    //Inizializzo il file con le dimensioni ed i parametri...
                    gws = new FileGws(nxp, nyp, xmin, xmax, ymin, ymax, windSimversion, areaname, coordinatesystem, filepath);
                    //Riempo l'array delle height..
                    double nxrows = nxp / 10.0;
                    int nx_index = 0, ny_index = 0;

                    for (ny_index = 0; ny_index < nyp; ny_index++) 
                    {
                        line = tr.ReadLine();
                        for (int nxrow = 0; nxrow < Math.Ceiling(nxrows); nxrow++) 
                        {
                            line = tr.ReadLine();
                            for (int element = 0; element < 10 && nx_index < nxp ; element++) 
                            {
                                GwsNode node = new GwsNode();

                                node.height = double.Parse(line.Substring(14 * element, 14).Trim(), CultureInfo.InvariantCulture);
                                
                                gws.data[nx_index,ny_index] = node;
                                nx_index++;
                            }
                        }
                        
                        nx_index = 0;
                    }

                    line = tr.ReadLine();
                    //Riempo l'array delle roughness
                    for (ny_index = 0; ny_index < nyp; ny_index++)
                    {
                        line = tr.ReadLine();
                        for (int nxrow = 0; nxrow < Math.Ceiling(nxrows); nxrow++)
                        {
                            line = tr.ReadLine();
                            for (int element = 0; element < 10 && nx_index < nxp; element++)
                            {

                                gws.data[nx_index, ny_index].rough = double.Parse(line.Substring(14 * element, 14).Trim(), CultureInfo.InvariantCulture);
                                 
                                nx_index++;
                            }
                        }

                        nx_index = 0;
                    }
                  
                }
            }


            return gws;
        
        
        }


    }
}
