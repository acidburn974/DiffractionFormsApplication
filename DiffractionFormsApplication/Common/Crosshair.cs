using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffractionFormsApplication.Common
{
    class Crosshair
    {
        private Bitmap _temporaryFrame;
        public Bitmap FinalFrameBitmap;

        public Crosshair(Bitmap temporaryFrame)
        {
            _temporaryFrame = temporaryFrame;
            var g = Graphics.FromImage(_temporaryFrame);
            g.DrawLine(Pens.Red, _temporaryFrame.Width / 2, 0, _temporaryFrame.Width / 2, _temporaryFrame.Height);
            g.DrawLine(Pens.Red, 0, _temporaryFrame.Height / 2, _temporaryFrame.Width, _temporaryFrame.Height / 2);
            FinalFrameBitmap = new Bitmap(_temporaryFrame);
            _temporaryFrame.Dispose();
        }

        public Crosshair(Bitmap temporaryFrame, int x, int y)
        {
            _temporaryFrame = temporaryFrame;
            var g = Graphics.FromImage(_temporaryFrame);
            g.DrawLine(Pens.Red, _temporaryFrame.Width / 2, 0, _temporaryFrame.Width / 2, _temporaryFrame.Height);
            g.DrawLine(Pens.Red, 0, _temporaryFrame.Height / 2, _temporaryFrame.Width, _temporaryFrame.Height / 2);
            FinalFrameBitmap = new Bitmap(_temporaryFrame);
            _temporaryFrame.Dispose();
        }
    }
}
