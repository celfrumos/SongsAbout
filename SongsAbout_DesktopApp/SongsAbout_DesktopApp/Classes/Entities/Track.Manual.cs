using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Properties;
using System.Windows.Forms;
using System.IO;
using SongsAbout_DesktopApp.Classes;

namespace SongsAbout_DesktopApp.Classes.Entities
{
    public partial class Track //: DbEntity<Track>
    {

        public static string Table = "Tracks";
        public static string TitleColumn = "name";

        public Track(FullTrack t)
        {
            this.name = t.Name;
            this.track_length_minutes = (double)(t.DurationMs) / 60000;
            this.track_spotify_uri = t.Uri;

            try
            {
                UpdateAlbum(t.Album);
                SimpleArtist tArtist = t.Artists[0];
                UpdateArtist(tArtist);
            }
            catch (Exception ex)
            {
                throw new UpdateError<Track>(t.Name, ex.Message);
            }
        }

        public Track(SimpleTrack track)
        {
            FullTrack t = UserSpotify.WebAPI.GetTrack(track.Id);
            this.name = t.Name;
            this.track_length_minutes = (double)(t.DurationMs) / 60000;
            this.track_spotify_uri = t.Uri;
            try
            {
                UpdateAlbum(t.Album);
                SimpleArtist tArtist = t.Artists[0];
                UpdateArtist(tArtist);
            }
            catch (Exception ex)
            {
                throw new UpdateError<Track>(track.Name, ex.Message);
            }
        }

        public void Save()
        {
            try
            {
                if (this.name != null)
                {
                    if (!Exists(this.name))
                    {
                        //this.Submit();
                    }
                    else
                    {
                        string msg = $"Track {this.name} already exists";
                        Console.WriteLine(msg);
                    }
                }
                else
                {
                    throw new Exception("Track name can't be null");
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error saving Track: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);

            }
        }

        public static bool Exists(string name)
        {
            return true;// DbEntity<Track>.Exists(name);
        }

        public static bool Exists(int track_id)
        {
            return true; // DbEntity<Track>.Exists(track_id);

        }

        //public void SaveGenres(ref List<string> genres)
        //{
        //    try
        //    {
        //        using (DataClassesDataContext context = new DataClassesDataContext())
        //        {
        //            DataSet gen = new DataSet();

        //            foreach (string g in genres)
        //            {
        //                TrackGenre tg = new TrackGenre();
        //                tg.track_id = this.track_id;
        //                tg.tg_genre = g;

        //                context.TrackGenres.InsertOnSubmit(tg);
        //            }

        //            context.SubmitChanges();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = "Error Saving track genres: " + ex.Message;
        //        Console.WriteLine(msg);
        //        throw new Exception(msg);
        //    }
        //}

        public void Update(FullTrack t)
        {
            try
            {
                this.name = t.Name;
                this.track_length_minutes = (double)(t.DurationMs) / 60000;
                this.track_spotify_uri = t.Uri;
                this.Save();
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

        public void Update(ref FullTrack t)
        {
            this.name = t.Name;
            this.track_length_minutes = (double)(t.DurationMs) / 60000;
            this.track_spotify_uri = t.Uri;
            try
            {

                UpdateAlbum(t.Album);
                SimpleArtist tArtist = t.Artists[0];
                UpdateArtist(tArtist);
            }
            catch (Exception ex)
            {
                string msg = $"Error Updating track: {ex.Message}";
                Console.WriteLine(msg);
                //throw new Exception(msg);
            }
        }

        public void UpdateArtist(SimpleArtist simpleArtist)
        {
            try
            {
                //Artist a;
                //TrackArtists ta = new TrackArtists();
                //if (Artist.Exists(simpleArtist.Name))
                //{
                //    a = Artist.Load(simpleArtist.Name);
                //}
                //else
                //{
                //    a = new Artist();
                //    a.Update(simpleArtist);
                //    //   a.Save();
                //}

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
            try
            {
                //AlbumTracks at = new AlbumTracks();

                //Album al;
                //if (Album.Exists(album.Name))
                //{
                //    al = Album.Load(album.Name);
                //}
                //else
                //{
                //    al = new Album();
                //    al.Update(album);
                //    //al.Save();
                //}
                //at.Update(al.album_id, this.track_id);
                ////at.Save();
            }
            catch (Exception ex)
            {
                string msg = $"Error updating track album for track: {this.name}: {ex.Message}";
                Console.WriteLine(msg);
                //    throw new Exception(msg);
            }
        }

        //private void UpdateAlbum(ref SimpleAlbum album)
        //{
        //    try
        //    {
        //        Album al;
        //        if (Artist.Exists(album.Name))
        //        {
        //            al = Album.Load(album.Name);
        //        }
        //        else
        //        {
        //            al = new Album();
        //            al.Update(album);
        //            al.Save();
        //        }

        //        this.album_id = al.album_id;
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = $"Error updating track album for track: {this.name}: {ex.Message}";
        //        Console.WriteLine(msg);
        //        //    throw new Exception(msg);
        //    }
        //}

    }
}
