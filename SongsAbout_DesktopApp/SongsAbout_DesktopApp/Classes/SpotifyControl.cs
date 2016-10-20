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
    public class SpotifyControl : Control
    {

        public SpotifyControl()
        {
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

    public static class SpotifyControlEventHandlers
    {
        public static void Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void Enter(object sender, EventArgs e)
        {
            SpotifyLabel s = sender as SpotifyLabel;
            var a = s.Tag.ToString();
        }

        public static void Hover(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.Cursor = Cursors.Hand;
        }

        public static void Default_Click(object sender, EventArgs e)
        {
            //   throw new NotImplementedException();
        }
    }

    public class SpotifyPanel : Panel
    {
        //private Action<object, EventArgs> spotifyControl_Click;
        public EventHandler spotifyControl_Click
        {
            set { this.Click += value; }
        }

        public string Level { get; set; }

        public SpotifyPanel(string name = "Not set", string level = "Not set")
        {
            this.Size = new Size(83, 106);
            this.TabStop = false;

            this.Name = "pnl" + name;
            this.Tag = name;
            this.Level = level;
            this.MouseHover += SpotifyControlEventHandlers.Hover;
        }

        public SpotifyPanel(string name, string level, EventHandler clickEvent) : this(name, level)
        {
            this.Controls.Add(new SpotifyLabel(name, clickEvent));
        }

        public SpotifyPanel(ref FullTrack track, EventHandler clickEvent) : this(track.Name, "Track", clickEvent) { }

        public SpotifyPanel(ref FullArtist artist, EventHandler clickEvent) : this(artist.Name, "Artist", clickEvent)
        {
            this.Controls.Add(new SpotifyPictureBox(ref artist, ref clickEvent));
        }

        public SpotifyPanel(ref FullAlbum artist, EventHandler clickEvent) : this(artist.Name, "Artist", clickEvent)
        {
            this.Controls.Add(new SpotifyPictureBox(ref artist, ref clickEvent));
        }
        public SpotifyPanel(ref FullPlaylist playlist, EventHandler clickEvent) : this(playlist.Name, "Playlist", clickEvent)
        {
            this.Controls.Add(new SpotifyPictureBox(ref playlist, ref clickEvent));
        }

        public SpotifyPanel(ref SimplePlaylist playlist, EventHandler clickEvent) : this(playlist.Name, "Playlist", clickEvent)
        {
            this.Controls.Add(new SpotifyPictureBox(ref playlist, ref clickEvent));
        }

    }

    public class SpotifyLabel : Label
    {
        //     private static bool _defAutosize = false;
        //  private static BorderStyle _defBorderStyle = BorderStyle.None;
        private static Color _defBackColor = User.Default.BackColor;
        private static Font _defFont = User.Default.ParagraphFont;
        private static Color _defTextColor = User.Default.TextColor;
        private static Point _defLocation = new Point(0, 81);
        private static Size _defSize = new Size(83, 25);
        //  private static ContentAlignment _defAlignment = ContentAlignment.MiddleCenter;


        public string Level { get; set; }

        public SpotifyLabel(string name = "Not Set", string level = "Not Set")
            : this(_defFont, _defBackColor, _defTextColor, _defLocation, _defSize)
        {
            this.Text = name;
            this.Tag = name;
        }

        public SpotifyLabel(Font font, Color backColor, Color foreColor, Point location, Size size,
            ContentAlignment alignment = ContentAlignment.MiddleCenter, bool autoSize = false, BorderStyle style = BorderStyle.None)
        {
            this.AutoSize = autoSize;
            this.BorderStyle = style;
            this.BackColor = backColor;
            this.ForeColor = foreColor;
            this.Location = location;
            this.Size = size;
            this.TextAlign = alignment;

            // this.Click += SpotifyControlEventHandlers.Default_Click;
            // this.Enter += SpotifyControlEventHandlers.Enter;
            // this.Leave += SpotifyControlEventHandlers.Leave;
            this.MouseHover += SpotifyControlEventHandlers.Hover;
        }
        public SpotifyLabel(string name, EventHandler clickEvent) : this(name)
        {
            this.Click += clickEvent;
        }

        public SpotifyLabel(string name, string level, EventHandler clickEvent) : this(name, level)
        {
            this.Click += clickEvent;
        }

        //internal void AddEventHandler(Action<object, EventArgs> spotifyControl_Click)
        //{
        //    this.Click += new EventHandler(spotifyControl_Click);

        //}
    }

    public class SpotifyPictureBox : PictureBox
    {
        private static string _defName = "Not Set";
        private static string _defLevel = "Not Set";
        private static Point _defLocation = new Point(0, 2);
        private static Size _defSize = new Size(83, 80);
        private static PictureBoxSizeMode _defSizeMode = PictureBoxSizeMode.Zoom;
        private static bool _defAutoSize = true;

        private EventHandler clickEvent { set { this.Click += value; } }

        public string Level { get; set; }

        public SpotifyPictureBox() : this(_defName, _defLevel)
        {
            this.Image = Resources.MusicNote;
        }

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

        public SpotifyPictureBox(ref FullAlbum album, ref EventHandler clickEvent) : this(album.Name, "Album")
        {
            SetImage(album.Images);
        }
        public SpotifyPictureBox(ref FullArtist artist, ref EventHandler clickEvent) : this(artist.Name, "Artist")
        {
            SetImage(artist.Images);
        }
        public SpotifyPictureBox(ref FullPlaylist playlist, ref EventHandler clickEvent) : this(playlist.Name, "Playlist")
        {
            SetImage(playlist.Images);
        }

        public SpotifyPictureBox(ref SimplePlaylist playlist, ref EventHandler clickEvent)
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
    }

}
