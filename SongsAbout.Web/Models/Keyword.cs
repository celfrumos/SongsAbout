using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Keyword : SaDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeywordId { get; set; }
        public override SaEntityType EntityType => SaEntityType.Keyword;
        public override int Id { get { return KeywordId; } set { KeywordId = value; } }
        [Display(Name = "Keyword")]
        [Required(ErrorMessage = "Keyword Text must not be blank", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Keywords must have less than 50 characters.")]
        public string KeywordText { get; set; }
        public override string Text { get { return KeywordText; } set { this.KeywordText = value; } }
        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }
    }
}