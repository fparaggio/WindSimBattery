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
    public class WindField
    {
        public PhiFile phi=null;
        public XYZFile xyz=null;

        public double[] ucrt(int x_cell, int y_cell)
        {
            int ucrt_index = Array.IndexOf(phi.variables_name, "UCRT");
            double[] arr = new double[phi.z_high_cell_face.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = phi.vars_phi[x_cell-1, y_cell-1, i, ucrt_index];
            }
            return arr;
        }

        public double[] ke(int x_cell, int y_cell)
        {
            int ke_index = Array.IndexOf(phi.variables_name, "KE");
            double[] arr = new double[phi.z_high_cell_face.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = phi.vars_phi[x_cell - 1, y_cell - 1, i, ke_index];
            }
            return arr;
        }

        public double[] tem1(int x_cell, int y_cell)
        {
            int tem1_index = Array.IndexOf(phi.variables_name, "TEM1");
            double[] arr = new double[phi.z_high_cell_face.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = phi.vars_phi[x_cell - 1, y_cell - 1, i, tem1_index];
            }
            return arr;
        }

        public double[] zcen(int x_cell, int y_cell)
        {
            double[] arr = new double[phi.z_high_cell_face.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                double zcen_i =   xyz.values[x_cell-1, y_cell-1, i, 2] + ( (xyz.values[x_cell-1, y_cell-1, i+1, 2] -  xyz.values[x_cell-1, y_cell-1, i, 2]) / 2);        
                arr[i] = zcen_i;
            }
            return arr;
        }


        public double[] z0(int x, int y, double maxHeight = 10.0, double r2Threshold = 0.95)
        {
            double[] arr = MyMath.LeastSquaresBestFitLine(this.zcen_log(x, y), this.ucrt(x, y));;

            if (maxHeight > 0)
            {
                int i = this.zcen_log(x, y).Length;
                while (MyMath.LeastSquaresBestFitLine(this.zcen_log(x, y).Take(i).ToArray(), this.ucrt(x, y).Take(i).ToArray())[0] > r2Threshold && this.zcen_log(x, y).Take(i).Max() > maxHeight)
                {
                    arr = MyMath.LeastSquaresBestFitLine(this.zcen_log(x, y).Take(i).ToArray(), this.ucrt(x, y).Take(i).ToArray());
                    i--;
                }
            }

         //{ BbestfitYintercept, AbestfitSlope, sigma, r_2, BsigmaIntercept, AsigmaSlope };
         double A = arr[1];
         double B = arr[0];
         double z0 = Math.Exp(-1 * B / A);
         double sigmaA = arr[5];
         double sigmaB = arr[4];
         double sigmaz0 = z0 * ((B / A) * ((sigmaB / B) + (sigmaA / A)));
         
            //  it returns following values
            //  { z0 , (u*/k) , sigma, r2 , sigmaz0 } 
         double[] result = {z0, A, arr[2], arr[3], sigmaz0 };
         return result;
        }

        public double[] zcen_log(int x,int y)
        {
 	    double[] zcen = this.zcen(x,y);
        double[] arr = new double[zcen.Length];
            for (int i = 0; i < zcen.Length; i++)
            {
            arr[i] = Math.Log(zcen[i]);
            }
            return arr;
        }

        //        public double ucrt(int x, int y, int z)
        //{
        //    int ucrt_index = Array.IndexOf(variables_name, "UCRT");
        //    return vars_phi[x, y, z, ucrt_index];
        //}

        //public double[] ucrt(int x, int y)
        //{
        //    ///inserire exeptions
            
        //    int ucrt_index = Array.IndexOf(variables_name, "UCRT");
        //    double[] arr = new double[z_high_cell_face.Length];
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        arr[i] = vars_phi[x, y, i, ucrt_index];
        //    }
        //    return arr;
        //}

        ////public double z0(int x, int y)
        ////{
        ////    int len = z_high_cell_face.Length;
        ////    double[] logz = new double[len];
        ////    double[] u = ucrt(x, y);
        ////    for (int i = 0; i < len; i++)
        ////    {
        ////        double zcen;
        ////        if (i == 0) zcen = z_high_cell_face[i] / 2;
        ////        else zcen = z_high_cell_face[i] - z_high_cell_face[i - 1];
        ////        logz[i] = Math.Log(zcen);
        ////    }

        ////}

        public WindField(WSProject project ,int settore) 
        
        {
            // inistialize phi and xyz

            string  phi_file = project.file.DirectoryName + "\\windfield\\" + settore + "_red.phi";
            string  xyz_file = project.file.DirectoryName + "\\windfield\\" + settore + "_red.xyz";
            
            FileInfo phi_file_check = new FileInfo(phi_file);
            FileInfo xyz_file_check = new FileInfo(xyz_file);

            // check if required files exists

            if (phi_file_check.Exists && xyz_file_check.Exists)
            {
                phi = new PhiFile(phi_file);
                xyz = new XYZFile(xyz_file);
            }
            else
            {
                phi = null;
                xyz = null;
            }

        }
    }

}
