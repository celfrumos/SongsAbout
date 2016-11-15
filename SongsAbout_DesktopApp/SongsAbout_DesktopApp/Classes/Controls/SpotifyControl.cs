using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp.Controls
{
    public partial class SpotifyControl : UserControl
    {
        protected string _level;
        public SpotifyControl()
        {
            InitializeComponent();
        }

        public virtual string Level()
        {
            return _level;
        }

        public override string Text
        {
            get { return base.Text; }

            set { base.Text = value; }
        }
    }
}
