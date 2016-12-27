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
            this.splitContainer.Panel1MinSize = 96;
            this.splitContainer.Size = new System.Drawing.Size(96, 135);
            this.splitContainer.SplitterDistance = 96;
            this.splitContainer.SplitterWidth = 2;
            // 
            // SpotifyPictureBox
            // 
            this.SpotifyPictureBox.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.SpotifyPictureBox.MaximumSize = new System.Drawing.Size(96, 96);
            this.SpotifyPictureBox.MinimumSize = new System.Drawing.Size(70, 70);
            this.SpotifyPictureBox.Size = new System.Drawing.Size(96, 96);
            this.SpotifyPictureBox.SpotifyEntityType = SpotifyAPI.Web.Enums.SpotifyEntityType.None;
            // 
            // SpotifyLabel
            // 
            this.SpotifyLabel.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.SpotifyLabel.MaximumSize = new System.Drawing.Size(96, 33);
            this.SpotifyLabel.MinimumSize = new System.Drawing.Size(70, 23);
            this.SpotifyLabel.Size = new System.Drawing.Size(96, 33);
            this.SpotifyLabel.SpotifyEntityType = SpotifyAPI.Web.Enums.SpotifyEntityType.None;
            // 
            // SpotifyImageStackedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ImageSize = new System.Drawing.Size(96, 96);
            this.LabelSize = new System.Drawing.Size(96, 33);
            this.MaximumSize = new System.Drawing.Size(96, 135);
            this.MinimumSize = new System.Drawing.Size(70, 95);
            this.Name = "SpotifyImageStackedPanel";
            this.Size = new System.Drawing.Size(96, 135);
            this.SPanelSize = SongsAbout.Controls.SPanelSize.Large;
            this.SPanelType = SongsAbout.Controls.SPanelType.StackedImage;
            this.SplitterDistance = 96;
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
