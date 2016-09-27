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
            this.artistsTableAdapter.Fill(this.dataSet.Artists);
            for (int i = 0; i < dataSet.Artists.Count; i++)
            {
                DataSet.ArtistsRow aRow = dataSet.Artists[i];
                GroupBox gBox = NewArtistBox(ref aRow);
                flowLayoutPanel.Controls.Add(gBox);
            }
        }

        private GroupBox NewArtistBox(ref DataSet.ArtistsRow aRow)
        {
            int artistId = aRow.artist_id;
            string artistName = aRow.a_name;
            //  
            // pBoxArtist 
            //  
            PictureBox pBoxArtist = new PictureBox();
            //      pBoxArtist.Image = aRow.a_profile_pic; 
            pBoxArtist.Location = new System.Drawing.Point(0, 2);
            pBoxArtist.Name = "pBoxArtist" + artistName;
            pBoxArtist.Size = new System.Drawing.Size(83, 80);
            // pBoxArtist.TabIndex = 1; 
            pBoxArtist.TabStop = false;
            pBoxArtist.Tag = artistId;

            //  
            // lblArtist 
            //  
            Label lblArtist = new Label();
            lblArtist.Text = artistName;
            lblArtist.AutoSize = true;
            lblArtist.Location = new System.Drawing.Point(17, 85);
            lblArtist.Tag = artistId;
            lblArtist.Name = "lbl" + artistName;
            // lblArtist.Size = new System.Drawing.Size(46, 17); 
            // lblArtist.TabIndex = 0; 
            lblArtist.Click += button_Click;   //  set any method 
            lblArtist.Enter += button_Enter;   //  
            lblArtist.Leave += button_Leave;

            // 
            // gBox 
            // 
            GroupBox gBox = new GroupBox();

            gBox.Controls.Add(pBoxArtist);
            gBox.Controls.Add(lblArtist);
            gBox.Name = "grpBox1";
            gBox.Size = new System.Drawing.Size(83, 106);
            //   gBox.TabIndex = 3; 
            gBox.TabStop = false;
            return gBox;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Label lblArtist = sender as Label;
        }

        private void button_Enter(object sender, EventArgs e)
        {

        }
        private void button_Leave(object sender, EventArgs e)
        {

        }

    }
}
