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
    
    public partial class Track
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Track()
        {
            this.AlbumTracks = new HashSet<AlbumTrack>();
            this.TrackArtists = new HashSet<TrackArtist>();
            this.TrackGenres = new HashSet<TrackGenre>();
            this.TrackTags = new HashSet<TrackTag>();
            this.TrackTopics = new HashSet<TrackTopic>();
        }
    
        public int ID { get; set; }
        public string track_name { get; set; }
        public string track_spotify_uri { get; set; }
        public Nullable<double> track_length_minutes { get; set; }
        public int track_artist_id { get; set; }
        public string can_play { get; set; }
        public Nullable<int> list_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlbumTrack> AlbumTracks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrackArtist> TrackArtists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrackGenre> TrackGenres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrackTag> TrackTags { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrackTopic> TrackTopics { get; set; }
    }
}
