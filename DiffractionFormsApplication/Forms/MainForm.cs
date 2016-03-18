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

        public Bitmap TemporaryFrame = new Bitmap(1280, 1024);
        public Bitmap Frame = new Bitmap(1280, 1024);
        public uint FrameCount = 0;

        private Thread _resfreshDisplayThread;
        private System.Windows.Forms.Timer _displayTimer;
        private Thread _profilesThread;

        public int CursorXPos;
        public int CursorYPos;

        public MainForm()
        {
            InitializeComponent();

            _resfreshDisplayThread = new Thread(RefreshDisplayWork);
            _resfreshDisplayThread.Start();

            _displayTimer = new System.Windows.Forms.Timer();
            _displayTimer.Tick += new EventHandler(delegate(object sender, EventArgs e) { SetDisplayImage(); });
            _displayTimer.Interval = 300;
            _displayTimer.Start();

            _profilesThread = new Thread(RefreshProfile);
            _profilesThread.Start();
        }
            
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DisplayWindow_Click(object sender, EventArgs e)
        {
            // Image.Width / ClientSize.Width
            float ratioX = DisplayWindow.Image.Width/DisplayWindow.ClientSize.Width;
            // ClientSize.Height / Image.Height
            float ratioY = (float)DisplayWindow.Image.Height/DisplayWindow.ClientSize.Height;

            MouseEventArgs me = (MouseEventArgs)e;
            //Trace.WriteLine("X Position:" + me.X * ratioX);
            //Trace.WriteLine("Y Position:" + me.Y * ratioY);

            CursorXPos = (int) (me.X*ratioX);
            CursorYPos = (int) (me.Y*ratioY);
        }

        /// <summary>
        /// Récupère l'image de la caméra et la met en mémoire pour traitement
        /// </summary>
        public void RefreshDisplayWork()
        {
            Int32 s32MemId;
            Camera.Cam.Memory.GetActive(out s32MemId);
            Camera.Cam.Memory.Lock(s32MemId);
            Camera.Cam.Memory.ToBitmap(s32MemId, out TemporaryFrame);
            Camera.Cam.Memory.Unlock(s32MemId);
        }

        /// <summary>
        /// Applique les traitements sur l'image et affiche dans la picturebox
        /// </summary>
        public void SetDisplayImage()
        {
            lock (_locker)
            {
                Frame = TemporaryFrame;
                //Crosshair.DrawCrosshair(ref Frame, CursorXPos, CursorYPos);
                RefreshProfile();
                DisplayWindow.Image = Frame;
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

        public void RefreshProfile()
        {
            int[] xProfile = BitmapToData.GetXProfile(TemporaryFrame, CursorXPos, CursorYPos);
            int[] yProfile = BitmapToData.GetYProfile(TemporaryFrame, CursorXPos, CursorYPos);
        }
    }
}
