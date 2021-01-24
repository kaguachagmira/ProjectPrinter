using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Utilidades
{
    public class Bresenham
    {
        public static PointF[] ObtenerPuntos(PointF inicial, PointF final, int rango)
        {
            var diff_X = final.X - inicial.X;
            var diff_Y = final.Y - inicial.Y;

            var interval_X = diff_X / (rango + 1);
            var interval_Y = diff_Y / (rango + 1);

            List<PointF> pointList = new List<PointF>();

            for (int i = 0; i < rango; i++)
            {
                pointList.Add(new PointF(inicial.X + interval_X * i, final.Y + interval_Y * i));
            }

            PointF[] points = pointList.ToArray();

            return points;
        }
    }

}
