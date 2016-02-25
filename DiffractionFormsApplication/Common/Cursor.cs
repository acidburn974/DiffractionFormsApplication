using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffractionFormsApplication.Common
{
    class Cursor
    {
        private readonly Bitmap _frame;

        public Cursor(Bitmap Frame)
        {
            _frame = Frame;
        }
    }
}
