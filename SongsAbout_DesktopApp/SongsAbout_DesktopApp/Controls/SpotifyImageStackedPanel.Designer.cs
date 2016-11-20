using System.Drawing;

namespace SongsAbout.Controls
{
    partial class SpotifyImageStackedPanel
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpotifyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.MaximumSize = new System.Drawing.Size(105, 135);
            this.splitContainer.MinimumSize = new System.Drawing.Size(70, 95);
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer.Size = new System.Drawing.Size(105, 107);
            this.splitContainer.SplitterDistance = 26;
            // 
            // SpotifyPictureBox
            // 
            this.SpotifyPictureBox.MaximumSize = new System.Drawing.Size(0, 135);
            this.SpotifyPictureBox.MinimumSize = new System.Drawing.Size(70, 0);
            this.SpotifyPictureBox.Size = new System.Drawing.Size(105, 26);
            // 
            // SpotifyLabel
            // 
            this.SpotifyLabel.MaximumSize = new System.Drawing.Size(0, 135);
            this.SpotifyLabel.MinimumSize = new System.Drawing.Size(70, 0);
            this.SpotifyLabel.Size = new System.Drawing.Size(105, 80);
            // 
            // SpotifyImageStackedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.MaximumSize = new System.Drawing.Size(105, 135);
            this.MinimumSize = new System.Drawing.Size(70, 95);
            this.Name = "SpotifyImageStackedPanel";
            this.Size = new System.Drawing.Size(105, 107);
            this.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.None;
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpotifyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


    }
}
