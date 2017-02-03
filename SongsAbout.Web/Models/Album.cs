using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public partial class Album
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public Artist MainArtist { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Artist> Artists { get; set; }
    }
}