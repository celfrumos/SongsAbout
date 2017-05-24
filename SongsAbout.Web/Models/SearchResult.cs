using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{

    public enum SortMode
    {
        Ascending, Descending
    }

    public class SearchResult
    {
        public SaEntityType SearchMethod { get; set; } = SaEntityType.Any;

        public SortMode sort { get; set; } = SortMode.Descending;
        public Dictionary<Type, List<ISaEntity>> Items { get; set; } = new Dictionary<Type, List<ISaEntity>>();

        public List<Artist> Artists => Get<Artist>();
        public List<Album> Albums => Get<Album>();
        public List<Track> Tracks => Get<Track>();
        public List<Topic> Topics => Get<Topic>();
        public List<Keyword> Keywords => Get<Keyword>();
        public List<Genre> Genres => Get<Genre>();

        private List<T> Get<T>() where T : class, ISaEntity
        {
            var res = from a in this.Items[typeof(T)]
                      select a as T;

            return res.ToList();
        }

    }


    public class SearchQuery
    {
        [Display(Name = "Query", ShortName = "q")]
        public string query { get; set; } = "";

        [Display(Name = "Limit", ShortName = "limit")]
        public int limit { get; set; } = 5;

        [Display(Name = "Search Type", ShortName = "type")]
        public SaEntityType type { get; set; } = SaEntityType.Any;
    }
}