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
    public partial class Login : Form
    {
        private OleDbConnection conn = new OleDbConnection();


        public Login()
        {
            InitializeComponent();

            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\НУВГП\4 КУРС\2 сем\ДИПЛОМКА\NFE app project\WFApp_NFE\bin\Debug\NFE_db.accdb;Persist Security Info=False";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT *FROM Users WHERE Username = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'";
            OleDbDataReader or = cmd.ExecuteReader();

            int count = 0;
            while (or.Read())
            {
                count = count + 1;
            }
            if (count ==1)
            {
                //MessageBox.Show("Вхід успішний.", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainMenu newForm = new MainMenu();
                newForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Логін чи пароль не вірний.", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            conn.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1.PerformClick();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
