using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CGoogleDrive
{
    public static class Extensions
    {

        public static bool IsEmpty(this DataSet value)
        {
            if (value == null)
                return true;

            foreach (DataTable table in value.Tables)
                if (table.Rows.Count != 0) return false;

            return true;
        }

        public static bool IsEmpty(this DataTable value)
        {
            if (value == null)
                return true;
                if (value.Rows.Count != 0) return false;

            return true;
        }

        public static bool Write(this Exception value)
        {
            bool retval = false;
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter("Errors.txt", true);
                sw.WriteLine(value.Message);
                sw.Close();
                retval = true;
            }
            catch (Exception ex)
            {
                ex.Write();
                retval = false;
            }
            return retval;
        }

        public static DataTable ConvertCSVtoDataTable(this StreamReader value )
        {
            try
            {

            }
            catch (Exception ex)
            {
                ex.Write();
            }

            string[] headers = value.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header.Replace("\"",string.Empty));
            }
            while (!value.EndOfStream)
            {
                string[] rows = Regex.Split(value.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i].Replace("\"", string.Empty);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static DataSet ToDataSet<T>(this IList<T> list)
        {

            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

           
            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
               
                //t.Columns.Add(propInfo.Name, propInfo.PropertyType);
                
                    Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType; t.Columns.Add(propInfo.Name, ColType);
                
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    
                        //row[propInfo.Name] = propInfo.GetValue(item, null);
                        row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                    
                }

                //This line was missing:
                t.Rows.Add(row);
            }


            return ds;
        }
    }
}
