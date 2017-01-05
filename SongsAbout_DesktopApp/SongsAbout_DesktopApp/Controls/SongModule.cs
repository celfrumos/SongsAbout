using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SongsAbout.Properties;
using SongsAbout.Classes;
using SongsAbout.Entities;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;
using SpotifyAPI.Local.Enums;
namespace SongsAbout.Controls
{
    public partial class SongModule : UserControl, ISpotifyEntityControl
    {
        private bool _isPlaying = false;
        private SpotifyLocalAPI LocalAPI { get { return Program.LocalAPI; } }
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set
            {
                _isPlaying = value;
                if (value)
                    this.btnPlayPause.SongButtonType = SongButtonType.Pause;
                else
                    this.btnPlayPause.SongButtonType = SongButtonType.Play;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }


        public SpotifyAPI.Local.Models.Track Track { get; set; }

        public string EntityName
        {
            get { return this.SpotifyEntity.Name; }
        }

        public SpotifyIntegralEntity SpotifyEntity { get; set; }

        public SpotifyEntityType SpotifyEntityType { get; set; }


        public event EventHandler SkipForward;
        public event EventHandler SkipBack;
        public event EventHandler PlayPause;

        public SongModule()
        {
            InitializeComponent();
            this.btnSkipForward.Click += OnSkipForward;
            this.btnSkipBack.Click += OnSkipBack;
            this.btnPlayPause.Click += OnPlayPause;
        }
        public async void OnSkipForward(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() => this.LocalAPI.Skip());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async void OnSkipBack(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() => this.LocalAPI.Previous());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async void OnPlayPause(object sender, EventArgs e)
        {
            try
            {
                if (IsPlaying)
                {
                    await this.LocalAPI.Pause();
                    IsPlaying = false;
                }
                else
                {
                    await this.LocalAPI.Play();
                    IsPlaying = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ImportEntity()
        {
            if (this.SpotifyEntity != null)
                Importer.ImportFromSpotify(this.SpotifyEntity);
        }
    }
}
