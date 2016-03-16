using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffractionFormsApplication.Common;

namespace DiffractionFormsApplication.Forms
{
    public partial class ActionsForm : Form
    {
        public ActionsForm()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Camera.StartCapture();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            Camera.PauseCapture();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Camera.StopCapture();
        }
    }
}
