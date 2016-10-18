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
            try
            {
                PromptOptions();
                //LoadAlbums();
                //     LoadPlaylists();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SpotifyControl_Click(object sender, EventArgs e)
        {
            string objTag;
            string objLevel;
            if (sender is SpotifyLabel)
            {
                SpotifyLabel lbl = sender as SpotifyLabel;
                objTag = lbl.Tag.ToString();
                objLevel = lbl.Level;
            }
            else if (sender is SpotifyPanel)
            {
                SpotifyPanel panel = sender as SpotifyPanel;
                objTag = panel.Tag.ToString();
                objLevel = panel.Level;
            }
            else if (sender is SpotifyPictureBox)
            {
                SpotifyLabel pBox = sender as SpotifyLabel;
                objTag = pBox.Tag.ToString();
                objLevel = pBox.Level;
            }
            else
            {
                throw new Exception("Something went Wrong");
            }
            RedrawForm(objTag, objLevel);
        }

        private void RedrawForm(string objTag, string objLevel)
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                switch (objTag)
                {
                    case "Playlists":
                        LoadPlaylists();
                        break;
                    case "Artists":
                        LoadArtists();
                        break;
                    case "Albums":
                        LoadAlbums();
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in RedrawForm(): " + ex.Message);
                flowLayoutPanel1.Controls.Add(new SpotifyLabel( objTag, objLevel, SpotifyControl_Click));
            }

        }

        private void LoadArtists()
        {
            throw new NotImplementedException();
        }

        private void PromptOptions()
        {
            SpotifyLabel lblPlaylists = new SpotifyLabel("Playlists", SpotifyControl_Click);
            SpotifyLabel lblAlbums = new SpotifyLabel("Artists", SpotifyControl_Click);
            SpotifyLabel lblTracks = new SpotifyLabel("Albums", SpotifyControl_Click);
            //lblPlaylists.Click += SpotifyControl_Click;
            //lblAlbums.Click += SpotifyControl_Click;
            //lblTracks.Click += SpotifyControl_Click;
            //lblPlaylists.AddEventHandler(SpotifyControl_Click);

            flowLayoutPanel1.Controls.Add(lblPlaylists);
            flowLayoutPanel1.Controls.Add(lblAlbums);
            flowLayoutPanel1.Controls.Add(lblTracks);
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
                        if (playlist.Public == true)
                        {
                            FullPlaylist p = await UserSpotify.WebAPI.GetPlaylistAsync(User.Default.UserId, playlist.Id);
                            SpotifyPanel panel = new SpotifyPanel(ref p, SpotifyControl_Click);
                            // panel.Click += SpotifyControl_Click; 
                            flowLayoutPanel1.Controls.Add(panel);
                        }
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
                        FullAlbum album = await UserSpotify.WebAPI.GetAlbumAsync(a.Album.Id);
                        SpotifyPanel panel = new SpotifyPanel(ref album,SpotifyControl_Click);
                        
                        flowLayoutPanel1.Controls.Add(panel);
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
