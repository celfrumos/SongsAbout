using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpotifyAPI;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SongsAbout_DesktopApp.Properties;
using System.Windows.Forms;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp.Classes
{

    class SpotifyPanel : Panel
    {
        public SpotifyPanel(string name)
        {
            this.Name = "grpBox" + name;
            this.Tag = name;
            this.Controls.Add(new SpotifyLabel(ref name));
            this.Size = new Size(83, 106);
            this.TabStop = false;

            this.Click += button_Click;
            this.Enter += button_Enter;
            this.Leave += button_Leave;
        }

        public SpotifyPanel(ref FullArtist artist) : this(artist.Name)
        {
            this.Controls.Add(new SpotifyPictureBox(ref artist));
        }

        public SpotifyPanel(ref FullTrack track) : this(track.Name) { }

        public SpotifyPanel(ref FullAlbum artist) : this(artist.Name)
        {
            this.Controls.Add(new SpotifyPictureBox(ref artist));
        }
        public SpotifyPanel(ref FullPlaylist playlist) : this(playlist.Name)
        {
            this.Controls.Add(new SpotifyPictureBox(ref playlist));
        }

        public SpotifyPanel(ref SimplePlaylist p) : this(p.Name)
        {
            FullPlaylist playlist = UserSpotify.WebAPI.GetPlaylist(User.Default.UserId, p.Id);
            this.Controls.Add(new SpotifyPictureBox(ref playlist));
        }

        protected void button_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void button_Enter(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }

    class SpotifyLabel : Label
    {
        public SpotifyLabel()
        {
            this.AutoSize = false;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = User.Default.BackColor;
            this.ForeColor = User.Default.TextColor;
            this.Location = new Point(0, 81);
            this.Size = new Size(83, 25);
            this.TextAlign = ContentAlignment.MiddleCenter;

        }

        public SpotifyLabel(ref string name) : this()
        {
            this.Text = name;
            this.Tag = name;
        }

        public SpotifyLabel(ref string name, string level) : this(ref name)
        {
        }
    }
    class SpotifyPictureBox : PictureBox
    {
        public SpotifyPictureBox(string name)
        {
            this.Name = "pBoxArtist" + name;
            this.Tag = name;
            this.Location = new Point(0, 2);
            this.Size = new Size(83, 80);
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.TabStop = false;

        }

        public SpotifyPictureBox(ref FullAlbum album) : this(album.Name)
        {
            SetImage(album.Images);
        }
        public SpotifyPictureBox(ref FullArtist artist) : this(artist.Name)
        {
            SetImage(artist.Images);
        }
        public SpotifyPictureBox(ref FullPlaylist playlist) : this(playlist.Name)
        {
            SetImage(playlist.Images);
        }

        private void SetImage(List<SpotifyAPI.Web.Models.Image> images)
        {
            try
            {
                if (images.Count > 0)
                {
                    this.Image = Importer.ImportSpotifyImage(images[0]);
                }
                else
                {
                    this.Image = Properties.Resources.MusicNote;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
