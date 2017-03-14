using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicId { get; set; }

        [Display(Name = "Topic")]
        [Required(ErrorMessage = "Topic Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 2, ErrorMessage =  "Topics must have less than 200 characters.")]
        public string TopicText { get; set; }

        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }
    }
}