﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Linq;
using System.Linq.Expressions;
using SongsAbout.Entities;
using SongsAbout.Properties;
using SongsAbout.Classes;
using SongsAbout.DataSetTableAdapters;

namespace SongsAbout.Forms
{
    public partial class QueryForm : Form
    {
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

                this.tableAdapterMngr.UpdateAll(this.dataSet);
                //FillTables();
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

        private async void FillTables()
        {
            try
            {
                // TODO: This line of code loads data into the 'dataSet.Albums' table. You can move, or remove it, as needed.
                await Task.Run(() => this.albumsTableAdapter.Fill(this.dataSet.Albums));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Albums Table: {ex.Message}");
            }
            try
            {
                // TODO: This line of code loads data into the 'dataSet.Tracks' table. You can move, or remove it, as needed.
                await Task.Run(() => this.tracksTableAdapter.Fill(this.dataSet.Tracks));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Tracks Table: {ex.Message}");
            }
            try
            {
                // TODO: This line of code loads data into the 'dataSet.Genres' table. You can move, or remove it, as needed.
                await Task.Run(() => this.genresTableAdapter.Fill(this.dataSet.Genres));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Genres Table: {ex.Message}");
            }
            try
            {
                // TODO: This line of code loads data into the 'dataSet.TrackGenres' table. You can move, or remove it, as needed.
                await Task.Run(() => this.trackGenresTableAdapter.Fill(this.dataSet.TrackGenres));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling TrackGenres Table: {ex.Message}");
            }
            try
            {
                // TODO: This line of code loads data into the 'dataSet.AlbumGenres' table. You can move, or remove it, as needed.
                await Task.Run(() => this.albumGenresTableAdapter.Fill(this.dataSet.AlbumGenres));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling AlbumGenres Table: {ex.Message}");
            }
            try
            {
                // TODO: This line of code loads data into the 'dataSet.Lists' table. You can move, or remove it, as needed.
                await Task.Run(() => this.listsTableAdapter.Fill(this.dataSet.Lists));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Lists Table: {ex.Message}");
            }
            try
            {
                // TODO: This line of code loads data into the 'dataSet.TrackTags' table. You can move, or remove it, as needed.
                await Task.Run(() => this.trackTagsTableAdapter.Fill(this.dataSet.TrackTags));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling TrackTags Table: {ex.Message}");
            }
            try
            {
                // TODO: This line of code loads data into the 'dataSet.Tags' table. You can move, or remove it, as needed.
                await Task.Run(() => this.tagsTableAdapter.Fill(this.dataSet.Tags));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Filling Tags Table: {ex.Message}");
            }


        }

        private void FillArtists()
        {

            this.tableAdapterMngr.UpdateAll(this.dataSet);

            try
            {
                // TODO: This line of code loads data into the 'dataSet.Artists' table. You can move, or remove it, as needed.
                this.artistsTableAdapter.Fill(this.dataSet.Artists);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Filling Artists Table: {ex.Message}");
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
