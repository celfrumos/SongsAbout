using SongsAbout.Desktop.Properties;
namespace SongsAbout.Forms
{
    partial class SForm
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
            System.Windows.Forms.MenuStrip mainMenuStrip;
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spotifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savedTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followedArtistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportPlaylists = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportPlaylists_WithTracks = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportPlaylists_NoTracks = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pBoxProfilePic = new System.Windows.Forms.PictureBox();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SongModule = new SongsAbout.Controls.SongModule();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.spotifyToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.profileToolStripMenuItem});
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            mainMenuStrip.Size = new System.Drawing.Size(527, 30);
            mainMenuStrip.TabIndex = 18;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDatabaseToolStripMenuItem,
            this.addNewTrackToolStripMenuItem,
            this.bulkAddToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewDatabaseToolStripMenuItem
            // 
            this.viewDatabaseToolStripMenuItem.Name = "viewDatabaseToolStripMenuItem";
            this.viewDatabaseToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.viewDatabaseToolStripMenuItem.Text = "View Database";
            // 
            // addNewTrackToolStripMenuItem
            // 
            this.addNewTrackToolStripMenuItem.Name = "addNewTrackToolStripMenuItem";
            this.addNewTrackToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.addNewTrackToolStripMenuItem.Text = "Add New Track";
            // 
            // bulkAddToolStripMenuItem
            // 
            this.bulkAddToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genresToolStripMenuItem,
            this.tagsToolStripMenuItem,
            this.playlistsToolStripMenuItem});
            this.bulkAddToolStripMenuItem.Name = "bulkAddToolStripMenuItem";
            this.bulkAddToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.bulkAddToolStripMenuItem.Text = "Bulk Add";
            // 
            // genresToolStripMenuItem
            // 
            this.genresToolStripMenuItem.Name = "genresToolStripMenuItem";
            this.genresToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.genresToolStripMenuItem.Text = "Genres";
            this.genresToolStripMenuItem.Click += new System.EventHandler(this.tsmiBulkGenres_Click);
            // 
            // tagsToolStripMenuItem
            // 
            this.tagsToolStripMenuItem.Name = "tagsToolStripMenuItem";
            this.tagsToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.tagsToolStripMenuItem.Text = "Tags";
            // 
            // playlistsToolStripMenuItem
            // 
            this.playlistsToolStripMenuItem.Name = "playlistsToolStripMenuItem";
            this.playlistsToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.playlistsToolStripMenuItem.Text = "Playlists";
            // 
            // spotifyToolStripMenuItem
            // 
            this.spotifyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.importToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.spotifyToolStripMenuItem.Name = "spotifyToolStripMenuItem";
            this.spotifyToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.spotifyToolStripMenuItem.Text = "Spotify";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savedTracksToolStripMenuItem,
            this.followedArtistsToolStripMenuItem,
            this.tsmiImportPlaylists,
            this.allToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // savedTracksToolStripMenuItem
            // 
            this.savedTracksToolStripMenuItem.Name = "savedTracksToolStripMenuItem";
            this.savedTracksToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.savedTracksToolStripMenuItem.Text = "Saved Tracks";
            this.savedTracksToolStripMenuItem.Click += new System.EventHandler(this.msiImportSavedTracks_Click);
            // 
            // followedArtistsToolStripMenuItem
            // 
            this.followedArtistsToolStripMenuItem.Name = "followedArtistsToolStripMenuItem";
            this.followedArtistsToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.followedArtistsToolStripMenuItem.Text = "Followed Artists";
            this.followedArtistsToolStripMenuItem.Click += new System.EventHandler(this.msiImportSavedTracks_Click);
            // 
            // tsmiImportPlaylists
            // 
            this.tsmiImportPlaylists.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImportPlaylists_WithTracks,
            this.tsmiImportPlaylists_NoTracks});
            this.tsmiImportPlaylists.Name = "tsmiImportPlaylists";
            this.tsmiImportPlaylists.Size = new System.Drawing.Size(201, 26);
            this.tsmiImportPlaylists.Text = "Followed Playlists";
            // 
            // tsmiImportPlaylists_WithTracks
            // 
            this.tsmiImportPlaylists_WithTracks.Name = "tsmiImportPlaylists_WithTracks";
            this.tsmiImportPlaylists_WithTracks.Size = new System.Drawing.Size(278, 26);
            this.tsmiImportPlaylists_WithTracks.Text = "Also Import All Playlist Tracks";
            this.tsmiImportPlaylists_WithTracks.Click += new System.EventHandler(this.tsmiFollowedPlaylists_Click);
            // 
            // tsmiImportPlaylists_NoTracks
            // 
            this.tsmiImportPlaylists_NoTracks.Name = "tsmiImportPlaylists_NoTracks";
            this.tsmiImportPlaylists_NoTracks.Size = new System.Drawing.Size(278, 26);
            this.tsmiImportPlaylists_NoTracks.Text = "Just Import Playlist Info";
            this.tsmiImportPlaylists_NoTracks.Click += new System.EventHandler(this.tsmiFollowedPlaylists_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.msiImportAll_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem1,
            this.themeToolStripMenuItem});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.profileToolStripMenuItem.Text = "Settings";
            // 
            // profileToolStripMenuItem1
            // 
            this.profileToolStripMenuItem1.Name = "profileToolStripMenuItem1";
            this.profileToolStripMenuItem1.Size = new System.Drawing.Size(129, 26);
            this.profileToolStripMenuItem1.Text = "Profile";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.logOutToolStripMenuItem.Text = "Log Out";
            // 
            // pBoxProfilePic
            // 
            this.pBoxProfilePic.Location = new System.Drawing.Point(15, 51);
            this.pBoxProfilePic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pBoxProfilePic.Name = "pBoxProfilePic";
            this.pBoxProfilePic.Size = new System.Drawing.Size(132, 128);
            this.pBoxProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxProfilePic.TabIndex = 27;
            this.pBoxProfilePic.TabStop = false;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // SongModule
            // 
            this.SongModule.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SongModule.IsPlaying = false;
            this.SongModule.Location = new System.Drawing.Point(206, 574);
            this.SongModule.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.SongModule.MaximumSize = new System.Drawing.Size(121, 53);
            this.SongModule.Name = "SongModule";
            this.SongModule.Size = new System.Drawing.Size(115, 52);
            this.SongModule.SpotifyEntity = null;
            this.SongModule.SpotifyEntityType = SpotifyAPI.Web.Enums.SpotifyEntityType.None;
            this.SongModule.TabIndex = 29;
            this.SongModule.Track = null;
            // 
            // SForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(527, 641);
            this.Controls.Add(this.SongModule);
            this.Controls.Add(this.pBoxProfilePic);
            this.Controls.Add(mainMenuStrip);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SForm";
            this.Text = "SongsAbout";
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox pBoxProfilePic;
        protected System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem bulkAddToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem genresToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem tagsToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem playlistsToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem viewDatabaseToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem spotifyToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem savedTracksToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem followedArtistsToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem tsmiImportPlaylists;
        protected System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem1;
        protected System.Windows.Forms.ToolStripMenuItem addNewTrackToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        protected Controls.SongModule SongModule;
        protected System.Windows.Forms.ToolStripMenuItem tsmiImportPlaylists_WithTracks;
        protected System.Windows.Forms.ToolStripMenuItem tsmiImportPlaylists_NoTracks;
    }
}

