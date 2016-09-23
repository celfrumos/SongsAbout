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
    public partial class AddTrackForm : Form
    {
        const char GENRE_DELIM = '~';
        private Artist _trackArtist = new Artist();
        private Album _trackAlbum = new Album();
        public Track NewTrack { get; set; }

        public AddTrackForm()
        {
            InitializeComponent();
            NewTrack = new Track();
        }

        //private void LoadArtists()
        //{
        //    Loader loader = new Loader();
        //    ArtistDictionary = loader.LoadArtists();

        //}

        private void btnSelectArtist_Click(object sender, EventArgs e)
        {
            SelectArtistForm selectArtist = new SelectArtistForm();
            selectArtist.ShowDialog();
            if (selectArtist.DialogResult == DialogResult.OK)
            {
                _trackArtist = selectArtist.SelectedArtist;
                txtBoxMainArtist.Text = _trackArtist.Name;
            }
        }

        private void btnSelectAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAlbumForm selectAlbum = new SelectAlbumForm();
                selectAlbum.ShowDialog();
                if (selectAlbum.DialogResult == DialogResult.OK)
                {
                    NewTrack.Album = selectAlbum.SelectedAlbum;
                    txtBoxAlbum.Text = NewTrack.Album.Title;

                    txtBoxMainArtist.Text = NewTrack.Artist.Name;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong getting");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            NewTrack.Album = _trackAlbum;
            NewTrack.Album.MainArtist = _trackArtist;
            NewTrack.Name = txtBoxName.Text;
            NewTrack.Length = double.Parse(txtBoxLength.Text);
            NewTrack.SetGenres(GetGenres());
            NewTrack.Save();
            this.Close();
        }

        public string GetGenres()
        {
            string genres = "";
            foreach (var item in lstBxGenres.SelectedItems)
            {
                genres += item.ToString() + GENRE_DELIM;
            }

            return genres;
        }
    }
}
