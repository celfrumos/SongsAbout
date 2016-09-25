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
                txtBoxMainArtist.Text = _trackArtist.a_name;
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
                    Album selectedAlbum = new Album();
                    selectedAlbum = selectAlbum.SelectedAlbum;
                    NewTrack.Album = selectedAlbum;
                    txtBoxAlbum.Text = selectedAlbum.al_title;

                    // txtBoxMainArtist.Text = selectedAlbum.GetArtistName();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong getting the chosen album");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewTrack.Album = _trackAlbum;
            // NewTrack.Album.Artist = _trackArtist;
            NewTrack.track_name = txtBoxName.Text;
            NewTrack.track_length_minutes = double.Parse(txtBoxLength.Text);
            NewTrack.Save();
            NewTrack.SaveGenres(GetGenres());
            this.Close();
        }

        public List<string> GetGenres()
        {
            List<string> genList = new List<string>();
            foreach (var item in lstBxGenres.SelectedItems)
            {
                genList.Add(item.ToString());
            }

            return genList;
        }
    }
}
