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
                    throw new Exception("Invalid data type used for DbEntity<> class.");
                }
            }
        }
        
        private static T _entity { get; }

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
                    throw new Exception("Invalid data type used for DbEntity<> class.");
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
                    throw new Exception("Invalid data type used for DbEntity<> class.");
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
                string msg = $"Error Saving {_type}: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        protected static bool Exists(int id)
        {
            try
            {
                string aquery = $"SELECT * FROM {_table} WHERE {_titleColumn} = '{id}'";
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    var entities = db.ExecuteQuery<T>(aquery);

                    foreach (T t in entities)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error verifying if {_type} with id '{id}' exists: {ex.Message}";
                Console.WriteLine("In DbEntity Exists: " + msg);
                throw new Exception(msg);
            }
        }

        protected static bool Exists(string name)
        {
            try
            {
                formatName(ref name);
                string aquery = $"SELECT * FROM {_table} WHERE {_titleColumn} = '{name}'";
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    var entities = db.ExecuteQuery<T>(aquery);

                    foreach (T t in entities)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error verifying if entity: '{name}' exists in {_table} table: {ex.Message}";
                Console.WriteLine("In DbEntity Exists: " + msg);
                throw new Exception(msg);
            }
        }

        protected static T Load(string title)
        {
            try
            {
                formatName(ref title);
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string query = $"SELECT * FROM {_table} WHERE {_titleColumn} = '{title}'";
                    var entities = db.ExecuteQuery<T>(query);
                    foreach (T t in entities)
                    {
                        return t;
                    }

                    throw new Exception($"No {_type} in {_table} table with name '{title}' found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Loading {_type} '{title}' from {_table} table: {ex.Message}");
            }
        }

        protected static T Load(int id)
        {
            try
            {
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string query = $"SELECT * FROM {_table} WHERE {_titleColumn} = '{id}'";
                    var entities = db.ExecuteQuery<T>(query);
                    foreach (T t in entities)
                    {
                        return t;
                    }

                    throw new Exception($"No {_type} in {_table} table with name '{id}' found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Loading {_type} with id '{id}' from {_table} table: {ex.Message}");
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
