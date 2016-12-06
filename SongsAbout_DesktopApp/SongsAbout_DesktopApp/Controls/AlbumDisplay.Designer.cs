namespace SongsAbout.Controls
{
    partial class AlbumDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected  Controls.SPicturePox spotifyPictureBox1;
        protected Controls.SLabel lblName;
        protected Controls.SLabel lblArtist;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumDisplay));
            this.spotifyPictureBox1 = new SongsAbout.Controls.SPicturePox();
            this.lblName = new SongsAbout.Controls.SLabel();
            this.lblArtist = new SongsAbout.Controls.SLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.spotifyPictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spotifyPictureBox1
            // 
            this.spotifyPictureBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.spotifyPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spotifyPictureBox1.DbEntity = null;
            this.spotifyPictureBox1.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.spotifyPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spotifyPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("spotifyPictureBox1.Image")));
            this.spotifyPictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("spotifyPictureBox1.InitialImage")));
            this.spotifyPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.spotifyPictureBox1.Name = "spotifyPictureBox1";
            this.spotifyPictureBox1.Size = new System.Drawing.Size(205, 205);
            this.spotifyPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spotifyPictureBox1.SpotifyEntity = null;
            this.spotifyPictureBox1.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.spotifyPictureBox1.TabIndex = 0;
            this.spotifyPictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoEllipsis = true;
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.DbEntity = null;
            this.lblName.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.lblName.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(255, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 19);
            this.lblName.SpotifyEntity = null;
            this.lblName.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArtist
            // 
            this.lblArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArtist.AutoEllipsis = true;
            this.lblArtist.AutoSize = true;
            this.lblArtist.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblArtist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblArtist.DbEntity = null;
            this.lblArtist.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.lblArtist.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.lblArtist.ForeColor = System.Drawing.Color.White;
            this.lblArtist.Location = new System.Drawing.Point(255, 64);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(41, 19);
            this.lblArtist.SpotifyEntity = null;
            this.lblArtist.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.lblArtist.TabIndex = 2;
            this.lblArtist.Text = "Artist";
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.spotifyPictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 205);
            this.panel1.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(3, 203);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(592, 244);
            this.listBox1.TabIndex = 4;
            // 
            // AlbumDisplay
            // 
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblName);
            this.Name = "AlbumDisplay";
            this.Size = new System.Drawing.Size(598, 450);
            ((System.ComponentModel.ISupportInitialize)(this.spotifyPictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
    }
}
