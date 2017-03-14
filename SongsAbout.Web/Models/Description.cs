using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Description
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DescriptionId { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Description must have less than 500 characters.")]
        public string DescriptionText { get; set; }
    }
}