using SongsAbout.Desktop.Properties;
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
            this.flpSpotifyControls = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlSearchType = new System.Windows.Forms.Panel();
            this.cboxPlaylists = new System.Windows.Forms.CheckBox();
            this.cboxTracks = new System.Windows.Forms.CheckBox();
            this.cboxAlbums = new System.Windows.Forms.CheckBox();
            this.cboxArtists = new System.Windows.Forms.CheckBox();
            this.cboxAll = new System.Windows.Forms.CheckBox();
            this.m = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            this.pnlSearchType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBoxProfilePic
            // 
            this.pBoxProfilePic.Location = new System.Drawing.Point(15, 50);
            this.pBoxProfilePic.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pBoxProfilePic.Size = new System.Drawing.Size(54, 56);
            // 
            // flpSpotifyControls
            // 
            this.flpSpotifyControls.AllowDrop = true;
            this.flpSpotifyControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpSpotifyControls.AutoScroll = true;
            this.flpSpotifyControls.Location = new System.Drawing.Point(15, 114);
            this.flpSpotifyControls.Margin = new System.Windows.Forms.Padding(4);
            this.flpSpotifyControls.Name = "flpSpotifyControls";
            this.flpSpotifyControls.Size = new System.Drawing.Size(1176, 741);
            this.flpSpotifyControls.TabIndex = 0;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSearch.Location = new System.Drawing.Point(854, 50);
            this.txtBoxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(210, 30);
            this.txtBoxSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1084, 49);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 33);
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
            this.pnlSearchType.Location = new System.Drawing.Point(145, 50);
            this.pnlSearchType.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSearchType.Name = "pnlSearchType";
            this.pnlSearchType.Size = new System.Drawing.Size(418, 31);
            this.pnlSearchType.TabIndex = 28;
            // 
            // cboxPlaylists
            // 
            this.cboxPlaylists.AutoSize = true;
            this.cboxPlaylists.ForeColor = System.Drawing.Color.White;
            this.cboxPlaylists.Location = new System.Drawing.Point(318, 2);
            this.cboxPlaylists.Margin = new System.Windows.Forms.Padding(2);
            this.cboxPlaylists.Name = "cboxPlaylists";
            this.cboxPlaylists.Size = new System.Drawing.Size(93, 27);
            this.cboxPlaylists.TabIndex = 0;
            this.cboxPlaylists.Text = "Playlists";
            this.cboxPlaylists.UseVisualStyleBackColor = true;
            this.cboxPlaylists.CheckedChanged += new System.EventHandler(this.cbox_SpecificCheckedChanged);
            // 
            // cboxTracks
            // 
            this.cboxTracks.AutoSize = true;
            this.cboxTracks.ForeColor = System.Drawing.Color.White;
            this.cboxTracks.Location = new System.Drawing.Point(212, 2);
            this.cboxTracks.Margin = new System.Windows.Forms.Padding(2);
            this.cboxTracks.Name = "cboxTracks";
            this.cboxTracks.Size = new System.Drawing.Size(84, 27);
            this.cboxTracks.TabIndex = 0;
            this.cboxTracks.Text = "Tracks";
            this.cboxTracks.UseVisualStyleBackColor = true;
            this.cboxTracks.CheckedChanged += new System.EventHandler(this.cbox_SpecificCheckedChanged);
            // 
            // cboxAlbums
            // 
            this.cboxAlbums.AutoSize = true;
            this.cboxAlbums.ForeColor = System.Drawing.Color.White;
            this.cboxAlbums.Location = new System.Drawing.Point(104, 2);
            this.cboxAlbums.Margin = new System.Windows.Forms.Padding(2);
            this.cboxAlbums.Name = "cboxAlbums";
            this.cboxAlbums.Size = new System.Drawing.Size(87, 27);
            this.cboxAlbums.TabIndex = 0;
            this.cboxAlbums.Text = "Albums";
            this.cboxAlbums.UseVisualStyleBackColor = true;
            this.cboxAlbums.CheckedChanged += new System.EventHandler(this.cbox_SpecificCheckedChanged);
            // 
            // cboxArtists
            // 
            this.cboxArtists.AutoSize = true;
            this.cboxArtists.ForeColor = System.Drawing.Color.White;
            this.cboxArtists.Location = new System.Drawing.Point(20, 3);
            this.cboxArtists.Margin = new System.Windows.Forms.Padding(2);
            this.cboxArtists.Name = "cboxArtists";
            this.cboxArtists.Size = new System.Drawing.Size(80, 27);
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
            this.cboxAll.Location = new System.Drawing.Point(98, 52);
            this.cboxAll.Margin = new System.Windows.Forms.Padding(2);
            this.cboxAll.Name = "cboxAll";
            this.cboxAll.Size = new System.Drawing.Size(49, 27);
            this.cboxAll.TabIndex = 0;
            this.cboxAll.Text = "All";
            this.cboxAll.UseVisualStyleBackColor = true;
            this.cboxAll.CheckedChanged += new System.EventHandler(this.cboxAll_CheckedChanged);
            // 
            // m
            // 
            this.m.FormattingEnabled = true;
            this.m.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.m.Location = new System.Drawing.Point(674, 48);
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(69, 31);
            this.m.TabIndex = 29;
            // 
            // SpotifySearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1206, 872);
            this.Controls.Add(this.m);
            this.Controls.Add(this.pnlSearchType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.cboxAll);
            this.Controls.Add(this.flpSpotifyControls);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SpotifySearchForm";
            this.Text = "Import From Spotify";
            this.Controls.SetChildIndex(this.flpSpotifyControls, 0);
            this.Controls.SetChildIndex(this.cboxAll, 0);
            this.Controls.SetChildIndex(this.txtBoxSearch, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.pnlSearchType, 0);
            this.Controls.SetChildIndex(this.m, 0);
            this.Controls.SetChildIndex(this.pBoxProfilePic, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
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
        private System.Windows.Forms.ComboBox m;
    }
}