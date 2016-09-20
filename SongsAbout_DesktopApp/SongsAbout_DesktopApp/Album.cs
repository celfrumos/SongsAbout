using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp
{
    class Album
    {
        public Artist MainArtist { get; set; }
        public string Year { get; set; }
        public string Title { get; set; }
        public string CoverArt { get; set; }
        public List<Artist> FeatArtists { get; set; }

        public Album()
        {
        }

    }
}
