using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        public int ArtistId { get; set; }
        public int AlbumId { get; set; }

        [DisplayName("Track Name")]
        public string Name { get; set; }

        [DisplayName("Main Artist")]
        public Artist MainArtist { get; set; }

        public Album Album { get; set; }

        //  public double LengthMinutes { get; set; }
        public int DurationMs { get; set; }

        public List<Artist> Artists { get; set; }
    }
}