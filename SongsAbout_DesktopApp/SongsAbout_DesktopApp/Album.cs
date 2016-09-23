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
    public class Album
    {
        const string ALBUM_FILE_NAME = "Albums.txt";
        private string _coverArtSource = "";
        private Image _coverArt;
        const char ALBUM_DELIM = '@';
        // private string id;

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


        /// <summary>
        /// Default Album constructor
        /// </summary>
        public Album()
        {
            this.Title = "";
            this.Year = "";
            this.SpotifyId = "";
            this.MainArtist = new Artist();
            // no album cover art set
        }

        /// <summary>
        /// Album constructor with artist object, will actually set this.MainArtist 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="mainArtist"></param>
        /// <param name="coverFileName"></param>
        public Album(string title, string year, Artist mainArtist, string coverFileName)
        {
            this.Title = title;
            this.Year = year;
            this.MainArtist = mainArtist;
            SetAlbumCoverArt(coverFileName);
        }

        /// <summary>
        /// Album constructor with string mainArtistName, will only set the artist name, not this.MainArtist object
        /// </summary>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="mainArtistName"></param>
        /// <param name="coverFileName"></param>
        public Album(string AlbumString)
        {
            string[] albumData = AlbumString.Split(ALBUM_DELIM);

            this.Title = albumData[0];
            this.Year = albumData[1];
            this.MainArtist = new Artist(albumData[2]);
            this.SpotifyId = albumData[3];
            SetAlbumCoverArt(albumData[4]);
        }

        /// <summary>
        /// Save one album to Albums.txt
        /// </summary>
        public void Save()
        {
            try
            {
                StreamWriter outputFile;

                outputFile = File.AppendText(ALBUM_FILE_NAME);
                outputFile.WriteLine(this.ToString());

                outputFile.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error Saving Album\n" + ex.Message);
            }
        }

        /// <summary>
        /// Save one album to an existing StreamWriter object
        /// </summary>
        public void Save(ref StreamWriter outputFile)
        {
            try
            {
                outputFile = File.AppendText(ALBUM_FILE_NAME);
                outputFile.WriteLine(this.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error Saving Album\n" + ex.Message);
            }
        }

        /// <summary>
        /// Load one artist from an existing StreamReader
        /// </summary>
        /// <param name="inputFile"></param>
        public void Load(ref StreamReader inputFile)
        {
            try
            {
                string line = inputFile.ReadLine();
                string[] albumData = line.Split(ALBUM_DELIM);

                this.Title = albumData[0];
                this.Year = albumData[1];
                this.MainArtist = new Artist(albumData[2]);
                this.SpotifyId = albumData[3];
                SetAlbumCoverArt(albumData[4]);

            }
            catch (Exception ex)
            {

                throw new Exception("Error loading album from file." + ex.Message);
            }
        }

        /// <summary>
        /// Set the album cover art from the fileName string param
        /// </summary>
        /// <param name="fileName"></param>
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

        /// <summary>
        /// Returns a string representation of this Album object
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            return this.Title + ALBUM_DELIM + this.Year + ALBUM_DELIM + this.MainArtist.ToString() + ALBUM_DELIM + _coverArtSource;

        }
    }
}
