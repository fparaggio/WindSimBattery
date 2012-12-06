using System;
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
            NumberStyles floatdataFormat = NumberStyles.AllowLeadingSign | NumberStyles.AllowExponent | NumberStyles.AllowLeadingWhite | NumberStyles.AllowDecimalPoint;
            NumberStyles floatdecimalFormat = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
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
                            if (a == "WindSimversion") { windSimversion = uncommented.Substring(21, a.Length).Replace(" ", ""); }
                            else if (a == "areaname") { areaname = uncommented.Substring(21, a.Length); }
                            else if (a == "#nodesnxpnyp") 
                                                        {
                                                            string[] nodesnxpnyp = Regex.Split(uncommented.Substring(21, a.Length).Trim(), @"\D+");  
                                                            nxp = Convert.ToInt32(nodesnxpnyp[0]);
                                                            nyp = Convert.ToInt32(nodesnxpnyp[1]);
                                                        }
                            else if (a == "co-ordinatesystem") {
                                coordinatesystem = Convert.ToInt32(uncommented.Substring(21, a.Length).Trim());
                                                               }
                            else if (a == "ext.xminxmax") {
                                xmin = Double.Parse(uncommented.Substring(21, 10).Trim(), floatdecimalFormat);
                                xmax = Double.Parse(uncommented.Substring(31, 10).Trim(), floatdecimalFormat);
                            }
                            else if (a == "ext.yminymax") 
                            {
                                ymin = Double.Parse(uncommented.Substring(21, 10).Trim(), floatdecimalFormat);
                                ymax = Double.Parse(uncommented.Substring(31, 10).Trim(), floatdecimalFormat);

                            }
                            //else if (a == "ext.zminzmax") { }
                            //  #nodes nxp nyp
                            else if (a == "HEIGHT") header = false;
                        }

          
                                             
                    }
                    //Inizializzo il file con le dimensioni ed i parametri...
                    gws = new FileGws(nxp, nyp, xmin, xmax, ymin, ymax, windSimversion, areaname, coordinatesystem);
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
                                node.height = Double.Parse(line.Substring(14 * element, 14), floatdataFormat);
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

                                gws.data[nx_index, ny_index].rough = Double.Parse(line.Substring(14 * element, 14), floatdataFormat);
                                 
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
