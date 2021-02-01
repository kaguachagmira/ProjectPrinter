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
    public class LogicaCuadrado
    {
        //Variables para el cuadrado
        const int CENTRADOX = 105;
        const int CENTRADOY = 10;
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
        public void InicializaDatos(TextBox lado, TextBox perimetro, TextBox area, PictureBox picX, PictureBox picY, PictureBox picZ )
        {
            lado.Text = "";
            perimetro.Text = "";
            area.Text = "";
            picX.Refresh();
            picY.Refresh();
            picZ.Refresh();
            mLado = 0.0f;
            mPerimetro = 0.0f;
            mArea = 0.0f;
        }
        public void LeerDatos(TextBox lado)
        {
            try
            {
                mLado = float.Parse(lado.Text);
                if(mLado >= 8)
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
            mArea = (float)Math.Pow(mLado, 2);
            mPerimetro = mLado * 4;
        }
        public void ImprimirDatos(TextBox perimetro, TextBox Area)
        {
            perimetro.Text = mArea.ToString();
            Area.Text = mPerimetro.ToString();
        }
        public void DeterminarPuntos()
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
        public void CreadoraRelleno(PictureBox[] pictureBoxes, ComboBox color, ListBox[] listas)
        {
            DeterminarPuntos();
            Thread.CurrentThread.IsBackground = true;
            Thread graficoZR = new Thread(new ThreadStart(() => GraficadoraRellenoZ(pictureBoxes, color, listas)));
            graficoZR.Start();
            graficoZR.Join();
        }
        public void GraficadoraContorno(PictureBox[] pictureBoxes, ComboBox color)
        {
            //CONTORNO PERSPECTIVA Z
            mGraficosZ = pictureBoxes[0].CreateGraphics();
            mGraficosX = pictureBoxes[1].CreateGraphics();
            mGraficosY = pictureBoxes[2].CreateGraphics();

            mPen = SeleccionarColor(color);
            mGraficosZ.DrawLine(mPen, mA, mB);
            mGraficosZ.DrawLine(mPen, mA, mC);
            mGraficosZ.DrawLine(mPen, mB, mD);
            mGraficosZ.DrawLine(mPen, mD, mC);

        }
        public void GraficadoraRellenoZ(PictureBox[] pictureBoxes, ComboBox color, ListBox[] listas)
        {
            int verificador = ((int)mLado * 10)-2;
            mGraficosZ = pictureBoxes[0].CreateGraphics();
            mGraficosX = pictureBoxes[1].CreateGraphics();
            mGraficosY = pictureBoxes[2].CreateGraphics();
            int rango = (int)mLado * 10;
            //Z
            PointF[] puntosT1;
            PointF[] puntosB1;

            puntosT1 = LinePoints.ObtenerPuntos(mA, mB, rango);
            puntosB1 = LinePoints.ObtenerPuntos(mC, mD, rango);


            //Y
            PointF[] puntosL;
            PointF[] puntosR;
            puntosL = LinePoints.ObtenerPuntos(mA, mC, rango);
            puntosR = LinePoints.ObtenerPuntos(mB, mD, rango);
            PointF[] puntosEntreLineas;


            do
            {
                mPen = SeleccionarColor(color);
                puntosEntreLineas = LinePoints.ObtenerPuntos(puntosL[verificador], puntosR[verificador], rango);
                for (int i = puntosL.Length-2; i > 0; i--)
                {
                    //Z
                    Thread.Sleep(20);
                    mGraficosZ.DrawLine(mPen, puntosT1[i], puntosB1[i]);
                    listas[0].Items.Add(puntosT1[i].X.ToString()); listas[1].Items.Add(puntosT1[i].Y.ToString());
                    listas[2].Items.Add(puntosB1[i].X.ToString()); listas[3].Items.Add(puntosB1[i].Y.ToString());
                    //Y
                    Point pixel = new Point();
                    pixel.X = (int)puntosEntreLineas[i].X; 
                    pixel.Y = (int)puntosEntreLineas[i].Y;
                    listas[4].Items.Add(puntosL[i].X.ToString()); listas[5].Items.Add(puntosL[i].Y.ToString());
                    listas[6].Items.Add(puntosR[i].X.ToString()); listas[7].Items.Add(puntosR[i].Y.ToString());
                    listas[12].Items.Add(pixel.X + "," + pixel.Y );
                    Rectangle rect = new Rectangle(pixel, new Size(1, 1));
                    mGraficosY.DrawRectangle(mPen, rect);
                }
                //X
                mGraficosX.DrawLine(mPen, puntosL[verificador], puntosR[verificador]);
                listas[8].Items.Add(puntosL[verificador].X.ToString()); listas[9].Items.Add(puntosL[verificador].Y.ToString());
                listas[10].Items.Add(puntosR[verificador].X.ToString()); listas[11].Items.Add(puntosR[verificador].Y.ToString());
                verificador--;
            } while (verificador != 0);

        }
        public void GraficadoraRellenoX(PictureBox cuadradoX, PictureBox cuadradoY, ComboBox color, int capas)
        {
            mGraficosX = cuadradoX.CreateGraphics();
            int rango = (int)mLado * 10;
            PointF[] PuntosL;
            PointF[] PuntosR;
            PointF Puntos;

            PuntosL = LinePoints.ObtenerPuntos(mA, mC, rango);
            PuntosR = LinePoints.ObtenerPuntos(mB, mD, rango);

            for (int i = 0; i <= capas; i++)
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
