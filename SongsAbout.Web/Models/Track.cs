using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Track : SaEntity
    {
        protected override string TypeName { get { return "Track"; } }
        private const double MS_TO_MINUTES = 60000d;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }

        [Display(Name = "Artist")]
        [Required(ErrorMessage = "Track must have an Artist.")]
        public int ArtistId { get; set; }

        [Display(Name = "Album")]
        [Required(ErrorMessage = "Track must be part of  an Album.")]
        public int AlbumId { get; set; }

        [DisplayName("Track Name")]
        [Required(ErrorMessage = "Track must have a name.", AllowEmptyStrings = false)]
        [StringLength(150, ErrorMessage ="Track Name is too long")]
        public override string Name { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Can Play")]
        public bool CanPlay { get; set; }

        [Display(Name = "Length")]
        public double LengthMinutes
        {
            get
            {
                return this.DurationMs / MS_TO_MINUTES;
            }
            set
            {
                this.DurationMs = (uint)(value * MS_TO_MINUTES);
            }
        }

        [DefaultValue(0)]
        [Editable(false)]
        public uint DurationMs { get; set; }

        public Artist Artist { get; set; }
        public Album Album { get; set; }

        [Display(Name = "Featured Artist")]
        public List<Artist> Artists { get; set; }
    }
}