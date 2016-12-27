using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SongsAbout.Enums;
using SongsAbout.Classes;
using FullArtist = SpotifyAPI.Web.Models.FullArtist;
using SpotifyAPI.Web.Enums;

namespace SongsAbout.Entities
{
    public partial class SpotifyArtist : SpotifyAPI.Web.Models.FullArtist, ISpotifyFullEntity
    {
       // public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.FullArtist; } }
        public DbEntityType DbEntityType { get { return DbEntityType.Artist; } }
        public SpotifyArtist() : base()
        {
        }
        public SpotifyArtist(FullArtist artist)
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
        public SpotifyArtist(SimpleArtist artist) : this(Converter.GetFullArtist(artist))
        {

        }
    }
    //public partial class SArtist : SpotifyAPI.Web.Models.SimpleArtist, ISpotifySimpleEntity
    //{
    //    public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.SimpleArtist; } }
    //    public DbEntityType DbEntityType { get { return DbEntityType.Artist; } }
    //    private SimpleArtist _base;
    //    public SArtist(SimpleArtist artist)
    //    {
    //        this._base = artist;
    //        this.Name = artist.Name;
    //        this.Type = artist.Type;
    //        this.Uri = artist.Uri;
    //        this.Id = artist.Id;
    //        this.Href = artist.Href;
    //        this.ExternalUrls = artist.ExternalUrls;
    //    }
    //    public static SArtist Convert(SimpleArtist artist)
    //    {
    //        return new SArtist(artist);
    //    }
    //    public ISpotifyFullEntity FullVersion()
    //    {
    //        return (ISpotifyFullEntity)(new SpotifyArtist(Classes.Converter.GetFullArtist(_base)));
    //    }
    //}

    public partial class SpotifyAlbum : FullAlbum, ISpotifyFullEntity
    {
        private List<SpotifyTrack> _trackList;
        private List<SpotifyArtist> _artists;
     //   public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.Album; } }
        public DbEntityType DbEntityType { get { return DbEntityType.Album; } }
        public List<SpotifyTrack> TrackList { get { return _trackList; } }

        /// <summary>
        /// Get the name of the Main Artist for the album
        /// </summary>
        /// <exception cref="SpotifyException"></exception>
        public string ArtistName
        {
            get
            {
                try
                {
                    return this.Artists[0].Name;
                }
                catch (NullReferenceException)
                {
                    return "Not Found";
                }
                catch (Exception ex)
                {
                    throw new SpotifyException(
                        $"Something went wrong getting artist name for Spotify FAlbum '{this.Name}': {ex.Message}");
                }
            }
        }
        public SpotifyAlbum() : base()
        {
        }
        public List<SpotifyArtist> ArtistList { get { return this._artists; } }
        public SpotifyAlbum(FullAlbum album)
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

            _trackList = new List<SpotifyTrack>();
            foreach (var track in this.Tracks.Items)
            {
                this._trackList.Add(new SpotifyTrack(Converter.GetFullTrack(track)));
            }
            _artists = new List<SpotifyArtist>();
            foreach (var item in this.Artists)
            {
                this._artists.Add(new SpotifyArtist(Converter.GetFullArtist(item)));
            }
        }
        public SpotifyAlbum(SimpleAlbum album) : this(Converter.GetFullAlbum(album))
        {

        }
        public SpotifyAlbum(SavedAlbum album) : this(Converter.GetFullAlbum(album))
        {

        }
        public static SpotifyAlbum Convert(FullAlbum album)
        {
            return new SpotifyAlbum(album);
        }
    }
    //public partial class SAlbum : FAlbum  /*:SpotifyAPI.Web.Models.SimpleAlbum, ISpotifyAlbum, ISpotifySimpleEntity*/
    //{
    //    public SAlbum(FullAlbum album):base(album)
    //    {

    //    }
    //    public SAlbum(SimpleAlbum album) : base(album)
    //    {

    //    }
    //    //private List<FTrack> _trackList;
    //    //public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.SimpleAlbum; } }
    //    //SpotifyEntityType ISpotifyAlbum.AlbumType { get { return this.SpotifyEntityType; } }
    //    //public DbEntityType DbEntityType { get { return DbEntityType.Album; } }
    //    //List<FTrack> ISpotifyAlbum.TrackList { get { return _trackList; } }

    //    //private List<FArtist> _artists;
    //    //List<FArtist> ISpotifyAlbum.Artists { get { return this._artists; } }

    //    //private SimpleAlbum _base;
    //    ///// <summary>
    //    ///// Get the name of the Main Artist for the album
    //    ///// </summary>
    //    ///// <exception cref="SpotifyException"></exception>
    //    //public string ArtistName
    //    //{
    //    //    get
    //    //    {
    //    //        try
    //    //        {
    //    //            return this.Artists[0].Name;
    //    //        }
    //    //        catch (NullReferenceException)
    //    //        {
    //    //            return "Not Found";
    //    //        }
    //    //        catch (Exception ex)
    //    //        {
    //    //            throw new SpotifyException(
    //    //                $"Something went wrong getting artist name for Spotify FAlbum '{this.Name}': {ex.Message}");
    //    //        }
    //    //    }
    //    //}

    //    //public SAlbum(SimpleAlbum album)
    //    //{
    //    //    this._base = album;
    //    //    this.AlbumType = album.AlbumType;
    //    //    this.AvailableMarkets = album.AvailableMarkets;
    //    //    this.Href = album.Href;
    //    //    this.Id = album.Id;
    //    //    this.Images = album.Images;
    //    //    this.Name = album.Name;
    //    //    this.Type = album.Type;
    //    //    this.Uri = album.Uri;
    //    //    _trackList = new List<FTrack>();
    //    //    _artists = new List<FArtist>();
    //    //    var full = Converter.GetFullAlbum(album);
    //    //    foreach (var track in full.Tracks.Items)
    //    //    {
    //    //        this._trackList.Add(new FTrack(Converter.GetFullTrack(track)));
    //    //    }
    //    //    foreach (var item in full.Artists)
    //    //    {
    //    //        this._artists.Add(new FArtist(Converter.GetFullArtist(item)));
    //    //    }
    //    //}
    //    //public static SAlbum Convert(SimpleAlbum album)
    //    //{
    //    //    return new SAlbum(album);
    //    //}
    //    //public ISpotifyFullEntity FullVersion()
    //    //{
    //    //    return (ISpotifyFullEntity)(new FAlbum(Classes.Converter.GetFullAlbum(_base)));
    //    //}
    //}

    public partial class SpotifyTrack : SpotifyAPI.Web.Models.FullTrack, ISpotifyFullEntity
    {
        public override SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.FullTrack; } }
        public DbEntityType DbEntityType { get { return DbEntityType.Track; } }

        public List<string> Genres { get; set; }

        public List<SpotifyAPI.Web.Models.SpotifyImage> Images
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        //public Dictionary<string, string> ExternalUrls
        //{
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}
        public List<SpotifyArtist> ArtistList { get; set; }

        public SpotifyTrack(FullTrack track)
        {
            this.Album = track.Album;
            this.ArtistList = new List<SpotifyArtist>();
            this.Artists = track.Artists;
            track.Artists.ForEach(a => this.ArtistList.Add(new SpotifyArtist(a)));
            this.AvailableMarkets = track.AvailableMarkets;
            this.DiscNumber = track.DiscNumber;
            this.DurationMs = track.DurationMs;
            this.Explicit = track.Explicit;
            this.ExternalIds = track.ExternalIds;
            this.ExternalUrls = track.ExternalUrls;
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
        public SpotifyTrack(SimpleTrack track) : this(Converter.GetFullTrack(track))
        {

        }
        public SpotifyTrack(SavedTrack track) : this(Converter.GetFullTrack(track))
        {

        }
        public SpotifyTrack()
        {

        }
    }
    //public partial class STrack : SpotifyAPI.Web.Models.SimpleTrack, ISpotifySimpleEntity
    //{
    //    public SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.SimpleTrack; } }
    //    public DbEntityType DbEntityType { get { return DbEntityType.Track; } }
    //    private SimpleTrack _base;
    //    public STrack(SimpleTrack track)
    //    {
    //        this._base = track;
    //        this.Artists = track.Artists;
    //        this.AvailableMarkets = track.AvailableMarkets;
    //        this.DiscNumber = track.DiscNumber;
    //        this.DurationMs = track.DurationMs;
    //        this.Explicit = track.Explicit;
    //        this.ExternUrls = track.ExternUrls;
    //        this.Href = track.Href;
    //        this.Id = track.Id;
    //        this.Name = track.Name;
    //        this.PreviewUrl = track.PreviewUrl;
    //        this.TrackNumber = track.TrackNumber;
    //        this.Type = track.Type;
    //        this.Uri = track.Uri;
    //    }
    //    public static STrack Convert(SimpleTrack track)
    //    {
    //        return new STrack(track);
    //    }
    //    public ISpotifyFullEntity FullVersion()
    //    {
    //        return (ISpotifyFullEntity)(new SpotifyTrack(Classes.Converter.GetFullTrack(_base)));
    //    }
    //}

    public partial class FPlaylist : SpotifyAPI.Web.Models.FullPlaylist, ISpotifyFullEntity
    {
       public DbEntityType DbEntityType { get { return DbEntityType.Playlist; } }

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
      public DbEntityType DbEntityType { get { return DbEntityType.Playlist; } }
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
        List<SpotifyAPI.Web.Models.SpotifyImage> Images { get; set; }
        Dictionary<string, string> ExternalUrls { get; set; }
        int Popularity { get; set; }
    }
}
