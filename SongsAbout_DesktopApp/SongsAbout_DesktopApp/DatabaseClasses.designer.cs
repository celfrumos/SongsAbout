﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SongsAbout_DesktopApp
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SongsAboutSQLDB")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAlbum(Album instance);
    partial void UpdateAlbum(Album instance);
    partial void DeleteAlbum(Album instance);
    partial void InsertArtist(Artist instance);
    partial void UpdateArtist(Artist instance);
    partial void DeleteArtist(Artist instance);
    partial void InsertGenre(Genre instance);
    partial void UpdateGenre(Genre instance);
    partial void DeleteGenre(Genre instance);
    partial void InsertTrackGenre(TrackGenre instance);
    partial void UpdateTrackGenre(TrackGenre instance);
    partial void DeleteTrackGenre(TrackGenre instance);
    partial void InsertTrack(Track instance);
    partial void UpdateTrack(Track instance);
    partial void DeleteTrack(Track instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::SongsAbout_DesktopApp.Properties.Settings.Default.SongsAboutSQLDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Album> Albums
		{
			get
			{
				return this.GetTable<Album>();
			}
		}
		
		public System.Data.Linq.Table<Artist> Artists
		{
			get
			{
				return this.GetTable<Artist>();
			}
		}
		
		public System.Data.Linq.Table<Genre> Genres
		{
			get
			{
				return this.GetTable<Genre>();
			}
		}
		
		public System.Data.Linq.Table<TrackGenre> TrackGenres
		{
			get
			{
				return this.GetTable<TrackGenre>();
			}
		}
		
		public System.Data.Linq.Table<TrackView> TrackViews
		{
			get
			{
				return this.GetTable<TrackView>();
			}
		}
		
		public System.Data.Linq.Table<Track> Tracks
		{
			get
			{
				return this.GetTable<Track>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Albums")]
	public partial class Album : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _album_id = default(int);
		
		private int _artist_id;
		
		private string _al_title;
		
		private string _al_year;
		
		private string _al_spotify_uri;
		
		private EntitySet<Track> _Tracks;
		
		private EntityRef<Artist> _Artist;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onartist_idChanging(int value);
    partial void Onartist_idChanged();
    partial void Onal_titleChanging(string value);
    partial void Onal_titleChanged();
    partial void Onal_yearChanging(string value);
    partial void Onal_yearChanged();
    partial void Onal_spotify_uriChanging(string value);
    partial void Onal_spotify_uriChanged();
    #endregion
		
		public Album()
		{
			this._Tracks = new EntitySet<Track>(new Action<Track>(this.attach_Tracks), new Action<Track>(this.detach_Tracks));
			this._Artist = default(EntityRef<Artist>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_album_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int album_id
		{
			get
			{
				return this._album_id;
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_artist_id", DbType="Int NOT NULL")]
		public int artist_id
		{
			get
			{
				return this._artist_id;
			}
			set
			{
				if ((this._artist_id != value))
				{
					if (this._Artist.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onartist_idChanging(value);
					this.SendPropertyChanging();
					this._artist_id = value;
					this.SendPropertyChanged("artist_id");
					this.Onartist_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_al_title", DbType="NVarChar(255)")]
		public string al_title
		{
			get
			{
				return this._al_title;
			}
			set
			{
				if ((this._al_title != value))
				{
					this.Onal_titleChanging(value);
					this.SendPropertyChanging();
					this._al_title = value;
					this.SendPropertyChanged("al_title");
					this.Onal_titleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_al_year", DbType="NVarChar(4)")]
		public string al_year
		{
			get
			{
				return this._al_year;
			}
			set
			{
				if ((this._al_year != value))
				{
					this.Onal_yearChanging(value);
					this.SendPropertyChanging();
					this._al_year = value;
					this.SendPropertyChanged("al_year");
					this.Onal_yearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_al_spotify_uri", DbType="NVarChar(255)")]
		public string al_spotify_uri
		{
			get
			{
				return this._al_spotify_uri;
			}
			set
			{
				if ((this._al_spotify_uri != value))
				{
					this.Onal_spotify_uriChanging(value);
					this.SendPropertyChanging();
					this._al_spotify_uri = value;
					this.SendPropertyChanged("al_spotify_uri");
					this.Onal_spotify_uriChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Album_Track", Storage="_Tracks", ThisKey="album_id", OtherKey="album_id")]
		public EntitySet<Track> Tracks
		{
			get
			{
				return this._Tracks;
			}
			set
			{
				this._Tracks.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Artist_Album", Storage="_Artist", ThisKey="artist_id", OtherKey="artist_id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Artist Artist
		{
			get
			{
				return this._Artist.Entity;
			}
			set
			{
				Artist previousValue = this._Artist.Entity;
				if (((previousValue != value) 
							|| (this._Artist.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Artist.Entity = null;
						previousValue.Albums.Remove(this);
					}
					this._Artist.Entity = value;
					if ((value != null))
					{
						value.Albums.Add(this);
						this._artist_id = value.artist_id;
					}
					else
					{
						this._artist_id = default(int);
					}
					this.SendPropertyChanged("Artist");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Tracks(Track entity)
		{
			this.SendPropertyChanging();
			entity.Album = this;
		}
		
		private void detach_Tracks(Track entity)
		{
			this.SendPropertyChanging();
			entity.Album = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Artists")]
	public partial class Artist : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _artist_id = default(int);
		
		private string _a_name;
		
		private string _a_bio;
		
		private string _a_website;
		
		private string _a_spotify_uri;
		
		private EntitySet<Album> _Albums;
		
		private EntitySet<Track> _Tracks;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ona_nameChanging(string value);
    partial void Ona_nameChanged();
    partial void Ona_bioChanging(string value);
    partial void Ona_bioChanged();
    partial void Ona_websiteChanging(string value);
    partial void Ona_websiteChanged();
    partial void Ona_spotify_uriChanging(string value);
    partial void Ona_spotify_uriChanged();
    #endregion
		
		public Artist()
		{
			this._Albums = new EntitySet<Album>(new Action<Album>(this.attach_Albums), new Action<Album>(this.detach_Albums));
			this._Tracks = new EntitySet<Track>(new Action<Track>(this.attach_Tracks), new Action<Track>(this.detach_Tracks));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_artist_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int artist_id
		{
			get
			{
				return this._artist_id;
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_a_name", DbType="NVarChar(255)")]
		public string a_name
		{
			get
			{
				return this._a_name;
			}
			set
			{
				if ((this._a_name != value))
				{
					this.Ona_nameChanging(value);
					this.SendPropertyChanging();
					this._a_name = value;
					this.SendPropertyChanged("a_name");
					this.Ona_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_a_bio", DbType="NVarChar(MAX)")]
		public string a_bio
		{
			get
			{
				return this._a_bio;
			}
			set
			{
				if ((this._a_bio != value))
				{
					this.Ona_bioChanging(value);
					this.SendPropertyChanging();
					this._a_bio = value;
					this.SendPropertyChanged("a_bio");
					this.Ona_bioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_a_website", DbType="NVarChar(MAX)")]
		public string a_website
		{
			get
			{
				return this._a_website;
			}
			set
			{
				if ((this._a_website != value))
				{
					this.Ona_websiteChanging(value);
					this.SendPropertyChanging();
					this._a_website = value;
					this.SendPropertyChanged("a_website");
					this.Ona_websiteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_a_spotify_uri", DbType="NVarChar(255)")]
		public string a_spotify_uri
		{
			get
			{
				return this._a_spotify_uri;
			}
			set
			{
				if ((this._a_spotify_uri != value))
				{
					this.Ona_spotify_uriChanging(value);
					this.SendPropertyChanging();
					this._a_spotify_uri = value;
					this.SendPropertyChanged("a_spotify_uri");
					this.Ona_spotify_uriChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Artist_Album", Storage="_Albums", ThisKey="artist_id", OtherKey="artist_id")]
		public EntitySet<Album> Albums
		{
			get
			{
				return this._Albums;
			}
			set
			{
				this._Albums.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Artist_Track", Storage="_Tracks", ThisKey="artist_id", OtherKey="track_artist_id")]
		public EntitySet<Track> Tracks
		{
			get
			{
				return this._Tracks;
			}
			set
			{
				this._Tracks.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Albums(Album entity)
		{
			this.SendPropertyChanging();
			entity.Artist = this;
		}
		
		private void detach_Albums(Album entity)
		{
			this.SendPropertyChanging();
			entity.Artist = null;
		}
		
		private void attach_Tracks(Track entity)
		{
			this.SendPropertyChanging();
			entity.Artist = this;
		}
		
		private void detach_Tracks(Track entity)
		{
			this.SendPropertyChanging();
			entity.Artist = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Genres")]
	public partial class Genre : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _genre;
		
		private EntitySet<TrackGenre> _TrackGenres;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OngenreChanging(string value);
    partial void OngenreChanged();
    #endregion
		
		public Genre()
		{
			this._TrackGenres = new EntitySet<TrackGenre>(new Action<TrackGenre>(this.attach_TrackGenres), new Action<TrackGenre>(this.detach_TrackGenres));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_genre", DbType="NVarChar(255) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string genre
		{
			get
			{
				return this._genre;
			}
			set
			{
				if ((this._genre != value))
				{
					this.OngenreChanging(value);
					this.SendPropertyChanging();
					this._genre = value;
					this.SendPropertyChanged("genre");
					this.OngenreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Genre_TrackGenre", Storage="_TrackGenres", ThisKey="genre", OtherKey="tg_genre")]
		public EntitySet<TrackGenre> TrackGenres
		{
			get
			{
				return this._TrackGenres;
			}
			set
			{
				this._TrackGenres.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_TrackGenres(TrackGenre entity)
		{
			this.SendPropertyChanging();
			entity.Genre1 = this;
		}
		
		private void detach_TrackGenres(TrackGenre entity)
		{
			this.SendPropertyChanging();
			entity.Genre1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TrackGenres")]
	public partial class TrackGenre : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _tg_id = default(int);
		
		private int _track_id;
		
		private string _tg_genre;
		
		private EntityRef<Genre> _Genre1;
		
		private EntityRef<Track> _Track;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ontrack_idChanging(int value);
    partial void Ontrack_idChanged();
    partial void Ontg_genreChanging(string value);
    partial void Ontg_genreChanged();
    #endregion
		
		public TrackGenre()
		{
			this._Genre1 = default(EntityRef<Genre>);
			this._Track = default(EntityRef<Track>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tg_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int tg_id
		{
			get
			{
				return this._tg_id;
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_track_id", DbType="Int NOT NULL")]
		public int track_id
		{
			get
			{
				return this._track_id;
			}
			set
			{
				if ((this._track_id != value))
				{
					if (this._Track.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Ontrack_idChanging(value);
					this.SendPropertyChanging();
					this._track_id = value;
					this.SendPropertyChanged("track_id");
					this.Ontrack_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="genre", Storage="_tg_genre", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string tg_genre
		{
			get
			{
				return this._tg_genre;
			}
			set
			{
				if ((this._tg_genre != value))
				{
					this.Ontg_genreChanging(value);
					this.SendPropertyChanging();
					this._tg_genre = value;
					this.SendPropertyChanged("tg_genre");
					this.Ontg_genreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Genre_TrackGenre", Storage="_Genre1", ThisKey="tg_genre", OtherKey="genre", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Genre Genre1
		{
			get
			{
				return this._Genre1.Entity;
			}
			set
			{
				Genre previousValue = this._Genre1.Entity;
				if (((previousValue != value) 
							|| (this._Genre1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Genre1.Entity = null;
						previousValue.TrackGenres.Remove(this);
					}
					this._Genre1.Entity = value;
					if ((value != null))
					{
						value.TrackGenres.Add(this);
						this._tg_genre = value.genre;
					}
					else
					{
						this._tg_genre = default(string);
					}
					this.SendPropertyChanged("Genre1");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Track_TrackGenre", Storage="_Track", ThisKey="track_id", OtherKey="track_id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Track Track
		{
			get
			{
				return this._Track.Entity;
			}
			set
			{
				Track previousValue = this._Track.Entity;
				if (((previousValue != value) 
							|| (this._Track.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Track.Entity = null;
						previousValue.TrackGenres.Remove(this);
					}
					this._Track.Entity = value;
					if ((value != null))
					{
						value.TrackGenres.Add(this);
						this._track_id = value.track_id;
					}
					else
					{
						this._track_id = default(int);
					}
					this.SendPropertyChanged("Track");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TrackView")]
	public partial class TrackView
	{
		
		private string _track_name;
		
		private string _a_name;
		
		private string _al_title;
		
		private System.Nullable<double> _track_length_minutes;
		
		private string _track_spotify_uri;
		
		public TrackView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_track_name", DbType="NVarChar(255)")]
		public string track_name
		{
			get
			{
				return this._track_name;
			}
			set
			{
				if ((this._track_name != value))
				{
					this._track_name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_a_name", DbType="NVarChar(255)")]
		public string a_name
		{
			get
			{
				return this._a_name;
			}
			set
			{
				if ((this._a_name != value))
				{
					this._a_name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_al_title", DbType="NVarChar(255)")]
		public string al_title
		{
			get
			{
				return this._al_title;
			}
			set
			{
				if ((this._al_title != value))
				{
					this._al_title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_track_length_minutes", DbType="Float")]
		public System.Nullable<double> track_length_minutes
		{
			get
			{
				return this._track_length_minutes;
			}
			set
			{
				if ((this._track_length_minutes != value))
				{
					this._track_length_minutes = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_track_spotify_uri", DbType="NVarChar(255)")]
		public string track_spotify_uri
		{
			get
			{
				return this._track_spotify_uri;
			}
			set
			{
				if ((this._track_spotify_uri != value))
				{
					this._track_spotify_uri = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tracks")]
	public partial class Track : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _track_id;
		
		private int _album_id;
		
		private string _track_name;
		
		private string _track_spotify_uri;
		
		private System.Nullable<double> _track_length_minutes;
		
		private System.Nullable<int> _track_artist_id;
		
		private EntitySet<TrackGenre> _TrackGenres;
		
		private EntityRef<Album> _Album;
		
		private EntityRef<Artist> _Artist;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ontrack_idChanging(int value);
    partial void Ontrack_idChanged();
    partial void Onalbum_idChanging(int value);
    partial void Onalbum_idChanged();
    partial void Ontrack_nameChanging(string value);
    partial void Ontrack_nameChanged();
    partial void Ontrack_spotify_uriChanging(string value);
    partial void Ontrack_spotify_uriChanged();
    partial void Ontrack_length_minutesChanging(System.Nullable<double> value);
    partial void Ontrack_length_minutesChanged();
    partial void Ontrack_artist_idChanging(System.Nullable<int> value);
    partial void Ontrack_artist_idChanged();
    #endregion
		
		public Track()
		{
			this._TrackGenres = new EntitySet<TrackGenre>(new Action<TrackGenre>(this.attach_TrackGenres), new Action<TrackGenre>(this.detach_TrackGenres));
			this._Album = default(EntityRef<Album>);
			this._Artist = default(EntityRef<Artist>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_track_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int track_id
		{
			get
			{
				return this._track_id;
			}
			set
			{
				if ((this._track_id != value))
				{
					this.Ontrack_idChanging(value);
					this.SendPropertyChanging();
					this._track_id = value;
					this.SendPropertyChanged("track_id");
					this.Ontrack_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_album_id", DbType="Int NOT NULL")]
		public int album_id
		{
			get
			{
				return this._album_id;
			}
			set
			{
				if ((this._album_id != value))
				{
					if (this._Album.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onalbum_idChanging(value);
					this.SendPropertyChanging();
					this._album_id = value;
					this.SendPropertyChanged("album_id");
					this.Onalbum_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_track_name", DbType="NVarChar(255)")]
		public string track_name
		{
			get
			{
				return this._track_name;
			}
			set
			{
				if ((this._track_name != value))
				{
					this.Ontrack_nameChanging(value);
					this.SendPropertyChanging();
					this._track_name = value;
					this.SendPropertyChanged("track_name");
					this.Ontrack_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_track_spotify_uri", DbType="NVarChar(255)")]
		public string track_spotify_uri
		{
			get
			{
				return this._track_spotify_uri;
			}
			set
			{
				if ((this._track_spotify_uri != value))
				{
					this.Ontrack_spotify_uriChanging(value);
					this.SendPropertyChanging();
					this._track_spotify_uri = value;
					this.SendPropertyChanged("track_spotify_uri");
					this.Ontrack_spotify_uriChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_track_length_minutes", DbType="Float")]
		public System.Nullable<double> track_length_minutes
		{
			get
			{
				return this._track_length_minutes;
			}
			set
			{
				if ((this._track_length_minutes != value))
				{
					this.Ontrack_length_minutesChanging(value);
					this.SendPropertyChanging();
					this._track_length_minutes = value;
					this.SendPropertyChanged("track_length_minutes");
					this.Ontrack_length_minutesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_track_artist_id", DbType="Int")]
		public System.Nullable<int> track_artist_id
		{
			get
			{
				return this._track_artist_id;
			}
			set
			{
				if ((this._track_artist_id != value))
				{
					if (this._Artist.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Ontrack_artist_idChanging(value);
					this.SendPropertyChanging();
					this._track_artist_id = value;
					this.SendPropertyChanged("track_artist_id");
					this.Ontrack_artist_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Track_TrackGenre", Storage="_TrackGenres", ThisKey="track_id", OtherKey="track_id")]
		public EntitySet<TrackGenre> TrackGenres
		{
			get
			{
				return this._TrackGenres;
			}
			set
			{
				this._TrackGenres.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Album_Track", Storage="_Album", ThisKey="album_id", OtherKey="album_id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Album Album
		{
			get
			{
				return this._Album.Entity;
			}
			set
			{
				Album previousValue = this._Album.Entity;
				if (((previousValue != value) 
							|| (this._Album.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Album.Entity = null;
						previousValue.Tracks.Remove(this);
					}
					this._Album.Entity = value;
					if ((value != null))
					{
						value.Tracks.Add(this);
						this._album_id = value.album_id;
					}
					else
					{
						this._album_id = default(int);
					}
					this.SendPropertyChanged("Album");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Artist_Track", Storage="_Artist", ThisKey="track_artist_id", OtherKey="artist_id", IsForeignKey=true)]
		public Artist Artist
		{
			get
			{
				return this._Artist.Entity;
			}
			set
			{
				Artist previousValue = this._Artist.Entity;
				if (((previousValue != value) 
							|| (this._Artist.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Artist.Entity = null;
						previousValue.Tracks.Remove(this);
					}
					this._Artist.Entity = value;
					if ((value != null))
					{
						value.Tracks.Add(this);
						this._track_artist_id = value.artist_id;
					}
					else
					{
						this._track_artist_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Artist");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_TrackGenres(TrackGenre entity)
		{
			this.SendPropertyChanging();
			entity.Track = this;
		}
		
		private void detach_TrackGenres(TrackGenre entity)
		{
			this.SendPropertyChanging();
			entity.Track = null;
		}
	}
}
#pragma warning restore 1591
