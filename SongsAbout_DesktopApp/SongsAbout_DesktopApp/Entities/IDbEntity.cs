using SongsAbout.Enums;

namespace SongsAbout.Entities
{
    public interface IDbEntity
    {
        DbEntityType DbEntityType { get; set; }
        string Name { get; set; }
        SpotifyEntityType SpotifyType { get; set; }
        string TableName { get; }
        string TitleColumnName { get; }
        string TypeName { get; }

        void Save();
        void Save(DataClassesContext db);
    }
}