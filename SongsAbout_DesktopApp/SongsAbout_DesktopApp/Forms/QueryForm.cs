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
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
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

        private void artistsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
