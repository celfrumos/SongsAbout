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
