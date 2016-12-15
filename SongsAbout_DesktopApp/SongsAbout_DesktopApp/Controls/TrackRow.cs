﻿using System;
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
    [DesignTimeVisible(true)]
    [Docking(DockingBehavior.Ask)]
    public partial class TrackRow : SControl, IExtenderProvider, IContainerControl
    {
        private string _trackName;
        private bool _selected;
        private Color HoverColor = Color.Black;
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                Color compColor;
                if (_selected)
                    compColor = HoverColor;
                else
                    compColor = Color.Transparent;

                foreach (Control item in tableLayoutPanel1.Controls)
                {
                    item.BackColor = compColor;
                }
            }
        }

        [Browsable(false)]
        public Track Track
        {
            get { return (Track)this.DbEntity; }
            set
            {
                DbEntity = value;
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
        [Browsable(false)]
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
        [Browsable(true)]
        public double? Length
        {
            get { return this.Track.Length; }
            private set
            {
                if (value == null)
                {
                    this.lblsLength.Text = "--";
                }
                else
                {
                    this.lblsLength.Text = value.ToString();
                    this.Track.Length = value;

                }
            }
        }

        [Browsable(true)]
        public string Uri
        {
            get { return this.lblsUri.Text; }
            private set { this.lblsUri.Text = value; }
        }
        [Browsable(false)]
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

        [Browsable(true)]
        public string ArtistName
        {
            get { return this.lblsArtist.Text; }
            private set { this.lblsArtist.Text = value; }
            //TODO: implement updating other entities from TrackRow
        }

        [Browsable(true)]
        public string AlbumName
        {
            get { return this.lblsAlbum.Text; }
            private set { this.lblsAlbum.Text = value; }
            //TODO: implement updating other entities from TrackRow
        }

        [Browsable(true)]
        public string TrackName
        {
            get { return this._trackName; }
            private set
            {
                this._trackName = value;
                this.lblsName.Text = this._trackName;
            }
        }

        private FTrack _spotifyTrack { get; set; }
        [Browsable(true)]
        public FArtist SpotifyArtist { get; set; }

        [Browsable(true)]
        public FAlbum SpotifyAlbum { get; set; }

        [Browsable(false)]
        public override ISpotifyEntity SpotifyEntity
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

        public override SpotifyEntityType SpotifyEntityType { get; set; }
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

        [Browsable(true)]
        public override DbEntity DbEntity
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

        public override DbEntityType DbEntityType
        {
            get { return DbEntityType.Track; }
            set
            {
                if ((value & DbEntityType.Track) != DbEntityType.Track)
                {
                    throw new DbException($"TrackRow can only have DbEntityType of Track.");
                }
            }
        }


        public override bool ImportEntity()
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
                    Console.WriteLine($"Error Importing TrackRow Track: {ex.Message}");
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

        private void TrackRow_SizeChanged(object sender, EventArgs e)
        {

        }

        public bool CanExtend(object extendee)
        {
            return ((IExtenderProvider)tableLayoutPanel1).CanExtend(extendee);
        }
    }
}