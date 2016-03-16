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
        private Camera _cam;

        public Bitmap TemporaryFrame = new Bitmap(1, 1);
        public Bitmap Frame = new Bitmap(1280, 1024);

        public uint FrameCount = 0;

        private Thread _resfreshDisplayThread;
        

        public MainForm()
        {
            InitializeComponent();

            /*if (this.DisplayWindow.Image == null)
            {
                using (Graphics g = Graphics.FromImage(Frame))
                {
                    g.FillRectangle(Brushes.Green, 0, 0, Frame.Width, Frame.Height);
                    using (Font myFont = new Font("Arial", 14))
                    {
                        g.DrawString("Camera not loaded yet", myFont, Brushes.Blue, new Point(Frame.Width / 2, Frame.Height / 2));
                    }
                }
                
                DisplayWindow.Refresh();
            }*/

            _cam = new Camera();
            _cam.Cam.EventFrame += OnEventFrame;

            _resfreshDisplayThread = new Thread(RefreshDisplayWork);
            _resfreshDisplayThread.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void OnEventFrame(object sender, EventArgs e)
        {
            uc480.Camera Camera = sender as uc480.Camera;

            Int32 s32MemId;
            Camera.Memory.GetActive(out s32MemId);
            Camera.Memory.Lock(s32MemId);
            Camera.Memory.ToBitmap(s32MemId, out TemporaryFrame);
            lock (_cam.FrameLocker)
            {
                //Frame = (Bitmap) TemporaryFrame.Clone();
                this.DisplayWindow.Image = TemporaryFrame;
            }
            Camera.Memory.Unlock(s32MemId);
        }

        public void RefreshDisplayWork()
        {
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

        private void DisplayWindow_Click(object sender, EventArgs e)
        {
            // Image.Width / ClientSize.Width
            float ratioX = (float)DisplayWindow.Image.Width/DisplayWindow.ClientSize.Width;
            // ClientSize.Height / Image.Height
            float ratioY = (float) DisplayWindow.ClientSize.Height/DisplayWindow.Image.Height;

            MouseEventArgs me = (MouseEventArgs)e;
            Trace.WriteLine("X Position:" + me.X * ratioX);
            Trace.WriteLine("Y Position:" + me.Y * ratioY);
        }
    }
}
