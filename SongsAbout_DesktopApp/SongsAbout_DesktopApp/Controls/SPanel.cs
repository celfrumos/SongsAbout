using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
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
    public enum SPanelSize
    {
        Small, Medium, Large
    }
    public partial class SPanel : UserControl, IEntityControl
    {
        #region Constants
        #region Image Constants
        ///
        // Image Panel constants 
        ///
        protected const double
            IMAGE_PANEL_IMAGE_RATIO = 1.0 / 5.0,
            IMAGE_PANEL_LABEL_RATIO = 1.0 - IMAGE_PANEL_IMAGE_RATIO,
            IMAGE_PANEL_RATIO = (double)IMAGE_PANEL_MAX_HEIGHT / (double)IMAGE_PANEL_MAX_WIDTH;

        protected const int
            IMAGE_PANEL_MAX_WIDTH = 200, IMAGE_PANEL_MAX_HEIGHT = 50,
            IMAGE_PANEL_MED_WIDTH = 175, IMAGE_PANEL_MED_HEIGHT = 45,
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
        private SpotifyEntityType _spotifyEntityType;
        private string _entityName;
        #endregion
        #region Protected Properties
        protected Size MaxLabelSize
        {
            get { return this.SpotifyLabel.MaximumSize; }
            set
            {
                try
                {
                    this.SpotifyLabel.MaximumSize = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error assigning MaxLabelSize");
                }
            }
        }
        protected Size MinLabelSize
        {
            get { return this.SpotifyLabel.MinimumSize; }
            set { this.SpotifyLabel.MinimumSize = value; }
        }
        /// <summary>
        /// Get/Set the Max Size for the image, based on SPanelType
        /// </summary>
        protected Size MaxImageSize
        {
            get { return SpotifyPictureBox.MaximumSize; }
            set
            {
                SpotifyPictureBox.MaximumSize = value;
            }
        }
        /// <summary>
        /// Get/Set the Min Size for the image, based on SPanelType
        /// </summary>
        protected Size MinImageSize
        {
            get { return SpotifyPictureBox.MinimumSize; }
            set { SpotifyPictureBox.MinimumSize = value; }
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
            this.SpotifyLabel.Size =
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

            this.SpotifyPictureBox.Size =

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
        #region Public Properties
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
        public object SpotifyEntity { get; set; }
        /// <summary>
        /// Size of the image in the SPanel
        /// </summary>
        public Size ImageSize
        {
            get { return this.SpotifyPictureBox.Size; }
            set
            {
                this.SpotifyPictureBox.Size = value;
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
            get { return this.SpotifyLabel.Size; }
            set { this.SpotifyLabel.Size = value; }
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
            get { return this.SpotifyPictureBox.Image; }
            set
            {
                try
                {
                    if (this.SpotifyPictureBox == null)
                    {
                        this.SpotifyPictureBox = new SPicturePox();
                    }
                    this.SpotifyPictureBox.Image = value;
                }
                catch (Exception ex)
                {
                    this.SpotifyPictureBox.Image = this.SpotifyPictureBox.ErrorImage;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Get/Set the text in the Label
        /// </summary>
        public override string Text
        {
            get { return this.SpotifyLabel.Text; }
            set
            {
                this.SpotifyLabel.Text = value;
            }
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
                this.SpotifyLabel.SpotifyEntityType = value;
                this.SpotifyPictureBox.SpotifyEntityType = value;
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
                this.SpotifyLabel.DbEntityType = value;
                this.SpotifyPictureBox.DbEntityType = value;
            }
        }

        private EventHandler ClickEvent
        {
            set
            {
                this.Click += value;
                this.SpotifyPictureBox.Click += value;
                this.SpotifyLabel.Click += value;
            }
        }

        public string EntityName
        {
            get { return this._entityName; }
            set
            {
                this._entityName = value;
                this.Text = value;
            }
        }

        public DbEntity DbEntity
        {
            get { return this._dbEntity; }
            set
            {
                try
                {
                    this._dbEntity = value;
                    this.SpotifyLabel.DbEntity = value;
                    this.SpotifyPictureBox.DbEntity = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error setting DbEntity for SPanel: {ex.Message}");
                }
            }
        }


        /// <summary>
        /// Holds a copy of the DbEntity this SPanel represents, if any
        /// </summary>


        #endregion
        #region Constructors

        /// <summary>
        /// Default Constructor, defaults to Image Panel
        /// </summary>
        public SPanel()
        {
            this.SPanelType = SPanelType.Image;
            this.SPanelSize = SPanelSize.Small;
            InitializeComponent();
            _setNewSize();
        }


        /// <summary>
        /// Construct an empty SPanel by type
        /// </summary>
        /// <param name="panelType"></param>
        public SPanel(SPanelType panelType = SPanelType.Image, SPanelSize panelSize = SPanelSize.Small)
        {
            this.SPanelType = panelType;
            this.SPanelSize = panelSize;
            InitializeComponent();
            _setNewSize();
        }

        /// <summary>
        /// Set the SPanel Image from a spotify Image
        /// </summary>
        /// <param name="spotifyImageBytes"></param>
        public void setImage(SpotifyAPI.Web.Models.Image spotifyImage)
        {
            try
            {
                this.Image = Importer.ImportSpotifyImage(spotifyImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error assignming SPanel Image: {ex.Message}");
                this.Image = Resources.MusicNote;
            }
        }

        public void setImage(List<SpotifyAPI.Web.Models.Image> spotifyImages)
        {
            if (spotifyImages.Count > 0)
            {
                setImage(spotifyImages[0]);
            }
            else
            {
                this.Image = Resources.MusicNote;
                Console.WriteLine($"SpotifyImage List came up empty.");
            }
        }
        /// <summary>
        /// Set the SPanel Image from the downloaded bytes
        /// </summary>
        /// <param name="spotifyImageBytes"></param>
        public void setImage(byte[] spotifyImageBytes)
        {
            try
            {
                this.Image = Converter.ImageFromBytes(spotifyImageBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error assignming SPanel Image: {ex.Message}");
                this.Image = Resources.MusicNote;
            }
        }

        /// <summary>
        /// Main Constructor for SPanel
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        /// <param name="tag"></param>
        /// <param name="dbtype"></param>
        /// <param name="spotifyType"></param>
        public SPanel(string entityName, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null, object entity = null,
          DbEntityType dbtype = DbEntityType.None, SpotifyEntityType spotifyType = SpotifyEntityType.None) : this(type, size)
        {
            this.EntityName = entityName;
            this.ClickEvent = clickEvent;
            this.SpotifyEntityType = spotifyType;
            this.DbEntityType = dbtype;
            if (entity is DbEntity)
            {
                this.DbEntity = entity as DbEntity;
            }
            else if (this.SpotifyEntity == null)
            {
                this.SpotifyEntity = entity;
            }
        }


        /// <summary>
        /// Construct a simple SPanel from any DbEntity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(DbEntity entity, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
            : this(entity.Name, type, size, clickEvent, entity, entity.DbEntityType, entity.SpotifyType)
        {

        }

        /// <summary>
        /// Construct an SPanel from a DB Artist
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(Artist artist, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
            : this(artist.name, type, size, clickEvent, artist, DbEntityType.Artist)
        {
            this.Image = artist.Image;
        }

        /// <summary>
        /// Construct an SPanel from a DB Album
        /// </summary>
        /// <param name="album"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(Album album, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
            : this(album.name, type, size, clickEvent, album, DbEntityType.Artist)
        {
            this.Image = album.Image;
        }
        /// <summary>
        /// Construct an SPanel from a DB Track
        /// </summary>
        /// <param name="track"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(Track track, SPanelType type = SPanelType.Text, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
            : this(track.name, type, size, clickEvent, track, DbEntityType.Artist)
        {

        }
        /// <summary>
        /// Construct an SPanel from a Spotify FullAlbum
        /// </summary>
        /// <param name="spotifyEntity"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(ISpotifyEntity spotifyEntity, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
            : this(spotifyEntity.Name, type, size, clickEvent, spotifyEntity, DbEntityType.Album, SpotifyEntityType.FullAlbum)
        {
            this.SpotifyEntity = spotifyEntity;
            if (spotifyEntity is ISpotifyFullEntity)
            {
                setImage(((ISpotifyFullEntity)spotifyEntity).Images);

            }
        }

        /// <summary>
        /// Construct an SPanel from a Spotify FullAlbum
        /// </summary>
        /// <param name="album"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(FullAlbum album, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
            : this(album.Name, type, size, clickEvent, album, DbEntityType.Album, SpotifyEntityType.FullAlbum)
        {
            this.SpotifyEntity = album;
            setImage(album.Images);
        }

 
        /// <summary>
        /// Construct an SPanel from a Spotify SimpleAlbum
        /// </summary>
        /// <param name="album"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(SimpleAlbum album, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
         : this(album.Name, type, size, clickEvent, album, DbEntityType.Album, SpotifyEntityType.SimpleAlbum)
        {
            this.SpotifyEntity = album;
            setImage(album.Images);
        }

        /// <summary>
        /// Construct an SPanel from a Spotify FullArtist
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(FullArtist artist, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
         : this(artist.Name, type, size, clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist)
        {
            this.SpotifyEntity = artist;
            setImage(artist.Images);
        }

        /// <summary>
        /// Construct an SPanel from a Spotify SimpleArtist
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(SimpleArtist artist, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
         : this(artist.Name, type, size, clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.SimpleArtist)
        {
            this.SpotifyEntity = artist;
            setImage(Converter.GetFullArtist(artist).Images);
        }



        /// <summary>
        /// Construct an SPanel from a Spotify FullPlaylist
        /// </summary>
        /// <param name="playlist"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(FullPlaylist playlist, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
            : this(playlist.Name, type, size, clickEvent, playlist, DbEntityType.List, SpotifyEntityType.FullPlaylist)
        {
            this.SpotifyEntity = playlist;
            setImage(playlist.Images);
        }

        /// <summary>
        /// Construct an SPanel from a Spotify SimplePlaylist
        /// </summary>
        /// <param name="playlist"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(SimplePlaylist playlist, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
          : this(playlist.Name, type, size, clickEvent, playlist, DbEntityType.List, SpotifyEntityType.SimplePlaylist)
        {
            this.SpotifyEntity = playlist;
            setImage(playlist.Images);
        }

        /// <summary>
        /// Construct an SPanel from a Spotify FullTrack
        /// </summary>
        /// <param name="track"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(FullTrack track, SPanelType type = SPanelType.Text, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
        : this(track.Name, type, size, clickEvent, track, DbEntityType.Track, SpotifyEntityType.FullTrack)
        {
            this.SpotifyEntity = track;
        }

        /// <summary>
        /// Construct an SPanel from a Spotify SimpleTrack
        /// </summary>
        /// <param name="track"></param>
        /// <param name="type"></param>
        /// <param name="clickEvent"></param>
        public SPanel(SimpleTrack track, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
        : this(track.Name, type, size, clickEvent, track, DbEntityType.Track, SpotifyEntityType.SimpleTrack)
        {
            this.SpotifyEntity = track;
        }
        #endregion
        #region Public Methods
        public void Set(string text, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null, object entity = null, DbEntityType dbtype = DbEntityType.None, SpotifyEntityType spotifyType = SpotifyEntityType.None)
        {
            InitializeComponent();
            this.Text = text;
            this.Tag = entity;
            this.ClickEvent = clickEvent;
            this.SpotifyEntityType = spotifyType;
            this.DbEntityType = dbtype;
            _setNewSize();

            if (entity is DbEntity)
            {
                this.DbEntity = entity as DbEntity;
            }
            else if (this.SpotifyEntity == null)
            {
                this.SpotifyEntity = entity;
            }

        }
        public void SetFromSpotifyAlbum(FullAlbum album, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
        {
            this.SpotifyEntity = album;
            Set(album.Name, type, size, clickEvent, album, DbEntityType.Album, SpotifyEntityType.FullAlbum);
            setImage(album.Images);
        }
        public void SetFromSpotifyAlbum(SimpleAlbum album, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
        {
            SetFromSpotifyAlbum(Converter.GetFullAlbum(album), type, size, clickEvent);
        }

        public void SetFromSpotifyArtist(SimpleArtist artist, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
        {
            SetFromSpotifyArtist(Converter.GetFullArtist(artist));
        }
        public void SetFromSpotifyArtist(FullArtist artist, SPanelType type = SPanelType.Image, SPanelSize size = SPanelSize.Small, EventHandler clickEvent = null)
        {
            this.SpotifyEntity = artist;
            this.Set(artist.Name, type, size, clickEvent, artist, DbEntityType.Artist, SpotifyEntityType.FullArtist);
            setImage(artist.Images);
        }


        public bool ImportEntity()
        {
            try
            {
                return Importer.ImportFromSpotify(this.EntityName, this.SpotifyEntity, this.DbEntityType, this.SpotifyEntityType);
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
//namespace SpotifyAPI.Web.Models
//{
//    public interface ISpotifyEntity
//    {
//        string Name { get; set; }
//        string ID { get; set; }
//        string URI { get; set; }

//    }
//    public partial class FullArtist
//    {
//        public FullArtist()
//        {

//        }
//        public void d()
//        {
//            this.
//        }
//    }
//}
