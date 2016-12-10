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
                var dd = SongDatabase.ExistingArtists;
                var a = Artist.Load("Jon Bellion");
                var als = a.Albums;
                foreach (var al in als)
                {
                    foreach (var track in al.Tracks)
                    {
                        Console.WriteLine($"Artist{a.Name}, Album: {al.Name}, Track: {track.Name}");
                    }
                }

                //Artist a = Artist.Load(4);
                //var albums = a.Albums;
                // var tracks = a.Tracks;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}