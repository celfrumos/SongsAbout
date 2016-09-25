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
        public Track NewTrack { get; set; }

        public AddTrackForm()
        {
            InitializeComponent();
            NewTrack = new Track();
        }

        private void btnSelectArtist_Click(object sender, EventArgs e)
        {
            try
            {

                SelectArtistForm selectArtist = new SelectArtistForm();
                selectArtist.ShowDialog();
                if (selectArtist.DialogResult == DialogResult.OK)
                {
                    NewTrack.track_artist_id = selectArtist.SelectedArtist.artist_id;
                    cBoxMainArtist.Text = selectArtist.SelectedArtist.a_name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnSelectAlbum_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SelectAlbumForm selectAlbum = new SelectAlbumForm();
            //    selectAlbum.ShowDialog();
            //    if (selectAlbum.DialogResult == DialogResult.OK)
            //    {
            //        NewTrack.Album = selectAlbum.SelectedAlbum;

            //        txtBoxAlbum.Text = NewTrack.Album.al_title;
            //        txtBoxMainArtist.Text = NewTrack.Album.artist_id.ToString();
            //        // txtBoxMainArtist.Text = selectedAlbum.GetArtistName();

            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Something went wrong getting the chosen album");
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // NewTrack.Album = _trackAlbum;
                //  NewTrack.album_id = _trackAlbum.album_id;
                NewTrack.track_artist_id = NewTrack.Album.artist_id;
                // NewTrack.Album.Artist = _trackArtist;
                NewTrack.track_name = txtBoxName.Text;
                NewTrack.track_length_minutes = double.Parse(txtBoxLength.Text);
                NewTrack.Save();

                //List<string> genres = GetGenres();
                // NewTrack.SaveGenres(ref genres);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
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

        private void AddTrackForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Genres' table. You can move, or remove it, as needed.
            this.genresTableAdapter.Fill(this.dataSet.Genres);
            // TODO: This line of code loads data into the 'dataSet.Artists' table. You can move, or remove it, as needed.
            this.artistsTableAdapter.Fill(this.dataSet.Artists);
            // TODO: This line of code loads data into the 'dataSet.Albums' table. You can move, or remove it, as needed.
            this.albumsTableAdapter.Fill(this.dataSet.Albums);

        }
    }
}
