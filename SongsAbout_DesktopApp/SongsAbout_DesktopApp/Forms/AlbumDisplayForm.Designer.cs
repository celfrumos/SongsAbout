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
            this.lblArtist = new SongsAbout.Controls.SLabel();
            this.lblAlbumName = new SongsAbout.Controls.SLabel();
            this.sPicturePox1 = new SongsAbout.Controls.SPicturePox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPicturePox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxProfilePic
            // 
            this.pBoxProfilePic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBoxProfilePic.Location = new System.Drawing.Point(569, 42);
            this.pBoxProfilePic.Size = new System.Drawing.Size(54, 54);
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
            this.lblArtist.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.ForeColor = System.Drawing.Color.White;
            this.lblArtist.Location = new System.Drawing.Point(130, 95);
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
            this.lblAlbumName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlbumName.AutoEllipsis = true;
            this.lblAlbumName.AutoSize = true;
            this.lblAlbumName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblAlbumName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAlbumName.DbEntity = null;
            this.lblAlbumName.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.lblAlbumName.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbumName.ForeColor = System.Drawing.Color.White;
            this.lblAlbumName.Location = new System.Drawing.Point(130, 42);
            this.lblAlbumName.Name = "lblAlbumName";
            this.lblAlbumName.Size = new System.Drawing.Size(81, 33);
            this.lblAlbumName.SpotifyEntity = null;
            this.lblAlbumName.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.lblAlbumName.TabIndex = 29;
            this.lblAlbumName.Text = "Album";
            this.lblAlbumName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sPicturePox1
            // 
            this.sPicturePox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.sPicturePox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sPicturePox1.DbEntity = null;
            this.sPicturePox1.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.sPicturePox1.Dock = System.Windows.Forms.DockStyle.None;
            this.sPicturePox1.Image = ((System.Drawing.Image)(resources.GetObject("sPicturePox1.Image")));
            this.sPicturePox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("sPicturePox1.InitialImage")));
            this.sPicturePox1.Location = new System.Drawing.Point(12, 46);
            this.sPicturePox1.Name = "sPicturePox1";
            this.sPicturePox1.Size = new System.Drawing.Size(96, 82);
            this.sPicturePox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sPicturePox1.SpotifyEntity = null;
            this.sPicturePox1.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.None;
            this.sPicturePox1.TabIndex = 31;
            this.sPicturePox1.TabStop = false;
            // 
            // AlbumDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.ClientSize = new System.Drawing.Size(635, 399);
            this.Controls.Add(this.sPicturePox1);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblAlbumName);
            this.Name = "AlbumDisplayForm";
            this.Controls.SetChildIndex(this.pBoxProfilePic, 0);
            this.Controls.SetChildIndex(this.lblAlbumName, 0);
            this.Controls.SetChildIndex(this.lblArtist, 0);
            this.Controls.SetChildIndex(this.sPicturePox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPicturePox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.SLabel lblArtist;
        private Controls.SLabel lblAlbumName;
        private Controls.SPicturePox sPicturePox1;
    }
}
