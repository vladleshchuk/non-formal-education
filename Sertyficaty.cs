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
    public partial class Sertyficaty : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;

        public Sertyficaty()
        {
            InitializeComponent();
            FillComboBox();
        }

        void GetSertyficaty()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM Sertyfikaty", conn);
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
        }

        private void FillComboBox()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=NFE_db.accdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM Zdobuvachi_osvity";

                DataSet dataset = new DataSet();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    adapter.Fill(dataset);
                }

                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    comboBox1.Items.Add(row["Nomer stud kvytka"].ToString());
                }

                DataSet dataset2 = new DataSet();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    adapter.Fill(dataset2);
                }

                foreach (DataRow row in dataset2.Tables[0].Rows)
                {
                    comboBox2.Items.Add(row["PIB"].ToString());
                }
            }
        }

        private void Sertyficaty2_Load(object sender, EventArgs e)
        {
            this.sertyfikatyTableAdapter.Fill(this.nFE_dbDataSet.Sertyfikaty);
            sertyfikatyBindingSource.DataSource = this.nFE_dbDataSet.Sertyfikaty;
            GetSertyficaty();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                sertyfikatyBindingSource.EndEdit();
                sertyfikatyTableAdapter.Update(this.nFE_dbDataSet.Sertyfikaty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sertyfikatyBindingSource.ResetBindings(false);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog fileDialog = new OpenFileDialog() { Filter = "JPEG files|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(fileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви справді хочете видалити сертифікат?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                sertyfikatyBindingSource.RemoveCurrent();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                    dataGridView1.DataSource = sertyfikatyBindingSource;
                else
                {
                    var query = from o in this.nFE_dbDataSet.Sertyfikaty
                                where o.PIB.Contains(txtSearch.Text) || o.Nomer_sertyficatu.Contains(txtSearch.Text)
                                select o;
                    dataGridView1.DataSource = query.ToList();

                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Text = "";
            pictureBox1.Image = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = $"[Nomer sertyficatu] LIKE '%{txtSearch.Text}%' OR " +
               $"[Nomer stud kvytka] LIKE '%{txtSearch.Text}%' OR " +
               $"PIB LIKE '%{txtSearch.Text}%' OR " +
               $"[Nazva osv platformy] LIKE '%{txtSearch.Text}%' OR " +
               $"[Nazva kursu] LIKE '%{txtSearch.Text}%' OR " +
               $"CONVERT([Data], 'System.String') LIKE '%{txtSearch.Text}%' OR " +
               $"CONVERT([Nomer sertyficatu], 'System.String') LIKE '%{txtSearch.Text}%' OR " +
               $"[URL] LIKE '%{txtSearch.Text}%'";
            dataGridView1.DataSource = dv;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = true;
                textBox1.Focus();
                string query = "INSERT INTO Sertyfikaty([Nomer sertyficatu]) VALUES(@nomerSertyficatu)";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nomerSertyficatu", textBox1.Text);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Новий номер сертифікату додано.");
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка: " + ex.Message);
                        this.Hide();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sertyfikatyBindingSource.ResetBindings(false);
                
            }

            Sertyficaty form = new Sertyficaty();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sertyficaty form = new Sertyficaty();
            form.Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Dovidnyk_Sertyfikaty form = new Dovidnyk_Sertyfikaty();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
