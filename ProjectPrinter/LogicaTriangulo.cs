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
        const int CENTRADOY = 10;
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
                    Thread.Sleep(10);
                    //Z
                    mGraficosZ.DrawLine(mPen, puntosIzquierda[k], puntosDerecha[k]);
                    //Y
                    
                    Point pixel = new Point();
                    pixel.X = (int)puntosEntreLineas[k].X;
                    pixel.Y = (int)puntosEntreLineas[k].Y;
                    Rectangle rect = new Rectangle(pixel, new Size(1, 1));
                    mGraficosY.DrawRectangle(mPen, rect);
                }
                mGraficosX.DrawLine(mPen, puntosIzquierda[verificador], puntosDerecha[verificador]);
                verificador--;
            } while (verificador != 0);
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
