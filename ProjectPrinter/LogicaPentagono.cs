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
    class LogicaPentagono
    {

        private float mArea;
        private float mPerimetro;
        private float mLado;

        //Atributos para guardar los valores de los angulos

        private float Anguloa;
        private float Angulob;
        private float AnguloAp;

        //Atributos para guardar los valores de los lados

        private float mLadoa;
        private float mLadob;
        private float mLadoc;
        private float mLadod;
        private float mAp;

        //Atributos para los puntos

        private PointF mA;
        private PointF mB;
        private PointF mC;
        private PointF mD;
        private PointF mE;

        //Atributo que me permite usar el modo grafico
        private Graphics mGraficosX;
        private Graphics mGraficosY;
        private Graphics mGraficosZ;
        //Declarar el factor de escalamiento

        private const float SF = 10;
        //Atributo que me permite dibujar con un lapiz

        private Pen mPen;

        //Constructor de  la clase me vacio//Sirve tambien para inicializar los atributos que se mostraran en pantalla

        public LogicaPentagono()
        {
            mLado = 0.0f;
            mArea = 0.0F;
            mPerimetro = 0.0f;
        }

        public void InicializaDatos(TextBox lado, TextBox perimetro, TextBox area, PictureBox pentagono)
        {
            lado.Text = "";
            perimetro.Text = "";
            area.Text = "";
            pentagono.Refresh();
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
            catch(Exception ex)
            {
                MessageBox.Show("Error al ingresar el lado del Pentagono"+ex);
            }
      

        }
        public void LadoyAngulos()

        {
            //Calculo de angulos

            Anguloa = (72.0f * (float)Math.PI) / 180.0f;
            Angulob = (36.0f * (float)Math.PI) / 180.0f;

            //Calculo de los lados apartir de los angulos
            mLadoa = mLado * (float)Math.Sin(Anguloa);
            mLadob = mLado * (float)Math.Sin(Angulob);
            mLadoc = mLado * (float)Math.Cos(Angulob);
            mLadod = mLado * (float)Math.Cos(Anguloa);

            mAp = (1 / 2 * (float)Math.Tan(Angulob));
        }

        public void PerimetroyArea()
        {
            mPerimetro = mLado * 5;
            mArea = ((mPerimetro) * mAp) / 2;
        }
        public void ImprimirDatos(TextBox area, TextBox perimetro)
        {
            area.Text = mArea.ToString();
            perimetro.Text = mPerimetro.ToString();
        }
        public void DeterminarPuntos()
        {
            mA.X = mLadod * SF;
            mA.Y = 0.0f * SF;

            mB.X = (mLadod + mLado) * SF;
            mB.Y = 0.0f * SF;

            mC.X = (mLado + (2 * mLadod)) * SF;
            mC.Y = mLadoa * SF;

            mD.X = (mLadoc) * SF;
            mD.Y = (mLadoa + mLadob) * SF;

            mE.X = 0.0f * SF;
            mE.Y = (mLadoa) * SF;
        }
        public void graficar(PictureBox[] pictureBoxes, ComboBox color, ListBox[] listas)
        {
            int rango = ((int)mLado * (int)SF);
            int veri = 0;
            mGraficosZ = pictureBoxes[0].CreateGraphics();
            mGraficosX = pictureBoxes[1].CreateGraphics();
            mGraficosY = pictureBoxes[2].CreateGraphics();
            PointF[] puntosEntreLineas;
            DeterminarPuntos();
            //Perspectiva Z por la izquierda
            PointF[] puntosAE;
            PointF[] puntosED;
            PointF[] puntosIzquierda;
            puntosAE = Bresenham.ObtenerPuntos(mA, mE, rango);
            Recorrer(puntosAE, (int)rango/ 2);
            puntosED = Bresenham.ObtenerPuntos(mE, mD, rango);
            puntosIzquierda = puntosAE.Concat(puntosED).ToArray();
            //Perspectiva Z por la derecha
            PointF[] puntosBC;
            PointF[] puntosCD;
            PointF[] puntosDerecha;
            puntosBC = Bresenham.ObtenerPuntos(mB, mC, rango);
            Recorrer(puntosBC, (int)rango / 2);
            puntosCD = Bresenham.ObtenerPuntos(mC, mD, rango);
            puntosDerecha = puntosBC.Concat(puntosCD).ToArray();

            veri = puntosDerecha.Length-1;

            do
            {
                mPen = SeleccionarColor(color);
                puntosEntreLineas = Bresenham.ObtenerPuntos(puntosIzquierda[veri], puntosDerecha[veri], puntosDerecha.Length);
                for (int k = puntosDerecha.Length-1, j=0; k > 0; k--, j++)
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
            rango = rango - (int)mLado-1;
            for(int i = 0; i < Puntos.Length; i++)
            {
                Puntos[i].Y = Puntos[i].Y - rango;
            }
        } 
    }
}
