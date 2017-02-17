using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGoogleDrive
{
    class ConnectionString
    {

        public static string MySQL(string server, string username, string password, string database)
        {
            string retval = string.Empty;
            try
            {
                retval = string.Format("server={0};uid={1};pwd={2};database={3};", server, username, password, database);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static string SQL_Windows(string server,string database)
        {
            string retval = string.Empty;
            try
            {
                retval = string.Format("Server={0}; Database={1};Trusted_Connection=True;", server, database);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
            
        }

        public static string SQL_Server(string server, string username, string password, string database)
        {
            string retval = string.Empty;
            try
            {
                retval = string.Format("Server={0};Database={1};User Id={2};Password={3};", server,database, username, password );
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static string MongoDB(string server, string username, string password)
        {
            string retval = string.Empty;
            try
            {
                retval = string.Format("mongodb://{1}:{2}@{0}", server, username, password);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static string MongoDB(string server)
        {
            string retval = string.Empty;
            try
            {
                retval = string.Format("mongodb://{0}", server);
                
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }
        
    }
}
