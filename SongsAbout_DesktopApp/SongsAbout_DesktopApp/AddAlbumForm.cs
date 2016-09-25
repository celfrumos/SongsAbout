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
        Album NewAlbum = new Album();
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
            picBoxProfilePic.Image = Image.FromFile(fileName);
            NewAlbum.SetAlbumCoverArt(fileName);
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
                    txtBoxMainArtist.Text = _albumArtist.a_name;

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
            try
            {
                SaveAlbum();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                throw new Exception("Error Submitting data to database" + ex.Message);
            }
        }

        private void SaveAlbum()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DataSet artistData = new DataSet();
                NewAlbum.al_title = txtBoxTitle.Text;
                NewAlbum.al_year = txtBoxYear.Text;
                NewAlbum.Artist = _albumArtist;
                
                context.Albums.InsertOnSubmit(NewAlbum);

                if (artistData.Artists.FindByartist_id(_albumArtist.artist_id) != null)
                {
                    context.Artists.InsertOnSubmit(_albumArtist);
                }
                context.SubmitChanges();
            }
        }
    }
}
