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
    public partial class AddAlbumForm : Form
    {
        Dictionary<string, Artist> ArtistDictionary;
        string ArtistName = "";

        Album album = new Album();
        public AddAlbumForm()
        {
            InitializeComponent();
            //LoadArtists();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadArtists()
        {
            Loader loader = new Loader();
            ArtistDictionary = loader.LoadArtists();
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog.FileName;
            album.SetAlbumCoverArt(fileName);
            picBoxProfilePic.Image = album.CoverArt;
        }

        private void btnSelectArtist_Click(object sender, EventArgs e)
        {
            SelectArtistForm selectArtist = new SelectArtistForm();
            Artist SelectedArtist = new Artist();
            selectArtist.ShowDialog();
            if (selectArtist.DialogResult == DialogResult.OK)
            {
                try
                {
                    LoadArtists();
                    ArtistName = selectArtist.SelectedArtist;
                    SelectedArtist = ArtistDictionary[ArtistName];
                    txtBoxMainArtist.Text = ArtistName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error getting artist.");
                }
            }
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            AddArtistForm addArtist = new AddArtistForm();
            addArtist.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            album.Save();
        }
    }
}
