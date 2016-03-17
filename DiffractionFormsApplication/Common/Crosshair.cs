using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffractionFormsApplication.Common
{
    static class Crosshair
    {
        public static void DrawCrosshair(ref Bitmap image)
        {
            var g = Graphics.FromImage(image);
            // Draw Vertical Line
            g.DrawLine(Pens.Red, image.Width / 2, 0, image.Width / 2, image.Height);
            // Draw Horizontal Line
            g.DrawLine(Pens.Red, 0, image.Height / 2, image.Width, image.Height / 2);
        }

        public static void DrawCrosshair(ref Bitmap image, uint x, uint y)
        {
            var g = Graphics.FromImage(image);
            g.DrawLine(Pens.Red, x, 0, x, image.Height);
            g.DrawLine(Pens.Red, 0, y, image.Width, y);
        }
    }
}
