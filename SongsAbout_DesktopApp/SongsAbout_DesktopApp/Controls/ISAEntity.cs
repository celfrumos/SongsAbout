using SongsAbout.Enums;
using SongsAbout.Entities;

namespace SongsAbout.Controls
{
    public interface IEntityControl
    {
        string Level { get; set; }
        string Text { get; set; }
        DbEntity DbEntity { get; set; }
        SpotifyEntityType SpotifyEntityType { get; set; }
        DbEntityType DbEntityType { get; set; }
    }


}