using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SpotifyAPI.Web.Enums;

namespace SpotifyAPI.Web.Models
{
    public class SimpleArtist : SpotifyIntegralEntity
    {
        public override SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.SimpleArtist; } }

    //[JsonProperty("external_urls")]
    //public Dictionary<string, string> ExternalUrls { get; set; }

    //[JsonProperty("href")]
    //public string Href { get; set; }

    //[JsonProperty("id")]
    //public string Id { get; set; }

    //[JsonProperty("name")]
    //public string Name { get; set; }

    //[JsonProperty("type")]
    //public string Type { get; set; }

    //[JsonProperty("uri")]
    //public string Uri { get; set; }
}
}