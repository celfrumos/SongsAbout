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
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.trackRow1 = new SongsAbout.Controls.TrackRow();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.ColumnCount = 1;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel.Controls.Add(this.trackRow1, 0, 0);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.RowCount = 6;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.Size = new System.Drawing.Size(850, 202);
            this.panel.TabIndex = 0;
            // 
            // trackRow1
            // 
            this.trackRow1.Album = null;
            this.trackRow1.Artist = null;
            this.trackRow1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.trackRow1.DbEntity = null;
            this.trackRow1.DbEntityType = SongsAbout.Enums.DbEntityType.Track;
            this.trackRow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackRow1.ForeColor = System.Drawing.Color.White;
            this.trackRow1.Location = new System.Drawing.Point(4, 4);
            this.trackRow1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackRow1.MinimumSize = new System.Drawing.Size(200, 40);
            this.trackRow1.Name = "trackRow1";
            this.trackRow1.Selected = false;
            this.trackRow1.Size = new System.Drawing.Size(842, 40);
            this.trackRow1.SpotifyAlbum = null;
            this.trackRow1.SpotifyArtist = null;
            this.trackRow1.SpotifyEntity = null;
            this.trackRow1.SpotifyEntityType = ((SpotifyAPI.Web.Enums.SpotifyEntityType)((SpotifyAPI.Web.Enums.SpotifyEntityType.FullTrack | SpotifyAPI.Web.Enums.SpotifyEntityType.BaseTrack)));
            this.trackRow1.TabIndex = 0;
            this.trackRow1.Track = null;
            // 
            // TrackListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "TrackListBox";
            this.Size = new System.Drawing.Size(850, 202);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TrackRowCollection _items = new TrackRowCollection();
        private System.Windows.Forms.TableLayoutPanel panel;
        private TrackRow trackRow1;
    }
}
