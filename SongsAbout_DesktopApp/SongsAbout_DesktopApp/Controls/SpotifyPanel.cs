using System;
using System.Drawing;
using SongsAbout.Classes;
using SongsAbout.Properties;
using SpotifyAPI.Web.Models;
using SongsAbout.Entities;
using System.Windows;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using Size = System.Drawing.Size;
using SongsAbout.Enums;

namespace SongsAbout.Controls
{
    public partial class SpotifyPanel : UserControl, IEntityControl
    {
        private DbEntity _dbEntity;
        private string _level;

        ///
        // Image Panel constants 
        ///
        protected const double
            IMAGE_PANEL_IMAGE_RATIO = 1.0 / 5.0,
            IMAGE_PANEL_LABEL_RATIO = 1.0 - IMAGE_PANEL_IMAGE_RATIO,
            IMAGE_PANEL_RATIO = (double)IMAGE_PANEL_MAX_HEIGHT / (double)IMAGE_PANEL_MAX_WIDTH;

        protected const int
            IMAGE_PANEL_MAX_WIDTH = 200, IMAGE_PANEL_MAX_HEIGHT = 135,
            IMAGE_PANEL_MIN_WIDTH = 140, IMAGE_PANEL_MIN_HEIGHT = 40;
        protected static readonly Size
            IMAGE_PANEL_MAX_SIZE = new Size(IMAGE_PANEL_MAX_WIDTH, IMAGE_PANEL_MAX_HEIGHT),
            IMAGE_PANEL_MIN_SIZE = new Size(IMAGE_PANEL_MIN_WIDTH, IMAGE_PANEL_MIN_HEIGHT);

        protected const int
            IMAGE_PANEL_MAX_LABEL_WIDTH = (int)(IMAGE_PANEL_MAX_WIDTH * IMAGE_PANEL_LABEL_RATIO),
            IMAGE_PANEL_MIN_LABEL_WIDTH = (int)(IMAGE_PANEL_MIN_WIDTH * IMAGE_PANEL_LABEL_RATIO),
            IMAGE_PANEL_MAX_IMAGE_LENGTH = (int)(IMAGE_PANEL_MAX_WIDTH * IMAGE_PANEL_IMAGE_RATIO),
            IMAGE_PANEL_MIN_IMAGE_LENGTH = (int)(IMAGE_PANEL_MIN_WIDTH * IMAGE_PANEL_IMAGE_RATIO);

        protected static readonly Size
            _imagePanelMaxSize = new Size(IMAGE_PANEL_MAX_WIDTH, IMAGE_PANEL_MAX_HEIGHT),
            _imagePanelMinSize = new Size(IMAGE_PANEL_MIN_WIDTH, IMAGE_PANEL_MIN_HEIGHT);

        protected static readonly Size
            _imagePanelMinImgSize = new Size(IMAGE_PANEL_MIN_IMAGE_LENGTH, IMAGE_PANEL_MIN_IMAGE_LENGTH),
            _imagePanelMaxImgSize = new Size(IMAGE_PANEL_MAX_IMAGE_LENGTH, IMAGE_PANEL_MAX_IMAGE_LENGTH);

        protected static readonly Size
            _imagePanelMaxLblSize = new Size(IMAGE_PANEL_MAX_LABEL_WIDTH, IMAGE_PANEL_MAX_HEIGHT),
            _imagePanelMinLblSize = new Size(IMAGE_PANEL_MIN_LABEL_WIDTH, IMAGE_PANEL_MIN_HEIGHT);

        ///
        /// Stacked Panel constants
        /// 
        protected const double
            STACKED_IMAGE_RATIO = 3.0 / 4.0,
            STACKED_LABEL_RATIO = (1.0 - STACKED_IMAGE_RATIO),
            STACKED_PANEL_RATIO = (double)STACKED_MAX_HEIGHT / (double)STACKED_MAX_WIDTH;

        protected const int
            STACKED_MAX_WIDTH = 105, STACKED_MAX_HEIGHT = 135,
            STACKED_MIN_WIDTH = 70, STACKED_MIN_HEIGHT = 95;

        protected static readonly Size
            _stackedPanelMaxSize = new Size(STACKED_MAX_WIDTH, STACKED_MAX_HEIGHT),
            _stackedPanelMinSize = new Size(STACKED_MIN_WIDTH, STACKED_MIN_HEIGHT);

        private const int
            STACKED_MAX_LABEL_HEIGHT = (int)(STACKED_MAX_HEIGHT * STACKED_LABEL_RATIO),
            STACKED_MIN_LABEL_HEIGHT = (int)(STACKED_MIN_HEIGHT * STACKED_LABEL_RATIO);

        private const int
            STACKED_MAX_IMAGE_LENGTH = (int)(STACKED_MAX_HEIGHT * STACKED_IMAGE_RATIO),
            STACKED_MIN_IMAGE_LENGTH = (int)(STACKED_MIN_HEIGHT * STACKED_IMAGE_RATIO);

        protected static readonly Size
            _stackedPanelMaxImgSize = new Size(STACKED_MAX_IMAGE_LENGTH, STACKED_MAX_IMAGE_LENGTH),
            _stackedPanelMinImgSize = new Size(STACKED_MIN_IMAGE_LENGTH, STACKED_MIN_IMAGE_LENGTH);

        protected static readonly Size
            _stackedPanelMaxLblSize = new Size(STACKED_MAX_WIDTH, STACKED_MAX_LABEL_HEIGHT),
            _stackedPanelMinLblSize = new Size(STACKED_MIN_WIDTH, STACKED_MIN_LABEL_HEIGHT);


        ///
        /// Text Panel constants
        /// 
        protected const double
            TEXT_PANEL_LABEL_RATIO = 1.0,
            TEXT_PANEL_IMAGE_RATIO = 0.0,
            TEXT_PANEL_RATIO = (double)TEXT_PANEL_MAX_HEIGHT / (double)TEXT_PANEL_MAX_WIDTH;

        private const int
            TEXT_PANEL_MAX_WIDTH = 205, TEXT_PANEL_MAX_HEIGHT = 30,
            TEXT_PANEL_MIN_WIDTH = 105, TEXT_PANEL_MIN_HEIGHT = 30;

        protected static readonly Size
            _textPanelMaxSize = new Size(TEXT_PANEL_MAX_WIDTH, TEXT_PANEL_MAX_HEIGHT),
            _textPanelMinSize = new Size(TEXT_PANEL_MIN_WIDTH, TEXT_PANEL_MIN_HEIGHT);

        protected static readonly Size
            _textMaxImgSize = new Size(0, 0),
            _textMinImgSize = _textMaxImgSize;

        protected static readonly Size
            _textMaxLblSize = _textPanelMaxSize,
            _textMinLblSize = _textPanelMinSize;


        public double WidthToHeightRatio
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return IMAGE_PANEL_RATIO;
                    case SPanelType.Text:
                        return TEXT_PANEL_RATIO;
                    case SPanelType.StackedImage:
                        return STACKED_PANEL_RATIO;
                    default:
                        return IMAGE_PANEL_RATIO;
                }
            }
        }

        public double ImageToLabelRatio
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return IMAGE_PANEL_IMAGE_RATIO;
                    case SPanelType.Text:
                        return TEXT_PANEL_IMAGE_RATIO;
                    case SPanelType.StackedImage:
                        return STACKED_IMAGE_RATIO;
                    default:
                        return IMAGE_PANEL_IMAGE_RATIO;
                }
            }
        }

        public double LabelToImageRatio
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return IMAGE_PANEL_LABEL_RATIO;
                    case SPanelType.Text:
                        return TEXT_PANEL_LABEL_RATIO;
                    case SPanelType.StackedImage:
                        return STACKED_LABEL_RATIO;
                    default:
                        return IMAGE_PANEL_LABEL_RATIO;
                }
            }
        }


        private SPanelType _sPanelType;

        public string Level { get; set; }

        public Size ImageSize
        {
            get { return this.SpotifyPictureBox.Size; }
            set
            {
                this.SpotifyPictureBox.Size = value;
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        this.SplitterDistance = value.Width;
                        break;
                    case SPanelType.Text:
                        this.SplitterDistance = 0;
                        break;
                    case SPanelType.StackedImage:
                        this.SplitterDistance = value.Height;
                        break;
                    default:
                        this.SplitterDistance = value.Width;
                        break;
                }
            }
        }

        private void _resizeLabel()
        {
            int w = LabelSize.Width,
                h = this.LabelSize.Height;

            int maxW = this.MaxLabelSize.Width,
                maxH = this.MaxLabelSize.Height,
                minW = this.MinLabelSize.Width,
                minH = this.MinLabelSize.Height;

            w = (w > maxW) ? maxW : w;
            w = (w < minW) ? minW : w;

            h = (h > maxH) ? maxH : h;
            h = (h < minH) ? minH : h;


            this.SpotifyLabel.Size = new Size(w, h);
        }

        public Size LabelSize
        {
            get { return this.SpotifyLabel.Size; }
            set { this.SpotifyLabel.Size = value; }
        }

        private Size MaxLabelSize
        {
            get { return this.SpotifyLabel.MaximumSize; }
            set { this.SpotifyLabel.MaximumSize = value; }
        }
        private Size MinLabelSize
        {
            get { return this.SpotifyLabel.MinimumSize; }
            set { this.SpotifyLabel.MinimumSize = value; }
        }
        private void _resizeImage()
        {
            int w = this.SpotifyPictureBox.Size.Width,
                h = this.SpotifyPictureBox.Size.Height;

            int maxW = this.MaxImageSize.Width,
                maxH = this.MaxImageSize.Height,
                minW = this.MinImageSize.Width,
                minH = this.MinImageSize.Height;

            w = (w > maxW) ? maxW : w;
            w = (w < minW) ? minW : w;

            h = (h > maxH) ? maxH : h;
            h = (h < minH) ? minH : h;

            this.SpotifyPictureBox.Size = new Size(w, h);
        }

        private Size MaxImageSize
        {
            get { return SpotifyPictureBox.MaximumSize; }
            set { SpotifyPictureBox.MaximumSize = value; }
        }

        private Size MinImageSize
        {
            get { return SpotifyPictureBox.MinimumSize; }
            set { SpotifyPictureBox.MinimumSize = value; }
        }

        new public Size Size
        {
            get { return base.Size; }
            set
            {
                int w = value.Width,
                    h = value.Height;

                w = (w > this.Width) ? (int)(h * WidthToHeightRatio) : w;
                h = (h > this.Width) ? (int)(w / WidthToHeightRatio) : w;

                base.Size = new Size(w, h);
                this.splitContainer.Size = base.Size;

                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        this.ImageSize = new Size((int)(w * ImageToLabelRatio), h);
                        this.LabelSize = new Size((int)(w * LabelToImageRatio), h);
                        break;
                    case SPanelType.Text:
                        this.ImageSize = new Size((int)(w * ImageToLabelRatio), (int)(h * ImageToLabelRatio));
                        this.LabelSize = value;
                        break;
                    case SPanelType.StackedImage:
                        this.ImageSize = new Size(w, (int)(h * ImageToLabelRatio));
                        this.LabelSize = new Size(w, (int)(h * LabelToImageRatio));
                        break;
                    default:
                        this.ImageSize = new Size((int)(w * ImageToLabelRatio), h);
                        this.LabelSize = new Size((int)(w * LabelToImageRatio), h);
                        break;
                }
                _resize();
            }
        }

        public SPanelType SPanelType
        {
            get { return this._sPanelType; }
            set
            {
                this._sPanelType = value;
                switch (value)
                {
                    case SPanelType.Image:
                        PictureCollapsed = false;
                        this.splitContainer.Orientation = Orientation.Vertical;
                        this.MinimumSize = _stackedPanelMinSize;
                        this.MaximumSize = _stackedPanelMaxSize;
                        this.MaxImageSize = _stackedPanelMaxImgSize;
                        this.MinImageSize = _stackedPanelMinImgSize;
                        this.MaxLabelSize = _stackedPanelMaxLblSize;
                        this.MinLabelSize = _stackedPanelMinLblSize;
                        break;
                    case SPanelType.Text:
                        this.PictureCollapsed = true;
                        this.MinimumSize = _textPanelMinSize;
                        this.MaximumSize = _textPanelMaxSize;
                        this.MaxImageSize = _textMaxImgSize;
                        this.MinImageSize = _textMinImgSize;
                        this.MaxLabelSize = _textMaxLblSize;
                        this.MinLabelSize = _textMinLblSize;
                        break;
                    case SPanelType.StackedImage:
                        this.PictureCollapsed = false;
                        this.splitContainer.Orientation = Orientation.Horizontal;
                        this.MinimumSize = _stackedPanelMinSize;
                        this.MaximumSize = _stackedPanelMaxSize;
                        this.MaxImageSize = _stackedPanelMaxImgSize;
                        this.MinImageSize = _stackedPanelMinImgSize;
                        this.MaxLabelSize = _stackedPanelMaxLblSize;
                        this.MinLabelSize = _stackedPanelMinLblSize;
                        break;
                    default:
                        this.PictureCollapsed = false;
                        this.splitContainer.Orientation = Orientation.Vertical;
                        this.MinimumSize = _stackedPanelMinSize;
                        this.MaximumSize = _stackedPanelMaxSize;
                        this.MaxImageSize = _stackedPanelMaxImgSize;
                        this.MinImageSize = _stackedPanelMinImgSize;
                        this.MaxLabelSize = _stackedPanelMaxLblSize;
                        this.MinLabelSize = _stackedPanelMinLblSize;
                        break;
                }
                _resize();
            }

        }

        public bool PictureCollapsed
        {
            get { return this.splitContainer.Panel1Collapsed; }
            set { this.splitContainer.Panel1Collapsed = value; }
        }

        protected void _resize()
        {
            int w = this.Size.Width,
                h = this.Size.Height;
            if (w == 0 && h == 0)
                return;

            int maxW = this.MaximumSize.Width,
                maxH = this.MaximumSize.Height,
                minW = this.MinimumSize.Width,
                minH = this.MinimumSize.Height;

            w = (w > maxW) ? maxW : w;
            w = (w < minW) ? minW : w;

            h = (h > maxH) ? maxH : h;
            h = (h < minH) ? minH : h;


            base.Size = new Size(w, h);
            _resizeImage();
            _resizeLabel();

        }
        public int SplitterDistance
        {
            get { return this.splitContainer.SplitterDistance; }
            set { this.splitContainer.SplitterDistance = value; }
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
            this.SPanelType = SPanelType.Image;
            InitializeComponent();
        }
        public SpotifyPanel(SPanelType panelType = SPanelType.Image)
        {
            InitializeComponent();
            this.SPanelType = panelType;
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
