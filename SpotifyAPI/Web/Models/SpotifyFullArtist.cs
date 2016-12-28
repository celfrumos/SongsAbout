﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SpotifyAPI.Web.Enums;

namespace SpotifyAPI.Web.Models
{
    public class SpotifyFullArtist : SpotifyArtist, ISpotifyImageList
    {
        public override SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.FullArtist; } }

        public override bool CanHaveImages { get { return true; } }

        [JsonProperty("followers")]
        public Followers Followers { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("images")]
        public List<SpotifyImage> Images { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        //[JsonProperty("type")]
        //public string Type { get; set; }

        //[JsonProperty("href")]
        //public string Href { get; set; }

        //[JsonProperty("external_urls")]
        //public Dictionary<string, string> ExternalUrls { get; set; }

        //[JsonProperty("id")]
        //public string Id { get; set; }

        //[JsonProperty("name")]
        //public string Name { get; set; }

        //[JsonProperty("uri")]
        //public string Uri { get; set; }
    }
}