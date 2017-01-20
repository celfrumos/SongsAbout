using System;
using System.Collections.Generic;
using System.Linq;
using SongsAbout.Properties;
using SongsAbout.Classes;
using SongsAbout.Classes.Database;
using SongsAbout.Enums;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout.Controls;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Local;



namespace SongsAbout
{
    public static class Library
    {
        public static SongDatabase Database { get; private set; }
        public static SpotifyLocalAPI LocalAPI { get; private set; }
        /// <summary>
        /// The main entry point for the library.
        /// </summary>
        public static void Main()
        {
            try
            {
                ConnectSpotify();
                Database = new SongDatabase();
                SPanel.LargeQuery = false;
                LocalAPI = new SpotifyLocalAPI();
                Library.LocalAPI.Connect();
                var a = Library.Database.Artists["Jon Bellion"];
                Console.WriteLine(a.Name + " " + a.Uri);
                Application.Run(new Form());
            }
            catch (System.Resources.MissingManifestResourceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nStack Trace:\n{ex.StackTrace}\nClosing Program.", "Fatal Error Running Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Console.WriteLine("Closing Program");
            }
        }

        public async static void ConnectSpotify()
        {
            try
            {
                if (User.Default.SpotifyWebAPI == null)
                {
                    try
                    {
                        await Task.Run(() => UserSpotify.Authenticate());
                    }
                    catch (System.Resources.MissingManifestResourceException ex)
                    {
                        Console.WriteLine($"Error connecting to Spotify: {ex.Message}");
                        throw;
                    }
                    catch (SpotifyAuthError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error assigning user profile");
                    }
                }
                else
                {
                    MessageBox.Show("Profile Already Defined.");

                    UserSpotify.FetchProfile();
                    UserSpotify.FetchFollowedArtists();
                    UserSpotify.FetchProfilePic();
                    User.Default.Save();
                }
            }
            catch (SpotifyAuthError ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }


}
