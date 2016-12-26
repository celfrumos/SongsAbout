using Newtonsoft.Json;
using System;
using SpotifyAPI.Web.Enums;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public class SimpleTrack : SpotifyIntegralEntity
    {
        public override SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.SimpleTrack; } }
        [JsonProperty("artists")]
        public List<SimpleArtist> Artists { get; set; }

        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }

        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }

        [JsonProperty("explicit")]
        public Boolean Explicit { get; set; }

        [JsonProperty("external_urls")]
        public Dictionary<string, string> ExternUrls { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

        //[JsonProperty("type")]
        //public string Type { get; set; }

        //[JsonProperty("uri")]
        //public string Uri { get; set; }       

        //[JsonProperty("href")]
        //public string Href { get; set; }

        //[JsonProperty("id")]
        //public string Id { get; set; }

        //[JsonProperty("name")]
        //public string Name { get; set; }
    }
}