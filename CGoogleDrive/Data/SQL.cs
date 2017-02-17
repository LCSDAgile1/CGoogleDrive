using CGoogleDrive.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGoogleDrive.Data
{
    class SQL : Base.SQLBase
    {

        public static DataSet ListDatabases(string connStr)
        {
            DataSet ds = null;
            try
            {
                ds = ExecCmdDataSet(connStr, "SELECT name FROM master.dbo.sysdatabases WHERE dbid > 6 ORDER BY name", CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return ds;
        }

        public static DataSet TestQuery(string connStr,string Query)
        {
            DataSet ds = null;
            try
            {
                ds = ExecCmdDataSet(connStr, Query, CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return ds;
        }

        public static DataSet GetData(string connStr, string Query)
        {
            DataSet ds = null;
            try
            {
                ds = ExecCmdDataSet(connStr, Query, CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return ds;
        }

        public static DataSet GetData(CurrentSettings settings)
        {
            DataSet ds = null;
            try
            {
                string connStr = string.Empty;
                if (settings.SQL_output_authenticationType == "Windows Authentication")
                {
                    connStr = ConnectionString.SQL_Windows(settings.SQL_output_server, settings.SQL_output_database);
                }
                else
                {
                    connStr = ConnectionString.SQL_Server(settings.SQL_output_server, settings.SQL_output_username, settings.SQL_output_password, settings.SQL_output_database);
                }

                ds = ExecCmdDataSet(connStr, settings.SQL_input_query, CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return ds;
        }

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

        public static void CheckAndCreateOuputTable(CurrentSettings settings)
        {
            try
            {
                string connStr = string.Empty;
                if (settings.SQL_output_authenticationType == "Windows Authentication"){
                    connStr = ConnectionString.SQL_Windows(settings.SQL_output_server, settings.SQL_output_database);
                }
                else{
                    connStr = ConnectionString.SQL_Server(settings.SQL_output_server,settings.SQL_output_username,settings.SQL_output_password, settings.SQL_output_database);
                }
                //string connStr = ConnectionString.SQL_Server
                ExecCmdNonQuery(connStr, "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CGoogleDrive]') AND type in (N'U')) BEGIN CREATE TABLE [dbo].[CGoogleDrive]( [id] [INT] IDENTITY(1,1) NOT NULL, [fileId] [VARCHAR](200) NOT NULL, [name] [VARCHAR](MAX) NOT NULL, [size] [INT] NULL, [mimeType] [VARCHAR](MAX) NULL, [webViewLink] [VARCHAR](MAX) NULL, [identifier] [INT] NOT NULL, CONSTRAINT [PK_CGoogleDrive] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] END", CommandType.Text, null);
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
                string connStr = string.Empty;
                if (settings.SQL_output_authenticationType == "Windows Authentication")
                {
                    connStr = ConnectionString.SQL_Windows(settings.SQL_output_server, settings.SQL_output_database);
                }
                else
                {
                    connStr = ConnectionString.SQL_Server(settings.SQL_output_server, settings.SQL_output_username, settings.SQL_output_password, settings.SQL_output_database);
                }

                if (identifier == null)
                    identifier = string.Empty;

                SqlParameterList parms = new SqlParameterList();
                parms.Add(new SqlParameter("@fileId", file.Id));
                parms.Add(new SqlParameter("@name", file.Name));
                parms.Add(new SqlParameter("@size", file.Size));
                parms.Add(new SqlParameter("@mimeType", file.MimeType));
                parms.Add(new SqlParameter("@webViewLink", file.WebViewLink));
                parms.Add(new SqlParameter("@identifier", identifier));
                ExecCmdNonQuery(connStr, "INSERT INTO [dbo].[CGoogleDrive] ([fileId] ,[name] ,[size] ,[mimeType] ,[webViewLink] ,[identifier]) VALUES (@fileId ,@name ,@size ,@mimeType ,@webViewLink ,@identifier)", CommandType.Text, parms);
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
                string connStr = string.Empty;
                if (settings.SQL_output_authenticationType == "Windows Authentication")
                {
                    connStr = ConnectionString.SQL_Windows(settings.SQL_output_server, settings.SQL_output_database);
                }
                else
                {
                    connStr = ConnectionString.SQL_Server(settings.SQL_output_server, settings.SQL_output_username, settings.SQL_output_password, settings.SQL_output_database);
                }
                //string connStr = ConnectionString.SQL_Server
                ExecCmdNonQuery(connStr, " Truncate Table CGoogleDrive", CommandType.Text, null);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }
    }
}
