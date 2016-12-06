using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsAbout.Controls;
using System.Windows.Forms;
using SongsAbout.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Controls
{
    public partial class AlbumDisplay : UserControl, IEntityControl
    {
        public virtual SPicturePox Image { get; set; }
        public virtual string Name
        {
            get { return this.lblArtist.Text; }
            set { this.lblArtist.Text = value; }
        }
        private DbEntity _dbEntity;
        public DbEntity DbEntity
        {
            get { return _dbEntity; }
            set
            {
                var a = (Album)value;
                this._dbEntity = a;
                this.lblName.DbEntity = a;
                a.AlbumTracks.ToList().ForEach(t =>
                {
                    this.listBox1.Items.Add(t.Track);
                });
            }
        }

        public ISpotifyEntity SpotifyEntity { get { return this.DbEntity.s } set; }

        public SpotifyEntityType SpotifyEntityType { get; set; }

        public DbEntityType DbEntityType { get; set; }

        public AlbumDisplay()
        {
            InitializeComponent();
        }
        public AlbumDisplay(Album album)
        {
            InitializeComponent();
            this.DbEntity = album;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public bool ImportEntity()
        {
            throw new NotImplementedException();
        }
    }
}
