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
    public partial class output : Form
    {
        CurrentSettings settings { get; set; }

        public output()
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
                settings.outputType = cmbOutputType.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void output_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.outputType) == false)
                    cmbOutputType.Text = settings.outputType;
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }
    }
}
