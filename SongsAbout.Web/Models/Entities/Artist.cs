using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpotifyAPI.Web.Models;

namespace SongsAbout.Web.Models
{

    [Serializable]
    public partial class Artist : SaEntity, ISaIntegralEntity
    {
        #region MappedProperties

        [Key]
        [Column("ArtistId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Display(Name = "Artist Name")]
        [Required(ErrorMessage = "Artist must have a name")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Artist Name is too long")]
        public override string Name { get; set; }

        [Display(Name = "Artist Biography")]
        [StringLength(500)]
        public string Bio { get; set; }

        [Display(Name = "Profile Picture")]
        [ForeignKey(nameof(ProfilePicId))]
        public Picture ProfilePic { get; set; }

        public int ProfilePicId { get; set; }

        [Display(Name = "Spotify Id")]
        [StringLength(50)]
        public override string SpotifyId { get; set; }

        #region ReferenceGroups

        [Display(GroupName = "Descriptors")]
        public List<Genre> Genres { get; set; }

        [Display(GroupName = "Descriptors")]
        public List<Topic> Topics { get; set; }

        [Display(Name = "Album Keywords", GroupName = "Descriptors")]
        public List<Keyword> Keywords { get; set; }

        [Display(Name = "Albums")]
        public List<Album> Albums { get; set; }

        public List<Picture> Images { get; set; }

        #endregion
        #endregion

        #region UnMappedProperties

        [NotMapped]
        [Display(Name = "Tracks")]
        public List<Track> Tracks
        {
            get
            {
                List<Track> res = new List<Track>();
                try
                {
                    using (var db = new EntityDbContext())
                    {
                        res.AddRange(from t in db.Tracks
                                     where t.ArtistId == this.Id
                                     select t);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return res;
            }
        }


        #region Constants
        [NotMapped]
        public override SaEntityType EntityType => SaEntityType.Artist;

        #endregion

        #region SpotifyUrls


        #endregion

        #endregion

        #region Methods
        public bool DescribedBy(string term)
        {
            return
                  this.Genres.Any(g => g.Name.ToLower().Contains(term.ToLower()))
                  || this.Topics.Any(g => g.Text.ToLower().Contains(term.ToLower()))
                  || this.Keywords.Any(g => g.Text.ToLower().Contains(term.ToLower()));
        }

        private void SetDefaults()
        {
            this.Albums = new List<Album>();
            this.Id = default(int);
            this.Bio = null;
            this.Genres = new List<Genre>();
            this.Id = default(int);
            this.Keywords = new List<Keyword>();
            this.Name = "";
            this.ProfilePic = null;
            this.ProfilePicId = default(int);
            this.SpotifyId = null;
            this.Topics = new List<Topic>();
        }
        #endregion

        #region Constructors
        public Artist()
        {
            SetDefaults();
        }

        public Artist(SpotifyArtist artist, IEnumerable<Album> albums = null)
            : this(artist?.GetFullVersion(Spotify.WebApi), albums)
        {
        }
        public Artist(SpotifyFullArtist artist, IEnumerable<Album> albums = null)
        {
            if (artist == null)
                this.SetDefaults();

            this.Name = artist.Name;
            this.ProfilePic = artist.Images.Count > 0 ? artist.Images[0] : new SpotifyImage();
            this.SpotifyId = artist.Id;
            this.Albums = albums?.ToList();
        }
        #endregion
    }
}
