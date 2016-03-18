
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffractionFormsApplication.Common
{
    static class BitmapToData
    {
        public static int[] GetXProfile(Bitmap img, int xPos, int yPos)
        {
            int[] data = new int[img.Width];
            for (int x = 0; x < img.Width; x++)
            {
                Color color = img.GetPixel(x, yPos);
                int luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                data[x] = luminance;
            }
            return data;
        }
    }
}
