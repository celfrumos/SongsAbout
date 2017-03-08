using System;
using System.Collections.Generic;
using System.Linq;
using SongsAbout.Desktop.Properties;
using SongsAbout.Desktop.Database;
using SongsAbout.Enums;
using SongsAbout.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout.Controls;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Local;



namespace SongsAbout
{
    static class Program
    {
        public static SpotifyLocalAPI LocalAPI { get; private set; }
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
                ConnectSpotify();
                SPanel.LargeQuery = false;
                //  Program.LocalAPI = new SpotifyLocalAPI();
                // Program.LocalAPI.Connect();

                Application.Run(new AlbumDisplayForm());
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

        private async static void ConnectSpotifyAsync()
        {
            try
            {
                if (UserSpotify.WebAPI == null)
                {
                    try
                    {
                        // var task = 
                        await Task.Run(() => UserSpotify.AuthenticateAsync());
                        //  task.Wait();
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

                    // UserSpotify.FetchProfile();
                    //UserSpotify.FetchFollowedArtists();
                    //UserSpotify.FetchProfilePic();
                    //User.Default.Save();
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
        private static void ConnectSpotify()
        {
            try
            {
                if (UserSpotify.WebAPI == null)
                {
                    try
                    {
                        // var task = 
                        UserSpotify.Authenticate();
                        //  task.Wait();
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

                    // UserSpotify.FetchProfile();
                    //UserSpotify.FetchFollowedArtists();
                    //UserSpotify.FetchProfilePic();
                    //User.Default.Save();
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
