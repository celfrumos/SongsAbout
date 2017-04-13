using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public abstract class SaDescription : SaEntity
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public int DescriptionId { get; set; }

        [Display(Name = "Descriptor")]
        [StringLength(500, ErrorMessage = "Descriptor must have less than 500 characters.")]
        public abstract string Text { get; set; }
        public override string Name
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
    }
}