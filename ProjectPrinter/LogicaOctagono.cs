using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Utilidades;
using System.Threading;

namespace ProjectPrinter
{
    class LogicaOctagono
    {

        private float mLado;
        private float mPerimetro;
        private float mArea;
        private float mApothem, mSegmentB, mAngle1, mAngle2;


        //  Datos miembro que operan con el modo grafico
        private PointF mA, mB, mC, mD, mE, mF, mG, mH;
        //Objeto que activa el modo grafico de Windows.
        // SF -> Sacle Factor (Constante) para manejar
        // un Zoom In y un Zoom Out del dibujo.
        private const float SF = 10;
        //Objeto de tipo pluma (lápiz,esfero,maracador)
        private Pen mPen;

        private Graphics mGraficosX;
        private Graphics mGraficosY;
        private Graphics mGraficosZ;
        // Constructor de la clase.
        public LogicaOctagono()
        {
            mLado = 0.0f;
            mPerimetro = 0.0f;
            mArea = 0.0f;
        }
        public void LeerDatos(TextBox txtSide)
        {
            try
            {
                mLado = float.Parse(txtSide.Text);
            }
            catch
            {
                MessageBox.Show("Error en el ingreso de datos...", "Mensaje de error");
                //InitializeData();
            }
        }

        //Se imprime el perimetro y el area del Hexagono
        public void ImprimirDatos(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimetro.ToString();
            txtArea.Text = mArea.ToString();
        }
        //Funcion que permite calcular el perimetro del hexagono
        public void AreayPerimetro()
        {
            //Permite
            mPerimetro = 8 * mLado;
            //Area
            mAngle1 = 45.0f * (float)Math.PI / 180.0f;
            mAngle2 = 22.5f * (float)Math.PI / 180.0f;

            mApothem = mLado / 2 * (float)Math.Tan(mAngle2);
            mArea = mPerimetro * mApothem / 2.0f;
        }
        public void InicializarDatos(TextBox txtSide, TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            txtSide.Focus();
            mLado = 0.0f;
            mPerimetro = 0.0f;
            mArea = 0.0f;
            txtSide.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            picCanvas.Refresh();

        }
        private void DeterminarPuntos()
        {
            mSegmentB = mLado * (float)Math.Cos(mAngle1);

            mA.X = mSegmentB * SF;
            mA.Y = 0.0f * SF;

            mB.X = (mSegmentB + mLado) * SF;
            mB.Y = 0.0f * SF;

            mC.X = (2 * mSegmentB + mLado) * SF;
            mC.Y = mSegmentB * SF;

            mE.X = (mSegmentB + mLado) * SF;
            mE.Y = (2.0f * mSegmentB + mLado) * SF;

            mF.X = mSegmentB * SF;
            mF.Y = (2.0f * mSegmentB + mLado) * SF;

            mD.X = (2.0f * mSegmentB + mLado) * SF;
            mD.Y = (mLado + mSegmentB) * SF;

            mG.X = 0.0f * SF;
            mG.Y = (mSegmentB + mLado) * SF;

            mH.X = 0.0f * SF;
            mH.Y = mSegmentB * SF;
        }
        public void CreadoraRelleno(PictureBox[] pictureBoxes, ComboBox color, ListBox[] listas)
        {
            DeterminarPuntos();
            Thread.CurrentThread.IsBackground = true;
            Thread graficoZR = new Thread(new ThreadStart(() => GraficadoraRellenoZ(pictureBoxes, color, listas)));
            graficoZR.Start();
            graficoZR.Join();
        }
        public void GraficadoraRellenoZ(PictureBox[] pictureBoxes, ComboBox color, ListBox[] listas)
        {
            if (mLado >= 5)
                mLado = 4;
            int rango = ((int)mLado * (int)SF);
            int veri = 0;
            mGraficosZ = pictureBoxes[0].CreateGraphics();
            mGraficosX = pictureBoxes[1].CreateGraphics();
            mGraficosY = pictureBoxes[2].CreateGraphics();
            PointF[] puntosEntreLineas;
            DeterminarPuntos();
            //Perspectiva Z por la izquierda
            PointF[] puntosAH;
            PointF[] puntosHG;
            PointF[] puntosGF;
            PointF[] puntosIzquierda;
            puntosAH = Bresenham.ObtenerPuntos(mA, mH, rango);
            puntosHG = Bresenham.ObtenerPuntos(mH, mG, rango);
            Recorrer(puntosHG, (int)rango / 2);
            puntosGF = Bresenham.ObtenerPuntos(mG, mF, rango);
            puntosIzquierda = (puntosAH.Concat(puntosHG).ToArray()).Concat(puntosGF).ToArray();

            //Perspectiva Z por la derecha
            PointF[] puntosBC;
            PointF[] puntosCD;
            PointF[] puntosDE;
            PointF[] puntosDerecha;
            puntosBC = Bresenham.ObtenerPuntos(mB, mC, rango);
            puntosCD = Bresenham.ObtenerPuntos(mC, mD, rango);
            Recorrer(puntosCD, (int)rango / 2);
            puntosDE = Bresenham.ObtenerPuntos(mD, mE, rango);
            puntosDerecha = (puntosBC.Concat(puntosCD).ToArray()).Concat(puntosDE).ToArray();
            veri = puntosDerecha.Length - 1;

            do
            {
                mPen = SeleccionarColor(color);
                puntosEntreLineas = Bresenham.ObtenerPuntos(puntosIzquierda[veri], puntosDerecha[veri], puntosDerecha.Length);
                for (int k = puntosDerecha.Length - 1, j = 0; k > 0; k--, j++)
                {
                    Thread.Sleep(5);
                    //Z
                    mGraficosZ.DrawLine(mPen, puntosIzquierda[k], puntosDerecha[k]);
                    //Y
                    Point pixel = new Point();
                    pixel.X = (int)puntosEntreLineas[k].X;
                    pixel.Y = (int)puntosEntreLineas[k].Y;
                    Rectangle rect = new Rectangle(pixel, new Size(1, 1));
                    mGraficosY.DrawRectangle(mPen, rect);
                }
                mGraficosX.DrawLine(mPen, puntosIzquierda[veri], puntosDerecha[veri]);
                veri--;
            } while (veri != 0);
        }
        public Pen SeleccionarColor(ComboBox color)
        {
            var random = new Random();
            int aleatorio = random.Next(1, 5);

            if (aleatorio == 1)
                return new Pen(Color.Blue, 3);
            if (aleatorio == 2)
                return new Pen(Color.Red, 3);
            if (aleatorio == 3)
                return new Pen(Color.FromArgb(66, 230, 245), 3);
            if (aleatorio == 4)
                return new Pen(Color.Green, 3);
            if (aleatorio == 5)
                return new Pen(Color.Brown, 3);
            return new Pen(Color.Black, 3);
            /*
            if (color.SelectedItem == "Azul")
                return new Pen(Color.Blue, 3);
            if (color.SelectedItem == "Rojo")
                return new Pen(Color.Red, 3);
            if (color.SelectedItem == "Amarillo")
                return new Pen(Color.FromArgb(66, 230, 245), 3);
            if (color.SelectedItem == "Verde")
                return new Pen(Color.Green, 3);
            if (color.SelectedItem == "Café")
                return new Pen(Color.Brown, 3);
            return new Pen(Color.Black, 3);*/
        }
        public void Recorrer(PointF[] Puntos, int rango)
        {
            rango = rango - (int)mLado-4;
            for (int i = 0; i < Puntos.Length; i++)
            {
                Puntos[i].Y = Puntos[i].Y - rango;
            }
        }
    }
}
