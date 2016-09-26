using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;


namespace SongsAbout_DesktopApp.Forms
{
    public partial class MyListsForm : Form
    {
        public MyListsForm()
        {
            InitializeComponent();
            LoadTracks();
        }

        private void LoadTracks()
        {
            this.albumsTableAdapter.Fill(this.dataSet.Albums);
            listView.Columns.Add("Album Art");
            foreach (var alRow in dataSet.Albums)
            {
                
                ListViewGroup group = new ListViewGroup();
                foreach (var trackRow in alRow.GetTracksRows())
                {
                    group.Items.Add(trackRow.track_name);
                }
                listView.Groups.Add(group);
            }
        }


    }
}
