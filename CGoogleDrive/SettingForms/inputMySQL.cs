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
    public partial class inputMySQL : Form
    {
        CurrentSettings settings { get; set; }

        public inputMySQL()
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

        private string connStr
        {
            get
            {
                if (String.IsNullOrEmpty(cmbDatabase.Text) == true)
                {
                    return ConnectionString.MySQL(txtServer.Text, txtUsername.Text, txtPassword.Text, "sys");
                }
                else
                {
                    return ConnectionString.MySQL(txtServer.Text, txtUsername.Text, txtPassword.Text, cmbDatabase.Text);
                }
            }
        }

        public bool Save()
        {
            bool retval = false;
            try
            {
                settings.MySQL_input_server = txtServer.Text;
                settings.MySQL_input_username = txtUsername.Text;
                //settings.MySQL_input_password = txtPassword.Text;
                if (string.IsNullOrEmpty(txtPassword.Text) == true)
                {
                    settings.MySQL_input_password = String.Empty;
                }
                else
                {
                    settings.MySQL_input_password = Encryption.Encrypt(txtPassword.Text);
                }

                settings.MySQL_input_database = cmbDatabase.Text;
                settings.MySQL_input_query = txtQuery.Text;
                
               
                settings.MySQL_input_mail = cmbMail.Text;
                settings.MySQL_input_identifier = cmbIdentifier.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void inputMySQL_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.MySQL_input_server) == false)
                    txtServer.Text = settings.MySQL_input_server;

                if (string.IsNullOrEmpty(settings.MySQL_input_username) == false)
                    txtUsername.Text = settings.MySQL_input_username;

                if (string.IsNullOrEmpty(settings.MySQL_input_password) == false)
                {
                    txtPassword.Text = Encryption.Decrypt(settings.MySQL_input_password);
                }
                   
                if (string.IsNullOrEmpty(settings.MySQL_input_database) == false)
                    cmbDatabase.Text = settings.MySQL_input_database;

                if (string.IsNullOrEmpty(settings.MySQL_input_query) == false)
                    txtQuery.Text = settings.MySQL_input_query;

                if (string.IsNullOrEmpty(settings.MySQL_input_mail) == false)
                    cmbMail.Text = settings.MySQL_input_mail;

                if (string.IsNullOrEmpty(settings.MySQL_input_identifier) == false)
                    cmbIdentifier.Text = settings.MySQL_input_identifier;

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
                DataSet ds = Data.MySQL.GetDatabases(connStr);
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

        private void cmbMail_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtQuery.Text))
                {
                    DataSet ds = Data.MySQL.GetData(connStr, txtQuery.Text);
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
                if (!string.IsNullOrEmpty(txtQuery.Text))
                {
                    DataSet ds = Data.MySQL.GetData(connStr, txtQuery.Text);
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
                string result = Data.MySQL.ConnectionTest(connStr);
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtQuery.Text))
                {
                    DataSet ds = Data.MySQL.GetData(connStr, txtQuery.Text);
                    if (ds.IsEmpty() == false)
                    {
                        DataPreview dp = new DataPreview(ds);
                        dp.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }
    }
}
