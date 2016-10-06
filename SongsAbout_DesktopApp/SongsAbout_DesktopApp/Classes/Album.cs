using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Classes;
using System.Collections.Generic;
using SongsAbout_DesktopApp.Properties;
using System;

namespace SongsAbout_DesktopApp
{
    public partial class Album
    {

        public Album(FullAlbum album)
        {
            this.Update(ref album);
        }

        public void Save()
        {
            try
            {
                if (this.al_title != null && !Exists(this.al_title))
                {
                    using (DataClassesDataContext context = new DataClassesDataContext())
                    {
                        context.Albums.InsertOnSubmit(this);
                        context.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error Saving Album '{ex.Message}'";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public static bool Exists(string al_title)
        {
            try
            {
                int count = 0;
                formatName(ref al_title);
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string aquery = $"SELECT * FROM Albums WHERE al_title = '{al_title}'";
                    var albs = db.ExecuteQuery<Album>(aquery);
                    foreach (var item in albs)
                    {
                        count++;
                    }
                }
                return (count > 0); ;
            }
            catch (Exception ex)
            {
                string msg = $"Error validating if album '{al_title}'exists: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        private static void formatName(ref string name)
        {
            if (name.Contains("\'"))
            {
                int i = name.IndexOf("\'");
                name = name.Insert(i, "'");
            }
        }

        public static Album Load(string al_title)
        {
            try
            {
                formatName(ref al_title);
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string aquery = $"SELECT * FROM Albums WHERE al_title = '{al_title}'";
                    var albums = db.ExecuteQuery<Album>(aquery);
                    int count = 0;
                    foreach (Album album in albums)
                    {
                        count++;
                        if (count == 1)
                        {
                            return album;
                        }
                    }

                    throw new Exception($"No artist with name '{al_title}' found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Loading Album '{al_title}', {ex.Message}");
            }
        }

        public static Album Load(int album_id)
        {
            try
            {
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string aquery = $"SELECT * FROM Albums WHERE album_id = {album_id}";
                    var albums = db.ExecuteQuery<Album>(aquery);
                    int count = 0;
                    foreach (Album album in albums)
                    {
                        count++;
                        if (count == 1)
                        {
                            return album;
                        }
                    }

                    throw new Exception($"No artist with id {album_id} found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Loading Album from id '{album_id}': {ex.Message}");
            }
        }

        public void Update(SimpleAlbum album)
        {
            try
            {
                FullAlbum al = User.Default.SpotifyWebAPI.GetAlbum(album.Id);
                this.Update(ref al);
            }
            catch (Exception ex)
            {
                string msg = $"Error Updating Album: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public void Update(ref SimpleAlbum album)
        {
            try
            {
                FullAlbum al = User.Default.SpotifyWebAPI.GetAlbum(album.Id);
                this.Update(ref al);
            }
            catch (Exception ex)
            {
                string msg = $"Error Updating Album: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public void Update(FullAlbum album)
        {
            try
            {
                this.al_title = album.Name;
                this.al_spotify_uri = album.Uri;
                UpdateArtist(album.Artists[0]);
                this.SetGenres(album.Genres);
                this.UpdateCoverArt(album);

                Console.WriteLine($"Album updated: '{album.Name}'");
            }
            catch (Exception ex)
            {
                string msg = $"Error Updating Album: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public void Update(ref FullAlbum album)
        {
            try
            {
                this.al_title = album.Name;
                this.al_spotify_uri = album.Uri;
                this.UpdateArtist(album.Artists[0]);
                this.SetGenres(album.Genres);
                this.UpdateCoverArt(album);

                Console.WriteLine($"Album updated: '{album.Name}'");
            }
            catch (Exception ex)
            {
                string msg = $"Error Updating Album: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        private void UpdateCoverArt(FullAlbum album)
        {
            if (album.Images.Count > 0)
            {
                byte[] pic = Importer.ImportSpotifyImageBytes(album.Images[0]);
                this.al_cover_art = pic;
            }
        }

        //private void ImportAlbumTracks(Paging<SimpleTrack> tracks)
        //{
        //    foreach (SimpleTrack track in tracks.Items)
        //    {
        //        try
        //        {
        //            Importer.ImportTrack(track);
        //            Console.WriteLine($"Imported track '{track.Name}'");
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}

        private void UpdateArtist(SimpleArtist simpleArtist)
        {
            try
            {
                Artist a;
                if (Artist.Exists(simpleArtist.Name))
                {
                    a = Artist.Load(simpleArtist.Name);
                }
                else
                {
                    a = new Artist();
                    a.Update(simpleArtist);
                    a.Save();
                    Console.WriteLine($"Artist added: '{a.a_name}'");
                }
                this.artist_id = a.artist_id;
            }
            catch (Exception ex)
            {
                string msg = $"Error updating artist for album '{this.al_title}', '{this.Artist.a_name}' : {ex.Message}";
                Console.WriteLine(msg);
            }
        }

        public void SetGenres(List<string> genres)
        {
            //foreach (string g in genres)
            //{
            //    AlbumGenre ag = new AlbumGenre();
            //    ag.album_id = this.album_id;
            //    ag.genre = g;

            //}
        }

    }
}
