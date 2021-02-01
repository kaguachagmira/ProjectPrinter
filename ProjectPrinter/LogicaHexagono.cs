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
    class LogicaHexagono
    {

        private float mLado;
        private float mPerimetro;
        private float mArea;
        private float mApothem, mSegmentB, mAngle1;
        const int CENTRADOX = 105;
        const int CENTRADOY = -5;

        //  Datos miembro que operan con el modo grafico
        private PointF mA, mB, mC, mD, mE, mF;
        //Objeto que activa el modo grafico de Windows.
        //Atributo que me permite usar el modo grafico
        private Graphics mGraficosX;
        private Graphics mGraficosY;
        private Graphics mGraficosZ;
        // SF -> Sacle Factor (Constante) para manejar
        // un Zoom In y un Zoom Out del dibujo.
        private const float SF = 10;
        //Objeto de tipo pluma (lápiz,esfero,maracador)
        private Pen mPen;


        // Constructor de la clase.
        public LogicaHexagono()
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
                if (mLado >= 8)
                {
                    mLado = 7;
                }
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

        //Funcion que permite calcular el perimetro
        public void AreaHexagon()
        {
            mAngle1 = 60.0f * (float)Math.PI / 180.0f;
            mApothem = mLado * (float)Math.Sin(mAngle1);
            mArea = mPerimetro * mApothem / 2.0f;
        }

        //Funcion que permite calcular el perimetro del hexagono
        public void PerimetroyArea()
        {
            //Perimetro
            mPerimetro = 6 * mLado;
            //Area
            mAngle1 = 60.0f * (float)Math.PI / 180.0f;
            mApothem = mLado * (float)Math.Sin(mAngle1);
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

            mA.X = (mSegmentB * SF) + CENTRADOX;
            mA.Y = (0.0f * SF)+ CENTRADOY;

            mB.X = ((mSegmentB + mLado) * SF)+ CENTRADOX;
            mB.Y = (0.0f * SF)+ CENTRADOY;

            mC.X = (0.0f * SF)+ CENTRADOX;
            mC.Y = (mApothem * SF)+ CENTRADOY;

            mE.X = (mSegmentB * SF)+ CENTRADOX;
            mE.Y = ((2.0f * mApothem) * SF)+ CENTRADOY;

            mF.X = ((mSegmentB + mLado) * SF)+ CENTRADOX;
            mF.Y = ((2.0f * mApothem) * SF)+ CENTRADOY;

            mD.X = ((2.0f * mSegmentB + mLado) * SF)+ CENTRADOX;
            mD.Y = (mApothem * SF)+ CENTRADOY;
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
            int rango = ((int)mLado * (int)SF);
            int veri = 0;
            mGraficosZ = pictureBoxes[0].CreateGraphics();
            mGraficosX = pictureBoxes[1].CreateGraphics();
            mGraficosY = pictureBoxes[2].CreateGraphics();
            PointF[] puntosEntreLineas;
            DeterminarPuntos();
            //Perpspectiva Z Lado Izquierdo
            PointF[] puntosAC;
            PointF[] puntosCE;
            PointF[] puntosIzquierda;
            puntosAC = Bresenham.ObtenerPuntos(mA, mC, rango);
            puntosCE = Bresenham.ObtenerPuntos(mC, mE, rango);
            puntosIzquierda = puntosAC.Concat(puntosCE).ToArray();
            //Perpspectiva Z Lado Derecho
            PointF[] puntosBD;
            PointF[] puntosDF;
            PointF[] puntosDerecha;
            puntosBD = Bresenham.ObtenerPuntos(mB, mD, rango);
            puntosDF = Bresenham.ObtenerPuntos(mD, mF, rango);
            puntosDerecha = puntosBD.Concat(puntosDF).ToArray();

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
                    listas[0].Items.Add(puntosIzquierda[k].X.ToString()); listas[1].Items.Add(puntosIzquierda[k].Y.ToString());
                    listas[2].Items.Add(puntosDerecha[k].X.ToString()); listas[3].Items.Add(puntosDerecha[k].Y.ToString());
                    //Y
                    Point pixel = new Point();
                    pixel.X = (int)puntosEntreLineas[k].X;
                    pixel.Y = (int)puntosEntreLineas[k].Y;
                    listas[4].Items.Add(puntosIzquierda[k].X.ToString()); listas[5].Items.Add(puntosIzquierda[k].Y.ToString());
                    listas[6].Items.Add(puntosDerecha[k].X.ToString()); listas[7].Items.Add(puntosDerecha[k].Y.ToString());
                    listas[12].Items.Add(pixel.X + "," + pixel.Y);
                    Rectangle rect = new Rectangle(pixel, new Size(1, 1));
                    mGraficosY.DrawRectangle(mPen, rect);
                }
                mGraficosX.DrawLine(mPen, puntosIzquierda[veri], puntosDerecha[veri]);
                listas[8].Items.Add(puntosIzquierda[veri].X.ToString()); listas[9].Items.Add(puntosDerecha[veri].Y.ToString());
                listas[10].Items.Add(puntosDerecha[veri].X.ToString()); listas[11].Items.Add(puntosDerecha[veri].Y.ToString());
                veri--;
            } while (veri != 0);


            /*mGraficosZ.DrawLine(mPen, mA, mB);
            mGraficosZ.DrawLine(mPen, mA, mC);
            mGraficosZ.DrawLine(mPen, mB, mD);
            mGraficosZ.DrawLine(mPen, mC, mE);
            mGraficosZ.DrawLine(mPen, mD, mF);
            mGraficosZ.DrawLine(mPen, mE, mF);*/
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
            rango = rango - (int)mLado - 1;
            for (int i = 0; i < Puntos.Length; i++)
            {
                Puntos[i].Y = Puntos[i].Y - rango;
            }
        }
    }
}
