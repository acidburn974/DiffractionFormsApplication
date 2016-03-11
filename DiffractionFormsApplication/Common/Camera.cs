using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffractionFormsApplication.Forms;

namespace DiffractionFormsApplication.Common
{
    class Camera
    {
        public uc480.Camera Cam;

        public bool IsLive { get; private set; } = false;

        private object _bmpLock = new Object();

        // Image temporaire de la caméra à traiter
        public Bitmap TemporaryFrame = new Bitmap(1280, 1024);
        // Image final à afficher
        public Bitmap Frame = new Bitmap(1280, 1024);

        public Camera()
        {
            InitCamera();
        }

        /// <summary>
        /// Initialise la caméra
        /// </summary>
        public void InitCamera()
        {
            Cam = new uc480.Camera(); //Use only the empty constructor, the one with cameraID has a bug

            uc480.Defines.Status statusRet = 0;

            int s32MemId;

            // Open Cam
            statusRet = Cam.Init(); //You can specify a particular cameraId here if you want to open a specific camera

            if (statusRet != uc480.Defines.Status.SUCCESS)
            {
                MessageBox.Show("Failed to initialize the camera");
            }

            // Allocate Memory
            statusRet = Cam.Memory.Allocate(out s32MemId, true);
            if (statusRet != uc480.Defines.Status.SUCCESS)
            {
                MessageBox.Show("Allocate Memory failed");
            }

            //  Start Live Video
            statusRet = Cam.Acquisition.Capture();
            if (statusRet != uc480.Defines.Status.SUCCESS)
            {
                MessageBox.Show("Start Live Video failed");
            }
            else
            {
                IsLive = true;
            }

            //Cam.EventFrame += OnFrameEvent;
        }

        /*public void OnFrameEvent(object sender, EventArgs e)
        {
            uc480.Camera camera = sender as uc480.Camera;

            if (camera != null)
            {
                int s32MemId;
                camera.Memory.GetActive(out s32MemId);
                camera.Memory.ToBitmap(s32MemId, out TemporaryFrame);

                lock (TemporaryFrame)
                {
                    Frame.Dispose();
                    Frame = new Bitmap(TemporaryFrame);
                }

                camera.Memory.Unlock(s32MemId);
                
            }
        }*/

        /// <summary>
        /// Démarre la capture
        /// </summary>
        public void StartCapture()
        {
            if (Cam.Acquisition.Capture() == uc480.Defines.Status.SUCCESS)
            {
                IsLive = true;
            }
        }

        /// <summary>
        /// Freeze la capture
        /// </summary>
        public void PauseCapture()
        {
            if (Cam.Acquisition.Freeze() == uc480.Defines.Status.SUCCESS)
            {
                IsLive = false;
            }
        }

        /// <summary>
        /// Stop la capture
        /// </summary>
        public void StopCapture()
        {
            if (Cam.Acquisition.Stop() == uc480.Defines.Status.SUCCESS)
            {
                IsLive = false;
            }
        }

        public void Exit()
        {
            this.Cam.Exit();
            IsLive = false;
        }
    }
}
