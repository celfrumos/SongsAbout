using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Web.Models
{
    [Serializable]
    public partial class Album : SaIntegralEntity
    {
        [NotMapped]
        public override SaEntityType EntityType => SaEntityType.Album;

        [Key]
        [Column("AlbumId")]
        [IdentityColumn]
        public override int Id { get; set; }

        [DisplayName("Album Name")]
        [Required(ErrorMessage = "Album must have a name.", AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Album Name is too long")]
        public override string Name { get; set; }

        [DisplayName("Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [DisplayName("Album Artist")]
        [Required(ErrorMessage = "Album must have an Artist.")]
        //[ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }

        [DisplayName("Main Artist")]
        [NotMapped]
        public Artist Artist
        {
            get
            {
                return this.Artists?.FirstOrDefault(a => a.Id == this.ArtistId);
            }
            set
            {
                if (value is null)
                    return;

                this.ArtistId = value.Id;
                if (this.Artists == null)
                {
                    this.Artists = new List<Artist> { value };
                    return;
                }


                if (this.Artists.Contains(value))
                    return;

                var existing = this.Artists.Where(a => a.Name == value.Name);
                if (existing.Count() > 0)
                {
                    int i = this.Artists.IndexOf(existing.First());
                    this.Artists[i] = value;

                }

            }
        }

        [Display(Name = "Tracks")]
        public List<Track> Tracks { get; set; }

        [Display(Name = "Featured Artists")]
        public List<Artist> Artists { get; set; }

        public Picture AlbumCover { get; set; }

        [Display(Name = "Album Cover")]
        [NotMapped]
        public int? AlbumCoverId
        {
            get
            {
                if (this.Pictures?.Count > 0)
                    return this.Pictures[0]?.Id;

                else
                    return null;
            }
        }

        [Display(Name = "Pictures")]
        public List<Picture> Pictures { get; set; }

        public static Album Convert(SpotifyAlbum album)
        {
            return new Album(album);
        }

        public static Album Convert(SpotifyFullAlbum album)
        {
            return new Album(album);
        }
        private void Initialize(SpotifyFullAlbum album = null, EntityDbContext db = null, bool createArtistIfDoesntExist = false)
        {
            try
            {
                this.Id = default(int);
                this.Genres = new List<Genre>();
                this.Keywords = new List<Keyword>();
                this.Name = album?.Name ?? "";
                this.ReleaseDate = album?.ReleaseDate;
                this.SpotifyId = album?.Id ?? "";
                this.Topics = new List<Topic>();
                this.Tracks = new List<Track>();
                this.AlbumCover = album.Images.Count > 0 ? album.Images[0] : null;

                if (db != null && album.Artists.Count > 0)
                {
                    this.Artist = db.Get<Artist>(album.Artists[0].Name);

                    if (createArtistIfDoesntExist && this.Artist == null)
                        this.Artist = db.Create<Artist>(new Artist(album.Artists[0]));


                    if (this.Artist != null)
                        this.ArtistId = this.Artist.Id;

                }
                else
                {
                    this.Artist = new Artist();
                    this.ArtistId = default(int);
                    this.Artists = new List<Artist>();
                }
            }
            catch (Exception ex)
            {
                throw new EntityInitializationException<Album>(ex, this);
            }
        }

        public Album()
        {
            this.Initialize();
        }
        public Album(SpotifyAlbum album)
            : this()
        {
            Initialize(album?.GetFullVersion(Spotify.WebApi));
        }
        public Album(SpotifyFullAlbum album, EntityDbContext db = null, bool createArtistIfDoesntExist = false)
        {
            this.Initialize(album, db, createArtistIfDoesntExist);
        }
    }
}