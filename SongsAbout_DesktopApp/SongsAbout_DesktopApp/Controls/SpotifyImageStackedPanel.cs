using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SongsAbout.Controls
{
    public enum SPanelType
    {
        Image, Text, StackedImage
    }


    public partial class SpotifyImageStackedPanel : SongsAbout.Controls.SpotifyPanel
    {
        private Size _minSize;
        private Size _maxSize;
        
        private Size _imageStackedPanelMaxSize = new Size(105, 135);
        private Size _imageStackedPanelMinSize = new Size(70, 95);

        private Size _imagePanelMaxSize = new Size(200, 134);
        private Size _imagePanelMinSize = new Size(140, 40);

        private Size _textPanelMaxSize = new Size(205, 30);
        private Size _textPanelMinSize = new Size(105, 30);

        private SPanelType _panelType;

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
                base._resize();
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
                base._resize();
            }
        }
        new public SPanelType PanelType
        {
            get { return this._panelType; }
            set
            {
                this._panelType = value;
                if (this._panelType == SPanelType.Text)
                {
                    PictureCollapsed = true;
                }
                else
                {
                    PictureCollapsed = false;
                }
            }
        }

        new public bool PictureCollapsed
        {
            get { return this.splitContainer.Panel1Collapsed; }
            set
            {
                //this.splitContainer.Panel1Collapsed = value;
                // if displaying as text panel
                if (this.splitContainer.Panel1Collapsed = value)
                {
                    this.MinimumSize = _textPanelMinSize;
                    this.MaximumSize = _textPanelMaxSize;
                }
                else
                {
                    // if displaying as image panel
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
            }
        }

        public SpotifyImageStackedPanel()
        {
            InitializeComponent();
        }

        public SpotifyImageStackedPanel(SPanelType type)
        {
            this.PanelType = type;

        }

    }
}
