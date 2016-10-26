﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Forms;
using SongsAbout_DesktopApp.Classes;

using SongsAbout_DesktopApp.Properties;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using Image = System.Drawing.Image;

namespace SongsAbout_DesktopApp.Forms
{
    public partial class MainForm : Form
    {
        //private SpotifyWebAPI _spotify;
        //private PrivateProfile _profile;
        //private List<FullTrack> _savedTracks;
        //private List<SimplePlaylist> _playlists;
        //private Image _profilePic;

        public MainForm()
        {
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string uri = "spotify:track:6C7RJEIUDqKkJRZVWdkfkH";
            //MakeRequest(uri).Wait();
            //GetResults();
        }

        private void GetResults()
        {
            string query = txtBoxQuery.Text;
            List<string> genres = new List<string>();
            for (int i = 0; i < lstBxGenres.SelectedItems.Count; i++)
            {
                genres.Add(lstBxGenres.SelectedItems[i].ToString());
            }
        }

        private void btnSavedLists_Click(object sender, EventArgs e)
        {
            ViewSpotifyForm myLists = new ViewSpotifyForm();
            myLists.ShowDialog();
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            try
            {
                var addAlbum = new AddAlbumForm();
                try
                {
                    addAlbum.ShowDialog();
                }
                catch (System.ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Something went wrong.");
                }
                if (addAlbum.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Successfully saved ", "Success!");
                }
                else {
                    MessageBox.Show("Something Happened");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.Message + ex.InnerException.Message, "Something went wrong.");
                }
                else
                {
                    MessageBox.Show(ex.Message, "Something went wrong.");

                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ArtistDictionary = artists.Load();
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            QueryForm queryForm = new QueryForm();
            try
            {
                queryForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong.");
            }
        }


        private void btnImportArtists_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Importing Artists from Spotify: " + ex.Message);
            }
        }

        private void btnImportSavedTracks_Click(object sender, EventArgs e)
        {
            try
            {
                Importer.ImportFollowedArtists();

                //  Importer.ImportSavedTracks();
                Console.WriteLine("Finished importing saved tracks");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Importing Artists from Spotify: {ex.Message}");
            }
        }
    }

}