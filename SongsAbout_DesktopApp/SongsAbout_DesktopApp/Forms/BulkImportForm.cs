using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsAbout.Enums;
using SongsAbout.Properties;

namespace SongsAbout.Forms
{
    public partial class BulkImportForm : Form
    {
        public DbEntityType DbEntityType { get; set; }
        public BulkImportForm()
        {
            InitializeComponent();
            this.BackColor = User.Default.BackColor;
        }
        public BulkImportForm(DbEntityType type)
        {
            this.DbEntityType = type;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Program.Database.LargeQuery = true;
            try
            {
                switch (this.DbEntityType)
                {
                    case DbEntityType.Genre:
                        ImportAsGenres(Program.Database.Genres.AllNames);
                        break;
                    case DbEntityType.Tag:
                        ImportAsTags(Program.Database.Tags.AllNames);
                        break;
                    case DbEntityType.Playlist:
                        ImportAsPlaylists(Program.Database.Playlists.AllNames);
                        break;
                    default:
                        MessageBox.Show($"The given DbEntityType is Not currently available for Bulk Imports: '{this.DbEntityType}'");
                        break;
                }
                this.DialogResult = DialogResult.OK;
                MessageBox.Show($"Successfully imported given {this.DbEntityType}s to the database.");
                this.Close();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                MessageBox.Show($"Something went wrong with buld import of {this.DbEntityType} values: {ex.Message}");
            }
            Program.Database.LargeQuery = false;
        }

        private void ImportAsPlaylists(List<string> existingNames)
        {
            var lines = txtBoxNewItems.Text.Split('\r', '\n').ToList()
                .Where(list => !existingNames.Contains(list));

            foreach (String list in lines)
            {
                if (list != "\r")
                {
                    try
                    {
                        Program.Database.Playlists.Add(list);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void ImportAsTags(List<string> existingNames)
        {
            var lines = txtBoxNewItems.Text.Split('\n').ToList()
                 .Where(tag => !existingNames.Contains(tag));

            foreach (String tag in lines)
            {
                Program.Database.Playlists.Add(tag);
            }
        }

        private void ImportAsGenres(List<string> existingNames)
        {
            var lines = txtBoxNewItems.Text.Split('\n').ToList()
                 .Where(genre => !existingNames.Contains(genre));

            foreach (String genre in lines)
            {
                Program.Database.Playlists.Add(genre);
            }
        }
    }
}
