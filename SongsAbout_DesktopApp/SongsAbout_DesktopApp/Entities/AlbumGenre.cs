//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SongsAbout.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class AlbumGenre
    {
        public int ID { get; set; }
        public Nullable<int> album_id { get; set; }
        public string genre { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Genre Genre1 { get; set; }
    }
}
