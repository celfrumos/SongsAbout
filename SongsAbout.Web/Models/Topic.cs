using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Topic : SaDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicId { get; set; }

        public override int Id { get { return TopicId; } set { TopicId = value; } }

        public override SaEntityType EntityType => SaEntityType.Topic;
        [Display(Name = "Topic")]
        [Required(ErrorMessage = "Topic Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Topics must have less than 200 characters.")]
        public override string Text { get; set; }

        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }
        

        public override string Name
        {
            get { return Text; }

            set { Text = value; ; }
        }
    }
}