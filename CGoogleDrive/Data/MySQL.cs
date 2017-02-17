using CGoogleDrive.Base;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGoogleDrive.Data
{
    class MySQL : Base.MySQLBase
    {
        public static string ConnectionTest(string connStr)
        {
            string retval = string.Empty;
            try
            {
                ExecCmdNonQuery(connStr, "Select 1", CommandType.Text, null);
                retval = "success";
            }
            catch (Exception ex)
            {
                retval = ex.Message;
            }
            return retval;
        }

        public static DataSet GetDatabases(string connStr)
        {
            DataSet retval = null;
            try
            {
                retval = ExecCmdDataSet(connStr, "show databases", CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static DataSet GetData(string connStr,string Query)
        {
            DataSet retval = null;
            try
            {
                retval = ExecCmdDataSet(connStr, Query, CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static DataSet GetData(CurrentSettings settings)
        {
            DataSet retval = null;
            try
            {
                string connStr = ConnectionString.MySQL(settings.MySQL_output_server, settings.MySQL_input_username, settings.MySQL_output_password, settings.MySQL_output_database);

                retval = ExecCmdDataSet(connStr, settings.MySQL_input_query, CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static void CheckAndCreateOuputTable(CurrentSettings settings)
        {
            try
            {
                string connStr = ConnectionString.MySQL(settings.MySQL_output_server,settings.MySQL_input_username,settings.MySQL_output_password,settings.MySQL_output_database);
               
                //string connStr = ConnectionString.SQL_Server
                ExecCmdNonQuery(connStr, "CREATE TABLE IF NOT EXISTS cgoogledrive (id INT NOT NULL AUTO_INCREMENT, fileId VARCHAR(200) NULL, name Text NULL, size INT NULL, mimeType Text NULL, webViewLink Text NULL, identifer Text NULL, PRIMARY KEY (id));", CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }
   
        public static void Insert(CurrentSettings settings, Google.Apis.Drive.v3.Data.File file, string identifier)
        {
            try
            {
                string connStr = ConnectionString.MySQL(settings.MySQL_output_server, settings.MySQL_input_username, settings.MySQL_output_password, settings.MySQL_output_database);

                if (identifier == null)
                    identifier = string.Empty;

                MySqlParameterList parms = new MySqlParameterList();
                parms.Add(new MySqlParameter("@fileId", file.Id));
                parms.Add(new MySqlParameter("@name", file.Name));
                parms.Add(new MySqlParameter("@size", file.Size));
                parms.Add(new MySqlParameter("@mimeType", file.MimeType));
                parms.Add(new MySqlParameter("@webViewLink", file.WebViewLink));
                parms.Add(new MySqlParameter("@identifier", identifier));
                ExecCmdNonQuery(connStr, "INSERT INTO cgoogledrive (fileId ,name ,size ,mimeType ,webViewLink ,identifer) VALUES (@fileId ,@name ,@size ,@mimeType ,@webViewLink ,@identifier)", CommandType.Text, parms);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        public static void Delete(CurrentSettings settings)
        {
            try
            {
                string connStr = ConnectionString.MySQL(settings.MySQL_output_server, settings.MySQL_input_username, settings.MySQL_output_password, settings.MySQL_output_database);

                //string connStr = ConnectionString.SQL_Server
                ExecCmdNonQuery(connStr, "TRUNCATE TABLE cgoogledrive;", CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }
    }
}
