namespace SongsAbout.Desktop.Forms
{
    partial class Form1
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBoxKeywords = new System.Windows.Forms.TextBox();
            this.lblTitleKeywords = new System.Windows.Forms.Label();
            this.lstBxGenres = new System.Windows.Forms.ListBox();
            this.lblTitleGenres = new System.Windows.Forms.Label();
            this.lblTitleTopic = new System.Windows.Forms.Label();
            this.txtBoxQuery = new System.Windows.Forms.TextBox();
            this.songModule1 = new SongsAbout.Controls.SongModule();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxProfilePic
            // 
            this.pBoxProfilePic.Location = new System.Drawing.Point(13, 45);
            this.pBoxProfilePic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBoxProfilePic.Size = new System.Drawing.Size(99, 100);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.btnSearch.Location = new System.Drawing.Point(360, 591);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(216, 38);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Find me some songs!";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBoxKeywords
            // 
            this.txtBoxKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxKeywords.Location = new System.Drawing.Point(360, 553);
            this.txtBoxKeywords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxKeywords.Name = "txtBoxKeywords";
            this.txtBoxKeywords.Size = new System.Drawing.Size(216, 25);
            this.txtBoxKeywords.TabIndex = 33;
            // 
            // lblTitleKeywords
            // 
            this.lblTitleKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleKeywords.AutoSize = true;
            this.lblTitleKeywords.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleKeywords.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.lblTitleKeywords.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitleKeywords.Location = new System.Drawing.Point(231, 553);
            this.lblTitleKeywords.Name = "lblTitleKeywords";
            this.lblTitleKeywords.Size = new System.Drawing.Size(75, 19);
            this.lblTitleKeywords.TabIndex = 32;
            this.lblTitleKeywords.Text = "Keywords:";
            // 
            // lstBxGenres
            // 
            this.lstBxGenres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBxGenres.FormattingEnabled = true;
            this.lstBxGenres.ItemHeight = 18;
            this.lstBxGenres.Location = new System.Drawing.Point(360, 90);
            this.lstBxGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstBxGenres.Name = "lstBxGenres";
            this.lstBxGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBxGenres.Size = new System.Drawing.Size(216, 418);
            this.lstBxGenres.Sorted = true;
            this.lstBxGenres.TabIndex = 31;
            // 
            // lblTitleGenres
            // 
            this.lblTitleGenres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleGenres.AutoSize = true;
            this.lblTitleGenres.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleGenres.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.lblTitleGenres.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitleGenres.Location = new System.Drawing.Point(152, 90);
            this.lblTitleGenres.Name = "lblTitleGenres";
            this.lblTitleGenres.Size = new System.Drawing.Size(154, 19);
            this.lblTitleGenres.TabIndex = 30;
            this.lblTitleGenres.Text = "In any of these genres:";
            // 
            // lblTitleTopic
            // 
            this.lblTitleTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleTopic.AutoSize = true;
            this.lblTitleTopic.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleTopic.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F);
            this.lblTitleTopic.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitleTopic.Location = new System.Drawing.Point(131, 51);
            this.lblTitleTopic.Name = "lblTitleTopic";
            this.lblTitleTopic.Size = new System.Drawing.Size(175, 19);
            this.lblTitleTopic.TabIndex = 29;
            this.lblTitleTopic.Text = "I want to find songs about:";
            // 
            // txtBoxQuery
            // 
            this.txtBoxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxQuery.Location = new System.Drawing.Point(360, 51);
            this.txtBoxQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxQuery.Name = "txtBoxQuery";
            this.txtBoxQuery.Size = new System.Drawing.Size(216, 25);
            this.txtBoxQuery.TabIndex = 28;
            // 
            // songModule1
            // 
            this.songModule1.Location = new System.Drawing.Point(641, 332);
            this.songModule1.Name = "songModule1";
            this.songModule1.Size = new System.Drawing.Size(216, 140);
            this.songModule1.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(1035, 645);
            this.Controls.Add(this.songModule1);
            this.Controls.Add(this.txtBoxKeywords);
            this.Controls.Add(this.lblTitleKeywords);
            this.Controls.Add(this.lstBxGenres);
            this.Controls.Add(this.lblTitleGenres);
            this.Controls.Add(this.lblTitleTopic);
            this.Controls.Add(this.txtBoxQuery);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.pBoxProfilePic, 0);
            this.Controls.SetChildIndex(this.txtBoxQuery, 0);
            this.Controls.SetChildIndex(this.lblTitleTopic, 0);
            this.Controls.SetChildIndex(this.lblTitleGenres, 0);
            this.Controls.SetChildIndex(this.lstBxGenres, 0);
            this.Controls.SetChildIndex(this.lblTitleKeywords, 0);
            this.Controls.SetChildIndex(this.txtBoxKeywords, 0);
            this.Controls.SetChildIndex(this.songModule1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBoxKeywords;
        private System.Windows.Forms.Label lblTitleKeywords;
        private System.Windows.Forms.ListBox lstBxGenres;
        private System.Windows.Forms.Label lblTitleGenres;
        private System.Windows.Forms.Label lblTitleTopic;
        private System.Windows.Forms.TextBox txtBoxQuery;
        private Controls.SongModule songModule1;
    }
}
