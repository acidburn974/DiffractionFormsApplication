using OxyPlot.WindowsForms;

namespace DiffractionFormsApplication.Forms
{
    partial class Histogram
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private PlotView plotProfile;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plotProfile = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // plotProfile
            // 
            this.plotProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotProfile.Location = new System.Drawing.Point(0, 0);
            this.plotProfile.Margin = new System.Windows.Forms.Padding(0);
            this.plotProfile.Name = "plotProfile";
            this.plotProfile.Size = new System.Drawing.Size(632, 446);
            this.plotProfile.TabIndex = 0;
            // 
            // Histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 211);
            this.Controls.Add(this.plotProfile);
            this.Name = "Histogram";
            this.Text = "Histogram";
            this.Load += new System.EventHandler(this.Histogram_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}