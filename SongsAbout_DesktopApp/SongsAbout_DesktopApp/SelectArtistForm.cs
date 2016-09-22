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
        Loader ArtistLoader = new Loader();
        Dictionary<string, Artist> DictArtists;

        public string SelectedArtist { get; set; }

        public SelectArtistForm(ref Dictionary<string, Artist> ArtistDictionary)
        {
            DictArtists = ArtistDictionary;
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
           DictArtists = ArtistLoader.LoadArtists();
            foreach (KeyValuePair<string, Artist> artist in DictArtists)
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

        private void btnNewArtist_Click(object sender, EventArgs e)
        {
            AddArtistForm addArtist = new AddArtistForm();
            addArtist.ShowDialog();
        }
    }
}
