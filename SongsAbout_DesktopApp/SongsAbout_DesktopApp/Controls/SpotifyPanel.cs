using System;
using System.Drawing;
using SongsAbout.Classes;
using SongsAbout.Properties;
using SpotifyAPI.Web.Models;
using SongsAbout.Entities;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using SongsAbout.Enums;

namespace SongsAbout.Controls
{
    public partial class SpotifyPanel : UserControl, IEntityControl
    {
        private DbEntity _dbEntity;
        protected string _level;
        private Size _minSize;
        private Size _maxSize;


        private Size _imageStackedPanelMaxSize = new Size(105, 135);
        private Size _imageStackedPanelMinSize = new Size(70, 95);

        private Size _imagePanelMaxSize = new Size(200, 134);
        private Size _imagePanelMinSize = new Size(140, 40);

        private Size _textPanelMaxSize = new Size(205, 30);
        private Size _textPanelMinSize = new Size(105, 30);

        private SPanelType _panelType;

        public string Level { get; set; }

        public override Size MinimumSize
        {

            get { return this._minSize; }
            set
            {
                this._minSize = value;
                this.splitContainer.MinimumSize = value;
                int w = value.Width,
                    h = value.Height;

                switch (_panelType)
                {
                    case SPanelType.Image:
                        this.SpotifyPictureBox.MinimumSize = new Size(w, h * (1 / 5));
                        this.SpotifyLabel.MinimumSize = new Size(w, h * (4 / 5));
                        break;
                    case SPanelType.Text:
                        this.SpotifyLabel.MinimumSize = value;
                        break;
                    case SPanelType.StackedImage:
                        this.SpotifyPictureBox.MinimumSize = new Size(w, h * (3 / 4));
                        this.SpotifyLabel.MinimumSize = new Size(w, h * (1 / 4));
                        break;
                    default:
                        break;
                }
                this._resize();
            }
        }
        public override Size MaximumSize
        {
            get { return this._maxSize; }
            set
            {
                this._maxSize = value;
                this.splitContainer.MaximumSize = value;
                int w = value.Width,
                    h = value.Height;

                switch (_panelType)
                {
                    case SPanelType.Image:
                        this.SpotifyPictureBox.MaximumSize = new Size(w * (1 / 5), h);
                        this.SpotifyLabel.MaximumSize = new Size(w * (4 / 5), h);
                        break;
                    case SPanelType.Text:
                        this.SpotifyLabel.MaximumSize = value;
                        break;
                    case SPanelType.StackedImage:
                        this.SpotifyPictureBox.MaximumSize = new Size(w, h * (3 / 4));
                        this.SpotifyLabel.MaximumSize = new Size(w, h * (1 / 4));
                        break;
                    default:
                        break;
                }
                this._resize();
            }
        }

        new public Size Size
        {
            get { return base.Size; }
            set
            {
                base.Size = value;
                this.splitContainer.Size = value;
                int w = value.Width,
                    h = value.Height;

                switch (_panelType)
                {
                    case SPanelType.Image:
                        this.SpotifyPictureBox.Size = new Size(w * (1 / 5), h);
                        this.SpotifyLabel.Size = new Size(w * (4 / 5), h);
                        break;
                    case SPanelType.Text:
                        this.SpotifyLabel.Size = value;
                        break;
                    case SPanelType.StackedImage:
                        this.SpotifyPictureBox.Size = new Size(w, h * (3 / 4));
                        this.SpotifyLabel.Size = new Size(w, h * (1 / 4));
                        break;
                    default:
                        break;
                }
                this._resize();
            }

        }

        public SPanelType PanelType
        {
            get { return this._panelType; }
            set
            {
                this._panelType = value;
                if (value == SPanelType.Text)
                {
                    PictureCollapsed = true;
                }
                else
                {
                    if (value == SPanelType.Image)
                    {
                        this.splitContainer.Orientation = Orientation.Vertical;
                    }
                    else
                    {
                        this.splitContainer.Orientation = Orientation.Horizontal;
                    }
                    PictureCollapsed = false;
                }
            }
        }

        public bool PictureCollapsed
        {
            get { return this.splitContainer.Panel1Collapsed; }
            set
            {
                this.splitContainer.Panel1Collapsed = value;
                // if displaying as text panel
                if (this.splitContainer.Panel1Collapsed)
                {
                    this.MinimumSize = _textPanelMinSize;
                    this.MaximumSize = _textPanelMaxSize;
                }
                else
                {
                    // if displaying as a stacked image panel
                    if (_panelType == SPanelType.StackedImage)
                    {
                        this.MinimumSize = _imageStackedPanelMinSize;
                        this.MaximumSize = _imageStackedPanelMaxSize;
                    }
                    // if displaying as image panel
                    else
                    {
                        //  this.splitContainer.SplitterDistance = 70;
                        this.MinimumSize = _imagePanelMinSize;
                        this.MaximumSize = _imagePanelMaxSize;
                    }
                }
                _resize();
            }
        }

        protected void _resize()
        {
            int w;
            int h;
            w = (this.Size.Width > this.MaximumSize.Width) ? this.MaximumSize.Width : this.Size.Width;
            h = (this.Size.Height > this.MaximumSize.Height) ? this.MaximumSize.Height : this.Size.Height;

            w = (this.Size.Width < this.MinimumSize.Width) ? this.MinimumSize.Width : this.Size.Width;
            h = (this.Size.Height < this.MinimumSize.Height) ? this.MinimumSize.Height : this.Size.Height;

            this.Size = new Size(w, h);
        }

        public Image Image
        {
            get { return this.SpotifyPictureBox.Image; }
            set
            {
                try
                {
                    this.SpotifyPictureBox.Image = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public override string Text
        {
            get { return this.SpotifyLabel.Text; }
            set { this.SpotifyLabel.Text = value; }
        }

        public PictureBoxSizeMode SizeMode
        {
            get { return this.SpotifyPictureBox.SizeMode; }
            set { this.SpotifyPictureBox.SizeMode = value; }
        }

        public SpotifyEntityType SpotifyEntityType { get; set; }

        public DbEntityType DbEntityType { get; set; }
        public DbEntity DbEntity
        {
            get { return this._dbEntity; }
            set
            {
                try
                {
                    this._dbEntity = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public SpotifyPanel()
        {
            InitializeComponent();
            this.PanelType = SPanelType.Image;
        }
        public SpotifyPanel(SPanelType type) : this()
        {
            this.PanelType = type;
        }

        public SpotifyPanel(Artist artist, SPanelType type = SPanelType.Image, EventHandler clickEvent = null) : this(artist.name, type, $"{typeof(Artist)}", clickEvent, artist, DbEntityType.Artist)
        {
            setImage(artist.a_profile_pic);
            this.DbEntity = artist;
        }

        private void setImage(byte[] a_profile_pic)
        {
            try
            {
                this.Image = Importer.ImageFromBytes(a_profile_pic);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Image = Resources.MusicNote;
            }
        }

        public SpotifyPanel(string text, SPanelType type = SPanelType.Image, string level = "Not Set", EventHandler clickEvent = null, object tag = null,
          DbEntityType dbtype = DbEntityType.None, SpotifyEntityType spotifyType = SpotifyEntityType.None) : this()
        {
            try
            {
                this.Text = text;
                this.Level = level;
                this.Tag = tag;
                this.Click += clickEvent;
                this.SpotifyEntityType = spotifyType;
                this.DbEntityType = dbtype;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public SpotifyPanel(string text, SPanelType type = SPanelType.Image, EventHandler clickEvent = null) : this(text, type, "Not Set", clickEvent)
        {
        }

        public SpotifyPanel(DbEntity entity, SPanelType type = SPanelType.Image, EventHandler clickEvent = null)
            : this(entity.Name, type, entity.TypeName, clickEvent, entity, entity.DbEntityType, entity.SpotifyType)
        {
            this.DbEntity = entity;
            this.SpotifyLabel = new SpotifyLabel(entity, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(entity, clickEvent);
        }

        public SpotifyPanel(FullAlbum album, SPanelType type = SPanelType.Image, EventHandler clickEvent = null)
            : this(album.Name, type, $"{typeof(FullAlbum)}", clickEvent, album, DbEntityType.Album, SpotifyEntityType.FullAlbum)
        {
            this.SpotifyLabel = new SpotifyLabel(album, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(album, clickEvent);
        }

        public SpotifyPanel(SimpleAlbum album, SPanelType type = SPanelType.Image, EventHandler clickEvent = null)
         : this(album.Name, type, $"{typeof(SimpleAlbum)}", clickEvent, album, DbEntityType.Album, SpotifyEntityType.SimpleAlbum)
        {
            this.SpotifyLabel = new SpotifyLabel(album, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(album, clickEvent);
        }

        public SpotifyPanel(FullArtist artist, SPanelType type = SPanelType.Image, EventHandler clickEvent = null)
         : this(artist.Name, type, $"{typeof(FullArtist)}", clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        {
            this.SpotifyLabel = new SpotifyLabel(artist, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(artist, clickEvent);
            this.Image = this.SpotifyPictureBox.Image;
        }
        public SpotifyPanel(SimpleArtist artist, SPanelType type = SPanelType.Image, EventHandler clickEvent = null)
         : this(artist.Name, type, $"{typeof(SimpleArtist)}", clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        {
            this.SpotifyLabel = new SpotifyLabel(artist, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(artist, clickEvent);
            this.Image = this.SpotifyPictureBox.Image;
        }

        public SpotifyPanel(FullPlaylist playlist, SPanelType type = SPanelType.Image, EventHandler clickEvent = null)
            : this(playlist.Name, type, $"{typeof(FullPlaylist)}", clickEvent, playlist, DbEntityType.List, SpotifyEntityType.FullPlaylist)
        {
            this.SpotifyLabel = new SpotifyLabel(playlist, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(playlist, clickEvent);
        }
        public SpotifyPanel(SimplePlaylist playlist, SPanelType type = SPanelType.Image, EventHandler clickEvent = null)
          : this(playlist.Name, type, $"{typeof(SimplePlaylist)}", clickEvent, playlist, DbEntityType.List, SpotifyEntityType.SimplePlaylist)
        {
            this.SpotifyLabel = new SpotifyLabel(playlist, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(playlist, clickEvent);
        }
        public SpotifyPanel(FullTrack track, SPanelType type = SPanelType.Image, EventHandler clickEvent = null)
        : this(track.Name, type, $"{typeof(FullTrack)}", clickEvent, track, DbEntityType.Track, SpotifyEntityType.FullTrack)
        {
            this.SpotifyLabel = new SpotifyLabel(track, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(track, clickEvent);
        }
        public SpotifyPanel(SimpleTrack track, SPanelType type = SPanelType.Image, EventHandler clickEvent = null)
        : this(track.Name, type, $"{typeof(SimpleTrack)}", clickEvent, track, DbEntityType.Track, SpotifyEntityType.SimpleTrack)
        {
            this.SpotifyLabel = new SpotifyLabel(track, clickEvent);
            this.SpotifyPictureBox = new SpotifyPictureBox(track, clickEvent);
        }
    }

}
