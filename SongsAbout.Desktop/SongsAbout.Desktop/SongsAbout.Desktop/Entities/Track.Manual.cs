using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using SongsAbout.Enums;
using SongsAbout;
using SongsAbout.Desktop.Database;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Desktop.Entities
{
    public partial class Track : DbEntity
    {
        private const double MS_TO_MINUTES = 60000D;

        private const string TABLE_NAME = "Tracks";
        private const string TITLE_COLUMN = "name";
        private static int DB_SEED_ID = 0;

        public override string TableName { get { return TABLE_NAME; } }
        public override DbEntityType DbEntityType
        {
            get { return DbEntityType.Track; }
        }
        public override string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double? Length
        {
            get { return this.track_length_minutes; }
            set { this.track_length_minutes = value; }
        }
        public string Uri
        {
            get { return this.track_spotify_uri; }
            set { this.track_spotify_uri = value; }
        }

        public int AlbumId
        {
            get { return this.track_album_id; }
            set { this.track_album_id = value; }
        }
        public bool CanPlay
        {
            get { return this.can_play; }
            set { this.can_play = value; }
        }
        public int ArtistId
        {
            get { return this.track_artist_id; }
            set { this.track_artist_id = value; }
        }

        public List<Artist> Artists
        {
            get { return this.privateArtists.ToList(); }
            set { this.privateArtists = value; }
        }

        private List<Genre> _loadGenres()
        {
            try
            {
                List<Genre> res;
                using (var db = new DbEntityContext())
                {
                    res = (List<Genre>)(from t in db.Tracks
                                        where t.ID == this.ID
                                        select t.privateGenres);
                }

                if (res.Count > 0)
                    return res;

                else
                    return new List<Genre>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading Genres for Track {this.Name}: {ex.Message}");

                return new List<Genre>();
            }
        }
        private List<Topic> _loadTopics()
        {
            try
            {
                List<Topic> res;
                using (var db = new DbEntityContext())
                {
                    res = (List<Topic>)(from t in db.Tracks
                                        where t.ID == this.ID
                                        select t.privateTopics);
                }

                if (res.Count > 0)
                    return res;

                else
                    return new List<Topic>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading Topics for Track {this.Name}: {ex.Message}");

                return new List<Topic>();
            }
        }
        private List<Tag> _loadTags()
        {
            try
            {
                List<Tag> res;
                using (var db = new DbEntityContext())
                {
                    res = (List<Tag>)(from t in db.Tracks
                                      where t.ID == this.ID
                                      select t.privateTags);
                }

                if (res.Count > 0)
                    return res;

                else
                    return new List<Tag>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading Topics for Track {this.Name}: {ex.Message}");

                return new List<Tag>();
            }
        }
        private List<Playlist> _loadPlaylists()
        {
            try
            {
                List<Playlist> res;
                using (var db = new DbEntityContext())
                {
                    res = (List<Playlist>)(from t in db.Tracks
                                           where t.ID == this.ID
                                           select t.privatePlaylists);
                }

                if (res.Count > 0)
                    return res;

                else
                    return new List<Playlist>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading Playlists for Track {this.Name}: {ex.Message}");

                return new List<Playlist>();
            }
        }

        private Album _loadAlbum()
        {
            try
            {
                Album res = SongDatabase.Albums[this.AlbumId];
                this.privateAlbum = res;
                return res;

            }
            catch (EntityNotFoundError)
            {
                throw;
            }
            catch (Exception ex)
            {
                string msg = $" Error loading Playlists for Track {this.Name}: {ex.Message}";
                throw new LoadError(DbEntityType.Album, this.AlbumId, msg);
            }

        }
        /// <summary>
        /// Get the main Album of the Track
        /// </summary>
        /// <exception cref="EntityNotFoundError"></exception>
        /// <exception cref="LoadError"></exception>
        public Album Album
        {
            set
            {
                this._album = value;
                if (value != null && value.ID != 0)
                {
                    this.AlbumId = value.ID;
                    this.privateAlbum = value;
                }
            }
            get
            {
                try
                {
                    return _album;

                }
                catch (EntityNotFoundError)
                {
                    throw;
                }
                catch (ObjectDisposedException ex)
                {
                    string msg = $" Error returning Genres for Track {this.Name}: {ex.Message}";
                    throw new LoadError(DbEntityType.Album, this.ArtistId, msg);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");
                    throw new LoadError(DbEntityType.Album, this.AlbumId, ex.Message);
                }
            }
        }
        private Artist _artist;
        private Album _album;
        /// <summary>
        /// The Main artist of the track
        /// </summary>
        /// <exception cref="EntityNotFoundError"></exception>
        /// <exception cref="LoadError"></exception>
        public Artist Artist
        {
            set
            {
                this._artist = value;
                if (this.ArtistId != null && this.ArtistId != 0 && value != null)
                {
                    SongDatabase.Artists[this.ArtistId] = value;

                }
            }
            get
            {
                try
                {
                    return _artist;
                }
                catch (EntityNotFoundError)
                {
                    throw;
                }
                catch (ObjectDisposedException ex)
                {
                    string msg = $" Error loading Artist for Track {this.Name}: {ex.Message}";
                    throw new LoadError(DbEntityType.Artist, this.ArtistId, msg);
                }
                catch (Exception ex)
                {
                    string msg = $" Error loading Artist for Track {this.Name}: {ex.Message}";
                    throw new LoadError(DbEntityType.Artist, this.ArtistId, msg);
                }
            }
        }
        public List<Playlist> Playlists
        {
            set { this.privatePlaylists = value; }
            get
            {
                try
                {
                    if (this.privatePlaylists != null)
                        return (List<Playlist>)this.privatePlaylists;
                    else
                        return new List<Playlist>();

                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");
                    return this._loadPlaylists();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");

                    return _loadPlaylists();

                }
            }
        }

        public List<Tag> Tags
        {
            set { this.privateTags = value; }
            get
            {
                try
                {
                    if (this.privateTags != null)
                        return (List<Tag>)this.privateTags;
                    else
                        return new List<Tag>();

                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");
                    return this._loadTags();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");

                    return _loadTags();

                }
            }
        }
        public List<Genre> Genres
        {
            set { this.privateGenres = value; }
            get
            {
                try
                {
                    if (this.privateGenres != null)
                        return (List<Genre>)this.privateGenres;
                    else
                        return new List<Genre>();
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");
                    return this._loadGenres();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");

                    return _loadGenres();

                }
            }
        }
        public List<Topic> Topics
        {
            set { this.privateTopics = value; }
            get
            {
                try
                {
                    if (this.privateGenres != null)
                        return (List<Topic>)this.privateTopics;
                    else
                        return new List<Topic>();

                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");
                    return this._loadTopics();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");

                    return _loadTopics();

                }
            }
        }

        public override string TitleColumnName
        {
            get { return TITLE_COLUMN; }
        }
        public static Track Load(Track track)
        {
            try
            {
                Track result = track;
                using (var db = new DbEntityContext())
                {
                    result = (from Track a in db.Tracks
                              where a == track
                              select a).First();

                    result.Genres = result.Genres;
                    result.Artists = result.Artists;
                    result.Topics = result.Topics;
                    result.Playlists = result.Playlists;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new DbInitFromSpotifyError(DbEntityType.Track, SpotifyEntityType.FullTrack, ex.Message);
            }

        }
        public static Track Load(int id)
        {
            try
            {
                Track result;
                using (var db = new DbEntityContext())
                {
                    result = (from Track t in db.Tracks
                              where t.ID == id
                              select t).First();

                    result.Genres = result.Genres;
                    result.Artists = result.Artists;
                    result.Topics = result.Topics;
                    result.Playlists = result.Playlists;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new DbInitFromSpotifyError(DbEntityType.Track, SpotifyEntityType.FullTrack, ex.Message);
            }
        }
        public static Track Load(string name)
        {
            try
            {
                Track result;
                using (var db = new DbEntityContext())
                {
                    result = (from Track t in db.Tracks
                              where t.Name == name
                              select t).First();

                    result.Genres = result.Genres;
                    result.Artists = result.Artists;
                    result.Topics = result.Topics;
                    result.Playlists = result.Playlists;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new DbInitFromSpotifyError(DbEntityType.Track, SpotifyEntityType.FullTrack, ex.Message);
            }

        }
        public Track(string name, double length = 0, string uri = "", int artist_id = 0, int album_id = 0)
        {
            this.Name = name;
            this.Length = length / MS_TO_MINUTES;
            this.Uri = uri;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        public Track(SpotifyTrack t) : this(t.Name, t.DurationMs, t.Uri)
        {
            try
            {
                SpotifyFullTrack track = new SpotifyFullTrack { };
                if (t.SpotifyEntityType == SpotifyEntityType.FullTrack)
                    track = (SpotifyFullTrack)t;

                else
                    track = t.FullVersion(UserSpotify.WebAPI);

                UpdateArtist(track.Artists[0]);
                UpdateAlbum(track.Album);

            }
            catch (Exception ex)
            {
                throw new DbInitFromSpotifyError(DbEntityType.Track, t.SpotifyEntityType, ex.Message);
            }
        }
        public static implicit operator Track(SpotifyTrack t)
        {
            return new Track(t);
        }
        public override void Save()
        {
            try
            {
                if (this.name != null)
                {
                    using (var db = new DbEntityContext())
                    {
                        var trackLine = $@"var {this.name} = new Track {{ TrackId = {DB_SEED_ID} Name = {this.name}, SpotifyId = {this.track_spotify_uri}, AlbumId = {this.Album}.AlbumId, ArtistId = {this.Artist}.ArtistId, LengthMinutes = {this.track_length_minutes}, CanPlay = {this.can_play}}}";

                        base.SaveEntitySeed($@"
                            {trackLine}
                            context.Tracks.Add({this.name});");

                        DB_SEED_ID++;
                        db.UpdateInsert_Track(this.ID, this.name, this.track_spotify_uri, this.track_length_minutes, this.track_artist_id, this.can_play, this.track_album_id);
                        db.SaveChanges();
                        Console.WriteLine($"Successfully saved track '{name}'");
                    }
                }
                else
                {
                    throw new Exception("Track name can't be null");
                }
            }
            catch (Exception ex)
            {
                throw new SaveError(this.DbEntityType, this.Name, ex.Message);

            }
        }

        public static bool Exists(string name)
        {
            return SongDatabase.Tracks.Contains(name);
        }


        public void Update(SpotifyTrack t)
        {
            try
            {
                this.name = t.Name;
                this.track_length_minutes = (t.DurationMs) / MS_TO_MINUTES;
                this.track_spotify_uri = t.Uri;
                UpdateAlbum(t.Album);
                UpdateArtist(t.Artists[0]);
            }
            catch (Exception ex)
            {
                string msg = $"Error Updating track: {ex.Message}";
                Console.WriteLine(msg);
                //throw new Exception(msg);
            }
        }


        /// <summary>
        /// Update the Track Artist from an FArtist
        /// </summary>
        /// <param name="artist"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        public void UpdateArtist(SpotifyArtist artist)
        {
            try
            {
                Artist a = SongDatabase.Artists[artist.Name];

                if (a == null)
                {
                    a = artist;
                    a.Save();
                    a = SongDatabase.Artists[artist.Name];
                    this.AlbumId = a.ID;
                }
                this.Artist = a;

            }
            catch (Exception ex)
            {
                throw new UpdateFromSpotifyError(DbEntityType.Artist, SpotifyEntityType.FullArtist, artist.Name, ex.Message);
            }
        }


        /// <summary>
        /// Update the Track Album from an FAlbum
        /// </summary>
        /// <param name="album"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        private void UpdateAlbum(SpotifyAlbum album)
        {
            try
            {
                Album al = SongDatabase.Albums[album.Name];

                if (al == null)
                {
                    al = album;
                    al.Save();
                    al = SongDatabase.Albums[album.Name];
                    this.AlbumId = al.ID;
                }
                this.Album = al;

            }
            catch (SaveError ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (LoadError ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                string msg = $"Error updating track album for track: {this.name}: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }


    }
}
