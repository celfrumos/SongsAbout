using SpotifyAPI.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public enum SaEntityType
    {
        Artist = 0,
        Album = 1,
        Track = 2,
        Topic = 4,
        Genre = 8,
        Keyword = 16,
        Playlist = 32,
        Any = Artist | Album | Track | Topic | Genre | Keyword | Playlist
    }

    public static class SaEntityTypeEnumExtensions
    {
        public static bool HasFlag(this SaEntityType type, SaEntityType target)
        {
            return (type == SaEntityType.Any || (type & target) == target);
        }

        public static Type GetSystemType(this SaEntityType type)
        {
            switch (type)
            {
                case SaEntityType.Artist:
                    return typeof(Artist);
                case SaEntityType.Album:
                    return typeof(Album);
                case SaEntityType.Track:
                    return typeof(Track);
                case SaEntityType.Topic:
                    return typeof(Topic);
                case SaEntityType.Genre:
                    return typeof(Genre);
                case SaEntityType.Keyword:
                    return typeof(Keyword);
                case SaEntityType.Any:
                    return typeof(ISaEntity);
                default:
                    return typeof(ISaEntity);
            }
        }
        public static Type[] GetTypes(this SaEntityType type)
        {
            var types = new List<Type>();
            if (type.HasFlag(SaEntityType.Artist))
                types.Add(typeof(Artist));

            if (type.HasFlag(SaEntityType.Album))
                types.Add(typeof(Album));

            if (type.HasFlag(SaEntityType.Track))
                types.Add(typeof(Track));

            if (type.HasFlag(SaEntityType.Topic))
                types.Add(typeof(Topic));

            if (type.HasFlag(SaEntityType.Genre))
                types.Add(typeof(Genre));

            if (type.HasFlag(SaEntityType.Keyword))
                types.Add(typeof(Genre));

            return types.ToArray();
        }

        public static SearchType GetSearchType(this SaEntityType type)
        {
            switch (type)
            {
                case SaEntityType.Artist:
                    return SearchType.Artist;
                case SaEntityType.Album:
                    return SearchType.Album;
                case SaEntityType.Track:
                    return SearchType.Track;
                case SaEntityType.Any:
                    return SearchType.All;
                default:
                    return SearchType.All;
            }
        }
        public static SaEntityType GetDbEntityType(this SpotifyEntityType type)
        {
            switch (type)
            {
                case SpotifyEntityType.Artist:
                    return SaEntityType.Artist;

                case SpotifyEntityType.BaseArtist:
                    return SaEntityType.Artist;

                case SpotifyEntityType.FullArtist:
                    return SaEntityType.Artist;

                case SpotifyEntityType.Album:
                    return SaEntityType.Album;

                case SpotifyEntityType.BaseAlbum:
                    return SaEntityType.Album;

                case SpotifyEntityType.FullAlbum:
                    return SaEntityType.Album;

                case SpotifyEntityType.SavedAlbum:
                    return SaEntityType.Album;

                case SpotifyEntityType.BaseTrack:
                    return SaEntityType.Track;

                case SpotifyEntityType.FullTrack:
                    return SaEntityType.Track;

                case SpotifyEntityType.SavedTrack:
                    return SaEntityType.Track;

                case SpotifyEntityType.BasePlaylist:
                    return SaEntityType.Playlist;

                case SpotifyEntityType.FullPlaylist:
                    return SaEntityType.Playlist;

                case SpotifyEntityType.Track:
                    return SaEntityType.Track;

                case SpotifyEntityType.Playlist:
                    return SaEntityType.Playlist;

                case SpotifyEntityType.PlaylistTrack:
                    return SaEntityType.Track;

                default:
                    return SaEntityType.Any;
            }
        }

        public static Type GetSystemType(this SpotifyEntityType type)
        {
            return GetSystemType(type.GetDbEntityType());
        }
    }

}