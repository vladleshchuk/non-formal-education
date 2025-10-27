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
    public partial class zapyt_Dysc_OsvPlatf : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;

        public zapyt_Dysc_OsvPlatf()
        {
            InitializeComponent();
        }

        void GetDysc_OsvPlat()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM Cross_Osv_platf1", conn);
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void zapyt_Dysc_OsvPlatf_Load(object sender, EventArgs e)
        {
            GetDysc_OsvPlat();
            dataGridView1.Columns[0].HeaderText = "Дисципліна";
            dataGridView1.Columns[0].Width = 250;
            dataGridView1.Columns[1].HeaderText = "Усього";
            dataGridView1.Columns[1].Width = 60;
            //dataGridView1.Columns[2].HeaderText = "Бакалаври";
            dataGridView1.Columns[2].Width = 80;
            //dataGridView1.Columns[3].HeaderText = "Магістри";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 100;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
