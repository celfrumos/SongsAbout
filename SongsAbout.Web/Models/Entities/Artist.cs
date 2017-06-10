using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Web.Models
{

    [Serializable]
    public partial class Artist : SaIntegralEntity
    {
        #region MappedProperties

        [Key]
        [Column("ArtistId")]
        [IdentityColumn]
        public override int Id { get; set; }

        [Display(Name = "Artist Name")]
        [Required(ErrorMessage = "Artist must have a name")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Artist Name is too long")]
        public override string Name { get; set; }

        [Display(Name = "Artist Biography")]
        [StringLength(500)]
        public string Bio { get; set; }

        [Display(Name = "Profile Picture")]
        [NotMapped]
        public Picture ProfilePic
        {
            get
            {
                if (this.Pictures?.Count > 0)
                    return this.Pictures[0];

                else
                    return null;
            }
            set
            {
                if (this.Pictures?.Count > 0)
                    this.Pictures[0] = value;

                else
                    this.Pictures = new List<Picture>() { value };
            }
        }

        public int? ProfilePicId
        {
            get { return this.ProfilePic?.Id ?? 0; }
        }

        #region ReferenceGroups


        [Display(Name = "Albums", GroupName = "Descendants")]
        public List<Album> Albums { get; set; }

        //[Display(Name = "Tracks", GroupName = "Descendants")]
        //public List<Track> Tracks { get; set; }
        public List<Track> GetArtistTracks(EntityDbContext db)
        {
            throw new NotImplementedException();
        }
        [Display(Name = "Pictures")]
        public List<Picture> Pictures { get; set; }

        #endregion
        #endregion

        #region UnMappedProperties

        [NotMapped]
        public override SaEntityType EntityType => SaEntityType.Artist;


        #region SpotifyUrls


        #endregion

        #endregion

        #region Methods

        private void Initialize(SpotifyFullArtist artist = null, IEnumerable<Album> albums = null)
        {
            try
            {
                this.Albums = new List<Album>();
                this.Id = default(int);
                this.Bio = null;
                this.Genres = new List<Genre>();
                this.Id = default(int);
                this.Keywords = new List<Keyword>();
                this.Name = "";
                this.ProfilePic = null;
                // this.ProfilePicId = default(int);
                this.SpotifyId = null;
                this.Topics = new List<Topic>();
                if (artist != null)
                {
                    this.Name = artist.Name;
                    this.ProfilePic = artist.Images.Count > 0 ? artist.Images[0] : new SpotifyImage();
                    this.SpotifyId = artist.Id;
                    this.Albums = albums?.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new EntityInitializationException<Artist>(ex, this);
            }
        }
        #endregion

        #region Constructors
        public Artist()
        {
            Initialize();
        }

        public Artist(SpotifyArtist artist, IEnumerable<Album> albums = null)
        {
            Initialize(artist?.GetFullVersion(Spotify.WebApi), albums);
        }
        public Artist(SpotifyFullArtist artist, IEnumerable<Album> albums = null)
        {
            Initialize(artist, albums);
        }
        #endregion
    }
}
