﻿using System;
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

        public virtual DbEntityType DbEntityType { get; protected set; }

        public virtual DbEntity _entity { get; protected set; }

        protected string TableName
        {
            get { return _entity.TableName; }
        }

        public string EntityColumn { get { return _entity.TitleColumnName; } }

        public DbException(DbEntity e, string msg = DEF_MSG)
        {
            _entity = e;
            DbEntityType = e.DbEntityType;
            Console.WriteLine(msg);
        }


        public DbException(string msg = DEF_MSG) : base(msg)
        {
            Console.WriteLine(msg);
        }

        public DbException(DbEntityType dbEntityType, string msg = DEF_MSG) : base(dbExDefMsg(dbEntityType, msg))
        {
            Console.WriteLine(msg);
        }
        protected static string dbExDefMsg(DbEntityType e, string msg = DEF_MSG)
        {
            return (msg == DEF_MSG ? msg : $"An error occurred related to {e} table: " + msg);

        }
    }

    public class SaveError : DbException
    {
        const string DEF_MSG = "Error Saving to the database.";
        public SaveError(string msg = DEF_MSG) : base($"Save Error: {msg}")
        {

        }
        public SaveError(DbEntityType entityType, string name, string msg = DEF_MSG)
            : base(entityType, saveErrDefMsg(entityType, name, msg))
        {
        }

        private static string saveErrDefMsg(DbEntityType entityType, string name, string msg = DEF_MSG)
        {
            return
            (msg == DEF_MSG ? msg : $"Error Updating {entityType} '{name}' from {entityType}s table: " + msg);

        }

    }

    public class LoadError : DbException
    {
        const string DEF_MSG = "Error Loading entity from Database";

        public LoadError(string msg = DEF_MSG)
              : base($"Load Error: {msg}")
        { }

        public LoadError(DbEntityType entityType, int id, string msg) : base(loadDefMsg(entityType, id, msg))
        {
        }

        public LoadError(DbEntityType entityType, string name, string msg) : base(loadDefMsg(entityType, name, msg))
        {
        }


        private static string loadDefMsg(DbEntityType entityType, int id, string msg)
        {
           return $"Error Loading {entityType} with id {id} from {entityType}s table: {msg}";
        
        }
        private static string loadDefMsg(DbEntityType entityType, string name, string msg)
        {
            return $"Error Loading {entityType} with name {name} from {entityType}s table: {msg}";           
        }

    }
    public class InvalidInitializedError : DbException
    {
        const string DEF_MSG = "Attempt was made to initialize an entity when not all preconditions were met.";

        public InvalidInitializedError(string objectName, string msg = DEF_MSG)
            : base($"For Object {objectName}: {msg}")
        {

        }


    }

    public class UpdateFromSpotifyError : DbException
    {
        const string defaultMsg = "Error Updating Entity in Database";

        public UpdateFromSpotifyError(DbEntityType entityType, SpotifyEntityType spotifyType, string name, string msg = defaultMsg)
        {
            string m =
                (msg == defaultMsg ? msg : $"Error Updating {entityType} '{name}' from {spotifyType} in {entityType}s table: {msg}");
        }
        private static string updateMsg(DbEntityType entityType, string name, string msg)
        {
            return
                (msg == defaultMsg ? msg : $"Error Updating {entityType} '{name}' in {entityType}s table: {msg}");
        }
    }
    public class EntityNotFoundError : DbException
    {
        const string defaultMsg = "The expected entity was not found";

        public EntityNotFoundError(DbEntityType entityType, string name, string msg = defaultMsg)
         : base(notFoundMsg(entityType, name, msg))
        {
        }
        public EntityNotFoundError(DbEntityType entityType, int id, string msg = defaultMsg)
        : base(notFoundMsg(entityType, id, msg))
        {
        }

        private static string notFoundMsg(DbEntityType entityType, string name, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity {entityType} named '{name}' not found in the intended table: " + msg);
        }
        private static string notFoundMsg(DbEntityType entityType, int id, string msg)
        {
            return (msg == defaultMsg ? msg
                : $"Entity '{entityType}' with id '{id}' not found in the intended table: " + msg);
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
                : $"Error importing {e.DbEntityType} data from spotify type '{spotifyType}'");

        }
    }

    public class NullValueError : DbException
    {
        const string NULL_ERR_DEF_MSG = "Attempted to add a null value where it is not allowed.";

        public NullValueError(string msg = NULL_ERR_DEF_MSG) : base(msg)
        {

        }
        public NullValueError(DbEntityType entityType, string column, string msg = "")
            : base(entityType, $"{entityType} {column} cannot be null:\n{msg}")
        {
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

    public class DbInitFromSpotifyError : DbException
    {
        const string DEF_MSG = "Failed to initialize DbEntity from Spotify Entity.";

        public SpotifyEntityType SpotifyEntityType { get; private set; }
        public DbInitFromSpotifyError(DbEntityType dbType, SpotifyEntityType spotifyType, string msg = DEF_MSG) : base(initErrDefMsg(dbType, spotifyType, msg))
        {
            this.DbEntityType = dbType;
            this.SpotifyEntityType = spotifyType;
        }

        private static string initErrDefMsg(DbEntityType dbType, SpotifyEntityType spotifyType, string msg)
        {
            return
                (msg == DEF_MSG ? $"Failed to initialize DbEntity {dbType} from Spotify Entity {spotifyType}\n{msg}" : msg);
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
            return (msg == DEF_MSG ? $"Failed to convert {fromType} to {toType}\n{msg}" : msg);
        }
    }
}
