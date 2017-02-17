using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGoogleDrive
{
    public partial class DataPreview : Form
    {
        public DataSet _Data { get; set; }
        public List<KeyValuePair<string, string>> _Columns { get; set; }
        public DataPreview(DataSet data, List<KeyValuePair<string, string>> columns = null)
        {
            _Data = data;
            if (columns != null)
            {
                _Columns = columns;
            }
            InitializeComponent();
        }

        private void DataPreview_Shown(object sender, EventArgs e)
        {
            try
            {
                if (_Columns != null)
                {
                    this.dataGridView1.AutoGenerateColumns = false;
                    foreach (KeyValuePair<string, string> dc in _Columns)
                    {
                        dataGridView1.Columns.Add(dc.Key, dc.Value);
                    }

                    foreach (DataGridViewColumn gc in dataGridView1.Columns)
                    {
                        gc.DataPropertyName = gc.Name;
                    }
                }
                else
                {
                    this.dataGridView1.AutoGenerateColumns = true;
                }

                if (_Data.Tables[0].Columns.Count >= 4)
                {
                    this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }
                else
                {
                    this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                
                this.dataGridView1.DataSource = _Data;
                this.dataGridView1.DataMember = _Data.Tables[0].TableName;
            }
            catch (Exception ex)
            {
                ex.Write();
            }
        }

        private void DataPreview_Load(object sender, EventArgs e)
        {

        }
    }
}
