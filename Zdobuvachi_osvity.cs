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
    public partial class Zdobuvachi_osvity : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;

        public Zdobuvachi_osvity()
        {
            InitializeComponent();
            FillComboBox();
        }

        void GetZdobuvachiOsvity()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM Zdobuvachi_osvity", conn);
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
                string query = "SELECT * FROM Grupy";

                DataSet dataset = new DataSet();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    adapter.Fill(dataset);
                }

                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    comboBox1.Items.Add(row["Nazva grupy"].ToString());
                }
            }
        }

        private void Zdobuvachi_osvity_Load(object sender, EventArgs e)
        {
            GetZdobuvachiOsvity();
            dataGridView1.Columns[0].HeaderText = "Номер студентського квитка";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].HeaderText = "Назва групи";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].HeaderText = "ПІБ";
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].HeaderText = "E-mail";
            dataGridView1.Columns[3].Width = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Zdobuvachi_osvity([Nomer stud kvytka], [Nazva grupy], PIB, [e-mail]) " +
                "VALUES(@nomerStudKvytka, @nazvaGrupy, @pib, @email)";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nomerStudKvytka", textBox1.Text);
                cmd.Parameters.AddWithValue("@nazvaGrupy", comboBox1.Text);
                cmd.Parameters.AddWithValue("@pib", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Дані про студента додано.");
                    GetZdobuvachiOsvity();
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
            string query = "UPDATE Zdobuvachi_osvity SET [Nomer stud kvytka] = @nomerStudKvytka, [Nazva grupy] = @nazvaGrupy, " +
                "PIB = @pib, [e-mail] = @email WHERE [Nomer stud kvytka] = @nomerStudKvytka";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nomerStudKvytka", textBox1.Text);
                cmd.Parameters.AddWithValue("@nazvaGrupy", comboBox1.Text);
                cmd.Parameters.AddWithValue("@pib", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Дані студента оновлено.");
                    GetZdobuvachiOsvity();
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
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Zdobuvachi_osvity WHERE [Nomer stud kvytka] = @nomerStudKvytka";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nomerStudKvytka", Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Nomer stud kvytka"].Value));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Дані студента видалено.");
                    GetZdobuvachiOsvity();
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
            textBox3.Text = "";
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
