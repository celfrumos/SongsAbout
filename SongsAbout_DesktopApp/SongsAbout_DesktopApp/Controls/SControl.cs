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
using SongsAbout.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Controls
{
    public abstract partial class SControl : UserControl, IEntityControl
    {

        new public static Color BackColor
        {
            get { return User.Default.BackColor; }
            set { User.Default.BackColor = value; }
        }

        new public static Color ForeColor
        {
            get { return User.Default.TextColor; }
            set { User.Default.TextColor = value; }
        }

        public abstract DbEntity DbEntity { get; set; }

        public abstract ISpotifyEntity SpotifyEntity { get; set; }

        public abstract SpotifyEntityType SpotifyEntityType { get; set; }

        public abstract DbEntityType DbEntityType { get; set; }

        public SControl()
        {
            InitializeComponent();
            base.BackColor = SControl.BackColor;
            base.ForeColor = SControl.ForeColor;
        }

        public abstract bool ImportEntity();
    }
}
