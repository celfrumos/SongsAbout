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
    class Album
    {
        const string ALBUM_FILE_NAME = "Albums.txt";
        private string _coverArtSource = "";
        private Image _coverArt;
        private string id;

        public Artist MainArtist { get; set; }
        public string Year { get; set; }
        public string Title { get; set; }
        public string SpotifyId { get; set; }
        public Image CoverArt
        {
            get { return _coverArt; }
        }
        public string CoverArtSource
        {
            get { return _coverArtSource; }
        }

        public List<Artist> FeatArtists { get; set; }

        public Album()
        {
            this.Title = "";
            this.Year = "";
            this.MainArtist = new Artist();
        }
        public Album(string title, string year, Artist mainArtist, string coverFileName)
        {
            this.Title = title;
            this.Year = year;
            this.MainArtist = mainArtist;
            SetAlbumCoverArt(coverFileName);
        }

        public void Save()
        {
            try
            {
                StreamWriter outputFile;

                outputFile = File.AppendText(ALBUM_FILE_NAME);
                
                string artistData = this.Title + "," + this.Year + "," + this.MainArtist.Name + "," + this.SpotifyId + "," + _coverArtSource;
                outputFile.WriteLine(artistData);

                outputFile.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error Saving Album:" + this.Title + " to File", ex);
            }

        }

        public void Load(string name)
        {
            try
            {
                StreamReader inputFile = new StreamReader(ALBUM_FILE_NAME);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetAlbumCoverArt(string fileName)
        {
            if (fileName != "")
            {
                try
                {
                    _coverArt = Image.FromFile(fileName);
                    _coverArtSource = fileName;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured while setting Cover art picture.", ex);
                }
            }

        }

    }
}
