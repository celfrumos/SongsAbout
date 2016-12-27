using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SpotifyAPI.Web.Enums;

namespace SpotifyAPI.Web.Models
{
    public class SpotifyFullPlaylist : SpotifyPlaylist
    {
        public override SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.FullPlaylist; } }

        [JsonProperty("followers")]
        public Followers Followers { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        //[JsonProperty("collaborative")]
        //public Boolean Collaborative { get; set; }


        //[JsonProperty("external_urls")]
        //public Dictionary<string, string> ExternalUrls { get; set; }


        //[JsonProperty("href")]
        //public string Href { get; set; }

        //[JsonProperty("id")]
        //public string Id { get; set; }

        //[JsonProperty("images")]
        //public List<SpotifyImage> Images { get; set; }

        //[JsonProperty("name")]
        //public string Name { get; set; }

        //[JsonProperty("owner")]
        //public PublicProfile Owner { get; set; }

        //[JsonProperty("public")]
        //public Boolean Public { get; set; }

        //[JsonProperty("tracks")]
        //public Paging<PlaylistTrack> Tracks { get; set; }

        //    [JsonProperty("type")]
        //    public string Type { get; set; }

        //    [JsonProperty("uri")]
        //    public string Uri { get; set; }
    }
}