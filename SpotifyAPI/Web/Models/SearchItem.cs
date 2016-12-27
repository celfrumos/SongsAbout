using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class SearchItem : BasicModel
    {
        [JsonProperty("artists")]
        public Paging<SpotifyFullArtist> Artists { get; set; }

        [JsonProperty("albums")]
        public Paging<SpotifyAlbum> Albums { get; set; }

        [JsonProperty("tracks")]
        public Paging<SpotifyFullTrack> Tracks { get; set; }

        [JsonProperty("playlists")]
        public Paging<SpotifyPlaylist> Playlists { get; set; } 
    }
}