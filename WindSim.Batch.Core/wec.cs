using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindSim.Batch.Core
{
    public class Layout
    {
        public Wec[] wecs;
        public string file;
        
        // contructor
        public Layout(string layout_file, DirectoryInfo project_dir) 
        {
            file = layout_file; 

            //parse profile data 
            DirectoryInfo directory = new DirectoryInfo(project_dir.FullName + "\\"+ Path.GetFileNameWithoutExtension(layout_file));
            string profile_file = directory.FullName + @"\report\vertical_profile_wecs.dat";
            if (File.Exists(profile_file))
            {
                // check ow many turbines and sectors

                using (TextReader tr = new StreamReader(profile_file))
                {
                    string line;
                    int turbine = 0;
                    int sectors = 0;
                    while ((line = tr.ReadLine()) != null)
                    {
                        if (line.StartsWith("WECS number        :"))
                        {
                            turbine++;

                            if (turbine == 1) 
                            { 

                                // dovrei contare i settori...
                            }
                        }
                    }
                    if(turbine != 0) 
                    {
                        wecs = new Wec[turbine];
                    }
                }








            }
 
        }

    }


    public class Wec
        {
            //WECS number        :          1
            //WECS name          : A
            //Manufacturer       : windsim
            //Type               : ws2000
            //Nominal effect     :       2000
            //Hub height         :      200.0
            //x (local)          :      200.0
            //y (local)          :       50.0
            //x (global)         :      200.0
            //y (global)         :       50.0


            public int number;
            public string name;
            public string Manufacturer;
            public string type;
            public long nominal_effect;
            public double hub_height;
            public double x_local;
            public double y_local;
            public double x_global;
            public double y_global;

            //sector:   270
            //  k       z-coord        UCRT         VCRT         WCRT      Speed_2D       Inflow        Shear    Shear_low   Shear_high           KE           TI        alpha
            // (-)        (m)          (m/s)        (m/s)        (m/s)        (m/s)        (deg)        (1/s)        (1/s)        (1/s)    (m*2/s*2)          (%)          (-)
            //   1        0.010        0.575        0.000        0.000        0.575        0.000       47.516       57.516       43.813        0.386      124.693        0.826
            //  17      166.317        8.981        0.000        0.005        8.981        0.035         -           0.007         -           0.200        5.749         -   

            ///public Sector[] sect = new Sector[];
        }

    public class Sector
        {
            //sector:   270
            double dir;

            //  k       z-coord        UCRT         VCRT         WCRT      Speed_2D       Inflow        Shear    Shear_low   Shear_high           KE           TI        alpha
            string[] name;

            // (-)        (m)          (m/s)        (m/s)        (m/s)        (m/s)        (deg)        (1/s)        (1/s)        (1/s)    (m*2/s*2)          (%)          (-)
            string[] unit;

            //   1        0.010        0.575        0.000        0.000        0.575        0.000       47.516       57.516       43.813        0.386      124.693        0.826
            //  17      166.317        8.981        0.000        0.005        8.981        0.035         -           0.007         -           0.200        5.749         -   
            double[,] val;

        }
    
   
}



