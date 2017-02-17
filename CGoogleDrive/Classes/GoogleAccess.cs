using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace CGoogleDrive
{
    class GoogleAccess
    {
        CurrentSettings settings { get; set; }
        public GoogleAccess()
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

        

        public DriveService GetDriveAccessForUser(string userEmail)
        {
            //check the file exists
            if (!System.IO.File.Exists(settings.keyFilePath))
            {
                Console.WriteLine("An Error occurred - Key file does not exist");
                return null;
            }

            string[] scopes = new string[] { DriveService.Scope.Drive }; //View Drive

            var certificate = new X509Certificate2(settings.keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            try
            {
                ServiceAccountCredential credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(settings.serviceAccount)
                    {
                        Scopes = scopes,
                        User = userEmail
                    }.FromCertificate(certificate));

                //Create the service
                DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = settings.applicationName
                });

                return service;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Google.Apis.Drive.v3.Data.File> GetUserFiles(string userEmail)
        {
            List<Google.Apis.Drive.v3.Data.File> retval = new List<Google.Apis.Drive.v3.Data.File>();
            try
            {
                    DriveService service = GetDriveAccessForUser(userEmail);
                    FilesResource.ListRequest listRequest = service.Files.List();
                    listRequest.PageSize = 100;
                    listRequest.Fields = "nextPageToken, files(id, name, size,mimeType,webViewLink )";
                    if (string.IsNullOrEmpty(settings.filter) == false)
                        listRequest.Q = settings.filter;
                    // List files.
                    IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
               
                    if (files != null && files.Count > 0)
                        retval = files.ToList(); 
                
     
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public string Verify(CurrentSettings _settings)
        {
            string retval = string.Empty;
            try
            {
                DriveService service = VerifyGetDriveAccessForUser(_settings);
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.PageSize = 100;
                listRequest.Fields = "nextPageToken, files(id, name, size,mimeType,webViewLink )";
                if (string.IsNullOrEmpty(settings.filter) == false)
                    listRequest.Q = settings.filter;
                // List files.
                IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;

                retval = "success";
            }
            catch (Exception ex)
            {
                retval = ex.Message;
            }
            return retval;
        }

        public DriveService VerifyGetDriveAccessForUser(CurrentSettings _settings)
        {
            //check the file exists
            if (!System.IO.File.Exists(_settings.keyFilePath))
            {
                Console.WriteLine("An Error occurred - Key file does not exist");
                return null;
            }

            string[] scopes = new string[] { DriveService.Scope.Drive }; //View Drive

            var certificate = new X509Certificate2(_settings.keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            try
            {
                ServiceAccountCredential credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(_settings.serviceAccount)
                    {
                        Scopes = scopes,
                        User = _settings.serviceAccount
                    }.FromCertificate(certificate));

                //Create the service
                DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = _settings.applicationName
                });

                return service;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Google.Apis.Drive.v3.Data.File> Preview(CurrentSettings _settings,string userEmail)
        {
            List<Google.Apis.Drive.v3.Data.File> retval = new List<Google.Apis.Drive.v3.Data.File>();
            try
            {

                DriveService service = PreviewGetDriveAccessForUser(_settings,userEmail);
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.PageSize = 100;
                listRequest.Fields = "nextPageToken, files(id, name, size,mimeType,webViewLink )";
                if (string.IsNullOrEmpty(settings.filter) == false)
                    listRequest.Q = settings.filter;
                // List files.
                IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;

                if (files != null && files.Count > 0)
                    retval = files.ToList();


            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public DriveService PreviewGetDriveAccessForUser(CurrentSettings _settings,string userEmail)
        {
            //check the file exists
            if (!System.IO.File.Exists(_settings.keyFilePath))
            {
                Console.WriteLine("An Error occurred - Key file does not exist");
                return null;
            }

            string[] scopes = new string[] { DriveService.Scope.Drive }; //View Drive

            var certificate = new X509Certificate2(_settings.keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            try
            {
                ServiceAccountCredential credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(_settings.serviceAccount)
                    {
                        Scopes = scopes,
                        User = userEmail
                    }.FromCertificate(certificate));

                //Create the service
                DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = _settings.applicationName
                });

                return service;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
