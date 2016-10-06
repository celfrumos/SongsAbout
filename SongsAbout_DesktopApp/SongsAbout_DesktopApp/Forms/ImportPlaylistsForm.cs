using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Classes;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SongsAbout_DesktopApp.Properties;
using SongsAbout_DesktopApp.Forms;
using Image = System.Drawing.Image;

namespace SongsAbout_DesktopApp.Forms
{
    public partial class ImportPlaylistsForm : Form
    {
        public ImportPlaylistsForm()
        {
            InitializeComponent();
            LoadTracks();
        }

        private void LoadTracks()
        {
            //this.artistsTableAdapter.Fill(this.dataSet.Artists);
            List<SimplePlaylist> playlists = UserSpotify.GetPlaylists();
            //for (int i = 0; i < dataSet.Artists.Count; i++)
            //{
            //    DataSet.ArtistsRow aRow = dataSet.Artists[i];
            //    GroupBox gBox = NewArtistBox(ref aRow);
            //    flowLayoutPanel.Controls.Add(gBox);
            //}
            for (int i = 0; i < playlists.Count; i++)
            {
                FullPlaylist p = UserSpotify.WebAPI.GetPlaylist(User.Default.UserId, playlists[i].Id);
                GroupBox gb = NewGroupBox(ref p);
                flowLayoutPanel1.Controls.Add(gb);

            }

        }

        private GroupBox NewGroupBox(ref FullPlaylist playlist)
        {
            //int artistId = aRow.artist_id;
            string playlistName = playlist.Name;

            //  
            // pBoxArtist 
            //  
            PictureBox pBoxArtist = new PictureBox();
            pBoxArtist.SizeMode = PictureBoxSizeMode.Zoom;
            Image aPicImage;
            try
            {
                aPicImage = Importer.ImportSpotifyImage(playlist.Images[0]);
                pBoxArtist.Image = aPicImage;
            }
            catch (Exception)
            {
                pBoxArtist.Image = Properties.Resources.MusicNote;
            }
            pBoxArtist.Location = new System.Drawing.Point(0, 2);
            pBoxArtist.Name = "pBoxArtist" + playlistName;
            pBoxArtist.Size = new System.Drawing.Size(83, 80);
            // pBoxArtist.TabIndex = 1; 
            pBoxArtist.TabStop = false;
            pBoxArtist.Tag = playlistName;

            //  
            // lblArtist 
            //  
            Label lblArtist = new Label();
            FormatLabel(ref lblArtist, ref playlistName);

            // 
            // gBox 
            // 
            GroupBox gBox = new GroupBox();
            gBox.Controls.Add(pBoxArtist);
            gBox.Controls.Add(lblArtist);
            gBox.Name = "grpBox" + playlistName;
            gBox.Size = new System.Drawing.Size(83, 106);
            //   gBox.TabIndex = 3; 
            gBox.TabStop = false;
            gBox.Tag = playlistName;

            gBox.Click += button_Click;   //  set any method 
            gBox.Enter += button_Enter;   //  
            gBox.Leave += button_Leave;
            return gBox;

        }

        private void FormatLabel(ref Label lblArtist, ref string playlistName)
        {
            lblArtist.Text = playlistName;
            lblArtist.AutoSize = false;
            //  lblArtist.Location = new System.Drawing.Point(17, 85);
            lblArtist.Tag = playlistName;
            lblArtist.BorderStyle = BorderStyle.FixedSingle;
            lblArtist.BackColor = Color.Aquamarine;
            lblArtist.Name = "lbl" + playlistName;
            lblArtist.BackColor = System.Drawing.Color.LightSkyBlue;
            lblArtist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            lblArtist.Location = new System.Drawing.Point(0, 81);
            lblArtist.Size = new System.Drawing.Size(83, 25);
            lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        }

        private void button_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button_Enter(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
