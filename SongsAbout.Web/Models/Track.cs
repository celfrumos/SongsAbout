using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Track : SaEntity
    {
        protected override string TypeName { get { return "Track"; } }

        [Key]
        public int TrackId { get; set; }

        public int ArtistId { get; set; }
        public int AlbumId { get; set; }

        [DisplayName("Track Name")]
        public override string Name { get; set; }

        [DisplayName("Main Artist")]
        public Artist Artist { get; set; }

        public Album Album { get; set; }
        public bool CanPlay { get; set; }
        public double LengthMinutes { get; set; }
        public int DurationMs { get; set; }

        public List<Artist> Artists { get; set; }
    }
}