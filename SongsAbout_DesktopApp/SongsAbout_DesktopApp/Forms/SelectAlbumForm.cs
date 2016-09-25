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
    public partial class SelectAlbumForm : Form
    {
        Dictionary<string, Album> DictAlbums;
        private Artist _albumArtist;

        public Album SelectedAlbum { get; set; }

        public SelectAlbumForm()
        {
            InitializeComponent();
            LoadAlbums();
            this.DialogResult = DialogResult.None;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAlbums();
                SelectedAlbum = DictAlbums[lstBoxSelectAlbum.SelectedItem.ToString()];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnGetArtist_Click(object sender, EventArgs e)
        {
            SelectArtistForm selectArtist = new SelectArtistForm();
            selectArtist.ShowDialog();
            if (selectArtist.DialogResult == DialogResult.OK)
            {
                try
                {
                    _albumArtist = selectArtist.SelectedArtist;
                    FilterByArtist(ref _albumArtist);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Getting Artist.");
                }
            }

        }

        private void LoadAlbums()
        {
            lstBoxSelectAlbum.Items.Clear();
            try
            {
                DictAlbums = Loader.LoadAlbums();
                foreach (KeyValuePair<string, Album> al in DictAlbums)
                {
                    lstBoxSelectAlbum.Items.Add(al.Key);
                }

                if (lstBoxSelectAlbum.Items.Count > 0)
                {
                    lstBoxSelectAlbum.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Albums.");
            }
        }

        private void FilterByArtist(ref Artist albumArtist)
        {
            txtBoxSelectedArtist.Text = _albumArtist.a_name;
        }

        private void btnNewAlbum_Click(object sender, EventArgs e)
        {
            AddAlbumForm addAlbum = new AddAlbumForm();
            addAlbum.ShowDialog();
            if (addAlbum.DialogResult == DialogResult.OK)
            {
                // LoadAlbums();
                lstBoxSelectAlbum.Items.Add(addAlbum.NewAlbum.al_title);
                lstBoxSelectAlbum.SelectedIndex = lstBoxSelectAlbum.Items.Count - 1;
            }
        }

    }
}
