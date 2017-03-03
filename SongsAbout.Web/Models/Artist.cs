using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core;
using System.Data.Linq;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace SongsAbout.Web.Models
{

    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    public partial class Artist
    {
        // DbEntityContext artistContext = new DbEntityContext();
        //public const string TABLE_NAME = "Artists";
        //public const string TYPE_STRING = "Artist";
        //public const string TITLE_COLUMN = "name";

        //  public readonly DbEntityType DbEntityType = DbEntityType.Artist;

        [Key]
        public int ArtistId { get; set; }

        [Display(Name = "Artist Name")]
        public string Name { get; set; }

        [Display(Name = "Artist Biography")]
        public string Bio { get; set; }

        public string SpotifyWebPage { get; set; }

        [Display(Name = "Spotify API Link")]
        public string ApiHref { get; set; }

        [Display(Name = "Spotify URI")]
        public string SpotifyUri { get; set; }

        public List<Album> Albums { get; set; }

        public List<Track> Tracks { get; set; }

        [Display(Name = "Profile Picture")]
        public Picture ProfilePic { get; set; }


    }
}
