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
    public class Loader
    {
        private Dictionary<string, Artist> _dictArtists;
        private Dictionary<string, Album> _dictAlbums;
        const string ARTIST_FILENAME = "Artists.txt";
        const string ALBUM_FILENAME = "Albums.txt";
        const char ARTIST_DELIM = '&';
        const char ALBUM_DELIM = '@';

        public Loader()
        {
            _dictArtists = new Dictionary<string, Artist>();
        }

        public Dictionary<string, Artist> LoadArtists()
        {
            StreamReader inputFile;
            try
            {
                inputFile = File.OpenText(ARTIST_FILENAME);

                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    string[] artistData = line.Split(ARTIST_DELIM);

                    string name = artistData[0];
                    string bio = artistData[1];
                    string website = artistData[2];
                    string spotifyId = artistData[3];
                    string profilePicFile = artistData[4];

                    Artist newArtist = new Artist(name, bio, website, spotifyId, profilePicFile);

                    _dictArtists.Add(name, newArtist);

                }
                inputFile.Close();

                return _dictArtists;
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

        public Dictionary<string, Album> LoadAlbums()
        {
            LoadArtists();
            _dictAlbums = new Dictionary<string, Album>();
            StreamReader inputFile;
            try
            {
                inputFile = File.OpenText(ALBUM_FILENAME);

                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    string[] artistData = line.Split(ALBUM_DELIM);

                    string title = artistData[0];
                    string year = artistData[1];
                    Artist mainArtist = new Artist(artistData[2]);

                    string coverFileName = artistData[3];

                    //string profilePicFile = artistData[4];
                    //   Artist mainArtist = _dictArtists[mainArtistName];

                    // Just sets album Artist Name right now
                    Album newAlbum = new Album(title, year, mainArtist, coverFileName);

                    _dictAlbums.Add(title, newAlbum);
                }
                inputFile.Close();

                return _dictAlbums;

            }
            catch (Exception ex)
            {
                if (File.Exists(ALBUM_FILENAME))
                {
                    throw new Exception("Error reading Album File in Loader.cs. " + ex.Message);
                }
                else
                {
                    throw new Exception();
                }
            }
        }

    }
}