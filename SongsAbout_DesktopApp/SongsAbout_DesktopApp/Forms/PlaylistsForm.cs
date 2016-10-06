using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Classes;
using System.Threading.Tasks;
using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Properties;
using Image = System.Drawing.Image;
using Cursor = System.Windows.Forms.Cursor;

namespace SongsAbout_DesktopApp.Forms
{
    public partial class PlaylistsForm : Form
    {
        public PlaylistsForm()
        {
            InitializeComponent();
            LoadTracks();
        }

        private async void LoadTracks()
        {
            List<SimplePlaylist> playlists = UserSpotify.GetPlaylists();

            for (int i = 0; i < playlists.Count; i++)
            {
                FullPlaylist p = UserSpotify.WebAPI.GetPlaylist(User.Default.UserId, playlists[i].Id);
                string pName = p.Name;
                if (pName != null)
                {
                    try
                    {
                        GroupBox g = new GroupBox();
                        Label l = new Label();
                        await Task.Run(() => FormatLabel(ref l, ref pName));
                        //await Task.Run(() => NewGroupBox(ref p, ref g));
                        //   flowLayoutPanel1.Controls.Add(l);
                    //    listView1.Sorting = SortOrder.
                        listView1.Controls.Add(l);
                    }
                    catch (Exception ex)
                    {
                        string msg = $"Error fetching playlist: {ex.Message}";
                    }
                }
                else
                {
                    Console.WriteLine("Playist empty.");
                }
            }
        }

        private void NewGroupBox(ref FullPlaylist playlist, ref GroupBox gBox)
        {
            string playlistName = playlist.Name;
            if (playlistName != null)
            {
                //  
                // pBoxArtist 
                //  
                PictureBox pBoxPlaylist = new PictureBox();
                pBoxPlaylist.SizeMode = PictureBoxSizeMode.Zoom;
                Image aPicImage;
                try
                {
                    aPicImage = Importer.ImportSpotifyImage(playlist.Images[0]);
                    pBoxPlaylist.Image = aPicImage;
                }
                catch (Exception)
                {
                    pBoxPlaylist.Image = Properties.Resources.MusicNote;
                }
                pBoxPlaylist.Location = new System.Drawing.Point(0, 2);
                pBoxPlaylist.Name = "pBoxArtist" + playlistName;
                pBoxPlaylist.Size = new System.Drawing.Size(83, 80);
                // pBoxArtist.TabIndex = 1; 
                pBoxPlaylist.TabStop = false;
                pBoxPlaylist.Tag = playlistName;

                //  
                // lblArtist 
                //  
                Label lblPlaylist = new Label();
                FormatLabel(ref lblPlaylist, ref playlistName);
                lblPlaylist.MouseHover += label_Hover;
                // 
                // gBox 
                // 
                gBox.FlatStyle = FlatStyle.Popup;
                gBox.Controls.Add(pBoxPlaylist);
                gBox.Controls.Add(lblPlaylist);

                gBox.Name = "grpBox" + playlistName;
                gBox.Size = new System.Drawing.Size(83, 106);
                //   gBox.TabIndex = 3; 
                gBox.TabStop = false;
                gBox.Tag = playlistName;
                gBox.Click += gBox_Click;   //  set any method 
              //  gBox.AutoSize = true;
            }
        }


        private void label_Hover(object sender, EventArgs e)
        {
            Label l = sender as Label;

            try
            {
                l.Cursor = Cursors.Hand;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hover Error: {ex.Message}");
            }
            //throw new NotImplementedException();
        }

        private void FormatLabel(ref Label lblPlaylist, ref string playlistName)
        {
            lblPlaylist.Text = playlistName;
            lblPlaylist.AutoSize = true;
            lblPlaylist.Tag = playlistName;
            lblPlaylist.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPlaylist.BorderStyle = BorderStyle.None;
           // lblPlaylist.BackColor = Color.Aquamarine;
            lblPlaylist.Name = "lbl" + playlistName;
            lblPlaylist.BackColor = Color.Transparent;
            lblPlaylist.ForeColor = SystemColors.ActiveCaptionText;
            lblPlaylist.Location = new Point(0, 81);
            lblPlaylist.Size = new Size(83, 25);
            lblPlaylist.TextAlign = ContentAlignment.MiddleCenter;
            lblPlaylist.Dock = DockStyle.Bottom;
            lblPlaylist.MouseHover += label_Hover;
        }



        private void gBox_Click(object sender, EventArgs e)
        {

            throw new NotImplementedException();
        }

    }
}
