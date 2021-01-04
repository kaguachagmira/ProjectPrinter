using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace ProjectPrinter
{
    class LogicaCuadrado
    {
        //Variables para el cuadrado
        private float mLado;
        private float mPerimetro;
        private float mArea;
        //Variables para el modo grafico
        private Graphics mGraficos;
        //Factor de escalamiento
        private const float SF = 20;
        //Variable que me permite dibujar
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
            mA.X = 0.0f * SF;
            mA.Y = 0.0f * SF;

            mB.X = mLado * SF;
            mB.Y = 0.0f;

            mC.X = mLado * SF;
            mC.Y = mLado * SF;

            mD.X = 0.0f * SF;
            mD.Y = mLado * SF;
        }
        public void PuntosGraficaVertical()
        {
            for (float i = 0.0f; i < mLado; i= i+  0.1f)
            {
                PuntosT.Add(new PointF(i*SF , 0.0f * SF));
                PuntosB.Add(new PointF(i * SF,mLado * SF));
                posicion++;
            }
            posicion = posicion - 1;
        }
        public void Creadora(PictureBox cuadrado)
        {
            myPic = cuadrado;
            PuntosPerfil();
            PuntosGraficaVertical();
            Thread graficoZ = new Thread(new ThreadStart(() => Graficadora(cuadrado)));
            graficoZ.Start();
        }
        public void Graficadora(PictureBox cuadrado)
        {
            mGraficos = cuadrado.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);
            //Dibujo del cuadrado
            mGraficos.DrawLine(mPen, mA, mB);
            mGraficos.DrawLine(mPen, mB, mC);
            mGraficos.DrawLine(mPen, mC, mD);
            mGraficos.DrawLine(mPen, mD, mA);
            //Relleno del cuadrado
            for (int i = 0; i < posicion; i++)
            {
                Thread.Sleep(200);
                mGraficos.DrawLine(mPen, PuntosT[i], PuntosB[i]);
                //MessageBox.Show("" + PuntosB[i].X);
                //MessageBox.Show("" + PuntosB[i].Y);
            }
            PuntosB.Clear();
            PuntosT.Clear();
            posicion = 0;
        }
    }
}
