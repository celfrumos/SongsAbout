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
    class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public string SpotifyId { get; set; }
        public Image ProfilePic { get; set; }
      
        public Artist()
        {
        }

        public void Save()
        {
            string filename = "Artists\\" + this.Name + ".txt";
            StreamWriter outputFile;
            try
            {
                outputFile = File.CreateText(filename);

                outputFile.WriteLine(this.Name);
                outputFile.WriteLine(this.Bio);
                outputFile.WriteLine(this.Website);
                outputFile.WriteLine(this.SpotifyId);

                outputFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Artist:" + this.Name + " to File");
            }
        }

    }
}
