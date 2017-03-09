using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout.Desktop.Forms;
using SongsAbout;
using SongsAbout.Enums;

using SongsAbout.Desktop.Properties;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

namespace SongsAbout.Desktop.Forms
{

    public partial class SForm : Form
    {
        public SForm()
        {
            InitializeComponent();
            SetProfilePic();
            this.tsmiImportPlaylists_WithTracks.Tag = true;
            this.tsmiImportPlaylists_NoTracks.Tag = false;
        }

        public void msiSpotifySearch_Click(object sender, EventArgs e)
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

        public void msiImportAll_Click(object sender, EventArgs e)
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

        public void msiImportFollowedArtists_Click(object sender, EventArgs e)
        {

        }
        public void msiImportSavedTracks_Click(object sender, EventArgs e)
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

        public async void msiConnectSpotify_Click(object sender, EventArgs e)
        {
            await Task.Run(() => UserSpotify.AuthenticateAsync());
        }


        public void tsmiFollowedPlaylists_Click(object sender, EventArgs e)
        {
            try
            {
                var tsmi = sender as ToolStripMenuItem;
                Importer.ImportSavedPlaylists((bool)tsmi.Tag);
                Console.WriteLine("Finished Importing Saved playlists");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Importing Saved playlists from Spotify: {ex.StackTrace}");
            }
        }

        public void tsmiBulkTags_Click(object sender, EventArgs e)
        {
            var tagsImport = new BulkImportForm() { DbEntityType = DbEntityType.Tag };
            tagsImport.ShowDialog();
        }

        public void tsmiBulkPlaylists_Click(object sender, EventArgs e)
        {
            var playlistImport = new BulkImportForm() { DbEntityType = DbEntityType.Playlist };
            playlistImport.ShowDialog();

        }

        public void tsmiBulkGenres_Click(object sender, EventArgs e)
        {
            var genresImport = new BulkImportForm() { DbEntityType = DbEntityType.Genre };
            genresImport.ShowDialog();

        }
    }

}