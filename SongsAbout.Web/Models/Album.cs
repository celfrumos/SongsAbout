using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SongsAbout.Web.Models
{
    public partial class Album : SaEntity
    {
        public override SaEntityType EntityType() => SaEntityType.Album;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }

        [DisplayName("Album Name")]
        [Required(ErrorMessage = "Album must have a name.", AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Album Name is too long")]
        public override string Name { get; set; }

        [DisplayName("Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [DisplayName("Album Artist")]
        [Required(ErrorMessage = "Album must have an Artist.")]
        public int ArtistId { get; set; }

        [DisplayName("Main Artist")]
        public Artist Artist { get; set; }

        [Display(Name = "Tracks")]
        public List<Track> Tracks { get; set; }

        [Display(Name = "Featured Artists")]
        public List<Artist> FeaturedArtists { get; set; }


        [Display(Name = "Album Cover")]
        public int AlbumCoverId { get; set; }

        [Display(Name = "Album Cover")]
        public AlbumCover AlbumCover { get; set; }

        [Display(Name = "Album Keywords")]
        public override List<Keyword> Keywords { get; set; }

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