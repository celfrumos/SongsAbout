using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public static class Constants
    {
        public const string SPOTIFY_API_BASE = @"https://api.spotify.com/v1";
        public const string SPOTIFY_WEB_PAGE_BASE = @"https://open.spotify.com";

    }
    //[NotMapped]
    //public abstract class SaEntity
    //{
    //    //[Index]
    //    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    //    //public int? Index { get; set; }

    //    public abstract int Id { get; set; }

    //    //  [EnumDataType(typeof(SaEntityType), ErrorMessage = "Error related to EntityType")]
    //    [NotMapped]
    //    public abstract SaEntityType EntityType { get; }

    //    [NotMapped]
    //    protected virtual string TypeName { get; }

    //    public abstract string Name { get; set; }

    //    public virtual List<Genre> Genres { get; set; }
    //    public virtual List<Topic> Topics { get; set; }
    //    public virtual List<Keyword> Keywords { get; set; }

    //    [NotMapped]
    //    public static List<AutoCompleteResult> AutoCompleteResults { get; set; }

    //    [Display(Name = "Spotify Id")]
    //    [StringLength(50)]
    //    public virtual string SpotifyId { get; set; }

    //    [NotMapped]
    //    [Display(Name = "Spotify Details Web Page")]
    //    public string SpotifyWebPage
    //    {
    //        get
    //        {
    //            if (this.SpotifyId == null)
    //                throw new Exception($"Spotify Id not found for {this.TypeName} '{this.Name}'");

    //            return $"{Constants.SPOTIFY_WEB_PAGE_BASE}/{this.TypeName}/{this.SpotifyId}";

    //        }
    //    }

    //    [NotMapped]
    //    [Display(Name = "Spotify API Link")]
    //    public virtual string ApiHref
    //    {
    //        get
    //        {
    //            if (this.SpotifyId == null)
    //                throw new Exception($"Spotify Id not found for {this.TypeName} '{this.Name}'");

    //            return $"{Constants.SPOTIFY_API_BASE}/{this.TypeName}s/{this.SpotifyId}";
    //        }
    //    }

    //    [NotMapped]
    //    [Display(Name = "Spotify URI")]
    //    public virtual string SpotifyUri
    //    {
    //        get
    //        {
    //            if (this.SpotifyId == null)
    //                throw new Exception($"Spotify Id not found for {this.TypeName} '{this.Name}'");

    //            return $"spotify:artist:{this.SpotifyId}";
    //        }
    //    }


    //}
}