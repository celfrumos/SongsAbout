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
    public partial class ViewSpotifyForm : Form
    {
        public ViewSpotifyForm()
        {
            InitializeComponent();
            //LoadAlbums();
            try
            {
                LoadPlaylists();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadPlaylists()
        {
            try
            {
                List<SimplePlaylist> playlists = UserSpotify.GetPlaylists();

                foreach (SimplePlaylist playlist in playlists)
                {
                    try
                    {
                        flowLayoutPanel1.Controls.Add(new SpotifyPanel(await UserSpotify.WebAPI.GetPlaylistAsync(User.Default.UserId, playlist.Id)));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading Playlist '{playlist.Name}': {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Playlists: {ex.Message}");
            }
        }

        private async void LoadAlbums()
        {
            try
            {
                Paging<SavedAlbum> albums = User.Default.SpotifyWebAPI.GetSavedAlbums();
                foreach (var a in albums.Items)
                {
                    try
                    {
                        flowLayoutPanel1.Controls.Add(new SpotifyPanel(await UserSpotify.WebAPI.GetAlbumAsync(a.Album.Id)));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error importing album {a.Album.Name}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
            }
        }
    }
}
