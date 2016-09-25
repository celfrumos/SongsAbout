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
        bool isNewArtist = false;
        public Album NewAlbum { get; set; }
        private Artist _albumArtist;

        public AddAlbumForm()
        {
            InitializeComponent();
            NewAlbum = new Album();
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
            picBoxProfilePic.Image = Image.FromFile(fileName);
            // NewAlbum.SetAlbumCoverArt(fileName);
        }

        /// <summary>
        /// On click, show a dialog to select an artist for the album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectArtist_Click(object sender, EventArgs e)
        {
            SelectArtistForm selectArtist = new SelectArtistForm();
            _albumArtist = new Artist();
            selectArtist.ShowDialog();
            if (selectArtist.DialogResult == DialogResult.OK)
            {
                try
                {
                    _albumArtist = selectArtist.SelectedArtist;
                    txtBoxMainArtist.Text = _albumArtist.a_name;

                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message, "Error getting artist.");
                    throw new Exception("Error Getting Artist", ex);
                }
            }
        }


        /// <summary>
        /// On click, save the newly entered artist to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isNewArtist)
            {
                if (txtBoxTitle.Text != "")
                {
                    try
                    {
                        NewAlbum.artist_id = _albumArtist.artist_id;
                        NewAlbum.Save();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        this.DialogResult = DialogResult.Abort;
                        MessageBox.Show(ex.Message, "Something went wrong saving new Artist");
                    }

                }
                else
                {
                    MessageBox.Show("Please enter at least a tilte for the New album.");
                }

            }
        }

    }
}
