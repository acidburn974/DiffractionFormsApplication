using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DiffractionFormsApplication.Common;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace DiffractionFormsApplication.Forms
{
    public partial class Histogram : Form
    {
        private string _profileName;
        private int[] _profile;
        private System.Windows.Forms.Timer _chartTimer;
        private PlotModel _pm = new PlotModel()
        {
            PlotType = PlotType.Cartesian,
            Background = OxyColors.White,
            Axes =
            {
                new LinearAxis() { Position = AxisPosition.Bottom, Minimum = 0 },
                new LinearAxis() { Position = AxisPosition.Left, Minimum = 0, Maximum = 255 }
            }
        };
        private LineSeries _lineSeries = new LineSeries();

        public Histogram(string profileName)
        {
            InitializeComponent();
            _profileName = profileName;

            _pm.Title = _profileName == "x" ? "Profil horizontal" : "Profil vertical";

            _chartTimer = new System.Windows.Forms.Timer();
            _chartTimer.Tick += new EventHandler(delegate (object sender, EventArgs e) { RefreshChart(); });
            _chartTimer.Interval = 200;
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
            _profile = _profileName == "x" ? Profile.GetXProfile(Camera.TemporaryFrame, Camera.CursorXPos, Camera.CursorYPos) : Profile.GetYProfile(Camera.TemporaryFrame, Camera.CursorXPos, Camera.CursorYPos);

            _pm.Series.Clear();
            _lineSeries.Points.Clear();
            for (int i = 0; i < _profile.Length; i++)
            {
                _lineSeries.Points.Add(new OxyPlot.DataPoint(i + 1, _profile[i]));
            }
            _pm.Series.Add(_lineSeries);
            plotProfile.Model = _pm;
            plotProfile.Refresh();
        }
    }
}
