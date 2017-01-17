using System;
using System.Collections.Generic;
using System.Linq;
using SongsAbout.Properties;
using SongsAbout.Classes;
using SongsAbout.Classes.Database;
using SongsAbout.Enums;
using System.Threading.Tasks;
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
        public static void main()
        {
            ConnectSpotify();
            Database = new SongDatabase();
            SPanel.LargeQuery = false;
            Library.LocalAPI = new SpotifyLocalAPI();
            Library.LocalAPI.Connect();
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
                        Console.WriteLine($"Error assigning user profile: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Profile Already Defined.");

                    UserSpotify.FetchProfile();
                    UserSpotify.FetchFollowedArtists();
                    UserSpotify.FetchProfilePic();
                    User.Default.Save();
                }
            }
            catch (SpotifyAuthError ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}