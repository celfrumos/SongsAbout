using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SongsAbout_DesktopApp
{
    public partial class AddArtistForm : Form
    {
        public Artist NewArtist { get; set; }

        public AddArtistForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBoxName.Text != "")
            {
                NewArtist.Name = txtBoxName.Text;
                NewArtist.Bio = txtBoxBio.Text;
                NewArtist.Website = txtBoxWebsite.Text;
                NewArtist.Save();
                this.Close();
            }
            else
            {
                MessageBox.Show("New Artist must at least have a name.");
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog.FileName;
            NewArtist.SetProfilePic(fileName);
            picBoxProfilePic.Image = NewArtist.ProfilePic;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
