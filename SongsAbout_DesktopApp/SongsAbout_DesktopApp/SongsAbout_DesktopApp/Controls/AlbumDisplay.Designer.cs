namespace SongsAbout.Controls
{
    partial class AlbumDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumDisplay));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblArtist = new SongsAbout.Controls.SLabel();
            this.lblAlbumName = new SongsAbout.Controls.SLabel();
            this.SPictureBox = new SongsAbout.Controls.SPicturePox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listBoxTracks = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblArtist);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlbumName);
            this.splitContainer1.Panel1.Controls.Add(this.SPictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxTracks);
            this.splitContainer1.Size = new System.Drawing.Size(424, 325);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 5;
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
            this.lblArtist.Location = new System.Drawing.Point(194, 70);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(70, 33);
            this.lblArtist.SpotifyEntity = null;
            this.lblArtist.SpotifyEntityType = SpotifyAPI.Web.Enums.SpotifyEntityType.FullArtist;
            this.lblArtist.TabIndex = 3;
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
            this.lblAlbumName.Location = new System.Drawing.Point(194, 16);
            this.lblAlbumName.Name = "lblAlbumName";
            this.lblAlbumName.Size = new System.Drawing.Size(81, 33);
            this.lblAlbumName.SpotifyEntity = null;
            this.lblAlbumName.SpotifyEntityType = SpotifyAPI.Web.Enums.SpotifyEntityType.FullArtist;
            this.lblAlbumName.TabIndex = 2;
            this.lblAlbumName.Text = "Album";
            this.lblAlbumName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SPictureBox
            // 
            this.SPictureBox.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SPictureBox.DbEntity = null;
            this.SPictureBox.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.SPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SPictureBox.Image")));
            this.SPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("SPictureBox.InitialImage")));
            this.SPictureBox.Location = new System.Drawing.Point(0, 0);
            this.SPictureBox.Name = "SPictureBox";
            this.SPictureBox.Size = new System.Drawing.Size(173, 151);
            this.SPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SPictureBox.SpotifyEntity = null;
            this.SPictureBox.SpotifyEntityType = SpotifyAPI.Web.Enums.SpotifyEntityType.FullArtist;
            this.SPictureBox.TabIndex = 1;
            this.SPictureBox.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(173, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(251, 151);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // listBoxTracks
            // 
            this.listBoxTracks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTracks.Location = new System.Drawing.Point(0, 0);
            this.listBoxTracks.Name = "listBoxTracks";
            this.listBoxTracks.Size = new System.Drawing.Size(424, 170);
            this.listBoxTracks.TabIndex = 0;
            // 
            // AlbumDisplay
            // 
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AlbumDisplay";
            this.Size = new System.Drawing.Size(424, 325);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1 = new System.Windows.Forms.SplitContainer();
        private System.Windows.Forms.Splitter splitter1 = new System.Windows.Forms.Splitter();
        private SPicturePox SPictureBox = new SPicturePox();
        private SLabel lblArtist = new SLabel();
        private SLabel lblAlbumName = new SLabel();
        private System.Windows.Forms.FlowLayoutPanel listBoxTracks;
    }
}
