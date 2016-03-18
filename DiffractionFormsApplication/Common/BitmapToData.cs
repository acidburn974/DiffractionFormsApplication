
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
        public static int[] BitmapToRawDataX(Bitmap img, uint xPos, uint yPos)
        {
            int[] data = new int[img.Width];
            for (int y = 0; y != yPos; y++)
            {
                if (y == yPos)
                {
                    for (int x = 0; x < img.Width; x++)
                    {
                        Color c = img.GetPixel(x, y);
                        int luminance = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                        data[x] = luminance;
                    }
                }
            }

            return data;
        }
    }
}
