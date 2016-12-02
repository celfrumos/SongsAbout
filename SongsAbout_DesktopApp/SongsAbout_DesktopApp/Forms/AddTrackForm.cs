using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout.Entities;
using SongsAbout.Classes;

namespace SongsAbout.Forms
{
    public partial class AddTrackForm : Form
    {
        public Track NewTrack { get; set; }

        public AddTrackForm()
        {
            InitializeComponent();
            NewTrack = new Track();
            this.DialogResult = DialogResult.None;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NewTrack.name = txtBoxName.Text;
                NewTrack.track_length_minutes = double.Parse(txtBoxLength.Text);

                string newAlbumId = cBoxAlbum.SelectedValue.ToString();
                //                NewTrack.album_id = int.Parse(newAlbumId);

                string newArtistId = cBoxAlbum.SelectedValue.ToString();
                NewTrack.track_artist_id = int.Parse(newArtistId);

                NewTrack.Save();

                //List<string> genres = GetGenres();
                // NewTrack.SaveGenres(ref genres);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
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

        private void btnNewArtist_Click(object sender, EventArgs e)
        {
            AddArtistForm artistForm = new AddArtistForm();
            artistForm.ShowDialog();

            if (artistForm.DialogResult == DialogResult.OK)
            {
                this.artistsTableAdapter.Fill(this.dataSet.Artists);
            }
        }

        private void btnNewAlbum_Click(object sender, EventArgs e)
        {
            Album newAlbum;
            AddAlbumForm albumForm = new AddAlbumForm(out newAlbum);
            albumForm.ShowDialog();
            if (albumForm.DialogResult == DialogResult.OK)
            {
                this.albumsTableAdapter.Fill(this.dataSet.Albums);
                // cBoxAlbum.Refresh();
            }
        }
    }
}
