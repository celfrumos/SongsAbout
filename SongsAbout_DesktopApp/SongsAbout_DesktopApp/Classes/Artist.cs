using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;
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
            DataSet dataSet = new DataSet();
            DataTable artistTable = dataSet.Tables["Artists"];
            string query = "a_name = '" + this.a_name + "'";
            DataRow[] rows;
            rows = artistTable.Select(query);

            if (rows.Length == 0)
            {
                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    context.Artists.InsertOnSubmit(this);
                    context.SubmitChanges();
                }

            }
            else
            {
                throw new Exception("An artist with this name already exists. ");
            }
        }
    }
}
