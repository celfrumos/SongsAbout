using System;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using SpotifyAPI.Web.Models;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using SongsAbout.Classes;
using SongsAbout.Enums;
using SongsAbout.Properties;
using SongsAbout.Controls;
using System.Windows;
using SongsAbout;
using SongsAbout.Classes;
using SongsAbout.Entities;
using SongsAbout.Properties;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

using SongsAbout.Forms;

namespace SongsAbout.Forms
{
    public partial class Form1 : SForm
    {
        public Form1() : base()
        {
            InitializeComponent();
            try
            {
                // SetProfilePic();
                var a = Artist.Load("Jon Bellion");
                var als = a.Albums;
                foreach (var al in als)
                {
                    foreach (var track in al.Tracks)
                    {
                        Console.WriteLine($"Artist{a.Name}, Album: {al.Name}, Track: {track.Name}");
                    }
                }


                using (var db = new DataClassesContext())
                {
                    var genres = (from Genre g in db.Genres
                                  select g.Name).ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //  this.lstBxGenres.DataSource = SongDatabase.ExistingGenres;

        }

        private async void SetProfilePic()
        {
            try
            {
                if (User.Default.ProfilePic != null)
                {
                    //  pBoxProfilePic.Image = await UserSpotify.ImportImageFromSpotify(User.Default.ProfilePic);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Setting Profile Picture: {ex.Message}");
            }

    }
}