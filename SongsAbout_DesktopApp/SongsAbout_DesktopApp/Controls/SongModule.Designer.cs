namespace SongsAbout.Controls
{
    partial class SongModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongModule));
            this.btnSkipForward = new SongsAbout.Controls.SongButton();
            this.btnSkipBack = new SongsAbout.Controls.SongButton();
            this.btnPlayPause = new SongsAbout.Controls.SongButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSkipForward
            // 
            this.btnSkipForward.BackColor = System.Drawing.Color.Transparent;
            this.btnSkipForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSkipForward.BackgroundImage")));
            this.btnSkipForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSkipForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSkipForward.FlatAppearance.BorderSize = 0;
            this.btnSkipForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkipForward.Location = new System.Drawing.Point(109, 13);
            this.btnSkipForward.Name = "btnSkipForward";
            this.btnSkipForward.Size = new System.Drawing.Size(30, 25);
            this.btnSkipForward.SongButtonType = SongsAbout.Controls.SongButtonType.SkipForward;
            this.btnSkipForward.TabIndex = 2;
            this.btnSkipForward.UseVisualStyleBackColor = true;
            // 
            // btnSkipBack
            // 
            this.btnSkipBack.BackColor = System.Drawing.Color.Transparent;
            this.btnSkipBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSkipBack.BackgroundImage")));
            this.btnSkipBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSkipBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSkipBack.FlatAppearance.BorderSize = 0;
            this.btnSkipBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkipBack.Location = new System.Drawing.Point(3, 13);
            this.btnSkipBack.Name = "btnSkipBack";
            this.btnSkipBack.Size = new System.Drawing.Size(29, 25);
            this.btnSkipBack.SongButtonType = SongsAbout.Controls.SongButtonType.SkipBack;
            this.btnSkipBack.TabIndex = 1;
            this.btnSkipBack.UseVisualStyleBackColor = true;
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayPause.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlayPause.BackgroundImage")));
            this.btnPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlayPause.FlatAppearance.BorderSize = 0;
            this.btnPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPause.Location = new System.Drawing.Point(38, 3);
            this.btnPlayPause.Name = "btnPlayPause";
            this.tableLayoutPanel1.SetRowSpan(this.btnPlayPause, 3);
            this.btnPlayPause.Size = new System.Drawing.Size(65, 47);
            this.btnPlayPause.SongButtonType = SongsAbout.Controls.SongButtonType.Play;
            this.btnPlayPause.TabIndex = 0;
            this.btnPlayPause.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnSkipForward, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSkipBack, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPlayPause, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(142, 53);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // SongModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SongModule";
            this.Size = new System.Drawing.Size(142, 53);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SongButton btnPlayPause;
        private SongButton btnSkipBack;
        private SongButton btnSkipForward;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
