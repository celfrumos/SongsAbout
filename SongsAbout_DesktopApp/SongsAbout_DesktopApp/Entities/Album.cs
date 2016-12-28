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
    
    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            this.privateTracks = new HashSet<Track>();
            this.privateGenres = new HashSet<Genre>();
        }
    
        public int ID { get; set; }
        private int artist_id { get; set; }
        private string name { get; set; }
        private string al_spotify_uri { get; set; }
        private byte[] al_cover_art { get; set; }
        public Nullable<System.DateTime> al_release_date { private get; set; }
    
        private Artist privateArtist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<Track> privateTracks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<Genre> privateGenres { get; set; }
    }
}
