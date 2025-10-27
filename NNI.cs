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
    public partial class NNI : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;

        public NNI()
        {
            InitializeComponent();
        }

        void GetNNI()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM NNI", conn);
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetNNI();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Назва навчально-наукового інституту";
            dataGridView1.Columns[2].HeaderText = "ННІ";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 550;
            dataGridView1.Columns[2].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO NNI([Nazva NNI], NNI) VALUES(@nazvaNNI, @nni)";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazvaNNI", textBox1.Text);
                cmd.Parameters.AddWithValue("@nni", textBox2.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Навчально-науковий інститут додано.");
                    GetNNI();
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
            string query = "UPDATE NNI SET [Nazva NNI] = @nazvaNNI, NNI = @nni WHERE ID = @id";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nazvaNNI", textBox1.Text);
                cmd.Parameters.AddWithValue("@nni", textBox2.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Навчально-науковий інститут оновлено.");
                    GetNNI();
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
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM NNI WHERE ID = @id";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Навчально-науковий інститут видалено.");
                    GetNNI();
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
            textBox2.Text = "";

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
