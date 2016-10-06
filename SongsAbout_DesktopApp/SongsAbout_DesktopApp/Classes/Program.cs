using System;
using System.Collections.Generic;
using System.Linq;
using SongsAbout_DesktopApp.Properties;
using SongsAbout_DesktopApp.Classes;
using SongsAbout_DesktopApp.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp
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
           // Console.ReadLine();
            ConnectSpotify();
            Application.Run(new MainForm());
        }

        private async static void ConnectSpotify()
        {
            try
            {
                if (User.Default.PrivateProfile == null)
                {
                    await Task.Run(() => UserSpotify.Authenticate());
                }
                else
                {
                    MessageBox.Show("Profile Already Defined.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting desired Info");
            }
        }
    }
}
