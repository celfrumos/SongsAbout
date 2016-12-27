using System;
using SpotifyAPI.Web.Enums;
using SongsAbout.Enums;

namespace SongsAbout.Entities
{
    public partial class Playlist : DbEntity
    {
        public override string TitleColumnName { get; }
        public override string TableName { get; }
        public override string Name
        {
            get { return this.list_name; }
            set { this.list_name = value; }
        }
        static public implicit operator Playlist(string name)
        {
            return new Playlist(name);
        }

        public Playlist(string name)
        {
            this.Name = name;
        }
        public int ID { get { return this.list_id; } }
        public override void Save()
        {
            if (!Program.Database.Playlists.Contains(this.Name))
            {
                using (var db = new DataClassesContext())
                {
                    db.Playlists.Add(this);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine($"Attempted to save a tag that already exists");
            }
        }
        public override DbEntityType DbEntityType { get { return DbEntityType.Playlist; } }
        public override SpotifyEntityType SpotifyType { get { return SpotifyEntityType.Playlist; } }
    }
}
