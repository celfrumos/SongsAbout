using System;
using System.Collections.Generic;
using System.Drawing;
using SongsAbout.Classes;
using SongsAbout.Properties;
using SongsAbout.Entities;
using SpotifyAPI.Web.Models;
using SongsAbout.Enums;
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

        public SpotifyEntityType SpotifyEntityType { get; set; }

        public DbEntityType DbEntityType { get; set; }


        public SpotifyPictureBox(string text, EventHandler clickEvent = null, object tag = null,
            DbEntityType dbtype = DbEntityType.None, SpotifyEntityType spotifyType = SpotifyEntityType.None) : this()
        {
            this.Click += clickEvent;
            this.Tag = tag;
            this.DbEntityType = dbtype;
            this.SpotifyEntityType = spotifyType;
        }

        public SpotifyPictureBox(DbEntity entity, EventHandler clickEvent = null)
            : this(entity.Name, clickEvent, entity, entity.DbEntityType, entity.SpotifyType)
        {
            this.DbEntity = entity;
        }

        public SpotifyPictureBox(FullAlbum album, EventHandler clickEvent = null)
            : this(album.Name, clickEvent, album, DbEntityType.Album, SpotifyEntityType.FullAlbum)
        {
            SetImage(album.Images);
        }

        public SpotifyPictureBox(SimpleAlbum album, EventHandler clickEvent = null)
         : this(album.Name, clickEvent, album, DbEntityType.Album, SpotifyEntityType.SimpleAlbum)
        {
            SetImage(album.Images);
        }

        public SpotifyPictureBox(FullArtist artist, EventHandler clickEvent = null)
         : this(artist.Name, clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        {
            SetImage(artist.Images);
        }
        public SpotifyPictureBox(SimpleArtist artist, EventHandler clickEvent = null)
            : this(artist.Name, clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        {
            try
            {
                SetImage(Converter.GetFullArtist(artist).Images);
            }
            catch (SpotifyConversionError)
            {
                this.Image = this.ErrorImage;
            }
        }


        public SpotifyPictureBox(FullPlaylist playlist, EventHandler clickEvent = null)
            : this(playlist.Name, clickEvent, playlist, DbEntityType.List, SpotifyEntityType.FullPlaylist)
        {
            SetImage(playlist.Images);
        }
        public SpotifyPictureBox(SimplePlaylist playlist, EventHandler clickEvent = null)
          : this(playlist.Name, clickEvent, playlist, DbEntityType.List, SpotifyEntityType.SimplePlaylist)
        {
            SetImage(playlist.Images);
        }
        public SpotifyPictureBox(FullTrack track, EventHandler clickEvent = null)
        : this(track.Name, clickEvent, track, DbEntityType.Track, SpotifyEntityType.FullTrack)
        {
            SetImage(track.Album.Images);
        }
        public SpotifyPictureBox(SimpleTrack track, EventHandler clickEvent = null)
        : this(track.Name, clickEvent, track, DbEntityType.Track, SpotifyEntityType.SimpleTrack)
        {
            SetImage(Converter.GetFullTrack(track).Album.Images);
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
            catch (SpotifyImageImportError ex)
            {
                Console.WriteLine(ex.Message);
                this.Image = Resources.MusicNote;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting image: {ex.Message}");
                this.Image = this.ErrorImage;
            }
            if (this.Image == null)
            {
                this.Image = this.ErrorImage;
                throw new SpotifyException("Error Setting Image");
            }
        }

    }
}
