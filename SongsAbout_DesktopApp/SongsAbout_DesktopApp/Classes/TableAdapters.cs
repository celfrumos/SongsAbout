using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp.DataSetTableAdapters
{
    public partial class TracksTableAdapter
    {
        public TracksTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
    public partial class ArtistsTableAdapter
    {
        public ArtistsTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
    public partial class TrackArtistsTableAdapter
    {
        public TrackArtistsTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }

    }
    public partial class TrackGenresTableAdapter
    {
        public TrackGenresTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
    public partial class GenresTableAdapter
    {        
        public GenresTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
    public partial class AlbumsTableAdapter
    {
        public AlbumsTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
    public partial class TagsTableAdapter
    {
        public TagsTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
    public partial class TrackTagsTableAdapter
    {
        public TrackTagsTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
    public partial class ListsTableAdapter
    {
        public ListsTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
    public partial class AlbumTracksTableAdapter
    {
        public AlbumTracksTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
    public partial class AlbumGenresTableAdapter
    {
        public AlbumGenresTableAdapter(SqlConnection connection) : this()
        {
            this._connection = connection;
        }
        public void SetConnection(SqlConnection connection)
        {
            this._connection = connection;
        }
    }
}
