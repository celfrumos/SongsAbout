using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using SpotifyAPI.Web.Models;
using SongsAbout.Properties;
using SongsAbout.Classes;
using SongsAbout.Entities;
using SongsAbout.Controls;
using SpotifyAPI.Web.Enums;

namespace SongsAbout.Forms
{
    public partial class SpotifySearchForm : Form
    {

        private SearchType _searchType = SearchType.All;
        public SpotifySearchForm()
        {
            InitializeComponent();
            try
            {
                // LoadArtists();
                //PromptOptions();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SpotifyLabel_Click(object sender, EventArgs e)
        {
            try
            {
                var control = sender as SpotifyLabel;
                var objTag = control.Tag;
                string objLevel = control.Level;

                RedrawForm(objTag.ToString(), objLevel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void SpotifyPanel_Click(object sender, EventArgs e)
        {
            var control = sender as SpotifyControl;

            var t = control.Tag;
            MessageBox.Show(t.ToString(), "Panel CLicked");

            // RedrawForm(objTag, objLevel);
        }
        private void RedrawForm(string objTag, string objLevel)
        {
            flpSpotifyControls.Controls.Clear();
            try
            {
                switch (objTag)
                {
                    case "Playlists":
                        _searchType = SearchType.Playlist;
                        break;
                    case "Artists":
                        _searchType = SearchType.Artist;
                        break;
                    case "Albums":
                        _searchType = SearchType.Album;
                        break;
                    case "Tracks":
                        _searchType = SearchType.Track;
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in RedrawForm(): " + ex.Message);
                EventHandler clickEvent = SpotifyLabel_Click;

                flpSpotifyControls.Controls.Add(new SpotifyLabel(objTag, objLevel, SpotifyLabel_Click));
            }

        }

        private void LoadArtists()
        {
            List<Artist> artists = new List<Artist>();
            using (var db = new DataClassesContext())
            {
                artists = (from a in db.Artists
                           select a).ToList();
            }
            foreach (Artist a in artists)
            {
                var lbl = new SpotifyPanel(a);//, SPanelType.StackedImage);
                                              //    lbl.PanelType = SPanelType.StackedImage;
                AddToFlow(lbl);
            }
        }

        private void PromptOptions()
        {
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
                        if (playlist.Public)
                        {
                            FullPlaylist p = await UserSpotify.WebAPI.GetPlaylistAsync(User.Default.PrivateId, playlist.Id);
                            SpotifyPanel panel = new SpotifyPanel(p, SPanelType.Image, SpotifyLabel_Click);
                            flpSpotifyControls.Controls.Add(panel);
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
                Paging<SavedAlbum> albums = UserSpotify.WebAPI.GetSavedAlbums();
                foreach (var a in albums.Items)
                {
                    try
                    {
                        FullAlbum album = await UserSpotify.WebAPI.GetAlbumAsync(a.Album.Id);
                        SpotifyPanel panel = new SpotifyPanel(album, SPanelType.Image, SpotifyPanel_Click);

                        flpSpotifyControls.Controls.Add(panel);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error importing album {a.Album.Name}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing albums {ex.Message}");
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBoxSearch.Text != "")
                {
                    flpSpotifyControls.Controls.Clear();
                    ExecuteSearch(txtBoxSearch.Text, _searchType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error searching Spotify");
            }
        }

        private void ExecuteSearch(string query, SearchType searchType, int limit = 20, int offset = 0)
        {
            var resultsList = UserSpotify.WebAPI.SearchItems(query, searchType, limit, offset);
            //  var res = new List<BasicModel>();
            if (searchType == SearchType.All)
            {
                foreach (var a in resultsList.Artists.Items)
                {
                    var label = new SpotifyPanel(a, SPanelType.Image, SpotifyPanel_Click);
                    flpSpotifyControls.Controls.Add(label);
                }

                resultsList.Artists.Items.ForEach(a =>
                {
                    AddToFlow(new SpotifyPanel(a, SPanelType.Image, SpotifyPanel_Click));
                });
                //resultsList.Albums.Items.ForEach(al =>
                //{
                //    AddToFlow(new SpotifyPanel(al, SPanelType.Image, SpotifyPanel_Click));
                //});
                //resultsList.Tracks.Items.ForEach(t =>
                //{
                //    AddToFlow(new SpotifyPanel(t, SPanelType.Image, SpotifyPanel_Click));
                //});
                //resultsList.Playlists.Items.ForEach(p =>
                //{
                //    AddToFlow(new SpotifyPanel(p, SPanelType.Image, SpotifyPanel_Click));
                //});
            }
            else
            {
                if (searchType == SearchType.Artist)
                {
                    resultsList.Artists.Items.ForEach(a =>
                    {
                        AddToFlow(new SpotifyPanel(a, SPanelType.Image, SpotifyPanel_Click));
                    });
                }
                if (searchType == SearchType.Album)
                {
                    resultsList.Albums.Items.ForEach(al =>
                    {
                        AddToFlow(new SpotifyPanel(al, SPanelType.Image, SpotifyPanel_Click));
                    });
                }
                if (searchType == SearchType.Track)
                {
                    resultsList.Tracks.Items.ForEach(t =>
                    {
                        AddToFlow(new SpotifyPanel(t, SPanelType.Image, SpotifyPanel_Click));
                    });
                }
                if (searchType == SearchType.Playlist)
                {
                    resultsList.Playlists.Items.ForEach(p =>
                    {
                        AddToFlow(new SpotifyPanel(p, SPanelType.Image, SpotifyPanel_Click));
                    });
                }

            }
        }

        private async void AddToFlow(SpotifyPanel panel)
        {
            try
            {
                //await Task.Run(() =>                {
                if (flpSpotifyControls.InvokeRequired)
                {
                    flpSpotifyControls.Invoke(new MethodInvoker(delegate
                    {
                        flpSpotifyControls.Controls.Add(panel);
                    }));
                }
                else
                {
                    flpSpotifyControls.Controls.Add(panel);
                }
                //  });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private async void AddToFlow(SpotifyLabel label)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (flpSpotifyControls.InvokeRequired)
                    {
                        flpSpotifyControls.Invoke(new MethodInvoker(delegate
                        {
                            flpSpotifyControls.Controls.Add(label);
                        }));
                    }
                    else
                    {
                        flpSpotifyControls.Controls.Add(label);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
