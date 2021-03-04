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
    public partial class frmImpresion : Form
    {
        LogicaCuadrado  objCuadrado  = new LogicaCuadrado();
        LogicaTriangulo objTriangulo = new LogicaTriangulo();
        LogicaPentagono objPentagono = new LogicaPentagono();
        LogicaHexagono  objHexagono  = new LogicaHexagono();
        LogicaHeptagono objHeptagono = new LogicaHeptagono();
        LogicaOctagono  objOctagono  = new LogicaOctagono();
        LogicaDecagono  objDecagono  = new LogicaDecagono();

        private int opcionFigura{ get ; set ;}
        public frmImpresion(int opcion)
        {
            InitializeComponent();
            objCuadrado.InicializaDatos(txtLado, txtPerimetro, txtArea, picZ, picY, picX);
            this.btnContorno.Enabled = !string.IsNullOrWhiteSpace(this.txtLado.Text);
            this.opcionFigura = opcion;
            switch (opcionFigura)
            {
                case 3:
                    picInfo.Image = new Bitmap(Application.StartupPath + @"/math/triangulo.png");
                    break;
                case 4:
                    picInfo.Image = new Bitmap(Application.StartupPath + @"/math/cuadrado.png");
                    break;
                case 5:
                    picInfo.Image = new Bitmap(Application.StartupPath + @"/math/pentagono.png");
                    break;
                case 6:
                    picInfo.Image = new Bitmap(Application.StartupPath + @"/math/hexagono.png");
                    break;
                case 7:
                    picInfo.Image = new Bitmap(Application.StartupPath + @"/math/heptagono.png");
                    break;
                case 8:
                    picInfo.Image = new Bitmap(Application.StartupPath + @"/math/octagono.png");
                    break;
                case 10:
                    picInfo.Image = new Bitmap(Application.StartupPath + @"/math/decagono.png");
                    break;

            }
        }

         private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGraficar_Click(object sender, EventArgs e)
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
            ListBox[] listaImpresion = {lstZx1, lstZy1, lstZx2, lstZy2,
                                        lstXx1, lstXy1, lstXx2, lstXy2,
                                        lstYx1, lstYy1, lstYx2, lstYy2,lstPunto};
            PictureBox[] pictureBoxes = { picZ, picX, picY };
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i].Refresh();
            }
            switch (opcionFigura)
            {
                case 3:
                    objTriangulo.LeerDatos(txtLado, picInfo);
                    objTriangulo.AreayPerimetro();
                    objTriangulo.ImprimirDatos(txtPerimetro, txtArea, txtAltura, txtVolumen);
                    objTriangulo.CreadoraRelleno(pictureBoxes, comboColor, listaImpresion, comboVelocidad);
                    break;
                case 4:
                    objCuadrado.LeerDatos(txtLado);
                    objCuadrado.AreayPerimetro();
                    objCuadrado.ImprimirDatos(txtPerimetro, txtArea);
                    objCuadrado.CreadoraRelleno(pictureBoxes, comboColor, listaImpresion, comboVelocidad);
                    break;
                case 5:
                    objPentagono.LeerDatos(txtLado);
                    objPentagono.LadoyAngulos();
                    objPentagono.AreayPerimetro();
                    objPentagono.ImprimirDatos(txtArea, txtPerimetro);
                    objPentagono.CreadoraRelleno(pictureBoxes, comboColor, listaImpresion, comboVelocidad);
                    break;
                case 6:
                    objHexagono.LeerDatos(txtLado);
                    objHexagono.PerimetroyArea();
                    objHexagono.ImprimirDatos(txtArea, txtPerimetro);
                    objHexagono.CreadoraRelleno(pictureBoxes, comboColor, listaImpresion, comboVelocidad);
                    break;
                case 7:
                    objHeptagono.Leerdatos(txtLado);
                    objHeptagono.AreayPerimetro();
                    objHeptagono.LadoyAngulos();
                    objHeptagono.CreadoraRelleno(pictureBoxes, comboColor, listaImpresion, comboVelocidad);
                    break;
                case 8:
                    objOctagono.LeerDatos(txtLado);
                    objOctagono.AreayPerimetro();
                    objOctagono.ImprimirDatos(txtPerimetro, txtArea);
                    objOctagono.CreadoraRelleno(pictureBoxes, comboColor, listaImpresion, comboVelocidad);
                    break;
                case 10:
                    objDecagono.limpiar(picZ);
                    objDecagono.LeerDatos(txtLado);
                    objDecagono.AreaYPerimetro();
                    objDecagono.ImprimirDatos(txtPerimetro, txtArea, picZ);
                    break;
            }


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
            PictureBox[] pictureBoxes = { picZ, picX, picY };
            ListBox[] listaImpresion = {lstZx1, lstZy1, lstZx2, lstZy2,
                                        lstXx1, lstXy1, lstXx2, lstXy2,
                                        lstYx1, lstYy1, lstYx2, lstYy2,lstPunto};
            this.txtLado.Clear();
            

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i].Refresh();
            }
            for (int j = 0; j < listaImpresion.Length; j++)
            {
                listaImpresion[j].Items.Clear();
            }
            this.txtArea.Clear();
            this.txtPerimetro.Clear();
            this.txtAltura.Clear();
            this.txtVolumen.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lstYy1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lstYx2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
