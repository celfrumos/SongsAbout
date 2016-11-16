using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SongsAbout.Entities;
using SongsAbout.Controls;
using SongsAbout.Enums;
using System.Threading.Tasks;

namespace SongsAbout.Classes
{
    public class DbException : Exception
    {
        const string defMsg = "An Error Occurred while interacting with the database";
        protected string _message;

        public override string Message { get { return _message; } }

        public virtual SpotifyEntityType SpotifyType { get; set; }

        protected string _type
        {
            get { return _entity.TypeName; }
            set { _type = value; }
        }

        protected DbEntity _entity { get; set; }

        protected string _table
        {
            get { return _entity.TableName; }
            set { _table = value; }
        }

        protected string _titleColumn { get { return _entity.TitleColumnName; } }

        public DbException(DbEntity e, string msg = defMsg)
        {
            Initialize(e, msg);
        }

        protected void Initialize(DbEntity e, string msg)
        {
            _message = msg;

            _entity = e;
            _type = e.TypeName;
            _table = e.TableName;
        }

        public DbException(string msg = defMsg) : base(msg)
        {
            _message = msg;
        }
        public DbException(Type t, string msg = defMsg) : base(dbExDefMsg(t, msg))
        {
            _message = msg;
        }

        protected static string dbExDefMsg(DbEntity e, string msg = "")
        {
            return
            (msg == defMsg ? msg : $"Error Updating {e.TypeName} from {e.TableName} table: " + msg);

        }
        protected static string dbExDefMsg(Type t, string msg = "")
        {
            return
            (msg == defMsg ? msg : $"Error Updating {t} from  table. " + msg);

        }
    }

    public class SaveError : DbException
    {
        const string defaultMsg = "Error Saving to the database.";
        public SaveError(string msg = defaultMsg) : base($"Save Error: {msg}")
        {

        }
        public SaveError(DbEntity e, string name, string msg = defaultMsg)
            : base(e, saveErrDefMsg(e, name, msg))
        {
        }

        private static string saveErrDefMsg(DbEntity e, string name, string msg)
        {
            return
            (msg == defaultMsg ? msg : $"Error Updating {e.TypeName} '{name}' from {e.TableName} table: " + msg);

        }

    }

    public class LoadError : DbException
    {
        const string defaultMsg = "Error Loading entity from Database";

        LoadError(string msg = defaultMsg) : base($"Load Error: {msg}") { }

        public LoadError(DbEntity e, string name, string msg = defaultMsg)
            : base(loadDefMsg(e, name, msg))
        {
        }


        public LoadError(DbEntity e, int id, string msg = defaultMsg)
            : base(loadDefMsg(e, id, msg))
        {
            string se = $"Error Loading {_type} '{id}' from {_table} table: " + msg;
        }

        private static string loadDefMsg(DbEntity e, string name, string msg)
        {
            return
                (msg == defaultMsg ? msg : $"Error Loading {e.TypeName} '{name}' from {e.TableName} table: " + msg);
        }
        private static string loadDefMsg(DbEntity e, int id, string msg)
        {
            return (msg == defaultMsg ? msg : $"Error Loading {e.TypeName} with id {id} from {e.TableName} table: " + msg);
        }

    }

    public class UpdateError : DbException
    {
        const string defaultMsg = "Error Updating Entity in Database";

        public UpdateError(DbEntity e, string name, string msg = defaultMsg)
            : base(e, updateMsg(e, name, msg))
        {
        }
        public UpdateError(DbEntity e, Type spotifyType, string name, string msg = defaultMsg)
        {
            string m =
                (msg == defaultMsg ? msg : $"Error Updating {e.TypeName} '{name}' from {spotifyType} in {e.TableName} table: " + msg);
        }
        private static string updateMsg(DbEntity e, string name, string msg)
        {
            return
                (msg == defaultMsg ? msg : $"Error Updating {e.TypeName} '{name}' from {e.TableName} table: " + msg);
        }
    }
    public class EntityNotFoundError : DbException
    {
        const string defaultMsg = "The expected entity was not found";
        public EntityNotFoundError(Type t, string name, string msg = defaultMsg)
            : base(notFoundMsg(t, name, msg))
        {
        }
        public EntityNotFoundError(Type t, int id, string msg = defaultMsg)
        : base(notFoundMsg(t, id, msg))
        {
        }

        public EntityNotFoundError(DbEntity e, string name, string msg = defaultMsg)
            : base(notFoundMsg(e, name, msg))
        { }

        public EntityNotFoundError(DbEntity e, int id, string msg = defaultMsg)
            : base(notFoundMsg(e, id, msg))
        { }

        private static string notFoundMsg(Type t, string name, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity {t} named '{name}' not found in the intended table: " + msg);
        }

        private static string notFoundMsg(Type t, int id, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity '{t}' with id '{id}' not found in the intended table: " + msg);
        }
        private static string notFoundMsg(DbEntity e, string name, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity {e.TypeName} named '{name}' not found in {e.TableName} table: " + msg);
        }

        private static string notFoundMsg(DbEntity e, int id, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity {e.TypeName} with id '{id}' not found in {e.TableName} table: " + msg);
        }
    }

    public class SpotifyToDBImportException : DbException
    {
        const string defaultMsg = "Error importing data from spotify";

        public SpotifyToDBImportException(SpotifyEntityType spotifyType, DbEntity e, string msg = defaultMsg)
            : base(e, ImportDefMsg(spotifyType, e, msg))
        {

        }

        private static string ImportDefMsg(SpotifyEntityType spotifyType, DbEntity e, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Error importing {e.TypeName} data from spotify type '{spotifyType}'");

        }
    }

    public class NullValueError : Exception
    {
        const string defaultMsg = "The value returned was null.";

        public NullValueError(DbEntity e, string msg = defaultMsg) : base(nullValDefMsg(e, msg))
        {
        }

        private static string nullValDefMsg(DbEntity e, string msg)
        {
            return
                (msg == defaultMsg ? msg : $"The expected value in {e.TableName} table unexpectedly returned null.");
        }
    }
}
