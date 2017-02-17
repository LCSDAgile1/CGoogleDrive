using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace CGoogleDrive.Base
{
	public class SQLBase
    {
       

        protected static DataSet ExecCmdDataSet(string ConnStr,string commandText, CommandType commandType, SqlParameterList parameters)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            SqlConnection conn = new SqlConnection(ConnStr);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandTimeout = 0;
            try
            {
                cmd.CommandType = commandType;

                if (parameters != null)
                {
                    foreach (SqlParameter parm in parameters)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                conn.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    cmd.Dispose();
                    da.Dispose();
                }
            }
        }

        protected static int ExecCmdNonQuery(string ConnStr,string commandText, CommandType commandType,SqlParameterList parameters)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandTimeout = 80000;
            try
            {
                cmd.CommandType = commandType;

                if (parameters != null)
                {
                    foreach (SqlParameter parm in parameters)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
        }

        protected static object ExecCmdScalar(string ConnStr,string commandText, CommandType commandType,SqlParameterList parameters)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandTimeout = 80000;
            try
            {
                cmd.CommandType = commandType;

                if (parameters != null)
                {
                    foreach (SqlParameter parm in parameters)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
        }
    }

    public class SqlParameterList : CollectionBase
    {
        //***************************************************************************
        // Default property
        //***************************************************************************
        public SqlParameter this[int index]
        {
            get { return (SqlParameter)List[index]; }
            set { List[index] = value; }
        }
        //***************************************************************************
        // Add a SqlParameter
        //***************************************************************************
        public void Add(SqlParameter parm)
        {
            List.Add(parm);
        }
        //***************************************************************************
        // Remove a SqlParameter
        //***************************************************************************
        public void Remove(SqlParameter parm)
        {
            List.Remove(parm);
        }
    }
}