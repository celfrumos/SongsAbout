using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;

using SongsAbout.Desktop.Properties;
using SongsAbout.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Controls
{
    public partial class SControl : UserControl, IEntityControl
    {
        public string EntityName
        {
            get
            {
                if (this.DbEntity != null)
                    return this.DbEntity.Name;

                else if (this.SpotifyEntity != null)
                    return this.SpotifyEntity.Name;
                else
                    return "Not Set";
            }
        }
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

        public virtual SpotifyIntegralEntity SpotifyEntity { get; set; }

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
