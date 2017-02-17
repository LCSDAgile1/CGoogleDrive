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
    public partial class outputMySQL : Form
    {
        CurrentSettings settings { get; set; }

        public outputMySQL()
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
                settings.MySQL_output_server = txtServer.Text;
                settings.MySQL_output_username = txtUsername.Text;
                //settings.SQL_input_password = txtPassword.Text;
                if (string.IsNullOrEmpty(txtPassword.Text) == true)
                {
                    settings.MySQL_output_password = string.Empty;
                }
                else
                {
                    settings.MySQL_output_password = Encryption.Encrypt(txtPassword.Text);
                }
                settings.MySQL_output_database = cmbDatabase.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void outputMySQL_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.MySQL_output_server) == false)
                    txtServer.Text = settings.MySQL_output_server;

                if (string.IsNullOrEmpty(settings.MySQL_output_username) == false)
                    txtUsername.Text = settings.MySQL_output_username;

                if (string.IsNullOrEmpty(settings.MySQL_output_password) == false)
                {
                    if (settings.MySQL_output_password.EndsWith("==") == true)
                        txtPassword.Text = Encryption.Decrypt(settings.MySQL_output_password);
                }

                if (string.IsNullOrEmpty(settings.MySQL_output_database) == false)
                    cmbDatabase.Text = settings.MySQL_output_database;
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
    }
}
