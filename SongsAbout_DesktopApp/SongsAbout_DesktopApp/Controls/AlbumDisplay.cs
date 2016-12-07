using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Controls;
using System.Windows.Forms;
using SongsAbout.Classes;
using SongsAbout.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Controls
{
    public enum AlbumType { DB, Spotify }
    public partial class AlbumDisplay : UserControl, IEntityControl
    {
        public AlbumType AlbumType { get; set; }
        public List<FTrack> SpotifyTracks = new List<FTrack>();
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
        private FAlbum _spotifyAlbum;
        private FArtist _spotifyArtist;
        public FArtist SpotifyArtist
        {
            get { return this._spotifyArtist; }
            set
            {
                this._spotifyArtist = value;
                this.ArtistName = value.Name;
            }
        }
        public FAlbum SpotifyAlbum
        {
            get { return this._spotifyAlbum; }
            set
            {
                this._spotifyAlbum = value;
                this.AlbumName = value.Name;
                this.SpotifyArtist = new FArtist(Converter.GetFullArtist(value.Artists[0]));
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

        private ISpotifyEntity _spotifyEntity;
        public ISpotifyEntity SpotifyEntity
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
            this.listBoxTracks.DataSource = this.Tracks;
            this.SPictureBox = new SPicturePox(album);
        }
        public AlbumDisplay(FAlbum album) //: this()
        {
            this.SpotifyAlbum = album;
            this.lblAlbumName = new SLabel(album);
            this.lblArtist = new SLabel(new SArtist(album.Artists[0]));
            album.Tracks.Items.ForEach(t =>
            {
                this.SpotifyTracks.Add((FTrack)new STrack(t).FullVersion());
            });
            this.listBoxTracks.DataSource = this.SpotifyTracks;
            this.SPictureBox = new SPicturePox(album);
        }

        public Image Image
        {
            get { return this.SPictureBox.Image; }
            set { this.SPictureBox.Image = value; }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public bool ImportEntity()
        {
            throw new NotImplementedException();
        }
    }
}
