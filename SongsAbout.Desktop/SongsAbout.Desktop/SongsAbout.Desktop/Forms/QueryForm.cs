using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using SongsAbout.Desktop.Entities;
using SongsAbout.Desktop.Properties;
using SongsAbout;
using SongsAbout.Desktop.DataSetTableAdapters;

namespace SongsAbout.Desktop.Forms
{
    public partial class QueryForm : SForm
    {
        const int THREAD_COUNT = 10;
        const int PORT = 13000;
        Thread _artistThread;
        Thread _albumThread;
        Thread _tracksThread;
        Thread _genresThread;
        Thread _trackGenresThread;

        public QueryForm()
        {
            InitializeComponent();

            // ChooseConnection();

        }


        private async void QueryForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvTracks.DataError += dgv_DataError;
                dgvArtists.DataError += dgv_DataError;
                dgvAlbums.DataError += dgv_DataError;

                // this.tableAdapterMngr.UpdateAll(this.dataSet);
                FillTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine($"DataError:\n{e.Context} at row {e.RowIndex}, Exception:{e.Exception.Message}");
            e.ThrowException = false;
        }

        private void fillOnThreads()
        {

            _artistThread = new Thread(new ThreadStart(FillArtistTable));
            _artistThread.Priority = ThreadPriority.Highest;
            _albumThread.Priority = ThreadPriority.AboveNormal;
            _tracksThread.Priority = ThreadPriority.AboveNormal;

        }

        private async void FillTables()
        {
            FillArtistTable();
            await Task.Run(() => FillAlbumsTable());
            await Task.Run(() => FillTracksTable());
            await Task.Run(() => FillGenresTable());
            await Task.Run(() => FillTagsTable());

            await Task.Run(() => FIllTrackTagsTable());
            await Task.Run(() => FillListsTable());
            await Task.Run(() => FillTrackGenresTable());
            await Task.Run(() => FillAlbumGenresTable());
        }
        private void FillListsTable()
        {
            try
            {
                this.listsTableAdapter.Fill(this.dataSet.Lists);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Lists Table: {ex.Message}");
            }
        }
        private void FillTagsTable()
        {
            try
            {
                this.tagsTableAdapter.Fill(this.dataSet.Tags);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Tags Table: {ex.Message}");
            }
        }
        private void FIllTrackTagsTable()
        {
            try
            {
                this.trackTagsTableAdapter.Fill(this.dataSet.TrackTags);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling TrackTags Table: {ex.Message}");
            }
        }
        private void FillAlbumGenresTable()
        {
            try
            {
                this.albumGenresTableAdapter.Fill(this.dataSet.AlbumGenres);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling AlbumGenres Table: {ex.Message}");
            }

        }
        private void FillArtistTable()
        {
            try
            {
                this.artistsTableAdapter.Fill(this.dataSet.Artists);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Filling Artists Table: {ex.Message}");
            }
        }
        private void FillAlbumsTable()
        {
            try
            {
                // TODO: This line of code loads data into the 'dataSet.Albums' table. You can move, or remove it, as needed.
                this.albumsTableAdapter.Fill(this.dataSet.Albums);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Albums Table: {ex.Message}");
            }

        }
        private void FillTracksTable()
        {
            try
            {
                this.tracksTableAdapter.Fill(this.dataSet.Tracks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Tracks Table: {ex.Message}");
            }

        }
        private void FillGenresTable()
        {
            try
            {
                this.genresTableAdapter.Fill(this.dataSet.Genres);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Genres Table: {ex.Message}");
            }

        }
        private void FillTrackGenresTable()
        {
            try
            {
                this.trackGenresTableAdapter.Fill(this.dataSet.TrackGenres);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling TrackGenres Table: {ex.Message}");
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
            try
            {
                if (SaveChanges())
                {
                    MessageBox.Show("Success");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Data:");
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveChanges())
                {
                    MessageBox.Show("Success. Now closing form.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nothing was saved. Try again or press cancel to exit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Data.");
                throw;
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Updating Artist info");
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


    }
}
