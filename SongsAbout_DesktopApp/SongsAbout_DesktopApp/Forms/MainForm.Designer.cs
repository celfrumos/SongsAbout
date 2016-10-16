using SongsAbout_DesktopApp.Properties;
namespace SongsAbout_DesktopApp
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
            this.btnSavedLists = new System.Windows.Forms.Button();
            this.btnAddInfo = new System.Windows.Forms.Button();
            this.btnViewData = new System.Windows.Forms.Button();
            this.btnSpotify = new System.Windows.Forms.Button();
            this.pBoxProfilePic = new System.Windows.Forms.PictureBox();
            this.btnImportPlaylistArtists = new System.Windows.Forms.Button();
            this.btnImportSavedTracks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(183, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 188);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtBoxQuery
            // 
            this.txtBoxQuery.Location = new System.Drawing.Point(295, 256);
            this.txtBoxQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxQuery.Name = "txtBoxQuery";
            this.txtBoxQuery.Size = new System.Drawing.Size(216, 25);
            this.txtBoxQuery.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = User.Default.ParagraphFont;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(36, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "I want to find songs about:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = User.Default.ParagraphFont;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(73, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "In any of these genres:";
            // 
            // lstBxGenres
            // 
            this.lstBxGenres.FormattingEnabled = true;
            this.lstBxGenres.ItemHeight = 18;
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
            this.lstBxGenres.Size = new System.Drawing.Size(216, 76);
            this.lstBxGenres.Sorted = true;
            this.lstBxGenres.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = User.Default.ParagraphFont;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(170, 461);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Keywords:";
            // 
            // txtBoxKeywords
            // 
            this.txtBoxKeywords.Location = new System.Drawing.Point(295, 461);
            this.txtBoxKeywords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxKeywords.Name = "txtBoxKeywords";
            this.txtBoxKeywords.Size = new System.Drawing.Size(216, 25);
            this.txtBoxKeywords.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = User.Default.ParagraphFont;
            this.btnSearch.Location = new System.Drawing.Point(295, 504);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(216, 112);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Find me some songs!";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSavedLists
            // 
            this.btnSavedLists.Font = User.Default.ParagraphFont;
            this.btnSavedLists.Location = new System.Drawing.Point(40, 560);
            this.btnSavedLists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSavedLists.Name = "btnSavedLists";
            this.btnSavedLists.Size = new System.Drawing.Size(193, 54);
            this.btnSavedLists.TabIndex = 12;
            this.btnSavedLists.Text = "Import Playlists";
            this.btnSavedLists.UseVisualStyleBackColor = true;
            this.btnSavedLists.Click += new System.EventHandler(this.btnSavedLists_Click);
            // 
            // btnAddInfo
            // 
            this.btnAddInfo.Font = User.Default.ParagraphFont;
            this.btnAddInfo.Location = new System.Drawing.Point(40, 502);
            this.btnAddInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddInfo.Name = "btnAddInfo";
            this.btnAddInfo.Size = new System.Drawing.Size(193, 54);
            this.btnAddInfo.TabIndex = 13;
            this.btnAddInfo.Text = "Add New Track";
            this.btnAddInfo.UseVisualStyleBackColor = true;
            this.btnAddInfo.Click += new System.EventHandler(this.btnAddTrack_Click);
            // 
            // btnViewData
            // 
            this.btnViewData.Location = new System.Drawing.Point(77, 367);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(130, 31);
            this.btnViewData.TabIndex = 14;
            this.btnViewData.Text = "View Data";
            this.btnViewData.UseVisualStyleBackColor = true;
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);
            // 
            // btnSpotify
            // 
            this.btnSpotify.Location = new System.Drawing.Point(25, 420);
            this.btnSpotify.Name = "btnSpotify";
            this.btnSpotify.Size = new System.Drawing.Size(93, 53);
            this.btnSpotify.TabIndex = 15;
            this.btnSpotify.Text = "Connect Spotify";
            this.btnSpotify.UseVisualStyleBackColor = true;
            // 
            // pBoxProfilePic
            // 
            this.pBoxProfilePic.Location = new System.Drawing.Point(12, 11);
            this.pBoxProfilePic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBoxProfilePic.Name = "pBoxProfilePic";
            this.pBoxProfilePic.Size = new System.Drawing.Size(65, 64);
            this.pBoxProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxProfilePic.TabIndex = 16;
            this.pBoxProfilePic.TabStop = false;
            // 
            // btnImportPlaylistArtists
            // 
            this.btnImportPlaylistArtists.Location = new System.Drawing.Point(149, 420);
            this.btnImportPlaylistArtists.Name = "btnImportPlaylistArtists";
            this.btnImportPlaylistArtists.Size = new System.Drawing.Size(147, 36);
            this.btnImportPlaylistArtists.TabIndex = 17;
            this.btnImportPlaylistArtists.Text = "Import AllSpotify";
            this.btnImportPlaylistArtists.UseVisualStyleBackColor = true;
            this.btnImportPlaylistArtists.Click += new System.EventHandler(this.btnImportArtists_Click);
            // 
            // btnImportSavedTracks
            // 
            this.btnImportSavedTracks.Location = new System.Drawing.Point(361, 409);
            this.btnImportSavedTracks.Name = "btnImportSavedTracks";
            this.btnImportSavedTracks.Size = new System.Drawing.Size(150, 30);
            this.btnImportSavedTracks.TabIndex = 17;
            this.btnImportSavedTracks.Text = "Import Saved Tracks";
            this.btnImportSavedTracks.UseVisualStyleBackColor = true;
            this.btnImportSavedTracks.Click += new System.EventHandler(this.btnImportSavedTracks_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = User.Default.BackColor;
            this.ClientSize = new System.Drawing.Size(547, 625);
            this.Controls.Add(this.btnImportSavedTracks);
            this.Controls.Add(this.btnImportPlaylistArtists);
            this.Controls.Add(this.pBoxProfilePic);
            this.Controls.Add(this.btnSpotify);
            this.Controls.Add(this.btnViewData);
            this.Controls.Add(this.btnAddInfo);
            this.Controls.Add(this.btnSavedLists);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxKeywords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstBxGenres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxQuery);
            this.Controls.Add(this.pictureBox1);
            this.Font = User.Default.ParagraphFont;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "SongsAbout";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
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
        private System.Windows.Forms.Button btnSavedLists;
        private System.Windows.Forms.Button btnAddInfo;
        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.Button btnSpotify;
        private System.Windows.Forms.PictureBox pBoxProfilePic;
        private System.Windows.Forms.Button btnImportPlaylistArtists;
        private System.Windows.Forms.Button btnImportSavedTracks;
    }
}

