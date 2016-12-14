﻿using System;
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

        private const string TABLE_NAME = "Tracks";
        private const string TITLE_COLUMN = "name";

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
                Album res = Program.Database.Albums[this.AlbumId];
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
                    Program.Database.Artists[this.ArtistId] = value;

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
                throw new DbInitFromSpotifyError(DbEntityType.Track, SpotifyEntityType.FullTrack, ex.Message);
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
                throw new DbInitFromSpotifyError(DbEntityType.Track, SpotifyEntityType.FullTrack, ex.Message);
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
        public Track(FTrack t) : this(t.Name, t.DurationMs, t.Uri)
        {
            try
            {
                this.Artist = Program.Database.Artists[t.Artists[0].Name];
                this.Album = Program.Database.Albums[t.Album.Name];
                if (this.Artist == null)
                {
                    UpdateArtist(t.SArtists[0]);
                }
                if (this.Album == null)
                {
                    UpdateAlbum(t.Album);

                }
            }
            catch (Exception ex)
            {
                throw new UpdateFromSpotifyError(this.DbEntityType, SpotifyEntityType.FullTrack, t.Name, ex.Message);
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
                throw new SaveError(this.DbEntityType, this.Name, ex.Message);

            }
        }

        public static bool Exists(string name)
        {
            return Program.Database.Tracks.Contains(name);
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
        /// <summary>
        /// Update the Track Artist from an SArtist
        /// </summary>
        /// <param name="artist"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        public void UpdateArtist(SArtist artist)
        {
            try
            {
                Artist newArtist = Program.Database.Artists[artist.Name];
                if (newArtist == null)
                {
                    newArtist = new Artist(Converter.GetFullArtist(artist));
                    Program.Database.Artists.Add(newArtist);
                }


                newArtist = Program.Database.Artists[artist.Name];
                if (newArtist != null)
                {
                    this.ArtistId = newArtist.ID;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                string msg = $"Error updating track artist: {this.name}: {ex.Message}";
                throw new UpdateFromSpotifyError(msg);
            }
        }

        /// <summary>
        /// Update the Track Artist from an SimpleArtist
        /// </summary>
        /// <param name="album"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        private void UpdateAlbum(SimpleAlbum album)
        {
            try
            {
                UpdateAlbum(new SAlbum(album));
            }
            catch (UpdateFromSpotifyError)
            {
                throw;
            }
        }
        /// <summary>
        /// Update the Track Artist from an SAlbum
        /// </summary>
        /// <param name="album"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        private void UpdateAlbum(SAlbum album)
        {
            try
            {
                UpdateAlbum((FAlbum)album.FullVersion());
            }
            catch (UpdateFromSpotifyError)
            {
                throw;
            }

        }
        /// <summary>
        /// Update the Track Artist from an FArtist
        /// </summary>
        /// <param name="artist"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        public void UpdateArtist(FArtist artist)
        {
            try
            {
                Artist a;
                if (!Artist.Exists(artist.Name))
                {
                    Program.Database.Artists[artist.Name] = new Artist((FullArtist)artist);
                }
                a = Program.Database.Artists[artist.Name];
                this.track_artist_id = a.ID;

            }
            catch (Exception ex)
            {
                throw new UpdateFromSpotifyError(DbEntityType.Artist, SpotifyEntityType.FullArtist, artist.Name, ex.Message);
            }
        }

        /// <summary>
        /// Update the Track Artist from an FullArtist
        /// </summary>
        /// <param name="artist"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        public void UpdateArtist(FullArtist artist)
        {
            try
            {
                UpdateArtist(new FArtist(artist));
            }
            catch (UpdateFromSpotifyError)
            {
                throw;
            }
        }

        /// <summary>
        /// Update the Track Album from an FAlbum
        /// </summary>
        /// <param name="album"></param>
        /// <exception cref="UpdateFromSpotifyError"></exception>
        private void UpdateAlbum(FAlbum album)
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
                this.AlbumId = al.ID;
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
