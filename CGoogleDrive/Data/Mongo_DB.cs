using CGoogleDrive.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
namespace CGoogleDrive.Data
{
    class Mongo_DB
    {
        public static List<BsonDocument> ListDatabases(string connStr)
        {
            List<MongoDB.Bson.BsonDocument> retval = new List<BsonDocument>(); ;
            try
            {

                MongoClient client = new MongoClient(connStr);

                List<BsonDocument> databases = client.ListDatabases().ToList();
                retval = databases;
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static List<BsonDocument> ListCollections(string connStr,string database)
        {
            List<MongoDB.Bson.BsonDocument> retval = new List<BsonDocument>(); ;
            try
            {

                MongoClient client = new MongoClient(connStr);
                var db = client.GetDatabase(database);
                retval = db.ListCollections().ToList();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static DataSet GetData(string connStr, string database,string collection)
        {
            DataSet retval = new DataSet();
            try
            {

                MongoClient client = new MongoClient(connStr);
                var db = client.GetDatabase(database);
                var coll = db.GetCollection<BsonDocument>(collection);
                List<BsonDocument> results = coll.Find(new BsonDocument()).ToList();
                DataTable dt = Classes.BsonToDataTable.BsonListToDataTable(results);
                if (dt != null)
                {
                    retval.Tables.Add(dt);
                }
                
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static DataSet GetData(CurrentSettings settings)
        {
            DataSet retval = new DataSet();
            try
            {
                string connStr = ConnectionString.MongoDB(settings.MongoDB_input_server);
                MongoClient client = new MongoClient(connStr);
                var db = client.GetDatabase(settings.MongoDB_input_database);
                var coll = db.GetCollection<BsonDocument>(settings.MongoDB_input_collection);
                List<BsonDocument> results = coll.Find(new BsonDocument()).ToList();
                DataTable dt = Classes.BsonToDataTable.BsonListToDataTable(results);
                if (dt != null)
                {
                    retval.Tables.Add(dt);
                }

            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        public static string ConnectionTest(string connStr, string database, string collection)
        {
            string retval = string.Empty;
            try
            {

                MongoClient client = new MongoClient(connStr);
                var db = client.GetDatabase(database);
                var coll = db.GetCollection<BsonDocument>(collection);
                var output = coll.Find(new BsonDocument()).ToList();
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
                string connStr = ConnectionString.MongoDB(settings.MongoDB_output_server);
                string database = settings.MongoDB_output_database;
                MongoClient client = new MongoClient(connStr);
                var db = client.GetDatabase(database);
                
                List<BsonDocument> collections = db.ListCollections().ToList();
                List<string> names = new List<string>();
                foreach (BsonDocument dc in collections)
                {
                    names.Add(dc.GetValue("name").ToString());
                }

                if (names.Contains("cgoogledrive") == false)
                {
                    db.CreateCollection("cgoogledrive");
                }
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

                string connStr = ConnectionString.MongoDB(settings.MongoDB_output_server);
                string database = settings.MongoDB_output_database;
                MongoClient client = new MongoClient(connStr);
                var db = client.GetDatabase(database);
                var coll = db.GetCollection<BsonDocument>("cgoogledrive");
                
                if (identifier == null)
                    identifier = string.Empty;

                var document = new BsonDocument
                {
                    {"fileId",file.Id},
                    {"name",file.Name},
                    {"size",file.Size},
                    {"mimeType",file.MimeType},
                    {"webViewLink",file.WebViewLink},
                    {"identifier",identifier}
                };

                coll.InsertOne(document);

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
                string connStr = ConnectionString.MongoDB(settings.MongoDB_output_server);
                string database = settings.MongoDB_output_database;
                MongoClient client = new MongoClient(connStr);
                var db = client.GetDatabase(database);
                var coll = db.GetCollection<BsonDocument>("cgoogledrive");
                coll.DeleteMany(new BsonDocument());
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }
    }
}
