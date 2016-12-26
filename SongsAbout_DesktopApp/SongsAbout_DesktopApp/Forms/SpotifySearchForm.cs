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
    public enum SSearchType
    {
        Artist = SearchType.Artist,
        Album = SearchType.Album,
        Track = SearchType.Track,
        Playlist = SearchType.Playlist,
        All = Artist | Album | Track | Playlist


    }
    public partial class SpotifySearchForm : SForm
    {
        private SSearchType _searchType;

        public SpotifySearchForm()
        {
            InitializeComponent();
            _searchType = SSearchType.All;
            cboxAlbums.Tag = SSearchType.Album;
            cboxAll.Tag = SSearchType.All;
            cboxArtists.Tag = SSearchType.Artist;
            cboxPlaylists.Tag = SSearchType.Playlist;
            cboxTracks.Tag = SSearchType.Track;

        }


        private void SpotifyPanel_Click(object sender, EventArgs e)
        {
            var control = sender as IEntityControl;

            Console.WriteLine($"{control.SpotifyEntity.Name} Panel Clicked");
            try
            {
                var spotify = control.SpotifyEntity;
                var entity = control.DbEntity;
                var imported = control.ImportEntity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                        _searchType = SSearchType.Playlist;
                        break;
                    case "Artists":
                        _searchType = SSearchType.Artist;
                        break;
                    case "Albums":
                        _searchType = SSearchType.Album;
                        break;
                    case "Tracks":
                        _searchType = SSearchType.Track;
                        break;
                    default:
                        _searchType = SSearchType.All;
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
                        var album = (SpotifyAlbum)await UserSpotify.WebAPI.GetAlbumAsync(a.Album.Id);
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

        private async void ExecuteSearch(string query, SSearchType searchType, int limit = 20, int offset = 0)
        {
            var resultsList = UserSpotify.Search(query, (SearchType)searchType, limit, offset);

            // this.albumDisplay1 = new AlbumDisplay((FAlbum)new SAlbum(resultsList.Albums.Items[0]).FullVersion());
            //return;

            //if (resultsList.Albums.Items.Count > 0)
            //{
            //    foreach (var album in resultsList.Albums.Items)
            //    {
            //        await Task.Run(() => AddToFlow(new SPanel(new SAlbum(album), SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click)));
            //        //  break;
            //    }
            //    flpSpotifyControls.Refresh();
            //    return;
            //}

            //if (HasSearchType(SSearchType.Artist))
            //{
            //    foreach (FullArtist a in resultsList.Artists.Items)
            //    {
            //        AddToFlow(new SPanel(new FArtist(a), SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));

            //    }
            //}
            //if (HasSearchType(SSearchType.Album))
            //{
            //    foreach (var al in resultsList.Albums.Items)
            //    {
            //        AddToFlow(new SPanel(new SAlbum(al), SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));
            //    }
            //}
            if (HasSearchType(SSearchType.Track))
            {
                foreach (var t in resultsList.Tracks.Items)
                {
                    var row = new TrackRow(t);
                    AddToFlow(row);
                    return;
                }
            }
            if (HasSearchType(SSearchType.Playlist))
            {
                foreach (var p in resultsList.Playlists.Items)
                {
                    // AddToFlow(new SPanel(new SPlaylist(p), SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));
                }
            }


        }

        private void AddToFlow(IEntityControl panel)
        {
            try
            {
                {
                    if (flpSpotifyControls.InvokeRequired)
                    {
                        flpSpotifyControls.Invoke(new MethodInvoker(delegate
                        {
                            flpSpotifyControls.Controls.Add((Control)panel);
                            flpSpotifyControls.Refresh();
                        }));
                    }
                    else
                    {
                        flpSpotifyControls.Controls.Add((Control)panel);
                        flpSpotifyControls.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private bool HasSearchType(SSearchType targetType)
        {
            return (_searchType & targetType) == targetType;
        }
        private SSearchType ToggleSearchType(SSearchType targetType)
        {
            return (SSearchType)Flag.Spotify.Search.ToggleFlag((SearchType)_searchType, (SearchType)targetType);
        }

        public SSearchType SetSearchType(SSearchType targetType)
        {
            return _searchType | targetType;
        }

        public SSearchType UnsetSearchType(SSearchType targetFlag)
        {
            return _searchType & (~targetFlag);
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

        private void cboxAll_CheckedChanged(object sender, EventArgs e)
        {
            var cBox = sender as CheckBox;
            _searchType = SSearchType.All;
            if (cBox.Checked)
            {
                foreach (CheckBox item in pnlSearchType.Controls)
                {
                    item.Checked = false;
                }

            }

        }

        private void cbox_SpecificCheckedChanged(object sender, EventArgs e)
        {
            var cBox = sender as CheckBox;
            if (cboxAll.Checked)
            {
                if (cBox.Checked)
                {
                    cboxAll.Checked = false;
                    _searchType = UnsetSearchType(SSearchType.All);
                }
            }
            _searchType = ToggleSearchType((SSearchType)cBox.Tag);
        }
    }
}
