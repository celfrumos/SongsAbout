using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp.Classes
{
    public partial class SpotifyPictureBox : PictureBox
    {
        public SpotifyPictureBox() : this(_defName, _defLevel)
        {
            InitializeComponent();
            this.Image = Resources.MusicNote;
        }
        private static string _defName = "Not Set";
        private static string _defLevel = "Not Set";
        private static Point _defLocation = new Point(0, 2);
        private static Size _defSize = new Size(83, 80);
        private static PictureBoxSizeMode _defSizeMode = PictureBoxSizeMode.Zoom;
        private static bool _defAutoSize = true;

        private EventHandler clickEvent { set { this.Click += value; } }

        public string Level { get; set; }
        
        public SpotifyPictureBox(string name = "Not Set", string level = "Not Set") : this(_defLocation, _defSize, _defSizeMode, _defAutoSize)
        {
            this.Level = level;
            this.Name = "pBoxArtist" + name;
            this.Tag = name;
            if (name == "Not Set" || level == "Not Set")
            {
                this.Image = Resources.MusicNote;
            }
        }

        public SpotifyPictureBox(Point location, Size size, PictureBoxSizeMode sizeMode, bool tabStop)
        {
            this.Location = location;
            this.Size = size;
            this.SizeMode = sizeMode;
            this.TabStop = tabStop;

            // this.Click += SpotifyControlEventHandlers.Default_Click;
            //this.Enter += SpotifyControlEventHandlers.Enter;
            //this.Leave += SpotifyControlEventHandlers.Leave;
            this.MouseHover += SpotifyControlEventHandlers.Hover;
        }

        public SpotifyPictureBox(FullAlbum album, EventHandler clickEvent) : this(album.Name, "Album")
        {
            SetImage(album.Images);
        }
        public SpotifyPictureBox(FullArtist artist, EventHandler clickEvent) : this(artist.Name, "Artist")
        {
            SetImage(artist.Images);
        }
        public SpotifyPictureBox(FullPlaylist playlist, EventHandler clickEvent) : this(playlist.Name, "Playlist")
        {
            SetImage(playlist.Images);
        }

        public SpotifyPictureBox(SimplePlaylist playlist, EventHandler clickEvent)
        {
            this.clickEvent = clickEvent;
        }

        private void SetImage(List<SpotifyAPI.Web.Models.Image> images)
        {
            try
            {
                if (images.Count > 0)
                {
                    Image i = Importer.ImportSpotifyImage(images[0]);
                    if (i != null)
                    {
                        this.Image = i;
                    }
                    else
                    {
                        this.Image = Resources.MusicNote;
                    }
                }
                else
                {
                    this.Image = Resources.MusicNote;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting image: {ex.Message}");
            }
            if (this.Image == null)
            {
                throw new Exception("Error Setting Image");
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
