using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout;
using SongsAbout.Entities;
using SongsAbout.Properties;
using SongsAbout.Classes;
using SongsAbout.Classes.Database;
using SpotifyAPI.Local;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;

namespace LibraryTesterConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var s = Converter.GetFullAlbum(new SpotifyAlbum());
            Library.Initialize();
            var a = Library.Database.Artists["Jon Bellion"];
            Console.WriteLine(a.Name + " "+a.Uri);
            Console.ReadLine();
        }
    }
    public static class Library
    {
        public static SongDatabase Database { get; private set; }
        public static SpotifyLocalAPI LocalAPI { get; private set; }
        /// <summary>
        /// The main entry point for the library.
        /// </summary>
        public static void Initialize()
        {
            try
            {
               // ConnectSpotify();
                Database = new SongDatabase();
                //LocalAPI = new SpotifyLocalAPI();
                //Library.LocalAPI.Connect();
            }
            catch (System.Resources.MissingManifestResourceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\nStack Trace:\n{ex.StackTrace}\nClosing Program.", "Fatal Error Running Application");
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
                if (UserSpotify.WebAPI == null)
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
                        Console.WriteLine(ex.Message, "Error assigning user profile");
                    }
                }
                else
                {
                    Console.WriteLine("Profile Already Defined.");

                    UserSpotify.FetchProfile();
                    UserSpotify.FetchFollowedArtists();
                    UserSpotify.FetchProfilePic();
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
