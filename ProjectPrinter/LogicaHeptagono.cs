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
    class LogicaHeptagono
    {
        private float mLado;
        private float nuevoLado;
        private float mAp;
        private float mLadoa;
        private float mLadob;
        private float mLadoc;
        private float mLadod;
        private float mLadoe;
        private float mLadof;
        private float mLadog;
        private float mLadoh;
        private float mArea;
        private float mPerimetro;
        private float Angulo1;
        private float Angulo2;
        private float Angulo3;
        private float Angulo4;
        private float Angulo5;

        private PointF mA, mB, mC, mD, mE, mF, mG;

        private Graphics mGraficosX;
        private Graphics mGraficosY;
        private Graphics mGraficosZ;

        private Pen mPen;
        private const float SF = 10;

        public LogicaHeptagono()
        {
            mArea = 0.0f;
            mPerimetro = 0.0f;
            mLado = 0.0f;
        }
        public void InicializarDatos(TextBox lado, TextBox perimetro, TextBox area, PictureBox heptagono)
        {
            mArea = 0.0f;
            mPerimetro = 0.0f;
            mLado = 0.0f;
            lado.Text = "";
            perimetro.Text = "";
            area.Text = "";
            heptagono.Refresh();
        }
        public void Leerdatos(TextBox lado)
        {
            try
            {
                mLado = float.Parse(lado.Text);
            }
            catch
            {
                MessageBox.Show("Error en el Ingreso de datos");
            }

        }
        public void Procesos()
        {
            //Primero los angulos
            Angulo1 = 51.42f * (float)Math.PI / 180.0f;
            Angulo2 = 38.54f * (float)Math.PI / 180.0f;
            Angulo3 = 64.28f * (float)Math.PI / 180.0f;
            Angulo4 = 38.57f * (float)Math.PI / 180.0f;
            Angulo5 = 65.28f * (float)Math.PI / 180.0f;

            //Calculo de la Apotema
            mAp = (mLado * (float)Math.Tan(Angulo3)) / 2;

            //Los lados usando los angulos
            mLadoa = mLado * (float)Math.Cos(Angulo1);
            mLadob = mLado * (float)Math.Sin(Angulo1);
            mLadof = (mLado / (2 * (float)Math.Cos(Angulo3)));
            mLadoc = ((mAp + mLadof) - mLadob);
            mLadod = mLadoa + (mLado / 2);
            mLadoe = mLadof * (float)Math.Cos(Angulo2);
            mLadog = mLadod - mLadoe;
            mLadoh = mLadof * (float)Math.Sin(Angulo4);

        }
        public void perimetroyarea()
        {
            mPerimetro = mLado * 7.0f;
            mArea = (mPerimetro * mAp) / 2;
        }
        public void DeterminarPuntos()
        {
            mA.X = mLadoa * SF;
            mA.Y = 0.0f * SF;

            mB.X = (mLadoa + mLado) * SF;
            mB.Y = 0.0f * SF;

            mC.X = ((2 * mLadoa) + mLado) * SF;
            mC.Y = mLadob * SF;

            mD.X = (mLadod + mLadoe) * SF;
            mD.Y = (mLadoh + mAp) * SF;

            mE.X = (mLadoa + (mLado / 2)) * SF;
            mE.Y = (mAp + mLadof) * SF;

            mF.X = (mLadog) * SF;
            mF.Y = (mLadoh + mAp) * SF;

            mG.X = 0.0f * SF;
            mG.Y = mLadob * SF;
        }
        public void limpiar(PictureBox heptagono)
        {
            heptagono.Refresh();
        }
        public void Impresion(PictureBox[] pictureBoxes, ComboBox color, ListBox[] lista)
        {

            int rango = ((int)mLado * (int)SF);
            int veri = 0;
            mGraficosZ = pictureBoxes[0].CreateGraphics();
            mGraficosX = pictureBoxes[1].CreateGraphics();
            mGraficosY = pictureBoxes[2].CreateGraphics();
            PointF[] puntosEntreLineas;
            DeterminarPuntos();
            //Perspectiva Z por la izquierda
            PointF[] puntosAG;
            PointF[] puntosGF;
            PointF[] puntosFE;
            PointF[] puntosIzquierda;
            puntosAG = Bresenham.ObtenerPuntos(mA, mG, rango);
            puntosGF = Bresenham.ObtenerPuntos(mG, mF, rango);
            Recorrer(puntosGF, (int)rango / 2);
            puntosFE = Bresenham.ObtenerPuntos(mF, mE, rango);
            RecorrerPos(puntosFE, (int)rango / 2);

            puntosIzquierda = (puntosAG.Concat(puntosGF).ToArray()).Concat(puntosFE).ToArray();

            //Perspectiva Z por la derecha
            PointF[] puntosBC;
            PointF[] puntosCD;
            PointF[] puntosDE;
            PointF[] puntosDerecha;
            puntosAG = Bresenham.ObtenerPuntos(mB, mC, rango);
            puntosCD = Bresenham.ObtenerPuntos(mC, mD, rango);
            Recorrer(puntosCD, (int)rango / 2);

            puntosDE = Bresenham.ObtenerPuntos(mD, mE, rango);
            RecorrerPos(puntosDE, (int)rango / 2);

            puntosDerecha = (puntosAG.Concat(puntosCD).ToArray()).Concat(puntosDE).ToArray();


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




            /*
            mGraficosZ.DrawLine(mPen, A, B);
            mGraficosZ.DrawLine(mPen, B, C);
            mGraficosZ.DrawLine(mPen, C, D);
            mGraficosZ.DrawLine(mPen, D, E);
            mGraficosZ.DrawLine(mPen, E, F);
            mGraficosZ.DrawLine(mPen, F, G);
            mGraficosZ.DrawLine(mPen, G, A);
            mGraficosZ.DrawLine(mPen, G, A);*/

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
            rango = rango - (int)nuevoLado - 8;
            for (int i = 0; i < Puntos.Length; i++)
            {
                Puntos[i].Y = Puntos[i].Y - rango;
            }
        }
        public void RecorrerPos(PointF[] Puntos, int rango)
        {
            rango = rango - (int)nuevoLado - 5;
            for (int i = 0; i < Puntos.Length; i++)
            {
                Puntos[i].Y = Puntos[i].Y + rango;
            }
        }
    }
}
