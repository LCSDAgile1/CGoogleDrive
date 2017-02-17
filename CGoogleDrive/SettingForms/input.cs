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
    public partial class input : Form
    {
        CurrentSettings settings { get; set; }

        public input()
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
                settings.inputType = cmbInputType.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void input_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.inputType) == false)
                    cmbInputType.Text = settings.inputType;
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }
    }
}
