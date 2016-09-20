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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lstBoxSelectAlbum = new System.Windows.Forms.ListBox();
            this.btnNewArtist = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(132, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 35;
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(274, 171);
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
            // btnNewArtist
            // 
            this.btnNewArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewArtist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewArtist.Location = new System.Drawing.Point(274, 39);
            this.btnNewArtist.Name = "btnNewArtist";
            this.btnNewArtist.Size = new System.Drawing.Size(75, 23);
            this.btnNewArtist.TabIndex = 36;
            this.btnNewArtist.Text = "New Artist";
            this.btnNewArtist.UseVisualStyleBackColor = true;
            this.btnNewArtist.Click += new System.EventHandler(this.btnNewArtist_Click);
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(274, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 95);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SelectAlbumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(359, 201);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstBoxSelectAlbum);
            this.Controls.Add(this.btnNewArtist);
            this.Controls.Add(this.btnGetArtist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lstBoxSelectAlbum;
        private System.Windows.Forms.Button btnNewArtist;
        private System.Windows.Forms.Button btnSave;
    }
}