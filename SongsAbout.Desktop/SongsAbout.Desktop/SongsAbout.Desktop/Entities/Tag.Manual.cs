﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout;
using SongsAbout.Enums;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;


namespace SongsAbout.Desktop.Entities
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
        public Tag(string name)
        {
            this.Name = name;

        }
        static public implicit operator Tag(string name)
        {
            return new Tag(name);
        }

        public override void Save()
        {
            if (!Exists(this.Name))
            {
                using (var db = new DbEntityContext())
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

            using (var db = new DbEntityContext())
            {
                return (from tag in db.Tags
                        where tag.tag_text == name
                        select tag).Count() > 0;
            }
        }
        public void Save(DbEntityContext db)
        {
            if ((from tag in db.Tags
                 where tag.tag_text == this.tag_text
                 select tag).Count() == 0)
            {
                db.Tags.Add(this);
                Console.WriteLine("Tag added, but not saved in Tag.Manual. To save with passed in DbEntityContext, SaveChanges in the calling context.");
            }
        }
        public override DbEntityType DbEntityType { get { return DbEntityType.Tag; } }
        public override SpotifyEntityType SpotifyType
        {
            get { return SpotifyEntityType.None; }
        }


    }
}
