using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp
{
    public partial class SelectAlbumForm : Form
    {
        string ArtistName = "";
        // Loader loader = new Loader();
        Dictionary<string, Artist> DictArtists;
        Dictionary<string, Album> DictAlbums;
        string AlbumArtistName = "";
        Artist AlbumArtist;

        public string SelectedArtistName { get; set; }

        public SelectAlbumForm(ref Dictionary<string, Artist> ArtistDictionary)
        {
            DictArtists = ArtistDictionary;
            LoadAlbums();
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }
        public SelectAlbumForm()
        {
            LoadArtists();
            LoadAlbums();
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedArtistName = lstBoxSelectAlbum.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception)
            {
                SelectedArtistName = "";
                this.DialogResult = DialogResult.Abort;
            }
            this.Close();
        }

        private void btnNewArtist_Click(object sender, EventArgs e)
        {
            AddArtistForm addArtist = new AddArtistForm();
            addArtist.ShowDialog();
            if (addArtist.DialogResult == DialogResult.OK)
            {
                LoadArtists();
                AlbumArtist = addArtist.NewArtist;
                txtBoxSelectedArtist.Text = AlbumArtist.Name;
            }
        }

        private void btnGetArtist_Click(object sender, EventArgs e)
        {
            SelectArtistForm selectArtist = new SelectArtistForm();
            selectArtist.ShowDialog();
            if (selectArtist.DialogResult == DialogResult.OK)
            {
                ArtistName = selectArtist.SelectedArtist;
                AlbumArtist = DictArtists[ArtistName];
                FilterByArtist(AlbumArtist);
            }

        }

        private void LoadArtists()
        {
            Loader loader = new Loader();
            DictArtists = loader.LoadArtists();
        }

        private void LoadAlbums()
        {
            Loader loader = new Loader();
            DictAlbums = loader.LoadAlbums();

            foreach (KeyValuePair<string, Album> album in DictAlbums)
            {
                lstBoxSelectAlbum.Items.Add(album);
            }
        }


        private void FilterByArtist(Artist albumArtist)
        {
            txtBoxSelectedArtist.Text = AlbumArtist.Name;
        }

        private void btnNewAlbum_Click(object sender, EventArgs e)
        {
            AddAlbumForm addAlbum = new AddAlbumForm();
            addAlbum.ShowDialog();
            LoadAlbums();
        }
    }
}
