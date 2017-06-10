using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SongsAbout.Web.Models;
namespace SongsAbout.Web
{
    public abstract class EntityInitializationException : Exception
    {
        public EntityInitializationException(string msg)
            : base(msg)
        {
        }
        public EntityInitializationException(string msg, Exception inner)
            : base(msg, inner)
        {

        }
        public virtual ISaDbEntityAccessor Entity { get; protected set; } = null;
    }
    public class EntityInitializationException<T> : EntityInitializationException where T : class, ISaDbEntityAccessor
    {
        private const string DEF_MSG = "An error occurred while attempting to initialize an entity of type";
        private readonly static string message = $"{DEF_MSG} {typeof(T).Name}";

        public EntityInitializationException(string msg, Exception inner, T entity = null)
            : base($"{message}\n{msg}", inner)
        {
            this.Entity = entity;
        }

        public EntityInitializationException(T entity = null)
              : base(message)
        {
            this.Entity = entity;
        }

        public EntityInitializationException(Exception inner, T entity = null)
              : base(message, inner)
        {
            this.Entity = entity;
        }
    }
}