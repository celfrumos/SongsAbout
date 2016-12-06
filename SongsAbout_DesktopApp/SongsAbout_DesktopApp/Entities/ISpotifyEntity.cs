using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SpotifyAPI.Web.Models;
using SongsAbout.Enums;
using FullArtist = SpotifyAPI.Web.Models.FullArtist;


namespace SongsAbout.Entities
{
    public partial class FArtist : SpotifyAPI.Web.Models.FullArtist, ISpotifyFullEntity
    {
        public SpotifyEntityType SpotifyType { get { return SpotifyEntityType.FullArtist; } }
    }
    public partial class SArtist : SpotifyAPI.Web.Models.SimpleArtist, ISpotifyEntity
    {
        public SpotifyEntityType SpotifyType { get { return SpotifyEntityType.SimpleArtist; } }
    }
    public partial class FAlbum : SpotifyAPI.Web.Models.FullAlbum, ISpotifyFullEntity
    {
        public SpotifyEntityType SpotifyType { get { return SpotifyEntityType.FullAlbum; } }
    }
    public partial class SAlbum : SpotifyAPI.Web.Models.SimpleAlbum, ISpotifyEntity
    {
        public SpotifyEntityType SpotifyType { get { return SpotifyEntityType.SimpleAlbum; } }
    }
    public partial class FTrack : SpotifyAPI.Web.Models.FullTrack, ISpotifyEntity
    {
        public SpotifyEntityType SpotifyType { get { return SpotifyEntityType.FullTrack; } }
    }
    public partial class STrack : SpotifyAPI.Web.Models.SimpleTrack, ISpotifyEntity
    {
        public SpotifyEntityType SpotifyType { get { return SpotifyEntityType.SimpleTrack; } }
    }
    public partial class FPlaylist : SpotifyAPI.Web.Models.FullPlaylist, ISpotifyEntity
    {
        public SpotifyEntityType SpotifyType { get { return SpotifyEntityType.FullPlaylist; } }
    }
    public partial class SPlaylist : SpotifyAPI.Web.Models.SimplePlaylist, ISpotifyEntity
    {
        public SpotifyEntityType SpotifyType { get { return SpotifyEntityType.SimplePlaylist; } }
    }

    public interface ISpotifyEntity
    {
        string Name { get; set; }
        string Href { get; set; }
        string Id { get; set; }
        string Type { get; set; }
        string Uri { get; set; }
        SpotifyEntityType SpotifyType { get; }
    }

    public interface ISpotifyFullEntity : ISpotifyEntity
    {
        List<string> Genres { get; set; }
        List<SpotifyAPI.Web.Models.Image> Images { get; set; }
        Dictionary<string, string> ExternalUrls { get; set; }
        int Popularity { get; set; }
    }
}
