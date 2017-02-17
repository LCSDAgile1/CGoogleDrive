using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGoogleDrive.SettingForms
{
    public partial class inputMongoDB : Form
    {
        CurrentSettings settings { get; set; }

        public inputMongoDB()
        {
            InitializeComponent();
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

        public bool Save()
        {
            bool retval = false;
            try
            {
                settings.MongoDB_input_server = txtServer.Text;
                settings.MongoDB_input_username = txtUsername.Text;
                //settings.MongoDB_input_password = txtPassword.Text;
                if (string.IsNullOrEmpty(txtPassword.Text) == true)
                {
                    settings.MongoDB_input_password = string.Empty;
                }
                else
                {
                    settings.MongoDB_input_password = Encryption.Encrypt(txtPassword.Text);
                }
                settings.MongoDB_input_database = cmbDatabase.Text;
                settings.MongoDB_input_collection = cmbCollection.Text;
                settings.MongoDB_input_mail = cmbMail.Text;
                settings.MongoDB_input_identifier = cmbIdentifier.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void inputMongoDB_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.MongoDB_input_server) == false)
                    txtServer.Text = settings.MongoDB_input_server;

                if (string.IsNullOrEmpty(settings.MongoDB_input_username) == false)
                    txtUsername.Text = settings.MongoDB_input_username;

                if (string.IsNullOrEmpty(settings.MongoDB_input_password) == false)
                    txtPassword.Text = Encryption.Decrypt(settings.MongoDB_input_password);

                if (string.IsNullOrEmpty(settings.MongoDB_input_database) == false)
                    cmbDatabase.Text = settings.MongoDB_input_database;

                if (string.IsNullOrEmpty(settings.MongoDB_input_collection) == false)
                    cmbCollection.Text = settings.MongoDB_input_collection;

                if (string.IsNullOrEmpty(settings.MongoDB_input_mail) == false)
                    cmbMail.Text = settings.MongoDB_input_mail;

                if (string.IsNullOrEmpty(settings.MongoDB_input_identifier) == false)
                    cmbIdentifier.Text = settings.MongoDB_input_identifier;

            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = string.Empty;
                if (txtUsername.Text != string.Empty || txtPassword.Text != string.Empty)
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text, txtUsername.Text, txtPassword.Text);
                }
                else
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text);
                }

                string result = Data.Mongo_DB.ConnectionTest(connStr,cmbDatabase.Text,cmbCollection.Text);
                if (result == "success")
                {
                    MessageBox.Show("Connection Test Successfull!", "CGoogleDrive");
                }
                else
                {
                    MessageBox.Show("Connection Test Failed : " + Environment.NewLine + result, "CGoogleDrive");
                }

            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            try
            {
                string connStr = string.Empty;
                if (txtUsername.Text != string.Empty || txtPassword.Text != string.Empty)
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text, txtUsername.Text, txtPassword.Text);
                }
                else
                {
                     connStr = ConnectionString.MongoDB(txtServer.Text);
                }
                List<BsonDocument> databases = Data.Mongo_DB.ListDatabases(connStr);
                if (databases.Count != 0)
                {
                    ComboBox ctrl = (ComboBox)sender;
                    ctrl.Items.Clear();
                    foreach (BsonDocument bd in databases)
                    {
                        ctrl.Items.Add(bd.GetValue("name"));
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            
        }

        private void cmbCollection_DropDown(object sender, EventArgs e)
        {
            try
            {
                string connStr = string.Empty;
                if (txtUsername.Text != string.Empty || txtPassword.Text != string.Empty)
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text, txtUsername.Text, txtPassword.Text);
                }
                else
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text);
                }
               List<BsonDocument> documents = Data.Mongo_DB.ListCollections(connStr,cmbDatabase.Text);
                if (documents.Count != 0)
                {
                    ComboBox ctrl = (ComboBox)sender;
                    ctrl.Items.Clear();
                    foreach (BsonDocument dc in documents)
                    {
                        ctrl.Items.Add(dc.GetValue("name"));
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void cmbMail_DropDown(object sender, EventArgs e)
        {
            try
            {
                string connStr = string.Empty;
                if (txtUsername.Text != string.Empty || txtPassword.Text != string.Empty)
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text, txtUsername.Text, txtPassword.Text);
                }
                else
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text);
                }
                DataSet ds = Data.Mongo_DB.GetData(connStr, cmbDatabase.Text, cmbCollection.Text);
                if (ds.IsEmpty() == false)
                {
                    ComboBox ctrl = (ComboBox)sender;
                    ctrl.Items.Clear();
                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        ctrl.Items.Add(dc.ColumnName);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void cmbIdentifier_DropDown(object sender, EventArgs e)
        {
            try
            {
                string connStr = string.Empty;
                if (txtUsername.Text != string.Empty || txtPassword.Text != string.Empty)
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text, txtUsername.Text, txtPassword.Text);
                }
                else
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text);
                }
                DataSet ds = Data.Mongo_DB.GetData(connStr, cmbDatabase.Text, cmbCollection.Text);
                if (ds.IsEmpty() == false)
                {
                    ComboBox ctrl = (ComboBox)sender;
                    ctrl.Items.Clear();
                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        ctrl.Items.Add(dc.ColumnName);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {

                string connStr = string.Empty;
                if (txtUsername.Text != string.Empty || txtPassword.Text != string.Empty)
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text, txtUsername.Text, txtPassword.Text);
                }
                else
                {
                    connStr = ConnectionString.MongoDB(txtServer.Text);
                }
                DataSet ds = Data.Mongo_DB.GetData(connStr, cmbDatabase.Text, cmbCollection.Text);

                if (ds.IsEmpty() == false)
                {
                    DataPreview dp = new DataPreview(ds);
                    dp.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

       

        
    }
}
