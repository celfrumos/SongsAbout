using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Classes;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SongsAbout_DesktopApp.Properties;
using SongsAbout_DesktopApp.Forms;

using Image = System.Drawing.Image;

namespace SongsAbout_DesktopApp.Forms
{
    public partial class ImportPlaylistsForm : Form
    {
        public ImportPlaylistsForm()
        {
            InitializeComponent();
            LoadTracks();
        }

        private void LoadTracks()
        {
            List<SimplePlaylist> playlists = UserSpotify.GetPlaylists();

            for (int i = 0; i < playlists.Count; i++)
            {
                FullPlaylist p = UserSpotify.WebAPI.GetPlaylist(User.Default.UserId, playlists[i].Id);
          
                flowLayoutPanel1.Controls.Add(new SpotifyPanel(ref p));

            }

        }
    }
}
