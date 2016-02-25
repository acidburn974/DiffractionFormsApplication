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

        private Bitmap _temporaryFrame = new Bitmap(1, 1);
        private Bitmap _frame = new Bitmap(1, 1);;

        private Object _bmpLock = new Object();
        

        public MainForm()
        {
            InitializeComponent();  
            _cam = new Camera();
            _cam.Cam.EventFrame += OnEventFrame;
        }

        private void MainForm_Closing(object sender, FormClosedEventArgs e)
        {
            _cam?.Exit();
        }

        public void DisplayWindow_Paint(object sender, PaintEventArgs e)
        {
            lock (_bmpLock)
            {
                if (_cam != null)
                {
                    //Nearest neighbor interpolation dramatically speeds up paint refresh rate if the PictureBox
                    //control is very large
                    //e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                    e.Graphics.DrawImage(_frame, DisplayWindow.ClientRectangle);
                }
            }
        }

        public void OnEventFrame(object sender, EventArgs e)
        {
            uc480.Camera camera = sender as uc480.Camera;

            if (camera == null) return;

            int s32MemId;
            camera.Memory.GetActive(out s32MemId);
            camera.Memory.ToBitmap(s32MemId, out _temporaryFrame);



            Crosshair crosshair = new Crosshair(_temporaryFrame);

            lock (_bmpLock)
            {
                _temporaryFrame.Dispose();
                _temporaryFrame = new Bitmap(crosshair.FinalFrameBitmap);
                _frame.Dispose();
                _frame = new Bitmap(_temporaryFrame);
                _temporaryFrame.Dispose();
            }

            camera.Memory.Unlock(s32MemId);
            DisplayWindow.Invalidate();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DisplayWindow_MouseEnter(object sender, EventArgs e)
        {
            Debug.WriteLine(e);
            /*lock (_bmpLock)
            {
                var g = Graphics.FromImage(_temporaryFrame);
                g.DrawLine(Pens.Red, _temporaryFrame.Width / 2, 0, _temporaryFrame.Width/2, _temporaryFrame.Height);
            }*/
        }

        /// <summary>
        /// Lance l'acquisition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartCaptureButton_Click(object sender, EventArgs e)
        {
            this._cam?.StartCapture();
        }

        /// <summary>
        /// Stop l'acquisition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopCaptureButton_Click(object sender, EventArgs e)
        {
            this._cam?.StopCapture(); // Eq: if(this._cam != null) { }
        }

        /// <summary>
        /// Execute la fonction Freeze de la blibliothèque de la caméra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseCaptureButton_Click(object sender, EventArgs e)
        {
            this._cam?.PauseCapture();
        }
    }
}
