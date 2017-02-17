using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGoogleDrive.SettingForms
{
    public partial class outputSQL : Form
    {
        CurrentSettings settings { get; set; }

        public outputSQL()
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
                settings.SQL_output_server = cmbServer.Text;
                if (settings.SQL_input_authenticationType == "Windows Authentication")
                {
                    settings.SQL_output_username = string.Empty;
                    settings.SQL_output_password = string.Empty;
                }
                else
                {
                    settings.SQL_output_username = txtUsername.Text;

                    //settings.SQL_input_password = txtPassword.Text;
                    if (string.IsNullOrEmpty(txtPassword.Text) == true)
                    {
                        settings.SQL_output_password = string.Empty;
                    }
                    else
                    {
                        settings.SQL_output_password = Encryption.Encrypt(txtPassword.Text);
                    }
                }
                settings.SQL_output_database = cmbDatabase.Text;
                settings.SQL_output_authenticationType = cmbAuthentication.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void outputSQL_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.SQL_output_server) == false)
                    cmbServer.Text = settings.SQL_output_server;

                if (string.IsNullOrEmpty(settings.SQL_output_authenticationType) == false)
                    cmbAuthentication.Text = settings.SQL_output_authenticationType;


                if (string.IsNullOrEmpty(settings.SQL_output_username) == false)
                    txtUsername.Text = settings.SQL_output_username;

                if (string.IsNullOrEmpty(settings.SQL_output_password) == false)
                {
                    if (settings.SQL_output_password.EndsWith("==") == true)
                        txtPassword.Text = Encryption.Decrypt(settings.SQL_output_password);
                }

                AuthenticationSwitch();

                if (string.IsNullOrEmpty(settings.SQL_output_database) == false)
                    cmbDatabase.Text = settings.SQL_output_database;

            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void AuthenticationSwitch()
        {
            try
            {
                switch (cmbAuthentication.Text)
                {
                    case "Windows Authentication":
                        txtUsername.Text = Environment.UserDomainName + "\\" + Environment.UserName;
                        txtPassword.Text = String.Empty;
                        txtPassword.Enabled = false;
                        txtPassword.Enabled = false;
                        break;
                    case "SQL Server Authentication":
                        txtUsername.Text = String.Empty;
                        txtPassword.Text = String.Empty;
                        txtUsername.Enabled = true;
                        txtPassword.Enabled = true;
                        break;
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void cmbServer_DropDown(object sender, EventArgs e)
        {
            // Retrieve the enumerator instance and then the data.
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            ComboBox ctrl = (ComboBox)sender;
            ctrl.Items.Clear();
            foreach (DataRow dr in table.Rows)
            {
                ctrl.Items.Add(dr[0].ToString());
            }
        }

        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            try
            {
                string connStr = string.Empty;
                if (cmbAuthentication.Text == "Windows Authentication")
                {
                    connStr = ConnectionString.SQL_Windows(cmbServer.Text, "msdb");
                }
                else
                {
                    connStr = ConnectionString.SQL_Server(cmbServer.Text, "msdb", txtUsername.Text, txtPassword.Text);
                }

                DataSet ds = Data.SQL.ListDatabases(connStr);
                if (ds.IsEmpty() == false)
                {
                    ComboBox ctrl = (ComboBox)sender;
                    ctrl.Items.Clear();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ctrl.Items.Add(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void cmbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AuthenticationSwitch();
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
                if (cmbAuthentication.Text == "Windows Authentication")
                {
                    connStr = ConnectionString.SQL_Windows(cmbServer.Text, cmbDatabase.Text);
                }
                else
                {
                    connStr = ConnectionString.SQL_Server(cmbServer.Text, cmbDatabase.Text, txtUsername.Text, txtPassword.Text);
                }

                string result = Data.SQL.ConnectionTest(connStr);
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
