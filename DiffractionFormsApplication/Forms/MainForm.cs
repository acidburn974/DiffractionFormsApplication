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

        public Bitmap TemporaryFrame = new Bitmap(1, 1);
        public Bitmap Frame = new Bitmap(1280, 1024);

        public uint FrameCount = 0;

        private Thread _resfreshDisplayThread;

        public MainForm()
        {
            InitializeComponent();
            Camera.Cam.EventFrame += OnEventFrame;

            _resfreshDisplayThread = new Thread(RefreshDisplayWork);
            _resfreshDisplayThread.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void OnEventFrame(object sender, EventArgs e)
        {
            uc480.Camera camera = sender as uc480.Camera;

            if (camera != null)
            {
                Int32 s32MemId;
                camera.Memory.GetActive(out s32MemId);
                camera.Memory.Lock(s32MemId);
                camera.Memory.ToBitmap(s32MemId, out TemporaryFrame);
                SetDisplayImage(TemporaryFrame);
                camera.Memory.Unlock(s32MemId);
            }
        }

        public void RefreshDisplayWork()
        {
            lock (_locker)
            {
                DisplayWindow.Image = Camera.Frame;
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        //this.DisplayWindow.Image = Frame;
                        this.DisplayWindow.Refresh();
                    });
                }
                else
                {
                    //this.DisplayWindow.Image = Frame;
                    this.DisplayWindow.Refresh();
                }
            }
        }

        private void DisplayWindow_Click(object sender, EventArgs e)
        {
            // Image.Width / ClientSize.Width
            float ratioX = DisplayWindow.Image.Width/DisplayWindow.ClientSize.Width;
            // ClientSize.Height / Image.Height
            float ratioY = (float)DisplayWindow.Image.Height/DisplayWindow.ClientSize.Height;

            MouseEventArgs me = (MouseEventArgs)e;
            Trace.WriteLine("X Position:" + me.X * ratioX);
            Trace.WriteLine("Y Position:" + me.Y * ratioY);
        }

        /// <summary>
        /// Définit le message 
        /// </summary>
        /// <param name="temporaryBitmap"></param>
        public void SetDisplayImage(Bitmap temporaryBitmap)
        {
            lock (_locker)
            {
                Frame = temporaryBitmap;
                DisplayWindow.Image = Frame;
            }
        }
    }
}
