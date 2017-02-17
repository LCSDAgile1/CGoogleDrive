using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGoogleDrive
{
    class Processor
    {
        CurrentSettings settings { get; set; }

        public Processor()
        {
            try
            {
                settings = new CurrentSettings();
                settings.Load();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        public void Start()
        {
            try
            {
                List<string> errors = new List<string>();
                errors.AddRange(Validate_Google());
                errors.AddRange(Validate_Input());
                if (settings.inputType == "Flat File")
                    errors.AddRange(Validate_Input_Flat());

                if (settings.inputType == "SQL Server")
                    errors.AddRange(Validate_Input_SQL());

                if (settings.inputType == "MySQL")
                    errors.AddRange(Validate_Input_MySQL());

                if (settings.inputType == "MongoDB")
                    errors.AddRange(Validate_Input_MongoDB());

                errors.AddRange(Validate_Output());
                if (settings.outputType == "Flat File")
                    errors.AddRange(Validate_Output_Flat());

                if (settings.outputType == "SQL Server")
                    errors.AddRange(Validate_Output_SQL());

                if (settings.outputType == "MySQL")
                    errors.AddRange(Validate_Output_MySQL());

                if (settings.outputType == "MongoDB")
                    errors.AddRange(Validate_Output_MongoDB());

                if (errors.Count >= 1)
                {
                    foreach (string error in errors)
                    {
                        Console.WriteLine(error);
                    }
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Please check your confiuration by launching with the switch -setup");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Start_Verified();
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }
  
        private List<string> Validate_Google()
        {
            List<string> retval = new List<string>();
            try
            {
                if (String.IsNullOrEmpty(settings.serviceAccount) == true)
                    retval.Add("Google Setup : No service account specified");

                if (String.IsNullOrEmpty(settings.keyFilePath) == true)
                    retval.Add("Google Setup : No service account key file specified");

                if (String.IsNullOrEmpty(settings.applicationName) == true)
                    retval.Add("Google Setup : No application name specified");

                if (String.IsNullOrEmpty(settings.maxParallel) == true)
                    retval.Add("Google Setup : No maximum parallel process count");

            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Input()
        {
            List<string> retval = new List<string>();
            try
            {

                string[] types = { "Flat File", "SQL Server", "MySQL", "MongoDB" };

                if (String.IsNullOrEmpty(settings.inputType) == true)
                    retval.Add("Input Config : No input type specified");

                if (types.Contains(settings.inputType) == false)
                    retval.Add("Input Config : Invalid input type specified");
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Input_Flat()
        {
            List<string> retval = new List<string>();
            try
            {
                if (String.IsNullOrEmpty(settings.FlatFile_input_path) == true)
                    retval.Add("Flat File Source : No flat file path specified");

                if (String.IsNullOrEmpty(settings.FlatFile_input_mail) == true)
                    retval.Add("Flat File Source : No flat file mail column specified");

                if (String.IsNullOrEmpty(settings.FlatFile_input_identifer) == true)
                    retval.Add("Flat File Source : No flat file identifier column specified");
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Input_SQL()
        {
            List<string> retval = new List<string>();
            try
            {
                if (String.IsNullOrEmpty(settings.SQL_input_server) == true)
                    retval.Add("SQL Server Source : No SQL server specified");

                if (String.IsNullOrEmpty(settings.SQL_input_database) == true)
                    retval.Add("SQL Server Source : No SQL database column specified");

                if (String.IsNullOrEmpty(settings.SQL_input_authenticationType) == true)
                    retval.Add("SQL Server Source : No SQL authentication type specified");

                if (settings.SQL_input_authenticationType == "SQL Server Authentication")
                {
                    if (String.IsNullOrEmpty(settings.SQL_input_username) == true)
                        retval.Add("SQL Server Source : No SQL username specified");

                    if (String.IsNullOrEmpty(settings.SQL_input_password) == true)
                        retval.Add("SQL Server Source : No SQL password specified");
                }

                if (String.IsNullOrEmpty(settings.SQL_input_query) == true)
                    retval.Add("SQL Server Source : No SQL query specified");

                if (String.IsNullOrEmpty(settings.SQL_input_mail) == true)
                    retval.Add("SQL Server Source : No SQL mail column specified");

                if (String.IsNullOrEmpty(settings.SQL_input_identifier) == true)
                    retval.Add("SQL Server Source : No SQL identifier column specified");
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Input_MySQL()
        {
            List<string> retval = new List<string>();
            try
            {
                if (String.IsNullOrEmpty(settings.MySQL_input_server) == true)
                    retval.Add("MySQL Server Source : No MySQL server specified");

                if (String.IsNullOrEmpty(settings.MySQL_input_database) == true)
                    retval.Add("MySQL Server Source : No MySQL database column specified");

                if (String.IsNullOrEmpty(settings.MySQL_input_username) == true)
                    retval.Add("MySQL Server Source : No MySQL username specified");

                if (String.IsNullOrEmpty(settings.MySQL_input_password) == true)
                    retval.Add("MySQL Server Source : No MySQL password specified");
                
                if (String.IsNullOrEmpty(settings.MySQL_input_query) == true)
                    retval.Add("MySQL Server Source : No MySQL query specified");

                if (String.IsNullOrEmpty(settings.MySQL_input_mail) == true)
                    retval.Add("MySQL Server Source : No MySQL mail column specified");

                if (String.IsNullOrEmpty(settings.MySQL_input_identifier) == true)
                    retval.Add("MySQL Server Source : No MySQL identifier column specified");
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Input_MongoDB()
        {
            List<string> retval = new List<string>();
            try
            {
                if (String.IsNullOrEmpty(settings.MongoDB_input_server) == true)
                    retval.Add("MongoDB Source : No MongoDB server specified");

                if (String.IsNullOrEmpty(settings.MongoDB_input_database) == true)
                    retval.Add("MongoDB Source : No MongoDB database specified");

                if (String.IsNullOrEmpty(settings.MongoDB_input_collection) == true)
                    retval.Add("MongoDB Source : No MongoDB collection specified");

                if (String.IsNullOrEmpty(settings.MongoDB_input_mail) == true)
                    retval.Add("MongoDB Source : No MongoDB mail element specified");

                if (String.IsNullOrEmpty(settings.MongoDB_input_identifier) == true)
                    retval.Add("MongoDB Source : No MongoDB identifier element specified");
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Output()
        {
            List<string> retval = new List<string>();
            try
            {

                string[] types = { "Flat File", "SQL Server", "MySQL", "MongoDB" };

                if (String.IsNullOrEmpty(settings.outputType) == true)
                    retval.Add("Output Config : No output type specified");

                if (types.Contains(settings.outputType) == false)
                    retval.Add("Output Config : Invalid output type specified");
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Output_Flat()
        {
            List<string> retval = new List<string>();
            try
            {
                if (String.IsNullOrEmpty(settings.FlatFile_ouput_path) == true)
                    retval.Add("Flat File Ouput : No flat file path specified");
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Output_SQL()
        {
            List<string> retval = new List<string>();
            try
            {
                if (String.IsNullOrEmpty(settings.SQL_output_server) == true)
                    retval.Add("SQL Server Output : No SQL server specified");

                if (String.IsNullOrEmpty(settings.SQL_output_database) == true)
                    retval.Add("SQL Server Output : No SQL database column specified");

                if (String.IsNullOrEmpty(settings.SQL_output_authenticationType) == true)
                    retval.Add("SQL Server Output : No SQL authentication type specified");

                if (settings.SQL_output_authenticationType == "SQL Server Authentication")
                {
                    if (String.IsNullOrEmpty(settings.SQL_output_username) == true)
                        retval.Add("SQL Server Output : No SQL username specified");

                    if (String.IsNullOrEmpty(settings.SQL_output_password) == true)
                        retval.Add("SQL Server Output : No SQL password specified");
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Output_MySQL()
        {
            List<string> retval = new List<string>();
            try
            {
                if (String.IsNullOrEmpty(settings.MySQL_output_server) == true)
                    retval.Add("MySQL Server Output : No MySQL server specified");

                if (String.IsNullOrEmpty(settings.MySQL_output_database) == true)
                    retval.Add("MySQL Server Output : No MySQL database column specified");

                if (String.IsNullOrEmpty(settings.MySQL_output_username) == true)
                    retval.Add("MySQL Server Output : No MySQL username specified");

                if (String.IsNullOrEmpty(settings.MySQL_output_password) == true)
                    retval.Add("MySQL Server Output : No MySQL password specified");
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private List<string> Validate_Output_MongoDB()
        {
            List<string> retval = new List<string>();
            try
            {
                if (String.IsNullOrEmpty(settings.MongoDB_output_server) == true)
                    retval.Add("MongoDB Output : No MongoDB server specified");

                if (String.IsNullOrEmpty(settings.MongoDB_output_database) == true)
                    retval.Add("MongoDB Output : No MongoDB database specified");
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void Start_Verified()
        {
            try
            {
                switch (settings.inputType)
                {
                    case "Flat File":
                        Start_FlatFile();
                        break;
                    case "SQL Server":
                        Start_SQL();
                        break;
                    case "MySQL":
                        Start_MySQL();
                        break;
                    case "MongoDB":
                        Start_MongoDB();
                        break;
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void Start_FlatFile()
        {
            try
            {
                OutputBuilder ob = null;

                //Run Initialization on output types
                switch (settings.outputType)
                {
                    case "Flat File":
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.FlatFile.Delete(settings);

                        ob = new OutputBuilder(settings.FlatFile_ouput_path);
                        break;
                    case "SQL Server":
                        Data.SQL.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.SQL.Delete(settings);
                        break;
                    case "MySQL":
                        Data.MySQL.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.MySQL.Delete(settings);
                        break;
                    case "MongoDB":
                        Data.Mongo_DB.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.Mongo_DB.Delete(settings);
                        break;
                }

                DataSet ds = Data.FlatFile.GetData(settings);
                if (ds.IsEmpty() == false)
                {
                    Parallel.ForEach(ds.Tables[0].AsEnumerable(), new ParallelOptions { MaxDegreeOfParallelism = int.Parse(settings.maxParallel) }, currentElement =>
                {
                    string email = currentElement[settings.FlatFile_input_mail].ToString();
                    string identifier = currentElement[settings.FlatFile_input_identifer].ToString();
                    
                    GoogleAccess ga = new GoogleAccess();
                    List<Google.Apis.Drive.v3.Data.File> files = ga.GetUserFiles(email);

                    if (files != null && files.Count > 0)
                    {
                        Console.WriteLine("Processing " + email + "(" + identifier + ") " + files.Count.ToString() + " Files Found");
                        foreach (Google.Apis.Drive.v3.Data.File file in files)
                        {
                            Console.WriteLine(file.Name);
                            switch (settings.outputType)
                            {
                                case "Flat File":
                                    string output = String.Format("{0},{1},{2},{3},{4},{5}", file.Id, file.Name, file.Size.ToString(), file.MimeType, file.WebViewLink, identifier);
                                    ob.Write(output);
                                    break;
                                case "SQL Server":
                                    Data.SQL.Insert(settings, file, identifier);
                                    break;
                                case "MySQL":
                                    Data.MySQL.Insert(settings, file, identifier);
                                    break;
                                case "MongoDB":
                                    Data.Mongo_DB.Insert(settings, file, identifier);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Processing " + email + "(" + identifier + ") No Files Found");
                    }
                    Console.WriteLine("");
                });
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void Start_SQL()
        {
            try
            {
                OutputBuilder ob = null;

                //Run Initialization on output types
                switch (settings.outputType)
                {
                    case "Flat File":
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.FlatFile.Delete(settings);

                        ob = new OutputBuilder(settings.FlatFile_ouput_path);
                        break;
                    case "SQL Server":
                        Data.SQL.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.SQL.Delete(settings);
                        break;
                    case "MySQL":
                        Data.MySQL.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.MySQL.Delete(settings);
                        break;
                    case "MongoDB":
                        Data.Mongo_DB.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.Mongo_DB.Delete(settings);
                        break;
                }

                DataSet ds = Data.SQL.GetData(settings);
                if (ds.IsEmpty() == false)
                {
                    Parallel.ForEach(ds.Tables[0].AsEnumerable(), new ParallelOptions { MaxDegreeOfParallelism = int.Parse(settings.maxParallel) }, currentElement =>
                    {
                        string email = currentElement[settings.SQL_input_mail].ToString();
                        string identifier = currentElement[settings.SQL_input_identifier].ToString();

                        GoogleAccess ga = new GoogleAccess();
                        List<Google.Apis.Drive.v3.Data.File> files = ga.GetUserFiles(email);

                        if (files != null && files.Count > 0)
                        {
                            Console.WriteLine("Processing " + email + "(" + identifier + ") " + files.Count.ToString() + " Files Found");
                            foreach (Google.Apis.Drive.v3.Data.File file in files)
                            {
                                Console.WriteLine(file.Name);
                                switch (settings.outputType)
                                {
                                    case "Flat File":
                                        string output = String.Format("{0},{1},{2},{3},{4},{5}", file.Id, file.Name, file.Size.ToString(), file.MimeType, file.WebViewLink, identifier);
                                        ob.Write(output);
                                        break;
                                    case "SQL Server":
                                        Data.SQL.Insert(settings, file, identifier);
                                        break;
                                    case "MySQL":
                                        Data.MySQL.Insert(settings, file, identifier);
                                        break;
                                    case "MongoDB":
                                        Data.Mongo_DB.Insert(settings, file, identifier);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Processing " + email + "(" + identifier + ") No Files Found");
                        }
                        Console.WriteLine("");
                    });
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void Start_MySQL()
        {
            try
            {
                OutputBuilder ob = null;

                //Run Initialization on output types
                switch (settings.outputType)
                {
                    case "Flat File":
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.FlatFile.Delete(settings);

                        ob = new OutputBuilder(settings.FlatFile_ouput_path);
                        break;
                    case "SQL Server":
                        Data.SQL.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.SQL.Delete(settings);
                        break;
                    case "MySQL":
                        Data.MySQL.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.MySQL.Delete(settings);
                        break;
                    case "MongoDB":
                        Data.Mongo_DB.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.Mongo_DB.Delete(settings);
                        break;
                }

                DataSet ds = Data.MySQL.GetData(settings);
                if (ds.IsEmpty() == false)
                {
                    Parallel.ForEach(ds.Tables[0].AsEnumerable(), new ParallelOptions { MaxDegreeOfParallelism = int.Parse(settings.maxParallel) }, currentElement =>
                    {
                        string email = currentElement[settings.MySQL_input_mail].ToString();
                        string identifier = currentElement[settings.MySQL_input_identifier].ToString();

                        GoogleAccess ga = new GoogleAccess();
                        List<Google.Apis.Drive.v3.Data.File> files = ga.GetUserFiles(email);

                        if (files != null && files.Count > 0)
                        {
                            Console.WriteLine("Processing " + email + "(" + identifier + ") " + files.Count.ToString() + " Files Found");
                            foreach (Google.Apis.Drive.v3.Data.File file in files)
                            {
                                Console.WriteLine(file.Name);
                                switch (settings.outputType)
                                {
                                    case "Flat File":
                                        string output = String.Format("{0},{1},{2},{3},{4},{5}", file.Id, file.Name, file.Size.ToString(), file.MimeType, file.WebViewLink, identifier);
                                        ob.Write(output);
                                        break;
                                    case "SQL Server":
                                        Data.SQL.Insert(settings, file, identifier);
                                        break;
                                    case "MySQL":
                                        Data.MySQL.Insert(settings, file, identifier);
                                        break;
                                    case "MongoDB":
                                        Data.Mongo_DB.Insert(settings, file, identifier);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Processing " + email + "(" + identifier + ") No Files Found");
                        }
                        Console.WriteLine("");
                    });
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void Start_MongoDB()
        {
            try
            {
                OutputBuilder ob = null;

                //Run Initialization on output types
                switch (settings.outputType)
                {
                    case "Flat File":
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.FlatFile.Delete(settings);

                        ob = new OutputBuilder(settings.FlatFile_ouput_path);
                        break;
                    case "SQL Server":
                        Data.SQL.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.SQL.Delete(settings);
                        break;
                    case "MySQL":
                        Data.MySQL.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.MySQL.Delete(settings);
                        break;
                    case "MongoDB":
                        Data.Mongo_DB.CheckAndCreateOuputTable(settings);
                        if (bool.Parse(settings.clearOutput) == true)
                            Data.Mongo_DB.Delete(settings);
                        break;
                }

                DataSet ds = Data.Mongo_DB.GetData(settings);
                if (ds.IsEmpty() == false)
                {
                    Parallel.ForEach(ds.Tables[0].AsEnumerable(), new ParallelOptions { MaxDegreeOfParallelism = int.Parse(settings.maxParallel) }, currentElement =>
                    {
                        string email = currentElement[settings.MongoDB_input_mail].ToString();
                        string identifier = currentElement[settings.MongoDB_input_identifier].ToString();

                        GoogleAccess ga = new GoogleAccess();
                        List<Google.Apis.Drive.v3.Data.File> files = ga.GetUserFiles(email);

                        if (files != null && files.Count > 0)
                        {
                            Console.WriteLine("Processing " + email + "(" + identifier + ") " + files.Count.ToString() + " Files Found");
                            foreach (Google.Apis.Drive.v3.Data.File file in files)
                            {
                                Console.WriteLine(file.Name);
                                switch (settings.outputType)
                                {
                                    case "Flat File":
                                        string output = String.Format("{0},{1},{2},{3},{4},{5}", file.Id, file.Name, file.Size.ToString(), file.MimeType, file.WebViewLink, identifier);
                                        ob.Write(output);
                                        break;
                                    case "SQL Server":
                                        Data.SQL.Insert(settings, file, identifier);
                                        break;
                                    case "MySQL":
                                        Data.MySQL.Insert(settings, file, identifier);
                                        break;
                                    case "MongoDB":
                                        Data.Mongo_DB.Insert(settings, file, identifier);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Processing " + email + "(" + identifier + ") No Files Found");
                        }
                        Console.WriteLine("");
                    });
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        public void WriteError(string Message)
        {
            try
            {
                Console.WriteLine(Message + " : Please check settings");
                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }
    }
}
