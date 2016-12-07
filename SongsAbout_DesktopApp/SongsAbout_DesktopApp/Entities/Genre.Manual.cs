using System;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Classes;
using SongsAbout.Enums;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Entities
{
    public partial class Genre : DbEntity
    {
        public static List<string> ExistingGenres { get; set; }
        public override DbEntityType DbEntityType
        {
            get { return DbEntityType.Genre; }
        }
        public override string TableName
        {
            get { return "Genres"; }
        }
        public override string TitleColumnName
        {
            get { return "genre"; }
        }
        public override string TypeName
        {
            get { return base.TypeName; }
        }

        public override SpotifyEntityType SpotifyType
        {
            get { return SpotifyEntityType.None; }
            set { }
        }
        public override string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                _saved = false;
            }
        }
        private bool _saved = false;
        public override void Save()
        {
            if (!this._saved && !Exists(this.Name))
            {
                using (var db = new DataClassesContext())
                {
                    db.Genres.Add(this);
                    db.SaveChanges();
                    this._saved = true;
                }
            }
        }
        public Genre(string name)
        {
            this.Name = name;
            if (!SongDatabase.ExistingGenres.Contains(name))
            {
                Save();
            }
        }
        public static bool Exists(string name)
        {
            bool result = true;
            using (var db = new DataClassesContext())
            {
                var genreNum =
                     (from g in db.Genres
                      where g.Name == name
                      select g).Count();
                result = genreNum > 0;
            }
            return result;
        }
    }
}
