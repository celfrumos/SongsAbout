using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class SeveralTracks : BasicModel
    {
        [JsonProperty("tracks")]
        public List<SpotifyFullTrack> Tracks { get; set; }
    }
}