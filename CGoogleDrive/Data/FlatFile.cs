using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGoogleDrive.Data
{
    class FlatFile
    {

        public static DataSet GetData(CurrentSettings settings)
        {
            DataSet ds = new DataSet();
            try
            {
                //Get Data From File
                DataTable dt = new StreamReader(settings.FlatFile_input_path).ConvertCSVtoDataTable();
                ds.Tables.Add(dt);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return ds;
        }

        public static void Delete(CurrentSettings settings)
        {
            try
            {
                StreamWriter sw = new StreamWriter(System.IO.Path.Combine(settings.FlatFile_ouput_path, "output.csv"));
                sw.Close();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

      
    }
}
