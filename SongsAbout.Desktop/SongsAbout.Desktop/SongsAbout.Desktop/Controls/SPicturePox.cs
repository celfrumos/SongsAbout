using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using SongsAbout;
using SongsAbout.Desktop.Properties;
using SongsAbout.Desktop.Entities;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SongsAbout.Enums;
using System.Windows.Forms;
using Image = System.Drawing.Image;


namespace SongsAbout.Controls
{
    [Docking(DockingBehavior.Ask)]
    public partial class SPicturePox : PictureBox, IEntityControl
    {
        [DefaultValue(DockStyle.Fill)]
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }
        public string EntityName
        {
            get
            {
                if (this.DbEntity != null)
                    return this.DbEntity.Name;

                else if (this.SpotifyEntity != null)
                    return this.SpotifyEntity.Name;
                else
                    return "Not Set";
            }
        }
        private DbEntity _dbEntity;
        public DbEntity DbEntity
        {
            get { return _dbEntity; }
            set
            {
                if (value != null)
                {
                    _dbEntity = value;
                    if (Enums.Flag.DB.HasFlag(value.DbEntityType, DbEntityType.Integral))
                    {
                        try
                        {
                            if (value is Artist)
                            {
                                this.Image = ((Artist)value).ProfilePic;
                            }
                            else if (value is Album)
                            {
                                this.Image = ((Album)value).CoverArt;
                            }
                            else if (value is Track)
                            {
                                this.Image = ((Track)value).Album.CoverArt;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error Setting SPictureBox Image:{ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Unsupported DbEntityType attempted to set SPictureBox image: {value.DbEntityType}");
                    }
                }
            }
        }
        public SPicturePox()
        {
            InitializeComponent();
            this.Image = Resources.MusicNote;
        }
        public SPicturePox(SpotifyIntegralEntity entity)
        {
            this.SpotifyEntity = entity;

        }
        private EventHandler ClickEvent { set { this.Click += value; } }

        public SpotifyEntityType SpotifyEntityType { get; set; }

        public DbEntityType DbEntityType { get; set; }
        private SpotifyIntegralEntity _spotifyEntity;
        public SpotifyIntegralEntity SpotifyEntity
        {
            get { return _spotifyEntity; }
            set
            {
                _spotifyEntity = value;
            }
        }

        public SPicturePox(string text, EventHandler clickEvent = null, object tag = null,
            DbEntityType dbtype = DbEntityType.None, SpotifyEntityType spotifyType = SpotifyEntityType.None) : this()
        {
            this.Click += clickEvent;
            this.Tag = tag;
            this.DbEntityType = dbtype;
            this.SpotifyEntityType = spotifyType;
        }

        public SPicturePox(DbEntity entity, EventHandler clickEvent = null)
            : this(entity.Name, clickEvent, entity, entity.DbEntityType, entity.SpotifyType)
        {
            this.DbEntity = entity;
        }
        public SPicturePox(SpotifyIntegralEntity spotifyEntity, EventHandler clickEvent = null)
            : this(spotifyEntity.Name, clickEvent, spotifyEntity, DbEntityType.Album, SpotifyEntityType.FullAlbum)
        {
            this.SpotifyEntity = spotifyEntity;
            if (spotifyEntity is ISpotifyFullEntity)
            {
                this.SetImage(((ISpotifyFullEntity)spotifyEntity).Images);

            }
        }
        //public SPicturePox(FullAlbum album, EventHandler clickEvent = null)
        //    : this(album.Name, clickEvent, album, DbEntityType.Album, SpotifyEntityType.FullAlbum)
        //{
        //    SetImage(album.Images);
        //}

        //public SPicturePox(SimpleAlbum album, EventHandler clickEvent = null)
        // : this(album.Name, clickEvent, album, DbEntityType.Album, SpotifyEntityType.SimpleAlbum)
        //{
        //    SetImage(album.Images);
        //}

        //public SPicturePox(FullArtist artist, EventHandler clickEvent = null)
        // : this(artist.Name, clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        //{
        //    SetImage(artist.Images);
        //}
        //public SPicturePox(SimpleArtist artist, EventHandler clickEvent = null)
        //    : this(artist.Name, clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        //{
        //    try
        //    {
        //        SetImage(Converter.GetFullArtist(artist).Images);
        //    }
        //    catch (SpotifyConversionError)
        //    {
        //        this.Image = this.ErrorImage;
        //    }
        //}
        //public SPicturePox(FullPlaylist playlist, EventHandler clickEvent = null)
        //    : this(playlist.Name, clickEvent, playlist, DbEntityType.List, SpotifyEntityType.FullPlaylist)
        //{
        //    SetImage(playlist.Images);
        //}
        //public SPicturePox(SimplePlaylist playlist, EventHandler clickEvent = null)
        //  : this(playlist.Name, clickEvent, playlist, DbEntityType.List, SpotifyEntityType.SimplePlaylist)
        //{
        //    SetImage(playlist.Images);
        //}
        //public SPicturePox(FullTrack track, EventHandler clickEvent = null)
        //: this(track.Name, clickEvent, track, DbEntityType.Track, SpotifyEntityType.FullTrack)
        //{
        //    SetImage(track.Album.Images);
        //}
        //public SPicturePox(SimpleTrack track, EventHandler clickEvent = null)
        //: this(track.Name, clickEvent, track, DbEntityType.Track, SpotifyEntityType.SimpleTrack)
        //{
        //    SetImage(Converter.GetFullTrack(track).Album.Images);
        //}

        private void SetImage(List<SpotifyAPI.Web.Models.SpotifyImage> images)
        {
            try
            {
                if (images.Count > 0)
                {
                    Image i = images[0];
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
