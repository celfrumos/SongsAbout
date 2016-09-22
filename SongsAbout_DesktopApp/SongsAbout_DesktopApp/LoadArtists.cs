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
    public class LoadArtists
    {
        private Dictionary<string, Artist> dictArtists = new Dictionary<string, Artist>();
        const string FILE_NAME = "Artists.txt";
        public LoadArtists() { }

        public Dictionary<string, Artist> Load()
        {
            StreamReader inputFile;
            try
            {
                inputFile = File.OpenText(FILE_NAME);

                while (!inputFile.EndOfStream)
                {
                    Artist artist = new Artist();
                    string line = inputFile.ReadLine();
                    string[] artistData = line.Split(',');

                    artist.Name = artistData[0];
                    artist.Bio = artistData[1];
                    artist.Website = artistData[2];
                    artist.SpotifyId = artistData[3];
                    artist.SetProfilePic(artistData[4]);

                    dictArtists.Add(artist.Name, artist);

                }
                inputFile.Close();

                return dictArtists;
            }
            catch (Exception ex)
            {
                if (File.Exists(FILE_NAME))
                {
                    MessageBox.Show(ex.Message, "Error loading Artist File");
                }
                return new Dictionary<string, Artist>();

            }
        }
    }
}