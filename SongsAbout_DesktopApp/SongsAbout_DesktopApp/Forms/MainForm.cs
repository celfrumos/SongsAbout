using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using SongsAbout_DesktopApp.Forms;

namespace SongsAbout_DesktopApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string uri = "spotify:track:6C7RJEIUDqKkJRZVWdkfkH";
            //MakeRequest(uri).Wait();
            //GetResults();
        }

        private void GetResults()
        {
            string query = txtBoxQuery.Text;
            List<string> genres = new List<string>();
            for (int i = 0; i < lstBxGenres.SelectedItems.Count; i++)
            {
                genres.Add(lstBxGenres.SelectedItems[i].ToString());
            }
        }

        static async Task MakeRequest(string request)
        {
            try
            {
                // Set parameters
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.spotify.com");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // GET
                    HttpResponseMessage response = await client.GetAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        // Assign response
                        string answer = await response.Content.ReadAsStringAsync();

                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error making API request.");
            }

        }

        private void btnSavedLists_Click(object sender, EventArgs e)
        {
            MyListsForm myLists = new MyListsForm();
            myLists.ShowDialog();
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            try
            {
                AddTrackForm addTrack = new AddTrackForm();
                addTrack.ShowDialog();

                if (addTrack.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Successfully saved " + addTrack.NewTrack.track_name, "Success!");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.Message + ex.InnerException.Message, "Something went wrong.");
                }
                else
                {
                    MessageBox.Show(ex.Message, "Something went wrong.");

                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ArtistDictionary = artists.Load();
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            QueryForm queryForm = new QueryForm();
            queryForm.ShowDialog();
        }
    }
}
