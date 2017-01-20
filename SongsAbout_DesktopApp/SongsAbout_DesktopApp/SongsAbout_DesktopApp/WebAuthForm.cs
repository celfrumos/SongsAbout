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
using SongsAbout.Classes;
using SongsAbout.Forms;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;


using SongsAbout.Desktop.Properties;

namespace SongsAbout
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
