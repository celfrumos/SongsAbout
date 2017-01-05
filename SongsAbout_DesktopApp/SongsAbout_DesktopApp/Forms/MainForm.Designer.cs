namespace SongsAbout.Forms
{
    partial class MainForm
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
            this.songModule1 = new SongsAbout.Controls.SongModule();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // songModule1
            // 
            this.songModule1.IsPlaying = false;
            this.songModule1.Location = new System.Drawing.Point(259, 592);
            this.songModule1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.songModule1.Name = "songModule1";
            this.songModule1.Size = new System.Drawing.Size(142, 53);
            this.songModule1.SpotifyEntity = null;
            this.songModule1.SpotifyEntityType = SpotifyAPI.Web.Enums.SpotifyEntityType.None;
            this.songModule1.TabIndex = 28;
            this.songModule1.Track = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.ClientSize = new System.Drawing.Size(661, 658);
            this.Controls.Add(this.songModule1);
            this.Name = "MainForm";
            this.Controls.SetChildIndex(this.pBoxProfilePic, 0);
            this.Controls.SetChildIndex(this.songModule1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.SongModule songModule1;
    }
}
