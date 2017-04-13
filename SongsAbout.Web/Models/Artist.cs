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
    public partial class Artist : SaEntity
    {
        // DbEntityContext artistContext = new DbEntityContext();
        //protected override string TypeName => "Artist";
        //public const string TITLE_COLUMN = "name";

        public override SaEntityType EntityType => SaEntityType.Artist;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }

        [Display(Name = "Artist Name")]
        [Required(ErrorMessage = "Artist must have a name")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Artist Name is too long")]
        public override string Name { get; set; }

        [Display(Name = "Artist Biography")]
        [StringLength(500)]
        public string Bio { get; set; }

        [Display(Name = "Profile Picture")]
        public ProfilePic ProfilePic { get; set; }

        public int ProfilePicId { get; set; }

        [Display(Name = "Albums")]
        public List<Album> Albums { get; set; }

        [Display(Name = "Tracks")]
        public List<Track> Tracks { get; set; }

        [Display(Name = "Album Keywords")]
        public override List<Keyword> Keywords { get; set; }

    }
}
