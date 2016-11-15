using System.Drawing;
using System.Windows.Forms;

namespace SongsAbout_DesktopApp.Controls
{
    public interface ISpotifyPictureBox
    {
        Image Image { get; set; }
        string Level { get; set; }
        string Name { get; set; }
        PictureBoxSizeMode SizeMode { get; set; }
    }
}