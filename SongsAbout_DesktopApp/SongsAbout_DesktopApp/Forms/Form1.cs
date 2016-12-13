using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using SongsAbout.Classes;
using SongsAbout.Entities;
using SongsAbout.Properties;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

using SongsAbout.Forms;
using System.Linq;

namespace SongsAbout.Forms
{
    public partial class Form1 : SForm
    {
        public Form1() : base()
        {
            InitializeComponent();
            try
            {
              //  var dd = Program.Database.Artists.All;

                
                //foreach (var item in Program.Database.Tracks)
                //{
                //    var album = item.Album;
                //    var artist = item.Artist;
                    
                //}
         

                //Artist a = Artist.Load(4);
                //var albums = a.Albums;
                // var tracks = a.Tracks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}