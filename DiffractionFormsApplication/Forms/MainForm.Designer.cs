﻿namespace DiffractionFormsApplication.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.DisplayWindow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayWindow
            // 
            this.DisplayWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayWindow.Cursor = System.Windows.Forms.Cursors.Default;
            this.DisplayWindow.Location = new System.Drawing.Point(12, 12);
            this.DisplayWindow.Name = "DisplayWindow";
            this.DisplayWindow.Size = new System.Drawing.Size(640, 519);
            this.DisplayWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DisplayWindow.TabIndex = 0;
            this.DisplayWindow.TabStop = false;
            this.DisplayWindow.Click += new System.EventHandler(this.DisplayWindow_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 543);
            this.Controls.Add(this.DisplayWindow);
            this.Name = "MainForm";
            this.Text = "Camera";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayWindow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayWindow;
    }
}

