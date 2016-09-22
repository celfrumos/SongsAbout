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

        const string ARTISTS_FILENAME = "Artists.txt";
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public string SpotifyId { get; set; }

        public Image ProfilePic
        {
            get { return _profilePic; }
        }
        public string ProfPicSource
        {
            get { return _profPicSource; }
        }

        public Artist()
        {
            this.Id = "";
            this.Name = "";
            this.Bio = "";
            this.Website = "";
            this.SpotifyId = "";
            _profPicSource = "";
        }
        public Artist(string name, string bio, string website, string spotifyId, string profPicSource)
        {
            this.Name = name;
            this.Bio = bio;
            this.Website = website;
            this.SpotifyId = spotifyId;
            SetProfilePic(profPicSource);
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

                string artistData = this.Name + "," + this.Bio + "," + this.Website + "," + this.SpotifyId + "," + _profPicSource;
                outputFile.WriteLine(artistData);
                outputFile.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error Saving Artist:" + this.Name + " to File", ex);
            }
        }

        public void Load(string name)
        {
            try
            {
                StreamReader inputFile = new StreamReader(ARTISTS_FILENAME);
            }
            catch (Exception)
            {

                throw;
            }
        }

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
                    throw new Exception("Error occured while setting artist profile picture.", ex);
                }
            }
        }
    }
}
