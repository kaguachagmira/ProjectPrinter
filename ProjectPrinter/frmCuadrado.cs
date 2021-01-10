using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPrinter
{
    public partial class frmCuadrado : Form
    {
        LogicaCuadrado objCuadrado = new LogicaCuadrado();
        public frmCuadrado()
        {
            InitializeComponent();
            objCuadrado.InicializaDatos(txtLado, txtPerimetro, txtArea, picSquare);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            objCuadrado.LeerDatos(txtLado);
            objCuadrado.AreayPerimetro();
            objCuadrado.Imprimir(txtPerimetro, txtArea);
            objCuadrado.Creadora(picSquare,comboBox1);
        }

        private void picSquare_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
