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
            objCuadrado.InicializaDatos(txtLado, txtPerimetro, txtArea, picSquareZ);
            this.btnContorno.Enabled = !string.IsNullOrWhiteSpace(this.txtLado.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private  void  btnGraficar_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { picSquareZ, picSquareX, picSquareY };
            ListBox[] listaImpresion = {lstZx1, lstZy1, lstZx2, lstZy2,
                                        lstXx1, lstXy1, lstXx2, lstXy2,
                                        lstYx1, lstYy1, lstYx2, lstYy2,lstPunto};
            objCuadrado.LeerDatos(txtLado);
            objCuadrado.AreayPerimetro();
            objCuadrado.Imprimir(txtPerimetro, txtArea);
            objCuadrado.CreadoraContorno(pictureBoxes, comboColor);
            objCuadrado.CreadoraRelleno(pictureBoxes, comboColor, listaImpresion);
        }

        private void frmCuadrado_Load(object sender, EventArgs e)
        {

        }

        private void txtLado_TextChanged(object sender, EventArgs e)
        {
            this.btnContorno.Enabled = !string.IsNullOrWhiteSpace(this.txtLado.Text);
        }

        private void groupBox6_Enter_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { picSquareZ, picSquareX, picSquareY };
            ListBox[] listaImpresion = {lstZx1, lstZy1, lstZx2, lstZy2,
                                        lstXx1, lstXy1, lstXx2, lstXy2,
                                        lstYx1, lstYy1, lstYx2, lstYy2,lstPunto};
            this.txtLado.Clear();

            for(int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i].Refresh();
            }
            for (int j = 0; j < listaImpresion.Length; j++)
            {
                listaImpresion[j].Items.Clear();
            }
            this.txtArea.Clear();
            this.txtPerimetro.Clear();
        }
    }
}
