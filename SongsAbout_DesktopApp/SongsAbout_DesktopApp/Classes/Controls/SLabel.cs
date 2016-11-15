using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using SpotifyAPI;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SongsAbout_DesktopApp.Properties;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp.Controls
{
    public partial class SLabel : UserControl
    {
        public SLabel()
        {
            InitializeComponent();
        }
        private static Color _defBackColor = User.Default.BackColor;
        private static Font _defFont = User.Default.ParagraphFont;
        private static Color _defTextColor = User.Default.TextColor;
        private static Point _defLocation = new Point(0, 81);
        private static Size _defSize = new Size(83, 25);

        public override string Level()
        {
            return _level;
        }

        public SpotifyLabel(string name = "Not Set", string level = "Not Set") 
            : this(_defFont, _defBackColor, _defTextColor, _defLocation, _defSize)
        {
            this._level = level;
            this.Text = name;
            this.Tag = name;
        }


        public SpotifyLabel(BasicModel spotifyEntity, string name = "Not Set", string level = "Not Set")
        : this(_defFont, _defBackColor, _defTextColor, _defLocation, _defSize)
        {
            this.Text = name;
            this._level = level;
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

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
    internal class ConcreteClassProvider : TypeDescriptionProvider
        {
            public ConcreteClassProvider() : base(TypeDescriptor.GetProvider(typeof(UserControl)))
            {
            }
        }
   
    }
}
