﻿using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core;
using System.Data.Linq;
using System.Linq;
using SpotifyAPI.Web.Models;
using SongsAbout.Classes;
using System.Windows.Forms;
using SongsAbout.Properties;
using System.IO;
using Image = System.Drawing.Image;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace SongsAbout.Entities
{

    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    public partial class Artist : DbEntity// : DbEntity<Artist>
    {
        // DataClassesContext artistContext = new DataClassesContext();
        public static string Table = "Artists";
        public static string TypeString = "Artist";
        public static string TitleColumn = "name";
        Type a = typeof(Artist);

        public override string TableName
        {
            get { return Table; }
        }

        public Artist(FullArtist artist)
        {
            this.name = artist.Name;
            this.a_spotify_uri = artist.Uri;
            this.a_website = artist.Href;
            this.UpdateProfilePic(artist);
            this.a_website = artist.Href;

        }
        public Artist(SimpleArtist artist) : this(Converter.GetFullArtist(artist))
        {

        }
        public override string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Image Image { get { return Converter.ImageFromBytes(this.a_profile_pic); } }

        public override string TypeName
        {
            get { return typeof(Artist).ToString(); }
        }
        public override string TitleColumnName
        {
            get { return TitleColumn; }
        }

        /// <summary>
        /// Submit Changes to the Database
        /// </summary>
        public override void Save()
        {
            try
            {
                if (this.name != null)
                {
                    using (var context = new DataClassesContext())
                    {
                        context.UpdateInsert_Artist(this.ID, this.name, a_bio, a_website, this.a_spotify_uri, this.a_profile_pic);
                        context.SaveChanges();
                        //    context.Artists.Add(this);
                        //  var e = context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Artist name cannot be null.");
                }
            }
            catch (EntityNotFoundError ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
            catch (UpdateError ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }
        /// </summary>
        public override void Save(DataClassesContext db)
        {
            try
            {
                if (this.name != null)
                {
                    if (!Exists(this.name))
                    {
                        db.Artists.Add(this);
                        db.SaveChanges();

                    }
                    else
                    {
                        throw new EntityNotFoundError(this, this.name);
                    }
                }
                else
                {
                    throw new Exception("Artist name cannot be null.");
                }
            }
            catch (Exception ex)
            {
                throw new SaveError(this, this.name, ex.Message);
            }
        }

        public static bool Exists(string name)
        {
            try
            {
                int count = 0;
                formatName(ref name);
                using (var db = new DataClassesContext())
                {
                    var c = db.Artists.Where(a => a.name == name);
                    count = c.Count();
                }

                return count > 0;
            }
            catch (Exception ex)
            {
                throw new DbException(typeof(Artist), ex.Message);
            }
        }

        public static bool Exists(int artist_id)
        {
            try
            {
                int count = 0;
                using (var db = new DataClassesContext())
                {
                    count = (from a in db.Artists
                             where a.ID == artist_id
                             select a).Count();
                };
                return count > 0;

            }
            catch (Exception ex)
            {
                throw new DbException(typeof(Artist), ex.Message);
            }
            //  return DbEntity<Artist>.Exists(artist_id);
        }

        public void Update(SimpleArtist artist)
        {
            try
            {
                FullArtist a;
                a = User.Default.SpotifyWebAPI.GetArtist(artist.Id);
                this.Update(a);
            }
            catch (Exception ex)
            {
                throw new UpdateError(this, artist.Name, ex.Message);
            }
        }

        public void Update(FullArtist artist)
        {
            try
            {
                this.name = artist.Name;
                this.a_spotify_uri = artist.Uri;
                this.a_website = artist.Href;
                this.UpdateProfilePic(artist);
                this.a_website = artist.Href;

                this.Save();
            }
            catch (Exception ex)
            {
                throw new UpdateError(this, artist.Name, ex.Message);
            }
        }

        private void UpdateProfilePic(FullArtist artist)
        {
            if (artist.Images.Count > 0)
            {
                byte[] pic = Importer.ImportSpotifyImageBytes(artist.Images[0]);
                this.a_profile_pic = pic; //await UserSpotify.ConvertSpotifyImageToBytes(artist.Images[0]);

            }
        }

        public static Artist Load(string a_name)
        {
            try
            {
                Artist result = new Artist();
                try
                {
                    using (var db = new DataClassesContext())
                    {
                        result = (Artist)(from Artist a in db.Artists
                                          where a.name == a_name
                                          select a).First();
                    }
                }
                catch (Exception)
                {
                    result = new Artist();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new LoadError(new Artist(), a_name, ex.Message);
            }
        }

        public static Artist Load(int a_id)
        {
            try
            {
                if (!Exists(a_id))
                {
                    Artist result;
                    using (var db = new DataClassesContext())
                    {
                        result = (Artist)(from Artist a in db.Artists
                                          where a.ID == a_id
                                          select a).First();
                    }
                    return result;
                }
                else
                {
                    throw new EntityNotFoundError(typeof(Artist), a_id);
                }
            }
            catch (Exception ex)
            {
                throw new LoadError(new Artist(), a_id, ex.Message);
            }
        }

    }
}
