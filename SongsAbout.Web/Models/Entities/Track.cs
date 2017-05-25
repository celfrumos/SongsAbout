using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Mapping;
using System.Data.SqlTypes;
using System.Web;

namespace SongsAbout.Web.Models
{
    [Serializable]
    public class Track : SaIntegralEntity
    {

        #region MappedProperties


        [Key]
        [Column("TrackId")]
        [IdentityColumn]
        public override int Id { get; set; }

        /// <summary>
        /// The Title of this <see cref="Track"/>
        /// </summary>
        [DisplayName("Track Name")]
        [Required(ErrorMessage = "Track must have a name.", AllowEmptyStrings = false)]
        [StringLength(150, ErrorMessage = "Track Name is too long")]
        public override string Name { get; set; }

        /// <summary>
        /// Represents whether or not this <see cref="Track"/> can be played by the user.
        /// </summary>
        [DefaultValue(false)]
        [Display(Name = "Can Play")]
        public bool CanPlay { get; set; }

        /// <summary>
        /// The duration of this <see cref="Track"/> represented in milliseconds. Access <seealso cref="LengthMinutes"/> to display it in minutes.
        /// </summary>
        [DefaultValue(0)]
        [Display(Name = "Duration")]
        public uint DurationMs { get; set; }

        /// <summary>
        /// Represents whether or not this track features Explicit content
        /// </summary>
        [Display(Name = "Explicit", AutoGenerateField = true, AutoGenerateFilter = true)]
        public bool Explicit { get; set; }

        [Required(ErrorMessage = "Track must have an Artist.")]
        public int ArtistId { get; set; }

        /// <summary>
        /// The id of <see cref="Album"/> for this <see cref="Track"/>
        /// </summary>
        [Display(Name = "Album")]
        [Required(ErrorMessage = "Track must be part of an Album.")]
        public int AlbumId { get; set; }

        [Association("FK_Track_Artist", nameof(Track.Id), nameof(ArtistId), IsForeignKey = true)]
        public Artist Artist { get; set; }

        [Association("FK_Track_Album", nameof(Track.Id), nameof(AlbumId), IsForeignKey = true)]
        public Album Album { get; set; }

        #region ReferenceGroups

        [Display(Name = "Artists")]
        public List<Artist> Artists { get; set; }

        #endregion



        #region AudioFeatures
        /// <summary>
        ///	Danceability describes how suitable a track is for dancing based on a combination of musical elements including tempo, rhythm stability, beat strength, and overall regularity. A value of 0.0 is least danceable and 1.0 is most danceable.
        /// </summary>
        public double Danceability { get; set; }

        /// <summary>
        /// Energy is a measure from 0.0 to 1.0 and represents a perceptual measure of intensity and activity. Typically, energetic tracks feel fast, loud, and noisy. For example, death metal has high energy, while a Bach prelude scores low on the scale. Perceptual features contributing to this attribute include dynamic range, perceived loudness, timbre, onset rate, and general entropy.
        /// </summary>
        public double Energy { get; set; }

        /// <summary>
        /// The key the track is in. Integers map to pitches using standard Pitch Class notation. E.g. 0 = C, 1 = C♯/D♭, 2 = D, and so on.
        /// </summary>
        public int Key { get; set; }

        /// <summary>
        /// Mode indicates the modality (major or minor) of a track, the type of scale from which its melodic content is derived. Major is represented by 1 and minor is 0.
        /// </summary>
        public MusicalMode Mode { get; set; }

        /// <summary>
        /// Speechiness detects the presence of spoken words in a track. The more exclusively speech-like the recording (e.g. talk show, audio book, poetry), the closer to 1.0 the attribute value. 
        /// <para>Values above 0.66 describe tracks that are probably made entirely of spoken words.</para> 
        /// <para>Values between 0.33 and 0.66 describe tracks that may contain both music and speech, either in sections or layered, including such cases as rap music. </para>
        /// <para>Values below 0.33 most likely represent music and other non-speech-like tracks.</para>
        /// </summary>
        public double Speechiness { get; set; }

        /// <summary>
        /// A confidence measure from 0.0 to 1.0 of whether the track is acoustic. 1.0 represents high confidence the track is acoustic.
        /// </summary>
        public double Acousticness { get; set; }

        /// <summary>
        /// Predicts whether a track contains no vocals. "Ooh" and "aah" sounds are treated as instrumental in this context. Rap or spoken word tracks are clearly "vocal". The closer the instrumentalness value is to 1.0, the greater likelihood the track contains no vocal content. Values above 0.5 are intended to represent instrumental tracks, but confidence is higher as the value approaches 1.0.
        /// </summary>
        public double Instrumentalness { get; set; }

        /// <summary>
        /// Detects the presence of an audience in the recording. Higher liveness values represent an increased probability that the track was performed live. A value above 0.8 provides strong likelihood that the track is live.
        /// </summary>
        public double Liveness { get; set; }

        /// <summary>
        /// The overall loudness of a track in decibels (dB). Loudness values are averaged across the entire track and are useful for comparing relative loudness of tracks. Loudness is the quality of a sound that is the primary psychological correlate of physical strength (amplitude). Values typical range between -60 and 0 db.
        /// </summary>
        public double Loudness { get; set; }

        /// <summary>
        /// A measure from 0.0 to 1.0 describing the musical positiveness conveyed by a track. 
        /// Tracks with high valence sound more positive (e.g. happy, cheerful, euphoric), while tracks with low valence sound more negative (e.g. sad, depressed, angry).
        /// </summary>
        public double Valence { get; set; }

        /// <summary>
        /// The overall estimated tempo of a track in beats per minute (BPM). In musical terminology, tempo is the speed or pace of a given piece and derives directly from the average beat duration.
        /// </summary>
        public double Tempo { get; set; }

        /// <summary>
        /// An estimated overall time signature of a track. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure).
        /// </summary>
        public int TimeSignature { get; set; }

        #endregion

        #endregion

        #region UnmappedProperties
        #region Constants
        [NotMapped]
        public override SaEntityType EntityType => SaEntityType.Track;

        [NotMapped]
        private const double MS_TO_MINUTES = 60000d;
        #endregion

        /// <summary>
        /// The length of this <see cref="Track"/> represented in minutes
        /// </summary>
        [Display(Name = "Length")]
        public double LengthMinutes
        {
            get { return this.DurationMs / MS_TO_MINUTES; }
            set { this.DurationMs = (uint)(value * MS_TO_MINUTES); }
        }

        [NotMapped]
        public bool IsAcoustic => this.Acousticness >= 0.50;

        [NotMapped]
        public bool IsLive => this.Liveness >= 0.50;

        [NotMapped]
        public bool IsMostlySpoken => this.Speechiness > 0.66;

        [NotMapped]
        public bool ContainsSpeech => this.Speechiness > 0.33;


        #region SpotifyUrls


        /// <summary>
        /// Get the url used to call the API and get the Audio Analysis for this <see cref="Track"/>
        /// </summary>
        [NotMapped]
        private string AnalysisUrl
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {nameof(Track)} '{this.Name}'");

                return $"{Constants.SPOTIFY_API_BASE}/audio-analysis/{this.SpotifyId}";
            }
        }

        /// <summary>
        /// Get the url used to call the API and get the <see cref="AudioFeatures"/> for this <see cref="Track"/>
        /// </summary>
        /// <seealso cref="DownloadAudioFeatures"/>
        /// <seealso cref="GetAudioFeatures"/>
        [NotMapped]
        public string AudioFeaturesUrl
        {
            get
            {
                if (this.SpotifyId == null)
                    throw new Exception($"Spotify Id not found for {nameof(Track)} '{this.Name}'");

                return $"{Constants.SPOTIFY_API_BASE}/audio-features/{this.SpotifyId}";
            }
        }
        #endregion
        #endregion

        #region Methods


        /// <summary>
        /// Download the audio features of this <see cref="Track"/>, and assigns them to the corresponding properties
        /// </summary>
        public void DownloadAudioFeatures()
        {
            this.SetAudioFeatures(Spotify.WebApi.GetAudioFeatures(this.SpotifyId));
        }

        /// <summary>
        /// Get a value tuple representation of the audio features of this  <see cref="Track"/>
        /// </summary>
        /// <returns>Value Tuple Object containing the audio features of this <see cref="Track"/></returns>
        public (double Acousticness, double Danceability, double Energy, double Instrumentaln, double Key, double Liveness, double Loudness, MusicalMode Mode, double Speechiness, double Tempo, double TimeSignature, double Valence) GetAudioFeatures()
        {
            return (
               this.Acousticness,
               this.Danceability,
               this.Energy,
               this.Instrumentalness,
               this.Key,
               this.Liveness,
               this.Loudness,
               this.Mode,
               this.Speechiness,
               this.Tempo,
               this.TimeSignature,
               this.Valence
            );
        }

        public void SetAudioFeatures(SpotifyAPI.Web.Models.AudioFeatures features)
        {
            this.Acousticness =    /**/    features?.Acousticness     /**/ ?? -1;
            this.Danceability =    /**/    features?.Danceability     /**/ ?? -1;
            this.Energy =          /**/    features?.Energy           /**/ ?? -1;
            this.Instrumentalness =/**/    features?.Instrumentalness /**/ ?? -1;
            this.Key =             /**/    features?.Key              /**/ ?? -1;
            this.Liveness =        /**/    features?.Liveness         /**/ ?? -1;
            this.Loudness =        /**/    features?.Loudness         /**/ ?? -1;
            this.Speechiness =     /**/    features?.Speechiness      /**/ ?? -1;
            this.Tempo =           /**/    features?.Tempo            /**/ ?? -1;
            this.TimeSignature =   /**/    features?.TimeSignature    /**/ ?? -1;
            this.Valence =         /**/    features?.Valence          /**/ ?? -1;

            this.Mode = features == null ? MusicalMode.None : ((MusicalMode)features.Mode);
        }

        public string GetKey()
        {
            string key = "";
            switch (this.Key)
            {
                case 0:
                    key = "C, B♯";
                    break;
                case 1:
                    key = "C♯, D♭";
                    break;
                case 2:
                    key = "D";
                    break;
                case 3:
                    key = "D♯, E♭";
                    break;
                case 4:
                    key = "E, F♭";
                    break;
                case 5:
                    key = "F, E♯";
                    break;
                case 6:
                    key = "F♯, G♭";
                    break;
                case 7:
                    key = "G";
                    break;
                case 8:
                    key = "G♯, A♭";
                    break;
                case 9:
                    key = "A";
                    break;
                case 10:
                    key = "A♯, B♭";
                    break;
                case 11:
                    key = "B";
                    break;
                default:
                    break;
            }
            return key;
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Construct a new <see cref="Track"/> with all default values
        /// </summary>
        public Track()
        {
            SetDefaults();
        }

        /// <summary>
        /// Assigns thie default values for all properties, with the specified <see cref="AudioFeatures"/> and <paramref name="canPlay"/> attributes
        /// </summary>
        /// <param name="features">The corresponding <see cref="AudioFeatures"/> to apply to the new <see cref="Track"/></param>
        /// <param name="canPlay">Whether or not the user can play the track</param>
        private void SetDefaults(AudioFeatures features = null, bool canPlay = false)
        {
            this.Album = new Album();
            this.AlbumId = default(int);
            this.Artist = new Artist();
            this.AlbumId = default(int);
            this.SetAudioFeatures(features);
            this.CanPlay = canPlay;
            this.DurationMs = 0;
            this.Explicit = false;
            this.Artists = new List<Artist>();
            this.Genres = new List<Genre>();
            this.SpotifyId = "";
            this.Topics = new List<Topic>();
            this.Id = default(int);
            this.Name = "";

            SetAudioFeatures(features);
        }

        /// <summary>
        /// Construct a new <see cref="Track"/> from an existing <see cref="SpotifyTrack"/>, and assign it the specified <see cref="AudioFeatures"/>
        /// </summary>
        /// <param name="track"></param>
        /// <param name="canPlay"></param>
        /// <param name="downloadAudioFeatures">Specifies wether or not to download the Audio Features for this track. If so, calls </param>
        public Track(SpotifyTrack track, bool canPlay = false, bool downloadAudioFeatures = false)
            : this(track, downloadAudioFeatures ? Spotify.WebApi.GetAudioFeatures(track.Id) : null, canPlay)
        {

        }
        public Track(SpotifyTrack track, AudioFeatures features, int artistId, int albumId, bool canPlay = false, EntityDbContext db = null, bool createArtistifNotExist = false, bool createAlbumIfNotExists = false)
            : this(track, features, canPlay, db, createArtistifNotExist, createAlbumIfNotExists)
        {
            this.ArtistId = artistId;
            this.AlbumId = albumId;
        }
        /// <summary>
        /// Construct a new <see cref="Track"/> from an existing <see cref="SpotifyTrack"/>, and assign it the specified <see cref="AudioFeatures"/>
        /// </summary>
        /// <param name="track">The <see cref="SpotifyTrack"/> from which to copy parameters</param>
        /// <param name="features">The corresponding <see cref="AudioFeatures"/> to apply to the new <see cref="Track"/></param>
        /// <param name="canPlay">Whether or not the user can play the track. Default is false/></param>
        public Track(SpotifyTrack track, AudioFeatures features, bool canPlay = false, EntityDbContext db = null, bool createArtistifNotExist = false, bool createAlbumIfNotExists = false)
        {
            if (track == null)
            {
                SetDefaults(features, canPlay);
            }
            else
            {
                this.Name = track.Name;
                this.DurationMs = (uint)track.DurationMs;
                this.SpotifyId = track.Id;
                this.Explicit = track.Explicit;

                this.CanPlay = canPlay;
                SetAudioFeatures(features);
                if (db != null)
                {
                    if (track.Artists.Count > 0)
                    {
                        this.Artist = db.Get<Artist>(track.Artists[0].Name);
                        if (createArtistifNotExist && this.Artist == null)
                            this.Artist = db.Create<Artist>(new Artist(track.Artists[0]));

                        if (this.Artist != null)
                            this.ArtistId = this.Artist.Id;
                    }

                    if (track.Album != null)
                    {
                        this.Album = db.Get<Album>(track.Album.Name);

                        if (createAlbumIfNotExists && this.Album == null)
                            this.Album = db.Create<Album>(new Album(track.Album));

                        if (this.Album != null)
                            this.AlbumId = this.Album.ArtistId;

                    }
                }
            }
        }

        #endregion

    }
}