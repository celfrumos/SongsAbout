using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Classes;
using SongsAbout.Enums;
using SongsAbout.Controls;

namespace SongsAbout.Entities
{
    public abstract class DbEntity
    {
        protected DbEntity()
        {
            this.SpotifyType = SpotifyEntityType.None;
            this.DbEntityType = DbEntityType.None;
        }
        public abstract string TitleColumnName { get; }
        public abstract string TableName { get; }
        public abstract string Name { get; set; }
        public virtual string TypeName { get { return typeof(DbEntity).ToString(); } }
        public abstract void Save();
      public virtual DbEntityType DbEntityType { get; }
        public virtual SpotifyEntityType SpotifyType { get; set; }
        public virtual ISpotifyEntity ISpotifyEntity { get; set; }
        protected static void formatName(ref string name)
        {
            if (name.Contains("\'"))
            {
                int i = name.IndexOf("\'");
                name = name.Insert(i, "'");
            }
        }

   }
}
