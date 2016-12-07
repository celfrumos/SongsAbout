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
            SetProfilePic();
            this.lstBxGenres.DataSource = SongDatabase.ExistingGenres;

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
}