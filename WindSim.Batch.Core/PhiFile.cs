using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace WindSim.Batch.Core
{

    public class PhiFile
    {
        //    line 1: contents of TEXT, version information. (format 1X,A40, A25))
        //Wind Field, Sector =000                   * PHOENICS - 2011  
        // I skipped this
        //    line 2: CARTES, ONEPHS, BFC, XCYCLE, CCM, LCMPRS ( ie. 6 logicals ). (format 1X,6L1)
        public FileInfo FileName;
        public bool cartes, onephs, bfc, xcycle, ccm, lcmprs;
        //    line 3: NX,NY,NZ,NPHI,DEN1,DEN2,EPOR,NPOR,HPOR,VPOR,LENREC,NUMBLK,
        //          NMATST,NFMAK1 ( ie. 14 integers ). (format 1X, 7I10)
        public int nx, ny, nz, nphi, den1, den2, epor, npor, hpor, vpor, lenrec, numblk, nmatst, nfmak1;
        //    line 4: RINNER,FLOAT(NPRPHI),RNFPWV,FLOAT(NFMAK2),RDMAT1,FLOAT(IDMAT2)  (format 1X, 6(1PE13.6))
        public double rinner, f_nprphi, rnfPWV, f_nfmak2, rdmat1, f_idmat2;
        //    line 5: (NAME(I),I=1,NPHI) (format 1X, 19A4).
        //P1  P2  U1  nul V1  nul W1  nul R1  R2  nul KE  EP  nul nul nul nul nul nul 
        //nul nul nul nul nul nul nul nul nul nul nul nul nul nul nul GR  WADDTREFYCEN
        //XCENZCENRHO1VPOREPORNPORHPORROUGENUTWCRTVCRTUCRT
        // three lines
        public string[] all_variables_name;       
        //line 6: x locations of east cell faces ( ie. NX reals, 1X,format 6(1PE13.6) ).
        public double[] x_east_cell_face;
        //line : y locations of north cell faces ( ie. NY reals , 1X, format 6(1PE13.6)).
        public double[] y_north_cell_face;
        //line : z locations of high cell faces ( ie. NZ reals, 1X, format 6(1PE13.6) ).
        public double[] z_high_cell_face;
        //line 9: mean pressure corrections at each slab ( ie. NZ reals, format 1X, 6(1PE13.6) ).
        public double[] slab_mean_pressure_correction;
        //    line 10: (STORE(I),I=1,NPHI) ( ie. NPHI logicals indicating which
        //          of the NPHI possible ones are stored in the file, format 1X, 79L1).
        public string[] variables_name;
        public double[, , ,] vars_phi;
        NumberStyles integerFormat = NumberStyles.AllowLeadingSign;
        NumberStyles phidataFormat = NumberStyles.AllowLeadingSign | NumberStyles.AllowExponent | NumberStyles.AllowLeadingWhite | NumberStyles.AllowDecimalPoint;
        public PhiFile(string fileName) 
        { 
            if (File.Exists(fileName))
            {
                FileName = new FileInfo(fileName);
                    using (TextReader tr = new StreamReader(fileName)) 
                    {
                //    line 1: contents of TEXT, version information. (format 1X,A40, A25))
                //Wind Field, Sector =000                   * PHOENICS - 2011  
                        tr.ReadLine();
                //    line 2: CARTES, ONEPHS, BFC, XCYCLE, CCM, LCMPRS ( ie. 6 logicals ). (format 1X,6L1)
                //TTTFFF  
                        string second_line = tr.ReadLine();
                        second_line = second_line.Replace(" ", "");
                        cartes = Tools.tf_char2bool(second_line[0]);
                        onephs = Tools.tf_char2bool(second_line[1]);
                        bfc = Tools.tf_char2bool(second_line[2]);
                        xcycle = Tools.tf_char2bool(second_line[3]);
                        ccm = Tools.tf_char2bool(second_line[4]);
                        lcmprs = Tools.tf_char2bool(second_line[5]); 
                //    line 3: NX,NY,NZ,NPHI,DEN1,DEN2,EPOR,NPOR,HPOR,VPOR,LENREC,NUMBLK,
                //          NMATST,NFMAK1 ( ie. 14 integers ). (format 1X, 7I10)
                //       600        10        50        50        41        -3        43
                //        44        45        42       256         0         0      1249
                        string line = tr.ReadLine();
                        //Console.WriteLine(line);
                        nx=Convert.ToInt32(line.Substring(1,10).Replace(" ",""));
                        ny=Convert.ToInt32(line.Substring(11, 10).Replace(" ", ""));
                        nz=Convert.ToInt32(line.Substring(21, 10).Replace(" ", ""));
                        nphi=Convert.ToInt32(line.Substring(31, 10).Replace(" ", ""));
                        den1=Convert.ToInt32(line.Substring(41, 10).Replace(" ", ""));
                        den2=Convert.ToInt32(line.Substring(51, 10).Replace(" ", ""));
                        epor=Convert.ToInt32(line.Substring(61, 10).Replace(" ", ""));
                        line = tr.ReadLine();
                        npor=Convert.ToInt32(line.Substring(1,10).Replace(" ",""));
                        hpor=Convert.ToInt32(line.Substring(11, 10).Replace(" ", ""));
                        vpor=Convert.ToInt32(line.Substring(21, 10).Replace(" ", ""));
                        lenrec=Convert.ToInt32(line.Substring(31, 10).Replace(" ", ""));
                        numblk=Convert.ToInt32(line.Substring(41, 10).Replace(" ", ""));
                        nmatst=Convert.ToInt32(line.Substring(51, 10).Replace(" ", ""));
                        nfmak1=Convert.ToInt32(line.Substring(61, 10).Replace(" ", ""));       
                //    line 4: RINNER,FLOAT(NPRPHI),RNFPWV,FLOAT(NFMAK2),RDMAT1,FLOAT(IDMAT2)  (format 1X, 6(1PE13.6))
                //0.000000E+00 0.000000E+00-9.000000E+00 1.152580E+05 0.000000E+00 0.000000E+00
                        line = tr.ReadLine();
                        //Console.WriteLine(line);
                        rinner = Double.Parse(line.Substring(0, 13), phidataFormat);
                        f_nprphi = Double.Parse(line.Substring(13, 13), phidataFormat);
                        rnfPWV = Double.Parse(line.Substring(26, 13), phidataFormat);
                        f_nfmak2 = Double.Parse(line.Substring(39, 13), phidataFormat);
                        rdmat1 = Double.Parse(line.Substring(52, 13), phidataFormat);
                        f_idmat2 = Double.Parse(line.Substring(65, 13), phidataFormat);
                //    line 5: (NAME(I),I=1,NPHI) (format 1X, 19A4).
                //P1  P2  U1  nul V1  nul W1  nul R1  R2  nul KE  EP  nul nul nul nul nul nul 
                //nul nul nul nul nul nul nul nul nul nul nul nul nul nul nul GR  WADDTREFYCEN
                //XCENZCENRHO1VPOREPORNPORHPORROUGENUTWCRTVCRTUCRT
                // three lines
                         // i count available variables
                        int variables_number = 0;
                        string first_var_row = tr.ReadLine();
                        string second_var_row = tr.ReadLine();
                        string third_var_row = tr.ReadLine();
                        string[] var_rows= { first_var_row,second_var_row,third_var_row};
                        // find variables name array dimension
                        for (int i = 0; i < 3; i++)
                        {
                            line = var_rows[i];
                     
                             for (int a = 0; a < 19; a++)
                            {
                                int pos =  (a * 4) + 1;
                                if (pos + 4 <= line.Length)
                                {
                                    variables_number++;
                                    //if (!line.Substring(pos, 4).Contains("nul")) variables_number++;
                                }
                                 //double test = Double.Parse(line.Substring(i * 13, 13), phidataFormat);
                                //Console.WriteLine(test.ToString("0.######E+00"), CultureInfo.InvariantCulture);
                            }
                        }
                        // allocate array dimensions
                        all_variables_name = new string[variables_number];
                        // parse variables name and put in the array
                        variables_number = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            line = var_rows[i];
                            for (int a = 0; a < 19; a++)
                            {
                                int pos = (a * 4) + 1;
                                if (pos + 4 <= line.Length)
                                {                           
                                    //if (!line.Substring(pos, 4).Contains("nul"))
                                    //{
                                        all_variables_name[variables_number] = line.Substring(pos, 4).Replace(" ", "");
                                        variables_number++;
                                    //}
                                    //for (int contat = 0; contat < variables_number; contat++) Console.WriteLine(variables_name[contat]);
                                }
                                //double test = Double.Parse(line.Substring(i * 13, 13), phidataFormat);
                                //Console.WriteLine(test.ToString("0.######E+00"), CultureInfo.InvariantCulture);
                            }
                        }
            //line 6: x locations of east cell faces ( ie. NX reals, 1X,format 6(1PE13.6) ).
            //1.666667E-03 3.333333E-03 5.000000E-03 6.666667E-03 8.333334E-03 1.000000E-02  <- row_to_parse
            //1.666667E-03 3.333333E-03 5.000000E-03 6.666667E-03 8.333334E-03 1.000000E-02  <- row_to_parse
            //1.166667E-02 1.333333E-02 1.500000E-02 1.666667E-02                            <- element_to_parse (in the last row)
                        string row;
                        int row_counter;
                        int element;
                    // allocate array dimensions
                        x_east_cell_face = new double[nx];
                    // parse data
                        int x_first_rows_to_parse = nx / 6;
                        int x_element_to_parse = nx % 6;
                        // parse all the first rows that arre formatted all the same
                        for (row_counter = 0; row_counter < x_first_rows_to_parse; row_counter++)
                        {
                            row = tr.ReadLine();
                            //Console.WriteLine(row);
                            for (element = 0; element < 6; element++)
                            {
                                x_east_cell_face[row_counter*6 + element] = Double.Parse(row.Substring(13*element, 13), phidataFormat);
                            }
                        }                      
                        // parse all the last row if one. it has less elements than the others.
                        if (x_element_to_parse != 0)
                        {
                            row = tr.ReadLine();
                            for (element = 0; element < x_element_to_parse; element++)
                            {
                                x_east_cell_face[x_first_rows_to_parse * 6 + element] = Double.Parse(row.Substring(13 * element, 13), phidataFormat);
                            }
                        }

                        //for (element = 0; element < nx; element++)
                        //{
                           // Console.WriteLine(x_east_cell_face[element]);
                        //}
            //line : y locations of north cell faces ( ie. NY reals , 1X, format 6(1PE13.6)).                        
                    // allocate array dimensions
                        y_north_cell_face = new double[ny];
                    // parse data
                        int y_first_rows_to_parse = ny / 6;
                        int y_element_to_parse = ny % 6;
                        // parse all the first rows that arre formatted all the same
                        for (row_counter = 0; row_counter < y_first_rows_to_parse; row_counter++)
                        {
                            row = tr.ReadLine();
                            //Console.WriteLine(row);
                            for (element = 0; element < 6; element++)
                            {
                                y_north_cell_face[row_counter * 6 + element] = Double.Parse(row.Substring(13 * element, 13), phidataFormat);
                            }
                        }

                        // parse all the last row if one. it has less elements than the others.
                        if (y_element_to_parse != 0)
                        {
                            row = tr.ReadLine();
                            for (element = 0; element < y_element_to_parse; element++)
                            {
                                y_north_cell_face[y_first_rows_to_parse * 6 + element] = Double.Parse(row.Substring(13 * element, 13), phidataFormat);
                            }
                        }
                        //for (element = 0; element < ny; element++)
                        //{
                        //    Console.WriteLine(y_north_cell_face[element]);
                        //}
            //line : z locations of high cell faces ( ie. NZ reals, 1X, format 6(1PE13.6) ).
                    // allocate array dimensions
                        z_high_cell_face = new double[nz];
                    // parse data
                        int z_first_rows_to_parse = nz / 6;
                        int z_element_to_parse = nz % 6;
                        // parse all the first rows that arre formatted all the same
                        for (row_counter = 0; row_counter < z_first_rows_to_parse; row_counter++)
                        {
                            row = tr.ReadLine();
                            //Console.WriteLine(row);
                            for (element = 0; element < 6; element++)
                            {
                                z_high_cell_face[row_counter * 6 + element] = Double.Parse(row.Substring(13 * element, 13), phidataFormat);
                            }

                        }
                        // parse all the last row if one. it has less elements than the others.
                        if (z_element_to_parse != 0)
                        {
                            row = tr.ReadLine();
                            for (element = 0; element < z_element_to_parse; element++)
                            {
                                z_high_cell_face[z_first_rows_to_parse * 6 + element] = Double.Parse(row.Substring(13 * element, 13), phidataFormat);
                            }
                        }
                        //for (element = 0; element < nz; element++)
                        //{
                        //    Console.WriteLine(z_high_cell_face[element]);
                        //}
                //line 9: mean pressure corrections at each slab ( ie. NZ reals, format 1X, 6(1PE13.6) ).
                    // allocate array dimensions
                        slab_mean_pressure_correction = new double[nz];
                    // Parse
                        // parse all the first rows that arre formatted all the same
                        for (row_counter = 0; row_counter < z_first_rows_to_parse; row_counter++)
                        {
                            row = tr.ReadLine();
                            //Console.WriteLine(row);
                            for (element = 0; element < 6; element++)
                            {
                                slab_mean_pressure_correction[row_counter * 6 + element] = Double.Parse(row.Substring(13 * element, 13), phidataFormat);
                            }
                        }
                       // parse all the last row if one. it has less elements than the others.
                        if (z_element_to_parse != 0)
                        {
                            row = tr.ReadLine();
                            for (element = 0; element < z_element_to_parse; element++)
                            {
                                slab_mean_pressure_correction[z_first_rows_to_parse * 6 + element] = Double.Parse(row.Substring(13 * element, 13), phidataFormat);
                            }
                        }
                //    line 10: (STORE(I),I=1,NPHI) ( ie. NPHI logicals indicating which
                //          of the NPHI possible ones are stored in the file, format 1X, 79L1).
                //  I skipped this.

                        string present_variables_str = tr.ReadLine().Replace(" ", "");
                        int number_of_true = present_variables_str.Length - present_variables_str.Replace("T", "").Length;
                        variables_name = new string[number_of_true];
                        int variable_counter = 0;
                        // restituire un'eccezione se all_variables_name.Length != present_variable_str.Length
                        for (int contatore = 0; contatore < present_variables_str.Length; contatore++)
                        {
                            if (Tools.tf_char2bool(present_variables_str[contatore]))
                            {
                                variables_name[variable_counter] = all_variables_name[contatore];
                                variable_counter++;
                            }
                        }

                //The above header is followed by the storage of the fields at each slab in the order P1, P2, U1,....C35. There are NX*NY values of each variable at each slab. Each slabs-worth of variable is written with the format (format 1X, 6(1PE13.6)).
                //An extract of Fortran code to read the fields section might look like:
                //       DO IZ=1,NZ
                //         DO IPHI=1,M
                //           READ(LU,'(1X,6(1PE13.6))') ((PHI(IPHI,IX,IY,IZ),IY=1,NY),IX=1,NX)
                //         ENDDO
                //       ENDDO    
                //where M is the total number of STOREd variables.
                //Note that if more values are written than the formt allows for, each logical line will be written as several physical lines in the file.
                //         public double[, , ,] vars_phi;
                    // allocate array dimensions               
                        int var_to_store = variables_name.Length;
                        vars_phi = new double[nx, ny, nz,var_to_store];               
                    // Parse
                        int var_index = 0;
                        int nx_index = 0;
                        int ny_index = 0;
                        int nz_index = 0;
                        bool close_loop = false;
                        while ((line = tr.ReadLine()) != null)
                        {
                            for (element = 0; element < 6; element++)
                            {
                                // verifica se c'e' un elemento
                                if (line.Length > 13 * element)
                                {
                                    vars_phi[nx_index, ny_index, nz_index, var_index] = Double.Parse(line.Substring(13 * element, 13), phidataFormat);                                   
                                   ny_index++;
                                    if (ny_index == ny)
                                    {
                                        ny_index = 0;
                                        nx_index++;
                                        if (nx_index == nx)
                                        {
                                            nx_index = 0;
                                            var_index++;
                                            if (var_index == var_to_store)
                                            {
                                                var_index = 0;
                                                nz_index++;
                                                if (nz_index == nz)
                                                {
                                                    close_loop = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (close_loop) break;
                            }                           
                        }
                        //for (var_index = 0; var_index < var_to_store; var_index++)
                        //{
                        //    Console.WriteLine(" ");
                        //    Console.WriteLine(" ");
                        //    for (nz_index = 0; nz_index < nz; nz_index++)
                        //    {
                        //        for (ny_index = 0; ny_index < ny; ny_index++)
                        //        {
                        //            for (nx_index = 0; nx_index < nx; nx_index++)
                        //            {
                        //                Console.Write(vars_phi[nx_index, ny_index, nz_index, var_index]);
                        //                Console.Write(" ");
                        //            }
                        //            Console.WriteLine("");
                        //        }
                        //    }
                        //}
                        //Console.ReadKey();

                    }              
            }
                   
                    //using (TextReader tr = new StreamReader(FileName))
                    //{
                    //    TurbinePwsDS.TurbineHeaderRow header = null;
                    //    string line;
                    //    while ((line = tr.ReadLine()) != null)
                    //    {
                    //        if(header == null)
                    //        {
                    //            header = _dataSet.TurbineHeader.NewTurbineHeaderRow();
                    //            header.WindSimVersion = int.Parse(line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
                    //            header.turbinManufacturer = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                    //            header.typeSpecification = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                    //            header.maxEffect = int.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
                    //            header.airDensity = decimal.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
                    //            header.CutinSpeed = int.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
                    //            header.CutoutSpeed = int.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
                    //            header.RatedWindSpeed = int.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
                    //            tr.ReadLine();
                    //            header.powerCurve = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                    //            _dataSet.TurbineHeader.Rows.Add(header);
                    //        }     
        }

        public bool Equals(PhiFile other)//(object obj) 
        {
            return (FileName.FullName == other.FileName.FullName) &&
                   (cartes == other.cartes) &&
                   (onephs == other.onephs) &&
                   (bfc == other.bfc) &&
                   (xcycle == other.xcycle) &&
                   (ccm == other.ccm) &&
                   (nx == other.nx) &&
                   (ny == other.ny) &&
                   (nz == other.nz) &&
                   (nphi == other.nphi) &&
                   (den1 == other.den1) &&
                   (den2 == other.den2) &&
                   (epor == other.epor) &&
                   (npor == other.npor) &&
                   (hpor == other.hpor) &&
                   (vpor == other.vpor) &&
                   (lenrec == other.lenrec) &&
                   (numblk == other.numblk) &&
                   (nmatst == other.nmatst) &&
                   (nfmak1 == other.nfmak1) &&
                   (rinner == other.rinner) &&
                   (f_nprphi == other.f_nprphi) &&
                   (f_nfmak2 == other.f_nfmak2) &&
                   (rdmat1 == other.rdmat1) &&
                   (f_idmat2 == other.f_idmat2) &&
                   Enumerable.SequenceEqual(all_variables_name, other.all_variables_name) &&
                   Enumerable.SequenceEqual(x_east_cell_face, other.x_east_cell_face) &&
                   Enumerable.SequenceEqual(y_north_cell_face, other.y_north_cell_face) &&
                   Enumerable.SequenceEqual(z_high_cell_face, other.z_high_cell_face) &&
                   Enumerable.SequenceEqual(slab_mean_pressure_correction, other.slab_mean_pressure_correction) &&
                   Enumerable.SequenceEqual(variables_name, other.variables_name);
                   //&& Enumerable.SequenceEqual(vars_phi, other.vars_phi);

        }


    }
}


//The "header"

//The first ten lines of this file contain "header" information, namely:-


//    line 1: contents of TEXT, version information. (format 1X,A40, A25))
//    line 2: CARTES, ONEPHS, BFC, XCYCLE, CCM, LCMPRS ( ie. 6 logicals ). (format 1X,6L1)
//    line 3: NX,NY,NZ,NPHI,DEN1,DEN2,EPOR,NPOR,HPOR,VPOR,LENREC,NUMBLK,
//          NMATST,NFMAK1 ( ie. 14 integers ). (format 1X, 7I10)
//    line 4: RINNER,FLOAT(NPRPHI),RNFPWV,FLOAT(NFMAK2),RDMAT1,FLOAT(IDMAT2)  (format 1X, 6(1PE13.6))
//    line 5: (NAME(I),I=1,NPHI) (format 1X, 19A4).
//    line 6: x locations of east cell faces ( ie. NX reals, 1X,format 6(1PE13.6) ).
//    line : y locations of north cell faces ( ie. NY reals , 1X, format 6(1PE13.6)).
//    line : z locations of high cell faces ( ie. NZ reals, 1X, format 6(1PE13.6) ).
//    line 9: mean pressure corrections at each slab ( ie. NZ reals, format 1X, 6(1PE13.6) ).
//    line 10: (STORE(I),I=1,NPHI) ( ie. NPHI logicals indicating which
//          of the NPHI possible ones are stored in the file, format 1X, 79L1).


                                                                                                                                          
 //TTTFFF                                                                                                                                                                                                 
 //       600        10        50        50        41        -3        43
 //        44        45        42       256         0         0      1249
 //0.000000E+00 0.000000E+00-9.000000E+00 1.152580E+05 0.000000E+00 0.000000E+00
 //P1  P2  U1  nul V1  nul W1  nul R1  R2  nul KE  EP  nul nul nul nul nul nul 
 //nul nul nul nul nul nul nul nul nul nul nul nul nul nul nul GR  WADDTREFYCEN
 //XCENZCENRHO1VPOREPORNPORHPORROUGENUTWCRTVCRTUCRT
 //1.666667E-03 3.333333E-03 5.000000E-03 6.666667E-03 8.333334E-03 1.000000E-02
 //1.166667E-02 1.333333E-02 1.500000E-02 1.666667E-02 1.833333E-02 2.000000E-02
 //2.166667E-02 2.333333E-02 2.500000E-02 2.666667E-02 2.833333E-02 3.000000E-02

        //public DataSet Parse(string fileName, object data = null)
        //{
        //    if (File.Exists(fileName))
        //        FileName = fileName;
        //    else
        //        return null;

        //    _dataSet.Clear();
            
        //    try
        //    {
        //        //"####.pws"
                
        //        using (TextReader tr = new StreamReader(FileName))
        //        {
        //            TurbinePwsDS.TurbineHeaderRow header = null;

        //            string line;
        //            while ((line = tr.ReadLine()) != null)
        //            {
        //                if(header == null)
        //                {
        //                    header = _dataSet.TurbineHeader.NewTurbineHeaderRow();
        //                    header.WindSimVersion = int.Parse(line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
        //                    header.turbinManufacturer = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
        //                    header.typeSpecification = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
        //                    header.maxEffect = int.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
        //                    header.airDensity = decimal.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
        //                    header.CutinSpeed = int.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
        //                    header.CutoutSpeed = int.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
        //                    header.RatedWindSpeed = int.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
        //                    tr.ReadLine();
        //                    header.powerCurve = tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
        //                    _dataSet.TurbineHeader.Rows.Add(header);
        //                }

        //                if (line.StartsWith("bin (m/s)      Power (kW)    Thrust Coef. (-)"))
        //                {
        //                    while((line = tr.ReadLine()) != "  ")
        //                    {
        //                        TurbinePwsDS.TurbineDataRow info = _dataSet.TurbineData.NewTurbineDataRow();

        //                        info.bin = decimal.Parse(line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Trim());
        //                        info.Power = decimal.Parse(line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
        //                        info.ThrustCoef = decimal.Parse(line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2].Trim());

        //                        _dataSet.TurbineData.Rows.Add(info);    
        //                    }
                            
        //                }

        //                if (line.StartsWith("broadband noise"))
        //                {
        //                    TurbinePwsDS.NoiseHeaderRow noiseHeader = _dataSet.NoiseHeader.NewNoiseHeaderRow();
        //                    try
        //                    {
        //                        noiseHeader.broadbandNoise = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
        //                    }
        //                    catch{noiseHeader.broadbandNoise = "";}
                            
        //                    noiseHeader.refHeight = decimal.Parse(tr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
        //                    _dataSet.NoiseHeader.Rows.Add(noiseHeader);    
        //                }

        //                if(line.StartsWith("bin (m/s)            sound power level (dB(A))  "))
        //                {
        //                    while((line = tr.ReadLine()) != "")
        //                    {
        //                        TurbinePwsDS.NoiseDataRow noiseData = _dataSet.NoiseData.NewNoiseDataRow();

        //                        noiseData.bin = int.Parse(line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Trim());
        //                        noiseData.soundPowerLevel = decimal.Parse(line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
        //                        _dataSet.NoiseData.Rows.Add(noiseData);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch { }



        //    return _dataSet;
        //}