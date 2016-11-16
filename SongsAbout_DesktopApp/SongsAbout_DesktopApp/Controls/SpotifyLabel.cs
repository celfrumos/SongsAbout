using System;
using System.ComponentModel;
using System.Drawing;
using SpotifyAPI.Web.Models;
using SongsAbout.Properties;
using System.Windows.Forms;

namespace SongsAbout.Controls
{

    public partial class SpotifyLabel : Label, IEntityControl
    {
        public SpotifyLabel()
        {
            InitializeComponent();
        }
        public string Level { get; set; }

        public SpotifyLabel(string text = "Not Set", string level = "Not Set", object tag = null)
        {
            this.Level = level;
            this.Text = text;
            this.Tag = text;
        }
        
        public SpotifyLabel(string text, EventHandler clickEvent) : this(text)
        {
            this.Click += clickEvent;
        }

        public SpotifyLabel(string text, string level, EventHandler clickEvent) : this(text, level)
        {
            this.Click += clickEvent;
        }

        public Label AsLabel()
        {
            return this;
        }
    
    }
}
