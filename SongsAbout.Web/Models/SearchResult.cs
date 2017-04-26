using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    [Flags]
    public enum SearchMethod
    {
        Artist = 0,
        Album = 1,
        Track = 2,
        Topic = 4,
        Genre = 8,
        Any = Artist | Album | Track | Topic | Genre
    }

    public class SearchResult
    {
        public SearchMethod SearchMethod { get; set; } = SearchMethod.Any;
        public List<ISaEntity> Items { get; set; } = new List<ISaEntity>();
        public int StartIndex { get; set; } = -1;
        public int EndIndex { get; set; } = -1;
        public int Count { get { return this.Items?.Count ?? 0; } }

    }
}