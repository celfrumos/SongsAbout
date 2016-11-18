using System;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Enums;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Entities
{
    public partial class Genre : DbEntity
    {
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
            get { return this.genre; }
            set { this.genre = value; }
        }
        public string genre
        {
            get { return this.genre1; }
            set { this.genre1 = value; }
        }

        public override void Save()
        {
        }

        public bool Exists(string name)
        {
            int num;
            using (var db = new DataClassesContext())
            {
                var query =
                     from g in db.Genres
                     where g.genre == name
                     select g;
                num = query.Count();
            }
            return num > 0;
        }
    }
}
