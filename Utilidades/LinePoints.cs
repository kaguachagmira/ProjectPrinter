using System;
using System.Drawing;

namespace Utilidades
{
    public class LinePoints
    {
        LinePoints()
        {

        }

        public static PointF[] ObtenerPuntos(PointF inicial, PointF final, int rango)
        {
            var points = new PointF[rango];
            float ydiff = (float)final.Y - (float)inicial.Y;
            float xdiff = (float)final.X - (float)inicial.X;

            double slope = (double)(final.Y - inicial.Y) / (final.X - inicial.X);
            double x, y;

            --rango;

            for (double i = 0; i < rango; i++) {
                y = slope == 0 ? 0 : ydiff * (i / rango);
                x = slope == 0 ? xdiff * (i / rango) : y / slope;
                points[(int)i] = new Point((int)Math.Round(x) + (int)inicial.X, (int)Math.Round(y) + (int)final.Y);
            }

            points[rango] = final;
            return points;
        }
    }
}
