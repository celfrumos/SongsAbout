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
        public List<ISaEntity> Items { get; set; } = new List<ISaEntity>();

        public IEnumerable<Album> Albums
        {
            get
            {
                try
                {
                    return from a in Items
                           where a.EntityType == SaEntityType.Album
                           select (Album)a;
                }
                catch (Exception ex)
                {
                    return new List<Album>();
                }
            }
        }

        public IEnumerable<Artist> Artists
        {
            get
            {
                try
                {
                    return from a in Items
                           where a.EntityType == SaEntityType.Artist
                           select (Artist)a;
                }
                catch (Exception ex)
                {
                    return new List<Artist>();
                }
            }
        }

        public IEnumerable<Track> Tracks
        {
            get
            {
                try
                {
                    return from a in Items
                           where a.EntityType == SaEntityType.Track
                           select (Track)a;
                }
                catch (Exception ex)
                {
                    return new List<Track>();
                }
            }
        }

        public IEnumerable<Topic> Topics
        {
            get
            {
                try
                {
                    return from a in Items
                           where a.EntityType == SaEntityType.Topic
                           select (Topic)a;
                }
                catch (Exception ex)
                {
                    return new List<Topic>();
                }
            }
        }

        public IEnumerable<Keyword> Keywords
        {
            get
            {
                try
                {
                    return from a in Items
                           where a.EntityType == SaEntityType.Keyword
                           select (Keyword)a;
                }
                catch (Exception ex)
                {
                    return new List<Keyword>();
                }
            }
        }

        public IEnumerable<Genre> Genres
        {
            get
            {
                try
                {
                    return from a in Items
                           where a.EntityType == SaEntityType.Genre
                           select (Genre)a;
                }
                catch (Exception ex)
                {
                    return new List<Genre>();
                }
            }
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