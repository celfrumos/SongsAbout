﻿using SongsAbout.Enums;
using SongsAbout.Entities;
using SpotifyAPI.Web.Enums;

namespace SongsAbout.Controls
{
        public interface IEntityControl
    {
        string Text { get; set; }
        DbEntity DbEntity { get; set; }
        ISpotifyEntity SpotifyEntity { get; set; }
        SpotifyEntityType SpotifyEntityType { get; set; }
        DbEntityType DbEntityType { get; }
        bool ImportEntity();
    }
}