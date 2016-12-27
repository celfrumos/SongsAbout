﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SpotifyAPI.Web.Enums;

namespace SpotifyAPI.Web.Models
{
    public class SpotifyAlbum : SpotifyIntegralEntity, ISpotifyImageList
    {
        public override SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.BaseAlbum; } }
        public override bool CanHaveImages
        {
            get { return true; }
        }
        public override SpotifyEntityType DbEntityType { get { return SpotifyEntityType.Album; } }
        [JsonProperty("album_type")]
        public string AlbumType { get; set; }

        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        [JsonProperty("images")]
        public List<SpotifyImage> Images { get; set; }

        public SpotifyFullAlbum GetFullVersion(SpotifyWebAPI api)
        {
            if (api == null)
                throw new SpotifyUndefinedAPIError();

            return api.GetAlbum(this.Id);
        }

        //[JsonProperty("name")]
        //public string Name { get; set; }

        //[JsonProperty("type")]
        //public string Type { get; set; }

        //[JsonProperty("uri")]
        //public string Uri { get; set; }

        //[JsonProperty("external_urls")]
        //public Dictionary<string, string> ExternalUrls { get; set; }

        //[JsonProperty("href")]
        //public string Href { get; set; }

        //[JsonProperty("id")]
        //public string Id { get; set; }
    }
}