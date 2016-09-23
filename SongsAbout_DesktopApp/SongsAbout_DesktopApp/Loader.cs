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
        private Dictionary<string, Artist> dictArtists = new Dictionary<string, Artist>();
        Dictionary<string, Album> dictAlbums = new Dictionary<string, Album>();
        const string ARTIST_FILENAME = "Artists.txt";
        const string ALBUM_FILENAME = "Albums.txt";

        public Loader() { }

        public Dictionary<string, Artist> LoadArtists()
        {
            StreamReader inputFile;
            try
            {
                inputFile = File.OpenText(ARTIST_FILENAME);

                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    string[] artistData = line.Split(',');

                    string name = artistData[0];
                    string bio = artistData[1];
                    string website = artistData[2];
                    string spotifyId = artistData[3];
                    string profilePicFile = artistData[4];

                    Artist newArtist = new Artist(name, bio, website, spotifyId, profilePicFile);

                    dictArtists.Add(name, newArtist);

                }
                inputFile.Close();

                return dictArtists;
            }
            catch (Exception ex)
            {
                if (File.Exists(ARTIST_FILENAME))
                {
                    MessageBox.Show(ex.Message, "Error loading Artist File");
                }
                return new Dictionary<string, Artist>();

            }
        }

        public Dictionary<string, Album> LoadAlbums()
        {
            StreamReader inputFile;
            try
            {
                inputFile = File.OpenText(ALBUM_FILENAME);

                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    string[] artistData = line.Split(',');

                    string title = artistData[0];
                    string year = artistData[1];
                    string mainArtist = artistData[2];
                    string coverFileName = artistData[3];
                    string profilePicFile = artistData[4];

                    // Just sets album Artist Name right now
                    Album newAlbum = new Album(title, year, mainArtist, coverFileName);

                    dictAlbums.Add(title, newAlbum);
                }
                inputFile.Close();

                return dictAlbums;

            }
            catch (Exception ex)
            {
                if (File.Exists(ALBUM_FILENAME))
                {
                    throw new Exception("Error reading Album File in Loader.cs" + ex.Message);
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}