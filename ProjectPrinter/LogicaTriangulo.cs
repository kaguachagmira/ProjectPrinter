using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;

namespace ProjectPrinter
{
    class LogicaTriangulo
    {
        const int CENTRADOX = 105;
        const int CENTRADOY = 50;
        private float mLado;
        private float mPerimetro;
        private float mArea;
        private float mAltura;
        //Variables para el modo grafico
        private Graphics mGraficosX;
        private Graphics mGraficosY;
        private Graphics mGraficosZ;
        //Factor de escalamiento
        private const float SF = 10;
        //Variables para dibujar
        private Pen mPen;
        private int posicion = 0;
        private PointF mA;
        private PointF mB;
        private PointF mC;
        private int velocidad;

        public void InicializaDatos(TextBox lado, TextBox perimetro, TextBox area, TextBox altura, PictureBox cuadrado)
        {
            lado.Text = "";
            perimetro.Text = "";
            area.Text = "";
            altura.Text = "";
            cuadrado.Refresh();
            mLado = 0.0f;
            mPerimetro = 0.0f;
            mArea = 0.0f;
            mAltura = 0.0f;
        }
        public void LeerDatos(TextBox lado, PictureBox picInfo)
        {
            try
            {
                mLado = float.Parse(lado.Text);
                if (mLado >= 8)
                {
                    mLado = 7;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el Ingreso de Datos" + ex);
            }
        }
        public void AreayPerimetro()
        {
            var radians = Math.PI * 60 / 180;
            mAltura = (float)Math.Sin(radians)*mLado;
            mArea = (mLado * mAltura) / 2;
            mPerimetro = mLado + mLado + mLado;
        }
        public void ImprimirDatos(TextBox perimetro, TextBox Area, TextBox altura)
        {
            perimetro.Text = mPerimetro.ToString();
            Area.Text = mArea.ToString();
            altura.Text = mAltura.ToString();
        }

        public void DeterminarPuntos()
        {
            mA.X = (mLado/2) * SF + CENTRADOX;
            mA.Y = (0.0f * SF) + CENTRADOY;

            mB.X = (0.0f * SF) + CENTRADOX;
            mB.Y = mAltura *SF + CENTRADOY;

            mC.X = mLado *SF + CENTRADOX;
            mC.Y = mAltura * SF + CENTRADOY;
        }
        public void CreadoraRelleno(PictureBox[] pictureBoxes, ComboBox color, ListBox[] listas, ComboBox velocidad)
        {
            DeterminarPuntos();
            Thread.CurrentThread.IsBackground = true;
            this.velocidad = DeterminarVelocidad(velocidad);
            Thread graficoZR = new Thread(new ThreadStart(() => GraficadoraRellenoZ(pictureBoxes, color, listas)));
            graficoZR.Start();
            graficoZR.Join();
        }
        public int DeterminarVelocidad(ComboBox velocidad)
        {
            if (velocidad.SelectedItem == "Lento")
            {
                return 30;
            }
            if (velocidad.SelectedItem == "Normal")
            {
                return 20;
            }
            if (velocidad.SelectedItem == "Rápido")
            {
                return 10;
            }
            if (velocidad.SelectedItem == "Muy Rápido")
            {
                return 1;
            }
            return 0;
        }
        public void GraficadoraRellenoZ(PictureBox[] pictureBoxes, ComboBox color, ListBox[] listas)
        {
            int verificador = ((int)mLado * 10)-2;
            int rango = (int)mLado * 10;

            mGraficosZ = pictureBoxes[0].CreateGraphics();
            mGraficosX = pictureBoxes[1].CreateGraphics();
            mGraficosY = pictureBoxes[2].CreateGraphics();
            PointF[] puntosEntreLineas;

            //Z
            PointF[] puntosIzquierda;
            PointF[] puntosDerecha;
            PointF[] puntosBase;

            puntosIzquierda = LinePoints.ObtenerPuntos(mA, mC, rango);
            puntosDerecha = LinePoints.ObtenerPuntos(mA, mB, rango);
            puntosBase = LinePoints.ObtenerPuntos(mB, mC, rango);

            do
            {
                mPen = SeleccionarColor(color);
                puntosEntreLineas = LinePoints.ObtenerPuntos(puntosIzquierda[verificador], puntosDerecha[verificador], rango);
                for (int k = puntosBase.Length-2, j = 0; k > 0; k--, j++)
                {
                    Thread.Sleep(this.velocidad);
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
                mGraficosX.DrawLine(mPen, puntosIzquierda[verificador], puntosDerecha[verificador]);
                listas[8].Items.Add(puntosIzquierda[verificador].X.ToString()); listas[9].Items.Add(puntosIzquierda[verificador].Y.ToString());
                listas[10].Items.Add(puntosDerecha[verificador].X.ToString()); listas[11].Items.Add(puntosDerecha[verificador].Y.ToString());
                verificador--;
            } while (verificador != 0);
        }
        public Pen SeleccionarColor(ComboBox color)
        {
            if (color.SelectedItem == "Random")
            {
                var random = new Random();
                int aleatorio = random.Next(1, 5);

                if (aleatorio == 1)
                    return new Pen(Color.Blue, 3);
                if (aleatorio == 2)
                    return new Pen(Color.Red, 3);
                if (aleatorio == 3)
                    return new Pen(Color.Yellow, 3);
                if (aleatorio == 4)
                    return new Pen(Color.Green, 3);
                if (aleatorio == 5)
                    return new Pen(Color.Brown, 3);
                return new Pen(Color.Black, 3);
            }

            else
            {
                if (color.SelectedItem == "Azul")
                    return new Pen(Color.Blue, 3);
                if (color.SelectedItem == "Rojo")
                    return new Pen(Color.Red, 3);
                if (color.SelectedItem == "Amarillo")
                    return new Pen(Color.Yellow, 3);
                if (color.SelectedItem == "Verde")
                    return new Pen(Color.Green, 3);
                if (color.SelectedItem == "Café")
                    return new Pen(Color.Brown, 3);
                return new Pen(Color.Black, 3);
            }
        }
    }
}
