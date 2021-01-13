using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using Utilidades;

namespace ProjectPrinter
{
    class LogicaCuadrado
    {
        //Variables para el cuadrado
        const int CENTRADOX = 30;
        const int CENTRADOY = 20;
        private float mLado;
        private float mPerimetro;
        private float mArea;
        //Variables para el modo grafico
        private Graphics mGraficosX;
        private Graphics mGraficosY;
        private Graphics mGraficosZ;
        //Factor de escalamiento
        private const float SF = 10;
        //Variables para dibujar
        private Pen mPen;
        private int posicion = 0;

        private List<PointF> PuntosT = new List<PointF>();
        private List<PointF> PuntosB = new List<PointF>();


        private PointF mA;
        private PointF mB;
        private PointF mC;
        private PointF mD;

        private PictureBox myPic;
        public LogicaCuadrado()
        {
            mLado = 0.0f;
            mPerimetro = 0.0f;
            mArea = 0.0f;
        }
        public void InicializaDatos(TextBox lado, TextBox perimetro, TextBox area, PictureBox cuadrado)
        {
            lado.Text = "";
            perimetro.Text = "";
            area.Text = "";
            cuadrado.Refresh();
            mLado = 0.0f;
            mPerimetro = 0.0f;
            mArea = 0.0f;
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
            mArea = (float)Math.Pow(mLado, 2);
            mPerimetro = mLado * 4;
        }
        public void Imprimir(TextBox perimetro, TextBox Area)
        {
            perimetro.Text = mArea.ToString();
            Area.Text = mPerimetro.ToString();
        }
        public void PuntosPerfil()
        {
            mA.X = (0.0f * SF) + CENTRADOX;
            mA.Y = (0.0f * SF) + CENTRADOY;

            mB.X = (mLado * SF) + CENTRADOX;
            mB.Y = 0.0f + CENTRADOY;

            mD.X = (mLado * SF) + CENTRADOX;
            mD.Y = (mLado * SF) + CENTRADOY;

            mC.X = (0.0f * SF) + CENTRADOX;
            mC.Y = (mLado * SF) + CENTRADOY;
        }
        public void CreadoraRelleno(PictureBox cuadradoZ, PictureBox cuadradoX, PictureBox cuadradoY, ComboBox color)
        {
            Thread.CurrentThread.IsBackground = true;
            Thread graficoZR = new Thread(new ThreadStart(() => GraficadoraRellenoZ(cuadradoZ,cuadradoX,cuadradoY, color)));
            //Thread graficoYR = new Thread(new ThreadStart(() => GraficadoraRellenoY(cuadradoY,color)));
            graficoZR.Start();

        }
        public void CreadoraContorno(PictureBox cuadradoZ, PictureBox cuadradoX, PictureBox cuadradoY, ComboBox color)
        {
            myPic = cuadradoZ;
            PuntosPerfil();
            Thread graficoZC = new Thread(new ThreadStart(() => GraficadoraContorno(cuadradoZ, cuadradoX, cuadradoY, color)));
            graficoZC.Start();
            graficoZC.Join();
        }
        public void GraficadoraContorno(PictureBox cuadradoZ, PictureBox cuadradoX, PictureBox cuadradoY, ComboBox color)
        {
            //CONTORNO PERSPECTIVA Z
            mGraficosZ = cuadradoZ.CreateGraphics();
            mGraficosX = cuadradoX.CreateGraphics();
            mGraficosY = cuadradoY.CreateGraphics();

            mPen = SeleccionarColor(color);
            mGraficosZ.DrawLine(mPen, mA, mB);
            mGraficosZ.DrawLine(mPen, mA, mC);
            mGraficosZ.DrawLine(mPen, mB, mD);
            mGraficosZ.DrawLine(mPen, mD, mC);
            //CONTORNO PERSPECTIVA X
            mGraficosX.DrawLine(mPen, mA, mB);
            //CONTORNO PERSPECTIVA Y
            mGraficosY.DrawLine(mPen, mC, mD);

        }
        public void GraficadoraRellenoZ(PictureBox cuadradoZ, PictureBox cuadradoX, PictureBox cuadradoY, ComboBox color)
        {
            int verificador = 0;
            mGraficosZ = cuadradoZ.CreateGraphics();
            mGraficosY = cuadradoY.CreateGraphics();
            mGraficosX = cuadradoX.CreateGraphics();
            int rango = (int)mLado * 10;
            //Z
            PointF[] PuntosT1;
            PointF[] PuntosB1;

            PuntosT1 = LinePoints.ObtenerPuntos(mA, mB, rango);
            PuntosB1 = LinePoints.ObtenerPuntos(mC, mD, rango);


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
                    //Y
                    Point pixel = new Point();
                    pixel.X = (int)PuntosEntreLineas[i].X;
                    pixel.Y = (int)PuntosEntreLineas[i].Y;
                    Rectangle rect = new Rectangle(pixel, new Size(2, 2));
                    mGraficosY.DrawRectangle(mPen, rect);
                }
                //X
                mGraficosX.DrawLine(mPen, PuntosL[verificador], PuntosR[verificador]);
                //GraficadoraRellenoX(cuadradoX, cuadradoY, color, verificador);
                verificador++;
            } while (verificador != rango);

        }
        public void GraficadoraRellenoX(PictureBox cuadradoX, PictureBox cuadradoY, ComboBox color, int capas)
        {
            mGraficosX = cuadradoX.CreateGraphics();
            int rango = (int)mLado * 10;
            PointF[] PuntosL;
            PointF[] PuntosR;
            PointF Puntos;

            PuntosL = LinePoints.ObtenerPuntos(mA,mC,rango);
            PuntosR = LinePoints.ObtenerPuntos(mB,mD,rango);

            for (int i = 0; i <=capas; i++)
            {
                mGraficosX.DrawLine(mPen, PuntosR[i], PuntosL[i]);
            }

        }
        public void GraficadoraRellenoY(PictureBox cuadradoY, ComboBox color)
        {
            mGraficosY = cuadradoY.CreateGraphics();
            int rango = (int)mLado * 10;
            PointF[] PuntosL;
            PointF[] PuntosR;
            PuntosL = LinePoints.ObtenerPuntos(mA, mC, rango);
            PuntosR = LinePoints.ObtenerPuntos(mB, mD, rango);

            PointF[] PuntosEntreLineas;

            for (int i = 0; i < rango; i++)
            {
                PuntosEntreLineas = LinePoints.ObtenerPuntos(PuntosL[i], PuntosR[i], rango);
                for (int j = 0; j < rango; j++)
                {
                    Point pixel = new Point();
                    pixel.X = (int)PuntosEntreLineas[j].X;
                    pixel.Y = (int)PuntosEntreLineas[j].Y;
                    Rectangle rect = new Rectangle(pixel, new Size(2, 2));
                    Thread.Sleep(20);
                    mGraficosY.DrawRectangle(mPen, rect);
                }
            }
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
