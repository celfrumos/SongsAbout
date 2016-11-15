using System;
using System.ComponentModel;
using System.Drawing;
using SpotifyAPI.Web.Models;
using SongsAbout_DesktopApp.Properties;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp.Controls
{

    public partial class SpotifyLabel : Label, ISpotifyControl
    {
        public SpotifyLabel()
        {
            InitializeComponent();
        }
        private static Color _defBackColor = User.Default.BackColor;
        private static Font _defFont = User.Default.ParagraphFont;
        private static Color _defTextColor = User.Default.TextColor;
        private static Point _defLocation = new Point(0, 81);
        private static Size _defSize = new Size(83, 25);

        public string Level { get; set; }

        public SpotifyLabel(string name = "Not Set", string level = "Not Set")
            : this(_defFont, _defBackColor, _defTextColor, _defLocation, _defSize)
        {
            this.Level = level;
            this.Text = name;
            this.Tag = name;
        }

        public SpotifyLabel(object tag = null, string text = "Not Set", string level = "Not Set")
            : this(_defFont, _defBackColor, _defTextColor, _defLocation, _defSize)
        {
            this.Level = level;
            this.Text = text;
            this.Tag = tag;
        }

        public SpotifyLabel(BasicModel spotifyEntity, string name = "Not Set", string level = "Not Set")
        : this(_defFont, _defBackColor, _defTextColor, _defLocation, _defSize)
        {
            this.Text = name;
            this.Level = level;
            this.Tag = spotifyEntity;
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
            //   this.TextAlign = alignment;

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

        public Label AsLabel()
        {
            return this.Label;
        }
        new internal class ConcreteClassProvider : TypeDescriptionProvider
        {
            public ConcreteClassProvider() : base(TypeDescriptor.GetProvider(typeof(UserControl)))
            {
            }
        }

    }
}
