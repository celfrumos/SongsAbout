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
using System.IO;


namespace SongsAbout_DesktopApp.Forms
{
    public partial class MyArtistsForm : Form
    {
        public MyArtistsForm()
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

        private Image convertImageFromBytes(ref byte[] picFile)
        {
            if (picFile != null)
            {
                using (var ms = new MemoryStream(picFile))
                {
                    return Image.FromStream(ms);
                }
            }
            else
            {
                throw new Exception();
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
            pBoxArtist.SizeMode = PictureBoxSizeMode.Zoom;
            Image aPicImage;
            try
            {
                byte[] aPicBytes = aRow.a_profile_pic;
                aPicImage = convertImageFromBytes(ref aPicBytes);
                pBoxArtist.Image = aPicImage;
            }
            catch (Exception)
            {
                pBoxArtist.Image = Properties.Resources.MusicNote;
            }
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
            FormatLabel(ref lblArtist, ref artistName, ref artistId);

            // 
            // gBox 
            // 
            GroupBox gBox = new GroupBox();
            gBox.Controls.Add(pBoxArtist);
            gBox.Controls.Add(lblArtist);
            gBox.Name = "grpBox" + artistName;
            gBox.Size = new System.Drawing.Size(83, 106);
            //   gBox.TabIndex = 3; 
            gBox.TabStop = false;
            return gBox;
        }

        private void FormatLabel(ref Label lblArtist, ref string artistName, ref int artistId)
        {
            lblArtist.Text = artistName;
            lblArtist.AutoSize = false;
            //  lblArtist.Location = new System.Drawing.Point(17, 85);
            lblArtist.Tag = artistId;
            lblArtist.BorderStyle = BorderStyle.FixedSingle;
            lblArtist.BackColor = Color.Aquamarine;
            lblArtist.Name = "lbl" + artistName;
            lblArtist.BackColor = System.Drawing.Color.LightSkyBlue;
            lblArtist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            lblArtist.Location = new System.Drawing.Point(0, 81);
            lblArtist.Size = new System.Drawing.Size(83, 25);
            lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
       
            lblArtist.Click += button_Click;   //  set any method 
            lblArtist.Enter += button_Enter;   //  
            lblArtist.Leave += button_Leave;
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
