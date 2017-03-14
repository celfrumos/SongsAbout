using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public abstract class SaEntity
    {
        protected const string SPOTIFY_API_BASE = @"https://api.spotify.com/v1";
        protected const string SPOTIFY_WEB_PAGE_BASE = @"https://open.spotify.com";

        protected abstract string TypeName { get; }

        public abstract string Name { get; set; }

        public virtual List<Genre> Genres { get; set; }
        public virtual List<Topic> Topics { get; set; }
        public virtual List<Keyword> Keywords { get; set; }

        [Display(Name = "Spotify Id")]
        [StringLength(50)]
        public virtual string SpotifyId { get; set; }

        [Display(Name = "Spotify Details Web Page")]
        public string SpotifyWebPage
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.TypeName} '{this.Name}'");

                return $"{SPOTIFY_WEB_PAGE_BASE}/{this.TypeName}/{this.SpotifyId}";

            }
        }

        [Display(Name = "Spotify API Link")]
        public virtual string ApiHref
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.TypeName} '{this.Name}'");

                return $"{SPOTIFY_API_BASE}/{this.TypeName}s/{this.SpotifyId}";
            }
        }

        [Display(Name = "Spotify URI")]
        public virtual string SpotifyUri
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {this.TypeName} '{this.Name}'");

                return $"spotify:artist:{this.SpotifyId}";
            }
        }


    }
}