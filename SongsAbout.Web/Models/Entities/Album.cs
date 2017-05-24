using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Web.Models
{
    [Serializable]
    public partial class Album : SaEntity, ISaIntegralEntity
    {
        [NotMapped]
        public override SaEntityType EntityType => SaEntityType.Album;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

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
        [ForeignKey(nameof(ArtistId))]
        public Artist Artist { get; set; }

        [Display(Name = "Tracks")]
        public List<Track> Tracks { get; set; }

        [Display(Name = "Featured Artists")]
        public List<Artist> FeaturedArtists { get; set; }

        [Display(Name = "Album Cover")]
        public int AlbumCoverId { get; set; }

        [Display(Name = "Album Cover")]
        [ForeignKey(nameof(AlbumCoverId))]
        public Picture AlbumCover { get; set; }


        [Display(Name = "Album Keywords")]
        public List<Keyword> Keywords { get; set; }

        public virtual List<Genre> Genres { get; set; }
        public virtual List<Topic> Topics { get; set; }

        public bool DescribedBy(string term)
        {
            return
                  this.Genres.Any(g => g.Name.ToLower().Contains(term.ToLower()))
                  || this.Topics.Any(g => g.Text.ToLower().Contains(term.ToLower()))
                  || this.Keywords.Any(g => g.Text.ToLower().Contains(term.ToLower()));
        }

        public static Album Convert(SpotifyAlbum album)
        {
            return new Album(album);
        }

        public static Album Convert(SpotifyFullAlbum album)
        {
            return new Album(album);
        }
        private void SetDefaults()
        {
            this.AlbumCover = new Picture();
            this.AlbumCoverId = default(int);
            this.Id = default(int);
            this.Artist = new Artist();
            this.ArtistId = default(int);
            this.FeaturedArtists = new List<Artist>();
            this.Genres = new List<Genre>();
            this.Keywords = new List<Keyword>();
            this.Name = "";
            this.ReleaseDate = null;
            this.SpotifyId = "";
            this.Topics = new List<Topic>();
            this.Tracks = new List<Track>();
        }
        public Album()
        {
            this.SetDefaults();
        }
        public Album(SpotifyAlbum album)
            : this(album?.GetFullVersion(Spotify.WebApi))
        {

        }
        public Album(SpotifyFullAlbum album, EntityDbContext db = null, bool createArtistIfDoesntExist = false)
        {
            if (album == null)
                this.SetDefaults();

            this.Name = album.Name;
            this.AlbumCover = album.Images.Count > 0 ? album.Images[0] : null;
            this.ReleaseDate = album.ReleaseDate;
            this.SpotifyId = album.Id;

            if (db != null && album.Artists.Count > 0)
            {
                this.Artist = db.Get<Artist>(album.Artists[0].Name);

                if (createArtistIfDoesntExist && this.Artist == null)
                    this.Artist = db.Create<Artist>(new Artist(album.Artists[0]));


                if (this.Artist != null)
                    this.ArtistId = this.Artist.Id;

            }

        }
    }
}