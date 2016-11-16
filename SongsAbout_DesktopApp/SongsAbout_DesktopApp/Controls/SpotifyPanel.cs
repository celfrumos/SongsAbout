using System;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using SongsAbout.Classes;
using SongsAbout.Properties;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;
using Image = System.Drawing.Image;


namespace SongsAbout.Controls
{
    public partial class SpotifyPanel : UserControl, IEntityControl, ISpotifyPictureBox
    {
        public Image Image
        {
            get { return this.SpotifyPictureBox.Image; }
            set { this.SpotifyPictureBox.Image = value; }
        }

        public override string Text
        {
            get { return this.spotifyLabel.Text; }
            set { this.spotifyLabel.Text = value; }
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
            get { return this.SpotifyPictureBox.SizeMode; }
            set { this.SpotifyPictureBox.SizeMode = value; }
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
            this.spotifyLabel = new SpotifyLabel(name, clickEvent);
        }

        public SpotifyPanel(BasicModel spotifyEntity, string name, string level, EventHandler clickEvent)
            : this(spotifyEntity, name, level)
        {
            this.spotifyLabel = new SpotifyLabel(name, clickEvent);
        }

        public SpotifyPanel(FullTrack track, EventHandler clickEvent) : this(track.Name, "Track", clickEvent) { }

        public SpotifyPanel(FullArtist artist, EventHandler clickEvent) : this(artist.Name, "Artist", clickEvent)
        {
            this.SpotifyPictureBox = new SpotifyPictureBox(artist, clickEvent);
        }

        public SpotifyPanel(FullAlbum album, EventHandler clickEvent) : this(album.Name, "Artist", clickEvent)
        {
            this.SpotifyPictureBox = new SpotifyPictureBox(album, clickEvent);
        }

        public SpotifyPanel(FullPlaylist playlist, EventHandler clickEvent) : this(playlist.Name, "Playlist", clickEvent)
        {
            this.SpotifyPictureBox = new SpotifyPictureBox(playlist, clickEvent);
        }

        public SpotifyPanel(SimplePlaylist playlist, EventHandler clickEvent) : this(playlist.Name, "Playlist", clickEvent)
        {
            this.SpotifyPictureBox = new SpotifyPictureBox(playlist, clickEvent);
         
        }
    }
  
}
