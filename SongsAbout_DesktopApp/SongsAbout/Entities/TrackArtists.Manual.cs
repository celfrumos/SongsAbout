using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout.Entities
{
    //public partial class TrackArtists
    //{
    //    public TrackArtists(int a_id, int t_id)
    //    {
    //        this.artist_id = a_id;
    //        this.track_id = t_id;
    //    }
    //    public void Update(int a_id, int t_id)
    //    {
    //        this.artist_id = a_id;
    //        this.track_id = t_id;
    //        this.Save();
    //    }

    //    public void Save()
    //    {
    //        if (Artist.Exists(this.artist_id))
    //        {
    //            if (Track.Exists(this.track_id))
    //            {
    //                try
    //                {
    //                    using (DataClassesDataContext context = new DataClassesDataContext())
    //                    {
    //                        context.TrackArtists.InsertOnSubmit(this);
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
    //            string msg = $"Artist Id in TrackArtists is invalid";
    //            Console.WriteLine(msg);
    //            throw new Exception(msg);
    //        }
    //    }
    //}
}
