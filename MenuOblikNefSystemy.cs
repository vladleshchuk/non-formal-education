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
    public partial class MenuOblikNefSystemy : Form
    {
        public MenuOblikNefSystemy()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_NNI_Click(object sender, EventArgs e)
        {
            NNI newForm = new NNI();
            newForm.ShowDialog();
        }

        private void btn_OsvGrupy_Click(object sender, EventArgs e)
        {
            Osvitni_programy newForm = new Osvitni_programy();
            newForm.ShowDialog();
        }

        private void btn_Dyscypliny_Click(object sender, EventArgs e)
        {
            Dyscypliny newForm = new Dyscypliny();
            newForm.ShowDialog();
        }

        private void btn_Grupy_Click(object sender, EventArgs e)
        {
            Grupy newForm = new Grupy();
            newForm.ShowDialog();
        }

        private void btnZdobuvOsv_Click(object sender, EventArgs e)
        {
            Zdobuvachi_osvity newForm = new Zdobuvachi_osvity();
            newForm.ShowDialog();
        }

        private void btn_Sertyfikaty_Click(object sender, EventArgs e)
        {
            Sertyficaty newForm = new Sertyficaty();
            newForm.ShowDialog();
        }

        private void btn_ZarahNefOsv_Click(object sender, EventArgs e)
        {
            Zarahuvannia_neform_osvity newForm = new Zarahuvannia_neform_osvity();
            newForm.ShowDialog();
        }
    }
}
