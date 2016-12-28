using SongsAbout.Enums;
using SongsAbout.Entities;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Controls
{
        public interface IEntityControl
    {
        string Text { get; set; }
        DbEntity DbEntity { get; set; }
        string EntityName { get;  }
        SpotifyIntegralEntity SpotifyEntity { get; set; }
        SpotifyEntityType SpotifyEntityType { get; set; }
        DbEntityType DbEntityType { get; }
        bool ImportEntity();
    }
}