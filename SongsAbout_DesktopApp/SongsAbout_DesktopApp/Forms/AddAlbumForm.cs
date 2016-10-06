﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SongsAbout_DesktopApp.Classes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp
{
    public partial class AddAlbumForm : Form
    {
        bool isNewArtist = false;

        private Album _newAlbum = new Album();//{ get; set; }
        
        public AddAlbumForm(out Album newAlbum) //: this(ref cBoxAlbum)
        {
            InitializeComponent();
            newAlbum = _newAlbum;
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
                        string newArtistId = cBoxMainArtist.SelectedValue.ToString();
                        _newAlbum.al_title = txtBoxTitle.Text;
                        _newAlbum.al_year = txtBoxYear.Text;
                        _newAlbum.artist_id = int.Parse(newArtistId);

                        _newAlbum.Save();
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
                    MessageBox.Show("Please enter a title for the New album.");
                }

            }
        }

        private void btnNewArtist_Click(object sender, EventArgs e)
        {
            AddArtistForm artistForm = new AddArtistForm();
            artistForm.ShowDialog();
            if (artistForm.DialogResult == DialogResult.OK)
            {
                this.artistsTableAdapter.Fill(this.dataSet.Artists);
            }
        }

        private void AddAlbumForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Artists' table. You can move, or remove it, as needed.
            this.artistsTableAdapter.Fill(this.dataSet.Artists);

        }
    }
}
