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
    public partial class Album : ISaEntity, ISaIntegralEntity
    {
        [NotMapped]
        public SaEntityType EntityType => SaEntityType.Album;
        public string TypeName => "Album";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }

        [NotMapped]
        public int Id { get { return AlbumId; } set { AlbumId = value; } }

        [DisplayName("Album Name")]
        [Required(ErrorMessage = "Album must have a name.", AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Album Name is too long")]
        public string Name { get; set; }

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
        public List<Keyword> Keywords { get; set; }

        [StringLength(50)]
        [Display(Name = "Spotify Id")]
        public virtual string SpotifyId { get; set; }

        [NotMapped]
        [Display(Name = "Spotify Details Web Page")]
        public string SpotifyWebPage
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.TypeName} '{this.Name}'");

                return $"{Constants.SPOTIFY_WEB_PAGE_BASE}/{this.TypeName.ToLower()}/{this.SpotifyId}";

            }
        }

        [NotMapped]
        [Display(Name = "Spotify API Link")]
        public virtual string ApiHref
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.TypeName} '{this.Name}'");

                return $"{Constants.SPOTIFY_API_BASE}/{this.TypeName.ToLower()}s/{this.SpotifyId}";
            }
        }

        [NotMapped]
        [Display(Name = "Spotify URI")]
        public virtual string SpotifyUri
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.TypeName} '{this.Name}'");

                return $"spotify:artist:{this.SpotifyId}";
            }
        }

        public virtual List<Genre> Genres { get; set; }
        public virtual List<Topic> Topics { get; set; }

        public bool DescribedBy(string term)
        {
            return
                  this.Genres.Any(g => g.Text.ToLower().Contains(term.ToLower()))
                  || this.Topics.Any(g => g.Text.ToLower().Contains(term.ToLower()))
                  || this.Keywords.Any(g => g.Text.ToLower().Contains(term.ToLower()));
        }
    }
}