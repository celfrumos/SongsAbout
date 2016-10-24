using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SongsAbout_DesktopApp.Classes.Entities;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp.Classes
{
    public class DbException : Exception
    {
        const string defMsg = "An Error Occurred while interacting with the database";
        protected string _message;

        public override string Message { get { return _message; } }

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

        protected DbException(DbEntity e, string msg = defMsg)
        {
            Initialize(ref e, ref msg);
        }

        protected void Initialize(ref DbEntity e, ref string msg)
        {
            _message = msg;

            _entity = e;
            _type = e.TypeName;
            _table = e.TableName;
        }

        protected DbException(string msg = defMsg) : base(msg)
        {
            _message = msg;
        }

    }

    public class SaveError : DbException
    {
        const string defaultMsg = "Error Saving to the database.";
        public SaveError(string msg = defaultMsg) : base($"Save Error: {msg}")
        {

        }
        public SaveError(DbEntity e, string name, string msg = defaultMsg)
            : base(e, saveErrDefMsg(ref e, ref name, ref msg))
        {
        }

        private static string saveErrDefMsg(ref DbEntity e, ref string name, ref string msg)
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
            : base(loadDefMsg(ref e, ref name, ref msg))
        {
        }


        public LoadError(DbEntity e, int id, string msg = defaultMsg)
            : base(loadDefMsg(ref e, ref id, ref msg))
        {
            string se = $"Error Loading {_type} '{id}' from {_table} table: " + msg;
        }

        private static string loadDefMsg(ref DbEntity e, ref string name, ref string msg)
        {
            return
                (msg == defaultMsg ? msg : $"Error Loading {e.TypeName} '{name}' from {e.TableName} table: " + msg);
        }
        private static string loadDefMsg(ref DbEntity e, ref int id, ref string msg)
        {
            return (msg == defaultMsg ? msg : $"Error Loading {e.TypeName} with id {id} from {e.TableName} table: " + msg);
        }

    }

    public class UpdateError : DbException
    {
        const string defaultMsg = "Error Updating Entity in Database";

        public UpdateError(DbEntity e, string name, string msg = defaultMsg)
            : base(e, updateMsg(ref e, ref name, ref msg))
        {
        }
        public UpdateError(DbEntity e, Type spotifyType, string name, string msg = defaultMsg)
        {
            string m =
                (msg == defaultMsg ? msg : $"Error Updating {e.TypeName} '{name}' from {spotifyType} in {e.TableName} table: " + msg);
        }
        private static string updateMsg(ref DbEntity e, ref string name, ref string msg)
        {
            return
                (msg == defaultMsg ? msg : $"Error Updating {e.TypeName} '{name}' from {e.TableName} table: " + msg);
        }
    }
    public class EntityNotFoundError : DbException
    {
        const string defaultMsg = "The expected entity was not found";
        public EntityNotFoundError(Type t)
        {
        }
        public EntityNotFoundError(DbEntity e, string name, string msg = defaultMsg)
            : base(notFoundMsg(ref e, ref name, ref msg))
        { }

        public EntityNotFoundError(DbEntity e, int id, string msg = defaultMsg)
            : base(notFoundMsg(ref e, ref id, ref msg))
        { }

        private static string notFoundMsg(ref DbEntity e, ref string name, ref string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity {e.TypeName} named '{name}' not found in {e.TableName} table: " + msg);
        }

        private static string notFoundMsg(ref DbEntity e, ref int id, ref string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity {e.TypeName} with id '{id}' not found in {e.TableName} table: " + msg);
        }
    }

    public class SpotifyImportError<SpotifyType> : DbException
    {
        const string defaultMsg = "Error importing data from spotify";

        public SpotifyImportError(DbEntity e, string msg = defaultMsg)
            : base(e, ImportDefMsg(ref e, ref msg))
        {

        }

        private static string ImportDefMsg(ref DbEntity e, ref string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Error importing {e.TypeName} data from spotify type '{typeof(SpotifyType).ToString()}'");

        }
    }

    public class NullValueError : Exception
    {
        const string defaultMsg = "The value returned was null.";

        public NullValueError(DbEntity e, string msg = defaultMsg) : base(nullValDefMsg(ref e, ref msg))
        {
        }

        private static string nullValDefMsg(ref DbEntity e, ref string msg)
        {
            return
                (msg == defaultMsg ? msg : $"The expected value in {e.TableName} table unexpectedly returned null.");
        }
    }
}
