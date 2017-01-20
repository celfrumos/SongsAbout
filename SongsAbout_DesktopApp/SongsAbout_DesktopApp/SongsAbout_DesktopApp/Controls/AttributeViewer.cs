using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout.Desktop.Properties;
using SongsAbout.Entities;
using SongsAbout.Enums;

using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;

namespace SongsAbout.Controls
{
    public partial class AttributeViewer : UserControl, IEntityControl
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
        private DbEntity _dbEntity;
        private DbEntityType _dbEntityType;
        public DbEntity DbEntity
        {
            get { return this._dbEntity; }
            set
            {
                this._dbEntity = value;

            }

        }

        public SpotifyEntityType SpotifyEntityType { get; set; }
        public DbEntityType DbEntityType
        {
            get { return this._dbEntityType; }
            set
            {
                this._dbEntityType = value;
                using (var db = new DataClassesContext())
                {
                    switch (value)
                    {
                        case DbEntityType.Artist:
                            foreach (Artist a in db.Artists)
                            {
                                this.Items.Add(new SPanel(a));
                            }
                            break;
                        case DbEntityType.Album:
                            foreach (var a in db.Albums)
                            {
                                this.Items.Add(new SPanel(a));
                            }
                            break;
                        case DbEntityType.Track:
                            foreach (var t in db.Tracks)
                            {
                                this.Items.Add(new SPanel(t));
                            }
                            break;
                        case DbEntityType.Tag:
                            foreach (var t in db.Tags)
                            {
                                this.Items.Add(new SPanel(t, SPanelType.Text));
                            }
                            break;
                        case DbEntityType.Playlist:
                            foreach (var l in db.Playlists)
                            {
                                //this.Items.Add(new SPanel(l.list_name, SPanelType.Text, SPanelSize.Small, null, l, DbEntityType.List));
                            }
                            break;
                        case DbEntityType.Genre:
                            foreach (var g in db.Genres)
                            {
                                this.Items.Add(g.Name);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public CheckedListBox.ObjectCollection Items { get { return this.ListBox.Items; } }


        CheckedListBox.CheckedItemCollection CheckedItems { get { return this.ListBox.CheckedItems; } }
        public string Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }
        }
        public AttributeViewer()
        {
            InitializeComponent();
            this.BackColor = User.Default.BackColor;
            this.ForeColor = User.Default.TextColor;
        }

        public AttributeViewer(DataClassesContext db)
        {

        }

        public AttributeViewer(DbEntityType dbEntityType) : this()
        {
            this.DbEntityType = dbEntityType;

        }

        public TextBox TextBox
        {
            get { return this.txtboxNewItem; }
            set { this.txtboxNewItem = value; }
        }
        public string TextBoxTitle
        {
            get { return this.lblTitleAddNew.Text; }
            set { this.lblTitleAddNew.Text = value; }
        }

        private void txtBxNewItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n')
            {
                this.Items.Add(txtboxNewItem.Text);
            }
        }
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                this.lblTitle.ForeColor = value;
                this.ListBox.ForeColor = value;
                this.lblTitle.ForeColor = value;
            }

        }
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                this.lblTitle.BackColor = value;
                this.ListBox.BackColor = value;
                this.lblTitle.BackColor = value;
            }
        }

        private SpotifyIntegralEntity _spotifyEntity;
        public SpotifyIntegralEntity SpotifyEntity
        {
            get { return this._spotifyEntity; }
            set { this._spotifyEntity = value; }
        }

        private void ListBox_Click(object sender, EventArgs e)
        {

        }

        public bool ImportEntity()
        {
            throw new NotImplementedException();
        }
    }
}
