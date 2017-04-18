using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongsAbout.Web.Models
{
    public class AutoCompleteResult
    {
        public string Text { get; set; }

        public SaEntityType SaEntityType { get; set; }

        public int SaEntityId { get; set; }

    }
}