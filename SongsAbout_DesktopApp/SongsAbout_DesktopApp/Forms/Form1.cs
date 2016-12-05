using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using SongsAbout.Classes;
using SongsAbout.Properties;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

using SongsAbout.Forms;

namespace SongsAbout.Forms
{
    public partial class Form1 : SForm
    {
        public Form1()
        {
            InitializeComponent();
            SetProfilePic();

        }

        private async void SetProfilePic()
        {
            try
            {
                if (User.Default.ProfilePic != null)
                {
                    pBoxProfilePic.Image = await UserSpotify.ImportImageFromSpotify(User.Default.ProfilePic);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Setting Profile Picture: {ex.Message}");
            }

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}