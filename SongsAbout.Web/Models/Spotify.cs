using System;
using System.Collections;
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
using System.Web.Mvc;

namespace SongsAbout.Web
{
    public static partial class Spotify
    {
        #region Constants
        private const string REDIRECT_URI = "http://localhost";
        private const int PORT = 8000;

        private const string DEFAULT_USER_ID = "rawdeg";
        private const string SINGIN_PLAYLIST_ID = "3rzuLmTVqB68cJR67jaaKh";

        private const string DIRECTORY_NAME = @"C:\Users\jdegr_000\Desktop\";
        private const string ARTISTS_FILENAME = DIRECTORY_NAME + "Artists.json";
        private const string ALBUMS_FILENAME = DIRECTORY_NAME + "Albums.json";
        private const string TRACKS_FILENAME = DIRECTORY_NAME + "Tracks.json";
        private const string AUDIO_FEATURES_FILENAME = DIRECTORY_NAME + "AudioFeatures.json";

        private const Scope DEFAULT_SCOPE =
            Scope.UserReadPrivate |
            Scope.UserReadEmail |
            Scope.PlaylistReadPrivate |
            Scope.UserLibraryRead |
            Scope.UserReadPrivate |
            Scope.UserFollowRead |
            Scope.UserReadBirthdate |
            Scope.UserTopRead |
            Scope.PlaylistModifyPrivate |
            Scope.PlaylistModifyPublic;

        #endregion

        #region Static Variables
        public static SpotifyWebAPI WebApi { get; private set; } = null;
        public static PublicProfile PublicProfile { get; private set; } = null;
        public static PrivateProfile PrivateProfile { get; private set; } = null;
        public static bool Authenticated { get; private set; } = false;

        public static string UserId => PrivateProfile?.Id;
        #endregion

        #region Authentication
        /// <summary>
        /// Initial Setup of USer Spotify Settings
        /// </summary>
        public static void Authenticate(string clientId = Secrets.Spotify.ClientId, Scope scope = DEFAULT_SCOPE, bool reAuthIfAlready = false)
        {
            if (!Authenticated || reAuthIfAlready)
            {
                try
                {
                    if (WebApi == null)
                    {
                        var webApiFactory = new WebAPIFactory
                        (
                            REDIRECT_URI,
                            PORT,
                            clientId,
                            scope
                            );

                        if (WebApi == null)
                        {
                            var getter = webApiFactory.GetWebApi();
                            getter.Wait();
                            WebApi = getter.Result;
                        }

                        Authenticated = true;
                        PrivateProfile = WebApi.GetPrivateProfile();
                        PublicProfile = WebApi.GetPublicProfile(UserId);
                    }
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
        }
        /// <summary>
        /// Initial Setup of USer Spotify Settings
        /// </summary>
        public static async void AuthenticateAsync(string clientId = Secrets.Spotify.ClientId, Scope scope = DEFAULT_SCOPE, bool reAuthIfAlready = false)
        {
            if (!Authenticated || reAuthIfAlready)
            {
                try
                {
                    if (WebApi == null)
                    {
                        var webApiFactory = new WebAPIFactory
                        (
                            REDIRECT_URI,
                            PORT,
                            clientId,
                           scope
                        );

                        WebApi = await webApiFactory.GetWebApi();
                    }

                    Authenticated = true;
                    PrivateProfile = await WebApi.GetPrivateProfileAsync();
                    PublicProfile = await WebApi.GetPublicProfileAsync(UserId);
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
        }

        #endregion

        #region Retrieval
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

        public static List<Album> GetArtistAlbums(string spotifyArtistId)
        {
            if (!Authenticated)
                Authenticate();
            var albums = WebApi.GetArtistsAlbums(spotifyArtistId);

            var res = new List<Album>(from a in albums.Items
                                      select Album.Convert(a.GetFullVersion(WebApi))
                                      );

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

        public static SearchItem Search(string q, SaEntityType type = SaEntityType.Any, int limit = 5, int offset = 0)
        {
            return Spotify.WebApi.SearchItems(q, type.GetSearchType(), limit, offset);
        }

        public async static Task<SearchItem> SearchAsync(string q, SaEntityType type = SaEntityType.Any, int limit = 5, int offset = 0)
        {
            return await Spotify.WebApi.SearchItemsAsync(q, type.GetSearchType(), limit, offset);
        }
        #endregion

        #region Serialization
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

        #region Seeding
        public async static void CallAndStoreSeedData()
        {
            List<SpotifyFullArtist> artists;
            List<SpotifyFullAlbum> albums;
            List<SpotifyFullTrack> tracks;
            List<AudioFeatures> audioFeatures;

            (artists, albums, tracks, audioFeatures) = await CallDataForSeedingAsync();

            StoreSeedData(ARTISTS_FILENAME, artists);
            StoreSeedData(ALBUMS_FILENAME, albums);
            StoreSeedData(TRACKS_FILENAME, tracks);
            StoreSeedData(AUDIO_FEATURES_FILENAME, audioFeatures);
        }

        public async static void StoreSeedData(string fileName, IEnumerable<ISpotifyObject> entities)
        {
            using (var writer = new StreamWriter(fileName))
            {
                await writer.WriteAsync(Spotify.GetJson(entities.ToArray()));
            }
        }

        public async static Task<(List<SpotifyFullArtist> Artists, List<SpotifyFullAlbum> Albums, List<SpotifyFullTrack> Tracks, List<AudioFeatures> Features)>
            CallDataForSeedingAsync(int trackLimit = 20)
        {
            return await Task.Run(() => CallDataForSeeding(trackLimit));
        }

        public static void SeedDatabase(EntityDbContext context)
        {
            try
            {
                if (!Spotify.Authenticated)
                    Spotify.Authenticate();

                //    Spotify.CallAndStoreSeedData();
                var artists = new Dictionary<string, int>();
                var albums = new Dictionary<string, int>();
                var tracks = new Dictionary<string, int>();

                var seed = Spotify.CallDataForSeeding();

                // Artists
                foreach (SpotifyFullArtist a in seed.Artists)
                {
                    try
                    {
                        if (!artists.ContainsKey(a.Name))
                        {
                            List<Picture> images = new List<Picture>();
                            Picture pic = null;
                            if (a.Images?.Count > 0)
                            {
                                for (int i = 0; i < a.Images.Count; i++)
                                {
                                    images.Add(context.Create(new Picture(a.Images[i], $"{a.Name}-{i}", SaEntityType.Artist)));
                                }
                                pic = images[0];
                            }
                            else
                                pic = null;


                            var ar = new Artist(a);
                            ar.Pictures = images;

                            Artist artist = context.Create<Artist>(ar);


                            artists.Add(artist.Name, artist.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                context.SaveChanges();
                // Albums
                foreach (SpotifyFullAlbum al in seed.Albums)
                {
                    try
                    {
                        if (!albums.ContainsKey(al.Id))
                        {
                            List<Picture> images = new List<Picture>();
                            Picture pic = null;
                            if (al.Images?.Count > 0)
                            {
                                for (int i = 0; i < al.Images.Count; i++)
                                {
                                    images.Add(context.Create(new Picture(al.Images[i], $"{al.Name}-{i}", SaEntityType.Album)));
                                }
                                pic = images[0];
                            }
                            else
                                pic = null;

                            int coverid = pic?.Id ?? 0;
                            string artistName = al.Artists.Count > 0 ? al.Artists[0].Name : null;

                            int artistId = 0;

                            if (artistName != null && artists.ContainsKey(artistName))
                            {
                                artistId = artists[artistName];
                            }
                            var alb = new Album(al) { ArtistId = artistId };
                            alb.Pictures = images;
                            var album = context.Create<Album>(alb);

                            albums.Add(album.Name, album.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                context.SaveChanges();
                // Tracks
                foreach (SpotifyFullTrack t in seed.Tracks)
                {
                    try
                    {
                        if (!tracks.ContainsKey(t.Name))
                        {
                            var feat = seed.Features.Where(a => a.Id == t.Id).FirstOrDefault();

                            int artistId = 0,
                                albumId = 0;
                            string artistName = t.Artists.Count > 0 ? t.Artists[0].Name : null;

                            if (artistName != null && artists.ContainsKey(artistName))
                            {
                                artistId = artists[artistName];
                            }
                            if (t.Album?.Name != null && albums.ContainsKey(t.Album.Name))
                            {
                                albumId = albums[t.Album.Name];
                            }

                            var tr = new Track(t, feat, artistId, albumId);
                            tr.Artist = context.Get<Artist>(artistId);
                            tr.Album = context.Get<Album>(albumId);
                            Track track = context.Create<Track>(tr);

                            tracks.Add(track.Name, track.Id);

                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static (List<SpotifyFullArtist> Artists, List<SpotifyFullAlbum> Albums, List<SpotifyFullTrack> Tracks, List<AudioFeatures> Features) CallDataForSeeding(int trackLimit = 20)
        {
            var artists = new Dictionary<string, SpotifyFullArtist>();
            var albums = new Dictionary<string, SpotifyFullAlbum>();
            var tracksToWrite = new Dictionary<string, SpotifyFullTrack>();
            var audioFeatures = new Dictionary<string, AudioFeatures>();

            var tracks = Spotify.GetSavedTracks();


            for (int i = 0; i < 10; i++)
            {
                SpotifyFullAlbum album = null;
                try
                {
                    album = tracks[i].Album.GetFullVersion(Spotify.WebApi);

                    if (!albums.ContainsKey(album.Name))
                        albums.Add(album.Name, album.GetFullVersion(Spotify.WebApi));

                    album.Artists.ForEach(a =>
                    {
                        if (!artists.ContainsKey(a.Name))
                            artists.Add(a.Name, a.GetFullVersion(Spotify.WebApi));


                    });
                }
                catch (Exception ex)
                {
                    ConsoleEx.WriteException(ex);
                    album = null;
                }
                if (album != null)
                {
                    var albTracks = Spotify.WebApi.GetAlbumTracks(album.Id);

                    foreach (SpotifyTrack track in albTracks.Items)
                    {
                        try
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
                        catch (Exception ex)
                        {
                            ConsoleEx.WriteException(ex);
                            throw;
                        }
                    }
                }
            }
            var lists =
                (artists.Select(a => a.Value).ToList(),
                albums.Select(a => a.Value).ToList(),
                tracksToWrite.Select(a => a.Value).ToList(),
                audioFeatures.Select(a => a.Value).ToList());
            return lists;

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

        #endregion

        #endregion
    }
}