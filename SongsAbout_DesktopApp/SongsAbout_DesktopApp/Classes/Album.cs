using System.Data;
using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Classes;
using System.Windows.Forms;
using System.Collections.Generic;
using SongsAbout_DesktopApp.Properties;
using System;

namespace SongsAbout_DesktopApp
{
    public partial class Album
    {
        public void Save()
        {
            try
            {
                if (this.al_title != null && !Exists(this.al_title))
                {
                    using (DataClasses1DataContext context = new DataClasses1DataContext())
                    {
                        context.Albums.InsertOnSubmit(this);
                        context.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "Error Saving Album: " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public static bool Exists(string name)
        {
            try
            {
                int count = 0;
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    string aquery =
                    "select * from Albums where al_title = '" + name + "'";
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
                string msg = "Error validating if album exists: " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public static Album Load(string al_title)
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    string aquery =
                    "SELECT * FROM Albums WHERE al_title = '" + al_title + "'";
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

                    throw new Exception("No artist with that name found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Loading Album: " + al_title + ", " + ex.Message);
            }
        }

        public void Update(SimpleAlbum album)
        {
            try
            {
                FullAlbum al = User.Default.SpotifyWebAPI.GetAlbum(album.Id);
                this.Update(al);
            }
            catch (Exception ex)
            {
                string msg = "Error Updating Album: " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public async void Update(FullAlbum album)
        {
            try
            {
                this.al_title = album.Name;
                this.al_spotify_uri = album.Uri;
                UpdateArtist(album.Artists[0]);
                this.SetGenres(album.Genres);

                if (album.Images.Count > 0)
                {
                    byte[] pic = await UserSpotify.ConvertSpotifyImageToBytes(album.Images[0]);
                    this.al_cover_art = pic;
                }
            }
            catch (Exception ex)
            {
                string msg = "Error Updating Album: " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

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
                }
                a.Update(simpleArtist);
                a.Save();
                this.artist_id = a.artist_id;
            }
            catch (Exception ex)
            {
                string msg = "Error updating album artist: " + this.al_title + ", " + this.Artist.a_name + ": " + ex.Message;
                Console.WriteLine(msg);
                throw new Exception(msg);
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
