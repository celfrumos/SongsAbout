using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SongsAbout.Entities;
using SongsAbout.Enums;
using SongsAbout.Classes;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Controls
{
    public partial class TrackRow : UserControl, IEntityControl
    {
        private string _trackName;
        public Track Track
        {
            get { return (Track)this.DbEntity; }
            set
            {
                this.DbEntity = value;
                if (value != null)
                {
                    this.TrackName = value.Name;
                    this.Artist = value.Artist;
                    this.Album = value.Album;
                    this.Uri = value.Uri;
                    this.Length = value.Length;
                }
            }
        }

        public Artist Artist
        {
            get { return (Artist)this.lblsArtist.DbEntity; }
            set
            {
                this.ArtistName = value.Name;
                this.lblsArtist.DbEntity = value;
                this.Track.Artist = value;
               // this.Track.Save();
            }
        }
        public double? Length
        {
            get { return this.Track.Length; }
            private set { this.lblsLength.Text = value.ToString(); }
        }
        public string Uri
        {
            get { return this.lblsUri.Text; }
            private set { this.lblsUri.Text = value; }
        }
        public Album Album
        {
            get { return (Album)this.lblsAlbum.DbEntity; }
            set
            {
                this.lblsAlbum.DbEntity = value;
                this.AlbumName = value.Name;
                this.Track.Album = value;
               // this.Track.Save();
            }
        }
        public string ArtistName
        {
            get { return this.lblsArtist.Text; }
            private set { this.lblsArtist.Text = value; }
            //TODO: implement updating other entities from TrackRow
        }

        public string AlbumName
        {
            get { return this.lblsAlbum.Text; }
            private set { this.lblsAlbum.Text = value; }
            //TODO: implement updating other entities from TrackRow
        }
        public string TrackName
        {
            get { return this.lblsName.Text; }
            private set { this.lblsName.Text = value; }
        }

        private FTrack _spotifyTrack { get; set; }
        public FArtist SpotifyArtist { get; set; }
        public FAlbum SpotifyAlbum { get; set; }
        public ISpotifyEntity SpotifyEntity
        {
            get { return this._spotifyTrack; }
            set
            {
                if (value.SpotifyEntityType == SpotifyEntityType.FullTrack)
                {
                    this._spotifyTrack = (FTrack)value;
                    this.SpotifyArtist = (FArtist)_spotifyTrack.SArtists[0].FullVersion();
                    this.SpotifyAlbum = new FAlbum(Converter.GetFullAlbum(_spotifyTrack.Album));


                    if (this._spotifyTrack != null)
                    {
                        this.Track = Program.Database.Tracks[this._spotifyTrack.Name];
                        if (this.Track == null)
                            this.Track = new Track(this._spotifyTrack);
                    }

                }
                else
                {
                    throw new DbException("Error Assigning TrackRow SpotifyEntity");
                }
            }
        }

        public SpotifyEntityType SpotifyEntityType { get; set; }
        public TrackRow()
        {
            this.SpotifyEntityType = SpotifyEntityType.Track;
            InitializeComponent();
        }
        public TrackRow(Track track) : this()
        {
            this.Track = track;
        }
        public TrackRow(FullTrack track) : this(new FTrack(track))
        {
        }

        public TrackRow(FTrack track) : this()
        {
            this.SpotifyEntity = track;
        }
        public TrackRow(string trackName) : this()
        {
            if (Program.Database.Tracks.Contains(trackName))
                this.Track = Program.Database.Tracks[trackName];
            else
                throw new EntityNotFoundError(DbEntityType.Track, trackName,
                    $"Unable to initialize TrackRow from artist name '{trackName}'");

        }
        public TrackRow(ISpotifyFullEntity track) : this()
        {
            try
            {
                if (Program.Database.Tracks.Contains(track.Name))
                    this.Track = Program.Database.Tracks[track.Name];
                else
                    this.Track = new Track(track);
            }
            catch (Exception ex)
            {
                throw new DbException(
                    $"Error initializint TrackRow from ISpotifyEntity track {track.Name}.\n{ex.Message}");
            }

        }
        private DbEntity _dbEntity;
        public DbEntity DbEntity
        {
            get { return this._dbEntity; }
            set
            {
                if (value == null || (value.DbEntityType & DbEntityType.Track) == DbEntityType.Track)
                    this._dbEntity = value;
                else
                    throw new DbException("TrackRow DbEntity must be Track");

            }
        }

        public DbEntityType DbEntityType
        {
            get { return DbEntityType.Track; }
            set { throw new DbException($"TrackRow can only have DbEntityType of Track."); }
        }


        public bool ImportEntity()
        {
            if (this.SpotifyEntity != null)
            {
                try
                {
                    if (!Program.Database.Tracks.Contains(this.SpotifyEntity.Name))
                    {
                        if (this.Track == null)
                            this.Track = new Track(this.SpotifyEntity);

                        this.Track.Save();
                        return true;
                    }
                    else
                        return false;
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Error Importing TrackRow Track");
                }
                return false;
            }
            else
            {
                throw new SpotifyImageImportError();
            }
        }


        private void TrackRow_Load(object sender, EventArgs e)
        {

        }
    }
}
