using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp.Classes
{
    public class DbEntity<T>
    {
     
        protected string _title { get; set; }
        protected string _table { get; set; }
        protected int _id { get; set; }

        protected void Save(T entity, string table)
        {
            try
            {
                using (DataClassesDataContext context = new DataClassesDataContext())
                {
                    switch (table)
                    {
                        case "Artists":
                            context.Artists.InsertOnSubmit(entity as Artist);
                            break;
                        case "Albums":
                            context.Albums.InsertOnSubmit(entity as Album);
                            break;
                        case "Tracks":
                            context.Tracks.InsertOnSubmit(entity as Track);
                            break;
                        case "Genres":
                            context.Genres.InsertOnSubmit(entity as Genre);
                            break;
                        case "TrackGenres":
                            context.TrackGenres.InsertOnSubmit(entity as TrackGenre);
                            break;
                        default:
                            break;
                    }
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error Saving {entity.ToString()}: {ex.Message}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        protected static bool Exists(int id, string column, string table)
        {
            try
            {
                string aquery = $"SELECT * FROM {table} WHERE {column} = '{id}'";
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
                string msg = $"Error verifying if id '{id}' exists in {table} table: {ex.Message}";
                Console.WriteLine("In DbEntity Exists: " + msg);
                throw new Exception(msg);
            }
        }

        protected static bool Exists(string name, string column, string table)
        {
            try
            {
                formatName(ref name);
                string aquery = $"SELECT * FROM {table} WHERE {column} = '{name}'";
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
                string msg = $"Error verifying if entity: '{name}' exists in {table} table: {ex.Message}";
                Console.WriteLine("In DbEntity Exists: " + msg);
                throw new Exception(msg);
            }
        }

        protected static T Load(string title, string column, string table)
        {
            try
            {
                formatName(ref title);
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    string query = $"SELECT * FROM {table} WHERE {column} = '{title}'";
                    var entities = db.ExecuteQuery<T>(query);
                    foreach (var t in entities)
                    {
                        return t;
                    }

                    throw new Exception($"No item in {table} table with name '{title}' found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Loading entity '{title}' from {table} table: {ex.Message}");
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
