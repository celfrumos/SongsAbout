using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SongsAbout;
using SongsAbout.Entities;
using SongsAbout.Enums;
using System.Collections;

namespace SongsAbout.Database
{
    public partial class SongDatabase
    {
        public class GenreCollection : EntityCollection<Genre>
        {
            public override bool HasIntId { get { return false; } }
            public override DbEntityType DbEntityType { get { return DbEntityType.Genre; } }
            private static bool _initialized { get; set; }

            private const string COLLECTION_NAME = "GenreList";

            /// <summary>
            /// Initializes the connector to the GenreList
            /// </summary>
            /// <exception cref="InvalidInitializedError"></exception>"
            public GenreCollection() : base(COLLECTION_NAME)
            {
                if (_initialized)
                {
                    throw new InvalidInitializedError(COLLECTION_NAME);
                }
                _initialized = true;

            }
            protected override Genre FindByName(string name)
            {
                Genre result;
                using (var db = new DbEntityContext())
                {
                    result = db.Genres.Find(name);
                }
                return result;

            }

            /// <summary>
            /// Returns A list of all Existing Genres in the database
            /// </summary>            
            /// <returns></returns>
            /// <exception cref="DbException"></exception>
            public override List<Genre> Items
            {
                get
                {
                    try
                    {
                        base.CachedItems = new List<Genre>();
                        using (var db = new DbEntityContext())
                        {
                            base.CachedItems.AddRange(from a in db.Genres
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
            public override void Add(Genre genre)
            {
                if (genre.Name == "" || genre.Name == null)
                    throw new NullValueError("Genre name cannot be null.");

                if (this.Contains(genre.Name))
                    throw new ValueAlreadyPresentException(DbEntityType, genre.Name);

                try
                {
                    using (var db = new DbEntityContext())
                    {
                        db.Genres.Add(genre);
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