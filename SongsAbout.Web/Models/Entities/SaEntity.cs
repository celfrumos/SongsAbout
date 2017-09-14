using SpotifyAPI.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace SongsAbout.Web.Models
{
    public static class Constants
    {
        public const string SPOTIFY_API_BASE = @"https://api.spotify.com/v1";
        public const string SPOTIFY_WEB_PAGE_BASE = @"https://open.spotify.com";

    }

    public enum EntityDisplayType
    {
        Spotlight,
        SearchResult,
        List,
        Related
    }

    [Serializable]
    [DebuggerDisplay("Name={Name}, Id={Id}")]
    public abstract class SaDbEntityAccessor : ISaDbEntityAccessor
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

    }

    [Serializable]
    public abstract class SaEntity : SaDbEntityAccessor, ISaEntity
    {
        [NotMapped]
        public abstract SaEntityType EntityType { get; }

    }

    public abstract class SaSpotifyAccessEntity : SaEntity, ISpotifyAccessor
    {
        public string SpotifyId { get; set; }
        [NotMapped]
        [Display(Name = "Spotify Details Web Page")]
        public string SpotifyWebPage
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.GetType().Name} '{this.Name}'");

                return $"{Constants.SPOTIFY_WEB_PAGE_BASE}/{this.GetType().Name.ToLower()}/{this.SpotifyId}";

            }
        }

        [NotMapped]
        [Display(Name = "Spotify URI")]
        public string SpotifyUri
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.GetType().Name} '{this.Name}'");

                return $"spotify:{this.GetType().Name.ToLower()}:{this.SpotifyId}";
            }
        }

        [NotMapped]
        [Display(Name = "Spotify API Link")]
        public string ApiHref
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.GetType().Name} '{this.Name}'");

                return $"{Constants.SPOTIFY_API_BASE}/{this.GetType().Name.ToLower()}s/{this.SpotifyId}";
            }
        }

    }
}