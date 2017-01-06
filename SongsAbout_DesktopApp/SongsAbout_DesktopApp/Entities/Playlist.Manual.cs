using System;
using System.Collections.Generic;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SongsAbout.Enums;
using SongsAbout.Classes;
using SongsAbout.Properties;
using System.Linq;

namespace SongsAbout.Entities
{
    public partial class Playlist : DbEntity
    {
        public override string TitleColumnName { get; }
        public override string TableName { get; }
        public override string Name
        {
            get { return this.list_name; }
            set { this.list_name = value; }
        }
        public string URI
        {
            get { return this.list_spotify_uri; }
            set { this.list_spotify_uri = value; }
        }

        public string Href
        {
            get { return this.list_spotify_href; }
            set { this.list_spotify_href = value; }
        }

        public string SpotifyID
        {
            get { return this.list_spotify_id; }
            set { this.list_spotify_id = value; }
        }

        public bool FromSpotify
        {
            get
            {
                return this.URI != null
                    && this.Href != null
                    && this.SpotifyID != null;
            }
        }

        public List<Track> Tracks
        {
            get
            {
                return (from t in this.privateTracks
                        select t).ToList();

            }
            set
            {
                this.privateTracks = (ICollection<Track>)value;
            }
        }

        static public implicit operator Playlist(string name)
        {
            return new Playlist(name);
        }

        static public implicit operator Playlist(SpotifyPlaylist p)
        {
            return new Playlist(p.Name) { URI = p.Uri, Href = p.Href, SpotifyID = p.Id };
        }

        static public implicit operator SpotifyFullPlaylist(Playlist p)
        {
            if (p.SpotifyID != null)
                return UserSpotify.WebAPI.GetPlaylist(User.Default.PrivateId, p.SpotifyID);
            else
                throw new DbInitFromSpotifyError(DbEntityType.Playlist, p.SpotifyType);
        }
        public Playlist(string name)
        {
            this.Name = name;
        }

        public override void Save()
        {
            if (!Program.Database.Playlists.Contains(this.Name))
            {
                using (var db = new DataClassesContext())
                {
                    db.Playlists.Add(this);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine($"Attempted to save a tag that already exists");
            }
        }

        public void AddTrack(Track t)
        {
            if (this.privateTracks != null && !this.privateTracks.Contains(t))
            {
                this.privateTracks.Add(t);
            }
        }

        public override DbEntityType DbEntityType { get { return DbEntityType.Playlist; } }
        public override SpotifyEntityType SpotifyType { get { return SpotifyEntityType.Playlist; } }
    }
}
