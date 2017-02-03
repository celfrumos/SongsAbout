using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public partial class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string SpotifyUri { get; set; }
        public string SpotifyHref { get; set; }

        public List<Album> Albums { get; set; }
        public List<Track> Tracks { get; set; }
    }
}