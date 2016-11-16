using System;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using SongsAbout.Classes;
using SongsAbout.Properties;
using SpotifyAPI.Web.Models;
using SongsAbout.Entities;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using SongsAbout.Enums;

namespace SongsAbout.Controls
{
    public partial class SpotifyPanel : UserControl, IEntityControl
    {
        private string _level;
        public Image Image
        {
            get { return this.SpotifyPictureBox.Image; }
            set
            {
                try
                {
                    this.SpotifyPictureBox.Image = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public override string Text
        {
            get { return this.SpotifyLabel.Text; }
            set
            {
                try
                {
                    this.SpotifyLabel.Text = value != null ? value : "";
                }
                catch (NullReferenceException)
                {
                    this.SpotifyLabel = new SpotifyLabel();
                    try
                    {

                        this.SpotifyLabel.Text = value != null ? value : "";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public SpotifyPanel()
        {
            InitializeComponent();
        }

        public string Level
        {
            get { return this._level; }
            set
            {
                try
                {
                    this._level = value != null ? value : "";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public PictureBoxSizeMode SizeMode
        {
            get { return this.SpotifyPictureBox.SizeMode; }
            set { this.SpotifyPictureBox.SizeMode = value; }
        }

        public SpotifyEntityType SpotifyEntityType { get; set; }

        public DbEntityType DbEntityType { get; set; }
        private DbEntity _dbEntity;
        public DbEntity DbEntity
        {
            get { return this._dbEntity; }
            set
            {
                try
                {
                    this._dbEntity = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public SpotifyPanel(string text, string level = "Not Set", EventHandler clickEvent = null, object tag = null,
          DbEntityType dbtype = DbEntityType.None, SpotifyEntityType spotifyType = SpotifyEntityType.None) : this()
        {
            try
            {
                this.Text = text;
                this.Level = level;
                this.Tag = tag;
                this.Click += clickEvent;
                this.SpotifyEntityType = spotifyType;
                this.DbEntityType = dbtype;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public SpotifyPanel(string text, EventHandler clickEvent = null) : this(text, "Not Set", clickEvent)
        {
        }

        public SpotifyPanel(DbEntity entity, EventHandler clickEvent = null)
            : this(entity.Name, entity.TypeName, clickEvent, entity, entity.DbEntityType, entity.SpotifyType)
        {
            this.DbEntity = entity;
            this.SpotifyLabel = new SpotifyLabel(entity, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(entity, clickEvent);
        }

        public SpotifyPanel(FullAlbum album, EventHandler clickEvent = null)
            : this(album.Name, $"{typeof(FullAlbum)}", clickEvent, album, DbEntityType.Album, SpotifyEntityType.FullAlbum)
        {
            this.SpotifyLabel = new SpotifyLabel(album, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(album, clickEvent);
        }

        public SpotifyPanel(SimpleAlbum album, EventHandler clickEvent = null)
         : this(album.Name, $"{typeof(SimpleAlbum)}", clickEvent, album, DbEntityType.Album, SpotifyEntityType.SimpleAlbum)
        {
            this.SpotifyLabel = new SpotifyLabel(album, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(album, clickEvent);
        }

        public SpotifyPanel(FullArtist artist, EventHandler clickEvent = null)
         : this(artist.Name, $"{typeof(FullArtist)}", clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        {
            this.SpotifyLabel = new SpotifyLabel(artist, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(artist, clickEvent);
        }
        public SpotifyPanel(SimpleArtist artist, EventHandler clickEvent = null)
         : this(artist.Name, $"{typeof(SimpleArtist)}", clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        {
            this.SpotifyLabel = new SpotifyLabel(artist, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(artist, clickEvent);
        }

        public SpotifyPanel(FullPlaylist playlist, EventHandler clickEvent = null)
            : this(playlist.Name, $"{typeof(FullPlaylist)}", clickEvent, playlist, DbEntityType.List, SpotifyEntityType.FullPlaylist)
        {
            this.SpotifyLabel = new SpotifyLabel(playlist, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(playlist, clickEvent);
        }
        public SpotifyPanel(SimplePlaylist playlist, EventHandler clickEvent = null)
          : this(playlist.Name, $"{typeof(SimplePlaylist)}", clickEvent, playlist, DbEntityType.List, SpotifyEntityType.SimplePlaylist)
        {
            this.SpotifyLabel = new SpotifyLabel(playlist, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(playlist, clickEvent);
        }
        public SpotifyPanel(FullTrack track, EventHandler clickEvent = null)
        : this(track.Name, $"{typeof(FullTrack)}", clickEvent, track, DbEntityType.Track, SpotifyEntityType.FullTrack)
        {
            this.SpotifyLabel = new SpotifyLabel(track, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(track, clickEvent);
        }
        public SpotifyPanel(SimpleTrack track, EventHandler clickEvent = null)
        : this(track.Name, $"{typeof(SimpleTrack)}", clickEvent, track, DbEntityType.Track, SpotifyEntityType.SimpleTrack)
        {
            this.SpotifyLabel = new SpotifyLabel(track, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(track, clickEvent);
        }
    }

}
