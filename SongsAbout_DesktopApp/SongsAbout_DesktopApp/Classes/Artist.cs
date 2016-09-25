using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp
{
    /// <summary>
    /// Partial Class to hold Artist Functions
    /// </summary>
    public partial class Artist
    {
        /// <summary>
        /// Submit Changes to the Database
        /// </summary>
        public void Save()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                context.Artists.InsertOnSubmit(this);
                context.SubmitChanges();
            }
        }
    }
}
