namespace SongsAbout_DesktopApp
{
    partial class AddTrackForm
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
            this.lstBxGenres = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxLength = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSelectArtist = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxMainArtist = new System.Windows.Forms.TextBox();
            this.btnSelectAlbum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxAlbum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstBxGenres
            // 
            this.lstBxGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBxGenres.FormattingEnabled = true;
            this.lstBxGenres.ItemHeight = 17;
            this.lstBxGenres.Items.AddRange(new object[] {
            "Acoustic",
            "Country",
            "Electronic",
            "Folk",
            "Opera",
            "Pop",
            "Rap",
            "Rock"});
            this.lstBxGenres.Location = new System.Drawing.Point(467, 10);
            this.lstBxGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstBxGenres.Name = "lstBxGenres";
            this.lstBxGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBxGenres.Size = new System.Drawing.Size(292, 72);
            this.lstBxGenres.Sorted = true;
            this.lstBxGenres.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(363, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "Genre(s)";
            // 
            // txtBoxLength
            // 
            this.txtBoxLength.Location = new System.Drawing.Point(140, 41);
            this.txtBoxLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxLength.Name = "txtBoxLength";
            this.txtBoxLength.Size = new System.Drawing.Size(216, 22);
            this.txtBoxLength.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(15, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 23);
            this.label11.TabIndex = 26;
            this.label11.Text = "Length";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(140, 11);
            this.txtBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(216, 22);
            this.txtBoxName.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(15, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 23);
            this.label14.TabIndex = 26;
            this.label14.Text = "Name";
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClose.Location = new System.Drawing.Point(467, 162);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(293, 32);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(467, 103);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(293, 50);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSelectArtist
            // 
            this.btnSelectArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectArtist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectArtist.Location = new System.Drawing.Point(140, 102);
            this.btnSelectArtist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectArtist.Name = "btnSelectArtist";
            this.btnSelectArtist.Size = new System.Drawing.Size(216, 28);
            this.btnSelectArtist.TabIndex = 33;
            this.btnSelectArtist.Text = "Select Artist";
            this.btnSelectArtist.UseVisualStyleBackColor = true;
            this.btnSelectArtist.Click += new System.EventHandler(this.btnSelectArtist_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(15, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Main Artist";
            // 
            // txtBoxMainArtist
            // 
            this.txtBoxMainArtist.Location = new System.Drawing.Point(140, 70);
            this.txtBoxMainArtist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxMainArtist.Name = "txtBoxMainArtist";
            this.txtBoxMainArtist.ReadOnly = true;
            this.txtBoxMainArtist.Size = new System.Drawing.Size(216, 22);
            this.txtBoxMainArtist.TabIndex = 32;
            // 
            // btnSelectAlbum
            // 
            this.btnSelectAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAlbum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectAlbum.Location = new System.Drawing.Point(140, 166);
            this.btnSelectAlbum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectAlbum.Name = "btnSelectAlbum";
            this.btnSelectAlbum.Size = new System.Drawing.Size(216, 28);
            this.btnSelectAlbum.TabIndex = 37;
            this.btnSelectAlbum.Text = "Select Album";
            this.btnSelectAlbum.UseVisualStyleBackColor = true;
            this.btnSelectAlbum.Click += new System.EventHandler(this.btnSelectAlbum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(15, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "Album";
            // 
            // txtBoxAlbum
            // 
            this.txtBoxAlbum.Location = new System.Drawing.Point(140, 135);
            this.txtBoxAlbum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxAlbum.Name = "txtBoxAlbum";
            this.txtBoxAlbum.ReadOnly = true;
            this.txtBoxAlbum.Size = new System.Drawing.Size(216, 22);
            this.txtBoxAlbum.TabIndex = 36;
            // 
            // AddTrackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(772, 204);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelectAlbum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtBoxAlbum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstBxGenres);
            this.Controls.Add(this.btnSelectArtist);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBoxMainArtist);
            this.Controls.Add(this.txtBoxLength);
            this.Controls.Add(this.btnSave);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTrackForm";
            this.Text = "Add New Track";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstBxGenres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxLength;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSelectAlbum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxAlbum;
        private System.Windows.Forms.Button btnSelectArtist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxMainArtist;
    }
}