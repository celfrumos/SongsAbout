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
        Playlist = 4,
        Genre = 8,
        Any = Artist | Album | Track | Playlist | Genre            
    }
    
    public class SearchResults<T> where T : SaEntity
    {
        public SearchMethod SearchMethod { get; set; } = SearchMethod.Any;
        public List<T> Results { get; set; }
        public int StartIndex { get; set; } = -1;
        public int EndIndex { get; set; } = -1;
        public int Count { get { return this.Results?.Count ?? 0; } }

    }
}