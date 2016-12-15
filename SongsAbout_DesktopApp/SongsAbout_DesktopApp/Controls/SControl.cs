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
    public partial class SControl : UserControl, IEntityControl
    {

        new public Color BackColor
        {
            get { return User.Default.BackColor; }
            set { User.Default.BackColor = value; }
        }

        new virtual public Color ForeColor
        {
            get { return User.Default.TextColor; }
            set
            {
                User.Default.TextColor = value;
                base.BackColor = value;
            }
        }

        public virtual DbEntity DbEntity { get; set; }

        public virtual ISpotifyEntity SpotifyEntity { get; set; }

        public virtual SpotifyEntityType SpotifyEntityType { get; set; }

        public virtual DbEntityType DbEntityType { get; set; }

        public SControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Imports the Control's Entity to the database. If this isn't overridden, it'll throw an exception
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool ImportEntity() { throw new NotImplementedException(); }
    }
}
