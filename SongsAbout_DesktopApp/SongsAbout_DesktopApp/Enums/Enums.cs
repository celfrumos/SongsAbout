using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web.Enums;


namespace SongsAbout.Enums
{
    public static class Flag
    {
        public static class DB
        {
            public static bool HasFlag(DbEntityType existingFlag, DbEntityType targetFlag)
            {
                return (existingFlag & targetFlag) == targetFlag;
            }
            public static DbEntityType ToggleFlag(DbEntityType existingFlag, DbEntityType targetFlag)
            {
                return existingFlag ^ targetFlag;
            }

            public static DbEntityType SetFlag(DbEntityType existingFlag, DbEntityType targetFlag)
            {
                return existingFlag | targetFlag;
            }

            public static DbEntityType UnsetFlag(DbEntityType existingFlag, DbEntityType targetFlag)
            {
                return existingFlag & (~targetFlag);
            }
        }
        public static class Spotify
        {
            public static class EntityType
            {
                public static bool HasFlag(SpotifyEntityType existingFlag, SpotifyEntityType targetFlag)
                {
                    return (existingFlag & targetFlag) == targetFlag;
                }
                public static SpotifyEntityType ToggleFlag(SpotifyEntityType existingFlag, SpotifyEntityType targetFlag)
                {
                    return existingFlag ^ targetFlag;
                }

                public static SpotifyEntityType SetFlag(SpotifyEntityType existingFlag, SpotifyEntityType targetFlag)
                {
                    return existingFlag | targetFlag;
                }

                public static SpotifyEntityType UnsetFlag(SpotifyEntityType existingFlag, SpotifyEntityType targetFlag)
                {
                    return existingFlag & (~targetFlag);
                }
            }
            public static class Search
            {
                public static bool HasFlag(SpotifyAPI.Web.Enums.SearchType existingFlag, SpotifyAPI.Web.Enums.SearchType targetFlag)
                {
                    return (existingFlag & targetFlag) == targetFlag;
                }
                public static SpotifyAPI.Web.Enums.SearchType ToggleFlag(SpotifyAPI.Web.Enums.SearchType existingFlag, SpotifyAPI.Web.Enums.SearchType targetFlag)
                {
                    return existingFlag ^ targetFlag;
                }

                public static SpotifyAPI.Web.Enums.SearchType SetFlag(SpotifyAPI.Web.Enums.SearchType existingFlag, SpotifyAPI.Web.Enums.SearchType targetFlag)
                {
                    return existingFlag | targetFlag;
                }

                public static SearchType UnsetFlag(SearchType existingFlag, SearchType targetFlag)
                {
                    return existingFlag & (~targetFlag);
                }
            }
            public static class AlbumType
            {
                public static bool HasFlag(SpotifyAPI.Web.Enums.AlbumType existingFlag, SpotifyAPI.Web.Enums.AlbumType targetFlag)
                {
                    return (existingFlag & targetFlag) == targetFlag;
                }
                public static SpotifyAPI.Web.Enums.AlbumType ToggleFlag(SpotifyAPI.Web.Enums.AlbumType existingFlag, SpotifyAPI.Web.Enums.AlbumType targetFlag)
                {
                    return existingFlag ^ targetFlag;
                }

                public static SpotifyAPI.Web.Enums.AlbumType SetFlag(SpotifyAPI.Web.Enums.AlbumType existingFlag, SpotifyAPI.Web.Enums.AlbumType targetFlag)
                {
                    return existingFlag | targetFlag;
                }

                public static SpotifyAPI.Web.Enums.AlbumType UnsetFlag(SpotifyAPI.Web.Enums.AlbumType existingFlag, SpotifyAPI.Web.Enums.AlbumType targetFlag)
                {
                    return existingFlag & (~targetFlag);
                }
            }
            public static class FollowType
            {
                public static bool HasFlag(SpotifyAPI.Web.Enums.FollowType existingFlag, SpotifyAPI.Web.Enums.FollowType targetFlag)
                {
                    return (existingFlag & targetFlag) == targetFlag;
                }
                public static SpotifyAPI.Web.Enums.FollowType ToggleFlag(SpotifyAPI.Web.Enums.FollowType existingFlag, SpotifyAPI.Web.Enums.FollowType targetFlag)
                {
                    return existingFlag ^ targetFlag;
                }

                public static SpotifyAPI.Web.Enums.FollowType SetFlag(SpotifyAPI.Web.Enums.FollowType existingFlag, SpotifyAPI.Web.Enums.FollowType targetFlag)
                {
                    return existingFlag | targetFlag;
                }

                public static SpotifyAPI.Web.Enums.FollowType UnsetFlag(SpotifyAPI.Web.Enums.FollowType existingFlag, SpotifyAPI.Web.Enums.FollowType targetFlag)
                {
                    return existingFlag & (~targetFlag);
                }
            }
            public static class Scope
            {
                public static bool HasFlag(SpotifyAPI.Web.Enums.Scope existingFlag, SpotifyAPI.Web.Enums.Scope targetFlag)
                {
                    return (existingFlag & targetFlag) == targetFlag;
                }
                public static SpotifyAPI.Web.Enums.Scope ToggleFlag(SpotifyAPI.Web.Enums.Scope existingFlag, SpotifyAPI.Web.Enums.Scope targetFlag)
                {
                    return existingFlag ^ targetFlag;
                }

                public static SpotifyAPI.Web.Enums.Scope SetFlag(SpotifyAPI.Web.Enums.Scope existingFlag, SpotifyAPI.Web.Enums.Scope targetFlag)
                {
                    return existingFlag | targetFlag;
                }

                public static SpotifyAPI.Web.Enums.Scope UnsetFlag(SpotifyAPI.Web.Enums.Scope existingFlag, SpotifyAPI.Web.Enums.Scope targetFlag)
                {
                    return existingFlag & (~targetFlag);
                }
            }
            public static class TimeRangeType
            {
                public static bool HasFlag(SpotifyAPI.Web.Enums.TimeRangeType existingFlag, SpotifyAPI.Web.Enums.TimeRangeType targetFlag)
                {
                    return (existingFlag & targetFlag) == targetFlag;
                }
                public static SpotifyAPI.Web.Enums.TimeRangeType ToggleFlag(SpotifyAPI.Web.Enums.TimeRangeType existingFlag, SpotifyAPI.Web.Enums.TimeRangeType targetFlag)
                {
                    return existingFlag ^ targetFlag;
                }

                public static SpotifyAPI.Web.Enums.TimeRangeType SetFlag(SpotifyAPI.Web.Enums.TimeRangeType existingFlag, SpotifyAPI.Web.Enums.TimeRangeType targetFlag)
                {
                    return existingFlag | targetFlag;
                }

                public static SpotifyAPI.Web.Enums.TimeRangeType UnsetFlag(SpotifyAPI.Web.Enums.TimeRangeType existingFlag, SpotifyAPI.Web.Enums.TimeRangeType targetFlag)
                {
                    return existingFlag & (~targetFlag);
                }
            }
        }
    }

    [Flags]
    public enum DbEntityType : ulong
    {
        /// <summary>
        /// Doesn't match to any table in the database
        /// </summary>
        None = 0,

        /// <summary>
        /// Matches to Artists table
        /// </summary>
        Artist = 1,

        /// <summary>
        /// Matches to Albums table
        /// </summary>
        Album = 2,

        /// <summary>
        /// Matches to Tracks table
        /// </summary>
        Track = 4,


        /// <summary>
        /// Matches to Genres table
        /// </summary>
        Genre = 8,
        /// <summary>
        /// Matches to Tags table
        /// </summary>
        Tag = 16,

        /// <summary>
        /// Matches to Lists table
        /// </summary>
        Playlist = 32,

        /// <summary>
        /// Matches to either the Artists, Albums, or Tracks table
        /// </summary>
        Integral = Artist | Album | Track,

        /// <summary>
        /// Matches to either the Genres, Tags, or Lists table
        /// </summary>
        Grouping = Genre | Tag | Playlist


    }

    [Flags]
    public enum SpotifyEntityType : ulong
    {

        None = 0,
        FullArtist = 1,
        FullAlbum = 2,
        FullTrack = 4,
        FullPlaylist = 8,

        SimpleArtist = 16,
        SimpleAlbum = 32,
        SimpleTrack = 64,
        SimplePlaylist = 128,

        /// <summary>
        /// Either a FullArtist or SimpleArtist
        /// </summary>
        Artist = FullArtist | SimpleArtist,
        Track = FullTrack | SimpleTrack,
        Album = FullAlbum | SimpleAlbum,
        Playlist = FullPlaylist | SimplePlaylist,

        FullType = FullArtist | FullAlbum | FullTrack | FullPlaylist,
        SimpleType = SimpleArtist | SimpleAlbum | SimpleTrack | SimplePlaylist,

        SavedItem = 256,

        SavedTrack = Track | SavedItem,
        SavedAlbum = Album | SavedItem,
        PlaylistTrack = Playlist | Track,

    }

}

