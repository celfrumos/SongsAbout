using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SongsAbout.Classes;
using SongsAbout.Entities;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;
using SpotifyAPI.Local.Enums;
namespace SongsAbout.Controls
{
    public interface ISpotifyEntityControl
    {
        string EntityName { get; }
        SpotifyIntegralEntity SpotifyEntity { get; set; }
        SpotifyEntityType SpotifyEntityType { get; set; }
        void ImportEntity();
    }
}
