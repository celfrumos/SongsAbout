using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using System.ComponentModel;

namespace SongsAbout.Web.Models
{
    public partial class Album
    {
        public int AlbumId { get; set; }

        [DisplayName("Album Name")]
        public string Name { get; set; }
        public int MainArtistId { get; set; }

        [DisplayName("Spotify Id")]
        public string SpotifyUri { get; set; }


        [DisplayName("Spotify Link")]
        public string SpotifyHref { get; set; }


        [DisplayName("Release Date")]
        public DateTime? ReleaseDate { get; set; }


        [DisplayName("Cover Art")]
        public Image CoverArt { get; set; }

        [DisplayName("Main Artist")]
        public Artist MainArtist { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Artist> FeaturedArtists { get; set; }

        /*
        //public Album(SpotifyFullAlbum album)// : this(new SpotifyAlbum(album))
        //{
        //    this.Name = album.Name;
        //    this.SpotifyUri = album.Uri;
        //    if (album.Artists.Count > 0)
        //    {
        //        this.MainArtist = (album.Artists[0]);
        //    }
        //    // var s = DateTime.Parse( album.ReleaseDate).Date;
        //    // this.Year = null;
        //    this.ReleaseDate = album.ReleaseDate;
        //    //  this.SetGenres(album.Genres);
        //    // this.UpdateCoverArt(album);
        //}

        //public Album(SpotifyAlbum album) : this(
        //    album.SpotifyEntityType == SpotifyEntityType.FullAlbum
        //    ? (SpotifyFullAlbum)album
        //    : album.GetFullVersion(UserSpotify.WebAPI))// : base("al_title", "Albums", "Album")
        //{
        //}

        //public Album()
        //{
        //    this.AlbumId = 0;
        //    this.ArtistId = 0;
        //    this.Name = null;
        //    this.ReleaseDate = null;
        //    this.SpotifyUri = null;
        //    this.CoverArt = null;

        //}

        //public Album(int id, int artist_id, string name, DateTime releaseDate, string uri,string href, Image coverArt)
        //{
        //    this.AlbumId = id;
        //    this.ArtistId = artist_id;
        //    this.Name = name;
        //    this.ReleaseDate = releaseDate;
        //    this.SpotifyUri = uri;
        //    this.SpotifyHref = href;
        //    this.CoverArt = coverArt;
        //}

        //public static implicit operator Album(SpotifyFullAlbum alb)
        //{
        //    Album res;
        //    using (var db = new EntityDbContext())
        //    {
        //        var albs = db.Albums.Where(a => a.Name == alb.Name);
        //        if (albs.Count() > 0)

        //            res = albs.First();

        //        else
        //            res = new Album() {
        //                Name= alb.Name,
        //                SpotifyUri= alb.Uri,
        //                SpotifyHref= alb.Href,
        //                ReleaseDate= alb.ReleaseDate,
        //                CoverArt= alb.Images[0]
        //            };

        //    }
        //    return res;

        //}
        */
    }
}