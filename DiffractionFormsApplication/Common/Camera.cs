using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffractionFormsApplication.Forms;

namespace DiffractionFormsApplication.Common
{
    static class Camera
    {
        public static Object Locker = new Object();

        public static uc480.Camera Cam;
        public static uint FrameCount = 0;
        public static bool IsLive { get; private set; } = false;

        public static Bitmap TemporaryFrame = new Bitmap(1280, 1024);
        public static Bitmap ProfileBitmap = new Bitmap(1280, 1024);
        public static Bitmap Frame = new Bitmap(1280, 1024);

        private static Thread _refreshFrameThread;
        private static Thread _refreshProfileThread;

        public static int CursorXPos;
        public static int CursorYPos;

        public static int[] xProfile;
        public static int[] yProfile;

        static Camera()
        {
            InitCamera();
            //Cam.EventFrame += OnEventFrame;

            // Lance le thread qui rafraichit l'image
            _refreshFrameThread = new Thread(RefreshImageWork);
            _refreshFrameThread.Start();

            // Lance le thread
            _refreshProfileThread = new Thread(RefreshProfileWork);
            _refreshProfileThread.Start();
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
        /// Rafraichit la 
        /// </summary>
        public static void RefreshImageWork()
        {
            int s32MemId;
            Cam.Memory.GetActive(out s32MemId);
            Cam.Memory.Lock(s32MemId);
            Cam.Memory.ToBitmap(s32MemId, out TemporaryFrame);
            Cam.Memory.Unlock(s32MemId);
            lock (Locker)
            {
                Frame = TemporaryFrame;
                ProfileBitmap = new Bitmap(TemporaryFrame);
            }
        }

        /// <summary>
        /// Rafraichit les profils en X et en Y
        /// </summary>
        public static void RefreshProfileWork()
        {
            if (IsLive)
            {
                xProfile = Profile.GetXProfile(ProfileBitmap, CursorXPos, CursorYPos);
                yProfile = Profile.GetYProfile(ProfileBitmap, CursorXPos, CursorYPos);
            } 
            ProfileBitmap.Dispose();
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
