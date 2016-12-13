using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout.Entities;

namespace SongsAbout.Controls
{
    public partial class TrackListBox : SControl
    {
        public TrackListBox()
        {
            InitializeComponent();
            
        }
        public TrackListBox(List<Track> tracks)
        {
            foreach (Track track in tracks)
            {
            }

        }
    }
}
