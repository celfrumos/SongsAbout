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

        const string FILE_NAME = "Artists.txt";
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
                StreamWriter outputFile;// = new StreamWriter(fileName);

                outputFile = File.AppendText(FILE_NAME);

                //  outputFile.WriteLine(DELIMITER);
                string artistData = this.Name + "," + this.Bio + "," + this.Website + "," + this.SpotifyId + "," + this.ProfPicSource;
                outputFile.WriteLine(artistData);
                //List<string> line = new List<string> { this.Name, this.Bio, this.Website, this.SpotifyId, this.ProfPicSource };
                //string outPutLine = string.Join(",", string);
                //outputFile.WriteLine(line);
                //outputFile.WriteLine("Name:" + this.Name);
                //outputFile.WriteLine("Bio:" + this.Bio);
                //outputFile.WriteLine("Website:" + this.Website);
                //outputFile.WriteLine("SpotifyId:" + this.SpotifyId);
                //outputFile.WriteLine("ProfilePic:" + this.ProfPicSource);

                outputFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Artist:" + this.Name + " to File");
            }
        }

        public void Load(string name)
        {
            try
            {
                StreamReader inputFile = new StreamReader(FILE_NAME);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetProfilePic(string fileName)
        {
            _profilePic = Image.FromFile(fileName);
            _profPicSource = fileName;
        }
    }
}
