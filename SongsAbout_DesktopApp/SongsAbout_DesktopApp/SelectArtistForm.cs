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

        public Artist SelectedArtist { get; set; }

        public SelectArtistForm(ref Dictionary<string, Artist> ArtistDictionary)
        {
            DictArtists = ArtistDictionary;
            InitializeComponent();
            LoadArtists();
            lstBoxSelectArtist.SelectedIndex = 0;
            this.DialogResult = DialogResult.None;
        }

        public SelectArtistForm()
        {
            InitializeComponent();
            LoadArtists();
            lstBoxSelectArtist.SelectedIndex = 0;
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

        /// <summary>
        /// Choose the Artist to be used in the form that launched this one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedArtist = DictArtists[lstBoxSelectArtist.SelectedItem.ToString()];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                if (lstBoxSelectArtist.Items.Count != 0)
                {
                    this.DialogResult = DialogResult.Abort;
                    throw new Exception();

                }
                else
                {
                    MessageBox.Show("No Artists loaded yet. Press close button to cancel selection.");
                }
            }
        }

        private void btnNewArtist_Click(object sender, EventArgs e)
        {
            AddArtistForm addArtist = new AddArtistForm();
            addArtist.ShowDialog();
            LoadArtists();
        }
    }
}
