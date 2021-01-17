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
    public partial class frmTriangulo : Form
    {
        LogicaTriangulo objTriangulo = new LogicaTriangulo();
        public frmTriangulo()
        {
            InitializeComponent();
            objTriangulo.InicializaDatos(txtLado, txtPerimetro, txtAltura, txtAltura, picSquareZ);
            this.btnContorno.Enabled = !string.IsNullOrWhiteSpace(this.txtLado.Text);
        }

        private void btnContorno_Click(object sender, EventArgs e)
        {

        }

        private void frmTriangulo_Load(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { picSquareZ, picSquareX, picSquareY };
            ListBox[] listaImpresion = {lstZx1, lstZy1, lstZx2, lstZy2,
                                        lstXx1, lstXy1, lstXx2, lstXy2,
                                        lstYx1, lstYy1, lstYx2, lstYy2,lstPunto};
            objTriangulo.LeerDatos(txtLado);
            objTriangulo.AreayPerimetro();
            objTriangulo.Imprimir(txtPerimetro, txtArea, txtAltura);
            objTriangulo.CreadoraContorno(pictureBoxes, comboColor);
            objTriangulo.GraficadoraRellenoZ(pictureBoxes, comboColor, listaImpresion);
            //objTriangulo.CreadoraRelleno(pictureBoxes, comboColor, listaImpresion);
        }
    }
}
