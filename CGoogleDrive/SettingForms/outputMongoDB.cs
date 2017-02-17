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
    public partial class outputMongoDB : Form
    {
        CurrentSettings settings { get; set; }

        public outputMongoDB()
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
                settings.MongoDB_output_server = txtServer.Text;
                settings.MongoDB_output_username = txtUsername.Text;
                //settings.MongoDB_output_password = txtPassword.Text;
                if (string.IsNullOrEmpty(txtPassword.Text) == true)
                {
                    settings.MongoDB_output_password = string.Empty;
                }
                else
                {
                    settings.MongoDB_output_password = Encryption.Encrypt(txtPassword.Text);
                }
                settings.MongoDB_output_database = cmbDatabase.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
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

        private void outputMongoDB_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.MongoDB_output_server) == false)
                    txtServer.Text = settings.MongoDB_output_server;

                if (string.IsNullOrEmpty(settings.MongoDB_output_username) == false)
                    txtUsername.Text = settings.MongoDB_output_username;


                if (string.IsNullOrEmpty(settings.MongoDB_output_password) == false)
                {
                    txtPassword.Text = Encryption.Decrypt(settings.MongoDB_output_password);
                }

                if (string.IsNullOrEmpty(settings.MongoDB_output_database) == false)
                    cmbDatabase.Text = settings.MongoDB_output_database;
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

                string result = Data.Mongo_DB.ConnectionTest(connStr, cmbDatabase.Text, "cgoogledrive");
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
    }
}
