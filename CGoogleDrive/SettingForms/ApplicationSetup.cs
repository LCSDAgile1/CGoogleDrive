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
    public partial class ApplicationSetup : Form
    {
        private TreeNode selectedNode { get; set; }
        public ApplicationSetup()
        {
            InitializeComponent();
        }

        private void ApplicationSetup_Load(object sender, EventArgs e)
        {
            tree_SettingsArea.ExpandAll();
            GoogleSetup gs = new GoogleSetup();
            gs.AutoScroll = true;
            gs.FormBorderStyle = FormBorderStyle.None;
            gs.Dock = DockStyle.Fill;
            gs.TopLevel = false;
            pnlSettings.Controls.Add(gs);
            gs.Show();

        }


        private void tree_SettingsArea_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (pnlSettings.Controls.Count >= 1)
            {
                var CurrentControl = pnlSettings.Controls[0];

                //Save Data Before Moving On
                if (CurrentControl is GoogleSetup)
                {
                    GoogleSetup gs = (GoogleSetup)CurrentControl;
                    gs.Save();
                }
                if (CurrentControl is inputFlat)
                {
                    inputFlat inf = (inputFlat)CurrentControl;
                    inf.Save();
                }
                if (CurrentControl is inputSQL)
                {
                    inputSQL isql = (inputSQL)CurrentControl;
                    isql.Save();
                }

                if (CurrentControl is inputMySQL)
                {
                    inputMySQL imsql = (inputMySQL)CurrentControl;
                    imsql.Save();
                }
                if (CurrentControl is inputMongoDB)
                {
                    inputMongoDB imdb = (inputMongoDB)CurrentControl;
                    imdb.Save();
                }

                if (CurrentControl is input)
                {
                    input i = (input)CurrentControl;
                    i.Save();
                }

                if (CurrentControl is outputFlat)
                {
                    outputFlat of = (outputFlat)CurrentControl;
                    of.Save();
                }

                if (CurrentControl is output)
                {
                    output o = (output)CurrentControl;
                    o.Save();
                }

                if (CurrentControl is outputSQL)
                {
                    outputSQL os = (outputSQL)CurrentControl;
                    os.Save();
                }

                if (CurrentControl is outputMySQL)
                {
                    outputMySQL oms = (outputMySQL)CurrentControl;
                    oms.Save();
                }

                if (CurrentControl is outputMongoDB)
                {
                    outputMongoDB omdb = (outputMongoDB)CurrentControl;
                    omdb.Save();
                }
                if (CurrentControl is outputGlobal)
                {
                    outputGlobal og = (outputGlobal)CurrentControl;
                    og.Save();
                }
            }

            //Load The Selected View and clear the exiting view
            pnlSettings.Controls.Clear();
            switch (e.Node.Tag.ToString())
            {
                case "Input":
                    input inputForm = new input();
                    inputForm.AutoScroll = true;
                    inputForm.FormBorderStyle = FormBorderStyle.None;
                    inputForm.Dock = DockStyle.Fill;
                    inputForm.TopLevel = false;
                    pnlSettings.Controls.Add(inputForm);
                    inputForm.Show();
                    break;
                case "Google":
                    GoogleSetup GoogleSetupForm = new GoogleSetup();
                    GoogleSetupForm.AutoScroll = true;
                    GoogleSetupForm.FormBorderStyle = FormBorderStyle.None;
                    GoogleSetupForm.Dock = DockStyle.Fill;
                    GoogleSetupForm.TopLevel = false;
                    pnlSettings.Controls.Add(GoogleSetupForm);
                    GoogleSetupForm.Show();
                    break;
                case "input_FlatFile":
                    inputFlat inputFlatForm = new inputFlat();
                    inputFlatForm.AutoScroll = true;
                    inputFlatForm.FormBorderStyle = FormBorderStyle.None;
                    inputFlatForm.Dock = DockStyle.Fill;
                    inputFlatForm.TopLevel = false;
                    pnlSettings.Controls.Add(inputFlatForm);
                    inputFlatForm.Show();
                    break;
                case "input_SQL":
                    inputSQL inputSQLForm = new inputSQL();
                    inputSQLForm.AutoScroll = true;
                    inputSQLForm.FormBorderStyle = FormBorderStyle.None;
                    inputSQLForm.Dock = DockStyle.Fill;
                    inputSQLForm.TopLevel = false;
                    pnlSettings.Controls.Add(inputSQLForm);
                    inputSQLForm.Show();
                    break;
                case "input_MySQL":
                    inputMySQL inputMySQLForm = new inputMySQL();
                    inputMySQLForm.AutoScroll = true;
                    inputMySQLForm.FormBorderStyle = FormBorderStyle.None;
                    inputMySQLForm.Dock = DockStyle.Fill;
                    inputMySQLForm.TopLevel = false;
                    pnlSettings.Controls.Add(inputMySQLForm);
                    inputMySQLForm.Show();
                    break;
                case "input_MongoDB":
                    inputMongoDB inputMongoDBForm = new inputMongoDB();
                    inputMongoDBForm.AutoScroll = true;
                    inputMongoDBForm.FormBorderStyle = FormBorderStyle.None;
                    inputMongoDBForm.Dock = DockStyle.Fill;
                    inputMongoDBForm.TopLevel = false;
                    pnlSettings.Controls.Add(inputMongoDBForm);
                    inputMongoDBForm.Show();
                    break;
                case "output_FlatFile":
                    outputFlat outputFlatForm = new outputFlat();
                    outputFlatForm.AutoScroll = true;
                    outputFlatForm.FormBorderStyle = FormBorderStyle.None;
                    outputFlatForm.Dock = DockStyle.Fill;
                    outputFlatForm.TopLevel = false;
                    pnlSettings.Controls.Add(outputFlatForm);
                    outputFlatForm.Show();
                    break;
                case "Output":
                    output outputForm = new output();
                    outputForm.AutoScroll = true;
                    outputForm.FormBorderStyle = FormBorderStyle.None;
                    outputForm.Dock = DockStyle.Fill;
                    outputForm.TopLevel = false;
                    pnlSettings.Controls.Add(outputForm);
                    outputForm.Show();
                    break;
                case "output_SQL":
                    outputSQL outputSQLForm = new outputSQL();
                    outputSQLForm.AutoScroll = true;
                    outputSQLForm.FormBorderStyle = FormBorderStyle.None;
                    outputSQLForm.Dock = DockStyle.Fill;
                    outputSQLForm.TopLevel = false;
                    pnlSettings.Controls.Add(outputSQLForm);
                    outputSQLForm.Show();
                    break;
                case "output_MySQL":
                    outputMySQL outputMySQLForm = new outputMySQL();
                    outputMySQLForm.AutoScroll = true;
                    outputMySQLForm.FormBorderStyle = FormBorderStyle.None;
                    outputMySQLForm.Dock = DockStyle.Fill;
                    outputMySQLForm.TopLevel = false;
                    pnlSettings.Controls.Add(outputMySQLForm);
                    outputMySQLForm.Show();
                    break;
                case "output_MongoDB":
                    outputMongoDB outputMongoDBForm = new outputMongoDB();
                    outputMongoDBForm.AutoScroll = true;
                    outputMongoDBForm.FormBorderStyle = FormBorderStyle.None;
                    outputMongoDBForm.Dock = DockStyle.Fill;
                    outputMongoDBForm.TopLevel = false;
                    pnlSettings.Controls.Add(outputMongoDBForm);
                    outputMongoDBForm.Show();
                    break;
                case "output_Global":
                    outputGlobal outputGlobalForm = new outputGlobal();
                    outputGlobalForm.AutoScroll = true;
                    outputGlobalForm.FormBorderStyle = FormBorderStyle.None;
                    outputGlobalForm.Dock = DockStyle.Fill;
                    outputGlobalForm.TopLevel = false;
                    pnlSettings.Controls.Add(outputGlobalForm);
                    outputGlobalForm.Show();
                    break;
            }
            
        }

       
    }
}
