//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SongsAbout_DesktopApp.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrackTag
    {
        public int ID { get; set; }
        public string tag_text { get; set; }
        public int track_id { get; set; }
    
        public virtual Tag Tag { get; set; }
        public virtual Track Track { get; set; }
    }
}
