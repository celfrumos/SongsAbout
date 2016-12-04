namespace SongsAbout.Controls
{
    partial class EntityDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected  Controls.SpotifyPictureBox spotifyPictureBox1;
        protected Controls.SpotifyLabel sLabelEntityName;
        protected Controls.SpotifyLabel spotifyLabel1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityDisplay));
            this.spotifyPictureBox1 = new SongsAbout.Controls.SpotifyPictureBox();
            this.sLabelEntityName = new SongsAbout.Controls.SpotifyLabel();
            this.spotifyLabel1 = new SongsAbout.Controls.SpotifyLabel();
            ((System.ComponentModel.ISupportInitialize)(this.spotifyPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // spotifyPictureBox1
            // 
            this.spotifyPictureBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.spotifyPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spotifyPictureBox1.DbEntity = null;
            this.spotifyPictureBox1.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.spotifyPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("spotifyPictureBox1.Image")));
            this.spotifyPictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("spotifyPictureBox1.InitialImage")));
            this.spotifyPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.spotifyPictureBox1.Name = "spotifyPictureBox1";
            this.spotifyPictureBox1.Size = new System.Drawing.Size(189, 194);
            this.spotifyPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spotifyPictureBox1.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.spotifyPictureBox1.TabIndex = 0;
            this.spotifyPictureBox1.TabStop = false;
            // 
            // sLabelEntityName
            // 
            this.sLabelEntityName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sLabelEntityName.AutoEllipsis = true;
            this.sLabelEntityName.AutoSize = true;
            this.sLabelEntityName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.sLabelEntityName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sLabelEntityName.DbEntity = null;
            this.sLabelEntityName.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.sLabelEntityName.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.sLabelEntityName.ForeColor = System.Drawing.Color.White;
            this.sLabelEntityName.Location = new System.Drawing.Point(229, 25);
            this.sLabelEntityName.Name = "sLabelEntityName";
            this.sLabelEntityName.Size = new System.Drawing.Size(46, 19);
            this.sLabelEntityName.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.sLabelEntityName.TabIndex = 1;
            this.sLabelEntityName.Text = "Name";
            this.sLabelEntityName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spotifyLabel1
            // 
            this.spotifyLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spotifyLabel1.AutoEllipsis = true;
            this.spotifyLabel1.AutoSize = true;
            this.spotifyLabel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.spotifyLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spotifyLabel1.DbEntity = null;
            this.spotifyLabel1.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.spotifyLabel1.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.spotifyLabel1.ForeColor = System.Drawing.Color.White;
            this.spotifyLabel1.Location = new System.Drawing.Point(229, 71);
            this.spotifyLabel1.Name = "spotifyLabel1";
            this.spotifyLabel1.Size = new System.Drawing.Size(93, 19);
            this.spotifyLabel1.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.spotifyLabel1.TabIndex = 2;
            this.spotifyLabel1.Text = "spotifyLabel1";
            this.spotifyLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EntityDisplay
            // 
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.spotifyLabel1);
            this.Controls.Add(this.sLabelEntityName);
            this.Controls.Add(this.spotifyPictureBox1);
            this.Name = "EntityDisplay";
            this.Size = new System.Drawing.Size(598, 450);
            ((System.ComponentModel.ISupportInitialize)(this.spotifyPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}
