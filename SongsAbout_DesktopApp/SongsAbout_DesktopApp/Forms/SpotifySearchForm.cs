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
using SongsAbout.Enums;

namespace SongsAbout.Forms
{
    public partial class SpotifySearchForm : SForm
    {
        private SearchType _searchType = SearchType.All;

        public SpotifySearchForm()
        {
            InitializeComponent();
            try
            {
                // LoadDbArtists();
                //  this.attributeViewer1 = new AttributeViewer(DbEntityType.Genre);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

      
        private void SpotifyPanel_Click(object sender, EventArgs e)
        {
            var control = sender as IEntityControl;

           Console.WriteLine($"{control.Text} Panel Clicked");
            try
            {
                control.ImportEntity();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        private void RedrawForm(string objTag)
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
                        _searchType = SearchType.All;
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in RedrawForm(): " + ex.Message);
                flpSpotifyControls.Controls.Add(new SLabel(objTag, SpotifyPanel_Click));
            }

        }

        private async void LoadDbArtists()
        {
            List<Artist> artists = new List<Artist>();
            using (var db = new DataClassesContext())
            {
                artists = (from a in db.Artists
                           select a).ToList();
            }
            foreach (Artist a in artists)
            {
                var lbl = new SPanel(a);//, SPanelType.StackedImage);
                                        //    lbl.PanelType = SPanelType.StackedImage;
                await Task.Run(() => AddToFlow(lbl));
            }
        }

        private void PromptOptions()
        {
        }

        private async void LoadPlaylists()
        {
            try
            {
                var playlists = UserSpotify.GetPlaylists();

                foreach (SimplePlaylist playlist in playlists)
                {
                    try
                    {
                        if (playlist.Public)
                        {
                            var p = (FPlaylist)await UserSpotify.WebAPI.GetPlaylistAsync(User.Default.PrivateId, playlist.Id);
                            SPanel panel = new SPanel(p, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click);
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
               var albums = UserSpotify.WebAPI.GetSavedAlbums();
                foreach (var a in albums.Items)
                {
                    try
                    {
                        var album = (FAlbum)await UserSpotify.WebAPI.GetAlbumAsync(a.Album.Id);
                        SPanel panel = new SPanel(album, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click);

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

        private async void ExecuteSearch(string query, SearchType searchType, int limit = 20, int offset = 0)
        {
            var resultsList = UserSpotify.Search(query, searchType, limit, offset);
            if (searchType == SearchType.All)
            {
                if (resultsList.Artists.Items.Count > 0)
                {
                    foreach (var artist in resultsList.Artists.Items)
                    {
                        await Task.Run(() => AddToFlow(new SPanel(artist, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click)));
                    }
                    flpSpotifyControls.Refresh();
                }
                
            }
            else
            {
                if (searchType == SearchType.Artist)
                {
                    resultsList.Artists.Items.ForEach(a =>
                    {
                        AddToFlow(new SPanel(a, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));
                    });
                }
                if (searchType == SearchType.Album)
                {
                    resultsList.Albums.Items.ForEach(al =>
                    {
                        AddToFlow(new SPanel(al, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));
                    });
                }
                if (searchType == SearchType.Track)
                {
                    resultsList.Tracks.Items.ForEach(t =>
                    {
                        AddToFlow(new SPanel(t, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));
                    });
                }
                if (searchType == SearchType.Playlist)
                {
                    resultsList.Playlists.Items.ForEach(p =>
                    {
                        AddToFlow(new SPanel(p, SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));
                    });
                }

            }
        }

        private void AddToFlow(SPanel panel)
        {
            try
            {
                {
                    if (flpSpotifyControls.InvokeRequired)
                    {
                        flpSpotifyControls.Invoke(new MethodInvoker(delegate
                        {
                            flpSpotifyControls.Controls.Add(panel);
                            flpSpotifyControls.Refresh();
                        }));
                    }
                    else
                    {
                        flpSpotifyControls.Controls.Add(panel);
                        flpSpotifyControls.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private async void AddToFlow(SLabel label)
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
