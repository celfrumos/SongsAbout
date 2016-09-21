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
        Artist artist = new Artist();

        Image picture;
        public AddArtistForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            artist.Name = txtBoxName.Text;
            artist.Bio = txtBoxBio.Text;
            artist.Website = txtBoxWebsite.Text;
            artist.Save();
            this.Close();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog.FileName;
            picture = Image.FromFile(fileName);
            picBoxProfilePic.Image = picture;
            artist.ProfilePic = picture;
            artist.ProfPicSource = fileName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
