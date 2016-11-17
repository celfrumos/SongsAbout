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

        private Size _imageStackedPanelMaxSize = new System.Drawing.Size(105, 135);
        private Size _imageStackedPanelMinSize = new System.Drawing.Size(70, 95);

        private Size _imagePanelMaxSize = new System.Drawing.Size(105, 134);
        private Size _imagePanelMinSize = new System.Drawing.Size(200, 55);

        private Size _textPanelMinSize = new System.Drawing.Size(105, 30);
        private Size _textPanelMaxSize = new System.Drawing.Size(205, 30);

        private SPanelType _panelType;

        public override Size MinimumSize
        {
            get { return _minSize; }
            set { _minSize = value; }
        }
        public override Size MaximumSize
        {
            get { return _maxSize; }
            set { _maxSize = value; }
        }
        public SPanelType PanelType
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

        protected SplitterPanel PicBoxPanel
        {
            get { return this.splitContainer.Panel1; }
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
                    this._minSize = _textPanelMinSize;
                    this._maxSize = _textPanelMaxSize;
                }

                else
                {
                    // if displaying as image panel
                    if (_panelType == SPanelType.StackedImage)
                    {
                        this._minSize = _imageStackedPanelMinSize;
                        this._maxSize = _imageStackedPanelMaxSize;
                    }
                    // if displaying as image panel
                    else
                    {
                        this.splitContainer.SplitterDistance = 70;
                        this._minSize = _imagePanelMinSize;
                        this._maxSize = _imagePanelMaxSize;
                    }
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
