using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpotifyAPI;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SongsAbout.Properties;
using System.Windows.Forms;
using SongsAbout.Classes;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Threading.Tasks;

namespace SongsAbout.Controls
{

    public static class SpotifyControlEventHandlers
    {
        public static void Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void Enter(object sender, EventArgs e)
        {
            SpotifyLabel s = sender as SpotifyLabel;
            var a = s.Tag.ToString();
        }

        public static void Hover(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.Cursor = Cursors.Hand;
        }

        public static void Default_Click(object sender, EventArgs e)
        {
        }
    }
}
