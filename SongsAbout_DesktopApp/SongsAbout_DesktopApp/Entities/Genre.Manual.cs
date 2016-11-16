using System;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout.Entities
{
    public partial class Genre
    {
        public bool Exists(string name)
        {
            int num;
            using (var db = new DataClassContext())
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
