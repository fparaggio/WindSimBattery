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
using System.Globalization;

namespace WindSim.Batch.Core
{
    public class XYZFile
    {
        public double[,,,] values;
        public int ni, nj, nk;
        FileInfo FileName;
        public XYZFile(string filename)
        {
            if (File.Exists(filename))
            {
                FileName = new FileInfo(filename);
                using (TextReader tr = new StreamReader(filename))
                {
                    string first_row = tr.ReadLine();
                    ni = Convert.ToInt32(first_row.Substring(0, 5).Replace(" ", ""));
                    nj = Convert.ToInt32(first_row.Substring(5, 5).Replace(" ", ""));
                    nk = Convert.ToInt32(first_row.Substring(10, 5).Replace(" ", ""));
                    string line;
                    int element = 0;
                    
                    values = new double[ni, nj, nk, 3];
                    int ni_index = 0;
                    int nj_index = 0;
                    int nk_index = 0;
                    int xyz_index = 0;
                    bool close_loop = false;
                    while ((line = tr.ReadLine()) != null)
                    {
                        for (element = 0; element < 5; element++)
                        {

                            values[ni_index, nj_index, nk_index, xyz_index] = double.Parse(line.Substring(13 * element, 13), CultureInfo.InvariantCulture);
                                nj_index++;

                                if (nj_index == nj) 
                                {
                                    nj_index = 0;
                                    ni_index++;
                            
                                    if (ni_index == ni)
                                    {
                                        ni_index = 0;
                                        
                                        xyz_index++;
                                            if (xyz_index == 3) 
                                            {
                                                xyz_index=0;
                                                nk_index++;
                                                if (nk_index == nk) 
                                                {
                                                    close_loop = true;
                                                }
                                                break;
                                            }
                                            break;
                                     
                                    }
                                    //break;
                                    
                                }
                            
                            if (close_loop) break;
                        }
                        if (close_loop) break;
                    }

                }
            }
        }

        private bool Equal_dimensions(XYZFile other)//(object obj) 
        {
            return (FileName.FullName == other.FileName.FullName) &&
                   (ni == other.ni) &&
                   (nj == other.nj) &&
                   (nk == other.nk);
        }

        public bool Equals(XYZFile other)
        {
            int err = 0;
            if (this.Equal_dimensions(other)) 
            {
                for (int i = 0; i < ni; i++) 
                {
                    for (int j = 0; j < nj; j++)
                    {
                        for (int k = 0; k < nk; k++)
                        {
                            for (int var = 0; var < 3; var++) 
                            {
                                if (values[i, j, k, var] != other.values[i, j, k, var]) { err++; }
                            }
                        }
                    }
                }

                

            } 
            else 
            {
                err++; 
            }

            if (err == 0) { return true; } else { return false; }
        }
    }

    public class XYZObject
    {
        private double _x, _y, _z;

        public double X
        {
            get { return _x; }
        }
        public double Y
        {
            get { return _y; }
        } 
        public double Z
        {
            get { return _z; }
        }

        public XYZObject(double x, double y, double z) 
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double[] toArray() 
        {
            return new double[] { X, Y, Z };
        }
    }
}
