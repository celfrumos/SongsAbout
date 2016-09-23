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
        Dictionary<string, Artist> ArtistDictionary;
        string ArtistName = "";

        Artist SelectedArtist = new Artist();

        public AddTrackForm(ref Dictionary<string, Artist> artistDictionary)
        {
            InitializeComponent();
            ArtistDictionary = artistDictionary;
        }

        public AddTrackForm()
        {
            InitializeComponent();
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            AddArtistForm addArtist = new AddArtistForm();
            addArtist.ShowDialog();
        }

        private void LoadArtists()
        {
            Loader loader = new Loader();
            ArtistDictionary = loader.LoadArtists();

        }
        private void btnAddAlbum_Click(object sender, EventArgs e)
        {
            AddAlbumForm addAlbum = new AddAlbumForm();
            addAlbum.ShowDialog();
        }

        private void btnSelectArtist_Click(object sender, EventArgs e)
        {
            SelectArtistForm selectArtist = new SelectArtistForm();
            selectArtist.ShowDialog();
            if (selectArtist.DialogResult == DialogResult.OK)
            {
                txtBoxMainArtist.Text = ArtistName;
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
                MessageBox.Show(ex.Message, "Something went wrong opening albums Form");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
