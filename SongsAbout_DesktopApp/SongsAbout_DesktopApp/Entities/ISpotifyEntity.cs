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
        public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.FullArtist; } }
        public DbEntityType DbEntityType { get { return DbEntityType.Artist; } }
        public FArtist() : base()
        {
        }
        public FArtist(FullArtist artist)
        {
            this.ExternalUrls = artist.ExternalUrls;
            this.Followers = artist.Followers;
            this.Genres = artist.Genres;
            this.Href = artist.Href;
            this.Id = artist.Id;
            this.Images = artist.Images;
            this.Name = artist.Name;
            this.Popularity = artist.Popularity;
            this.Type = artist.Type;
            this.Uri = artist.Uri;
        }
        public static FArtist Convert(FullArtist artist)
        {
            return new FArtist(artist);
        }
    }
    public partial class SArtist : SpotifyAPI.Web.Models.SimpleArtist, ISpotifySimpleEntity
    {
        public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.SimpleArtist; } }
        public DbEntityType DbEntityType { get { return DbEntityType.Artist; } }
        private SimpleArtist _base;
        public SArtist(SimpleArtist artist)
        {
            this._base = artist;
            this.Name = artist.Name;
            this.Type = artist.Type;
            this.Uri = artist.Uri;
            this.Id = artist.Id;
            this.Href = artist.Href;
            this.ExternalUrls = artist.ExternalUrls;
        }
        public static SArtist Convert(SimpleArtist artist)
        {
            return new SArtist(artist);
        }
        public ISpotifyFullEntity FullVersion()
        {
            return (ISpotifyFullEntity)(new FArtist(Classes.Converter.GetFullArtist(_base)));
        }
    }
    public partial class FAlbum : SpotifyAPI.Web.Models.FullAlbum, ISpotifyFullEntity
    {
        public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.FullAlbum; } }
        public DbEntityType DbEntityType { get { return DbEntityType.Album; } }
        public FAlbum(FullAlbum album)
        {
            this.AlbumType = album.AlbumType;
            this.Artists = album.Artists;
            this.AvailableMarkets = album.AvailableMarkets;
            this.Copyrights = album.Copyrights;
            this.ExternalIds = album.ExternalIds;
            this.Href = album.Href;
            this.Id = album.Id;
            this.Images = album.Images;
            this.Name = album.Name;
            this.Popularity = album.Popularity;
            this.ReleaseDate = album.ReleaseDate;
            this.ReleaseDatePrecision = album.ReleaseDatePrecision;
            this.Type = album.Type;
            this.Tracks = album.Tracks;
            this.Uri = album.Uri;
        }
        public static FAlbum Convert(FullAlbum album)
        {
            return new FAlbum(album);
        }
    }
    public partial class SAlbum : SpotifyAPI.Web.Models.SimpleAlbum, ISpotifySimpleEntity
    {
        public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.SimpleAlbum; } }
        public DbEntityType DbEntityType { get { return DbEntityType.Album; } }
        private SimpleAlbum _base;
        public SAlbum(SimpleAlbum album)
        {
            this._base = album;
            this.AlbumType = album.AlbumType;
            this.AvailableMarkets = album.AvailableMarkets;
            this.Href = album.Href;
            this.Id = album.Id;
            this.Images = album.Images;
            this.Name = album.Name;
            this.Type = album.Type;
            this.Uri = album.Uri;
        }
        public static SAlbum Convert(SimpleAlbum album)
        {
            return new SAlbum(album);
        }
        public ISpotifyFullEntity FullVersion()
        {
            return (ISpotifyFullEntity)(new FAlbum(Classes.Converter.GetFullAlbum(_base)));
        }
    }
    public partial class FTrack : SpotifyAPI.Web.Models.FullTrack, ISpotifyFullEntity
    {
        public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.FullTrack; } }
        public DbEntityType DbEntityType { get { return DbEntityType.Track; } }

        public List<string> Genres { get; set; }

        public List<SpotifyAPI.Web.Models.Image> Images
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Dictionary<string, string> ExternalUrls
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
         public List<SArtist> SArtists { get; set; }

        public FTrack(FullTrack track)
        {
            this.Album = track.Album;
            this.SArtists = new List<SArtist>();
            this.Artists = track.Artists;
            track.Artists.ForEach(a => this.SArtists.Add(new SArtist(a)));
            this.AvailableMarkets = track.AvailableMarkets;
            this.DiscNumber = track.DiscNumber;
            this.DurationMs = track.DurationMs;
            this.Explicit = track.Explicit;
            this.ExternalIds = track.ExternalIds;
            this.ExternUrls = track.ExternUrls;
            this.Href = track.Href;
            this.Id = track.Id;
            this.IsPlayable = track.IsPlayable;
            this.LinkedFrom = track.LinkedFrom;
            this.Name = track.Name;
            this.PreviewUrl = track.PreviewUrl;
            this.Popularity = track.Popularity;
            this.TrackNumber = track.TrackNumber;
            this.Type = track.Type;
            this.Uri = track.Uri;
        }
        public static FTrack Convert(FullTrack track)
        {
            return new FTrack(track);
        }
    }
    public partial class STrack : SpotifyAPI.Web.Models.SimpleTrack, ISpotifySimpleEntity
    {
        public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.SimpleTrack; } }
        public DbEntityType DbEntityType { get { return DbEntityType.Track; } }
        private SimpleTrack _base;
        public STrack(SimpleTrack track)
        {
            this._base = track;
            this.Artists = track.Artists;
            this.AvailableMarkets = track.AvailableMarkets;
            this.DiscNumber = track.DiscNumber;
            this.DurationMs = track.DurationMs;
            this.Explicit = track.Explicit;
            this.ExternUrls = track.ExternUrls;
            this.Href = track.Href;
            this.Id = track.Id;
            this.Name = track.Name;
            this.PreviewUrl = track.PreviewUrl;
            this.TrackNumber = track.TrackNumber;
            this.Type = track.Type;
            this.Uri = track.Uri;
        }
        public static STrack Convert(SimpleTrack track)
        {
            return new STrack(track);
        }
        public ISpotifyFullEntity FullVersion()
        {
            return (ISpotifyFullEntity)(new FTrack(Classes.Converter.GetFullTrack(_base)));
        }
    }
    public partial class FPlaylist : SpotifyAPI.Web.Models.FullPlaylist, ISpotifyFullEntity
    {
        public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.FullPlaylist; } }
        public DbEntityType DbEntityType { get { return DbEntityType.List; } }

        public List<string> Genres { get; set; }

        public int Popularity { get; set; }

        public FPlaylist(FullPlaylist playlist)
        {
            this.Collaborative = playlist.Collaborative;
            this.Description = playlist.Description;
            this.ExternalUrls = playlist.ExternalUrls;
            this.Followers = playlist.Followers;
            this.Href = playlist.Href;
            this.Id = playlist.Id;
            this.Images = playlist.Images;
            this.Name = playlist.Name;
            this.Owner = playlist.Owner;
            this.Public = playlist.Public;
            this.Tracks = playlist.Tracks;
            this.Type = playlist.Type;
            this.Uri = playlist.Uri;

        }

        public static FPlaylist Convert(FullPlaylist playlist)
        {
            return new FPlaylist(playlist);
        }
    }
    public partial class SPlaylist : SpotifyAPI.Web.Models.SimplePlaylist, ISpotifySimpleEntity
    {
        public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.SimplePlaylist; } }
        public DbEntityType DbEntityType { get { return DbEntityType.List; } }
        private SimplePlaylist _base;
        public SPlaylist(SimplePlaylist playlist)
        {
            this._base = playlist;
            this.Collaborative = playlist.Collaborative;
            this.ExternalUrls = playlist.ExternalUrls;
            this.Href = playlist.Href;
            this.Id = playlist.Id;
            this.Images = playlist.Images;
            this.Name = playlist.Name;
            this.Owner = playlist.Owner;
            this.Public = playlist.Public;
            this.Tracks = playlist.Tracks;
            this.Type = playlist.Type;
            this.Uri = playlist.Uri;

        }

        public ISpotifyFullEntity FullVersion()
        {
            return (ISpotifyFullEntity)(new FPlaylist(Classes.Converter.GetFullPlaylist(_base)));
        }
        public static SPlaylist Convert(SimplePlaylist playlist)
        {
            return new SPlaylist(playlist);
        }
    }

    public interface ISpotifyEntity
    {
        string Name { get; set; }
        string Href { get; set; }
        string Id { get; set; }
        string Type { get; set; }
        string Uri { get; set; }
        SpotifyEntityType SpotifyEntityType { get; }
        DbEntityType DbEntityType { get; }
    }
    public interface ISpotifySimpleEntity : ISpotifyEntity
    {
        ISpotifyFullEntity FullVersion();
    }
    public interface ISpotifyFullEntity : ISpotifyEntity
    {
        List<string> Genres { get; set; }
        List<SpotifyAPI.Web.Models.Image> Images { get; set; }
        Dictionary<string, string> ExternalUrls { get; set; }
        int Popularity { get; set; }
    }
}
