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
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using WindSim.Breeze.XmlParser.DataSets;

namespace WindSim.Breeze.XmlParser
{
    #region File Layout
    /*
    WindSim version    : 480

    Park production    :     150.9785 GWh

    CLIM number        :          1
    CLIM name          : Climatology1
    CLIM representation: frequency table

    WECS number        :          1
    WECS name          : Turbine1
    Manufacturer       : windsim
    Type               : ws2000
    Nominal effect     :       2000
    Hub height         :      100.0
    x (local)          :     3805.7
    y (local)          :     5363.5
    x (global)         :   611340.7
    y (global)         :  7182805.5

    Sector  Energy (MWh/y)  Speed wecs (m/s)   Speedup (-)   Speed ref (m/s)    Freq, ref      A, ref           k, ref        Freq, turb     A, turb          k, turb                
       1      2293.8             8.35           1.201            6.95           0.30            7.22            1.41           0.30            8.68            1.40
       2      6994.1             9.96           1.201            8.29           0.70            9.24            1.85           0.70           11.54            2.02
     1 -  2   9287.8             9.47           1.201            7.89           1.00            8.66            1.70           1.00           10.96            1.89

    
    */
    #endregion

    public class Energy_freq_refParser : IWSParser
    {
        private Energy_freq_refDS _dataSet = new Energy_freq_refDS();
        private string _filePath = "";

        public IWSParserTypes LogType
        {
            get
            {
                return IWSParserTypes.Energy_freq_ref;
            }
        }

        public string FileName
        {
            get;set;
        }

        public string FilePath
        {
            get { return _filePath; }
            
        }

        public DataSet DataSet 
        { 
            get { return _dataSet; }
        }
        
        
        public DataSet Parse(string fileName, object data = null)
        {
            if (File.Exists(fileName))
                FileName = fileName;
            else
                return null;

            _dataSet.Clear();
            
            try
            {
                //"energy_freq_ref###.log"
                
                using (TextReader tr = new StreamReader(FileName))
                {

                    Energy_freq_refDS.HeaderRow header=null; 
                    string line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        if(header == null)
                        {
                            header = _dataSet.Header.NewHeaderRow();
                            header.WindSimVersion = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            line = tr.ReadLine();
                            header.ParkProduction = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                            line = tr.ReadLine();
                            header.CLIMNumber = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            if (header.CLIMNumber != "all")
                                header.CLIMName = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            else
                                header.CLIMName = "";
                            header.CLIMRepresentation = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            
                            _dataSet.Header.Rows.Add(header);
                        }
                        if (line.StartsWith("WECS number        :"))
                        {
                            Energy_freq_refDS.DataRow row = _dataSet.Data.NewDataRow();
                            row.WECSNumber = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            row.WECSName = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            row.Manufacturer = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            row.Type = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            row.NominalEffect = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            row.HubHeight = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            row.xlocal = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            row.ylocal = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            row.xglobal = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            row.yglobal = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            _dataSet.Data.Rows.Add(row);
                            tr.ReadLine();
                            tr.ReadLine();
                            while ((line = tr.ReadLine()) != "" )
                            {
                                string[] values = line.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                                Energy_freq_refDS.InfoRow info = _dataSet.Info.NewInfoRow();
                                info.Data_Id = row.Data_Id;
                                info.DataRow = row;
                                int idx = 0;
                                if (values[idx+1] == "-")
                                {
                                    info.Sector = values[idx++].Trim();
                                    info.Sector += " "+ values[idx++].Trim();
                                    info.Sector += " "+values[idx++].Trim();    
                                }
                                else
                                    info.Sector = values[idx++].Trim();

                                info.Energy = values[idx++].Trim();
                                info.SpeedWecs = values[idx++].Trim();
                                info.Speedup = values[idx++].Trim();
                                info.SpeedRef = values[idx++].Trim();
                                info.FreqRef = values[idx++].Trim();
                                info.ARef = values[idx++].Trim();
                                info.kRef = values[idx++].Trim();
                                info.FreqTurb = values[idx++].Trim();
                                info.ATurb = values[idx++].Trim();
                                info.kTurb = values[idx++].Trim();
                                _dataSet.Info.Rows.Add(info);
                            }

                            
                        }
                        

                        
                        
                       
                    }
                }
            }
            catch { }



            return _dataSet;
        }

        public bool Save(string filePath)
        {
            try
            {
                if (_dataSet.Data == null || _dataSet.Data.Count <= 0)
                    return false;

                _dataSet.WriteXml(filePath);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
