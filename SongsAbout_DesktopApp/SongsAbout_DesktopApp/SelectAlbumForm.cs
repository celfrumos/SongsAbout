﻿using System;
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
        Dictionary<string, Artist> DictArtists;
        Dictionary<string, Album> DictAlbums;
        private Artist _albumArtist { get; set; }

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

            }
            catch (Exception)
            {
                this.Close();
                this.DialogResult = DialogResult.Abort;
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
                    FilterByArtist(_albumArtist);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Getting Artist.");
                }
            }

        }

        private void LoadAlbums()
        {
            Loader loader = new Loader();
            DictAlbums = loader.LoadAlbums();

            foreach (KeyValuePair<string, Album> album in DictAlbums)
            {
                lstBoxSelectAlbum.Items.Add(album.Key);
            }
            if (lstBoxSelectAlbum.Items.Count > 0)
            {
                lstBoxSelectAlbum.SelectedIndex = 0;
            }
        }

        private void FilterByArtist(Artist albumArtist)
        {
            txtBoxSelectedArtist.Text = _albumArtist.Name;
        }

        private void btnNewAlbum_Click(object sender, EventArgs e)
        {
            AddAlbumForm addAlbum = new AddAlbumForm();
            addAlbum.ShowDialog();
            if (addAlbum.DialogResult == DialogResult.OK)
            {
                LoadAlbums();
            }
        }
    }
}
