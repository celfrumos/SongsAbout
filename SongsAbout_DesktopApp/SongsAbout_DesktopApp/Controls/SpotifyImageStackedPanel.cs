using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SongsAbout.Controls
{
    public enum SPanelType
    {
        Image, Text, StackedImage
    }


    public partial class SpotifyImageStackedPanel : SongsAbout.Controls.SpotifyPanel
    {

        public SpotifyImageStackedPanel()
        {
            InitializeComponent();
            this.SPanelType = SPanelType.StackedImage;

        }


    }
}
