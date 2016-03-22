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
        public static void DrawCrosshair(Bitmap image, int x, int y)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawLine(Pens.Red, x, 0, x, image.Height);
                g.DrawLine(Pens.Red, 0, y, image.Width, y);
            }
        }
    }
}
