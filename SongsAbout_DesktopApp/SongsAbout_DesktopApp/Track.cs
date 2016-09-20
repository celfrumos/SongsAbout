using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp
{
    class Track
    {
        public Album TrackAlbum { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public List<string> Genres { get; set; }
        public Artist TrackArtist
        {
            get { return this.TrackAlbum.MainArtist; }
            set { this.TrackAlbum.MainArtist = value; }
        }
        public Track()
        {
        }
    }
}
