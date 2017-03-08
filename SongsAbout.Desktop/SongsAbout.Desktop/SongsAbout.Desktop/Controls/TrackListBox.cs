using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout;
using SongsAbout.Desktop.Entities;
using SongsAbout.Enums;
using SongsAbout;
using System.Collections;
using Size = System.Drawing.Size;
using System.Windows;

namespace SongsAbout.Controls
{
    [ListBindable(BindableSupport.Yes)]
    [DefaultBindingProperty("SelectedIndex")]
    [DefaultEvent("ItemAdded")]
    [DefaultProperty("Items")]
    [Docking(DockingBehavior.Ask)]
    [DesignerCategory("TableLayoutPanel")]
    public partial class TrackListBox : SControl, IExtenderProvider, IContainerControl
    {
        public TrackRowCollection Items
        {
            get { return _items; }
            set { _items = value; }
        }
        private System.Windows.Forms.Label lblTitle { get; set; }

        public event EventHandler<TrackRowAddedEventArgs> ItemAdded
        {
            add { this.Items.ItemAdded += value; }
            remove { this.Items.ItemAdded -= value; }
        }
        public override Size MinimumSize
        {
            get { return base.MinimumSize; }

            set
            {
                base.MinimumSize = value;
                foreach (var item in this.Items)
                {
                    item.MinimumSize = value;
                }
            }
        }
        public override Size MaximumSize
        {
            get { return base.MaximumSize; }

            set
            {
                base.MaximumSize = value;
                foreach (var item in this.Items)
                {
                    item.MaximumSize = value;
                }
            }
        }

        public event EventHandler RowClicked
        {
            add
            {
                foreach (var item in this.Items)
                {
                    item.Click += value;
                }

            }
            remove
            {
                foreach (var item in this.Items)
                {
                    item.Click -= value;
                }

            }
        }
        public event EventHandler<TrackRowAddedEventArgs> RowAdded
        {
            add { this.Items.ItemAdded += value; }
            remove { this.Items.ItemAdded -= value; }

        }
        public override DbEntityType DbEntityType
        {
            get { return DbEntityType.Track; }
        }

        public override DbEntity DbEntity
        {
            get { return this.SelectedItem.DbEntity; }
            set
            {
                if (value != null && value.DbEntityType == DbEntityType.Track)
                {
                    this.SelectedItem.DbEntity = value;
                }
                else
                    throw new DbException(value,
                        "DbEntity for TrackListBox and Track Row must be of type DbEntityType.Track");
            }
        }
        public override bool ImportEntity()
        {
            return ((IEntityControl)this.SelectedItem).ImportEntity();
        }

        public TrackRow SelectedItem { get; set; }

        new public int Width
        {
            get { return base.Width; }
            set
            {
                base.Width = value;
                this.Items.ForEach(a => a.Width = value);
            }
        }

        new public Size Size
        {
            get { return base.Size; }
            set
            {
                base.Size = value;
                if (this.Items != null)
                {
                    this.Items.ForEach(a => a.Width = value.Width);
                }
            }
        }
        public int SelectedIndex { get; set; }
        public override AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }

        public TrackListBox()
        {
            this.Items = new TrackRowCollection();

            InitializeComponent();
            this.ItemAdded += this.TrackListBox_ItemAdded;
            this.ControlAdded += Row_ControlAdded;
        }

        public TrackListBox(List<Track> tracks) : this()
        {
            ListBox a = new ListBox();

            foreach (Track track in tracks)
            {
                this.Items.Add(new TrackRow(track) { Dock = DockStyle.Fill });
            }
        }

        private void Row_Click(object sender, EventArgs e)
        {
            var row = sender as TrackRow;

            row.Selected = true;
            this.SelectedItem = row;
            this.SelectedIndex = this.Items.IndexOf(row);
            ((IContainerControl)this).ActivateControl(row);
        }

        private void TrackListBox_ItemAdded(object sender, TrackRowAddedEventArgs e)
        {
            var newRow = sender as TrackRow;
            newRow.Click += Row_Click;
            newRow.Dock = DockStyle.Fill;
            this.panel.Controls.Add(newRow);
            this.panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            OnControlAdded(new ControlEventArgs(newRow));
        }
        private void Row_ControlAdded(object sender, ControlEventArgs e)
        {
            if (this.lblTitle != null && !lblTitle.IsDisposed)
            {
                this.lblTitle.Dispose();
            }
        }
        public void Clear()
        {
            this.Items.Clear();
        }
        bool IExtenderProvider.CanExtend(object extendee)
        {
            return ((IExtenderProvider)panel).CanExtend(extendee);
        }

        [Bindable(BindableSupport.Yes)]
        public class TrackRowCollection : List<TrackRow>, IListSource
        {
            bool IListSource.ContainsListCollection
            {
                get { return this.Count > 0; }
            }

            public event EventHandler<TrackRowAddedEventArgs> ItemAdded;

            public TrackRowCollection()
            {
                this.ItemAdded += TrackRowList_Default_ItemAdded;
            }

            /// <summary>
            /// Adds a new item to the TrackRowCollection
            /// </summary>
            /// <param name="row"></param>
            new public void Add(TrackRow row)
            {
                this.ItemAdded.Invoke(row, new TrackRowAddedEventArgs(base.Count));
                base.Add(row);
            }

            private static void TrackRowList_Default_ItemAdded(object sender, TrackRowAddedEventArgs e)
            {
            }

            IList IListSource.GetList()
            {
                return (IList)this;
            }
        }


        public class TrackRowAddedEventArgs : EventArgs
        {
            [DefaultValue(0)]
            public int Index { get; private set; }

            public TrackRowAddedEventArgs()
            {

            }
            public TrackRowAddedEventArgs(int index)
            {
                this.Index = index;
            }
        }

    }
}
