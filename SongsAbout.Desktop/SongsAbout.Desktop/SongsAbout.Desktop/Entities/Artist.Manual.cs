﻿using System;
using System.Linq;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SongsAbout.Desktop.Database;
using SongsAbout.Enums;
using System.Drawing;

namespace SongsAbout.Desktop.Entities
{

    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    public partial class Artist : DbEntity
    {
        // DbEntityContext artistContext = new DbEntityContext();
        public const string TABLE_NAME = "Artists";
        public const string TypeString = "Artist";
        public const string TitleColumn = "name";
        private static int DB_SEED_ID = 0;
        public override string TableName
        {
            get { return TABLE_NAME; }
        }

        public Artist(string name, string uri, string website, string bio = null)
        {
            this.Name = name;
            this.Uri = uri;
            this.Bio = bio;
            this.Website = website;

        }

        public static implicit operator Artist(SpotifyArtist a)
        {
            return new Artist(a);
        }


        public Artist(SpotifyArtist artist) : this(artist.Name, artist.Uri, artist.Href)
        {
            this.UpdateProfilePic(artist);
        }

        public override string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public override string TitleColumnName
        {
            get { return TitleColumn; }
        }

        public string Bio
        {
            get { return this.a_bio; }
            set { this.a_bio = value; }
        }
        public string Website
        {
            get { return this.a_website; }
            set { this.a_website = value; }
        }
        public string Uri
        {
            get { return this.a_spotify_uri; }
            set { this.a_spotify_uri = value; }
        }
        public byte[] ProfilePicBytes
        {
            get { return this.a_profile_pic; }
            set { this.a_profile_pic = value; }
        }
        public SpotifyImage SpotifyImage { get; set; }

        private Image _profilePic;
        public Image ProfilePic
        {
            get
            {
                if (_profilePic != null)
                    return _profilePic;
                else
                    return Converter.ImageFromBytes(this.ProfilePicBytes);
            }
            set
            {
                _profilePic = value;
                var newBytes = Converter.ImageToBytes(value);
                if (newBytes != null)
                {
                    this.ProfilePicBytes = newBytes;
                }
            }
        }
        /// <summary>
        /// Submit Changes to the Database
        /// </summary>
        /// <exception cref="NullValueError"></exception>
        /// <exception cref="UpdateFromSpotifyError"></exception>"
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException"></exception>
        /// <exception cref="DbException"></exception>"
        public override void Save()
        {
            string imgLine = $@"var {this.name}_img = new ProfilePic {{ ProfilePicId = {DB_SEED_ID}, Url = {this.SpotifyImage.Url}, Width = {this.SpotifyImage.Width}, Height = {this.SpotifyImage.Height} }};";
            string artistLine = $@"var {this.name} = new Artist {{ ArtistId = { DB_SEED_ID }, Name = { this.name }, SpotifyId = { this.a_spotify_uri }, ProfilePicId = { DB_SEED_ID } }};";
            base.SaveEntitySeed($@"
                            {imgLine}
                            {artistLine}
                            context.ProfilePics.Add({this.name}_img);
                            context.Artists.Add({this.name});");

            DB_SEED_ID++;
            SongDatabase.Artists.Add(this);
        }

        public static bool Exists(string name)
        {
            return SongDatabase.Artists.Contains(name);
        }

        public static bool Exists(int id)
        {
            return SongDatabase.Artists.Contains(id);
        }

        /// <summary>
        /// Initialize the member data from spotify Aritst
        /// </summary>
        /// <param name="artist"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        public void Update(SpotifyArtist artist)
        {
            try
            {
                this.Name = artist.Name;
                this.Uri = artist.Uri;
                this.Website = artist.Href;
                this.UpdateProfilePic(artist);

                this.Save();
            }
            catch (Exception ex)
            {
                throw new UpdateFromSpotifyError(this.DbEntityType, SpotifyEntityType.FullArtist, artist.Name, ex.Message);
            }
        }

        private void UpdateProfilePic(SpotifyArtist artist)
        {
            SpotifyFullArtist fullArtist;
            if (artist.SpotifyEntityType == SpotifyEntityType.FullArtist)
                fullArtist = (SpotifyFullArtist)artist;
            else
                fullArtist = artist.GetFullVersion(UserSpotify.WebAPI);

            if (fullArtist.Images.Count > 0)
            {
                this.ProfilePic = fullArtist.Images[0];
                this.SpotifyImage = fullArtist.Images[0];
            }
        }

        public static Artist Load(Artist a)
        {
            a.Albums.ToList().ForEach(al => al = Album.Load(al));
            a.Tracks.ToList().ForEach(t => t = Track.Load(t));
            return a;
        }

        /// <summary>
        /// Get the Artist of the given name if it exists, otherwise throws an exception
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="EntityNotFoundError"></exception>
        /// <exception cref="LoadError"></exception>"
        public static Artist Load(string name)
        {
            if (SongDatabase.Artists.Contains(name))
            {
                return SongDatabase.Artists[name];
            }
            else
            {
                throw new EntityNotFoundError(DbEntityType.Artist, name);
            }
        }

        /// <summary>
        /// Load the artist of the given id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="EntityNotFoundError"></exception>
        /// <exception cref="LoadError"></exception>"
        /// <returns></returns>
        public static Artist Load(int id)
        {
            return SongDatabase.Artists[id];
        }

    }
}
