using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGoogleDrive.SettingForms
{
    public partial class inputFlat : Form
    {
        CurrentSettings settings { get; set; }

        public inputFlat()
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
                settings.FlatFile_input_path = txtPath.Text;
                settings.FlatFile_input_identifer = cmbIdentifier.Text;
                settings.FlatFile_input_mail = cmbMail.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void inputFlat_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.FlatFile_input_path) == false)
                    txtPath.Text = settings.FlatFile_input_path;

                if (string.IsNullOrEmpty(settings.FlatFile_input_mail) == false)
                    cmbMail.Text = settings.FlatFile_input_mail;

                if (string.IsNullOrEmpty(settings.FlatFile_input_identifer) == false)
                    cmbIdentifier.Text = settings.FlatFile_input_identifer;

            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedPath = string.Empty;
                var t = new Thread((ThreadStart)(() =>
                {
                    OpenFileDialog fbd = new OpenFileDialog();
                    fbd.InitialDirectory = Environment.CurrentDirectory;
                    //fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                    fbd.Filter = "CSV File|*.csv";
                    if (fbd.ShowDialog() == DialogResult.Cancel)
                        return;

                    selectedPath = fbd.FileName;
                }));

                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                txtPath.Text = selectedPath;
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
                StreamReader sr = new StreamReader(txtPath.Text);
                DataTable dt = sr.ConvertCSVtoDataTable();

                if (dt.IsEmpty() == false)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    DataPreview dp = new DataPreview(ds);
                    dp.ShowDialog();
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
                StreamReader sr = new StreamReader(txtPath.Text);
                DataTable dt = sr.ConvertCSVtoDataTable();

                if (dt.IsEmpty() == false)
                {
                    ComboBox ctrl = (ComboBox)sender;
                    ctrl.Items.Clear();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        ctrl.Items.Add(dc.ColumnName.Replace("\"", String.Empty));
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
                StreamReader sr = new StreamReader(txtPath.Text);
                DataTable dt = sr.ConvertCSVtoDataTable();

                if (dt.IsEmpty() == false)
                {
                    ComboBox ctrl = (ComboBox)sender;
                    ctrl.Items.Clear();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        ctrl.Items.Add(dc.ColumnName.Replace("\"", String.Empty));
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
