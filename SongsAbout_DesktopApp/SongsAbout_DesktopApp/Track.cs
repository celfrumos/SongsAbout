using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SongsAbout_DesktopApp
{
    public class Track
    {
        const string TRACK_FILE_NAME = "Tracks.txt";
        const char TRACK_DELIM = '\t';
        const char GENRE_DELIM = '~';
        public string Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public List<string> Genres { get; set; }
        public Album Album { get; set; }
        public Artist Artist
        {
            get { return this.Album.MainArtist; }
        }

        //  public List<Artist> FeatArtists { get; set; }

        public Track(string name, double length, List<string> genres, Album album, List<Artist> featArtists)
        {
            this.Name = name;
            this.Length = length;
            this.Genres = genres;
            this.Album = album;
            //  this.FeatArtists = featArtists;

        }

        public Track()
        {
            this.Name = "";
            this.Length = 0;
            this.Genres = new List<string>();
            this.Album = new Album();
            //  this.FeatArtists = new List<Artist>();

        }

        public Track(string trackString)
        {
            string[] trackInfo = trackString.Split(TRACK_DELIM);

            this.Name = trackInfo[0];
            this.Length = double.Parse(trackInfo[1]);
            SetGenres(trackInfo[2]);
            this.Album = new Album(trackInfo[3]);
        }
        public void Save()
        {
            try
            {
                StreamWriter outFile = File.AppendText(TRACK_FILE_NAME);

                outFile.WriteLine(this.ToString());
                outFile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Track Save Error:" + ex.Message);
            }
        }

        /// <summary>
        /// Return a string representation of this Track object, 
        /// which can be used for file I/O or initialization
        /// </summary>
        /// <returns></returns>
        new public string ToString()
        {
            string str =
                this.Name + TRACK_DELIM +
                this.Length + TRACK_DELIM +
                getGenreString() + TRACK_DELIM +
                this.Album.ToString() + TRACK_DELIM;

            return str;
            // + this.FeatArtists.ToString();
        }


        private string getGenreString()
        {
            string str = "";
            foreach (string genre in this.Genres)
            {
                str += genre + GENRE_DELIM;
            }
            return str;
        }


        public void SetGenres(string genString)
        {
            string[] genres = genString.Split(GENRE_DELIM);
            foreach (string g in genres)
            {
                this.Genres.Add(g);
            }
        }
    }
}
