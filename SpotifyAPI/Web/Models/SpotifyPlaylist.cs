using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SpotifyAPI.Web.Enums;

namespace SpotifyAPI.Web.Models
{
    public class SpotifyPlaylist : SpotifyIntegralEntity, ISpotifyImageList
    {
        public override SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.BasePlaylist; } }
        public override bool CanHaveImages { get { return true; } }
        public override SpotifyEntityType DbEntityType { get { return SpotifyEntityType.Playlist; } }
        [JsonProperty("collaborative")]
        public Boolean Collaborative { get; set; }

        [JsonProperty("images")]
        public List<SpotifyImage> Images { get; set; }

        [JsonProperty("owner")]
        public PublicProfile Owner { get; set; }

        [JsonProperty("public")]
        public Boolean Public { get; set; }

        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; set; }

        [JsonProperty("tracks")]
        public PlaylistTrackCollection Tracks { get; set; }

        //[JsonProperty("type")]
        //public string Type { get; set; }

        //[JsonProperty("external_urls")]
        //public Dictionary<string, string> ExternalUrls { get; set; }

        //[JsonProperty("href")]
        //public string Href { get; set; }

        //[JsonProperty("id")]
        //public string Id { get; set; }

        //[JsonProperty("name")]
        //public string Name { get; set; }
        //[JsonProperty("uri")]
        //public string Uri { get; set; }
    }
}