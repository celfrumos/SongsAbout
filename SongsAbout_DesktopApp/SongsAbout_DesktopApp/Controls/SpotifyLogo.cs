using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SongsAbout.Properties;
public enum LogoColor { Green, White, Black }
namespace SongsAbout.Controls
{

    public class SpotifyLogo : SPicturePox
    {
        private LogoColor _logoColor;
        public LogoColor LogoColor
        {
            get { return _logoColor; }
            set
            {
                _logoColor = value;
                switch (value)
                {
                    case LogoColor.Green:
                        this.Image = Resources.Spotify_Icon_Green;
                        break;
                    case LogoColor.White:
                        this.Image = Resources.Spotify_Icon_White;
                        break;
                    case LogoColor.Black:
                        this.Image = Resources.Spotify_Icon_Black;
                        break;
                    default:
                        this.Image = Resources.Spotify_Icon_Green;
                        break;
                }
            }
        }

        public SpotifyLogo()
        {
            InitializeComponent();
        }

        new private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // SpotifyLogo
            // 
            this.Image = global::SongsAbout.Properties.Resources.Spotify_Icon_Green;
            this.InitialImage = global::SongsAbout.Properties.Resources.Spotify_Icon_Green;
            this.Size = new System.Drawing.Size(21, 21);
            this.MinimumSize = new System.Drawing.Size(21, 21);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
