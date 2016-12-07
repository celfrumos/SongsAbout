﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SongsAbout.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DataClassesContext : DbContext
    {
        public DataClassesContext()
            : base("name=DataClassesContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
    
        public virtual int UpdateInsert_Artist(Nullable<int> id, string name, string a_bio, string a_website, string a_spotify_uri, byte[] a_profile_pic)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var a_bioParameter = a_bio != null ?
                new ObjectParameter("a_bio", a_bio) :
                new ObjectParameter("a_bio", typeof(string));
    
            var a_websiteParameter = a_website != null ?
                new ObjectParameter("a_website", a_website) :
                new ObjectParameter("a_website", typeof(string));
    
            var a_spotify_uriParameter = a_spotify_uri != null ?
                new ObjectParameter("a_spotify_uri", a_spotify_uri) :
                new ObjectParameter("a_spotify_uri", typeof(string));
    
            var a_profile_picParameter = a_profile_pic != null ?
                new ObjectParameter("a_profile_pic", a_profile_pic) :
                new ObjectParameter("a_profile_pic", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateInsert_Artist", idParameter, nameParameter, a_bioParameter, a_websiteParameter, a_spotify_uriParameter, a_profile_picParameter);
        }
    
        public virtual int UpdateInsert_Album(Nullable<int> id, Nullable<int> artist_id, string name, string al_year, string al_spotify_uri, byte[] al_cover_art)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var artist_idParameter = artist_id.HasValue ?
                new ObjectParameter("artist_id", artist_id) :
                new ObjectParameter("artist_id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var al_yearParameter = al_year != null ?
                new ObjectParameter("al_year", al_year) :
                new ObjectParameter("al_year", typeof(string));
    
            var al_spotify_uriParameter = al_spotify_uri != null ?
                new ObjectParameter("al_spotify_uri", al_spotify_uri) :
                new ObjectParameter("al_spotify_uri", typeof(string));
    
            var al_cover_artParameter = al_cover_art != null ?
                new ObjectParameter("al_cover_art", al_cover_art) :
                new ObjectParameter("al_cover_art", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateInsert_Album", idParameter, artist_idParameter, nameParameter, al_yearParameter, al_spotify_uriParameter, al_cover_artParameter);
        }
    
        public virtual int UpdateInsert_Track(Nullable<int> id, string name, string track_spotify_uri, Nullable<double> track_length_minutes, Nullable<int> track_artist_id, string can_play, Nullable<int> track_album_id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var track_spotify_uriParameter = track_spotify_uri != null ?
                new ObjectParameter("track_spotify_uri", track_spotify_uri) :
                new ObjectParameter("track_spotify_uri", typeof(string));
    
            var track_length_minutesParameter = track_length_minutes.HasValue ?
                new ObjectParameter("track_length_minutes", track_length_minutes) :
                new ObjectParameter("track_length_minutes", typeof(double));
    
            var track_artist_idParameter = track_artist_id.HasValue ?
                new ObjectParameter("track_artist_id", track_artist_id) :
                new ObjectParameter("track_artist_id", typeof(int));
    
            var can_playParameter = can_play != null ?
                new ObjectParameter("can_play", can_play) :
                new ObjectParameter("can_play", typeof(string));
    
            var track_album_idParameter = track_album_id.HasValue ?
                new ObjectParameter("track_album_id", track_album_id) :
                new ObjectParameter("track_album_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateInsert_Track", idParameter, nameParameter, track_spotify_uriParameter, track_length_minutesParameter, track_artist_idParameter, can_playParameter, track_album_idParameter);
        }
    }
}
