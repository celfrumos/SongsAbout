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
        private bool _isNewArtist = false;

        public bool isNewArtist { get { return _isNewArtist; } }

        int indexOfNewArtist = -1;
        Dictionary<string, Artist> DictArtists;

        public Artist SelectedArtist { get; set; }

        public SelectArtistForm()
        {
            InitializeComponent();
            LoadArtists();
            this.DialogResult = DialogResult.None;
        }

        /// <summary>
        /// Load the Artists and put them in the listBox
        /// </summary>
        private void LoadArtists()
        {
            lstBoxSelectArtist.Items.Clear();
            DictArtists = Loader.LoadArtists();

            foreach (KeyValuePair<string, Artist> a in DictArtists)
            {
                lstBoxSelectArtist.Items.Add(a.Key);
            }

            if (lstBoxSelectArtist.Items.Count > 0)
            {
                lstBoxSelectArtist.SelectedIndex = 0;
            }
        }

        private void btnNewArtist_Click(object sender, EventArgs e)
        {
            _isNewArtist = true;
            AddArtistForm addArtist = new AddArtistForm();
            addArtist.ShowDialog();
            if (addArtist.DialogResult == DialogResult.OK)
            {
                string newName = addArtist.NewArtist.a_name;
                LoadArtists(newName);

            }
        }

        /// <summary>
        /// Loader for when there's a new Artist
        /// </summary>
        /// <param name="newName"></param>
        private void LoadArtists(string newName)
        {
            lstBoxSelectArtist.Items.Clear();
            DictArtists = Loader.LoadArtists();
            int i = 0;
            foreach (KeyValuePair<string, Artist> a in DictArtists)
            {
                lstBoxSelectArtist.Items.Add(a.Key);
                if (a.Key == newName)
                {
                    indexOfNewArtist = i;
                }
                i++;
            }

            if (lstBoxSelectArtist.Items.Count > 0)
            {
                lstBoxSelectArtist.SelectedIndex = indexOfNewArtist;
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
            catch (Exception ex)
            {
                if (lstBoxSelectArtist.Items.Count != 0)
                {
                    this.DialogResult = DialogResult.Abort;
                    throw new Exception();

                }
                else
                {
                    MessageBox.Show("No Artists loaded yet. Press close button to cancel artist selection.");
                }
            }
        }

    }
}
