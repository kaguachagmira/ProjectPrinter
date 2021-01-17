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
        //Variables para el cuadrado
        const int CENTRADOX = 30;
        const int CENTRADOY = 20;
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
        public void LeerDatos(TextBox lado)
        {
            try
            {
                mLado = float.Parse(lado.Text);
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
        public void Imprimir(TextBox perimetro, TextBox Area, TextBox altura)
        {
            perimetro.Text = mPerimetro.ToString();
            Area.Text = mArea.ToString();
            altura.Text = mAltura.ToString();
        }

        public void PuntosPerfil()
        {
            mA.X = (mLado/2) * SF + CENTRADOX;
            mA.Y = (0.0f * SF) + CENTRADOY;

            mB.X = (0.0f * SF) + CENTRADOX;
            mB.Y = mAltura *SF + CENTRADOY;

            mC.X = mLado *SF + CENTRADOX;
            mC.Y = mAltura * SF + CENTRADOY;
        }
        public void CreadoraContorno(PictureBox[] pictureBoxes, ComboBox color)
        {
            PuntosPerfil();
            Thread graficoZC = new Thread(new ThreadStart(() => GraficadoraContorno(pictureBoxes, color)));
            graficoZC.Start();
            graficoZC.Join();
        }
        public void GraficadoraContorno(PictureBox[] pictureBoxes, ComboBox color)
        {
            mGraficosZ = pictureBoxes[0].CreateGraphics();
            mPen = SeleccionarColor(color);

            mGraficosZ.DrawLine(mPen,mA,mB);
            mGraficosZ.DrawLine(mPen,mA,mC);
            mGraficosZ.DrawLine(mPen,mB,mC);

        }
        public void GraficadoraRellenoZ(PictureBox[] pictureBoxes, ComboBox color, ListBox[] listas)
        {
            int verificador = 0;
            mGraficosZ = pictureBoxes[0].CreateGraphics();
            mGraficosX = pictureBoxes[1].CreateGraphics();
            mGraficosY = pictureBoxes[2].CreateGraphics();
            PointF[] PuntosEntreLineas;

            int rango = (int)mLado * 10;
            //Z
            PointF[] PuntosIzquierda;
            PointF[] PuntosDerecha;

            PuntosIzquierda = LinePoints.ObtenerPuntos(mA, mC, rango);
            PuntosDerecha = LinePoints.ObtenerPuntos(mA, mB, rango);

            do
            {
                mPen = SeleccionarColor(color);
                PuntosEntreLineas = LinePoints.ObtenerPuntos(PuntosIzquierda[verificador], PuntosDerecha[verificador], rango);
                for (int k = 0; k < rango; k++)
                {
                    Thread.Sleep(20);
                    //Z
                    mGraficosZ.DrawLine(mPen, PuntosIzquierda[k], PuntosDerecha[k]);
                    //X
                    Thread.Sleep(50);
                    mGraficosX.DrawLine(mPen, PuntosIzquierda[k], PuntosDerecha[k]);
                    /*
                    Point pixel = new Point();
                    pixel.X = (int)PuntosEntreLineas[k].X;
                    pixel.Y = (int)PuntosEntreLineas[k].Y;
                    Rectangle rect = new Rectangle(pixel, new Size(1, 1));
                    mGraficosY.DrawRectangle(mPen, rect);*/
                }
                verificador++;
            } while (verificador != rango);

            /*
            //Y
            PointF[] PuntosL;
            PointF[] PuntosR;
            PuntosL = LinePoints.ObtenerPuntos(mA, mC, rango);
            PuntosR = LinePoints.ObtenerPuntos(mB, mD, rango);
            PointF[] PuntosEntreLineas;


            do
            {
                mPen = SeleccionarColor(color);
                PuntosEntreLineas = LinePoints.ObtenerPuntos(PuntosL[verificador], PuntosR[verificador], rango);
                for (int i = 0; i < rango; i++)
                {
                    //Z
                    Thread.Sleep(20);
                    mGraficosZ.DrawLine(mPen, PuntosT1[i], PuntosB1[i]);
                    listas[0].Items.Add("X:  " + PuntosT1[i].X.ToString()); listas[1].Items.Add("Y:  " + PuntosT1[i].Y.ToString());
                    listas[2].Items.Add("X:  " + PuntosB1[i].X.ToString()); listas[3].Items.Add("Y:  " + PuntosB1[i].Y.ToString());
                    //Y
                    Point pixel = new Point();
                    pixel.X = (int)PuntosEntreLineas[i].X;
                    pixel.Y = (int)PuntosEntreLineas[i].Y;
                    listas[4].Items.Add("X:  " + PuntosL[i].X.ToString()); listas[5].Items.Add("Y:  " + PuntosL[i].Y.ToString());
                    listas[6].Items.Add("X:  " + PuntosR[i].X.ToString()); listas[7].Items.Add("Y:  " + PuntosR[i].Y.ToString());
                    listas[12].Items.Add(pixel.X + "," + pixel.Y);
                    Rectangle rect = new Rectangle(pixel, new Size(1, 1));
                    mGraficosY.DrawRectangle(mPen, rect);
                }
                //X
                mGraficosX.DrawLine(mPen, PuntosL[verificador], PuntosR[verificador]);
                listas[8].Items.Add("X:  " + PuntosL[verificador].X.ToString()); listas[9].Items.Add("Y:  " + PuntosL[verificador].Y.ToString());
                listas[10].Items.Add("X:  " + PuntosR[verificador].X.ToString()); listas[11].Items.Add("Y:  " + PuntosR[verificador].Y.ToString());
                verificador++;
            } while (verificador != rango);*/

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
    }
}
