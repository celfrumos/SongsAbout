using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class CategoryPlaylist : BasicModel
    {
        [JsonProperty("playlists")]
        public Paging<SpotifyPlaylist> Playlists { get; set; }
    }
}