﻿using System.Drawing;

namespace SongsAbout.Controls
{
    partial class SPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPanel));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pBoxCheckMark = new System.Windows.Forms.PictureBox();
            this.SPictureBox = new SongsAbout.Controls.SPicturePox();
            this.SLabel = new SongsAbout.Controls.SLabel();
            this.sPanelMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGenresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCheckMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPictureBox)).BeginInit();
            this.sPanelMenuStrip.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.pBoxCheckMark);
            this.splitContainer.Panel1.Controls.Add(this.SPictureBox);
            this.splitContainer.Panel1.ForeColor = System.Drawing.Color.White;
            this.splitContainer.Panel1MinSize = 20;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AccessibleName = "LabelPanel";
            this.splitContainer.Panel2.Controls.Add(this.SLabel);
            this.splitContainer.Size = new System.Drawing.Size(175, 50);
            this.splitContainer.SplitterDistance = 51;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // pBoxCheckMark
            // 
            this.pBoxCheckMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBoxCheckMark.BackColor = System.Drawing.Color.Transparent;
            this.pBoxCheckMark.Image = global::SongsAbout.Properties.Resources.CheckMarkBlue;
            this.pBoxCheckMark.Location = new System.Drawing.Point(0, 32);
            this.pBoxCheckMark.Name = "pBoxCheckMark";
            this.pBoxCheckMark.Size = new System.Drawing.Size(20, 20);
            this.pBoxCheckMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxCheckMark.TabIndex = 1;
            this.pBoxCheckMark.TabStop = false;
            this.pBoxCheckMark.Visible = false;
            // 
            // SPictureBox
            // 
            this.SPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.SPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SPictureBox.DbEntity = null;
            this.SPictureBox.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.SPictureBox.Dock = System.Windows.Forms.DockStyle.None;
            this.SPictureBox.Image = global::SongsAbout.Properties.Resources.MusicNote;
            this.SPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("SPictureBox.InitialImage")));
            this.SPictureBox.Location = new System.Drawing.Point(0, 0);
            this.SPictureBox.Name = "SPictureBox";
            this.SPictureBox.Size = new System.Drawing.Size(51, 50);
            this.SPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SPictureBox.SpotifyEntity = null;
            this.SPictureBox.SpotifyEntityType = SpotifyAPI.Web.Enums.SpotifyEntityType.FullArtist;
            this.SPictureBox.TabIndex = 0;
            this.SPictureBox.TabStop = false;
            // 
            // SLabel
            // 
            this.SLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.SLabel.AutoEllipsis = true;
            this.SLabel.BackColor = System.Drawing.Color.Transparent;
            this.SLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SLabel.DbEntity = null;
            this.SLabel.DbEntityType = SongsAbout.Enums.DbEntityType.None;
            this.SLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SLabel.Font = new System.Drawing.Font("Arial Unicode MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SLabel.ForeColor = System.Drawing.Color.White;
            this.SLabel.Location = new System.Drawing.Point(0, 0);
            this.SLabel.MinimumSize = new System.Drawing.Size(87, 19);
            this.SLabel.Name = "SLabel";
            this.SLabel.Size = this.SLabel.MinimumSize;
            this.SLabel.SpotifyEntity = null;
            this.SLabel.SpotifyEntityType = SpotifyAPI.Web.Enums.SpotifyEntityType.FullArtist;
            this.SLabel.TabIndex = 0;
            this.SLabel.Text = "SpotifyLabel";
            this.SLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SLabel.Click += new System.EventHandler(this.SpotifyLabel_Click);
            // 
            // sPanelMenuStrip
            // 
            this.sPanelMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sPanelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.setGenresToolStripMenuItem,
            this.setTagsToolStripMenuItem,
            this.addToListToolStripMenuItem});
            this.sPanelMenuStrip.Name = "contextMenuStrip1";
            this.sPanelMenuStrip.Size = new System.Drawing.Size(159, 108);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.ctsmi_Import);
            // 
            // setGenresToolStripMenuItem
            // 
            this.setGenresToolStripMenuItem.Name = "setGenresToolStripMenuItem";
            this.setGenresToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.setGenresToolStripMenuItem.Text = "Set Genres";
            this.setGenresToolStripMenuItem.Click += new System.EventHandler(this.ctsmi_SetGenres);
            // 
            // setTagsToolStripMenuItem
            // 
            this.setTagsToolStripMenuItem.Name = "setTagsToolStripMenuItem";
            this.setTagsToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.setTagsToolStripMenuItem.Text = "Set Tags";
            this.setTagsToolStripMenuItem.Click += new System.EventHandler(this.ctsmi_SetTags);
            // 
            // addToListToolStripMenuItem
            // 
            this.addToListToolStripMenuItem.Name = "addToListToolStripMenuItem";
            this.addToListToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.addToListToolStripMenuItem.Text = "Add To List";
            this.addToListToolStripMenuItem.Click += new System.EventHandler(this.ctsmi_AddToList);
            // 
            // SPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ContextMenuStrip = this.sPanelMenuStrip;
            this.Controls.Add(this.splitContainer);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(110, 40);
            this.Name = "SPanel";
            this.Size = new System.Drawing.Size(175, 50);
            this.Tag = "Not Set";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCheckMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPictureBox)).EndInit();
            this.sPanelMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.SplitContainer splitContainer = new System.Windows.Forms.SplitContainer();
        protected SPicturePox SPictureBox = new SPicturePox();
        protected SLabel SLabel = new SLabel();
        private System.Windows.Forms.ContextMenuStrip sPanelMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGenresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToListToolStripMenuItem;
        private System.Windows.Forms.PictureBox pBoxCheckMark;
    }
}
