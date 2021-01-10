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
        const int CENTRADOX = 30;
        const int CENTRADOY = 20;
        private float mLado;
        private float mPerimetro;
        private float mArea;
        //Variables para el modo grafico
        private Graphics mGraficos;
        //Factor de escalamiento
        private const float SF = 20;
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

            mC.X = (mLado * SF) + CENTRADOX;
            mC.Y = (mLado * SF) + CENTRADOY;

            mD.X = (0.0f * SF) + CENTRADOX;
            mD.Y = (mLado * SF) + CENTRADOY;
        }
        public void PuntosGraficaVertical()
        {
            for (float i = 0.0f; i < mLado; i= i+  0.1f)
            {
                PuntosT.Add(new PointF((i*SF)+ CENTRADOX, (0.0f * SF)+ CENTRADOY));
                PuntosB.Add(new PointF((i * SF)+ CENTRADOX, (mLado * SF)+ CENTRADOY));
                posicion++;
            }
            posicion = posicion - 1;
        }
        public void Creadora(PictureBox cuadrado, ComboBox color)
        {
            myPic = cuadrado;
            PuntosPerfil();
            PuntosGraficaVertical();
            Thread graficoZ = new Thread(new ThreadStart(() => Graficadora(cuadrado, color)));
            graficoZ.Start();
        }
        public void Graficadora(PictureBox cuadrado, ComboBox color)
        {
            mGraficos = cuadrado.CreateGraphics();

            mPen = SeleccionarColor(color);
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
            }
            PuntosB.Clear();
            PuntosT.Clear();
            posicion = 0;
        }
        public Pen SeleccionarColor(ComboBox color)
        {
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
            return new Pen(Color.Black,3);
        }
    }
}
