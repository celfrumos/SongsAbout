using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web;
using SongsAbout.Web.Models;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace SongsAbout.Web
{
    public static class Spotify
    {
        private const string REDIRECT_URI = "http://localhost";
        private const int PORT = 8000;

        private const string DIRECTORY_NAME = @"C:\Users\jdegr_000\Desktop\";
        private const string ARTISTS_FILENAME = DIRECTORY_NAME + "Artists.json";
        private const string ALBUMS_FILENAME = DIRECTORY_NAME + "Albums.json";
        private const string TRACKS_FILENAME = DIRECTORY_NAME + "Tracks.json";
        private const string AUDIO_FEATURES_FILENAME = DIRECTORY_NAME + "AudioFeatures.json";

        public static SpotifyWebAPI WebApi { get; private set; }

        public static bool Authenticated { get; private set; }

        /// <summary>
        /// Initial Setup of USer Spotify Settings
        /// </summary>
        public static void Authenticate(string clientId = null)
        {
            try
            {
                clientId = clientId ?? Secrets.Spotify.ClientId;
                WebAPIFactory webApiFactory = new WebAPIFactory(
                    REDIRECT_URI,
                    PORT,
                    clientId,
                    Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead |
                    Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead | Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic);

                if (WebApi == null)
                {
                    var getter = webApiFactory.GetWebApi();
                    getter.Wait();
                    WebApi = getter.Result;
                }

                Authenticated = true;
            }
            catch (SpotifyException ex)
            {
                throw new SpotifyAuthError(inner: ex);
            }
            catch (System.Resources.MissingManifestResourceException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                var e = new SpotifyAuthError(ex.Message);
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }

        /// <summary>
        /// Returns a list of User's saved tracks
        /// </summary>
        /// <returns></returns>
        public static List<SpotifyFullTrack> GetSavedTracks(int limit = 50)
        {
            if (!Authenticated)
                Authenticate();
            var savedTracks = new Paging<SavedTrack>();
            var list = new List<SpotifyFullTrack>();
            try
            {
                savedTracks = WebApi.GetSavedTracks();

                list = savedTracks.Items.Select(track => track.Track).ToList();

                while (savedTracks.Next != null && list.Count < limit)
                {
                    savedTracks = WebApi.GetSavedTracks(20, savedTracks.Offset + savedTracks.Limit);
                    list.AddRange(savedTracks.Items.Select(track => track.Track));

                }

                return list;
            }
            catch (Exception ex)
            {
                SpotifyException exception = new SpotifyException(ex.Message);

                throw exception;
            }
        }

        public async static void CallAndStoreSeedData()
        {
            List<SpotifyFullArtist> artists;
            List<SpotifyFullAlbum> albums;
            List<SpotifyFullTrack> tracks;
            List<AudioFeatures> audioFeatures;

            (artists, albums, tracks, audioFeatures) = await CallDataForSeedingAsync();

            using (var writer = new StreamWriter(ARTISTS_FILENAME))
            {
                await writer.WriteAsync(Spotify.GetJson(artists.ToArray()));
            }
            using (var writer = new StreamWriter(ALBUMS_FILENAME))
            {
                await writer.WriteAsync(Spotify.GetJson(albums.ToArray()));
            }
            using (var writer = new StreamWriter(TRACKS_FILENAME))
            {
                await writer.WriteAsync(Spotify.GetJson(tracks.ToArray()));
            }
            using (var writer = new StreamWriter(AUDIO_FEATURES_FILENAME))
            {
                await writer.WriteAsync(Spotify.GetJson(audioFeatures.ToArray()));
            }
        }
        public async static Task<(List<SpotifyFullArtist> Artists, List<SpotifyFullAlbum> Albums, List<SpotifyFullTrack> Tracks, List<AudioFeatures> Features)> CallDataForSeedingAsync(int trackLimit = 20)
        {
            var artists = new Dictionary<string, SpotifyFullArtist>();
            var albums = new Dictionary<string, SpotifyFullAlbum>();
            var tracksToWrite = new Dictionary<string, SpotifyFullTrack>();
            var audioFeatures = new Dictionary<string, SpotifyAPI.Web.Models.AudioFeatures>();

            var tracks = Spotify.GetSavedTracks();


            for (int i = 0; i < 10; i++)
            {
                var album = await tracks[i].Album.GetFullVersionAsync(Spotify.WebApi);

                if (!albums.ContainsKey(album.Name))
                    albums.Add(album.Name, album.GetFullVersion(Spotify.WebApi));

                album.Artists.ForEach(a =>
                {
                    if (!artists.ContainsKey(a.Name))
                        artists.Add(a.Name, a.GetFullVersion(Spotify.WebApi));

                });

                var albTracks = await Spotify.WebApi.GetAlbumTracksAsync(album.Id);


                foreach (var track in albTracks.Items)
                {
                    if (tracksToWrite.Count >= trackLimit)
                        break;

                    var trackArtists = track.Artists;
                    var trackFeatures = Spotify.WebApi.GetAudioFeatures(track.Id);

                    if (!audioFeatures.ContainsKey(track.Id))
                        audioFeatures.Add(track.Id, trackFeatures);

                    track.Artists.ForEach(a =>
                    {
                        if (!artists.ContainsKey(a.Name))
                            artists.Add(a.Name, a.GetFullVersion(Spotify.WebApi));
                    });

                    if (!tracksToWrite.ContainsKey(track.Name))
                        tracksToWrite.Add(track.Name, track.FullVersion(Spotify.WebApi));
                }

            }
            return (artists.Select(a => a.Value).ToList(), albums.Select(a => a.Value).ToList(), tracksToWrite.Select(a => a.Value).ToList(), audioFeatures.Select(a => a.Value).ToList());

        }

        public static (List<SpotifyFullArtist> Artists, List<SpotifyFullAlbum> Albums, List<SpotifyFullTrack> Tracks, List<AudioFeatures> Features) CallDataForSeeding(int trackLimit = 20)
        {
            var artists = new Dictionary<string, SpotifyFullArtist>();
            var albums = new Dictionary<string, SpotifyFullAlbum>();
            var tracksToWrite = new Dictionary<string, SpotifyFullTrack>();
            var audioFeatures = new Dictionary<string, SpotifyAPI.Web.Models.AudioFeatures>();

            var tracks = Spotify.GetSavedTracks();


            for (int i = 0; i < 10; i++)
            {
                var album = tracks[i].Album.GetFullVersion(Spotify.WebApi);

                if (!albums.ContainsKey(album.Name))
                    albums.Add(album.Name, album.GetFullVersion(Spotify.WebApi));

                album.Artists.ForEach(a =>
                {
                    if (!artists.ContainsKey(a.Name))
                        artists.Add(a.Name, a.GetFullVersion(Spotify.WebApi));

                });

                var albTracks = Spotify.WebApi.GetAlbumTracks(album.Id);


                foreach (var track in albTracks.Items)
                {
                    if (tracksToWrite.Count >= trackLimit)
                        break;

                    var trackArtists = track.Artists;
                    var trackFeatures = Spotify.WebApi.GetAudioFeatures(track.Id);

                    if (!audioFeatures.ContainsKey(track.Id))
                        audioFeatures.Add(track.Id, trackFeatures);

                    track.Artists.ForEach(a =>
                    {
                        if (!artists.ContainsKey(a.Name))
                            artists.Add(a.Name, a.GetFullVersion(Spotify.WebApi));
                    });

                    if (!tracksToWrite.ContainsKey(track.Name))
                        tracksToWrite.Add(track.Name, track.FullVersion(Spotify.WebApi));
                }

            }
            return (artists.Select(a => a.Value).ToList(), albums.Select(a => a.Value).ToList(), tracksToWrite.Select(a => a.Value).ToList(), audioFeatures.Select(a => a.Value).ToList());

        }


        public static (List<SpotifyFullArtist> Artists, List<SpotifyFullAlbum> Albums, List<SpotifyFullTrack> Tracks, List<AudioFeatures> Features) GetStoredSeedData()
        {

            var artists = Spotify.GetStoredSeedData<SpotifyFullArtist>();
            var albums = Spotify.GetStoredSeedData<SpotifyFullAlbum>();
            var tracks = Spotify.GetStoredSeedData<SpotifyFullTrack>();
            var features = Spotify.GetStoredSeedData<AudioFeatures>();

            return (artists, albums, tracks, features);
        }


        private static List<T> GetStoredSeedData<T>()
        {
            var type = typeof(T);
            List<T> results = new List<T>();

            try
            {
                if (type == typeof(SpotifyFullArtist))
                {
                    results = new List<T>(ReadSeedObjects<SpotifyFullArtist>(ARTISTS_FILENAME) as IEnumerable<T>);
                }
                else if (type == typeof(SpotifyFullAlbum))
                {
                    results = new List<T>(ReadSeedObjects<SpotifyFullAlbum>(ALBUMS_FILENAME) as IEnumerable<T>);
                }
                else if (type == typeof(SpotifyFullTrack))
                {
                    results = new List<T>(ReadSeedObjects<SpotifyFullTrack>(TRACKS_FILENAME) as IEnumerable<T>);
                }
                else if (type == typeof(AudioFeatures))
                {
                    results = new List<T>(ReadSeedObjects<AudioFeatures>(AUDIO_FEATURES_FILENAME) as IEnumerable<T>);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return results;
        }

        private static IEnumerable<T> ReadSeedObjects<T>(string filename)
        {
            dynamic objects = null;
            if (filename != null)
            {
                try
                {
                    using (var reader = new StreamReader(filename))
                    {
                        using (var jsonReader = new JsonTextReader(reader))
                        {

                            objects = JsonSerializer.Deserialize<T[]>(jsonReader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return objects;
        }

        public static List<Album> GetArtistAlbums(string spotifyArtistId)
        {
            if (!Authenticated)
                Authenticate();
            var albums = WebApi.GetArtistsAlbums(spotifyArtistId);

            var res = new List<Album>(from a in albums.Items
                                      select Album.Convert(a.GetFullVersion(WebApi))
                                      );

            //while (albums.HasNextPage())
            //{
            //    albums = albums.dow
            //    res.AddRange(from a in albums.Items
            //                 select (Album)a.GetFullVersion(WebApi));

            //}
            return res;
        }
        public static List<Track> GetAllAlbumTracks(string spotifyAlbumId)
        {
            if (!Authenticated)
                Authenticate();

            var res = new List<Track>();
            var trackPage = Spotify.WebApi.GetAlbumTracks(spotifyAlbumId, 30);

            res.AddRange(from t in trackPage.Items
                         select new Track(t));

            return res;
        }
        public static List<Track> GetAllArtistTracks(string spotifyArtistId)
        {
            var albums = GetArtistAlbums(spotifyArtistId);
            var tracks = new List<Track>();
            foreach (var album in albums)
            {
                tracks.AddRange(GetAllAlbumTracks(album.SpotifyId));
            }
            return tracks;
        }

        public static JsonSerializer JsonSerializer { get; set; } = new JsonSerializer();

        public static string GetJson(object entity)
        {
            string jsonStr = "";
            using (var writer = new StringWriter())
            {
                JsonSerializer.Serialize(writer, entity);
                jsonStr = writer.ToString();
            }
            return jsonStr;
        }
        public static async Task<string> GetJsonAsync(object entity)
        {
            string jsonStr = "";
            using (var writer = new StringWriter())
            {
                await Task.Run(() => JsonSerializer.Serialize(writer, entity));
                jsonStr = writer.ToString();
            }
            return jsonStr;
        }
    }
}