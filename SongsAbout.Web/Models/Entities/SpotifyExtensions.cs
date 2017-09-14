using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SongsAbout.Web.Models;
using System.Threading.Tasks;

namespace SongsAbout.Web.Models
{
    public static class SpotifyExtensions
    {
        public static bool IsSaved(this ISpotifyEntity entity, EntityDbContext db)
        {
            if (entity?.Name is null)
                return false;

            ISaDbEntityAccessor dbEntity;

            switch (entity.SpotifyEntityType.GetDbEntityType())
            {
                case SaEntityType.Artist:
                    dbEntity = entity.GetLocalVersion<Artist>(db);
                    break;
                case SaEntityType.Album:
                    dbEntity = entity.GetLocalVersion<Album>(db);
                    break;
                case SaEntityType.Track:
                    dbEntity = entity.GetLocalVersion<Track>(db);
                    break;
                default:
                    return false;
            }

            return dbEntity != null;
        }

        public static TLocalType GetLocalVersion<TLocalType>(this ISpotifyEntity entity, EntityDbContext db) where TLocalType : class, ISaDbEntityAccessor
        {
            if (entity is null || db is null)
                return null;

            return db.Set<TLocalType>()
                .SingleOrDefault(a => a.Name == entity.Name);

        }
        public static bool IsSavedLocally<TLocal>(this ISpotifyEntity entity, EntityDbContext db = null)
            where TLocal : SaDbEntityAccessor, new()
        {

            var localEntity = (TLocal)typeof(TLocal).GetConstructor(new Type[] { }).Invoke(null);

            localEntity.Name = entity.Name;
            return localEntity.Exists(db);
        }

        public async static Task<bool> IsSavedLocallyAsync<TLocal>(this ISpotifyEntity entity, EntityDbContext db = null)
           where TLocal : SaDbEntityAccessor, new()
        {
            var localEntity = default(TLocal);
            localEntity.Name = entity.Name;
            return await localEntity.ExistsAsync(db);
        }
    }
}