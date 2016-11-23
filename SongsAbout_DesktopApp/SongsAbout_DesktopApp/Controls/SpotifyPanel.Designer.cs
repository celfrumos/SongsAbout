﻿using System.Drawing;

namespace SongsAbout.Controls
{
    partial class SpotifyPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpotifyPanel));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.SpotifyPictureBox = new SongsAbout.Controls.SpotifyPictureBox();
            this.SpotifyLabel = new SongsAbout.Controls.SpotifyLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpotifyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AccessibleName = "PboxPanel";
            this.splitContainer.Panel1.Controls.Add(this.SpotifyPictureBox);
            this.splitContainer.Panel1.ForeColor = System.Drawing.Color.White;
            this.splitContainer.Panel1MinSize = 20;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AccessibleName = "LabelPanel";
            this.splitContainer.Panel2.Controls.Add(this.SpotifyLabel);
            this.splitContainer.Size = new System.Drawing.Size(170, 40);
            this.splitContainer.SplitterDistance = 41;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // SpotifyPictureBox
            // 
            this.SpotifyPictureBox.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SpotifyPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpotifyPictureBox.DbEntity = null;
            this.SpotifyPictureBox.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.SpotifyPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpotifyPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SpotifyPictureBox.Image")));
            this.SpotifyPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("SpotifyPictureBox.InitialImage")));
            this.SpotifyPictureBox.Level = "";
            this.SpotifyPictureBox.Location = new System.Drawing.Point(0, 0);
            this.SpotifyPictureBox.Name = "SpotifyPictureBox";
            this.SpotifyPictureBox.Size = new System.Drawing.Size(41, 40);
            this.SpotifyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SpotifyPictureBox.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.SpotifyPictureBox.TabIndex = 0;
            this.SpotifyPictureBox.TabStop = false;
            // 
            // SpotifyLabel
            // 
            this.SpotifyLabel.AutoEllipsis = true;
            this.SpotifyLabel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SpotifyLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpotifyLabel.DbEntity = null;
            this.SpotifyLabel.DbEntityType = SongsAbout.Enums.DbEntityType.Artist;
            this.SpotifyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpotifyLabel.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.SpotifyLabel.ForeColor = System.Drawing.Color.White;
            this.SpotifyLabel.Level = "";
            this.SpotifyLabel.Location = new System.Drawing.Point(0, 0);
            this.SpotifyLabel.MinimumSize = new System.Drawing.Size(87, 19);
            this.SpotifyLabel.Name = "SpotifyLabel";
            this.SpotifyLabel.Size = this.SpotifyLabel.MinimumSize;
            this.SpotifyLabel.SpotifyEntityType = SongsAbout.Enums.SpotifyEntityType.FullArtist;
            this.SpotifyLabel.TabIndex = 0;
            this.SpotifyLabel.Text = "SpotifyLabel";
            this.SpotifyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpotifyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.splitContainer);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(110, 40);
            this.Name = "SpotifyPanel";
            this.Size = new System.Drawing.Size(170, 40);
            this.Tag = "Not Set";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpotifyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
   
        protected System.Windows.Forms.SplitContainer splitContainer = new System.Windows.Forms.SplitContainer();
        public SpotifyPictureBox SpotifyPictureBox = new SpotifyPictureBox();
        public SpotifyLabel SpotifyLabel = new SpotifyLabel();
    }
}
