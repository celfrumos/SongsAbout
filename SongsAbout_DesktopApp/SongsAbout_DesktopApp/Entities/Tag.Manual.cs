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
    public partial class Tag : DbEntity
    {
        public override string TitleColumnName { get { return "tag_text"; } }
        public override string TableName { get { return "Tags"; } }
        public override string Name
        {
            get { return this.tag_text; }
            set { this.tag_text = value; }
        }
        public override string TypeName { get { return typeof(Tag).ToString(); } }
        public override void Save()
        {
            if (!Exists(this.Name))
            {
                using (var db = new DataClassesContext())
                {
                    db.Tags.Add(this);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine($"Attempted to save a tag that already exists");
            }
        }
        public static bool Exists(string name)
        {

            using (var db = new DataClassesContext())
            {
                return (from tag in db.Tags
                        where tag.tag_text == name
                        select tag).Count() > 0;
            }
        }
        public void Save(DataClassesContext db)
        {
            if ((from tag in db.Tags
                 where tag.tag_text == this.tag_text
                 select tag).Count() == 0)
            {
                db.Tags.Add(this);
                Console.WriteLine("Tag added, but not saved in Tag.Manual. To save with passed in DataClassesContext, SaveChanges in the calling context.");
            }
        }
        public override DbEntityType DbEntityType { get { return DbEntityType.Tag; } }
        public override SpotifyEntityType SpotifyType
        {
            get { return SpotifyEntityType.None; }
            set { throw new InvalidOperationException("Tag does not have a changeable SpotifyEntityType"); }
        }

       
    }
}
