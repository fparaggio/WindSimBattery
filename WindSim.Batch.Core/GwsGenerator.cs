using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindSim.Batch.Core
{
    public class GwsGenerator
    {
        public void plane(int cell_x, int cell_y, double ext_x, double ext_y) 
        {
            string name = cell_x + "_" + cell_y + "_" + ext_x + "_" + ext_y;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("WindSim version    : 430");
            sb.AppendLine("");
            sb.AppendLine("area name          : "+name);
            sb.AppendLine("");
            sb.AppendFormat("{0,21}{1,12}{2,12}{3}", "#nodes nxp nyp     : ", cell_x + 1, cell_y + 1, Environment.NewLine);
            sb.AppendLine("");
            sb.AppendLine("co-ordinate system :            3");
            sb.AppendLine("");
            sb.AppendFormat("{0,21}{1,12:0.0}{2,12:0.0}{3}", "ext. xmin xmax     : ", 0, ext_x, Environment.NewLine);
            sb.AppendFormat("{0,21}{1,12:0.0}{2,12:0.0}{3}", "ext. ymin ymax     : ", 0, ext_y, Environment.NewLine);
            sb.AppendLine("ext. zmin zmax     :          0.0         0.0");
            sb.AppendLine("");
            sb.AppendLine("HEIGHT             :");
            double cicli = Math.Floor((cell_x+1)/10.0);
            double resto = (cell_x+1)%10;
            for (int i = 0; i < cell_y+1; i++) 
            {
                sb.AppendFormat("{0,10}{1}", i+1, Environment.NewLine);
                
                for (int a = 0; a < cicli; a++)
                {                
                sb.AppendLine("  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00");
                }
                if (resto == 1) sb.AppendLine("  0.000000E+0");
                if (resto == 2) sb.AppendLine("  0.000000E+00  0.000000E+00");
                if (resto == 3) sb.AppendLine("  0.000000E+00  0.000000E+00  0.000000E+00");
                if (resto == 4) sb.AppendLine("  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00");
                if (resto == 5) sb.AppendLine("  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00");
                if (resto == 6) sb.AppendLine("  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00");
                if (resto == 7) sb.AppendLine("  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00");
                if (resto == 8) sb.AppendLine("  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00");
                if (resto == 9) sb.AppendLine("  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00  0.000000E+00");
            }

            File.WriteAllText( "c:\\gws_fra\\" + name + ".gws", sb.ToString());    
        }
    }
}
