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
        public Picture ProfilePic { get; set; }

        [ForeignKey(nameof(ProfilePic))]
        public int ProfilePicId { get; set; }

        //public Picture ProfilePic
        //{
        //    get
        //    {
        //        if (this.Images != null && this.Images.Count > 0)
        //            return this.Images[0];
        //        else
        //            return null;

        //    }
        //    set
        //    {
        //        if (value == null)
        //            return;

        //        value.SaEntityType = SaEntityType.Artist;

        //        if (this.Images != null && this.Images.Count > 0)
        //            this.Images[0] = value;
        //        else
        //            this.Images = new List<Picture>() { value };

        //    }
        //}

        //public int ProfilePicId
        //{
        //    get { return this.ProfilePic?.Id ?? 0; }
        //    set
        //    {
        //        if (this.ProfilePic != null)
        //            this.ProfilePic.Id = value;
        //        else
        //            this.ProfilePic = new Picture() { Id = value };
        //    }
        //}

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

        [Display(Name = "Tracks")]
        public List<Track> Tracks { get; set; }

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
