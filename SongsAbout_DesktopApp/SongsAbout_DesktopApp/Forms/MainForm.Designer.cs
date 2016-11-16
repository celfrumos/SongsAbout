using SongsAbout.Properties;
namespace SongsAbout.Forms
{
    partial class MainForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBoxQuery = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstBxGenres = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxKeywords = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pBoxProfilePic = new System.Windows.Forms.PictureBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spotifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savedTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followedArtistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followedPlaylistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(183, 48);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 159);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtBoxQuery
            // 
            this.txtBoxQuery.Location = new System.Drawing.Point(295, 256);
            this.txtBoxQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxQuery.Name = "txtBoxQuery";
            this.txtBoxQuery.Size = new System.Drawing.Size(216, 21);
            this.txtBoxQuery.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(36, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "I want to find songs about:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(73, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "In any of these genres:";
            // 
            // lstBxGenres
            // 
            this.lstBxGenres.FormattingEnabled = true;
            this.lstBxGenres.ItemHeight = 14;
            this.lstBxGenres.Items.AddRange(new object[] {
            "Acoustic",
            "Country",
            "Electronic",
            "Folk",
            "Opera",
            "Pop",
            "Rap",
            "Rock"});
            this.lstBxGenres.Location = new System.Drawing.Point(295, 315);
            this.lstBxGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstBxGenres.Name = "lstBxGenres";
            this.lstBxGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBxGenres.Size = new System.Drawing.Size(216, 74);
            this.lstBxGenres.Sorted = true;
            this.lstBxGenres.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(170, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Keywords:";
            // 
            // txtBoxKeywords
            // 
            this.txtBoxKeywords.Location = new System.Drawing.Point(295, 418);
            this.txtBoxKeywords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxKeywords.Name = "txtBoxKeywords";
            this.txtBoxKeywords.Size = new System.Drawing.Size(216, 21);
            this.txtBoxKeywords.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.btnSearch.Location = new System.Drawing.Point(295, 461);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(216, 112);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Find me some songs!";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pBoxProfilePic
            // 
            this.pBoxProfilePic.Location = new System.Drawing.Point(12, 39);
            this.pBoxProfilePic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBoxProfilePic.Name = "pBoxProfilePic";
            this.pBoxProfilePic.Size = new System.Drawing.Size(65, 64);
            this.pBoxProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxProfilePic.TabIndex = 16;
            this.pBoxProfilePic.TabStop = false;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.spotifyToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(547, 24);
            this.mainMenuStrip.TabIndex = 18;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDatabaseToolStripMenuItem,
            this.addNewTrackToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewDatabaseToolStripMenuItem
            // 
            this.viewDatabaseToolStripMenuItem.Name = "viewDatabaseToolStripMenuItem";
            this.viewDatabaseToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.viewDatabaseToolStripMenuItem.Text = "View Database";
            this.viewDatabaseToolStripMenuItem.Click += new System.EventHandler(this.msiViewData_Click);
            // 
            // addNewTrackToolStripMenuItem
            // 
            this.addNewTrackToolStripMenuItem.Name = "addNewTrackToolStripMenuItem";
            this.addNewTrackToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addNewTrackToolStripMenuItem.Text = "Add New Track";
            this.addNewTrackToolStripMenuItem.Click += new System.EventHandler(this.msiAddTrack_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            // 
            // spotifyToolStripMenuItem
            // 
            this.spotifyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.importToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.spotifyToolStripMenuItem.Name = "spotifyToolStripMenuItem";
            this.spotifyToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.spotifyToolStripMenuItem.Text = "Spotify";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.msiConncectSpotify_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savedTracksToolStripMenuItem,
            this.followedArtistsToolStripMenuItem,
            this.followedPlaylistsToolStripMenuItem,
            this.allToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // savedTracksToolStripMenuItem
            // 
            this.savedTracksToolStripMenuItem.Name = "savedTracksToolStripMenuItem";
            this.savedTracksToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.savedTracksToolStripMenuItem.Text = "Saved Tracks";
            this.savedTracksToolStripMenuItem.Click += new System.EventHandler(this.msiImportSavedTracks_Click);
            // 
            // followedArtistsToolStripMenuItem
            // 
            this.followedArtistsToolStripMenuItem.Name = "followedArtistsToolStripMenuItem";
            this.followedArtistsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.followedArtistsToolStripMenuItem.Text = "Followed Artists";
            this.followedArtistsToolStripMenuItem.Click += new System.EventHandler(this.msiImportFollowedArtists_Click);
            // 
            // followedPlaylistsToolStripMenuItem
            // 
            this.followedPlaylistsToolStripMenuItem.Name = "followedPlaylistsToolStripMenuItem";
            this.followedPlaylistsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.followedPlaylistsToolStripMenuItem.Text = "Followed Playlists";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.msiImportAll_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.msiSpotifySearch_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.msiDisconnect_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem1,
            this.themeToolStripMenuItem});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.profileToolStripMenuItem.Text = "Settings";
            // 
            // profileToolStripMenuItem1
            // 
            this.profileToolStripMenuItem1.Name = "profileToolStripMenuItem1";
            this.profileToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.profileToolStripMenuItem1.Text = "Profile";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(547, 625);
            this.Controls.Add(this.pBoxProfilePic);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxKeywords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstBxGenres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxQuery);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "SongsAbout";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBoxQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstBxGenres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxKeywords;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pBoxProfilePic;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spotifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savedTracksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followedArtistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followedPlaylistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
    }
}

