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
        const string DEF_MSG = "An Error Occurred while interacting with the database";
        protected string _message;

        public override string Message { get { return _message; } }

        public virtual DbEntityType DbEntityType { get; protected set; }

        public virtual DbEntity _entity { get; protected set; }

        protected string TableName
        {
            get { return _entity.TableName; }
        }

        public string EntityColumn { get { return _entity.TitleColumnName; } }

        public DbException(DbEntity e, string msg = DEF_MSG)
        {
            _message = msg;
            _entity = e;
            DbEntityType = e.DbEntityType;
        }


        public DbException(string msg = DEF_MSG) : base(msg)
        {
            _message = msg;
        }
        public DbException(Type t, string msg = DEF_MSG) : base(dbExDefMsg(t, msg))
        {
            _message = msg;
        }

        public DbException(DbEntityType dbEntityType, string msg = DEF_MSG) : base(dbExDefMsg(dbEntityType, msg))
        {
            _message = msg;
        }
        protected static string dbExDefMsg(DbEntity e, string msg = DEF_MSG)
        {
            return (msg == DEF_MSG ? msg : $"Error Updating {e.TypeName} from {e.TableName} table: " + msg);

        }
        protected static string dbExDefMsg(DbEntityType e, string msg = DEF_MSG)
        {
            return (msg == DEF_MSG ? msg : $"An error occurred related to {e} table: " + msg);

        }
        protected static string dbExDefMsg(Type t, string msg = DEF_MSG)
        {
            return (msg == DEF_MSG ? msg : $"An error occured related to {t} table. " + msg);

        }
    }

    public class SaveError : DbException
    {
        const string DEF_MSG = "Error Saving to the database.";
        public SaveError(string msg = DEF_MSG) : base($"Save Error: {msg}")
        {

        }
        public SaveError(DbEntity e, string name, string msg = DEF_MSG)
            : base(e, saveErrDefMsg(e, name, msg))
        {
        }

        private static string saveErrDefMsg(DbEntity e, string name, string msg = DEF_MSG)
        {
            return
            (msg == DEF_MSG ? msg : $"Error Updating {e.TypeName} '{name}' from {e.TableName} table: " + msg);

        }

    }

    public class LoadError : DbException
    {
        const string DEF_MSG = "Error Loading entity from Database";

        public LoadError(string msg = DEF_MSG)
              : base($"Load Error: {msg}")
        { }

        public LoadError(DbEntity e, string name, string msg = DEF_MSG)
            : base(loadDefMsg(e, name, msg))
        {
        }


        public LoadError(DbEntity e, int id, string msg = DEF_MSG) : base(loadDefMsg(e, id, msg))
        {
        }
        public LoadError(DbEntityType e, int id, string msg = DEF_MSG) : base(loadDefMsg(e, id, msg))
        {
        }

        public LoadError(DbEntityType e, string name, string msg = DEF_MSG) : base(loadDefMsg(e, name, msg))
        {
        }

        private static string loadDefMsg(DbEntity e, string name, string msg = DEF_MSG)
        {
            return (msg == DEF_MSG ? msg : $"Error Loading {e.TypeName} '{name}' from {e.TableName} table: " + msg);
        }
        private static string loadDefMsg(DbEntity e, int id, string msg)
        {
            return (msg == DEF_MSG ? msg : $"Error Loading {e.TypeName} with id {id} from {e.TableName} table: " + msg);
        }
        private static string loadDefMsg(DbEntityType e, int id, string msg)
        {

            switch (e)
            {
                case DbEntityType.Artist:
                    return (msg == DEF_MSG ? msg : $"Error Loading {Artist.TypeString} with id {id} from {Artist.Table} table: " + msg);
                case DbEntityType.Album:
                    return (msg == DEF_MSG ? msg : $"Error Loading {Album.TypeString} with id {id} from {Album.Table} table: " + msg);
                case DbEntityType.Track:
                    return (msg == DEF_MSG ? msg : $"Error Loading {Track.TypeString} with id {id} from {Track.Table} table: " + msg);
                default:
                    return (msg == DEF_MSG ? msg : DEF_MSG + "\n" + msg);
            }
        }
        private static string loadDefMsg(DbEntityType e, string name, string msg)
        {
            switch (e)
            {
                case DbEntityType.Artist:
                    return (msg == DEF_MSG ? msg : $"Error Loading {Artist.TypeString} with name {name} from {Artist.Table} table: " + msg);
                case DbEntityType.Album:
                    return (msg == DEF_MSG ? msg : $"Error Loading {Album.TypeString} with name {name} from {Album.Table} table: " + msg);
                case DbEntityType.Track:
                    return (msg == DEF_MSG ? msg : $"Error Loading {Track.TypeString} with name {name} from {Track.Table} table: " + msg);
                default:
                    return (msg == DEF_MSG ? msg : DEF_MSG + "\n" + msg);
            }
        }

    }
    public class AlreadyInitializedError : DbException
    {
        const string DEF_MSG = "Attempted to initialize an entity that must only have one instance.";
        public AlreadyInitializedError(string msg = DEF_MSG) : base(msg)
        {

        }
        public AlreadyInitializedError(string objectName, string msg = DEF_MSG)
            : base($"For Object {objectName}: {msg}")
        {

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
        public EntityNotFoundError(DbEntityType t, string name, string msg = defaultMsg)
         : base(notFoundMsg(t, name, msg))
        {
        }
        public EntityNotFoundError(DbEntityType t, int id, string msg = defaultMsg)
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
        private static string notFoundMsg(DbEntityType t, string name, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity {t} named '{name}' not found in the intended table: " + msg);
        }
        private static string notFoundMsg(Type t, int id, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity '{t}' with id '{id}' not found in the intended table: " + msg);
        }
        private static string notFoundMsg(DbEntityType t, int id, string msg)
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

        public SpotifyEntityType SpotifyEntityType { get; private set; }
        public SpotifyToDBImportException(SpotifyEntityType spotifyType, DbEntity e, string msg = defaultMsg)
            : base(e, ImportDefMsg(spotifyType, e, msg))
        {
            this.SpotifyEntityType = spotifyType;
            this.DbEntityType = e.DbEntityType;

        }

        private static string ImportDefMsg(SpotifyEntityType spotifyType, DbEntity e, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Error importing {e.TypeName} data from spotify type '{spotifyType}'");

        }
    }

    public class NullValueError : DbException
    {
        const string NULL_ERR_DEF_MSG = "The value returned was null.";

        public NullValueError(string msg = NULL_ERR_DEF_MSG) : base(msg)
        {

        }
        public NullValueError(DbEntity e, string msg = NULL_ERR_DEF_MSG) : base(nullValDefMsg(e, msg))
        {
        }
        public NullValueError(DbEntityType e, string msg = NULL_ERR_DEF_MSG) : base(nullValDefMsg(e, msg))
        {
        }

        private static string nullValDefMsg(DbEntity e, string msg)
        {
            return
                (msg == NULL_ERR_DEF_MSG ? msg : $"The expected value in {e.TableName} table unexpectedly returned null.");
        }
        private static string nullValDefMsg(DbEntityType e, string msg)
        {
            return
                (msg == NULL_ERR_DEF_MSG ? msg : $"The expected value in {e}s table unexpectedly returned null: \n{msg}");
        }
    }
    public class ValueAlreadyPresentException : DbException
    {
        const string DEF_MSG = "Attempted to insert an entity that already exists into the database.";

        public SpotifyEntityType SpotifyEntityType { get; private set; }
        public ValueAlreadyPresentException(string msg = DEF_MSG)
            : base((msg == DEF_MSG ? msg : $"{DEF_MSG}\n{msg}"))
        {

        }
        public ValueAlreadyPresentException(DbEntityType dbType, int id, string msg = DEF_MSG)
            : base(initErrDefMsg(dbType, id, msg))
        {
            this.DbEntityType = dbType;
        }

        private static string initErrDefMsg(DbEntityType dbType, int id, string msg)
        {
            return (msg == DEF_MSG ? msg
                : $"Attempted to insert a new {dbType} with id {id} that already exists into the database. Try updating instead. \n{msg}");
        }
        public ValueAlreadyPresentException(DbEntityType dbType, string name, string msg = DEF_MSG)
        : base(initErrDefMsg(dbType, name, msg))
        {
            this.DbEntityType = dbType;
        }

        private static string initErrDefMsg(DbEntityType dbType, string name, string msg)
        {
            return ($"Attempted to insert a new {dbType} with name {name}, which already exists into the database. Try updating instead. \n{msg}");
        }
    }
    public class InitializationError : DbException
    {
        const string DEF_MSG = "Failed to initialize DbEntity from Spotify Entity.";

        public SpotifyEntityType SpotifyEntityType { get; private set; }
        public InitializationError(DbEntityType dbType, SpotifyEntityType spotifyType, string msg = DEF_MSG) : base(initErrDefMsg(dbType, spotifyType, msg))
        {
            this.DbEntityType = dbType;
            this.SpotifyEntityType = spotifyType;
        }

        private static string initErrDefMsg(DbEntityType dbType, SpotifyEntityType spotifyType, string msg)
        {
            return (msg == DEF_MSG ? msg : $"Failed to initialize DbEntity {dbType} from Spotify Entity {spotifyType}\n{msg}");
        }

    }
    public class ConversionError : DbException
    {
        const string DEF_MSG = "Failed to convert one DataType to another.";

        public string FromType { get; set; }
        public string ToType { get; set; }
        public ConversionError(string fromType = "UnknownType", string toType = "UnknownType", string msg = DEF_MSG)
            : base(_convErrDefMsg(fromType, toType, msg))
        {
            this.FromType = fromType;
            this.ToType = toType;
        }

        private static string _convErrDefMsg(string fromType = "UnknownType", string toType = "UnknownType", string msg = DEF_MSG)
        {
            return (msg == DEF_MSG ? msg : $"Failed to convert {fromType} to {toType}\n{msg}");
        }
    }
}
