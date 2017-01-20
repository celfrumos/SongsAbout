using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using SongsAbout.Classes;
using SongsAbout.Desktop.Properties;
using SpotifyAPI.Web.Models;
using SongsAbout.Entities;
//using System.Windows;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using Size = System.Drawing.Size;
using SongsAbout.Enums;
using SpotifyAPI.Web.Enums;

namespace SongsAbout.Controls
{
    public enum SPanelSize
    {
        Small, Medium, Large
    }
    public partial class SPanel : UserControl, IEntityControl
    {
        #region Constants
        private const string DEFAULT_ENTITY_NAME = "Not Set";
        private const SPanelSize DEFAULT_PANEL_SIZE = SPanelSize.Medium;
        private const SPanelType DEFAULT_PANEL_TYPE = SPanelType.Image;
        #region Image Constants
        ///
        // Image Panel constants 
        ///
        protected const double
            IMAGE_PANEL_IMAGE_RATIO = 1.0 / 5.0,
            IMAGE_PANEL_LABEL_RATIO = 1.0 - IMAGE_PANEL_IMAGE_RATIO,
            IMAGE_PANEL_RATIO = (double)IMAGE_PANEL_MAX_HEIGHT / (double)IMAGE_PANEL_MAX_WIDTH;

        protected const int
            IMAGE_PANEL_MAX_WIDTH = 366, IMAGE_PANEL_MAX_HEIGHT = 109,
            IMAGE_PANEL_MED_WIDTH = 272, IMAGE_PANEL_MED_HEIGHT = 70,
            IMAGE_PANEL_MIN_WIDTH = 160, IMAGE_PANEL_MIN_HEIGHT = 40;

        protected const int
            IMAGE_PANEL_MAX_LABEL_WIDTH = (int)(IMAGE_PANEL_MAX_HEIGHT / IMAGE_PANEL_LABEL_RATIO),
            IMAGE_PANEL_MED_LABEL_WIDTH = (int)(IMAGE_PANEL_MED_HEIGHT / IMAGE_PANEL_LABEL_RATIO),
            IMAGE_PANEL_MIN_LABEL_WIDTH = (int)(IMAGE_PANEL_MIN_HEIGHT / IMAGE_PANEL_LABEL_RATIO),

            IMAGE_PANEL_MAX_IMAGE_LENGTH = IMAGE_PANEL_MAX_HEIGHT,
            IMAGE_PANEL_MED_IMAGE_LENGTH = IMAGE_PANEL_MED_HEIGHT,
            IMAGE_PANEL_MIN_IMAGE_LENGTH = IMAGE_PANEL_MIN_HEIGHT;

        protected static readonly Size
            _imagePanelMaxSize = new Size(IMAGE_PANEL_MAX_WIDTH, IMAGE_PANEL_MAX_HEIGHT),
            _imagePanelMedSize = new Size(IMAGE_PANEL_MED_WIDTH, IMAGE_PANEL_MED_HEIGHT),
            _imagePanelMinSize = new Size(IMAGE_PANEL_MIN_WIDTH, IMAGE_PANEL_MIN_HEIGHT);

        protected static readonly Size
            _imagePanelMaxImgSize = new Size(IMAGE_PANEL_MAX_IMAGE_LENGTH, IMAGE_PANEL_MAX_IMAGE_LENGTH),
            _imagePanelMedImgSize = new Size(IMAGE_PANEL_MED_IMAGE_LENGTH, IMAGE_PANEL_MED_IMAGE_LENGTH),
            _imagePanelMinImgSize = new Size(IMAGE_PANEL_MIN_IMAGE_LENGTH, IMAGE_PANEL_MIN_IMAGE_LENGTH);

        protected static readonly Size
            _imagePanelMaxLblSize = new Size(IMAGE_PANEL_MAX_LABEL_WIDTH, IMAGE_PANEL_MAX_HEIGHT),
            _imagePanelMedLblSize = new Size(IMAGE_PANEL_MED_LABEL_WIDTH, IMAGE_PANEL_MED_HEIGHT),
            _imagePanelMinLblSize = new Size(IMAGE_PANEL_MIN_LABEL_WIDTH, IMAGE_PANEL_MIN_HEIGHT);
        #endregion
        #region Stacked Constants
        ///
        /// Stacked Panel constants
        /// 
        protected const int
            STACKED_MAX_WIDTH = 96, STACKED_MAX_HEIGHT = 135,
            STACKED_MED_WIDTH = 90, STACKED_MED_HEIGHT = 110,
            STACKED_MIN_WIDTH = 70, STACKED_MIN_HEIGHT = 95;

        protected const double
            STACKED_IMAGE_RATIO = 3.0 / 4.0,
            STACKED_LABEL_RATIO = (1.0 - STACKED_IMAGE_RATIO),
            STACKED_PANEL_RATIO = (double)STACKED_MAX_HEIGHT / (double)STACKED_MAX_WIDTH;


        protected static readonly Size
            _stackedPanelMaxSize = new Size(STACKED_MAX_WIDTH, STACKED_MAX_HEIGHT),
            _stackedPanelMedSize = new Size(STACKED_MED_WIDTH, STACKED_MED_HEIGHT),
            _stackedPanelMinSize = new Size(STACKED_MIN_WIDTH, STACKED_MIN_HEIGHT);

        private const int
            STACKED_MAX_LABEL_HEIGHT = (int)(STACKED_MAX_HEIGHT * STACKED_LABEL_RATIO),
            STACKED_MED_LABEL_HEIGHT = (int)(STACKED_MED_HEIGHT * STACKED_LABEL_RATIO),
            STACKED_MIN_LABEL_HEIGHT = (int)(STACKED_MIN_HEIGHT * STACKED_LABEL_RATIO);

        private const int
            STACKED_MAX_IMAGE_LENGTH = STACKED_MAX_WIDTH,
            STACKED_MED_IMAGE_LENGTH = STACKED_MED_WIDTH,
            STACKED_MIN_IMAGE_LENGTH = STACKED_MIN_WIDTH;

        protected static readonly Size
            _stackedPanelMaxImgSize = new Size(STACKED_MAX_IMAGE_LENGTH, STACKED_MAX_IMAGE_LENGTH),
            _stackedPanelMedImgSize = new Size(STACKED_MED_IMAGE_LENGTH, STACKED_MED_IMAGE_LENGTH),
            _stackedPanelMinImgSize = new Size(STACKED_MIN_IMAGE_LENGTH, STACKED_MIN_IMAGE_LENGTH);

        protected static readonly Size
            _stackedPanelMaxLblSize = new Size(STACKED_MAX_WIDTH, STACKED_MAX_LABEL_HEIGHT),
            _stackedPanelMedLblSize = new Size(STACKED_MED_WIDTH, STACKED_MED_LABEL_HEIGHT),
            _stackedPanelMinLblSize = new Size(STACKED_MIN_WIDTH, STACKED_MIN_LABEL_HEIGHT);
        #endregion
        #region Text Panel Constants
        ///
        /// Text Panel constants
        /// 
        private const int
            TEXT_PANEL_MAX_WIDTH = 205, TEXT_PANEL_MAX_HEIGHT = 30,
            TEXT_PANEL_MED_WIDTH = 150, TEXT_PANEL_MED_HEIGHT = 30,
            TEXT_PANEL_MIN_WIDTH = 105, TEXT_PANEL_MIN_HEIGHT = 30;

        protected const double
            TEXT_PANEL_LABEL_RATIO = 1.0,
            TEXT_PANEL_IMAGE_RATIO = 0.0,
            TEXT_PANEL_RATIO = (double)TEXT_PANEL_MAX_HEIGHT / (double)TEXT_PANEL_MAX_WIDTH;

        protected static readonly Size
            _textPanelMaxSize = new Size(TEXT_PANEL_MAX_WIDTH, TEXT_PANEL_MAX_HEIGHT),
            _textPanelMedSize = new Size(TEXT_PANEL_MED_WIDTH, TEXT_PANEL_MED_HEIGHT),
            _textPanelMinSize = new Size(TEXT_PANEL_MIN_WIDTH, TEXT_PANEL_MIN_HEIGHT);

        protected static readonly Size
            _textPanelMaxImgSize = new Size(0, 0),
            _textPanelMedImgSize = _textPanelMaxImgSize,
            _textPanelMinImgSize = _textPanelMaxImgSize;

        protected static readonly Size
            _textPanelMaxLblSize = _textPanelMaxSize,
            _textPanelMedLblSize = _textPanelMedSize,
            _textPanelMinLblSize = _textPanelMinSize;
        #endregion
        #endregion
        #region Private Properties
        private DbEntity _dbEntity;
        private SPanelType _sPanelType = SPanelType.Image;
        private SPanelSize _sPanelSize = SPanelSize.Small;
        private DbEntityType _dbEntityType;
        private SpotifyIntegralEntity _spotifyEntity;
        private SpotifyEntityType _spotifyEntityType;
        private string _entityName;
        private bool _existsInDatabase;
        #endregion
        #region Protected Properties
        protected Size MaxLabelSize
        {
            get { return this.SLabel.MaximumSize; }
            set
            {
                try
                {
                    this.SLabel.MaximumSize = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error assigning MaxLabelSize: {ex.Message}");
                }
            }
        }
        protected Size MinLabelSize
        {
            get { return this.SLabel.MinimumSize; }
            set { this.SLabel.MinimumSize = value; }
        }
        /// <summary>
        /// Get/Set the Max Size for the image, based on SPanelType
        /// </summary>
        protected Size MaxImageSize
        {
            get { return SPictureBox.MaximumSize; }
            set
            {
                SPictureBox.MaximumSize = value;
            }
        }

        /// <summary>
        /// Get/Set the Min Size for the image, based on SPanelType
        /// </summary>
        protected Size MinImageSize
        {
            get { return SPictureBox.MinimumSize; }
            set { SPictureBox.MinimumSize = value; }
        }

        protected Size SmallPanelSize
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return _imagePanelMinSize;
                    case SPanelType.Text:
                        return _textPanelMinSize;
                    case SPanelType.StackedImage:
                        return _stackedPanelMinSize;
                    default:
                        return _imagePanelMinSize;
                }
            }
        }
        protected Size MedPanelSize
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return _imagePanelMedSize;
                    case SPanelType.Text:
                        return _textPanelMedSize;
                    case SPanelType.StackedImage:
                        return _stackedPanelMedSize;
                    default:
                        return _imagePanelMedSize;
                }
            }
        }
        protected Size LargePanelSize
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return _imagePanelMaxSize;
                    case SPanelType.Text:
                        return _textPanelMaxSize;
                    case SPanelType.StackedImage:
                        return _stackedPanelMaxSize;
                    default:
                        return _imagePanelMaxSize;
                }
            }
        }

        protected Size SmallLabelSize
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return _imagePanelMinLblSize;
                    case SPanelType.Text:
                        return _textPanelMinSize;
                    case SPanelType.StackedImage:
                        return _stackedPanelMinLblSize;
                    default:
                        return _imagePanelMinLblSize;
                }
            }
        }

        private void SpotifyLabel_Click(object sender, EventArgs e)
        {

        }

        protected Size MedLabelSize
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return _imagePanelMedLblSize;
                    case SPanelType.Text:
                        return _textPanelMedSize;
                    case SPanelType.StackedImage:
                        return _stackedPanelMedLblSize;
                    default:
                        return _imagePanelMedLblSize;
                }
            }
        }
        protected Size LargeLabelSize
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return _imagePanelMaxLblSize;
                    case SPanelType.Text:
                        return _textPanelMaxLblSize;
                    case SPanelType.StackedImage:
                        return _stackedPanelMaxLblSize;
                    default:
                        return _imagePanelMaxLblSize;
                }
            }
        }

        protected Size SmallImageSize
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return _imagePanelMinImgSize;
                    case SPanelType.Text:
                        return _textPanelMinImgSize;
                    case SPanelType.StackedImage:
                        return _stackedPanelMinImgSize;
                    default:
                        return _imagePanelMinImgSize;
                }
            }
        }
        protected Size MedImageSize
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return _imagePanelMedImgSize;
                    case SPanelType.Text:
                        return _textPanelMedImgSize;
                    case SPanelType.StackedImage:
                        return _stackedPanelMedImgSize;
                    default:
                        return _imagePanelMedImgSize;
                }
            }
        }
        protected Size LargeImageSize
        {
            get
            {
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        return _imagePanelMaxImgSize;
                    case SPanelType.Text:
                        return _textPanelMaxImgSize;
                    case SPanelType.StackedImage:
                        return _stackedPanelMaxImgSize;
                    default:
                        return _imagePanelMaxImgSize;
                }
            }
        }

        new public Size Size
        {
            get { return base.Size; }
            set
            {
                base.Size = value;
                this.splitContainer.Size = value;
            }
        }
        /// <summary>
        /// Get/Set the size of the SPanel 
        /// </summary>
        protected Size OldSize
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
                        this.ImageSize = new Size((int)(w * ImageToPanelRatio), h);
                        this.LabelSize = new Size((int)(w * LabelToImageRatio), h);
                        break;
                    case SPanelType.Text:
                        this.ImageSize = new Size((int)(w * ImageToPanelRatio), (int)(h * ImageToPanelRatio));
                        this.LabelSize = value;
                        break;
                    case SPanelType.StackedImage:
                        this.ImageSize = new Size(w, (int)(h * ImageToPanelRatio));
                        this.LabelSize = new Size(w, (int)(h * LabelToImageRatio));
                        break;
                    default:
                        this.ImageSize = new Size((int)(w * ImageToPanelRatio), h);
                        this.LabelSize = new Size((int)(w * LabelToImageRatio), h);
                        break;
                }
                // _resize();
            }
        }
        #endregion
        #region Private Methods
        private void CheckIfInDatabase()
        {
            switch (this.DbEntityType)
            {
                case DbEntityType.Artist:
                    this.ExistsInDatabase = Program.Database.Artists.Contains(this.EntityName, LargeQuery);
                    break;
                case DbEntityType.Album:
                    this.ExistsInDatabase = Program.Database.Albums.Contains(this.EntityName, LargeQuery);
                    break;
                case DbEntityType.Track:
                    this.ExistsInDatabase = Program.Database.Tracks.Contains(this.EntityName, LargeQuery);
                    break;
                case DbEntityType.Genre:
                    this.ExistsInDatabase = Program.Database.Genres.Contains(this.EntityName, LargeQuery);
                    break;
                case DbEntityType.Playlist:
                    this.ExistsInDatabase = Program.Database.Playlists.Contains(this.EntityName, LargeQuery);
                    break;
                case DbEntityType.Tag:
                    this.ExistsInDatabase = Program.Database.Tags.Contains(this.EntityName, LargeQuery);
                    break;
                default:
                    this.ExistsInDatabase = false;
                    break;
            }
        }

        private void _setNewSize()
        {
            switch (this.SPanelSize)
            {
                case SPanelSize.Small:
                    this.Size = this.SmallPanelSize;
                    this.LabelSize = this.SmallLabelSize;
                    this.ImageSize = this.SmallImageSize;
                    break;
                case SPanelSize.Medium:
                    this.Size = this.MedPanelSize;
                    this.LabelSize = this.MedLabelSize;
                    this.ImageSize = this.MedImageSize;
                    break;
                case SPanelSize.Large:
                    this.Size = this.LargePanelSize;
                    this.LabelSize = this.LargeLabelSize;
                    this.ImageSize = this.LargeImageSize;
                    break;
                default:
                    this.Size = this.SmallPanelSize;
                    this.LabelSize = this.SmallLabelSize;
                    this.ImageSize = this.SmallImageSize;
                    break;
            }
        }

        private void _assignEdgeSizes(SPanelType panelType)
        {
            switch (panelType)
            {
                case SPanelType.Image:
                    PictureCollapsed = false;
                    this.splitContainer.Orientation = Orientation.Vertical;
                    this.MaximumSize = _imagePanelMaxSize;
                    this.MinimumSize = _imagePanelMinSize;

                    this.MaxImageSize = _imagePanelMaxImgSize;
                    this.MinImageSize = _imagePanelMinImgSize;

                    this.MaxLabelSize = _imagePanelMaxLblSize;

                    this.MinLabelSize = _imagePanelMinLblSize;

                    this.SplitterDistance = this.ImageSize.Width;
                    break;
                case SPanelType.Text:
                    this.PictureCollapsed = true;
                    this.MaximumSize = _textPanelMaxSize;
                    this.MinimumSize = _textPanelMinSize;

                    this.MaxImageSize = _textPanelMaxImgSize;
                    this.MinImageSize = _textPanelMinImgSize;

                    this.MaxLabelSize = _textPanelMaxLblSize;
                    this.MinLabelSize = _textPanelMinLblSize;
                    break;
                case SPanelType.StackedImage:
                    this.PictureCollapsed = false;
                    this.splitContainer.Orientation = Orientation.Horizontal;
                    this.MaximumSize = _stackedPanelMaxSize;
                    this.MinimumSize = _stackedPanelMinSize;

                    this.MaxImageSize = _stackedPanelMaxImgSize;
                    this.MinImageSize = _stackedPanelMinImgSize;

                    this.MaxLabelSize = _stackedPanelMaxLblSize;
                    this.MinLabelSize = _stackedPanelMinLblSize;

                    this.SplitterDistance = this.ImageSize.Height;
                    break;
                default:
                    this.PictureCollapsed = false;
                    this.splitContainer.Orientation = Orientation.Vertical;

                    this.MaximumSize = _imagePanelMaxSize;
                    this.MinimumSize = _imagePanelMinSize;

                    this.MaxImageSize = _imagePanelMaxImgSize;
                    this.MinImageSize = _imagePanelMinImgSize;

                    this.MaxLabelSize = _imagePanelMaxLblSize;
                    this.MinLabelSize = _imagePanelMinLblSize;
                    break;
            }
        }

        private Size _resizeX(int w, int h, int maxW, int maxH, int minW, int minH)
        {
            w = (w > maxW) ? maxW : w;
            w = (w < minW) ? minW : w;

            h = (h > maxH) ? maxH : h;
            h = (h < minH) ? minH : h;

            return new Size(w, h);
        }

        private void _resizeLabel()
        {
            this.SLabel.Size =
                _resizeX(
                    this.LabelSize.Width, this.LabelSize.Height,
                    this.MaxLabelSize.Width, this.MaxLabelSize.Height,
                    this.MinLabelSize.Width, this.MinLabelSize.Height);
        }
        private void _resizeImage()
        {
            int w, h;
            switch (this.SPanelType)
            {
                case SPanelType.Image:
                    w = (int)(this.Width * ImageToPanelRatio);
                    h = w;
                    break;
                case SPanelType.StackedImage:
                    h = (int)(this.Height * ImageToPanelRatio);
                    w = h;
                    break;
                default:
                    w = ImageSize.Width;
                    h = ImageSize.Height;
                    break;
            }

            this.SPictureBox.Size =

            _resizeX(w, h,
                this.MaxImageSize.Width, this.MaxImageSize.Height,
                this.MinImageSize.Width, this.MinImageSize.Height);

            switch (this.SPanelType)
            {
                case SPanelType.Image:
                    this.SplitterDistance = this.ImageSize.Width;
                    break;
                case SPanelType.StackedImage:
                    this.SplitterDistance = this.ImageSize.Height;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Resize the entire SPanel, then resize the Image and Label
        /// </summary>
        protected void _resize()
        {
            int w = this.Width,
                h = this.Height;

            if (w == 0 && h == 0)
                base.Size = MinimumSize;
            else
            {
                base.Size = _resizeX(w, h, this.MinimumSize.Width, this.MinimumSize.Height, this.MaximumSize.Width, this.MaximumSize.Height);
            }

            _resizeImage();
            _resizeLabel();

        }
        #endregion
        #region EventHandlers
        new public event EventHandler Click
        {
            add
            {
                base.Click += value;
                this.SPictureBox.Click += value;
                this.SLabel.Click += value;
            }
            remove
            {
                base.Click -= value;
                this.SPictureBox.Click -= value;
                this.SLabel.Click -= value;
            }
        }


        private void ctsmi_Import(object sender, EventArgs e)
        {
            bool succeeded = this.ImportEntity();
            if (succeeded)
            {
                MessageBox.Show($"Successfully imported {this.DbEntityType} '{this.Text}' into database");
            }
            else
            {
                MessageBox.Show($"{this.DbEntityType} '{this.Text}' not imported.");
            }

        }

        private void ctsmi_SetGenres(object sender, EventArgs e)
        {

        }

        private void ctsmi_SetTags(object sender, EventArgs e)
        {

        }

        private void ctsmi_AddToList(object sender, EventArgs e)
        {

        }
        #endregion
        #region Public Properties
        public static bool LargeQuery
        {
            get { return Program.Database.LargeQuery; }
            set { Program.Database.LargeQuery = value; }
        }

        public bool ExistsInDatabase
        {
            get { return _existsInDatabase; }
            private set
            {
                _existsInDatabase = value;
                if (value)
                {
                    this.pBoxDbOrSpotify.Image = Resources.CheckMarkBlue1;
                }
                else
                {
                    this.pBoxDbOrSpotify.Image = Resources.Spotify_Icon_Green;
                }
            }
        }
        /// <summary>
        /// Height / Width
        /// </summary>
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

        /// <summary>
        /// Image size / Panel Size
        /// </summary>
        public double ImageToPanelRatio
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

        /// <summary>
        /// 1 - ImageToPanelRatio
        /// </summary>
        public double LabelToImageRatio
        {
            get
            {
                if (this.SPanelType == SPanelType.Text)
                {
                    return TEXT_PANEL_LABEL_RATIO;
                }
                else
                {
                    return 1 - this.ImageToPanelRatio;
                }
            }
        }
        public SpotifyIntegralEntity SpotifyEntity
        {
            get { return this._spotifyEntity; }
            set
            {
                this._spotifyEntity = value;
                this.SLabel.SpotifyEntity = value;
                this.SPictureBox.SpotifyEntity = value;
                if (value != null)
                {
                    this.EntityName = value.Name;
                    this.SpotifyEntityType = value.SpotifyEntityType;
                    SetImage(value);
                    switch (value.SpotifyEntityType)
                    {
                        case SpotifyEntityType.BaseArtist:
                            this.DbEntityType = DbEntityType.Artist;
                            break;
                        case SpotifyEntityType.BaseAlbum:
                            this.DbEntityType = DbEntityType.Album;
                            break;
                        case SpotifyEntityType.BaseTrack:
                            this.DbEntityType = DbEntityType.Track;
                            break;
                        case SpotifyEntityType.BasePlaylist:
                            this.DbEntityType = DbEntityType.Playlist;
                            break;
                        case SpotifyEntityType.FullArtist:
                            this.DbEntityType = DbEntityType.Artist;
                            break;
                        case SpotifyEntityType.FullAlbum:
                            this.DbEntityType = DbEntityType.Album;
                            break;
                        case SpotifyEntityType.FullTrack:
                            this.DbEntityType = DbEntityType.Track;
                            break;
                        case SpotifyEntityType.FullPlaylist:
                            this.DbEntityType = DbEntityType.Playlist;
                            break;
                        case SpotifyEntityType.Artist:
                            this.DbEntityType = DbEntityType.Artist;
                            break;
                        case SpotifyEntityType.Track:
                            this.DbEntityType = DbEntityType.Track;
                            break;
                        case SpotifyEntityType.Album:
                            this.DbEntityType = DbEntityType.Album;
                            break;
                        case SpotifyEntityType.Playlist:
                            this.DbEntityType = DbEntityType.Playlist;
                            break;
                        case SpotifyEntityType.SavedTrack:
                            this.DbEntityType = DbEntityType.Track;
                            break;
                        case SpotifyEntityType.SavedAlbum:
                            break;
                        case SpotifyEntityType.PlaylistTrack:
                            this.DbEntityType = DbEntityType.Track;
                            break;
                        default:
                            this.DbEntityType = DbEntityType.None;
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Size of the image in the SPanel
        /// </summary>
        public Size ImageSize
        {
            get { return this.SPictureBox.Size; }
            set
            {
                this.SPictureBox.Size = value;
                switch (this.SPanelType)
                {
                    case SPanelType.Image:
                        this.splitContainer.Panel1MinSize = value.Width;
                        this.SplitterDistance = value.Width;
                        break;
                    case SPanelType.Text:
                        break;
                    case SPanelType.StackedImage:
                        this.splitContainer.Panel1MinSize = value.Height;
                        this.SplitterDistance = value.Height;
                        break;
                    default:
                        this.splitContainer.Panel1MinSize = value.Width;
                        this.SplitterDistance = value.Width;
                        break;
                }
            }
        }

        public Size LabelSize
        {
            get { return this.SLabel.Size; }
            set { this.SLabel.Size = value; }
        }

        /// <summary>
        /// Get/Set whether to collapse the image.
        /// </summary>
        public bool PictureCollapsed
        {
            get { return this.splitContainer.Panel1Collapsed; }
            set { this.splitContainer.Panel1Collapsed = value; }
        }

        /// <summary>
        /// Where the image ends and the label begins
        /// </summary>
        public int SplitterDistance
        {
            get { return this.splitContainer.SplitterDistance; }
            set { this.splitContainer.SplitterDistance = value; }
        }

        /// <summary>
        /// The image displayed in the SPanel, for the entity that it will display
        /// </summary>
        public Image Image
        {
            get { return this.SPictureBox.Image; }
            set
            {
                try
                {
                    if (this.SPictureBox == null)
                    {
                        this.SPictureBox = new SPicturePox();
                    }
                    this.SPictureBox.Image = value;
                }
                catch (Exception ex)
                {
                    this.SPictureBox.Image = this.SPictureBox.ErrorImage;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Get/Set the text in the Label
        /// </summary>
        public override string Text
        {
            get { return this.SLabel.Text; }
            set { this.SLabel.Text = value; }
        }

        /// <summary>
        /// Represents the type of panel, and changes the Min/Max for the appropriate values upon change.
        /// </summary>
        public SPanelType SPanelType
        {
            get { return this._sPanelType; }
            set
            {
                if (this._sPanelType != value)
                {
                    this._sPanelType = value;
                    _assignEdgeSizes(value);
                    _setNewSize();
                }
            }

        }

        public SPanelSize SPanelSize
        {
            get { return _sPanelSize; }
            set
            {
                if (_sPanelSize != value)
                {
                    _sPanelSize = value;
                    _setNewSize();
                }

            }
        }

        /// <summary>
        /// Tag to identify what the SpotifyEntityType was that this was initialized with
        /// </summary>
        public SpotifyEntityType SpotifyEntityType
        {
            get { return _spotifyEntityType; }
            set
            {
                this._spotifyEntityType = value;
                this.SLabel.SpotifyEntityType = value;
                this.SPictureBox.SpotifyEntityType = value;
            }
        }

        /// <summary>
        /// Tag to identify what DbEntityType the SPanel maps to
        /// </summary>
        public DbEntityType DbEntityType
        {
            get { return this._dbEntityType; }
            set
            {
                this._dbEntityType = value;
                this.SLabel.DbEntityType = value;
                this.SPictureBox.DbEntityType = value;
            }
        }



        public string EntityName
        {
            get { return this.SLabel.Text; }
            set { this.SLabel.Text = value; }
        }

        /// <summary>
        /// Holds a copy of the DbEntity this SPanel represents, if any
        /// </summary>
        public DbEntity DbEntity
        {
            get { return this._dbEntity; }
            set
            {
                try
                {
                    this._dbEntity = value;
                    this.DbEntityType = value.DbEntityType;
                    this.SpotifyEntityType = value.SpotifyType;

                    this.EntityName = value.Name;
                    this.SLabel.DbEntity = value;
                    this.SPictureBox.DbEntity = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error setting DbEntity for SPanel: {ex.Message}");
                }
            }
        }



        #endregion
        #region Constructors

        /// <summary>
        /// Default Constructor, defaults to Image Panel
        /// </summary>
        public SPanel()
        {
            this.SPanelType = DEFAULT_PANEL_TYPE;
            this.SPanelSize = DEFAULT_PANEL_SIZE;
            InitializeComponent();
            this.ExistsInDatabase = false;
            _setNewSize();
            this.EntityName = DEFAULT_ENTITY_NAME;
        }
        private const SpotifyEntityType DEFAULT_SPOTIFY_TYPE = SpotifyEntityType.None;
        private const DbEntityType DEFAULT_DB_ENTITY_TYPE = DbEntityType.None;

        /// <summary>
        /// Construct an empty SPanel by type
        /// </summary>
        /// <param name="panelType"></param>
        public SPanel(string name, SPanelType type = DEFAULT_PANEL_TYPE, SPanelSize size = DEFAULT_PANEL_SIZE, DbEntityType entityType = DbEntityType.None) : this(type, size)
        {
            this.DbEntityType = entityType;
            this.EntityName = name;
            InitializeComponent();
            CheckIfInDatabase();
            _setNewSize();
        }
        private SPanel(DbEntityType type) : this()//, SpotifyEntityType spotifyType)
        {
            this.DbEntityType = type;

        }
        /// <summary>
        /// Main Constructor for SPanel
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="type"></param>
        /// <param name="size"></param>
        /// <param name="clickEvent"></param>
        /// <param name="dbtype"></param>
        /// <param name="spotifyType"></param>
        public SPanel(string entityName, SPanelType type = DEFAULT_PANEL_TYPE, SPanelSize size = DEFAULT_PANEL_SIZE, EventHandler clickEvent = null, DbEntityType dbtype = DEFAULT_DB_ENTITY_TYPE, SpotifyEntityType spotifyType = DEFAULT_SPOTIFY_TYPE)
            : this(entityName, type, size, dbtype)
        {
            this.Click += clickEvent;

            this.SpotifyEntityType = spotifyType;
            this.DbEntityType = dbtype;
            switch (dbtype)
            {
                case DbEntityType.Artist:
                    this.DbEntity = new Artist();
                    break;
                case DbEntityType.Album:
                    this.DbEntity = new Album();
                    break;
                case DbEntityType.Track:
                    this.DbEntity = new Track();
                    break;
                case DbEntityType.Genre:
                    this.DbEntity = new Genre();
                    break;
                case DbEntityType.Tag:
                    this.DbEntity = new Tag();
                    break;
                case DbEntityType.Playlist:
                    this.DbEntity = new Playlist();
                    break;
                default:
                    break;
            }
            switch (spotifyType)
            {
                case SpotifyEntityType.BaseArtist:
                    this.SpotifyEntity = new SpotifyArtist();
                    break;
                case SpotifyEntityType.BaseAlbum:
                    this.SpotifyEntity = new SpotifyAlbum();
                    break;
                case SpotifyEntityType.BaseTrack:
                    this.SpotifyEntity = new SpotifyTrack();
                    break;
                case SpotifyEntityType.BasePlaylist:
                    this.SpotifyEntity = new SpotifyPlaylist();
                    break;
                case SpotifyEntityType.FullArtist:
                    this.SpotifyEntity = new SpotifyFullArtist();
                    break;
                case SpotifyEntityType.FullAlbum:
                    this.SpotifyEntity = new SpotifyFullAlbum();
                    break;
                case SpotifyEntityType.FullTrack:
                    this.SpotifyEntity = new SpotifyFullTrack();
                    break;
                case SpotifyEntityType.FullPlaylist:
                    this.SpotifyEntity = new SpotifyFullPlaylist();
                    break;
                default:
                    break;
            }

        }


        private SPanel(SPanelType type, SPanelSize size, EventHandler clickevent = null) : this()
        {
            this.SPanelType = type;
            this.SPanelSize = size;
            this.Click += clickevent;
        }
        /// <summary>
        /// Construct a simple SPanel from any DbEntity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(DbEntity entity, SPanelType type = DEFAULT_PANEL_TYPE, SPanelSize size = DEFAULT_PANEL_SIZE, EventHandler clickEvent = null) : this(type, size, clickEvent)
        {
            this.DbEntity = entity;
            CheckIfInDatabase();

        }

        /// <summary>
        /// Construct an SPanel from a Spotify Entity
        /// </summary>
        /// <param name="spotifyEntity"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(SpotifyIntegralEntity spotifyEntity, SPanelType type = DEFAULT_PANEL_TYPE, SPanelSize size = DEFAULT_PANEL_SIZE, EventHandler clickEvent = null) : this(type, size, clickEvent)
        {
            this.SpotifyEntity = spotifyEntity;
            CheckIfInDatabase();
        }

        #endregion
        #region Public Methods

        private void SetImage(SpotifyIntegralEntity spotifyEntity)
        {
            if (spotifyEntity.CanHaveImages)
            {
                SetImage(((ISpotifyImageList)spotifyEntity).Images);
            }

        }

        /// <summary>
        /// Set the SPanel Image from a spotify Image
        /// </summary>
        /// <param name="spotifyImageBytes"></param>
        public void SetImage(SpotifyImage spotifyImage)
        {
            try
            {
                this.Image = spotifyImage;//.Get();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error assignming SPanel Image: {ex.Message}");
                this.Image = Resources.MusicNote;
            }
        }

        public void SetImage(List<SpotifyImage> spotifyImages)
        {
            if (spotifyImages != null)
            {
                if (spotifyImages.Count > 0)
                {
                    SetImage(spotifyImages[0]);
                }
                else
                {
                    this.Image = Resources.MusicNote;
                    Console.WriteLine($"SpotifyImage List was empty.");
                }
            }
            else
            {
                this.Image = this.SPictureBox.ErrorImage;
            }
        }

        /// <summary>
        /// Import the Spotify Entity Represented by this SPanl
        /// </summary>
        /// <returns></returns>
        public bool ImportEntity()
        {
            try
            {
                if (this.SpotifyEntity == null)
                    return false;
                else
                    return Importer.ImportFromSpotify(this.SpotifyEntity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Importing Entity: {ex.Message}");
                return false;
            }

        }

        #endregion
    }

}

