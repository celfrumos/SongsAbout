using SongsAbout.Properties;
namespace SongsAbout.Forms
{
    partial class SpotifySearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpotifySearchForm));
            this.flpSpotifyControls = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlSearchType = new System.Windows.Forms.Panel();
            this.cboxPlaylists = new System.Windows.Forms.CheckBox();
            this.cboxTracks = new System.Windows.Forms.CheckBox();
            this.cboxAlbums = new System.Windows.Forms.CheckBox();
            this.cboxArtists = new System.Windows.Forms.CheckBox();
            this.cboxAll = new System.Windows.Forms.CheckBox();
            this.albumDisplay1 = new SongsAbout.Controls.AlbumDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            this.flpSpotifyControls.SuspendLayout();
            this.pnlSearchType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBoxProfilePic
            // 
            this.pBoxProfilePic.Location = new System.Drawing.Point(12, 41);
            this.pBoxProfilePic.Size = new System.Drawing.Size(43, 46);
            // 
            // flpSpotifyControls
            // 
            this.flpSpotifyControls.AllowDrop = true;
            this.flpSpotifyControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpSpotifyControls.AutoScroll = true;
            this.flpSpotifyControls.Controls.Add(this.albumDisplay1);
            this.flpSpotifyControls.Location = new System.Drawing.Point(12, 94);
            this.flpSpotifyControls.Name = "flpSpotifyControls";
            this.flpSpotifyControls.Size = new System.Drawing.Size(941, 612);
            this.flpSpotifyControls.TabIndex = 0;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSearch.Location = new System.Drawing.Point(683, 42);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(169, 26);
            this.txtBoxSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(867, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlSearchType
            // 
            this.pnlSearchType.Controls.Add(this.cboxPlaylists);
            this.pnlSearchType.Controls.Add(this.cboxTracks);
            this.pnlSearchType.Controls.Add(this.cboxAlbums);
            this.pnlSearchType.Controls.Add(this.cboxArtists);
            this.pnlSearchType.Location = new System.Drawing.Point(332, 42);
            this.pnlSearchType.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSearchType.Name = "pnlSearchType";
            this.pnlSearchType.Size = new System.Drawing.Size(334, 26);
            this.pnlSearchType.TabIndex = 28;
            // 
            // cboxPlaylists
            // 
            this.cboxPlaylists.AutoSize = true;
            this.cboxPlaylists.ForeColor = System.Drawing.Color.White;
            this.cboxPlaylists.Location = new System.Drawing.Point(254, 2);
            this.cboxPlaylists.Margin = new System.Windows.Forms.Padding(2);
            this.cboxPlaylists.Name = "cboxPlaylists";
            this.cboxPlaylists.Size = new System.Drawing.Size(79, 23);
            this.cboxPlaylists.TabIndex = 0;
            this.cboxPlaylists.Text = "Playlists";
            this.cboxPlaylists.UseVisualStyleBackColor = true;
            this.cboxPlaylists.CheckedChanged += new System.EventHandler(this.cbox_SpecificCheckedChanged);
            // 
            // cboxTracks
            // 
            this.cboxTracks.AutoSize = true;
            this.cboxTracks.ForeColor = System.Drawing.Color.White;
            this.cboxTracks.Location = new System.Drawing.Point(170, 2);
            this.cboxTracks.Margin = new System.Windows.Forms.Padding(2);
            this.cboxTracks.Name = "cboxTracks";
            this.cboxTracks.Size = new System.Drawing.Size(71, 23);
            this.cboxTracks.TabIndex = 0;
            this.cboxTracks.Text = "Tracks";
            this.cboxTracks.UseVisualStyleBackColor = true;
            this.cboxTracks.CheckedChanged += new System.EventHandler(this.cbox_SpecificCheckedChanged);
            // 
            // cboxAlbums
            // 
            this.cboxAlbums.AutoSize = true;
            this.cboxAlbums.ForeColor = System.Drawing.Color.White;
            this.cboxAlbums.Location = new System.Drawing.Point(83, 2);
            this.cboxAlbums.Margin = new System.Windows.Forms.Padding(2);
            this.cboxAlbums.Name = "cboxAlbums";
            this.cboxAlbums.Size = new System.Drawing.Size(74, 23);
            this.cboxAlbums.TabIndex = 0;
            this.cboxAlbums.Text = "Albums";
            this.cboxAlbums.UseVisualStyleBackColor = true;
            this.cboxAlbums.CheckedChanged += new System.EventHandler(this.cbox_SpecificCheckedChanged);
            // 
            // cboxArtists
            // 
            this.cboxArtists.AutoSize = true;
            this.cboxArtists.ForeColor = System.Drawing.Color.White;
            this.cboxArtists.Location = new System.Drawing.Point(2, 2);
            this.cboxArtists.Margin = new System.Windows.Forms.Padding(2);
            this.cboxArtists.Name = "cboxArtists";
            this.cboxArtists.Size = new System.Drawing.Size(67, 23);
            this.cboxArtists.TabIndex = 0;
            this.cboxArtists.Text = "Artists";
            this.cboxArtists.UseVisualStyleBackColor = true;
            this.cboxArtists.CheckedChanged += new System.EventHandler(this.cbox_SpecificCheckedChanged);
            // 
            // cboxAll
            // 
            this.cboxAll.AutoSize = true;
            this.cboxAll.Checked = true;
            this.cboxAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxAll.ForeColor = System.Drawing.Color.White;
            this.cboxAll.Location = new System.Drawing.Point(288, 45);
            this.cboxAll.Margin = new System.Windows.Forms.Padding(2);
            this.cboxAll.Name = "cboxAll";
            this.cboxAll.Size = new System.Drawing.Size(43, 23);
            this.cboxAll.TabIndex = 0;
            this.cboxAll.Text = "All";
            this.cboxAll.UseVisualStyleBackColor = true;
            this.cboxAll.CheckedChanged += new System.EventHandler(this.cboxAll_CheckedChanged);
            // 
            // albumDisplay1
            // 
            this.albumDisplay1.AlbumName = "Album";
            this.albumDisplay1.AlbumType = SongsAbout.Controls.AlbumType.DB;
            this.albumDisplay1.ArtistName = "Artist";
            this.albumDisplay1.BackColor = System.Drawing.SystemColors.HotTrack;
            //this.albumDisplay1.DbEntity = albumDisplay1.Album;
            this.albumDisplay1.DbEntityType = SongsAbout.Enums.DbEntityType.Album;
            this.albumDisplay1.Image = ((System.Drawing.Image)(resources.GetObject("albumDisplay1.Image")));
            this.albumDisplay1.Location = new System.Drawing.Point(3, 3);
            this.albumDisplay1.Name = "albumDisplay1";
            this.albumDisplay1.Size = new System.Drawing.Size(424, 325);            
            this.albumDisplay1.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.albumDisplay1.TabIndex = 0;
            // 
            // SpotifySearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(965, 720);
            this.Controls.Add(this.pnlSearchType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.cboxAll);
            this.Controls.Add(this.flpSpotifyControls);
            this.Name = "SpotifySearchForm";
            this.Text = "Import From Spotify";
            this.Controls.SetChildIndex(this.flpSpotifyControls, 0);
            this.Controls.SetChildIndex(this.cboxAll, 0);
            this.Controls.SetChildIndex(this.txtBoxSearch, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.pBoxProfilePic, 0);
            this.Controls.SetChildIndex(this.pnlSearchType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
            this.flpSpotifyControls.ResumeLayout(false);
            this.pnlSearchType.ResumeLayout(false);
            this.pnlSearchType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSpotifyControls = new System.Windows.Forms.FlowLayoutPanel();
        private System.Windows.Forms.TextBox txtBoxSearch = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Button btnSearch = new System.Windows.Forms.Button();
        private System.Windows.Forms.Panel pnlSearchType;
        private System.Windows.Forms.CheckBox cboxPlaylists;
        private System.Windows.Forms.CheckBox cboxTracks;
        private System.Windows.Forms.CheckBox cboxAlbums;
        private System.Windows.Forms.CheckBox cboxArtists;
        private System.Windows.Forms.CheckBox cboxAll;
        private Controls.AlbumDisplay albumDisplay1;
    }
}