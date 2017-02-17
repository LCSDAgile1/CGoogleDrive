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
    public partial class GoogleSetup : Form
    {
        CurrentSettings settings { get; set; }
        public GoogleSetup()
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
                settings.serviceAccount = txtServiceAccount.Text;
                settings.keyFilePath = txtKeyFile.Text;
                settings.applicationName = txtApplicationName.Text;
                settings.maxParallel = numMaxParralel.Value.ToString();
                settings.filter = txtFilter.Text;
                settings.Save();
            }
            catch (Exception ex)
            {
                ex.Write();
            }
            return retval;
        }

        private void GoogleSetup_Load(object sender, EventArgs e)
        {
            try
            {
                //load settings if not null or string.empty
                if (string.IsNullOrEmpty(settings.serviceAccount) == false)
                    txtServiceAccount.Text = settings.serviceAccount;

                if (string.IsNullOrEmpty(settings.keyFilePath) == false)
                    txtKeyFile.Text = settings.keyFilePath;

                if (string.IsNullOrEmpty(settings.applicationName) == false)
                    txtApplicationName.Text = settings.applicationName;

                if (string.IsNullOrEmpty(settings.maxParallel) == false)
                    numMaxParralel.Value = Decimal.Parse(settings.maxParallel);

                if (string.IsNullOrEmpty(settings.filter) == false)
                {
                    txtFilter.Text = settings.filter;
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
                GoogleAccess ga = new GoogleAccess();
                string result = ga.Verify(settings);
                if (result == "success")
                {
                    MessageBox.Show("Access to Google Drive Verified!", "CGoogleDrive");
                }
                else
                {
                    MessageBox.Show(result, "CGoogleDrive");
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
                string userEmail = ShowDialog("Please enter the e-mail of a user to preview.", "CGoogleDrive");
                if (string.IsNullOrEmpty(userEmail)){
                    MessageBox.Show("You must enter an e-mail address to preview!","CGoogleDrive");
                    return;
                }

                GoogleAccess ga = new GoogleAccess();
                DataSet ds = ga.Preview(settings, userEmail).ToDataSet();
                List<KeyValuePair<string, string>> columns = new List<KeyValuePair<string, string>>();
                columns.Add(new KeyValuePair<string,string>("Id", "Id"));
                columns.Add(new KeyValuePair<string, string>("MimeType", "MimeType"));
                columns.Add(new KeyValuePair<string, string>("Name", "Name"));
                columns.Add(new KeyValuePair<string, string>("Size", "Size"));
                columns.Add(new KeyValuePair<string, string>("WebViewLink", "WebViewLink"));
                DataPreview dp = new DataPreview(ds,columns);
                dp.ShowDialog();

            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20,Width = 400, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void btnFilterDocumentation_Click(object sender, EventArgs e)
        {
            try
            {
                string link = "https://developers.google.com/drive/v3/web/search-parameters";
                System.Diagnostics.Process.Start(link);
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void btnKeyFileBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedPath = string.Empty;
                var t = new Thread((ThreadStart)(() =>
                {
                    OpenFileDialog fbd = new OpenFileDialog();
                    fbd.InitialDirectory = Environment.CurrentDirectory;
                    //fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                    fbd.Filter = "p12 File|*.p12";
                    if (fbd.ShowDialog() == DialogResult.Cancel)
                        return;

                    selectedPath = fbd.FileName;
                }));

                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                if (string.IsNullOrEmpty(selectedPath) == false)
                    txtKeyFile.Text = selectedPath;
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

    }
}
