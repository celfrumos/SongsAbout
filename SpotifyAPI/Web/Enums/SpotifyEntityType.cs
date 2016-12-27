using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Enums
{
    [Flags]
    public enum SpotifyEntityType : ulong
    {

        None = 0,

        BaseArtist = 1,
        BaseAlbum = 2,
        BaseTrack = 4,
        BasePlaylist = 8,

        FullArtist = 16,
        FullAlbum = 32,
        FullTrack = 64,
        FullPlaylist = 128,

        /// <summary>
        /// Either a FullArtist or SimpleArtist
        /// </summary>
        Artist = FullArtist | BaseArtist,
        Track = FullTrack | BaseTrack,
        Album = FullAlbum | BaseAlbum,
        Playlist = FullPlaylist | BasePlaylist,

        FullType = FullArtist | FullAlbum | FullTrack | FullPlaylist,
        SimpleType = BaseArtist | BaseAlbum | BaseTrack | BasePlaylist,

        SavedItem = 256,

        SavedTrack = Track | SavedItem,
        SavedAlbum = Album | SavedItem,
        PlaylistTrack = Playlist | Track,

    }

}
