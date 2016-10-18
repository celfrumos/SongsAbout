using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp.Classes
{
    public class DbEntity<T>
    {
        protected static string _type
        {
            get
            {
                if (_entity is Artist)
                {
                    return "Artist";
                }
                else if (_entity is Album)
                {
                    return "Album";
                }
                else if (_entity is Track)
                {
                    return "Track";
                }
                else
                {
                    throw new InvalidDbDataTypeError<T>();
                }
            }
        }

        private static T _entity;

        private static string _titleColumn
        {
            get
            {
                if (_entity is Artist)
                {
                    return Artist.TitleColumn;
                }
                else if (_entity is Album)
                {
                    return Album.TitleColumn;
                }
                else if (_entity is Track)
                {
                    return Track.TitleColumn;
                }
                else
                {
                    throw new InvalidDbDataTypeError<T>();
                }
            }
        }

        private static string _table
        {
            get
            {
                if (_entity is Artist)
                {
                    return Artist.Table;
                }
                else if (_entity is Album)
                {
                    return Album.Table;
                }
                else if (_entity is Track)
                {
                    return Track.Table;
                }
                else
                {
                    throw new InvalidDbDataTypeError<T>();
                }
            }
        }

        protected void Submit()
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    switch (_table)
                    {
                        case "Artists":
                            context.Artists.InsertOnSubmit(_entity as Artist);
                            break;
                        case "Albums":
                            context.Albums.InsertOnSubmit(_entity as Album);
                            break;
                        case "Tracks":
                            context.Tracks.InsertOnSubmit(_entity as Track);
                            break;
                        case "Genres":
                            context.Genres.InsertOnSubmit(_entity as Genre);
                            break;
                        case "TrackGenres":
                            context.TrackGenres.InsertOnSubmit(_entity as TrackGenre);
                            break;
                        default:
                            break;
                    }
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new SaveError<T>(ex.Message);
            }
        }

        protected static bool Exists(int id)
        {
            T a = _entity;
            var t = _table;
            var c = _titleColumn;
                
            try
            {
                string aquery = $"SELECT {_titleColumn} FROM {_table} WHERE {_titleColumn} = '{id}'";
                //LINQ syntax
                //var aquery =
                //    from _titleColumn in _table
                //    where _titleColumn == id
                //    select id;
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    List<T> entities = db.ExecuteQuery<T>(aquery).ToList();
                    return entities.Count > 0;                    
                }
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundError<T>(id, ex.Message);
            }
        }

        protected static bool Exists(string name)
        {
            try
            {
                T a = _entity;
                var t = _table;
                var c = _titleColumn;
                formatName(ref name);
                string aquery = $"SELECT {_titleColumn} FROM {_table} WHERE {_titleColumn} = '{name}'";
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    List<T> entities = db.ExecuteQuery<T>(aquery).ToList();
                    return entities.Count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundError<T>(name, ex.Message);
            }
        }

        protected static T Load(string title)
        {
            try
            {
                formatName(ref title);
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string query = $"SELECT {_titleColumn} FROM {_table} WHERE {_titleColumn} = '{title}'";
                    var entities = db.ExecuteQuery<T>(query);
                    foreach (T t in entities)
                    {
                        return t;
                    }
                    throw new EntityNotFoundError<T>(title);
                }
            }
            catch (Exception ex)
            {
                throw new LoadError<T>(title, ex.Message);
            }
        }

        protected static T Load(int id)
        {
            try
            {
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string query = $"SELECT {_titleColumn} FROM {_table} WHERE {_titleColumn} = '{id}'";
                    var entities = db.ExecuteQuery<T>(query);
                    foreach (T t in entities)
                    {
                        return t;
                    }

                    throw new EntityNotFoundError<T>(id);
                }
            }
            catch (Exception ex)
            {
                throw new LoadError<T>(id, ex.Message);
            }
        }


        private static void formatName(ref string name)
        {
            if (name.Contains("\'"))
            {
                int i = name.IndexOf("\'");
                name = name.Insert(i, "'");
            }
        }
    }
}
