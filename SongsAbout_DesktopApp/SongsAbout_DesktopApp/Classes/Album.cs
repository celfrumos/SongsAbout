using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Classes;
using System.Collections.Generic;
using SongsAbout_DesktopApp.Properties;
using System;

namespace SongsAbout_DesktopApp.Classes
{
    public partial class Album : DbEntity<Artist>
    {
        public static string Table = "Albums";
        public static string TitleColumn = "al_title";
        public Album(FullAlbum album)
        {
            this.Update(ref album);
        }

        public void Save()
        {
            try
            {
                if (this.al_title != null)
                {
                    if (!Exists(this.al_title))
                    {
                        this.Submit();

                    }
                    else
                    {
                        string msg = $"Track {this.al_title} already exists";
                        Console.WriteLine(msg);
                    }
                }
                else
                {
                    Console.WriteLine($"Error saving album {this.al_title}, already exists");
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error Saving Album '{ex.Message}'";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        new public static bool Exists(int album_id)
        {
            return DbEntity<Album>.Exists(album_id);
        }

        new public static bool Exists(string al_title)
        {
            return DbEntity<Album>.Exists(al_title);
        }

        private static void formatName(ref string name)
        {
            if (name.Contains("\'"))
            {
                int i = name.IndexOf("\'");
                name = name.Insert(i, "'");
            }
        }

        new public static Album Load(string al_title)
        {
            return DbEntity<Album>.Load(al_title);
        }

        new public static Album Load(int album_id)
        {
            return DbEntity<Album>.Load(album_id);
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

                this.Save();
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

                this.Save();
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
                    //  a.Save();
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
