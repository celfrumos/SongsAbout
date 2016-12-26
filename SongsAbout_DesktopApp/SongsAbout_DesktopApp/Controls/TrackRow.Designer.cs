namespace SongsAbout.Controls
{
    partial class TrackRow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblsName = new SongsAbout.Controls.SLabel();
            this.lblsGenres = new SongsAbout.Controls.SLabel();
            this.lblsArtist = new SongsAbout.Controls.SLabel();
            this.lblsUri = new SongsAbout.Controls.SLabel();
            this.lblsAlbum = new SongsAbout.Controls.SLabel();
            this.lblsLength = new SongsAbout.Controls.SLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.lblsName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblsGenres, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblsArtist, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblsUri, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblsAlbum, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblsLength, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(601, 40);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lblsName
            // 
            this.lblsName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsName.AutoEllipsis = true;
            this.lblsName.AutoSize = true;
            this.lblsName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblsName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblsName.DbEntity = null;
            this.lblsName.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.lblsName.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsName.ForeColor = System.Drawing.Color.White;
            this.lblsName.Location = new System.Drawing.Point(3, 0);
            this.lblsName.Name = "lblsName";
            this.lblsName.Size = new System.Drawing.Size(94, 40);
            this.lblsName.SpotifyEntity = null;
            this.lblsName.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.None;
            this.lblsName.TabIndex = 0;
            this.lblsName.Text = "Name";
            this.lblsName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsGenres
            // 
            this.lblsGenres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsGenres.AutoEllipsis = true;
            this.lblsGenres.AutoSize = true;
            this.lblsGenres.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblsGenres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblsGenres.DbEntity = null;
            this.lblsGenres.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.lblsGenres.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsGenres.ForeColor = System.Drawing.Color.White;
            this.lblsGenres.Location = new System.Drawing.Point(503, 0);
            this.lblsGenres.Name = "lblsGenres";
            this.lblsGenres.Size = new System.Drawing.Size(95, 40);
            this.lblsGenres.SpotifyEntity = null;
            this.lblsGenres.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.None;
            this.lblsGenres.TabIndex = 5;
            this.lblsGenres.Text = "Genres";
            this.lblsGenres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsArtist
            // 
            this.lblsArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsArtist.AutoEllipsis = true;
            this.lblsArtist.AutoSize = true;
            this.lblsArtist.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblsArtist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblsArtist.DbEntity = null;
            this.lblsArtist.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.lblsArtist.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsArtist.ForeColor = System.Drawing.Color.White;
            this.lblsArtist.Location = new System.Drawing.Point(103, 0);
            this.lblsArtist.Name = "lblsArtist";
            this.lblsArtist.Size = new System.Drawing.Size(94, 40);
            this.lblsArtist.SpotifyEntity = null;
            this.lblsArtist.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.None;
            this.lblsArtist.TabIndex = 1;
            this.lblsArtist.Text = "Artist";
            this.lblsArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsUri
            // 
            this.lblsUri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsUri.AutoEllipsis = true;
            this.lblsUri.AutoSize = true;
            this.lblsUri.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblsUri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblsUri.DbEntity = null;
            this.lblsUri.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.lblsUri.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsUri.ForeColor = System.Drawing.Color.White;
            this.lblsUri.Location = new System.Drawing.Point(403, 0);
            this.lblsUri.Name = "lblsUri";
            this.lblsUri.Size = new System.Drawing.Size(94, 40);
            this.lblsUri.SpotifyEntity = null;
            this.lblsUri.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.None;
            this.lblsUri.TabIndex = 4;
            this.lblsUri.Text = "Uri";
            this.lblsUri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsAlbum
            // 
            this.lblsAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsAlbum.AutoEllipsis = true;
            this.lblsAlbum.AutoSize = true;
            this.lblsAlbum.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblsAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblsAlbum.DbEntity = null;
            this.lblsAlbum.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.lblsAlbum.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsAlbum.ForeColor = System.Drawing.Color.White;
            this.lblsAlbum.Location = new System.Drawing.Point(203, 0);
            this.lblsAlbum.Name = "lblsAlbum";
            this.lblsAlbum.Size = new System.Drawing.Size(94, 40);
            this.lblsAlbum.SpotifyEntity = null;
            this.lblsAlbum.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.None;
            this.lblsAlbum.TabIndex = 2;
            this.lblsAlbum.Text = "Album";
            this.lblsAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsLength
            // 
            this.lblsLength.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsLength.AutoEllipsis = true;
            this.lblsLength.AutoSize = true;
            this.lblsLength.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblsLength.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblsLength.DbEntity = null;
            this.lblsLength.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.lblsLength.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsLength.ForeColor = System.Drawing.Color.White;
            this.lblsLength.Location = new System.Drawing.Point(303, 0);
            this.lblsLength.Name = "lblsLength";
            this.lblsLength.Size = new System.Drawing.Size(94, 40);
            this.lblsLength.SpotifyEntity = null;
            this.lblsLength.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.None;
            this.lblsLength.TabIndex = 3;
            this.lblsLength.Text = "Length";
            this.lblsLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(200, 40);
            this.Name = "TrackRow";
            this.Size = new System.Drawing.Size(601, 40);
            this.Load += new System.EventHandler(this.TrackRow_Load);
            this.SizeChanged += new System.EventHandler(this.TrackRow_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SLabel lblsName;
        private SLabel lblsArtist;
        private SLabel lblsAlbum;
        private SLabel lblsLength;
        private SLabel lblsUri;
        private SLabel lblsGenres;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
