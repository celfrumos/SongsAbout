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
            this.flpSpotifyControls = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxProfilePic
            // 
            this.pBoxProfilePic.Location = new System.Drawing.Point(12, 39);
            this.pBoxProfilePic.Size = new System.Drawing.Size(43, 44);
            // 
            // flpSpotifyControls
            // 
            this.flpSpotifyControls.AllowDrop = true;
            this.flpSpotifyControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpSpotifyControls.AutoScroll = true;
            this.flpSpotifyControls.Location = new System.Drawing.Point(12, 89);
            this.flpSpotifyControls.Name = "flpSpotifyControls";
            this.flpSpotifyControls.Size = new System.Drawing.Size(941, 580);
            this.flpSpotifyControls.TabIndex = 0;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSearch.Location = new System.Drawing.Point(683, 40);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(169, 25);
            this.txtBoxSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(867, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SpotifySearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(965, 682);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.flpSpotifyControls);
            this.Name = "SpotifySearchForm";
            this.Text = "Import From Spotify";
            this.Controls.SetChildIndex(this.flpSpotifyControls, 0);
            this.Controls.SetChildIndex(this.txtBoxSearch, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.pBoxProfilePic, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSpotifyControls = new System.Windows.Forms.FlowLayoutPanel();
        private System.Windows.Forms.TextBox txtBoxSearch = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Button btnSearch = new System.Windows.Forms.Button();
    }
}