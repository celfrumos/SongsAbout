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

namespace SongsAbout.Forms
{
    public partial class BulkImportForm : Form
    {
        public BulkImportForm()
        {
            InitializeComponent();
        }
        public BulkImportForm(DbEntityType type)
        {
            switch (type)
            {
                case DbEntityType.Artist:
                    break;
                case DbEntityType.Album:
                    break;
                case DbEntityType.Track:
                    break;
                case DbEntityType.Genre:
                    break;
                case DbEntityType.Tag:
                    break;
                case DbEntityType.Playlist:
                    break;
                default:
                    break;
            }
        }
    }
}
