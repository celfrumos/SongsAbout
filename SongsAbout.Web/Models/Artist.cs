using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core;
using System.Data.Linq;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace SongsAbout.Web.Models
{

    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    [Serializable]
    public partial class Artist : ISaEntity
    {
        // DbEntityContext artistContext = new DbEntityContext();
        //protected override string TypeName => "Artist";
        //public const string TITLE_COLUMN = "name";

        [NotMapped]
        public SaEntityType EntityType => SaEntityType.Artist;
        [NotMapped]
        public string TypeName => "Artist";
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }

        [NotMapped]
        public int Id { get { return ArtistId; } set { ArtistId = value; } }

        [Display(Name = "Artist Name")]
        [Required(ErrorMessage = "Artist must have a name")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Artist Name is too long")]
        public string Name { get; set; }

        [Display(Name = "Artist Biography")]
        [StringLength(500)]
        public string Bio { get; set; }

        [Display(Name = "Profile Picture")]
        public ProfilePic ProfilePic { get; set; }

        [Display(Name = "Profile Picture")]
        public int ProfilePicId { get; set; }

        [Display(Name = "Albums")]
        public List<Album> Albums { get; set; }

        [Display(Name = "Tracks")]
        public List<Track> Tracks { get; set; }

        [Display(Name = "Album Keywords", GroupName = "Descriptors")]
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

        [Display(GroupName = "Descriptors")]
        public virtual List<Genre> Genres { get; set; }
        [Display(GroupName = "Descriptors")]
        public virtual List<Topic> Topics { get; set; }

    }
}
