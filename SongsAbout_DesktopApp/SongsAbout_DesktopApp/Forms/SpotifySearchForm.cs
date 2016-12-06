﻿using System;
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
        private SearchType _searchType;

        public SpotifySearchForm()
        {
            InitializeComponent();
            _searchType = SearchType.All;
            cboxAlbums.Tag = SearchType.Album;
            cboxAll.Tag = SearchType.All;
            cboxArtists.Tag = SearchType.Artist;
            cboxPlaylists.Tag = SearchType.Playlist;
            cboxTracks.Tag = SearchType.Track;

        }


        private void SpotifyPanel_Click(object sender, EventArgs e)
        {
            var control = sender as IEntityControl;

            Console.WriteLine($"{control.SpotifyEntity.Name} Panel Clicked");
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

            this.albumDisplay1 = new AlbumDisplay((FAlbum)new SAlbum(resultsList.Albums.Items[0]).FullVersion());
            return;
            if (searchType == SearchType.All)
            {
                if (resultsList.Albums.Items.Count > 0)
                {
                    foreach (var album in resultsList.Albums.Items)
                    {
                        await Task.Run(() => AddToFlow(new SPanel(new SAlbum(album), SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click)));
                        break;
                    }
                    flpSpotifyControls.Refresh();
                    return;
                }

            }
            else
            {
                if (HasSearchType(SearchType.Artist))
                {
                    foreach (FullArtist a in resultsList.Artists.Items)
                    {
                        AddToFlow(new SPanel(new FArtist(a), SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));

                    }
                }
                if (HasSearchType(SearchType.Album))
                {
                    foreach (var al in resultsList.Albums.Items)
                    {
                        AddToFlow(new SPanel(new SAlbum(al), SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));
                    }
                }
                if ((searchType & SearchType.Track) == SearchType.Track)
                {
                    foreach (var t in resultsList.Tracks.Items)
                    {
                        AddToFlow(new SPanel(new FTrack(t), SPanelType.Text, SPanelSize.Small, SpotifyPanel_Click));
                    }
                }
                if (HasSearchType(SearchType.Playlist))
                {
                    foreach (var p in resultsList.Playlists.Items)
                    {
                        AddToFlow(new SPanel(new SPlaylist(p), SPanelType.Image, SPanelSize.Small, SpotifyPanel_Click));
                    }
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
        private bool HasSearchType(SearchType targetType)
        {
            return (_searchType & targetType) == targetType;
        }
        private SearchType TogleSearchType(SearchType targetType)
        {
            return _searchType ^ targetType;
        }

        public SearchType SetSearchType(SearchType targetType)
        {
            return _searchType | targetType;
        }

        public SearchType UnsetSearchType(SearchType targetFlag)
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
            _searchType = SearchType.All;
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
                    _searchType = UnsetSearchType(SearchType.All);
                }
            }
            _searchType = TogleSearchType((SearchType)cBox.Tag);
        }
    }
}
