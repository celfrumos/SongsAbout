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
using System.Collections;
using System.Windows;

namespace SongsAbout.Controls
{
    [ListBindable(BindableSupport.Yes)]
    [DefaultBindingProperty("SelectedValue")]
    [DefaultEvent("ItemAdded")]
    [DefaultProperty("Items")]
    public partial class TrackListBox : SControl, IExtenderProvider, IContainerControl
    {
        public event EventHandler<TrackRowAddedEventArgs> ItemAdded
        {
            add { this.Items.ItemAdded += value; }
            remove { this.Items.ItemAdded -= value; }
        }

        public TrackListBox()
        {
            InitializeComponent();
            this.Items.ItemAdded += this.newItemAdded;
        }

        private TrackRowCollection _items;
        public TrackRowCollection Items
        {
            get { return _items; }
            set { _items = value; }
        }
        new public int Width
        {
            get { return base.Width; }
            set
            {
                base.Width = value;
                this.Items.ForEach(a => a.Width = value);
            }
        }

        public override AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }
        private void resizeRows(object sender, EventArgs e)
        {
            this.lblTitle.Text = sender.GetType().ToString();
        }

        public TrackListBox(List<Track> tracks)
        {
            this.Resize += resizeRows;
            ListBox a = new ListBox();

            foreach (Track track in tracks)
            {
                this.Items.Add(new TrackRow(track));
            }
        }

        private void newItemAdded(object sender, TrackRowAddedEventArgs e)
        {
            var newRow = sender as TrackRow;
            newRow.Width = this.flowLayoutPanel.Width;
            this.flowLayoutPanel.Controls.Add(newRow);
            OnControlAdded(new ControlEventArgs(newRow));
        }
        private void rowControlAdded(object sender, ControlEventArgs e)
        {

        }
        public void Clear()
        {
            this.Items.Clear();
        }
        public bool CanExtend(object extendee)
        {
            return ((IExtenderProvider)flowLayoutPanel).CanExtend(extendee);
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
            /// Adds a new item to the TrackRowList
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
