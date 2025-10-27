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
    public partial class zapyt_Zagalna_info : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;

        public zapyt_Zagalna_info()
        {
            InitializeComponent();
        }

        void GetSimple_Summary_Info()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM Simple_Summary_Info", conn);
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void zapyt_Zagalna_info_Load(object sender, EventArgs e)
        {
            GetSimple_Summary_Info();
            dataGridView1.Columns[0].HeaderText = "ННІ";
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].HeaderText = "Назва групи";
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].HeaderText = "Освітній рівень";
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].HeaderText = "ПІБ";
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].HeaderText = "Освітня платформа";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].HeaderText = "Курс";
            dataGridView1.Columns[5].Width = 280;
            dataGridView1.Columns[6].HeaderText = "Дисципліна";
            dataGridView1.Columns[6].Width = 225;
            dataGridView1.Columns[7].HeaderText = "Оцінка";
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].HeaderText = "№ протоколу";
            dataGridView1.Columns[8].Width = 70;
            dataGridView1.Columns[9].HeaderText = "Дата";
            dataGridView1.Columns[9].Width = 75;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
