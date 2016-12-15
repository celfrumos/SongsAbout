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
using Size = System.Drawing.Size;
using System.Windows;

namespace SongsAbout.Controls
{
    [ListBindable(BindableSupport.Yes)]
    [DefaultBindingProperty("SelectedItem")]
    [DefaultEvent("ItemAdded")]
    [DefaultProperty("Items")]
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
        public event EventHandler RowClick;

        public TrackRow SelectedItem
        {
            get; set;
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
            InitializeComponent();
            this.Items.ItemAdded += this.newItemAdded;
            this.ControlAdded += Row_ControlAdded;            
        }

        public TrackListBox(List<Track> tracks) : this()
        {
            ListBox a = new ListBox();

            foreach (Track track in tracks)
            {
                this.Items.Add(new TrackRow(track));
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

        private void newItemAdded(object sender, TrackRowAddedEventArgs e)
        {
            var newRow = sender as TrackRow;
            newRow.Width = this.flowLayoutPanel.Width;
            newRow.Click += Row_Click;
            this.flowLayoutPanel.Controls.Add(newRow);
            OnControlAdded(new ControlEventArgs(newRow));
        }
        private void Row_ControlAdded(object sender, ControlEventArgs e)
        {
            if (this.lblTitle != null)
            {
                this.lblTitle.Dispose();
            }
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
