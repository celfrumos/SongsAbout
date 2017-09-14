using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SongsAbout.Web.Models
{
    public static class SaEntityGenericExtensions
    {
        /// <summary>
        /// Verify if an entity exists in the database, based on the given values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db">The Existing <see cref="EntityDbContext"/> to use. If null, a new one is created</param>
        /// <param name="columnNames">The names of the columns from which to check</param>
        /// <returns></returns>
        public static bool Exists<T>(this T entity, EntityDbContext db = null, params string[] columnNames) where T : SaDbEntityAccessor
        {
            if (db == null)
                db = new EntityDbContext();

            if (columnNames == null || columnNames.Count() == 0)
                return db.Set<T>().Count(a => a.Name == entity.Name) > 0;


            var matchingProps
                = typeof(T)
                .GetProperties(BindingFlags.GetProperty)
                .Where(p => columnNames.Contains(p.Name));

            Dictionary<string, object> values
                = matchingProps
                .ToDictionary(p => p.Name, p => p.GetValue(entity));

            return
                db.Set<T>()
                .Where(a => matchingProps
                .ToDictionary(p => p.Name, p => p.GetValue(a)).Equals(values))
                .Count() > 0;
        }
        /// <summary>
        /// Verify if an entity exists in the database, based on the given values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db">The Existing <see cref="EntityDbContext"/> to use. If null, a new one is created</param>
        /// <param name="columnNames">The names of the columns from which to check</param>
        /// <returns></returns>
        public async static Task<bool> ExistsAsync<T>(this T entity, EntityDbContext db = null, params string[] columnNames) where T : SaDbEntityAccessor
        {
            if (db == null)
                db = new EntityDbContext();

            if (columnNames == null)
                return await db.Set<T>().CountAsync(a => a.Name == entity.Name) > 0;


            var matchingProps
                = typeof(T)
                .GetProperties(BindingFlags.GetProperty)
                .Where(p => columnNames.Contains(p.Name));

            Dictionary<string, object> values
                = matchingProps
                .ToDictionary(p => p.Name, p => p.GetValue(entity));

            return await db.Set<T>().CountAsync(a => matchingProps.ToDictionary(p => p.Name, p => p.GetValue(a)).Equals(values)) > 0;
        }
    }
}