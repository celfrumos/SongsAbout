using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{

    public enum SaEntityType
    {
        Artist = 0,
        Album = 1,
        Track = 2,
        Topic = 4,
        Genre = 8,
        Keyword,
        Any = Artist | Album | Track | Topic | Genre
    }

}