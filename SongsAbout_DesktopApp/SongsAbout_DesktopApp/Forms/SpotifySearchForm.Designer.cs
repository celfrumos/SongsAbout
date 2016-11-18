﻿using SongsAbout.Properties;
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
            this.spotPan = new SongsAbout.Controls.SpotifyPanel();
            this.spotifyPanel1 = new SongsAbout.Controls.SpotifyPanel();
            this.flpSpotifyControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpSpotifyControls
            // 
            this.flpSpotifyControls.AllowDrop = true;
            this.flpSpotifyControls.AutoScroll = true;
            this.flpSpotifyControls.Controls.Add(this.spotifyPanel1);
            this.flpSpotifyControls.Location = new System.Drawing.Point(12, 79);
            this.flpSpotifyControls.Name = "flpSpotifyControls";
            this.flpSpotifyControls.Size = new System.Drawing.Size(405, 517);
            this.flpSpotifyControls.TabIndex = 0;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(148, 13);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(169, 22);
            this.txtBoxSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(342, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // spotPan
            // 
            this.spotPan.AutoSize = true;
            this.spotPan.BackColor = System.Drawing.SystemColors.HotTrack;
            this.spotPan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spotPan.DbEntity = null;
            this.spotPan.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.spotPan.ForeColor = System.Drawing.Color.White;
            this.spotPan.Image = global::SongsAbout.Properties.Resources.ProfilePic;
            this.spotPan.Level = "";
            this.spotPan.Location = new System.Drawing.Point(11, 77);
            this.spotPan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spotPan.MaximumSize = new System.Drawing.Size(200, 134);
            this.spotPan.MinimumSize = new System.Drawing.Size(140, 40);
            this.spotPan.Name = "spotPan";
            this.spotPan.PanelType = SongsAbout.Controls.SPanelType.Image;
            this.spotPan.PictureCollapsed = false;
            this.spotPan.Size = new System.Drawing.Size(199, 52);
            this.spotPan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spotPan.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.spotPan.TabIndex = 0;
            this.spotPan.Tag = "";
            // 
            // spotifyPanel1
            // 
            this.spotifyPanel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.spotifyPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spotifyPanel1.DbEntity = null;
            this.spotifyPanel1.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.spotifyPanel1.ForeColor = System.Drawing.Color.White;
            this.spotifyPanel1.Image = ((System.Drawing.Image)(resources.GetObject("spotifyPanel1.Image")));
            this.spotifyPanel1.Level = null;
            this.spotifyPanel1.Location = new System.Drawing.Point(3, 2);
            this.spotifyPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spotifyPanel1.MinimumSize = new System.Drawing.Size(110, 40);
            this.spotifyPanel1.Name = "spotifyPanel1";
            this.spotifyPanel1.PanelType = SongsAbout.Controls.SPanelType.Image;
            this.spotifyPanel1.PictureCollapsed = false;
            this.spotifyPanel1.Size = new System.Drawing.Size(157, 40);
            this.spotifyPanel1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spotifyPanel1.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.spotifyPanel1.TabIndex = 0;
            this.spotifyPanel1.Tag = "Not Set";
            // 
            // SpotifySearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(429, 608);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.flpSpotifyControls);
            this.Name = "SpotifySearchForm";
            this.Text = "Import From Spotify";
            this.flpSpotifyControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSpotifyControls = new System.Windows.Forms.FlowLayoutPanel();
        private SongsAbout.Controls.SpotifyPanel spotPan = new SongsAbout.Controls.SpotifyPanel();
        private System.Windows.Forms.TextBox txtBoxSearch = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Button btnSearch = new System.Windows.Forms.Button();
        private Controls.SpotifyPanel spotifyPanel1;
    }
}