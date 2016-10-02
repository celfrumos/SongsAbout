using System;
using System.IO;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp
{
    public partial class QueryForm : Form
    {

        private string newFileName { get; set; }
        public QueryForm()
        {
            InitializeComponent();
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.TrackArtistAlbum' table. You can move, or remove it, as needed.
            this.trackArtistAlbumTableAdapter.Fill(this.dataSet.TrackArtistAlbum);
            // TODO: This line of code loads data into the 'dataSet.TrackArtistAlbum' table. You can move, or remove it, as needed.
            this.trackArtistAlbumTableAdapter.Fill(this.dataSet.TrackArtistAlbum);
            try
            {
                // TODO: This line of code loads data into the 'dataSet.Lists' table. You can move, or remove it, as needed.
                this.listsTableAdapter.Fill(this.dataSet.Lists);
                // TODO: This line of code loads data into the 'dataSet.TrackTags' table. You can move, or remove it, as needed.
                this.trackTagsTableAdapter.Fill(this.dataSet.TrackTags);
                // TODO: This line of code loads data into the 'dataSet.Tags' table. You can move, or remove it, as needed.
                this.tagsTableAdapter.Fill(this.dataSet.Tags);
                // TODO: This line of code loads data into the 'dataSet.TrackGenres' table. You can move, or remove it, as needed.
                this.trackGenresTableAdapter.Fill(this.dataSet.TrackGenres);
                // TODO: This line of code loads data into the 'dataSet.Artists' table. You can move, or remove it, as needed.
                this.artistsTableAdapter.Fill(this.dataSet.Artists);
                // TODO: This line of code loads data into the 'dataSet.Albums' table. You can move, or remove it, as needed.
                this.albumsTableAdapter.Fill(this.dataSet.Albums);
                // TODO: This line of code loads data into the 'dataSet.Tracks' table. You can move, or remove it, as needed.
                this.tracksTableAdapter.Fill(this.dataSet.Tracks);
                // TODO: This line of code loads data into the 'dataSet.Genres' table. You can move, or remove it, as needed.
                this.genresTableAdapter.Fill(this.dataSet.Genres);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private bool SaveChanges()
        {
            try
            {
                this.Validate();
                this.artistsBindingSource.EndEdit();
                this.tableAdapterMngr.UpdateAll(this.dataSet);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Artist table");
                return false;
            }
        }
        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            bool saveSucceeded = SaveChanges();
            if (saveSucceeded)
            {
                MessageBox.Show("Success");
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            bool saveSucceeded = SaveChanges();
            if (saveSucceeded)
            {
                MessageBox.Show("Success. Now closing form.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Nothing was saved. Try again or press cancel to exit.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Artist_Drop(object sender, DragEventArgs e)
        {
            var i = e.Data.GetData("FileDrop", true);
            MessageBox.Show(i.ToString(), "File Contents");
        }

        private void artistsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int artistColumnIndex = 3;
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[artistColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == artistColumnIndex)
                {
                    DataGridViewCell selectedCell = senderGrid.Rows[e.RowIndex].Cells[artistColumnIndex];

                    UpdateCellValue(ref selectedCell);

                }
            }
        }

        private void UpdateCellValue(ref DataGridViewCell cell)
        {
            try
            {
                openFileDialog.ShowDialog();
                string filename = openFileDialog.FileName;
                byte[] newProfilePic = File.ReadAllBytes(filename);
                cell.Value = newProfilePic;

                SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error updating cell value");
            }
        }

        private void trackArtistAlbumDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
