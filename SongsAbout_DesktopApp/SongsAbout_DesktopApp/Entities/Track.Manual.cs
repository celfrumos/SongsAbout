using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;
using System.IO;
using SongsAbout.Properties;
using SongsAbout.Enums;
using SongsAbout.Classes;

namespace SongsAbout.Entities
{
    public partial class Track : DbEntity
    {
        private const double MS_TO_MINUTES = 60000D;

        public static string Table = "Tracks";
        public static string TypeString = "Track";
        public static string TitleColumn = "name";
        Type a = typeof(Track);

        public override string TableName
        {
            get { return Table; }
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

        public int ArtistId
        {
            get { return this.track_artist_id; }
            set { this.track_artist_id = value; }
        }

        public List<Artist> Artists
        {
            get; set;
        }

        private List<Genre> _loadGenres()
        {
            try
            {
                List<Genre> res;
                using (var db = new DataClassesContext())
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
                using (var db = new DataClassesContext())
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
                using (var db = new DataClassesContext())
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
                using (var db = new DataClassesContext())
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
                Album res;
                using (var db = new DataClassesContext())
                {
                    res = (Album)(from t in db.Tracks
                                  where t.ID == this.ID
                                  select t.privateAlbum);
                }

                if (res != null)
                    return res;

                else
                    return new Album();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading Playlists for Track {this.Name}: {ex.Message}");

                return new Album();
            }

        }
        public Album Album
        {
            set
            {
                this.privateAlbum = value;
                this.AlbumId = value.ID;
            }
            get
            {
                try
                {
                    try
                    {
                        if (this.privatePlaylists != null)
                            return this.privateAlbum;
                        else
                            return new Album();
                    }
                    catch (ObjectDisposedException ex)
                    {
                        Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");
                        return this._loadAlbum();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");

                    return this._loadAlbum();

                }
            }
        }
        private Artist _mainArtist { get; set; }
        public Artist MainArtist
        {
            set { _mainArtist = value; }
            get
            {
                try
                {
                    if (this._mainArtist != null)
                        return this._mainArtist;

                    else if (this.ArtistId != 0)
                        return Artist.Load(this.ArtistId);

                    else
                        return new Artist();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error loading MainArtist for Track {this.Name}: {ex.Message}");

                    return new Artist();
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning Genres for Track {this.Name}: {ex.Message}");

                    return _loadTopics();

                }
            }
        }
        public override string TypeName
        {
            get { return typeof(Artist).ToString(); }
        }
        public override string TitleColumnName
        {
            get { return TitleColumn; }
        }
        public static Track Load(Track track)
        {
            try
            {
                Track result = track;
                using (var db = new DataClassesContext())
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
                throw new DbFromSpotifyInitializationError(DbEntityType.Track, SpotifyEntityType.FullTrack);
            }

        }
        public static Track Load(int id)
        {
            try
            {
                Track result;
                using (var db = new DataClassesContext())
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
                throw new DbFromSpotifyInitializationError(DbEntityType.Track, SpotifyEntityType.FullTrack);
            }
        }
        public static Track Load(string name)
        {
            try
            {
                Track result;
                using (var db = new DataClassesContext())
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
                throw new DbFromSpotifyInitializationError(DbEntityType.Track, SpotifyEntityType.FullTrack);
            }

        }
        public Track(string name, double length = 0, string uri = "", int artist_id = 0, int album_id = 0)
        {
            this.Name = name;
            this.Length = length / MS_TO_MINUTES;
            this.Uri = uri;
        }
        public Track(FTrack t) : this(t.Name, t.DurationMs, t.Uri)
        {
            try
            {
                var tArtist = t.SArtists[0];
                UpdateArtist(tArtist);
                UpdateAlbum(t.Album);
            }
            catch (Exception ex)
            {
                throw new UpdateFromSpotifyError(this, t.Name, ex.Message);
            }
        }
        public Track(FullTrack t) : this(new FTrack(t))
        {
        }
        public Track(SimpleTrack t) : this(new STrack(t))
        {
        }

        public Track(ISpotifyEntity t) : this(t.Name, 0, t.Uri)
        {
            if (t.SpotifyEntityType == SpotifyEntityType.FullTrack)
            {
                var track = t as FTrack;
                this.track_length_minutes = track.DurationMs / MS_TO_MINUTES;
                UpdateArtist(track.SArtists[0]);
                UpdateAlbum(track.Album);
            }
            else if (t.SpotifyEntityType == SpotifyEntityType.SimpleTrack)
            {
                var sTrack = t as STrack;
                var track = sTrack.FullVersion() as FTrack;
                this.track_length_minutes = track.DurationMs / MS_TO_MINUTES;
                UpdateArtist(track.SArtists[0]);
                UpdateAlbum(track.Album);
            }
        }


        public Track(STrack track) : this(track.FullVersion())
        {
        }

        public override void Save()
        {
            try
            {
                if (this.name != null)
                {
                    using (var db = new DataClassesContext())
                    {
                        // db.Tracks.Add(this);
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
                throw new SaveError(this, this.Name, ex.Message);

            }
        }

        public static bool Exists(string name)
        {
            int tracks = 0;
            using (DataClassesContext context = new DataClassesContext())
            {
                FormatName(ref name);
                tracks = (
                   from t in context.Tracks
                   where t.name == name
                   select t).Count();
            }
            return tracks > 0;
        }

        public static bool Exists(int a)
        {
            int tracks = 0;
            using (DataClassesContext context = new DataClassesContext())
            {
                tracks = (
                   from ab in context.Tracks
                   where ab.ID == a
                   select ab).Count();
            }
            return tracks > 0;

        }

        public void Update(FTrack t)
        {
            try
            {
                this.name = t.Name;
                this.track_length_minutes = (t.DurationMs) / MS_TO_MINUTES;
                this.track_spotify_uri = t.Uri;
                UpdateAlbum(t.Album);
                UpdateArtist(new SArtist(t.Artists[0]));
            }
            catch (Exception ex)
            {
                string msg = $"Error Updating track: {ex.Message}";
                Console.WriteLine(msg);
                //throw new Exception(msg);
            }
        }

        public void UpdateArtist(SArtist artist)
        {
            try
            {
                Artist a;
                if (!Artist.Exists(artist.Name))
                {
                    a = new Artist(artist);
                    a.Save();
                }
                a = Artist.Load(artist.Name);

                this.track_artist_id = a.ID;

            }
            catch (Exception ex)
            {
                string msg = $"Error updating track artist: {this.name}: {ex.Message}";
                Console.WriteLine(msg);
                //  throw new Exception(msg);
            }
        }
        public void UpdateArtist(FullArtist artist)
        {
            try
            {
                Artist a;
                if (Artist.Exists(artist.Name))
                {
                    a = Artist.Load(artist.Name);
                }
                else
                {
                    a = new Artist(artist);
                    a.Save();
                    //al.Save();
                }
                this.track_artist_id = a.ID;

                //ta.Update(a.artist_id, this.track_id);
            }
            catch (Exception ex)
            {
                string msg = $"Error updating track artist: {this.name}: {ex.Message}";
                Console.WriteLine(msg);
                //  throw new Exception(msg);
            }
        }
        private void UpdateAlbum(SimpleAlbum album)
        {
            UpdateAlbum(new SAlbum(album));
        }
        private void UpdateAlbum(SAlbum album)
        {
            try
            {
                Album al;
                if (!Album.Exists(album.Name))
                {
                    al = new Album(album);
                    al.Save();
                }

                al = Album.Load(album.Name);
                this.track_album_id = al.ID;
            }
            catch (Exception ex)
            {
                string msg = $"Error updating track album for track: {this.name}: {ex.Message}";
                Console.WriteLine(msg);
            }
        }
        private void UpdateAlbum(FAlbum album)
        {
            try
            {
                Album al;
                if (Album.Exists(album.Name))
                {
                    al = new Album(album);
                    al.Save();
                }

                al = Album.Load(album.Name);
                this.track_album_id = al.ID;
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

        public Track(FTrack t, SpotifyEntityType type)
        {
            try
            {
                if (type == SpotifyEntityType.SimpleTrack || type == SpotifyEntityType.FullTrack)
                {
                    this.name = t.Name;
                    this.track_length_minutes = (t.DurationMs) / MS_TO_MINUTES;
                    this.track_spotify_uri = t.Uri;

                    UpdateAlbum(new SAlbum(t.Album));
                    UpdateArtist(new SArtist(t.Artists[0]));
                }
                else
                {
                    throw new DbFromSpotifyInitializationError(DbEntityType.Track, type, "");
                }
            }
            catch (DbFromSpotifyInitializationError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DbFromSpotifyInitializationError(DbEntityType.Artist, type, ex.Message);
            }
        }

    }
}
