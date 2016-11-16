using System;
using System.Collections.Generic;
using System.Drawing;
using SongsAbout.Classes;
using SongsAbout.Properties;
using SongsAbout.Entities;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace SongsAbout.Controls
{
    public partial class SpotifyPictureBox : PictureBox, IEntityControl
    {
        public DbEntity DbEntity { get; set; }

        public SpotifyPictureBox()
        {
            InitializeComponent();
            this.Image = Resources.MusicNote;
        }

        private EventHandler ClickEvent { set { this.Click += value; } }

        public SpotifyPictureBox(string name, string level, object tag = null) : this()
        {
            this.Name = name;
            this.Level = level;
            this.Tag = tag;
        }

        public SpotifyPictureBox(string name, string level, object tag, DbEntity entity) : this(name, level, tag)
        {
            this.DbEntity = entity;
        }

        public SpotifyPictureBox(string name, string level, object tag, EventHandler clickEvent)
            : this(name, level, tag)
        {
            this.ClickEvent = clickEvent;
        }

        public SpotifyPictureBox(FullAlbum album, EventHandler clickEvent) : this(album.Name, album.Type, album)
        {
            this.Click += clickEvent;
            SetImage(album.Images);
        }
        public SpotifyPictureBox(FullArtist artist, EventHandler clickEvent) : this(artist.Name, artist.Type, artist)
        {
            this.Click += clickEvent;
            SetImage(artist.Images);
        }
        public SpotifyPictureBox(FullPlaylist playlist, EventHandler clickEvent) : this(playlist.Name, playlist.Type, playlist)
        {
            this.Click += clickEvent;
            SetImage(playlist.Images);
        }

        public SpotifyPictureBox(SimplePlaylist playlist, EventHandler clickEvent)
            : this(playlist.Name, playlist.Type, clickEvent)
        {
            this.Click += clickEvent;
        }

        private void SetImage(List<SpotifyAPI.Web.Models.Image> images)
        {
            try
            {
                if (images.Count > 0)
                {
                    Image i = Importer.ImportSpotifyImage(images[0]);
                    if (i != null)
                    {
                        this.Image = i;
                    }
                    else
                    {
                        this.Image = Resources.MusicNote;
                    }
                }
                else
                {
                    this.Image = Resources.MusicNote;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting image: {ex.Message}");
            }
            if (this.Image == null)
            {
                throw new Exception("Error Setting Image");
            }
        }

    }
}
