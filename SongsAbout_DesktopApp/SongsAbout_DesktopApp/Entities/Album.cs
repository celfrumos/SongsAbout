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
            this.AlbumGenres = new HashSet<AlbumGenre>();
            this.AlbumTracks = new HashSet<AlbumTrack>();
        }
    
        public int ID { get; set; }
        public int artist_id { get; set; }
        public string name { get; set; }
        public string al_year { get; set; }
        public string al_spotify_uri { get; set; }
        public byte[] al_cover_art { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlbumGenre> AlbumGenres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlbumTrack> AlbumTracks { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
