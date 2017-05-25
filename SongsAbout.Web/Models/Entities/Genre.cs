using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Genre : SaDescriptor
    {
        [NotMapped]
        public override SaEntityType EntityType => SaEntityType.Genre;

        [NotMapped]
        public string TypeName => "Genre";


        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Genres must have between 3 and 150 characters.")]
        public override string Name { get; set; }

        [Display(Name = "Genre Keywords")]
        public List<Keyword> Keywords { get; set; }
    }
}