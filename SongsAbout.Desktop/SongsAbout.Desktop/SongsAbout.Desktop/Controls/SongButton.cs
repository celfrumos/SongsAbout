using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SongsAbout.Desktop.Properties;
using SongsAbout;
using SongsAbout.Entities;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;
using SpotifyAPI.Local.Enums;


namespace SongsAbout.Controls
{
    public enum SongButtonType
    {
        Play, Pause, Stop, SkipForward, SkipBack, FastForward, FastBackward
    }


    public partial class SongButton : Button, IButtonControl
    {
        private SongButtonType _songButtonType;

        public SongButton()
        {
            _songButtonType = SongButtonType.Play;
            InitializeComponent();
            this.Text = "";
        }
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = ""; }
        }

        public SongButtonType SongButtonType
        {
            get { return _songButtonType; }
            set
            {
                _songButtonType = value;
                switch (value)
                {
                    //case SongButtonType.Play:
                    //    this.BackgroundImage = ButtonImages.Play;
                    //    break;
                    //case SongButtonType.Pause:
                    //    this.BackgroundImage = ButtonImages.Pause;
                    //    break;
                    //case SongButtonType.Stop:
                    //    this.BackgroundImage = ButtonImages.Stop;
                    //    break;
                    //case SongButtonType.SkipForward:
                    //    this.BackgroundImage = ButtonImages.SkipForward;
                    //    break;
                    //case SongButtonType.SkipBack:
                    //    this.BackgroundImage = ButtonImages.SkipBack;
                    //    break;
                    //case SongButtonType.FastForward:
                    //    this.BackgroundImage = ButtonImages.FastForward;
                    //    break;
                    //case SongButtonType.FastBackward:
                    //    this.BackgroundImage = ButtonImages.FastBackward;
                    //    break;
                }
            }
        }
/// <summary>
        /// Gets or sets the value returned to the parent form when the button is clicked.
        /// Returns:
        ///     One of the System.Windows.Forms.DialogResult values.
        /// </summary>
        public override DialogResult DialogResult { get; set; }


    }

}
