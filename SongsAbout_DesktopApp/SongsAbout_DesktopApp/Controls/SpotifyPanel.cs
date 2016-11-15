using System;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using SongsAbout_DesktopApp.Classes;
using SongsAbout_DesktopApp.Properties;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;
using Image = System.Drawing.Image;


namespace SongsAbout_DesktopApp.Controls
{
    public partial class SpotifyPanel : UserControl, ISpotifyControl, ISpotifyPictureBox
    {
        public Image Image
        {
            get { return this.PictureBox.Image; }
            set { this.PictureBox.Image = value; }
        }

        public override string Text
        {
            get { return this.Label.Text; }
            set { this.Label.Text = value; }
        }

        public SpotifyPanel()
        {
            InitializeComponent();
        }
        public EventHandler spotifyControl_Click
        {
            set { this.Click += value; }
        }

        public string Level { get; set; }

        public PictureBoxSizeMode SizeMode
        {
            get { return this.PictureBox.SizeMode; }
            set { this.PictureBox.SizeMode = value; }
        }

        public SpotifyPanel(object name = null, string level = "Not set") : this()
        {
            this.Size = new Size(83, 106);
            this.TabStop = false;

            this.Name = "pnl" + name;
            this.Tag = name;
            this.Level = level;
        }

        public SpotifyPanel(BasicModel spotifyEntity, object name = null, string level = "Not set") : this()
        {
            this.Size = new Size(83, 106);
            this.TabStop = false;

            this.Name = "pnl" + name;
            this.Tag = spotifyEntity;
            this.Level = level;
        }

        public SpotifyPanel(string name, string level, EventHandler clickEvent) : this(name, level)
        {
            this.Label = new SpotifyLabel(name, clickEvent).AsLabel();
        }

        public SpotifyPanel(BasicModel spotifyEntity, string name, string level, EventHandler clickEvent)
            : this(spotifyEntity, name, level)
        {
            this.Label = new SpotifyLabel(name, clickEvent).AsLabel();
        }

        public SpotifyPanel(FullTrack track, EventHandler clickEvent) : this(track.Name, "Track", clickEvent) { }

        public SpotifyPanel(FullArtist artist, EventHandler clickEvent) : this(artist.Name, "Artist", clickEvent)
        {
            this.PictureBox = new SpotifyPictureBox(artist, clickEvent).AsPictureBox();
        }

        public SpotifyPanel(FullAlbum album, EventHandler clickEvent) : this(album.Name, "Artist", clickEvent)
        {
            this.PictureBox = new SpotifyPictureBox(album, clickEvent).AsPictureBox();
        }

        public SpotifyPanel(FullPlaylist playlist, EventHandler clickEvent) : this(playlist.Name, "Playlist", clickEvent)
        {
            this.PictureBox = new SpotifyPictureBox(playlist, clickEvent).AsPictureBox();
        }

        public SpotifyPanel(SimplePlaylist playlist, EventHandler clickEvent) : this(playlist.Name, "Playlist", clickEvent)
        {
            this.PictureBox = new SpotifyPictureBox(playlist, clickEvent).AsPictureBox();
        }
    }
}
