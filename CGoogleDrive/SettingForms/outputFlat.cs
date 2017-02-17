using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGoogleDrive.SettingForms
{
    public partial class outputFlat : Form
    {
        CurrentSettings settings { get; set; }

        public outputFlat()
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

        private void outputFlat_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.FlatFile_ouput_path) == false)
                    txtPath.Text = settings.FlatFile_ouput_path;
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
                settings.FlatFile_ouput_path = txtPath.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedPath = string.Empty;
                var t = new Thread((ThreadStart)(() =>
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    //fbd.InitialDirectory = Environment.CurrentDirectory;
                    fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                    //fbd.Filter = "CSV File|*.csv";
                    if (fbd.ShowDialog() == DialogResult.Cancel)
                        return;

                    selectedPath = fbd.SelectedPath;
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

       
    }
}
