using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Genre : SaEntity, ISaEntity, ISaDescriptor
    {
        [Key]
        [Column("GenreId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [NotMapped]
        public override SaEntityType EntityType => SaEntityType.Genre;

        [NotMapped]
        public string TypeName => "Genre";


        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Genres must have less than 150 characters.")]
        public override string Name { get; set; }

        [Display(Name = "Spotify Id")]
        [StringLength(50)]
        public override string SpotifyId { get; set; }

        public virtual List<Topic> Topics { get; set; }

        [Display(Name = "Genre Keywords")]
        public List<Keyword> Keywords { get; set; }
    }
}