using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SongsAbout.Controls;

namespace SongsAbout.Forms
{
    public partial class AlbumDisplayForm : SongsAbout.Forms.SForm
    {
        public AlbumDisplayForm()
        {
            InitializeComponent();
            TrackListBox t = new TrackListBox();
        }
    }
}
