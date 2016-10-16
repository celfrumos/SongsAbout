using SongsAbout_DesktopApp.Properties;
namespace SongsAbout_DesktopApp.Forms
{
    partial class ViewSpotifyForm
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
            SongsAbout_DesktopApp.Properties.User user1 = new SongsAbout_DesktopApp.Properties.User();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(405, 584);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ImportPlaylistsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            user1.BackColor = System.Drawing.SystemColors.HotTrack;
            user1.FeaturedPlaylists = null;
            user1.FollowedArtists = null;
            user1.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 10.2F);
            user1.Highlight = System.Drawing.SystemColors.Highlight;
            user1.ParagraphFont = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            user1.PrivateProfile = null;
            user1.ProfilePic = null;
            user1.PublicProfile = null;
            user1.SettingsKey = "";
            user1.SpotifyWebAPI = null;
            user1.TextColor = System.Drawing.Color.White;
            user1.UserId = "";
            this.BackColor = user1.BackColor;
            this.ClientSize = new System.Drawing.Size(429, 608);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ImportPlaylistsForm";
            this.Text = "ImportPlaylistsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}