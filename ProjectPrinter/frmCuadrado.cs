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
            objCuadrado.graficadora(picSquare);

        }
    }
}
