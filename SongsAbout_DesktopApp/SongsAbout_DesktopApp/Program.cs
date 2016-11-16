using System;
using System.Collections.Generic;
using System.Linq;
using SongsAbout.Properties;
using SongsAbout.Classes;
using SongsAbout.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SongsAbout
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            User.Default.Upgrade();
           
            ConnectSpotify();
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nClosing Program.", "Fatal Error Running Application");
            }
        }

        private async static void ConnectSpotify()
        {
            try
            {
                if (User.Default.UserId != null)
                {
                    //  UserSpotify.ImplicitConnectSpotify();
                }
                if (User.Default.SpotifyWebAPI == null)
                {
                    await Task.Run(() => UserSpotify.Authenticate());
                }
                else
                {
                    MessageBox.Show("Profile Already Defined.");

                    UserSpotify.FetchProfile();
                    UserSpotify.FetchFollowedArtists();
                    UserSpotify.FetchProfilePic();
                    User.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting desired Info");
            }
        }


    }
}
