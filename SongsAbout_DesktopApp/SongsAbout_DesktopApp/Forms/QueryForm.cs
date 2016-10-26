using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Linq;
using System.Linq.Expressions;
using SongsAbout_DesktopApp.Classes.Entities;

using SongsAbout_DesktopApp.Classes;

namespace SongsAbout_DesktopApp.Forms
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        private async void QueryForm_Load(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() => FillTables());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void FillTables()
        {
            // TODO: This line of code loads data into the 'dataSet.AlbumGenres' table. You can move, or remove it, as needed.
            this.albumGenresTableAdapter.Fill(this.dataSet.AlbumGenres);
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
