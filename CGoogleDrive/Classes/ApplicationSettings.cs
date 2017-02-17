using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CGoogleDrive
{
    public class CurrentSettings
    {

        public string serviceAccount { get; set; }
        public string keyFilePath { get; set; }
        public string applicationName { get; set; }
        public string maxParallel { get; set; }
        public string clearOutput { get; set; }
        public string filter { get; set; }

        public string inputType { get; set; }
        public string MySQL_input_server { get; set; }
        public string MySQL_input_database { get; set; }
        public string MySQL_input_username { get; set; }
        public string MySQL_input_password { get; set; }
        public string MySQL_input_query { get; set; }
        public string MySQL_input_mail { get; set; }
        public string MySQL_input_identifier { get; set; }
       
        public string SQL_input_server { get; set; }
        public string SQL_input_database { get; set; }
        public string SQL_input_username { get; set; }
        public string SQL_input_password { get; set; }
        public string SQL_input_authenticationType { get; set; }
        public string SQL_input_query { get; set; }
        public string SQL_input_mail { get; set; }
        public string SQL_input_identifier { get; set; }

        public string MongoDB_input_server { get; set; }
        public string MongoDB_input_database { get; set; }
        public string MongoDB_input_username { get; set; }
        public string MongoDB_input_password { get; set; }
        public string MongoDB_input_collection { get; set; }
        public string MongoDB_input_mail { get; set; }
        public string MongoDB_input_identifier { get; set; }

        public string FlatFile_input_path { get; set; }
        public string FlatFile_input_mail { get; set; }
        public string FlatFile_input_identifer { get; set; }

        public string outputType { get; set; }
        public string MySQL_output_server { get; set; }
        public string MySQL_output_database { get; set; }
        public string MySQL_output_username { get; set; }
        public string MySQL_output_password { get; set; }

        public string SQL_output_server { get; set; }
        public string SQL_output_database { get; set; }
        public string SQL_output_username { get; set; }
        public string SQL_output_password { get; set; }
        public string SQL_output_authenticationType { get; set; }

        public string MongoDB_output_server { get; set; }
        public string MongoDB_output_database { get; set; }
        public string MongoDB_output_username { get; set; }
        public string MongoDB_output_password { get; set; }

        public string FlatFile_ouput_path { get; set; }

        public CurrentSettings()
        { 
            serviceAccount = string.Empty;
            keyFilePath = string.Empty;
            applicationName = string.Empty;
            maxParallel = "1";
            clearOutput = string.Empty;
            filter = string.Empty;

            inputType = string.Empty;
            MySQL_input_server = string.Empty;
            MySQL_input_database = string.Empty;
            MySQL_input_username = string.Empty;
            MySQL_input_password = string.Empty;
            MySQL_input_query = string.Empty;
            MySQL_input_mail = string.Empty;
            MySQL_input_identifier = string.Empty;
       
            SQL_input_server = string.Empty;
            SQL_input_database = string.Empty;
            SQL_input_username = string.Empty;
            SQL_input_password = string.Empty;
            SQL_input_authenticationType = string.Empty;
            SQL_input_query = string.Empty;
            SQL_input_mail = string.Empty;
            SQL_input_identifier = string.Empty;

            MongoDB_input_server = string.Empty;
            MongoDB_input_database = string.Empty;
            MongoDB_input_username = string.Empty;
            MongoDB_input_password = string.Empty;
            MongoDB_input_collection = string.Empty;
            MongoDB_input_mail = string.Empty;
            MongoDB_input_identifier = string.Empty;

            FlatFile_input_path = string.Empty;
            FlatFile_input_mail = string.Empty;
            FlatFile_input_identifer = string.Empty;

            outputType = string.Empty;
            MySQL_output_server = string.Empty;
            MySQL_output_database = string.Empty;
            MySQL_output_username = string.Empty;
            MySQL_output_password = string.Empty;

            SQL_output_server = string.Empty;
            SQL_output_database = string.Empty;
            SQL_output_username = string.Empty;
            SQL_output_password = string.Empty;
            SQL_output_authenticationType = string.Empty;

            MongoDB_output_server = string.Empty;
            MongoDB_output_database = string.Empty;
            MongoDB_output_username = string.Empty;
            MongoDB_output_password = string.Empty;

            FlatFile_ouput_path = string.Empty;
        }

        public bool Save()
        {
            bool retval = false;
            TextWriter tw = new StreamWriter(@"settings.xml");
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(CurrentSettings));
                xs.Serialize(tw,this);
                retval = true;
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            finally
            {
                tw.Close();
                tw.Dispose();
            }
            return retval;
        }

        public bool Load()
        {
            if (System.IO.File.Exists(@"settings.xml") == false)
                return false;

            bool retval = false;
            StreamReader sr = new StreamReader(@"settings.xml");
            try
            {
               XmlSerializer xs = new XmlSerializer(typeof(CurrentSettings));
               CurrentSettings cs = (CurrentSettings)xs.Deserialize(sr);
               serviceAccount = cs.serviceAccount;
               keyFilePath = cs.keyFilePath;
               applicationName = cs.applicationName;
               maxParallel = cs.maxParallel;
               clearOutput = cs.clearOutput;
               filter = cs.filter;

               inputType = cs.inputType;
               MySQL_input_server = cs.MySQL_input_server;
               MySQL_input_database = cs.MySQL_input_database;
               MySQL_input_username = cs.MySQL_input_username;
               MySQL_input_password = cs.MySQL_input_password;
               MySQL_input_query = cs.MySQL_input_query;
               MySQL_input_mail = cs.MySQL_input_mail;
               MySQL_input_identifier = cs.MySQL_input_identifier;

               SQL_input_server = cs.SQL_input_server;
               SQL_input_database = cs.SQL_input_database;
               SQL_input_username = cs.SQL_input_username;
               SQL_input_password = cs.MySQL_input_password;
               SQL_input_authenticationType = cs.SQL_input_authenticationType;
               SQL_input_query = cs.SQL_input_query;
               SQL_input_mail = cs.SQL_input_mail;
               SQL_input_identifier = cs.SQL_input_identifier;

               MongoDB_input_server = cs.MongoDB_input_server;
               MongoDB_input_database = cs.MongoDB_input_database;
               MongoDB_input_username = cs.MongoDB_input_username;
               MongoDB_input_password = cs.MongoDB_input_password;
               MongoDB_input_collection = cs.MongoDB_input_collection;
               MongoDB_input_mail = cs.MongoDB_input_mail;
               MongoDB_input_identifier = cs.MongoDB_input_identifier;

               FlatFile_input_path = cs.FlatFile_input_path;
               FlatFile_input_mail = cs.FlatFile_input_mail;
               FlatFile_input_identifer = cs.FlatFile_input_identifer;

               outputType = cs.outputType;
               MySQL_output_server = cs.MySQL_output_server;
               MySQL_output_database = cs.MySQL_output_database;
               MySQL_output_username = cs.MySQL_output_username;
               MySQL_output_password = cs.MySQL_output_password;

               SQL_output_server = cs.SQL_output_server;
               SQL_output_database = cs.SQL_output_database;
               SQL_output_username = cs.SQL_output_username;
               SQL_output_password = cs.SQL_output_password;
               SQL_output_authenticationType = cs.SQL_output_authenticationType;

               MongoDB_output_server = cs.MongoDB_output_server;
               MongoDB_output_database = cs.MongoDB_output_database;
               MongoDB_output_username = cs.MongoDB_output_username;
               MongoDB_output_password = cs.MongoDB_output_password;

               FlatFile_ouput_path = cs.FlatFile_ouput_path;
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            finally
            {
                sr.Close();
                sr.Dispose();
            }
            return retval;
        }

    }
}
