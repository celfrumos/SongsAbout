using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout.Forms;
using SongsAbout.Classes;
using SongsAbout.Enums;

using SongsAbout.Properties;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

namespace SongsAbout.Forms
{

    public partial class SForm : Form
    {
        public SForm()
        {
            InitializeComponent();
            SetProfilePic();
        }

        public static void msiSpotifySearch_Click(object sender, EventArgs e)
        {
            SpotifySearchForm spotifySearch = new SpotifySearchForm();
            spotifySearch.ShowDialog();
        }
        public async void SetProfilePic()
        {
            try
            {
                if (User.Default.ProfilePic != null)
                {
                    pBoxProfilePic.Image = await Task.Run(() => User.Default.ProfilePic);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Setting Profile Picture: {ex.Message}");
            }

        }

        public static void msiAddTrack_Click(object sender, EventArgs e)
        {
            try
            {
                var addAlbum = new AddAlbumForm();
                try
                {
                    addAlbum.ShowDialog();
                }
                catch (System.ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Something went wrong.");
                }
                if (addAlbum.DialogResult == DialogResult.OK)
                    MessageBox.Show("Successfully saved ", "Success!");

                else
                    MessageBox.Show("Something stopped the track from saving.");

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.Message + ex.InnerException.Message, "Something went wrong.");

                else
                    MessageBox.Show(ex.Message, "Something went wrong.");
            }
        }

        public static void msiViewData_Click(object sender, EventArgs e)
        {
            QueryForm queryForm = new QueryForm();
            try
            {
                queryForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong.");
            }
        }

        public static void msiImportAll_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Importing Artists from Spotify: " + ex.Message);
            }
        }

        public static void msiImportFollowedArtists_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportFollowedArtists();

                Console.WriteLine("Finished importing saved tracks");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Importing Artists from Spotify: {ex.Message}");
            }
        }
        public static void msiImportSavedTracks_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportSavedTracks();
                Console.WriteLine("Finished importing saved tracks");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Importing Saved Tracks from Spotify: {ex.StackTrace}");
            }
        }

        public async static void msiConnectSpotify_Click(object sender, EventArgs e)
        {
            await Task.Run(() => UserSpotify.Authenticate());
        }


        public static void msiDisconnect_Click(object sender, EventArgs e)
        {

        }

        public static void tsmiFollowedPlaylists_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportSavedPlaylists();
                Console.WriteLine("Finished Importing Saved playlists");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Importing Saved playlists from Spotify: {ex.StackTrace}");
            }
        }

        public static void tagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tagsImport = new BulkImportForm() { DbEntityType = DbEntityType.Tag };
            tagsImport.ShowDialog();
        }

        public static void playlistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var playlistImport = new BulkImportForm() { DbEntityType = DbEntityType.Playlist };
            playlistImport.ShowDialog();

        }

        private void genresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var genresImport = new BulkImportForm() { DbEntityType = DbEntityType.Genre };
            genresImport.ShowDialog();

        }
    }

}