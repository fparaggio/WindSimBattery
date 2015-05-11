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
