using System;
using System.Collections.Generic;
using System.Linq;
using SongsAbout.Properties;
using SongsAbout.Classes;
using SongsAbout.Classes.Database;
using SongsAbout.Enums;
using SongsAbout.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;



namespace SongsAbout
{
    static class Program
    {
        public static SongDatabase Database { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //   User.Default.Upgrade();
                ConnectSpotify();
                Database = new SongDatabase();

                //var search = UserSpotify.Search("A moon shaped pool", SpotifyAPI.Web.Enums.SearchType.Album);

                //var s = search.Albums.Items[0];
                // const string id ="6vuykQgDLUCiZ7YggIpLM9";
                //   var album = UserSpotify.WebAPI.GetAlbum(id);
                Application.Run(new Form1());
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

        private async static void ConnectSpotify()
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
