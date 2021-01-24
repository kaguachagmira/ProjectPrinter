using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
namespace ProjectPrinter
{
    class LogicaDecagono
    {

        private float mLado;
        private float mAp;
        private float mLadoa;
        private float mLadob;
        private float mLadoc;
        private float mLadod;
        private float mArea;
        private float mPerimetro;
        private float Angulo1;
        private float Angulo2;
        private float Angulo3;

        private PointF A, B, C, D, E, F, G, H, I, J;

        private Graphics mgraficadora;

        private Pen mPen;
        private const float SF = 20;

        public LogicaDecagono()
        {
            mLado = 0.0f;
            mArea = 0.0f;
            mPerimetro = 0.0f;
        }
        public void InicializarDatos(TextBox lado, TextBox perimetro, TextBox area, PictureBox picDecagono)
        {
            lado.Text = "";
            perimetro.Text = "";
            area.Text = "";
            mLado = 0.0f;
            mPerimetro = 0.0f;
            mArea = 0.0f;
            picDecagono.Refresh();
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
        public void limpiar(PictureBox decagono)
        {
            decagono.Refresh();
        }
        public void AngulosyLados()
        {
            Angulo1 = 36.0f * (float)Math.PI / 180;
            Angulo2 = 18.0f * (float)Math.PI / 180;
            Angulo3 = 72.0f * (float)Math.PI / 180;
            mLadoc = mLado * (float)Math.Cos(Angulo1);
            mLadod = mLado * (float)Math.Sin(Angulo2);
            mAp = (mLado * (float)Math.Tan(Angulo3)) / (2.0f);
            mLadoa = mLadod + mLadoc;
            mLadob = mLado * (float)Math.Sin(Angulo1);
        }
        public void AreaYPerimetro()
        {
            mPerimetro = 10.0f * mLado;
            mArea = mPerimetro * mAp / 2;
        }

        public void puntos()
        {
            AngulosyLados();
            A.X = mLadoa * SF;
            A.Y = 0.0f * SF;

            B.X = (mLadoa + mLado) * SF;
            B.Y = 0.0f * SF;

            C.X = (mLadoa + mLado + mLadoc) * SF;
            C.Y = mLadob * SF;

            D.X = (2 * mLadoa + mLado) * SF;
            D.Y = mAp * SF;

            E.X = (mLadoa + mLado + mLadoc) * SF;
            E.Y = (mAp + (mAp - mLadob)) * SF;

            F.X = (mLadoa + mLado) * SF;
            F.Y = (2 * mAp) * SF;

            G.X = (mLadoa) * SF;
            G.Y = (2 * mAp) * SF;

            H.X = (mLadod) * SF;
            H.Y = (mAp + (mAp - mLadob)) * SF;

            I.X = 0.0f * SF;
            I.Y = mAp * SF;

            J.X = mLadod * SF;
            J.Y = mLadob * SF;
        }

        public void ImprimirDatos(TextBox perimetro, TextBox area, PictureBox picDecagono)
        {
            puntos();
            mgraficadora = picDecagono.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);

            perimetro.Text = mPerimetro.ToString();
            area.Text = mArea.ToString();

            mgraficadora.DrawLine(mPen, A, B);
            mgraficadora.DrawLine(mPen, B, C);
            mgraficadora.DrawLine(mPen, C, D);
            mgraficadora.DrawLine(mPen, D, E);
            mgraficadora.DrawLine(mPen, E, F);
            mgraficadora.DrawLine(mPen, F, G);
            mgraficadora.DrawLine(mPen, G, H);
            mgraficadora.DrawLine(mPen, H, I);
            mgraficadora.DrawLine(mPen, I, J);
            mgraficadora.DrawLine(mPen, J, A);

        }
    }
}
