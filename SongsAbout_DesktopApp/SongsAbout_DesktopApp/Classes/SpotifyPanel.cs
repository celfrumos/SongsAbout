using System;
using System.Drawing;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp.Classes
{
  
    public partial class SpotifyPanel : Panel
    {
        public SpotifyPanel()
        {
            InitializeComponent();
        }

        //private Action<object, EventArgs> spotifyControl_Click;
        public EventHandler spotifyControl_Click
        {
            set { this.Click += value; }
        }

        public string Level { get; set; }

        public SpotifyPanel(object name = null, string level = "Not set")
        {
            this.Size = new Size(83, 106);
            this.TabStop = false;

            this.Name = "pnl" + name;
            this.Tag = name;
            this.Level = level;
            this.MouseHover += SpotifyControlEventHandlers.Hover;
        }
        public SpotifyPanel(BasicModel spotifyEntity, object name = null, string level = "Not set")
        {
            this.Size = new Size(83, 106);
            this.TabStop = false;

            this.Name = "pnl" + name;
            this.Tag = spotifyEntity;
            this.Level = level;
            this.MouseHover += SpotifyControlEventHandlers.Hover;
        }

        public SpotifyPanel(string name, string level, EventHandler clickEvent) : this(name, level)
        {
            this.Controls.Add(new SpotifyLabel(name, clickEvent));
        }
        public SpotifyPanel(BasicModel spotifyEntity, string name, string level, EventHandler clickEvent)
            : this(spotifyEntity, name, level)
        {
            this.Controls.Add(new SpotifyLabel(name, clickEvent));
        }

        public SpotifyPanel(FullTrack track, EventHandler clickEvent) : this(track.Name, "Track", clickEvent) { }

        public SpotifyPanel(FullArtist artist, EventHandler clickEvent) : this(artist.Name, "Artist", clickEvent)
        {
            this.Controls.Add(new SpotifyPictureBox(artist, clickEvent));
        }

        public SpotifyPanel(FullAlbum album, EventHandler clickEvent) : this(album.Name, "Artist", clickEvent)
        {
            this.Controls.Add(new SpotifyPictureBox(album, clickEvent));
        }
        public SpotifyPanel(FullPlaylist playlist, EventHandler clickEvent) : this(playlist.Name, "Playlist", clickEvent)
        {
            this.Controls.Add(new SpotifyPictureBox(playlist, clickEvent));
        }

        public SpotifyPanel(SimplePlaylist playlist, EventHandler clickEvent) : this(playlist.Name, "Playlist", clickEvent)
        {
            this.Controls.Add(new SpotifyPictureBox(playlist, clickEvent));
        }



        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
