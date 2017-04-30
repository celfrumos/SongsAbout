using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Keyword : ISaEntity, ISaDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeywordId { get; set; }

        [NotMapped]
        public string TypeName => "Keyword";

        [NotMapped]
        public SaEntityType EntityType => SaEntityType.Keyword;

        [NotMapped]
        public int Id { get { return KeywordId; } set { KeywordId = value; } }

        [Display(Name = "Keyword")]
        [Required(ErrorMessage = "Keyword Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Keywords must have less than 50 characters.")]
        public string Text { get; set; }

        [NotMapped]
        public string Name
        {
            get { return Text; }
            set { Text = value; }
        }

        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }


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
    }
}