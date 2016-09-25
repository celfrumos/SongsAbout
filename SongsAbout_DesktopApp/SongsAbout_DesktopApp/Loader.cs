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

    static class Loader
    {
        static Dictionary<string, Artist> _dictArtists;
        static Dictionary<string, Album> _dictAlbums;
        const string ARTIST_FILENAME = "Artists.txt";
        const string ALBUM_FILENAME = "Albums.txt";
        const char ARTIST_DELIM = '&';
        const char ALBUM_DELIM = '@';

        //public Loader()
        //{
        //    _dictArtists = new Dictionary<string, Artist>();
        //}

        static Dictionary<string, Artist> LoadArtists()
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var artists = context.Artists.Context.GetTable<Artist>();
                    foreach (var artist in artists)
                    {
                        _dictArtists.Add(artist.a_name, artist);
                    }
                    return _dictArtists;
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(ARTIST_FILENAME))
                {
                    throw new Exception("Error reading Artist File in Loader.cs. " + ex.Message);
                }
                return new Dictionary<string, Artist>();
            }
        }

        //static Dictionary<string, Album> LoadAlbums()
        //{
        //    LoadArtists();
        //    _dictAlbums = new Dictionary<string, Album>();
        //    StreamReader inputFile;
        //    try
        //    {
        //        if (File.Exists(ALBUM_FILENAME))
        //        {
        //            inputFile = File.OpenText(ALBUM_FILENAME);

        //            while (!inputFile.EndOfStream)
        //            {
        //                string line = inputFile.ReadLine();
        //                string[] artistData = line.Split(ALBUM_DELIM);

        //                string title = artistData[0];
        //                string year = artistData[1];
        //              //  Artist mainArtist = new Artist(artistData[2]);

        //                string coverFileName = artistData[3];

        //                //Album newAlbum = new Album(title, year, mainArtist, coverFileName);

        //               // _dictAlbums.Add(title, newAlbum);
        //            }
        //            inputFile.Close();

        //            return _dictAlbums;
        //        }
        //        else
        //        {
        //            return new Dictionary<string, Album>();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (File.Exists(ALBUM_FILENAME))
        //        {
        //            throw new Exception("Error reading Album File in Loader.cs. " + ex.Message);
        //        }
        //        else
        //        {
        //            throw new Exception();
        //        }
        //    }
        //}

    }

}