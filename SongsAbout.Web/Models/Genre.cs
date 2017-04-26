using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Genre : ISaEntity, ISaDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        [NotMapped]
        public int Id
        {
            get { return GenreId; }
            set { GenreId = value; }
        }

        [NotMapped]
        public SaEntityType EntityType => SaEntityType.Genre;
        [NotMapped]
        public string TypeName => "Genre";
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Genres must have less than 150 characters.")]
        public string Text { get; set; }

        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }

        public string Name
        {
            get { return Text; }
            set { Text = value; }
        }
        [Display(Name = "Spotify Id")]
        [StringLength(50)]
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

        [Display(Name = "Genres Keywords")]
        public List<Keyword> Keywords { get; set; }
    }
}