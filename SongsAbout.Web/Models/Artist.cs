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

namespace SongsAbout.Web.Models
{

    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    [Serializable]
    public partial class Artist : SaEntity
    {
        // DbEntityContext artistContext = new DbEntityContext();
        protected override string TypeName { get { return "Artist"; } }
        //public const string TITLE_COLUMN = "name";

        //  public readonly DbEntityType DbEntityType = DbEntityType.Artist;

        [Key]
        public int ArtistId { get; set; }

        [Display(Name = "Artist Name")]
        public override string Name { get; set; }

        [Display(Name = "Artist Biography")]
        public string Bio { get; set; }

        [Display(Name = "Spotify Id")]
        public override string SpotifyId { get; set; }

        [Display(Name = "Profile Picture")]
        public ProfilePic ProfilePic { get; set; }

        public int ProfilePicId { get; set; }

        [Display(Name = "Albums")]
        public List<Album> Albums { get; set; }

        // public List<Track> Tracks { get; set; }
    }
}
