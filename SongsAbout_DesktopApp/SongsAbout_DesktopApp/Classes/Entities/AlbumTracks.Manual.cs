using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Album = SongsAbout_DesktopApp.Classes.Album;
using System.Threading.Tasks;
using SongsAbout_DesktopApp;

namespace SongsAbout_DesktopApp.Classes.Entities
{
    //public partial class AlbumTracks
    //{
    //    public AlbumTracks(int a_id, int t_id)
    //    {
    //        this.album_id = a_id;
    //        this.track_id = t_id;
    //    }

    //    public void Update(int a_id, int t_id)
    //    {
    //        this.album_id = a_id;
    //        this.track_id = t_id;
    //        this.Save();
    //    }

    //    public void Save()
    //    {

    //        if (Album.Exists(this.album_id))
    //        {
    //            if (Track.Exists(this.track_id))
    //            {
    //                try
    //                {
    //                    using (DataClassesDataContext context = new DataClassesDataContext())
    //                    {
    //                        context.AlbumTracks.InsertOnSubmit(this);
    //                        context.SubmitChanges();
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //                    string msg = $"Error Saving AlbumTracks: {ex.Message}";
    //                    Console.WriteLine(msg);
    //                    throw new Exception(msg);
    //                }

    //            }
    //            else
    //            {
    //                string msg = $"Track Id in AlbumTracks is invalid";
    //                Console.WriteLine(msg);
    //                throw new Exception(msg);
    //            }
    //        }
    //        else
    //        {
    //            string msg = $"Album Id in AlbumTracks is invalid";
    //            Console.WriteLine(msg);
    //            throw new Exception(msg);
    //        }
    //    }
    //}
}
