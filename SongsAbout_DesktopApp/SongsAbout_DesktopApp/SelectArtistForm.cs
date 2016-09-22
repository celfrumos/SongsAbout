using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp
{
    public partial class SelectArtistForm : Form
    {
        LoadArtists ArtistLoader = new LoadArtists();
        Dictionary<string, Artist> ArtistDictionary;

        public string SelectedArtist { get; set; }

        public SelectArtistForm(ref Dictionary<string, Artist> ArtistDictionary)
        {
            InitializeComponent();
            PopulateLstBox();
            this.DialogResult = DialogResult.None;
        }

        public SelectArtistForm()
        {
            InitializeComponent();
            PopulateLstBox();
            this.DialogResult = DialogResult.None;
        }
       private void PopulateLstBox()
        {
           ArtistDictionary = ArtistLoader.Load();
            foreach (KeyValuePair<string, Artist> artist in ArtistDictionary)
            {
                lstBoxSelectArtist.Items.Add(artist.Key);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedArtist = lstBoxSelectArtist.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception)
            {
                SelectedArtist = "";
                this.DialogResult = DialogResult.Abort;
            }
            this.Close();
        }
    }
}
