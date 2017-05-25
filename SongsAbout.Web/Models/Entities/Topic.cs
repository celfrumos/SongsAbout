using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Topic : SaDescriptor
    {
        [NotMapped]
        public override SaEntityType EntityType => SaEntityType.Topic;

        [Display(Name = "Topic")]
        [Required(ErrorMessage = "Topic Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Topics must have between 5 and 200 characters.")]
        public override string Name { get; set; }

        [Display(Name = "Topic Keywords")]
        public List<Keyword> Keywords { get; set; }

        public virtual List<Genre> Genres { get; set; }
        public virtual List<Topic> Topics { get; set; }
    }
}