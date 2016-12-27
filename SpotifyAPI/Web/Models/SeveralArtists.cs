using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class SeveralArtists : BasicModel
    {
        [JsonProperty("artists")]
        public List<SpotifyFullArtist> Artists { get; set; }
    }
}