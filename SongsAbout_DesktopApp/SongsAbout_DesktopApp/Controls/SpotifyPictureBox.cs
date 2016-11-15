using System;
using System.Collections.Generic;
using System.Drawing;
using SongsAbout_DesktopApp.Classes;
using SongsAbout_DesktopApp.Properties;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace SongsAbout_DesktopApp.Controls
{
    public partial class SpotifyPictureBox : PictureBox, ISpotifyControl, ISpotifyPictureBox
    {
        private const string _defName = "Not Set";
        private const string _defLevel = "Not Set";
        private static Point _defLocation = new Point(0, 2);
        private static Size _defSize = new Size(83, 80);
        private static PictureBoxSizeMode _defSizeMode = PictureBoxSizeMode.Zoom;
        private static bool _defAutoSize = true;

        new public string Name
        {
            get { return this.pictureBox.Name; }
            set { this.pictureBox.Name = value; }
        }
         

        private EventHandler ClickEvent { set { this.Click += value; } }

        public string Level { get; set; }

        public SpotifyPictureBox(string name = _defName, string level = _defLevel)
        {
            InitializeComponent();
            this.Level = level;
            this.Name = "pBoxArtist" + name;
            this.Tag = name;
            this.Location = _defLocation;
            this.Size = _defSize;
            this.pictureBox.SizeMode = _defSizeMode;
            this.TabStop = false;
            if (name == _defName || level == _defLevel)
            {
                this.Image = Resources.MusicNote;
            }
        }
        public SpotifyPictureBox(EventHandler clickEvent, string name = _defName, string level = _defLevel) : this(name, level)
        {
            this.ClickEvent = clickEvent;
        }

        public SpotifyPictureBox(Point location, Size size, PictureBoxSizeMode sizeMode, bool tabStop = false) : this()
        {
            this.Location = location;
            this.Size = size;
            this.pictureBox.SizeMode = sizeMode;
            this.TabStop = tabStop;

            // this.Click += SpotifyControlEventHandlers.Default_Click;
            //this.Enter += SpotifyControlEventHandlers.Enter;
            //this.Leave += SpotifyControlEventHandlers.Leave;
            // this.MouseHover += SpotifyControlEventHandlers.Hover;
        }

        public SpotifyPictureBox(FullAlbum album, EventHandler clickEvent) : this(clickEvent, album.Name, "Album")
        {
            SetImage(album.Images);
        }
        public SpotifyPictureBox(FullArtist artist, EventHandler clickEvent) : this(clickEvent, artist.Name, "Artist")
        {
            SetImage(artist.Images);
        }
        public SpotifyPictureBox(FullPlaylist playlist, EventHandler clickEvent) : this(clickEvent, playlist.Name, "Playlist")
        {
            SetImage(playlist.Images);
        }
        public PictureBox AsPictureBox()
        {
            return this.pictureBox;
        }
        public SpotifyPictureBox(SimplePlaylist playlist, EventHandler clickEvent) : this(clickEvent, playlist.Name, "Playlist")
        {
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

    }
}
