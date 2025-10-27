using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WFApp_NFE
{
    public partial class zapyt_NNI : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;

        public zapyt_NNI()
        {
            InitializeComponent();
        }

        void GetNNI_Stat()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM NNI_Stat", conn);
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zapyt_NNI_Load(object sender, EventArgs e)
        {
            GetNNI_Stat();
            dataGridView1.Columns[0].HeaderText = "ННІ";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].HeaderText = "К-ть";
            dataGridView1.Columns[1].Width = 60;
        }
    }
}
