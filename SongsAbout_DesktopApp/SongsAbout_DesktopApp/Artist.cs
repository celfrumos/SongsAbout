using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp
{
    public class Artist
    {
        private Image _profilePic;
        private string _profPicSource;
        const char ARTIST_DELIM = '&';

        const string ARTISTS_FILENAME = "Artists.txt";
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public string SpotifyId { get; set; }

        /// <summary>
        /// Has get access only. To set, use SetProfilePic(string fileName)
        /// </summary>
        public Image ProfilePic
        {
            get { return _profilePic; }
        }

        public string ProfPicSource
        {
            get { return _profPicSource; }
        }

        /// <summary>
        /// Default Artist Constructor
        /// </summary>
        public Artist()
        {
            this.Id = "";
            this.Name = "";
            this.Bio = "";
            this.Website = "";
            this.SpotifyId = "";
            _profPicSource = "";
        }

        /// <summary>
        /// Artist constructor with individual properties as params
        /// </summary>
        /// <param name="name"></param>
        /// <param name="bio"></param>
        /// <param name="website"></param>
        /// <param name="spotifyId"></param>
        /// <param name="profPicSource"></param>
        public Artist(string name, string bio, string website, string spotifyId, string profPicSource)
        {
            this.Name = name;
            this.Bio = bio;
            this.Website = website;
            this.SpotifyId = spotifyId;
            SetProfilePic(profPicSource);
        }

        /// <summary>
        /// Constructor with string representation of an Artist object
        /// </summary>
        /// <param name="artistString"></param>
        public Artist(string artistString)
        {
            string[] artistData = artistString.Split(ARTIST_DELIM);

            this.Name = artistData[0];
            this.Bio = artistData[1];
            this.Website = artistData[2];
            this.SpotifyId = artistData[3];
            SetProfilePic(artistData[4]);

        }

        /// <summary>
        /// Name:
        /// Bio:
        /// Website: 
        /// SpotifyId:
        /// ProfilePic:
        /// </summary>
        public void Save()
        {
            try
            {
                StreamWriter outputFile;

                outputFile = File.AppendText(ARTISTS_FILENAME);

                string artistData = this.Name + ARTIST_DELIM + this.Bio + ARTIST_DELIM + this.Website + ARTIST_DELIM + this.SpotifyId + ARTIST_DELIM + _profPicSource;
                outputFile.WriteLine(artistData);
                outputFile.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error Saving Artist:" + this.Name + " to File", ex);
            }
        }

        /// <summary>
        /// Save the artist to an existing stream
        /// </summary>
        public void Save(ref StreamWriter outputFile)
        {
            try
            {
                string artistData = this.Name + ARTIST_DELIM + this.Bio + ARTIST_DELIM + this.Website + ARTIST_DELIM + this.SpotifyId + ARTIST_DELIM + _profPicSource;
                outputFile.WriteLine(artistData);

            }
            catch (Exception ex)
            {
                throw new Exception("Error Saving Artist: " + this.Name + " to File" + ex.Message);
            }
        }

        /// <summary>
        /// Return a string representation of this Artist object, which can be used for file I/O
        /// </summary>
        new public string ToString()
        {
            return this.Name + ARTIST_DELIM + this.Bio + ARTIST_DELIM + this.Website + ARTIST_DELIM + this.SpotifyId + ARTIST_DELIM + _profPicSource;
        }

        /// <summary>
        /// Load an Artist from an existing StreamReader object
        /// </summary>
        /// <param name="inputFile"></param>
        public void Load(ref StreamReader inputFile)
        {
            try
            {
                string line = inputFile.ReadLine();
                string[] artistData = line.Split(ARTIST_DELIM);

                this.Name = artistData[0];
                this.Bio = artistData[1];
                this.Website = artistData[2];
                this.SpotifyId = artistData[3];
                SetProfilePic(artistData[4]);
            }
            catch (Exception ex)
            {
                throw new Exception("Artist Load Error." + ex.Message);
            }
        }

        /// <summary>
        /// Set the profile picture of this Artist object from the fileName Param
        /// </summary>
        /// <param name="fileName"></param>
        public void SetProfilePic(string fileName)
        {
            if (fileName != "")
            {
                try
                {
                    _profilePic = Image.FromFile(fileName);
                    _profPicSource = fileName;
                }
                catch (Exception ex)
                {
                    throw new Exception("SetProfilePic Error." + ex.Message);
                }
            }
        }
    }
}
