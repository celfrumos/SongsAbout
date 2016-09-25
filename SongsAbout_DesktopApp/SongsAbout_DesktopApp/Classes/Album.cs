using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp
{
    public partial class Album
    {
        public void Save()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                context.Albums.InsertOnSubmit(this);                
                context.SubmitChanges();
            }
        }
        
    }
}
