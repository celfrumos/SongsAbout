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
        Dictionary<string, Artist> DictArtists;

        public string SelectedArtist { get; set; }

        public SelectArtistForm(ref Dictionary<string, Artist> ArtistDictionary)
        {
            DictArtists = ArtistDictionary;
            InitializeComponent();
            LoadArtists();
            this.DialogResult = DialogResult.None;
        }

        public SelectArtistForm()
        {
            InitializeComponent();
            LoadArtists();
            this.DialogResult = DialogResult.None;
        }

        private void LoadArtists()
        {
            Loader loader = new Loader();
            DictArtists = loader.LoadArtists();
            lstBoxSelectArtist.Items.Clear();
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
            LoadArtists();
        }
    }
}
