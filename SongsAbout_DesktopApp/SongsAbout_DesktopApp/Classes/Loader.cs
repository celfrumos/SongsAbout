using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace SongsAbout_DesktopApp
{
    using System.Data.Linq;
    using System.Data.Linq.Mapping;


    public static class Loader
    {

        /// <summary>
        /// Load all of the Artists from the database
        /// </summary>
        /// <returns>Dictionary<string, Artist></returns>
        public static Dictionary<string, Artist> LoadArtists()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                try
                {
                    Dictionary<string, Artist> _dictArtists = new Dictionary<string, Artist>();
                    Table<Artist> artists = context.Artists.Context.GetTable<Artist>();
                    foreach (Artist artist in artists)
                    {
                        _dictArtists.Add(artist.a_name, artist);
                    }
                    return _dictArtists;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error loading Artists. Msg: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Load all of the Albums from the database
        /// </summary>
        /// <returns>Dictionary<string, Album></returns>
        public static Dictionary<string, Album> LoadAlbums()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Dictionary<string, Album> _dictAlbums = new Dictionary<string, Album>();
                try
                {
                    Table<Album> albumTable = context.Albums.Context.GetTable<Album>();
                    foreach (Album album in albumTable)
                    {
                        _dictAlbums.Add(album.al_title, album);
                    }
                    return _dictAlbums;
                }

                catch (Exception ex)
                {
                    throw new Exception("Error loading Albums. Msg: " + ex.Message);
                }
            }
        }

    }

}