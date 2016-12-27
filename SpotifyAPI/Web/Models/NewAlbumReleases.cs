using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class NewAlbumReleases : BasicModel
    {
        [JsonProperty("albums")]
        public Paging<SpotifyAlbum> Albums { get; set; }
    }
}