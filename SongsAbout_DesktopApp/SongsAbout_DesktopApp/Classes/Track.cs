using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp
{
    public partial class Track
    {
        public void Save()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                context.Tracks.InsertOnSubmit(this);
                context.SubmitChanges();
            }
        }

        public void SaveGenres(List<string> genres)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                DataSet gen = new DataSet();

                foreach (string g in genres)
                {
                    TrackGenre tg = new TrackGenre();
                    tg.track_id = this.track_id;
                    tg.tg_genre = g;

                    context.TrackGenres.InsertOnSubmit(tg);
                }

                context.SubmitChanges();
            }

        }
    }
}
