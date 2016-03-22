using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiffractionFormsApplication.Forms
{
    public partial class Histogram : Form
    {
        public int[] DataProfile;
        private Timer _chartTimer;




        public Histogram(int[] dataProfile)
        {
            InitializeComponent();
            this.DataProfile = dataProfile;

            this.ProfileChart.DataSource = dataProfile;

            _chartTimer = new System.Windows.Forms.Timer();
            _chartTimer.Tick += new EventHandler(delegate (object sender, EventArgs e) { RefreshChart(); });
            _chartTimer.Interval = 50;
            _chartTimer.Start();
        }

        private void Histogram_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Rafraichit le graphique
        /// </summary>
        private void RefreshChart()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    this.ProfileChart.Refresh();
                });
            }
            else
            {
                this.ProfileChart.Refresh();
            }
        }
    }
}
