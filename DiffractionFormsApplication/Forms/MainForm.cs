using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffractionFormsApplication.Common;

namespace DiffractionFormsApplication.Forms
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Object instancié de la classe caméra
        /// </summary>
        private Object _locker = new Object();
        public uint FrameCount = 0;
        private System.Windows.Forms.Timer _displayTimer;

        public MainForm()
        {
            InitializeComponent();

            _displayTimer = new System.Windows.Forms.Timer();
            _displayTimer.Tick += new EventHandler(delegate(object sender, EventArgs e) { SetDisplayImage(); });
            _displayTimer.Interval = 50;
            _displayTimer.Start();
        }
            
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DisplayWindow_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            // Image.Width / ClientSize.Width
            float ratioX = DisplayWindow.Image.Width/DisplayWindow.ClientSize.Width;
            // ClientSize.Height / Image.Height
            float ratioY = (float)DisplayWindow.Image.Height/DisplayWindow.ClientSize.Height;

            Camera.CursorXPos = (int) (me.X*ratioX);
            Camera.CursorYPos = (int) (me.Y*ratioY);
        }

        /// <summary>
        /// Applique les traitements sur l'image et affiche dans la picturebox
        /// </summary>
        public void SetDisplayImage()
        {
            lock (_locker)
            {
                Bitmap frame = new Bitmap(Camera.Frame);
                Crosshair.DrawCrosshair(frame, Camera.CursorXPos, Camera.CursorYPos);
                DisplayWindow.Image = frame;
            }
            
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    this.DisplayWindow.Refresh();
                });
            }
            else
            {
                this.DisplayWindow.Refresh();
            }
        }
    }
}
