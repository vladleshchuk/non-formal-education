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
    public partial class Zarahuvannia_neform_osvity : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;

        public Zarahuvannia_neform_osvity()
        {
            InitializeComponent();
            FillComboBox();
        }

        void GetZarahuvanniaNeformOsvity()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM Zarahuvannia_neform_osvity", conn);
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void FillComboBox()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM Sertyfikaty";

                DataSet dataset = new DataSet();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    adapter.Fill(dataset);
                }

                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    comboBox1.Items.Add(row["Nomer sertyficatu"].ToString());
                }

                string query2 = "SELECT * FROM Dyscypliny";

                DataSet dataset2 = new DataSet();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query2, connection))
                {
                    adapter.Fill(dataset2);
                }

                foreach (DataRow row in dataset2.Tables[0].Rows)
                {
                    comboBox2.Items.Add(row["Nazva dyscypliny"].ToString());
                }
            }
        }

        private void Zarahuvannia_neform_osvity_Load(object sender, EventArgs e)
        {
            GetZarahuvanniaNeformOsvity();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Regular);
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Номер сертифікату";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].HeaderText = "Назва дисципліни";
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].HeaderText = "Номер протоколу";
            dataGridView1.Columns[3].Width = 75;
            dataGridView1.Columns[4].HeaderText = "Дата протоколу";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].HeaderText = "Оцінка";
            dataGridView1.Columns[5].Width = 75;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Zarahuvannia_neform_osvity([Nomer sertyficatu], [Nazva dyscypliny], [Nomer protokolu], [Data protokolu], Ocinka) " +
                "VALUES(@nomerSertyfikatu, @nazvaDyscypliny, @nomerProtokolu, @dataProtokolu, @ocinka)";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nomerSertyfikatu", comboBox1.Text);
                cmd.Parameters.AddWithValue("@nazvaDyscypliny", comboBox2.Text);
                cmd.Parameters.AddWithValue("@nomerProtokolu", textBox1.Text);
                cmd.Parameters.AddWithValue("@dataProtokolu", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ocinka", textBox2.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Дані про зарахування додано.");
                    GetZarahuvanniaNeformOsvity();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Zarahuvannia_neform_osvity SET [Nomer sertyficatu] = @nomerSertyfikatu, [Nazva dyscypliny] = @nazvaDyscypliny, " +
                "[Nomer protokolu] = @nomerProtokolu, [Data protokolu] = @dataProtokolu, [Ocinka] = @ocinka WHERE ID = @id";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nomerSertyfikatu", comboBox1.Text);
                cmd.Parameters.AddWithValue("@nazvaDyscypliny", comboBox2.Text);
                cmd.Parameters.AddWithValue("@nomerProtokolu", textBox1.Text);
                cmd.Parameters.AddWithValue("@dataProtokolu", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ocinka", textBox2.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Дані про зарахування оновлено.");
                    GetZarahuvanniaNeformOsvity();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Zarahuvannia_neform_osvity WHERE ID = @id";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Зарахування видалено.");
                    GetZarahuvanniaNeformOsvity();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Dovidnyk_Oblik1 newForm = new Dovidnyk_Oblik1();
            newForm.ShowDialog();
        }
    }
}
