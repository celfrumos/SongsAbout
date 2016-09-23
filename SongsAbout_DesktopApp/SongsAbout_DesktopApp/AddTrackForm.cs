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
                    txtBoxAlbum.Text = selectAlbum.SelectedAlbum.Title;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong opening SelectAlbumForm");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // NewTrack.
            NewTrack.Album = _trackAlbum;
            NewTrack.Album.MainArtist = _trackArtist;
            NewTrack.Name = txtBoxName.Text;

            NewTrack.Save();
            this.Close();
        }
    }
}
