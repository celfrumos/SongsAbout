using System;
using System.ComponentModel;
using System.Drawing;
using SpotifyAPI.Web.Models;
using SongsAbout.Properties;
using SongsAbout.Entities;
using SongsAbout.Enums;
using System.Windows.Forms;

namespace SongsAbout.Controls
{

    public partial class SpotifyLabel : Label, IEntityControl
    {
        public DbEntity DbEntity { get; set; }

        public SpotifyEntityType SpotifyEntityType { get; set; }
        public DbEntityType DbEntityType { get; set; }

        public string Level { get; set; }

        public SpotifyLabel()
        {
            InitializeComponent();
        }

        public SpotifyLabel(string text, string level = "Not Set", EventHandler clickEvent = null, object tag = null,
            DbEntityType dbtype = DbEntityType.None, SpotifyEntityType spotifyType = SpotifyEntityType.None)
        {
            this.Text = text;
            this.Level = level;
            this.Tag = tag;
            this.Click += clickEvent;
            this.SpotifyEntityType = spotifyType;
            this.DbEntityType = dbtype;
        }

        public SpotifyLabel(string text, EventHandler clickEvent = null) : this(text, "Not Set", clickEvent)
        {
        }

        public SpotifyLabel(DbEntity entity, EventHandler clickEvent = null)
            : this(entity.Name, entity.TypeName, clickEvent, entity, entity.DbEntityType, entity.SpotifyType)
        {
            this.DbEntity = entity;
        }

        public SpotifyLabel(FullAlbum album, EventHandler clickEvent = null)
            : this(album.Name, $"{typeof(FullAlbum)}", clickEvent, album, DbEntityType.Album, SpotifyEntityType.FullAlbum)
        {
        }

        public SpotifyLabel(SimpleAlbum album, EventHandler clickEvent = null)
         : this(album.Name, $"{typeof(SimpleAlbum)}", clickEvent, album, DbEntityType.Album, SpotifyEntityType.SimpleAlbum)
        {
        }

        public SpotifyLabel(FullArtist artist, EventHandler clickEvent = null)
         : this(artist.Name, $"{typeof(FullArtist)}", clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        {
        }
        public SpotifyLabel(SimpleArtist artist, EventHandler clickEvent = null)
      : this(artist.Name, $"{typeof(SimpleArtist)}", clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        {
        }
        public SpotifyLabel(FullPlaylist playlist, EventHandler clickEvent = null)
            : this(playlist.Name, $"{typeof(FullPlaylist)}", clickEvent, playlist, DbEntityType.List, SpotifyEntityType.FullPlaylist)
        {
        }
        public SpotifyLabel(SimplePlaylist playlist, EventHandler clickEvent = null)
          : this(playlist.Name, $"{typeof(SimplePlaylist)}", clickEvent, playlist, DbEntityType.List, SpotifyEntityType.SimplePlaylist)
        {
        }
        public SpotifyLabel(FullTrack track, EventHandler clickEvent = null)
        : this(track.Name, $"{typeof(FullTrack)}", clickEvent, track, DbEntityType.Track, SpotifyEntityType.FullTrack)
        {
        }
        public SpotifyLabel(SimpleTrack track, EventHandler clickEvent = null)
        : this(track.Name, $"{typeof(SimpleTrack)}", clickEvent, track, DbEntityType.Track, SpotifyEntityType.SimpleTrack)
        {
        }

    }
}
