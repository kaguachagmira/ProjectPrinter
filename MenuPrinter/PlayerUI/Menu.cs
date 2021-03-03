using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPrinter;
namespace PlayerUI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            openChildForm(new frmImpresion(3));
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {

            openChildForm(new frmImpresion(4));
        }

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            openChildForm(new frmImpresion(5));

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            openChildForm(new frmImpresion(7));
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {

            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmImpresion(8));
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmImpresion(10));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmImpresion(9));
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            openChildForm(new frmImpresion(6));

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
