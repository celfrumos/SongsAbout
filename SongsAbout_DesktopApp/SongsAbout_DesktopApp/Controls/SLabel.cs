using System;
using System.ComponentModel;
using System.Drawing;
using SpotifyAPI.Web.Models;
using SongsAbout.Properties;
using SongsAbout.Entities;
using SongsAbout.Enums;
using SongsAbout.Classes;
using System.Windows.Forms;

namespace SongsAbout.Controls
{

    public partial class SLabel : Label, IEntityControl
    {
        public DbEntity DbEntity { get; set; }

        public SpotifyEntityType SpotifyEntityType { get; set; }
        public DbEntityType DbEntityType { get; set; }
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (value != null)
                {
                    base.Text = value;
                }
                else
                {
                    base.Text = "";
                }
            }
        }

        public ISpotifyEntity SpotifyEntity { get; set; }
        
        public SLabel()
        {
            InitializeComponent();
        }

        public SLabel(string text, EventHandler clickEvent = null, object tag = null,
            DbEntityType dbtype = DbEntityType.None, SpotifyEntityType spotifyType = SpotifyEntityType.None) : this()
        {
            this.Text = text;
            this.Tag = tag;
            this.Click += clickEvent;
            this.SpotifyEntityType = spotifyType;
            this.DbEntityType = dbtype;
        }

        public SLabel(DbEntity entity, EventHandler clickEvent = null)
            : this(entity.Name, clickEvent, entity, entity.DbEntityType, entity.SpotifyType)
        {
            this.DbEntity = entity;
        }
        public SLabel(ISpotifyEntity spotifyEntity, EventHandler clickEvent = null)
            : this(spotifyEntity.Name,  clickEvent, spotifyEntity, DbEntityType.Album, spotifyEntity.SpotifyEntityType)
        {
            this.SpotifyEntity = spotifyEntity;
        }
      //  public SLabel(FullAlbum album, EventHandler clickEvent = null)
      //      : this(album.Name, clickEvent, album, DbEntityType.Album, SpotifyEntityType.FullAlbum)
      //  {
      //  }

      //  public SLabel(SimpleAlbum album, EventHandler clickEvent = null)
      //   : this(album.Name, clickEvent, album, DbEntityType.Album, SpotifyEntityType.SimpleAlbum)
      //  {
      //  }

      //  public SLabel(FullArtist artist, EventHandler clickEvent = null)
      //   : this(artist.Name, clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
      //  {
      //  }
      //  public SLabel(SimpleArtist artist, EventHandler clickEvent = null)
      //: this(artist.Name, clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
      //  {
      //  }
      //  public SLabel(FullPlaylist playlist, EventHandler clickEvent = null)
      //      : this(playlist.Name, clickEvent, playlist, DbEntityType.List, SpotifyEntityType.FullPlaylist)
      //  {
      //  }
      //  public SLabel(SimplePlaylist playlist, EventHandler clickEvent = null)
      //    : this(playlist.Name, clickEvent, playlist, DbEntityType.List, SpotifyEntityType.SimplePlaylist)
      //  {
      //  }
      //  public SLabel(FullTrack track, EventHandler clickEvent = null)
      //  : this(track.Name, clickEvent, track, DbEntityType.Track, SpotifyEntityType.FullTrack)
      //  {
      //  }
      //  public SLabel(SimpleTrack track, EventHandler clickEvent = null)
      //  : this(track.Name, clickEvent, track, DbEntityType.Track, SpotifyEntityType.SimpleTrack)
      //  {
      //  }
        public bool ImportEntity()
        {
            try
            {
                return Importer.ImportFromSpotify(this.SpotifyEntity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Importing Entity: {ex.Message}");
                return false;
            }

        }
    }
}
