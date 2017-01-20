using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout;
using SongsAbout.Controls;
using SongsAbout.Desktop.Properties;
using SongsAbout.Classes;
using SongsAbout.Entities;
using SongsAbout.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using Image = System.Drawing.Image;

namespace SongsAbout.Controls
{
    public enum AlbumType { DB, Spotify }
    public partial class AlbumDisplay : UserControl, IEntityControl
    {
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
        public AlbumType AlbumType { get; set; }
        public List<SpotifyTrack> SpotifyTracks = new List<SpotifyTrack>();
        public virtual string ArtistName
        {
            get { return this.lblArtist.Text; }
            set { this.lblArtist.Text = value; }
        }
        public virtual string AlbumName
        {
            get { return this.lblAlbumName.Text; }
            set { this.lblAlbumName.Text = value; }
        }
        private DbEntity _dbEntity;
        public DbEntity DbEntity
        {
            get { return _dbEntity; }
            set { this._dbEntity = value; }
        }
        public Album Album
        {
            get { return (Album)this.DbEntity; }
            set
            {
                this.AlbumName = value.Name;
                this.DbEntity = value;
                this._artist = value.Artist;
            }
        }
        private SpotifyAlbum _spotifyAlbum;
        private SpotifyArtist _spotifyArtist;
        public SpotifyArtist SpotifyArtist
        {
            get { return this._spotifyArtist; }
            set
            {
                this._spotifyArtist = value;
                this.ArtistName = value.Name;
            }
        }
        public SpotifyAlbum SpotifyAlbum
        {
            get { return this._spotifyAlbum; }
            set
            {
                this._spotifyAlbum = value;
                this.AlbumName = value.Name;
                SpotifyFullAlbum album;
                if (value.SpotifyEntityType == SpotifyEntityType.FullAlbum)
                {
                    album = (SpotifyFullAlbum)value;
                }
                else
                {
                    album = value.GetFullVersion(UserSpotify.WebAPI);
                }
                this.SpotifyArtist = album.Artists[0];
            }
        }
        private Artist _artist = new Artist();
        public Artist Artist
        {
            get { return this._artist; }
            set
            {
                this._artist = value;
                this.ArtistName = value.Name;
                this.Album.Artist = value;
                this.Album.Save();
            }
        }
        private List<Track> _tracks = new List<Track>();
        public List<Track> Tracks
        {
            get { return _tracks; }
            set { this._tracks = value; }
        }

        private SpotifyIntegralEntity _spotifyEntity;
        public SpotifyIntegralEntity SpotifyEntity
        {
            get { return this._spotifyEntity; }
            set { this._spotifyEntity = value; }
        }

        public SpotifyEntityType SpotifyEntityType { get; set; }

        public DbEntityType DbEntityType { get; set; }

        public AlbumDisplay()
        {

            InitializeComponent();
        }
        public AlbumDisplay(Album album)// : this()
        {
            this.AlbumType = AlbumType.DB;
            this.Album = album;
            this.lblAlbumName.DbEntity = album;
            this.lblArtist.Text = album.Artist.Name;
            this.lblAlbumName.Text = album.Name;
            album.Tracks.ToList().ForEach(t =>
            {
                this.Tracks.Add(t);
            });
            // this.listBoxTracks.DataSource = this.Tracks;
            this.SPictureBox = new SPicturePox(album);
        }
        public AlbumDisplay(SpotifyAlbum album)
            : this(album.SpotifyEntityType == SpotifyEntityType.FullAlbum ? (SpotifyFullAlbum)album
                  : album.GetFullVersion((UserSpotify.WebAPI)))
        {

        }
        public AlbumDisplay(SpotifyFullAlbum album) //: this()
        {
            this.SpotifyAlbum = album;
            this.lblAlbumName = new SLabel(album);
            this.lblArtist = new SLabel(album.Artists[0]);
            this.SpotifyTracks.AddRange(album.Tracks.Items);
            //this.listBoxTracks.DataSource = this.SpotifyTracks;
            this.SPictureBox = new SPicturePox(album);
        }
        public Image Image
        {
            get { return this.SPictureBox.Image; }
            set { this.SPictureBox.Image = value; }
        }


        public bool ImportEntity()
        {
            throw new NotImplementedException();
        }
    }
}
