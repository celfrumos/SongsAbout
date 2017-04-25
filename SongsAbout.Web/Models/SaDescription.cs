using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
   [NotMapped]
    public abstract class SaDescription : ISaDescription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DescriptionId { get; set; }

           [NotMapped]
        public virtual string Text { get; set; }
        public string Name
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
    }
}