using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    [Serializable]
    public class Track : ISaEntity
    {
        [NotMapped]
        public SaEntityType EntityType => SaEntityType.Track;
        public string TypeName => "Track";

        [NotMapped]
        private const double MS_TO_MINUTES = 60000d;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }

        public int Id { get { return TrackId; } set { TrackId = value; } }


        [Display(Name = "Artist")]
        [Required(ErrorMessage = "Track must have an Artist.")]
        public int ArtistId { get; set; }

        [Display(Name = "Album")]
        [Required(ErrorMessage = "Track must be part of an Album.")]
        public int AlbumId { get; set; }

        [DisplayName("Track Name")]
        [Required(ErrorMessage = "Track must have a name.", AllowEmptyStrings = false)]
        [StringLength(150, ErrorMessage = "Track Name is too long")]
        public string Name { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Can Play")]
        public bool CanPlay { get; set; }

        [Display(Name = "Length")]
        [DisplayFormat(DataFormatString = "{0:##}")]
        public double LengthMinutes
        {
            get { return this.DurationMs / MS_TO_MINUTES; }
            set { this.DurationMs = (uint)(value * MS_TO_MINUTES); }
        }

        [DefaultValue(0)]
        [Display(Name = "Duration")]
        [DisplayFormat(DataFormatString = "{0:##}")]
        public uint DurationMs { get; set; }

        public Artist Artist { get; set; }


        public Album Album { get; set; }

        [Display(Name = "Description")]
        [DefaultValue(null)]
        public int? DescriptionId { get; set; }

        [DefaultValue(null)]
        public SaDescription Description { get; set; }


        [Display(Name = "Featured Artists")]
        public List<Artist> FeaturedArtists { get; set; }

        [Display(Name = "Album Keywords")]
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