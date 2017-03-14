using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Genres must have less than 150 characters.")]
        public string GenreText { get; set; }

        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }
    }
}