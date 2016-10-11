using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp.Classes.Exceptions
{
    public class DbException<T> : Exception
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

        protected static T _entity { get; }

        protected static string _titleColumn
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

        protected static string _table
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

        private static string defaultMsg = $"An Error Occurred while interacting with the database";

        public DbException() : base(defaultMsg) { }

        public DbException(string msg) : base(msg) { }
    }

    public class SaveError<T> : DbException<T>
    {
        private static string defaultMsg = $"Error Saving {_type}";

        public SaveError() :
            base(defaultMsg)
        {
            Console.WriteLine(defaultMsg);
        }

        public SaveError(string msg) :
            base(msg)
        {
            Console.WriteLine(msg);
        }

    }
    public class LoadError<T> : DbException<T>
    {
        private static string defaultMsg = $"Error Loading {_type} from Database";

        public LoadError() :
            base(defaultMsg)
        {
            Console.WriteLine(defaultMsg);
        }

        public LoadError(string msg) :
            base(msg)
        {
            Console.WriteLine(msg);
        }

        public LoadError(string name, string msg) :
            base($"Error Loading {_type} '{name}' from {_table} table: " + msg)
        {
            Console.WriteLine($"Error Loading {_type} '{name}' from {_table} table: " + msg);
        }

    }

    public class UpdateError<T> : DbException<T>
    {
        private static string defaultMsg = $"Error Updating {_type}";

        public UpdateError() :
            base(defaultMsg)
        {
            Console.WriteLine(defaultMsg);
        }

        public UpdateError(string msg) :
            base(msg)
        {
            Console.WriteLine(msg);
        }

        public UpdateError(string name, string msg) :
            base($"Error Updating {_type} '{name}'" + msg)
        {
            Console.WriteLine($"Error Updating {_type} '{name}': " + msg);
        }
    }

    public class EntityNotFoundError<T> : DbException<T>
    {
        private static string defaultMsg = $"The expected {_type} in {_table} table was not found";

        public EntityNotFoundError() :
            base(defaultMsg)
        {
            Console.WriteLine(defaultMsg);
        }

        public EntityNotFoundError(string name) :
            base($"No {_type} in {_table} table with name '{name}' found")
        {
            Console.WriteLine($"No {_type} in {_table} table with name '{name}' found");
        }

        public EntityNotFoundError(string name, string msg) :
            base($"No {_type} in {_table} table with name '{name}' found: " + msg)
        {
            Console.WriteLine($"No {_type} in {_table} table with name '{name}' found: " + msg);
        }
    }
}
