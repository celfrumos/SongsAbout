using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SongsAbout.Controls;
using SongsAbout.Entities;
using SongsAbout.Classes;
using SongsAbout.Enums;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Forms
{
    public partial class AlbumDisplayForm : SongsAbout.Forms.SForm
    {
        public AlbumDisplayForm()
        {
            InitializeComponent();
        }

        private List<SpotifyTrack> _spotifyTracks;
        private SpotifyAlbum _spotifyAlbum;
        private SpotifyArtist _spotifyArtist;
        public SpotifyArtist SpotifyArtist
        {
            get { return _spotifyArtist; }
            set
            {
                this._spotifyArtist = value;
                this.lblArtist.Text = value.Name;
            }
        }
        public SpotifyAlbum SpotifyAlbum
        {
            get { return _spotifyAlbum; }
            set
            {
                _spotifyAlbum = value;
                this.lblAlbumName.Text = value.Name;
                this.SpotifyArtist = value.ArtistList[0];
                this.SpotifyTracks = value.TrackList;

            }
        }
        
        public List<SpotifyTrack> SpotifyTracks
        {
            get { return _spotifyTracks; }
            set
            {
                this._spotifyTracks = value;
                foreach (var track in value)
                {
                    Control[] row = {
                        new SLabel() { Text = track.Name, SpotifyEntity = track },
                        new SLabel() { Text = Math.Round( (track.DurationMs / 60000d),2).ToString(), SpotifyEntity = track},
                        new SLabel() { Text = track.ArtistList[0].Name , SpotifyEntity = track.ArtistList[0]}
                    };
                    tableLayoutPanel1.Controls.AddRange(row);

                }
            }
        }

        public AlbumDisplayForm(SpotifyAlbum album) : this()
        {
            this.tableLayoutPanel1.SizeChanged += sizeChanged;
            try
            {
                //   this.SpotifyArtist = album.ArtistList[0];
                this.SpotifyAlbum = album;


                try
                {
                    this.sPicturePox1.Image = Importer.ImportSpotifyImage(album.Images[0]);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void sizeChanged(object sender, EventArgs e)
        {
      
        }

        public AlbumDisplayForm(SimpleAlbum album) : this(new SpotifyAlbum(album)) { }
        public AlbumDisplayForm(FullAlbum album) : this(new SpotifyAlbum(album)) { }

        public AlbumDisplayForm(Album album)
        {
            this.lblArtist.Text = album.Artist.Name;
            this.lblAlbumName.Text = album.Name;

        }
    }
}
