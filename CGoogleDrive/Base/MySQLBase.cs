using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;
namespace CGoogleDrive.Base
{
	public class MySQLBase
    {


        protected static DataSet ExecCmdDataSet(string ConnStr, string commandText, CommandType commandType, MySqlParameterList parameters)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();

            MySqlConnection conn = new MySqlConnection(ConnStr);
            MySqlCommand cmd = new MySqlCommand(commandText, conn);
            cmd.CommandTimeout = 0;
            try
            {
                cmd.CommandType = commandType;

                if (parameters != null)
                {
                    foreach (MySqlParameter parm in parameters)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                conn.Open();
                da = new MySqlDataAdapter(cmd);
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

        protected static int ExecCmdNonQuery(string ConnStr, string commandText, CommandType commandType, MySqlParameterList parameters)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            MySqlCommand cmd = new MySqlCommand(commandText, conn);
            cmd.CommandTimeout = 80000;
            try
            {
                cmd.CommandType = commandType;

                if (parameters != null)
                {
                    foreach (MySqlParameter parm in parameters)
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

        protected static object ExecCmdScalar(string ConnStr, string commandText, CommandType commandType, MySqlParameterList parameters)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            MySqlCommand cmd = new MySqlCommand(commandText, conn);
            cmd.CommandTimeout = 80000;
            try
            {
                cmd.CommandType = commandType;

                if (parameters != null)
                {
                    foreach (MySqlParameter parm in parameters)
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

    public class MySqlParameterList : CollectionBase
    {
        //***************************************************************************
        // Default property
        //***************************************************************************
        public MySqlParameter this[int index]
        {
            get { return (MySqlParameter)List[index]; }
            set { List[index] = value; }
        }
        //***************************************************************************
        // Add a SqlParameter
        //***************************************************************************
        public void Add(MySqlParameter parm)
        {
            List.Add(parm);
        }
        //***************************************************************************
        // Remove a SqlParameter
        //***************************************************************************
        public void Remove(MySqlParameter parm)
        {
            List.Remove(parm);
        }
    }
}