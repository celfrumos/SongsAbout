namespace SongsAbout.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using SongsAbout.Entities;

    public partial class User : DbSet<User>
    {
        [Key]
        public int u_id { get; set; }

        [Required]
        [StringLength(50)]
        public string u_name { get; set; }

        [StringLength(100)]
        public string u_email { get; set; }

        [Column(TypeName = "image")]
        public byte[] u_profile_pic { get; set; }

        [StringLength(250)]
        public string u_bio { get; set; }

        public List<Playlist> Lists { get; set; }
        
    }
}
