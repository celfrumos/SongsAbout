namespace SongsAbout.Controls
{
    partial class SpotifyPictureBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public string Level { get; set; }

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
        public void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // SpotifyPictureBox
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorImage = global::SongsAbout.Properties.Resources.MusicNote;
            this.Image = global::SongsAbout.Properties.Resources.MusicNote;
            this.InitialImage = global::SongsAbout.Properties.Resources.MusicNote;
            this.Name = "SPBox";
            this.Size = new System.Drawing.Size(62, 61);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


    }
}
