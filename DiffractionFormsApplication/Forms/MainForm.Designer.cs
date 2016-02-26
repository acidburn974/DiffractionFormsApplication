namespace DiffractionFormsApplication.Forms
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
            this.StartCaptureButton = new System.Windows.Forms.Button();
            this.StopCaptureButton = new System.Windows.Forms.Button();
            this.PauseCaptureButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayWindow
            // 
            this.DisplayWindow.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisplayWindow.Location = new System.Drawing.Point(12, 12);
            this.DisplayWindow.Name = "DisplayWindow";
            this.DisplayWindow.Size = new System.Drawing.Size(1280, 1024);
            this.DisplayWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.DisplayWindow.TabIndex = 0;
            this.DisplayWindow.TabStop = false;
            this.DisplayWindow.Click += new System.EventHandler(this.DisplayWindow_Click);
            this.DisplayWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayWindow_Paint);
            this.DisplayWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayWindow_MouseMove);
            // 
            // StartCaptureButton
            // 
            this.StartCaptureButton.Location = new System.Drawing.Point(478, 12);
            this.StartCaptureButton.Name = "StartCaptureButton";
            this.StartCaptureButton.Size = new System.Drawing.Size(102, 23);
            this.StartCaptureButton.TabIndex = 1;
            this.StartCaptureButton.Text = "Start capture";
            this.StartCaptureButton.UseVisualStyleBackColor = true;
            this.StartCaptureButton.Click += new System.EventHandler(this.StartCaptureButton_Click);
            // 
            // StopCaptureButton
            // 
            this.StopCaptureButton.Location = new System.Drawing.Point(478, 70);
            this.StopCaptureButton.Name = "StopCaptureButton";
            this.StopCaptureButton.Size = new System.Drawing.Size(102, 23);
            this.StopCaptureButton.TabIndex = 2;
            this.StopCaptureButton.Text = "Stop capture";
            this.StopCaptureButton.UseVisualStyleBackColor = true;
            this.StopCaptureButton.Click += new System.EventHandler(this.StopCaptureButton_Click);
            // 
            // PauseCaptureButton
            // 
            this.PauseCaptureButton.Location = new System.Drawing.Point(478, 41);
            this.PauseCaptureButton.Name = "PauseCaptureButton";
            this.PauseCaptureButton.Size = new System.Drawing.Size(102, 23);
            this.PauseCaptureButton.TabIndex = 3;
            this.PauseCaptureButton.Text = "Pause capture";
            this.PauseCaptureButton.UseVisualStyleBackColor = true;
            this.PauseCaptureButton.Click += new System.EventHandler(this.PauseCaptureButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 492);
            this.Controls.Add(this.PauseCaptureButton);
            this.Controls.Add(this.StopCaptureButton);
            this.Controls.Add(this.StartCaptureButton);
            this.Controls.Add(this.DisplayWindow);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayWindow;
        private System.Windows.Forms.Button StartCaptureButton;
        private System.Windows.Forms.Button StopCaptureButton;
        private System.Windows.Forms.Button PauseCaptureButton;
    }
}

