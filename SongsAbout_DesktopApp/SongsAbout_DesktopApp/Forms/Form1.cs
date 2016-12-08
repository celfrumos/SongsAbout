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

            //Artist a = Artist.Load(4);
            //var albums = a.Albums;
           // var tracks = a.Tracks;
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}