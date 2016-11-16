namespace SongsAbout.Controls
{
    partial class SpotifyPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpotifyPanel));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.spotifyLabel = new SongsAbout.Controls.SpotifyLabel();
            this.SpotifyPictureBox = new SongsAbout.Controls.SpotifyPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpotifyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.SpotifyPictureBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.spotifyLabel);
            this.splitContainer.Size = new System.Drawing.Size(181, 73);
            this.splitContainer.SplitterDistance = 73;
            this.splitContainer.TabIndex = 3;
            // 
            // spotifyLabel
            // 
            this.spotifyLabel.AutoSize = true;
            this.spotifyLabel.BackColor = System.Drawing.Color.Transparent;
            this.spotifyLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spotifyLabel.ForeColor = System.Drawing.Color.White;
            this.spotifyLabel.Level = null;
            this.spotifyLabel.Location = new System.Drawing.Point(7, 28);
            this.spotifyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.spotifyLabel.Name = "spotifyLabel";
            this.spotifyLabel.Size = new System.Drawing.Size(84, 17);
            this.spotifyLabel.TabIndex = 0;
            this.spotifyLabel.Text = "spotifyLabel";
            // 
            // SpotifyPictureBox
            // 
            this.SpotifyPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.SpotifyPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpotifyPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpotifyPictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("SpotifyPictureBox.ErrorImage")));
            this.SpotifyPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SpotifyPictureBox.Image")));
            this.SpotifyPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("SpotifyPictureBox.InitialImage")));
            this.SpotifyPictureBox.Level = null;
            this.SpotifyPictureBox.Location = new System.Drawing.Point(0, 0);
            this.SpotifyPictureBox.Name = "SpotifyPictureBox";
            this.SpotifyPictureBox.Size = new System.Drawing.Size(73, 73);
            this.SpotifyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SpotifyPictureBox.TabIndex = 0;
            this.SpotifyPictureBox.TabStop = false;
            // 
            // SpotifyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.splitContainer);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SpotifyPanel";
            this.Size = new System.Drawing.Size(181, 73);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpotifyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer;
        private SpotifyLabel spotifyLabel;
        private SpotifyPictureBox SpotifyPictureBox;
    }
}
