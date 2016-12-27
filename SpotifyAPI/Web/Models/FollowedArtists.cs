using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class FollowedArtists : BasicModel
    {
        [JsonProperty("artists")]
        public CursorPaging<SpotifyFullArtist> Artists { get; set; }
    }
}