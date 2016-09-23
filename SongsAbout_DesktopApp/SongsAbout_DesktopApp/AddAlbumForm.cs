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
        Album SelectedAlbum = new Album();
        private Artist _albumArtist;
        public AddAlbumForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog.FileName;
            SelectedAlbum.SetAlbumCoverArt(fileName);
            picBoxProfilePic.Image = SelectedAlbum.CoverArt;
        }

        private void btnSelectArtist_Click(object sender, EventArgs e)
        {
            SelectArtistForm selectArtist = new SelectArtistForm();
            _albumArtist = new Artist();
            selectArtist.ShowDialog();
            if (selectArtist.DialogResult == DialogResult.OK)
            {
                try
                {
                    //LoadArtists();

                    _albumArtist = selectArtist.SelectedArtist;
                    txtBoxMainArtist.Text = _albumArtist.Name;

                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message, "Error getting artist.");
                    throw new Exception("Error Getting Artist", ex);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectedAlbum.Title = txtBoxTitle.Text;
            SelectedAlbum.Year = txtBoxYear.Text;
            SelectedAlbum.MainArtist = _albumArtist;

            SelectedAlbum.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
