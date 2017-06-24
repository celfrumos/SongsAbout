using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SongsAbout.Web.Models;

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

        private static TLocalType GetLocalVersion<TLocalType>(this ISpotifyEntity entity, EntityDbContext db) where TLocalType : class, ISaDbEntityAccessor
        {
            if (entity is null || db is null)
                return null;

            return db.Set<TLocalType>()
                .SingleOrDefault(a => a.Name == entity.Name);

        }

    }
}