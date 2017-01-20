using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Classes;
using SongsAbout.Enums;
using SongsAbout.Controls;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;

namespace SongsAbout.Entities
{
    public abstract class DbEntity
    {
        public bool isInitialized { get; set; }
        protected DbEntity()
        {
            isInitialized = false;
            this.SpotifyType = SpotifyEntityType.None;
            this.DbEntityType = DbEntityType.None;
        }

        /// <summary>
        /// THe name of the title column of thiis DbEntity
        /// </summary>
        public abstract string TitleColumnName { get; }
        public abstract string TableName { get; }
        public abstract string Name { get; set; }
        public abstract void Save();

        public virtual DbEntityType DbEntityType { get; }
        public virtual SpotifyEntityType SpotifyType { get; }
        public virtual ISpotifyEntity ISpotifyEntity { get; set; }
        protected static void FormatName(ref string name)
        {
            if (name.Contains("\'"))
            {
                int i = name.IndexOf("\'");
                name = name.Insert(i, "'");
            }
        }
        protected int UpdateInsertTrack(int? id, string name, string track_spotify_uri, double? track_length_minutes,
            int track_artist_id, bool can_play, int track_album_id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));

            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));

            var track_spotify_uriParameter = track_spotify_uri != null ?
                new ObjectParameter("track_spotify_uri", track_spotify_uri) :
                new ObjectParameter("track_spotify_uri", typeof(string));

            var track_length_minutesParameter = track_length_minutes.HasValue ?
                new ObjectParameter("track_length_minutes", track_length_minutes) :
                new ObjectParameter("track_length_minutes", typeof(double));

            var track_artist_idParameter = new ObjectParameter("track_artist_id", track_artist_id);


            var can_playParameter = new ObjectParameter("can_play", can_play);

            var track_album_idParameter = new ObjectParameter("track_album_id", track_album_id);

            using (var db = new DataClassesContext())
            {
                return ((IObjectContextAdapter)db).ObjectContext.ExecuteFunction("UpdateInsert_Track",
                    idParameter, nameParameter, track_spotify_uriParameter, track_length_minutesParameter, track_artist_idParameter, can_playParameter, track_album_idParameter);

            }
        }

    }
}
