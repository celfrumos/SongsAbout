using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Keyword : SaDescriptor
    {

        [NotMapped]
        public override SaEntityType EntityType => SaEntityType.Keyword;

        [Display(Name = "Keyword")]
        [Required(ErrorMessage = "Keyword Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Keywords must have between 3 and 50 characters.")]
        public override string Name { get; set; }

    }
}