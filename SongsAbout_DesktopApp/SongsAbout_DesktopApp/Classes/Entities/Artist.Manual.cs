using System;
using System.Data;
using System.Data.Linq;
using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Classes;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Properties;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace SongsAbout_DesktopApp.Classes.Entities
{

    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    public partial class Artist// : DbEntity<Artist>
    {
        public static string Table = "Artists";
        public static string TitleColumn = "name";

        /// <summary>
        /// Submit Changes to the Database
        /// </summary>
        public void Save()
        {
            try
            {
                if (this.name != null)
                {
                    if (!Exists(this.name))
                    {
                        //   DbEntity<Artist>.Submit();
                    }
                    else
                    {
                        var e = new EntityNotFoundError<Artist>();
                    }
                }
                else
                {
                    throw new Exception("Artist name cannot be null.");
                }
            }
            catch (Exception ex)
            {
                throw new SaveError<Artist>(ex.Message);
            }
        }

        public static bool Exists(string name)
        {
            using (var db = new DataClassContext())
            {
                Artist k = db.Artists.Find(name);
                //var query =
                //    from a in db.Artists
                //    where a == name
                //    select a;

                return k != null;
            }
        }

        public static bool Exists(int artist_id)
        {
            return true;
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
                throw new UpdateError<Artist>(artist.Name, ex.Message);
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
                throw new UpdateError<Artist>(artist.Name, ex.Message);
            }
        }

        private void UpdateProfilePic(FullArtist artist)
        {
            if (artist.Images.Count > 0)
            {
                byte[] pic = Importer.ImportSpotifyImageBytes(artist.Images[0]);
                this.a_profile_pic = pic;//await UserSpotify.ConvertSpotifyImageToBytes(artist.Images[0]);

            }
        }

        public static Artist Load(string title)
        {
            throw new NotImplementedException();
            //return DbEntity<Artist>.Load(title);
        }

        public static Artist Load(int id)
        {
            throw new NotImplementedException();
            //return DbEntity<Artist>.Load(id);
        }

        //public static Artist Load(string name)
        //{
        //    try
        //    {
        //        formatName(ref name);
        //        using (DataClassesDataContext db = new DataClassesDataContext())
        //        {
        //            string aquery = $"SELECT * FROM Artists WHERE name = '{name}'";
        //            var artists = db.ExecuteQuery<Artist>(aquery);
        //            int count = 0;
        //            foreach (Artist artist in artists)
        //            {
        //                count++;
        //                if (count == 1)
        //                {
        //                    return artist;
        //                }
        //            }

        //            throw new Exception($"No artist with name '{name}' found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error Loading artist '{name}': {ex.Message}");
        //    }
        //}

        //private void oldLoad()
        //{
        //    try
        //    {
        //        BindingSource artistsBindingSource = new BindingSource();
        //        DataSetTableAdapters.ArtistsTableAdapter artistsTableAdapter = new DataSetTableAdapters.ArtistsTableAdapter();
        //        DataSet dataSet = new DataSet();

        //        // TODO: This line of code loads data into the 'dataSet.Artists' table. You can move, or remove it, as needed.
        //        artistsTableAdapter.Fill(dataSet.Artists);

        //        DataTable artistTable = dataSet.Artists;
        //        string query = "name = '" + this.name + "'";
        //        DataRow[] rows = artistTable.Select(query);

        //        if (rows.Length > 0)
        //        {
        //            this.name = rows[0]["name"].ToString();
        //            this.a_spotify_uri = rows[0]["a_spotify_uri"].ToString();
        //            this.a_website = rows[0]["a_website"].ToString();
        //            this._a_profile_pic = (byte[])rows[0]["_a_profile_pic"];
        //            this.a_bio = rows[0]["a_bio"].ToString();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error Loading Artist: " + ex.Message);
        //    }
        //}
    }
}
