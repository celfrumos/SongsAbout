namespace SongsAbout.Controls
{
    partial class TrackListBox
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.trackRow1 = new SongsAbout.Controls.TrackRow();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.trackRow1);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(662, 202);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // trackRow1
            // 
            this.trackRow1.Album = null;
            this.trackRow1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackRow1.Artist = null;
            this.trackRow1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.trackRow1.DbEntity = null;
            this.trackRow1.DbEntityType = SongsAbout.Enums.DbEntityType.Track;
            this.trackRow1.ForeColor = System.Drawing.Color.White;
            this.trackRow1.Location = new System.Drawing.Point(4, 4);
            this.trackRow1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackRow1.MinimumSize = new System.Drawing.Size(548, 40);
            this.trackRow1.Name = "trackRow1";
            this.trackRow1.Size = new System.Drawing.Size(645, 40);
            this.trackRow1.SpotifyAlbum = null;
            this.trackRow1.SpotifyArtist = null;
            this.trackRow1.SpotifyEntity = null;
            this.trackRow1.SpotifyEntityType = ((SongsAbout.Enums.SpotifyEntityType)((SongsAbout.Enums.SpotifyEntityType.FullTrack | SongsAbout.Enums.SpotifyEntityType.SimpleTrack)));
            this.trackRow1.TabIndex = 0;
            this.trackRow1.Track = null;
            // 
            // TrackListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "TrackListBox";
            this.Size = new System.Drawing.Size(662, 202);
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TrackRowCollection _items= new TrackRowCollection();
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private TrackRow trackRow1;
    }
}
