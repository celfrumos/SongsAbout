using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class Picture
    {
        [Key]
        public string SourceFile { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}