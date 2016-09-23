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
        // Loader loader = new Loader();
        Dictionary<string, Artist> DictArtists;
        Dictionary<string, Album> DictAlbums;
        private Artist _albumArtist;

        //  string SelectedArtistName { get; set; }
        public Album SelectedAlbum { get; set; }

        public SelectAlbumForm(ref Dictionary<string, Artist> ArtistDictionary)
        {
            DictArtists = ArtistDictionary;
            LoadAlbums();
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }
        public SelectAlbumForm()
        {
            InitializeComponent();
            LoadAlbums();
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
                SelectedAlbum.MainArtist.Name = lstBoxSelectAlbum.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception)
            {
                _albumArtist.Name = "";
                this.DialogResult = DialogResult.Abort;
            }
            this.Close();
        }

        private void btnGetArtist_Click(object sender, EventArgs e)
        {
            SelectArtistForm selectArtist = new SelectArtistForm();
            selectArtist.ShowDialog();
            if (selectArtist.DialogResult == DialogResult.OK)
            {
                try
                {
                    _albumArtist = selectArtist.SelectedArtist;
                    FilterByArtist(_albumArtist);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Getting Artist.");
                }
            }

        }

        private void LoadAlbums()
        {
            Loader loader = new Loader();
            DictAlbums = loader.LoadAlbums();

            foreach (KeyValuePair<string, Album> album in DictAlbums)
            {
                Album a = album.Value;
                lstBoxSelectAlbum.Items.Add(a.Title);
            }
        }


        private void FilterByArtist(Artist albumArtist)
        {
            txtBoxSelectedArtist.Text = _albumArtist.Name;
        }

        private void btnNewAlbum_Click(object sender, EventArgs e)
        {
            AddAlbumForm addAlbum = new AddAlbumForm();
            addAlbum.ShowDialog();
            if (addAlbum.DialogResult == DialogResult.OK)
            {
                LoadAlbums();

            }
        }
    }
}
