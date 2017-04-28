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

        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Topic> Topics { get; set; }
        public List<Keyword> Keywords { get; set; }
        public List<Genre> Genres { get; set; }

    }
}