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

        [Display(Name = "Artist")]
        public abstract string Name { get; set; }

        public virtual string SpotifyWebPage { get { return $"{SPOTIFY_WEB_PAGE_BASE}/{this.TypeName}/{this.SpotifyId}"; } }

        [Display(Name = "Spotify API Link")]
        public virtual string ApiHref { get { return $"{SPOTIFY_API_BASE}/{this.TypeName}s/{this.SpotifyId}"; } }

        [Display(Name = "Spotify URI")]
        public virtual string SpotifyUri { get { return $"spotify:artist:{this.SpotifyId}"; } }

        [Display(Name = "Spotify Id")]
        public virtual string SpotifyId { get; set; }

    }
}