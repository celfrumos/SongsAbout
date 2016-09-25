namespace SongsAbout_DesktopApp
{
    partial class SelectAlbumForm
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
            this.btnGetArtist = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxSelectedArtist = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lstBoxSelectAlbum = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewAlbum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetArtist
            // 
            this.btnGetArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetArtist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGetArtist.Location = new System.Drawing.Point(273, 9);
            this.btnGetArtist.Name = "btnGetArtist";
            this.btnGetArtist.Size = new System.Drawing.Size(75, 23);
            this.btnGetArtist.TabIndex = 36;
            this.btnGetArtist.Text = "Get Artist";
            this.btnGetArtist.UseVisualStyleBackColor = true;
            this.btnGetArtist.Click += new System.EventHandler(this.btnGetArtist_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "Filter by Artist:";
            // 
            // txtBoxSelectedArtist
            // 
            this.txtBoxSelectedArtist.Location = new System.Drawing.Point(132, 10);
            this.txtBoxSelectedArtist.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxSelectedArtist.Name = "txtBoxSelectedArtist";
            this.txtBoxSelectedArtist.Size = new System.Drawing.Size(136, 20);
            this.txtBoxSelectedArtist.TabIndex = 35;
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(15, 194);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lstBoxSelectAlbum
            // 
            this.lstBoxSelectAlbum.FormattingEnabled = true;
            this.lstBoxSelectAlbum.Location = new System.Drawing.Point(15, 41);
            this.lstBoxSelectAlbum.Name = "lstBoxSelectAlbum";
            this.lstBoxSelectAlbum.Size = new System.Drawing.Size(253, 147);
            this.lstBoxSelectAlbum.TabIndex = 37;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(273, 193);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewAlbum
            // 
            this.btnNewAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAlbum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewAlbum.Location = new System.Drawing.Point(274, 41);
            this.btnNewAlbum.Name = "btnNewAlbum";
            this.btnNewAlbum.Size = new System.Drawing.Size(75, 147);
            this.btnNewAlbum.TabIndex = 39;
            this.btnNewAlbum.Text = "New Album";
            this.btnNewAlbum.UseVisualStyleBackColor = true;
            this.btnNewAlbum.Click += new System.EventHandler(this.btnNewAlbum_Click);
            // 
            // SelectAlbumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(359, 227);
            this.Controls.Add(this.btnNewAlbum);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstBoxSelectAlbum);
            this.Controls.Add(this.btnGetArtist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxSelectedArtist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectAlbumForm";
            this.Text = "Select Album";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetArtist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxSelectedArtist;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lstBoxSelectAlbum;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewAlbum;
    }
}