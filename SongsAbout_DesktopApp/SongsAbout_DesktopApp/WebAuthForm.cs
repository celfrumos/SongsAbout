using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Classes;
using SongsAbout_DesktopApp.Forms;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;


using SongsAbout_DesktopApp.Properties;

namespace SongsAbout_DesktopApp
{
    public partial class WebAuthForm : Form
    {
        ImplicitGrantAuth implicitAuth = new ImplicitGrantAuth();
        public WebAuthForm()
        {
            InitializeComponent();
        }

 

    }
}
