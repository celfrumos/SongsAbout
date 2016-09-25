namespace SongsAbout_DesktopApp
{
    partial class AddAlbumForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxYear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxMainArtist = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelectArtist = new System.Windows.Forms.Button();
            this.picBoxProfilePic = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(199, 322);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 28);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOpenFile.Location = new System.Drawing.Point(20, 52);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(100, 28);
            this.btnOpenFile.TabIndex = 28;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(15, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 23);
            this.label6.TabIndex = 26;
            this.label6.Text = "Cover Art";
            // 
            // txtBoxYear
            // 
            this.txtBoxYear.Location = new System.Drawing.Point(140, 284);
            this.txtBoxYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxYear.Name = "txtBoxYear";
            this.txtBoxYear.Size = new System.Drawing.Size(216, 22);
            this.txtBoxYear.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(15, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "Year";
            // 
            // txtBoxMainArtist
            // 
            this.txtBoxMainArtist.Location = new System.Drawing.Point(140, 222);
            this.txtBoxMainArtist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxMainArtist.Name = "txtBoxMainArtist";
            this.txtBoxMainArtist.ReadOnly = true;
            this.txtBoxMainArtist.Size = new System.Drawing.Size(216, 22);
            this.txtBoxMainArtist.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(15, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Main Artist";
            // 
            // txtBoxTitle
            // 
            this.txtBoxTitle.Location = new System.Drawing.Point(140, 192);
            this.txtBoxTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxTitle.Name = "txtBoxTitle";
            this.txtBoxTitle.Size = new System.Drawing.Size(216, 22);
            this.txtBoxTitle.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(15, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Title";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Location = new System.Drawing.Point(48, 322);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 28);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelectArtist
            // 
            this.btnSelectArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectArtist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectArtist.Location = new System.Drawing.Point(198, 250);
            this.btnSelectArtist.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectArtist.Name = "btnSelectArtist";
            this.btnSelectArtist.Size = new System.Drawing.Size(100, 28);
            this.btnSelectArtist.TabIndex = 28;
            this.btnSelectArtist.Text = "Select Artist";
            this.btnSelectArtist.UseVisualStyleBackColor = true;
            this.btnSelectArtist.Click += new System.EventHandler(this.btnSelectArtist_Click);
            // 
            // picBoxProfilePic
            // 
            this.picBoxProfilePic.Location = new System.Drawing.Point(140, 15);
            this.picBoxProfilePic.Margin = new System.Windows.Forms.Padding(4);
            this.picBoxProfilePic.Name = "picBoxProfilePic";
            this.picBoxProfilePic.Size = new System.Drawing.Size(217, 164);
            this.picBoxProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxProfilePic.TabIndex = 33;
            this.picBoxProfilePic.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // AddAlbumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(377, 364);
            this.Controls.Add(this.picBoxProfilePic);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectArtist);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxYear);
            this.Controls.Add(this.txtBoxMainArtist);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAlbumForm";
            this.Text = "AddAlbumForm";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxMainArtist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectArtist;
        private System.Windows.Forms.PictureBox picBoxProfilePic;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}