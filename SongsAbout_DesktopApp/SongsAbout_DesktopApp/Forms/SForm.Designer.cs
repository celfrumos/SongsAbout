using SongsAbout.Properties;
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
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addNewTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            spotifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            savedTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            followedArtistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            followedPlaylistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            profileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pBoxProfilePic = new System.Windows.Forms.PictureBox();
            mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pBoxProfilePic)).BeginInit();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem,
            spotifyToolStripMenuItem,
            profileToolStripMenuItem,
            aboutToolStripMenuItem});
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            mainMenuStrip.Size = new System.Drawing.Size(681, 30);
            mainMenuStrip.TabIndex = 18;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            viewDatabaseToolStripMenuItem,
            addNewTrackToolStripMenuItem,
            logOutToolStripMenuItem});
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // viewDatabaseToolStripMenuItem
            // 
            viewDatabaseToolStripMenuItem.Name = "viewDatabaseToolStripMenuItem";
            viewDatabaseToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            viewDatabaseToolStripMenuItem.Text = "View Database";
            viewDatabaseToolStripMenuItem.Click += new System.EventHandler(msiViewData_Click);
            // 
            // addNewTrackToolStripMenuItem
            // 
            addNewTrackToolStripMenuItem.Name = "addNewTrackToolStripMenuItem";
            addNewTrackToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            addNewTrackToolStripMenuItem.Text = "Add New Track";
            addNewTrackToolStripMenuItem.Click += new System.EventHandler(msiAddTrack_Click);
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            logOutToolStripMenuItem.Text = "Log Out";
            // 
            // spotifyToolStripMenuItem
            // 
            spotifyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            connectToolStripMenuItem,
            importToolStripMenuItem,
            searchToolStripMenuItem,
            disconnectToolStripMenuItem});
            spotifyToolStripMenuItem.Name = "spotifyToolStripMenuItem";
            spotifyToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            spotifyToolStripMenuItem.Text = "Spotify";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += new System.EventHandler(msiConnectSpotify_Click);
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            savedTracksToolStripMenuItem,
            followedArtistsToolStripMenuItem,
            followedPlaylistsToolStripMenuItem,
            allToolStripMenuItem});
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            importToolStripMenuItem.Text = "Import";
            // 
            // savedTracksToolStripMenuItem
            // 
            savedTracksToolStripMenuItem.Name = "savedTracksToolStripMenuItem";
            savedTracksToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            savedTracksToolStripMenuItem.Text = "Saved Tracks";
            savedTracksToolStripMenuItem.Click += new System.EventHandler(msiImportSavedTracks_Click);
            // 
            // followedArtistsToolStripMenuItem
            // 
            followedArtistsToolStripMenuItem.Name = "followedArtistsToolStripMenuItem";
            followedArtistsToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            followedArtistsToolStripMenuItem.Text = "Followed Artists";
            followedArtistsToolStripMenuItem.Click += new System.EventHandler(msiImportFollowedArtists_Click);
            // 
            // followedPlaylistsToolStripMenuItem
            // 
            followedPlaylistsToolStripMenuItem.Name = "followedPlaylistsToolStripMenuItem";
            followedPlaylistsToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            followedPlaylistsToolStripMenuItem.Text = "Followed Playlists";
            followedPlaylistsToolStripMenuItem.Click += new System.EventHandler(tsmiFollowedPlaylists_Click);
            // 
            // allToolStripMenuItem
            // 
            allToolStripMenuItem.Name = "allToolStripMenuItem";
            allToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            allToolStripMenuItem.Text = "All";
            allToolStripMenuItem.Click += new System.EventHandler(msiImportAll_Click);
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += new System.EventHandler(msiSpotifySearch_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += new System.EventHandler(msiDisconnect_Click);
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            profileToolStripMenuItem1,
            themeToolStripMenuItem});
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            profileToolStripMenuItem.Text = "Settings";
            // 
            // profileToolStripMenuItem1
            // 
            profileToolStripMenuItem1.Name = "profileToolStripMenuItem1";
            profileToolStripMenuItem1.Size = new System.Drawing.Size(129, 26);
            profileToolStripMenuItem1.Text = "Profile";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            aboutToolStripMenuItem.Text = "About";
            // 
            // pBoxProfilePic
            // 
            pBoxProfilePic.Location = new System.Drawing.Point(15, 51);
            pBoxProfilePic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pBoxProfilePic.Name = "pBoxProfilePic";
            pBoxProfilePic.Size = new System.Drawing.Size(132, 128);
            pBoxProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pBoxProfilePic.TabIndex = 27;
            pBoxProfilePic.TabStop = false;
            // 
            // SForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Size = new System.Drawing.Size(681, 323);
            this.Controls.Add(pBoxProfilePic);
            this.Controls.Add(mainMenuStrip);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SForm";
            this.Text = "SongsAbout";
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pBoxProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox pBoxProfilePic;
        protected static System.Windows.Forms.MenuStrip mainMenuStrip;
        protected static System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem viewDatabaseToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem spotifyToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem savedTracksToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem followedArtistsToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem followedPlaylistsToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem1;
        protected static System.Windows.Forms.ToolStripMenuItem addNewTrackToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        protected static System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
    }
}

