using System;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Classes;
using SongsAbout.Classes.Database;
using SongsAbout.Enums;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;

namespace SongsAbout.Entities
{
    public partial class Genre : DbEntity
    {
        private bool _saved = false;
        public static List<string> ExistingGenres { get; set; }
        public override DbEntityType DbEntityType { get { return DbEntityType.Genre; } }
        public override SpotifyEntityType SpotifyType { get { return SpotifyEntityType.None; } }
        public override string TableName { get { return "Genres"; } }
        public override string TitleColumnName { get { return "genre"; } }

        static public implicit operator Genre(string name)
        {
            return new Genre(name);
        }
        static public implicit operator string(Genre genre)
        {
            return genre.Name;
        }

        private List<Album> _loadAlbums()
        {
            try
            {
                List<Album> res;
                using (var db = new DataClassesContext())
                {
                    res = (List<Album>)(from g in db.Genres
                                        where g.Name == this.Name
                                        select g.privateAlbums);
                }
                if (res.Count > 0)
                    return res;

                else
                    return new List<Album>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading Albums for Genre {this.Name}: {ex.Message}");

                return _loadAlbums();
            }
        }
        public List<Album> Albums
        {
            set { this.privateAlbums = value; }
            get
            {
                try
                {
                    try
                    {
                        if (this.privateAlbums != null)
                            return (List<Album>)this.privateAlbums;
                        else
                            return new List<Album>();
                    }
                    catch (ObjectDisposedException ex)
                    {
                        Console.WriteLine($" Error returning Albums for Genre {this.Name}: {ex.Message}");
                        return this._loadAlbums();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error returning Albums for Genre {this.Name}: {ex.Message}");

                    return _loadAlbums();

                }
            }
        }

        public override string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                _saved = false;
            }
        }
        public override void Save()
        {
            if (!this._saved && !SongDatabase.Genres.Contains(this.Name))
            {
                SongDatabase.Genres[this.Name] = this;
                _saved = true;
            }
        }
        public Genre(string name)
        {
            this.Name = name;
            Save();

        }
    }
}
