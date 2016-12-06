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

namespace SongsAbout.Controls
{
    public partial class EntityDisplay : UserControl
    {
        public virtual SPicturePox Image { get; set; }
        public virtual string Name
        {
            get { return this.spotifyLabel1.Text; }
            set { this.spotifyLabel1.Text = value; }
        }

        public EntityDisplay()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
