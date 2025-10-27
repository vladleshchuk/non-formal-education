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
    public partial class MenuZapyty : Form
    {
        public MenuZapyty()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnZagalnaInfo_Click(object sender, EventArgs e)
        {
            zapyt_Zagalna_info newForm = new zapyt_Zagalna_info();
            newForm.ShowDialog();
        }

        private void btnDyscypliny_Click(object sender, EventArgs e)
        {
            zapyt_Dyscypliny newForm = new zapyt_Dyscypliny();
            newForm.ShowDialog();
        }

        private void btnGrupy_Click(object sender, EventArgs e)
        {
            zapyt_Grupy newForm = new zapyt_Grupy();
            newForm.ShowDialog();
        }

        private void btnNNI_Click(object sender, EventArgs e)
        {
            zapyt_NNI newForm = new zapyt_NNI();
            newForm.ShowDialog();
        }

        private void btnOsv_Plat_Click(object sender, EventArgs e)
        {
            zapyt_Osv_platformy newForm = new zapyt_Osv_platformy();
            newForm.ShowDialog();
        }

        private void btn_Dysc_OsvPlat_Click(object sender, EventArgs e)
        {
            zapyt_Dysc_OsvRiven newForm = new zapyt_Dysc_OsvRiven();
            newForm.ShowDialog();
        }

        private void btnDyst_OsvRiven_Click(object sender, EventArgs e)
        {
            zapyt_Dysc_OsvPlatf newForm = new zapyt_Dysc_OsvPlatf();
            newForm.ShowDialog();
        }
    }
}
