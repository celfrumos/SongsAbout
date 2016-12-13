using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SongsAbout.Entities;
using SongsAbout.Enums;

namespace SongsAbout.Controls
{
    public partial class TrackRow : SongsAbout.Controls.SControl
    {
        public Track Track
        {
            get { return (Track)this.DbEntity; }
            set
            {
                this.Artist = value.Artist;
                this.DbEntity = value;
            }
        }
        public Artist Artist
        {
            get { return (Artist)this.lblsArtist.DbEntity; }
            set
            {
                this.lblsArtist.DbEntity = value;
                this.lblsArtist.Text = value.Name;
            }
        }
        public Album Album
        {
            get { return (Album)this.lblsAlbum.DbEntity; }
            set
            {
                this.lblsAlbum.DbEntity = value;
                this.lblsAlbum.Text = value.Name;
            }
        }
        public string ArtistName
        {
            get { return this.lblsArtist.Text; }

        }
        public string TrackName
        {
            get { return this.lblsName.Text; }
            set { this.lblsName.Text = value; }
        }
        public TrackRow()
        {
            InitializeComponent();
        }
        public TrackRow(Track track) : this()
        {

        }

        public override DbEntity DbEntity
        {
            get; set;
        }

        public override DbEntityType DbEntityType
        {
            get; set;
        }

        public override ISpotifyEntity SpotifyEntity
        {
            get; set;
        }

        public override SpotifyEntityType SpotifyEntityType
        {
            get; set;
        }

        public override bool ImportEntity()
        {
            throw new NotImplementedException();
        }

        private void TrackRow_Load(object sender, EventArgs e)
        {

        }
    }
}
