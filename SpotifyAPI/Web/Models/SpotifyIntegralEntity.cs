using System.Collections.Generic;
using Newtonsoft.Json;
using SpotifyAPI.Web.Enums;

namespace SpotifyAPI.Web.Models
{
    public abstract class SpotifyIntegralEntity : BasicModel
    {
        [JsonProperty("href")]
        public virtual string Href { get; set; }

        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("external_urls")]
        public virtual Dictionary<string, string> ExternalUrls { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("type")]
        public virtual string Type { get; set; }

        [JsonProperty("uri")]
        public virtual string Uri { get; set; }

        public abstract SpotifyEntityType SpotifyEntityType { get; }
        

    }
}
