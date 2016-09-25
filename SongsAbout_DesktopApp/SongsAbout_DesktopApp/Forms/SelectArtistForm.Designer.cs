namespace SongsAbout_DesktopApp
{
    partial class SelectArtistForm
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
            this.lstBoxSelectArtist = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewArtist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBoxSelectArtist
            // 
            this.lstBoxSelectArtist.FormattingEnabled = true;
            this.lstBoxSelectArtist.ItemHeight = 16;
            this.lstBoxSelectArtist.Location = new System.Drawing.Point(11, 14);
            this.lstBoxSelectArtist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBoxSelectArtist.Name = "lstBoxSelectArtist";
            this.lstBoxSelectArtist.Size = new System.Drawing.Size(351, 132);
            this.lstBoxSelectArtist.TabIndex = 0;
            this.lstBoxSelectArtist.SelectedIndexChanged += new System.EventHandler(this.lstBoxSelectArtist_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(11, 154);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(371, 154);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewArtist
            // 
            this.btnNewArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewArtist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewArtist.Location = new System.Drawing.Point(371, 15);
            this.btnNewArtist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewArtist.Name = "btnNewArtist";
            this.btnNewArtist.Size = new System.Drawing.Size(100, 126);
            this.btnNewArtist.TabIndex = 40;
            this.btnNewArtist.Text = "New Artist";
            this.btnNewArtist.UseVisualStyleBackColor = true;
            this.btnNewArtist.Click += new System.EventHandler(this.btnNewArtist_Click);
            // 
            // SelectArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(481, 196);
            this.Controls.Add(this.btnNewArtist);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstBoxSelectArtist);
            this.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectArtistForm";
            this.Text = "Select Artist";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxSelectArtist;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewArtist;
    }
}