using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
namespace ProjectPrinter
{
    class LogicaEneagono
    {
        private float mLado;
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

        private PointF A, B, C, D, E, F, G, H, I;

        private Graphics mgraficadora;

        private Pen mPen;
        private const float SF = 20;

        public LogicaEneagono()
        {
            mLado = 0.0f;
            mArea = 0.0f;
            mPerimetro = 0.0f;
        }
        public void InicializarDatos(TextBox lado, TextBox perimetro, TextBox area, PictureBox picEneagono)
        {
            lado.Text = "";
            perimetro.Text = "";
            area.Text = "";
            mLado = 0.0f;
            mPerimetro = 0.0f;
            mArea = 0.0f;
            picEneagono.Refresh();
        }
        public void LeerDatos(TextBox lado)
        {
            try
            {
                mLado = float.Parse(lado.Text);
            }
            catch
            {
                MessageBox.Show("Error en el ingreso de datos");
            }
        }
        public void AngulosyLados()
        {
            Angulo1 = 10.0f * (float)Math.PI / 180;
            Angulo2 = 20.0f * (float)Math.PI / 180;
            Angulo3 = 30.0f * (float)Math.PI / 180;
            Angulo4 = 40.0f * (float)Math.PI / 180;
            mAp = mLado / 2 * (float)Math.Tan(Angulo2);
            mLadoa = mLado * (float)Math.Cos(Angulo4);
            mLadob = mLado * (float)Math.Sin(Angulo4);
            mLadoc = mLado * (float)Math.Cos(Angulo1);
            mLadod = mLado * (float)Math.Sin(Angulo1);
            mLadog = mLado * (float)Math.Cos(Angulo3);
            mLadoe = mLado * (float)Math.Cos(Angulo2);
            mLadoh = mLado * (float)Math.Sin(Angulo2);
            mLadof = (mLadoa) - (mLadob) / 2;
        }
        public void AreayPerimetro()
        {
            mPerimetro = mLado * 9;
            mArea = (mPerimetro * mAp) / 2;
        }
        public void puntos()
        {
            AngulosyLados();
            A.X = (mLadoa + mLadod) * SF;
            A.Y = (0.0f) * SF;

            B.X = (mLadoa + mLadod + mLado) * SF;
            B.Y = 0.0f * SF;

            C.X = ((2 * mLadoa) + mLadod + mLado) * SF;
            C.Y = mLadob * SF;

            D.X = ((2 * mLadoa) + (2 * mLadod) + mLado) * SF;
            D.Y = (mLadob + mLadoc) * SF;

            E.X = ((mLadoa + mLadod + mLadoe) + (mLado) / 2) * SF;
            E.Y = (mLadob + mLadoc + mLadog) * SF;

            F.X = ((mLadoa + mLadod) + (mLado) / 2) * SF;
            F.Y = (mLadob + mLadoc + mLadog + mLadoh) * SF;

            G.X = (mLadof) * SF;
            G.Y = (mLadob + mLadoc + mLadog) * SF;

            H.X = (0.0f) * SF;
            H.Y = (mLadob + mLadoc) * SF;

            I.X = (mLadod) * SF;
            I.Y = (mLadob) * SF;
        }
        public void limpiar(PictureBox enegaono)
        {
            enegaono.Refresh();
        }
        public void ImprimirDatos(TextBox perimetro, TextBox area, PictureBox enegaono)
        {
            perimetro.Text = mPerimetro.ToString();
            area.Text = mArea.ToString();
            puntos();
            mgraficadora = enegaono.CreateGraphics();

            mPen = new Pen(Color.Blue, 3);

            mgraficadora.DrawLine(mPen, A, B);
            mgraficadora.DrawLine(mPen, B, C);
            mgraficadora.DrawLine(mPen, C, D);
            mgraficadora.DrawLine(mPen, D, E);
            mgraficadora.DrawLine(mPen, E, F);
            mgraficadora.DrawLine(mPen, F, G);
            mgraficadora.DrawLine(mPen, G, H);
            mgraficadora.DrawLine(mPen, H, I);
            mgraficadora.DrawLine(mPen, I, A);
        }
    }
}
