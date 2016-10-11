using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp.Classes
{
    public class SaveException<T> : Exception
    {
        protected static string _type
        {
            get
            {
                if (_entity is Artist)
                {
                    return "Artist";
                }
                else if (_entity is Album)
                {
                    return "Album";
                }
                else if (_entity is Track)
                {
                    return "Track";
                }
                else
                {
                    throw new Exception("Invalid data type used for DbEntity<> class.");
                }
            }
        }

        private static T _entity { get; }

        private static string _titleColumn
        {
            get
            {
                if (_entity is Artist)
                {
                    return Artist.TitleColumn;
                }
                else if (_entity is Album)
                {
                    return Album.TitleColumn;
                }
                else if (_entity is Track)
                {
                    return Track.TitleColumn;
                }
                else
                {
                    throw new Exception("Invalid data type used for DbEntity<> class.");
                }
            }
        }

        private static string _table
        {
            get
            {
                if (_entity is Artist)
                {
                    return Artist.Table;
                }
                else if (_entity is Album)
                {
                    return Album.Table;
                }
                else if (_entity is Track)
                {
                    return Track.Table;
                }
                else
                {
                    throw new Exception("Invalid data type used for DbEntity<> class.");
                }
            }
        }
        private string _message;
        new public string Message { get { return this._message; } }
        public SaveException() : base()
        {
            string msg = $"Error Saving {_type}";
            this.Message = msg;
        }

    }
}
