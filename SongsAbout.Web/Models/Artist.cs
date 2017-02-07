using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core;
using System.Data.Linq;
using System.Linq;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SongsAbout;
using SongsAbout.Database;
using System.Windows.Forms;
using SongsAbout.Properties;
using SongsAbout.Enums;
using System.IO;
using Image = System.Drawing.Image;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using SongsAbout.Entities;

namespace SongsAbout.Web.Models
{

    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    public partial class Artist
    {
        // DbEntityContext artistContext = new DbEntityContext();
        public const string TABLE_NAME = "Artists";
        public const string TYPE_STRING = "Artist";
        public const string TITLE_COLUMN = "name";

        public readonly DbEntityType DbEntityType = DbEntityType.Artist;

        Type a = typeof(Artist);

        public string TableName
        {
            get { return TABLE_NAME; }
        }

        public Artist(string name, string uri, string href, string bio = null)
        {
            this.Name = name;
            this.Uri = uri;
            this.Bio = bio;
            this.Href = Href;

        }

        public static implicit operator Artist(SpotifyArtist a)
        {
            return new Artist(a);
        }


        public Artist(SpotifyArtist artist) : this(artist.Name, artist.Uri, artist.Href)
        {
            this.UpdateProfilePic(artist);
        }

        public string Name { get; set; }

        public string TitleColumnName
        {
            get { return TITLE_COLUMN; }
        }

        public string Bio { get; set; }
        public string Href { get; set; }
        public string Uri { get; set; }
        public Image ProfilePic { get; set; }
        /// <summary>
        /// Submit Changes to the Database
        /// </summary>
        /// <exception cref="NullValueError"></exception>
        /// <exception cref="UpdateFromSpotifyError"></exception>"
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException"></exception>
        /// <exception cref="DbException"></exception>"
        public void Save()
        {
            //  SongDatabase.Artists.Add(this);

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
                this.Href = artist.Href;
                this.UpdateProfilePic(artist);

                this.Save();
            }
            catch (Exception ex)
            {
                throw new UpdateFromSpotifyError(DbEntityType, SpotifyEntityType.FullArtist, artist.Name, ex.Message);
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
            }
        }

        //public static Artist Load(Artist a)
        //{
        //    a.Albums.ToList().ForEach(al => al = Album.Load(al));
        //    a.Tracks.ToList().ForEach(t => t = Track.Load(t));
        //    return a;
        //}

        ///// <summary>
        ///// Get the Artist of the given name if it exists, otherwise throws an exception
        ///// </summary>
        ///// <param name="name"></param>
        ///// <exception cref="EntityNotFoundError"></exception>
        ///// <exception cref="LoadError"></exception>"
        //public static Artist Load(string name)
        //{
        //    if (SongDatabase.Artists.Contains(name))
        //    {
        //        //return SongDatabase.Artists[name];
        //    }
        //    else
        //    {
        //        throw new EntityNotFoundError(DbEntityType.Artist, name);
        //    }
        //}

        ///// <summary>
        ///// Load the artist of the given id from the database
        ///// </summary>
        ///// <param name="id"></param>
        ///// <exception cref="EntityNotFoundError"></exception>
        ///// <exception cref="LoadError"></exception>"
        ///// <returns></returns>
        //public static Artist Load(int id)
        //{
        //   // return SongDatabase.Artists[id];
        //}

    }
}
