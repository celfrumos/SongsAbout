using SongsAbout.Enums;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;

namespace SongsAbout.Entities
{
    public interface IDbEntity
    {
        DbEntityType DbEntityType { get; }
        string Name { get; set; }
        SpotifyEntityType SpotifyType { get; set; }
        string TableName { get; }
        string TitleColumnName { get; }
        string TypeName { get; }

        void Save();
        void Save(DataClassesContext db);
    }
}