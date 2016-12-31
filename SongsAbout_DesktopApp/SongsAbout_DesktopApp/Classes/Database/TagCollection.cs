using System;
using System.Collections.Generic;
using System.Linq;
using SongsAbout.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Classes.Database
{
    public partial class SongDatabase
    {
        public class TagCollection : EntityCollection<Tag>
        {
            public override bool HasIntId { get { return false; } }
            public override DbEntityType DbEntityType { get { return DbEntityType.Tag; } }
            private static bool _initialized { get; set; }

            private const string COLLECTION_NAME = "TagCollection";

            /// <summary>
            /// Initializes the connector to the GenreList
            /// </summary>
            /// <exception cref="InvalidInitializedError"></exception>"
            public TagCollection() : base(COLLECTION_NAME)
            {
                if (_initialized)
                {
                    throw new InvalidInitializedError(COLLECTION_NAME);
                }
                _initialized = true;

            }

            /// <summary>
            /// Returns A list of all Existing Genres in the database
            /// </summary>            
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public override List<Tag> Items
            {
                get
                {
                    try
                    {
                        base.CachedItems = new List<Tag>();
                        using (var db = new DataClassesContext())
                        {
                            base.CachedItems.AddRange(from a in db.Tags
                                                      select a);
                        }
                        return base.CachedItems;
                    }
                    catch (Exception ex)
                    {
                        throw new DbException($"Error loading All Genres from database: {ex.Message}");
                    }
                }
                protected set
                {
                    this.CachedItems = value;
                }
            }

            /// <summary>
            /// Submit Changes to the Database
            /// </summary>
            /// <exception cref="NullValueError"></exception>
            /// <exception cref="ValueAlreadyPresentException"></exception>"
            /// <exception cref="DbException"></exception>"
            public override void Add(Tag Tag)
            {
                if (Tag.Name == "" || Tag.Name == null)
                    throw new NullValueError("Genre name cannot be null.");

                if (this.Contains(Tag.Name))
                    throw new ValueAlreadyPresentException(DbEntityType, Tag.Name);

                try
                {
                    using (var db = new DataClassesContext())
                    {
                        db.Tags.Add(Tag);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    throw new DbException(ex.Message);
                }
            }
        }
    }
}
