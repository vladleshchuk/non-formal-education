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
    public partial class Grupy : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;

        public Grupy()
        {
            InitializeComponent();
            FillComboBox();
        }

        void GetGrupy()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM Grupy", conn);
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
                string query = "SELECT * FROM Osvitni_programy";

                DataSet dataset = new DataSet();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    adapter.Fill(dataset);
                }

                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    comboBox1.Items.Add(row["Nazva osv programy"].ToString());
                }
            }
        }

        private void Grupy_Load(object sender, EventArgs e)
        {
            GetGrupy();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Назва групи";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].HeaderText = "Назва освітньої програми";
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].HeaderText = "Курс";
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].HeaderText = "Форма навчання";
            dataGridView1.Columns[4].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Grupy([Nazva grupy], [Nazva osv programy], Kurs, [Forma navchannia]) VALUES(@nazvaGrupy, " +
                "@nazvaOsvProg, @kurs, @formaNavchannia)";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazvaGrupy", textBox1.Text);
                cmd.Parameters.AddWithValue("@nazvaOsvProg", comboBox1.Text);
                cmd.Parameters.AddWithValue("@kurs", textBox2.Text);
                cmd.Parameters.AddWithValue("@formaNavchannia", comboBox2.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Групу додано.");
                    GetGrupy();
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
            string query = "UPDATE Grupy SET [Nazva grupy] = @nazvaGrupy, [Nazva osv programy] = @nazvaOsvProg, " +
                "Kurs = @kurs, [Forma navchannia] = @formaNavchannia WHERE ID = @id";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazvaGrupy", textBox1.Text);
                cmd.Parameters.AddWithValue("@nazvaOsvProg", comboBox1.Text);
                cmd.Parameters.AddWithValue("@kurs", textBox2.Text);
                cmd.Parameters.AddWithValue("@formaNavchannia", comboBox2.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Групу оновлено.");
                    GetGrupy();
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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Grupy WHERE ID = @id";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Групу видалено.");
                    GetGrupy();
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
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dovidnyk_Oblik1 newForm = new Dovidnyk_Oblik1();
            newForm.ShowDialog();
        }
    }
}
