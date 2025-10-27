using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp_NFE
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuOblikNefSystemy newForm = new MenuOblikNefSystemy();
            newForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuZapyty newForm = new MenuZapyty();
            newForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Info newForm = new Info();
            newForm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Dovidnyk_Main newForm = new Dovidnyk_Main();
            newForm.ShowDialog();
        }
    }
}
