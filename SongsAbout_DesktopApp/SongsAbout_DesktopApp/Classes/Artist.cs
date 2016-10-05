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

namespace SongsAbout_DesktopApp
{

    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    public partial class Artist
    {
        /// <summary>
        /// Submit Changes to the Database
        /// </summary>
        public void Save()
        {
            try
            {
                if (this.a_name != null)
                {
                    if (!Exists(this.a_name))
                    {
                        try
                        {
                            using (DataClasses1DataContext context = new DataClasses1DataContext())
                            {
                                context.Artists.InsertOnSubmit(this);
                                context.SubmitChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            string msg = $"Error Saving Artist: {ex.Message}";
                            Console.WriteLine(msg);
                            throw new Exception(msg);
                        }
                    }
                    else
                    {
                        string msg = $"An artist named '{a_name}' already exists. To update that artist, use Artist a = Artist.Load(a_name)";

                        Console.WriteLine(msg);
                        //throw new Exception ()
                    }
                }
                else
                {
                    throw new Exception("Artist name cannot be null.");
                }

            }
            catch (Exception ex)
            {
                string msg = $"Error updating artist: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public static bool Exists(string name)
        {
            try
            {
                formatName(ref name);
                string aquery = $"SELECT * FROM Artists WHERE a_name = '{name}'";
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var artists = db.ExecuteQuery<Artist>(aquery);
                    int count = 0;
                    foreach (Artist artist in artists)
                    {
                        count++;
                    }

                    return (count > 0);
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error verifying if artist: '{name}' exists: {ex.Message}";
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

        internal void Update(SimpleArtist artist)
        {
            try
            {
                FullArtist a = User.Default.SpotifyWebAPI.GetArtist(artist.Id);
                this.Update(a);
            }
            catch (Exception ex)
            {
                string msg = $"Error updating artist '{artist.Name}': {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        public void Update(FullArtist artist)
        {
            try
            {
                this.a_name = artist.Name;
                this.a_spotify_uri = artist.Uri;
                this.a_website = artist.Href;
                this.UpdateProfilePic(artist);
                this.a_website = artist.Href;
            }
            catch (Exception ex)
            {
                string msg = $"Error Updating artist: '{artist.Name}': {ex.Message}'";
                Console.WriteLine(msg);
                throw new Exception(msg);
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

        public static Artist Load(string a_name)
        {
            try
            {
                formatName(ref a_name);
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    string aquery = $"SELECT * FROM Artists WHERE a_name = '{a_name}'";
                    var artists = db.ExecuteQuery<Artist>(aquery);
                    int count = 0;
                    foreach (Artist artist in artists)
                    {
                        count++;
                        if (count == 1)
                        {
                            return artist;
                        }
                    }

                    throw new Exception($"No artist with name '{a_name}' found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Loading artist '{a_name}': {ex.Message}");
            }
        }

        private void oldLoad()
        {
            try
            {
                BindingSource artistsBindingSource = new BindingSource();
                DataSetTableAdapters.ArtistsTableAdapter artistsTableAdapter = new DataSetTableAdapters.ArtistsTableAdapter();
                DataSet dataSet = new DataSet();

                // TODO: This line of code loads data into the 'dataSet.Artists' table. You can move, or remove it, as needed.
                artistsTableAdapter.Fill(dataSet.Artists);

                DataTable artistTable = dataSet.Artists;
                string query = "a_name = '" + this.a_name + "'";
                DataRow[] rows = artistTable.Select(query);

                if (rows.Length > 0)
                {
                    this.a_name = rows[0]["a_name"].ToString();
                    this.a_spotify_uri = rows[0]["a_spotify_uri"].ToString();
                    this.a_website = rows[0]["a_website"].ToString();
                    this._a_profile_pic = (byte[])rows[0]["_a_profile_pic"];
                    this.a_bio = rows[0]["a_bio"].ToString();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Loading Artist: " + ex.Message);
            }
        }
    }
}
