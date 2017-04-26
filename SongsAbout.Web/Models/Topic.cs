using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Topic : ISaEntity, ISaDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicId { get; set; }

        [NotMapped]
        public int Id { get { return TopicId; } set { TopicId = value; } }

        [NotMapped]
        public SaEntityType EntityType => SaEntityType.Topic;

        public string TypeName => "Topic";

        [Display(Name = "Topic")]
        [Required(ErrorMessage = "Topic Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Topics must have less than 200 characters.")]
        public string Text { get; set; }

        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }


        public string Name
        {
            get { return Text; }

            set { Text = value; ; }
        }

        [Display(Name = "Topic Keywords")]
        public List<Keyword> Keywords { get; set; }

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