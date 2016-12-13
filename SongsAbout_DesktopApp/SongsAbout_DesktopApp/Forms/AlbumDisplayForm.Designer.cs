namespace SongsAbout.Forms
{
    partial class AlbumDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumDisplayForm));
            this.listBoxTracks = new System.Windows.Forms.ListBox();
            this.lblArtist = new SongsAbout.Controls.SLabel();
            this.lblAlbumName = new SongsAbout.Controls.SLabel();
            this.SPictureBox = new SongsAbout.Controls.SPicturePox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxProfilePic
            // 
            this.pBoxProfilePic.Location = new System.Drawing.Point(509, 42);
            this.pBoxProfilePic.Size = new System.Drawing.Size(54, 54);
            // 
            // listBoxTracks
            // 
            this.listBoxTracks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTracks.BackColor = System.Drawing.SystemColors.HotTrack;
            this.listBoxTracks.ForeColor = System.Drawing.Color.White;
            this.listBoxTracks.FormattingEnabled = true;
            this.listBoxTracks.ItemHeight = 23;
            this.listBoxTracks.Location = new System.Drawing.Point(12, 166);
            this.listBoxTracks.Name = "listBoxTracks";
            this.listBoxTracks.Size = new System.Drawing.Size(552, 303);
            this.listBoxTracks.TabIndex = 31;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoEllipsis = true;
            this.lblArtist.AutoSize = true;
            this.lblArtist.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblArtist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblArtist.DbEntity = null;
            this.lblArtist.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.lblArtist.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.ForeColor = System.Drawing.Color.White;
            this.lblArtist.Location = new System.Drawing.Point(155, 104);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(70, 33);
            this.lblArtist.SpotifyEntity = null;
            this.lblArtist.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.lblArtist.TabIndex = 30;
            this.lblArtist.Text = "Artist";
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlbumName
            // 
            this.lblAlbumName.AutoEllipsis = true;
            this.lblAlbumName.AutoSize = true;
            this.lblAlbumName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblAlbumName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAlbumName.DbEntity = null;
            this.lblAlbumName.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.lblAlbumName.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbumName.ForeColor = System.Drawing.Color.White;
            this.lblAlbumName.Location = new System.Drawing.Point(155, 51);
            this.lblAlbumName.Name = "lblAlbumName";
            this.lblAlbumName.Size = new System.Drawing.Size(81, 33);
            this.lblAlbumName.SpotifyEntity = null;
            this.lblAlbumName.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.lblAlbumName.TabIndex = 29;
            this.lblAlbumName.Text = "Album";
            this.lblAlbumName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SPictureBox
            // 
            this.SPictureBox.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SPictureBox.DbEntity = null;
            this.SPictureBox.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.SPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SPictureBox.Image")));
            this.SPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("SPictureBox.InitialImage")));
            this.SPictureBox.Location = new System.Drawing.Point(12, 42);
            this.SPictureBox.Name = "SPictureBox";
            this.SPictureBox.Size = new System.Drawing.Size(121, 106);
            this.SPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SPictureBox.SpotifyEntity = null;
            this.SPictureBox.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.SPictureBox.TabIndex = 28;
            this.SPictureBox.TabStop = false;
            // 
            // AlbumDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.ClientSize = new System.Drawing.Size(576, 478);
            this.Controls.Add(this.listBoxTracks);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblAlbumName);
            this.Controls.Add(this.SPictureBox);
            this.Name = "AlbumDisplayForm";
            this.Controls.SetChildIndex(this.pBoxProfilePic, 0);
            this.Controls.SetChildIndex(this.SPictureBox, 0);
            this.Controls.SetChildIndex(this.lblAlbumName, 0);
            this.Controls.SetChildIndex(this.lblArtist, 0);
            this.Controls.SetChildIndex(this.listBoxTracks, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTracks;
        private Controls.SLabel lblArtist;
        private Controls.SLabel lblAlbumName;
        private Controls.SPicturePox SPictureBox;
    }
}
