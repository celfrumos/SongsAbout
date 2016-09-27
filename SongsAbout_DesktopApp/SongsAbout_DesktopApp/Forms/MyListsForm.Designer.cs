﻿namespace SongsAbout_DesktopApp.Forms
{
    partial class MyListsForm
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataSet = new SongsAbout_DesktopApp.DataSet();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableAdapterMgr = new SongsAbout_DesktopApp.DataSetTableAdapters.TableAdapterManager();
            this.albumsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.AlbumsTableAdapter();
            this.artistsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.ArtistsTableAdapter();
            this.gBox = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblArtist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.gBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(210, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 137);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = this.dataSet;
            this.bindingSource.Position = 0;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 166);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(592, 415);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // tableAdapterMgr
            // 
            this.tableAdapterMgr.AlbumsTableAdapter = this.albumsTableAdapter;
            this.tableAdapterMgr.ArtistsTableAdapter = this.artistsTableAdapter;
            this.tableAdapterMgr.BackupDataSetBeforeUpdate = false;
            this.tableAdapterMgr.GenresTableAdapter = null;
            this.tableAdapterMgr.ListsTableAdapter = null;
            this.tableAdapterMgr.TagsTableAdapter = null;
            this.tableAdapterMgr.TrackGenresTableAdapter = null;
            this.tableAdapterMgr.TracksTableAdapter = null;
            this.tableAdapterMgr.TrackTagsTableAdapter = null;
            this.tableAdapterMgr.UpdateOrder = SongsAbout_DesktopApp.DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // albumsTableAdapter
            // 
            this.albumsTableAdapter.ClearBeforeFill = true;
            // 
            // artistsTableAdapter
            // 
            this.artistsTableAdapter.ClearBeforeFill = true;
            // 
            // gBox
            // 
            this.gBox.Controls.Add(this.pictureBox2);
            this.gBox.Controls.Add(this.lblArtist);
            this.gBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gBox.Location = new System.Drawing.Point(66, 32);
            this.gBox.Name = "gBox";
            this.gBox.Size = new System.Drawing.Size(83, 106);
            this.gBox.TabIndex = 3;
            this.gBox.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(3, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 73);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(17, 85);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(46, 17);
            this.lblArtist.TabIndex = 0;
            this.lblArtist.Text = "label1";
            // 
            // MyListsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(616, 593);
            this.Controls.Add(this.gBox);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MyListsForm";
            this.Text = "MyListsForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.gBox.ResumeLayout(false);
            this.gBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private DataSetTableAdapters.TableAdapterManager tableAdapterMgr;
        private DataSetTableAdapters.AlbumsTableAdapter albumsTableAdapter;
        private DataSetTableAdapters.ArtistsTableAdapter artistsTableAdapter;
        private System.Windows.Forms.GroupBox gBox;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}