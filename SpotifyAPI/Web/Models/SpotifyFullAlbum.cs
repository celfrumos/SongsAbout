using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SpotifyAPI.Web.Enums;

namespace SpotifyAPI.Web.Models
{
    public class SpotifyFullAlbum : SpotifyAlbum
    {
        public override SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.FullAlbum; } }


        [JsonProperty("artists")]
        public List<SpotifyArtist> Artists { get; set; }
        
        [JsonProperty("copyrights")]
        public List<Copyright> Copyrights { get; set; }

        [JsonProperty("external_ids")]
        public Dictionary<string, string> ExternalIds { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("release_date_precision")]
        public string ReleaseDatePrecision { get; set; }

        [JsonProperty("tracks")]
        public Paging<SpotifyTrack> Tracks { get; set; }

        //[JsonProperty("available_markets")]
        //public List<string> AvailableMarkets { get; set; }

        //[JsonProperty("album_type")]
        //public string AlbumType { get; set; }

        //[JsonProperty("images")]
        //public List<SpotifyImage> Images { get; set; }

        //[JsonProperty("name")]
        //public string Name { get; set; }

        //[JsonProperty("href")]
        //public string Href { get; set; }

        //[JsonProperty("id")]
        //public string Id { get; set; }

        //[JsonProperty("type")]
        //public string Type { get; set; }

        //[JsonProperty("uri")]
        //public string Uri { get; set; }

        //[JsonProperty("external_urls")]
        //public Dictionary<string, string> ExternalUrls { get; set; }

    }
}