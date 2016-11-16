using System.Drawing;
using System.Windows.Forms;

namespace SongsAbout.Controls
{
    public interface ISpotifyPictureBox
    {
        Image Image { get; set; }
        string Level { get; set; }
        string Name { get; set; }
        PictureBoxSizeMode SizeMode { get; set; }
    }
}