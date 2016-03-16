using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffractionFormsApplication.Forms;

namespace DiffractionFormsApplication.Common
{
    static class Camera
    {
        public static uc480.Camera Cam;
        public static uint FrameCount = 0;
        public static bool IsLive { get; private set; } = false;
        public static Bitmap Frame = new Bitmap(1, 1);

        static Camera()
        {
            InitCamera();
            //Cam.EventFrame += OnEventFrame;
        }

        /// <summary>
        /// Initialise la caméra
        /// </summary>
        public static void InitCamera()
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

        }

        public static void OnEventFrame(object sender, EventArgs e)
        {
            FrameCount++;
        }

        /// <summary>
        /// Démarre la capture
        /// </summary>
        public static void StartCapture()
        {
            if (Cam.Acquisition.Capture() == uc480.Defines.Status.SUCCESS)
            {
                IsLive = true;
            }
        }

        /// <summary>
        /// Freeze la capture
        /// </summary>
        public static void PauseCapture()
        {
            if (Cam.Acquisition.Freeze() == uc480.Defines.Status.SUCCESS)
            {
                IsLive = false;
            }
        }

        /// <summary>
        /// Stop la capture
        /// </summary>
        public static void StopCapture()
        {
            if (Cam.Acquisition.Stop() == uc480.Defines.Status.SUCCESS)
            {
                IsLive = false;
            }
        }

        public static void Exit()
        {
            Cam.Exit();
            IsLive = false;
        }
    }
}
