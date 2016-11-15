using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Classes;
using SongsAbout_DesktopApp.Controls;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SongsAbout_DesktopApp.Properties;

namespace SongsAbout_DesktopApp.Forms
{
    public partial class SpotifySearchForm : Form
    {

        private SearchType _searchType = SearchType.All;
        public SpotifySearchForm()
        {
            InitializeComponent();
            try
            {
                PromptOptions();
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
            
            string objTag;
            string objLevel;
            var t = control.Tag;


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
                EventHandler clickEvent = SpotifyLabel_Click;

                flpSpotifyControls.Controls.Add(new SpotifyLabel(objTag, objLevel, SpotifyLabel_Click));
            }

        }

        private void LoadArtists()
        {
        }

        private void PromptOptions()
        {
            var s = new SpotifyLabel("Playlists", SpotifyLabel_Click);
            var sdaf = new Label();
            sdaf.Text = "dffdafdfa";
            flpSpotifyControls.Controls.Add(sdaf);
            
            flpSpotifyControls.Controls.Add(s);
            flpSpotifyControls.Controls.Add(new SpotifyLabel("Tracks", SpotifyLabel_Click));
            flpSpotifyControls.Controls.Add(new SpotifyLabel("Albums", SpotifyLabel_Click));
            flpSpotifyControls.Controls.Add(new SpotifyLabel("Tracks", SpotifyLabel_Click));
            flpSpotifyControls.Controls.Add(new SpotifyLabel("Playlists", SpotifyLabel_Click));
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
                            FullPlaylist p = await UserSpotify.WebAPI.GetPlaylistAsync(User.Default.UserId, playlist.Id);
                            SpotifyPanel panel = new SpotifyPanel(p, SpotifyLabel_Click);
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
                        SpotifyPanel panel = new SpotifyPanel(album, SpotifyPanel_Click);

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
                    //var s = UserSpotify.WebAPI.SearchItems(txtBoxSearch.Text, _searchType);
                    //var res = new List<BasicModel>();
                    //foreach (var item in s.Artists.Items)
                    //{
                    //    res.Add(item);

                    //}
                    //var artists = s.Artists;
                    //var albums = s.Albums;
                    //var tracks = s.Tracks;
                    //var playlists = s.Playlists;
                    //int i = 0;
                    //while (i < artists.Items.Count)
                    //{
                    //    var artist = artists.Items[i];
                    //    Console.WriteLine(artist.Name);
                    //    await Task.Run(() => AddToFlow(artist, SpotifyPanel_Click));
                    //    i++;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error searching Spotify");
            }
        }
 
        private async void ExecuteSearch(string query, SearchType searchType, int limit = 20, int offset = 0)
        {
            var resultsList = UserSpotify.WebAPI.SearchItems(query, searchType, limit, offset);
            var res = new List<BasicModel>();
            if (searchType == SearchType.All)
            {
                await Task.Run(() => resultsList.Artists.Items.ForEach(a => AddToFlow(a, SpotifyPanel_Click)));
                await Task.Run(() => resultsList.Albums.Items.ForEach(al => AddToFlow(al, SpotifyPanel_Click)));
                await Task.Run(() => resultsList.Tracks.Items.ForEach(t => AddToFlow(t, SpotifyPanel_Click)));
                await Task.Run(() => resultsList.Playlists.Items.ForEach(p => AddToFlow(p, SpotifyPanel_Click)));
            }
            else
            {
                if (searchType == SearchType.Artist)
                {
                    await Task.Run(() => resultsList.Artists.Items.ForEach(a => AddToFlow(a, SpotifyPanel_Click)));
                }
                if (searchType == SearchType.Album)
                {
                    await Task.Run(() => resultsList.Albums.Items.ForEach(al => AddToFlow(al, SpotifyPanel_Click)));
                }
                if (searchType == SearchType.Track)
                {
                    await Task.Run(() => resultsList.Tracks.Items.ForEach(t => AddToFlow(t, SpotifyPanel_Click)));
                }
                if (searchType == SearchType.Playlist)
                {
                    await Task.Run(() => resultsList.Playlists.Items.ForEach(p => AddToFlow(p, SpotifyPanel_Click)));
                }

            }
        }


        private void AddToFlow(FullArtist artist, EventHandler clickEvent)
        {
            if (flpSpotifyControls.InvokeRequired)
            {
                flpSpotifyControls.Invoke(new MethodInvoker(delegate
                {
                    flpSpotifyControls.Controls.Add(new SpotifyPanel(artist, clickEvent));
                }));
            }
            else
            {
                flpSpotifyControls.Controls.Add(new SpotifyPanel(artist, clickEvent));
            }
        }

        private void AddToFlow(SimplePlaylist playlist, EventHandler clickEvent)
        {
            if (flpSpotifyControls.InvokeRequired)
            {
                flpSpotifyControls.Invoke(new MethodInvoker(delegate
                {
                    flpSpotifyControls.Controls.Add(new SpotifyPanel(playlist, clickEvent));
                }));
            }
            else
            {
                flpSpotifyControls.Controls.Add(new SpotifyPanel(playlist, clickEvent));
            }
        }

        private void AddToFlow(FullTrack track, EventHandler clickEvent)
        {
            if (flpSpotifyControls.InvokeRequired)
            {
                flpSpotifyControls.Invoke(new MethodInvoker(delegate
                {
                    flpSpotifyControls.Controls.Add(new SpotifyPanel(track, clickEvent));
                }));
            }
            else
            {
                flpSpotifyControls.Controls.Add(new SpotifyPanel(track, clickEvent));
            }
        }

        private void AddToFlow(SimpleAlbum album, EventHandler clickEvent)
        {
            FullAlbum al = Converter.GetFullAlbum(album);
            if (flpSpotifyControls.InvokeRequired)
            {
                flpSpotifyControls.Invoke(new MethodInvoker(delegate
                {
                    flpSpotifyControls.Controls.Add(new SpotifyPanel(al, clickEvent));
                }));
            }
            else
            {
                flpSpotifyControls.Controls.Add(new SpotifyPanel(al, clickEvent));
            }
        }


    }
}
