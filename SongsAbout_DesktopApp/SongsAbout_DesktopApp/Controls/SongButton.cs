using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SongsAbout.Properties;
using SongsAbout.Classes;
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

    public partial class SongButton : PictureBox, IButtonControl, ISpotifyEntityControl
    {
        private SongButtonType _songButtonType;
        public SongButton()
        {
            _songButtonType = SongButtonType.Play;
            InitializeComponent();
        }

        new public Image Image
        {
            get { return base.Image; }
            set
            {
                Image i = value;
                base.Image = value;
            }
        }
        public SongButtonType SongButtonType
        {
            get { return _songButtonType; }
            set
            {
                _songButtonType = value;
                switch (value)
                {
                    case SongButtonType.Play:
                        this.Image = ButtonImages.Play;
                        break;
                    case SongButtonType.Pause:
                        this.Image = ButtonImages.Pause;
                        break;
                    case SongButtonType.Stop:
                        this.Image = ButtonImages.Stop;
                        break;
                    case SongButtonType.SkipForward:
                        this.Image = ButtonImages.SkipForward;
                        break;
                    case SongButtonType.SkipBack:
                        this.Image = ButtonImages.SkipBack;
                        break;
                    case SongButtonType.FastForward:
                        this.Image = ButtonImages.FastForward;
                        break;
                    case SongButtonType.FastBackward:
                        this.Image = ButtonImages.FastBackward;
                        break;
                }
            }
        }

        public SpotifyFullTrack Track { get; set; }

        public string EntityName
        {
            get { return this.SpotifyEntity.Name; }
        }

        public SpotifyIntegralEntity SpotifyEntity { get; set; }

        public SpotifyEntityType SpotifyEntityType { get; set; }

        /// <summary>
        /// Gets or sets the value returned to the parent form when the button is clicked.
        /// Returns:
        ///     One of the System.Windows.Forms.DialogResult values.
        /// </summary>
        public DialogResult DialogResult { get; set; }

        public void ImportEntity()
        {
            if (this.SpotifyEntity != null)
                Importer.ImportFromSpotify(this.SpotifyEntity);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }
        /// <summary>
        ///   Notifies a control that it is the default button so that its appearance and behavior
        /// </summary>
        /// <param name="value">true if the control should behave as a default button; otherwise false.</param>
        public void NotifyDefault(bool value)
        {
        }

        /// <summary>
        ///     Generates a System.Windows.Forms.Control.Click event for the control.
        /// </summary>        
        public void PerformClick()
        {
            this.InvokeOnClick(this, new EventArgs());

        }
    }

}
