using Newtonsoft.Json;
using System;
using SpotifyAPI.Web.Enums;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public class SpotifyTrack : SpotifyIntegralEntity
    {
        public override bool CanHaveImages { get { return false; } }
        public override SpotifyEntityType SpotifyEntityType { get { return SpotifyEntityType.BaseTrack; } }
        public override SpotifyEntityType DbEntityType { get { return SpotifyEntityType.Track; } }
        [JsonProperty("artists")]
        public List<SpotifyArtist> Artists { get; set; }

        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }

        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }

        [JsonProperty("explicit")]
        public Boolean Explicit { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

        [JsonProperty("album")]
        public SpotifyAlbum Album { get; set; }

        /// <summary> 
        /// Get the full version of this track 
        /// </summary> 
        /// <param name="api"></param> 
        /// <returns></returns> 
        /// <exception cref="SpotifyUndefinedAPIError"></exception> 
        public SpotifyFullTrack FullVersion(SpotifyWebAPI api)
        {
            if (api == null)
                throw new SpotifyUndefinedAPIError();

            return api.GetTrack(this.Id);
        }

        //[JsonProperty("type")] 
        //public string Type { get; set; } 

        //[JsonProperty("external_urls")] 
        //public Dictionary<string, string> ExternalUrls { get; set; } 

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