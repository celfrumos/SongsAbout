using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyAPI.Local;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;


namespace SongsAbout_DesktopApp.Forms
{
    public partial class SelectionForm : Form
    {
        SpotifyWebAPI _spotify = new SpotifyWebAPI();
        public SelectionForm()
        {
            InitializeComponent();
        }

        private async void TestAPI()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
                    "http://localhost",
                    8000,
                    Properties.Resources.SpotifyClientID,
                    Scope.UserReadPrivate,
                    TimeSpan.FromSeconds(20)
            );

            try
            {
                //This will open the user's browser and returns once
                //the user is authorized.
                _spotify = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (_spotify == null)
            { return; }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestAPI();
        }
    }
}
