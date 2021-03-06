/****** Object:  Table [dbo].[Albums]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[Album_ArtistId] [int] NOT NULL,
	[AlbumName] [nvarchar](255) NOT NULL,
	[AlbumReleaseDate] [date] NULL,
	[AlbumSpotifyUri] [nvarchar](255) NULL,
	[AlbumCoverArt] [image] NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tracks]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracks](
	[TrackId] [int] IDENTITY(1,1) NOT NULL,
	[TrackName] [nvarchar](255) NOT NULL,
	[TrackSpotifyUri] [nvarchar](255) NULL,
	[TrackLengthMinutes] [float] NULL,
	[TrackCanPlay] [bit] NOT NULL DEFAULT 0,
	[Track_ArtistId] [int] NOT NULL,
	[Track_AlbumId] [int] NOT NULL,
 CONSTRAINT [PK_Tracks] PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artists]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [nvarchar](255) NOT NULL,
	[ArtistBio] [nvarchar](max) NULL,
	[ArtistWebsite] [nvarchar](max) NULL,
	[ArtistSpotifyUri] [nvarchar](255) NULL,
	[ArtistProfilePic] [image] NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlbumGenres]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumGenres](
	[AlbumId] [int] NOT NULL,
	[GenreId] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_AlbumGenres_1] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Genres]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreId] INT Identity NOT NULL,
	[GenreText] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lists]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].Playlists(
	PlaylistId [int] IDENTITY(1,1) NOT NULL,
	PlaylistName [varchar](100) NOT NULL,
	PlaylistSpotifyUri [varchar](100) NULL,
	PlaylistSpotifyId [varchar](100) NULL,
	PlaylistSpotifyHref [varchar](100) NULL,
 CONSTRAINT [PK_Lists] PRIMARY KEY CLUSTERED 
(
	PlaylistId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListTracks]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].PlaylistTracks(
	PlaylistId [int] NOT NULL,
	[TrackId] [int] NOT NULL,
 CONSTRAINT [PK_ListTracks] PRIMARY KEY CLUSTERED 
(
	PlaylistId ASC,
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	TagId INT PRIMARY KEY,
	TagText [nvarchar](50) NOT NULL
);
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[topic_text] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrackArtists]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackArtists](
	[artist_id] [int] NOT NULL,
	[track_id] [int] NOT NULL,
 CONSTRAINT [PK_TrackArtists] PRIMARY KEY CLUSTERED 
(
	[artist_id] ASC,
	[track_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrackGenres]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackGenres](
	[track_id] [int] NOT NULL,
	[genre] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TrackGenres_1] PRIMARY KEY CLUSTERED 
(
	[track_id] ASC,
	[genre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrackTags]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackTags](
	[tag_text] [nvarchar](50) NOT NULL,
	[track_id] [int] NOT NULL,
 CONSTRAINT [PK_TrackTags_1] PRIMARY KEY CLUSTERED 
(
	[tag_text] ASC,
	[track_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrackTopics]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackTopics](
	[topic_id] [int] NOT NULL,
	[track_id] [int] NOT NULL,
 CONSTRAINT [PK_TrackTopics_1] PRIMARY KEY CLUSTERED 
(
	[topic_id] ASC,
	[track_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLists]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLists](
	[userId] [int] NULL,
	[listId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[UserProfilePic] [image] NULL,
	[Bio] [varchar](250) NULL,
	[PasswordHash] [varchar](max) NOT NULL,
	[PhoneNumber] [varchar](10) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NULL,
	[UserName] [varchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Tracks] ADD  CONSTRAINT [DF_Tracks_can_play]  DEFAULT ((0)) FOR [can_play]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [EmailConfirmed]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [TwoFactorEnabled]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [LockoutEnabled]
GO
ALTER TABLE [dbo].[AlbumGenres]  WITH CHECK ADD  CONSTRAINT [FK_AlbumGenres_Albums] FOREIGN KEY([album_id])
REFERENCES [dbo].[Albums] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlbumGenres] CHECK CONSTRAINT [FK_AlbumGenres_Albums]
GO
ALTER TABLE [dbo].[AlbumGenres]  WITH CHECK ADD  CONSTRAINT [FK_AlbumGenres_Genres] FOREIGN KEY([genre])
REFERENCES [dbo].[Genres] ([genre])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlbumGenres] CHECK CONSTRAINT [FK_AlbumGenres_Genres]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_Albums_Artists] FOREIGN KEY([artist_id])
REFERENCES [dbo].[Artists] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_Albums_Artists]
GO
ALTER TABLE [dbo].[ListTracks]  WITH CHECK ADD  CONSTRAINT [FK_ListTracks_Lists] FOREIGN KEY([list_id])
REFERENCES [dbo].[Lists] ([list_id])
GO
ALTER TABLE [dbo].[ListTracks] CHECK CONSTRAINT [FK_ListTracks_Lists]
GO
ALTER TABLE [dbo].[ListTracks]  WITH CHECK ADD  CONSTRAINT [FK_ListTracks_Tracks] FOREIGN KEY([track_id])
REFERENCES [dbo].[Tracks] ([ID])
GO
ALTER TABLE [dbo].[ListTracks] CHECK CONSTRAINT [FK_ListTracks_Tracks]
GO
ALTER TABLE [dbo].[TrackArtists]  WITH CHECK ADD  CONSTRAINT [FK__TrackArtists_Artists] FOREIGN KEY([artist_id])
REFERENCES [dbo].[Artists] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrackArtists] CHECK CONSTRAINT [FK__TrackArtists_Artists]
GO
ALTER TABLE [dbo].[TrackArtists]  WITH CHECK ADD  CONSTRAINT [FK__TrackArtists_Tracks] FOREIGN KEY([track_id])
REFERENCES [dbo].[Tracks] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrackArtists] CHECK CONSTRAINT [FK__TrackArtists_Tracks]
GO
ALTER TABLE [dbo].[TrackGenres]  WITH CHECK ADD  CONSTRAINT [FK_TrackGenres_Genres] FOREIGN KEY([genre])
REFERENCES [dbo].[Genres] ([genre])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrackGenres] CHECK CONSTRAINT [FK_TrackGenres_Genres]
GO
ALTER TABLE [dbo].[TrackGenres]  WITH CHECK ADD  CONSTRAINT [FK_TrackGenres_Tracks] FOREIGN KEY([track_id])
REFERENCES [dbo].[Tracks] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrackGenres] CHECK CONSTRAINT [FK_TrackGenres_Tracks]
GO
ALTER TABLE [dbo].[Tracks]  WITH CHECK ADD  CONSTRAINT [FK_Album_Tracks] FOREIGN KEY([track_album_id])
REFERENCES [dbo].[Albums] ([ID])
GO
ALTER TABLE [dbo].[Tracks] CHECK CONSTRAINT [FK_Album_Tracks]
GO
ALTER TABLE [dbo].[TrackTags]  WITH CHECK ADD  CONSTRAINT [FK_TrackTags_Tags] FOREIGN KEY([tag_text])
REFERENCES [dbo].[Tags] ([tag_text])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrackTags] CHECK CONSTRAINT [FK_TrackTags_Tags]
GO
ALTER TABLE [dbo].[TrackTags]  WITH CHECK ADD  CONSTRAINT [FK_TrackTags_Tracks] FOREIGN KEY([track_id])
REFERENCES [dbo].[Tracks] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrackTags] CHECK CONSTRAINT [FK_TrackTags_Tracks]
GO
ALTER TABLE [dbo].[TrackTopics]  WITH CHECK ADD  CONSTRAINT [FK_TrackTopics_Topics] FOREIGN KEY([topic_id])
REFERENCES [dbo].[Topics] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrackTopics] CHECK CONSTRAINT [FK_TrackTopics_Topics]
GO
ALTER TABLE [dbo].[TrackTopics]  WITH CHECK ADD  CONSTRAINT [FK_TrackTopics_Tracks] FOREIGN KEY([track_id])
REFERENCES [dbo].[Tracks] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrackTopics] CHECK CONSTRAINT [FK_TrackTopics_Tracks]
GO
ALTER TABLE [dbo].[UserLists]  WITH CHECK ADD FOREIGN KEY([listId])
REFERENCES [dbo].[Lists] ([list_id])
GO
ALTER TABLE [dbo].[UserLists]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[GenreExists]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GenreExists]
@genre varchar(255)
AS
BEGIN
	declare @result bit
	IF EXISTS(select * from genres where genre = @genre)
		select @result = 1
	ELSE 
		select @result = 0
	select @result
END

GO
/****** Object:  StoredProcedure [dbo].[LoadArtist]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LoadArtist]
	-- Add the parameters for the stored procedure here
	@name varchar
AS
BEGIN
    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM Artists WHERE name = @name )
		SELECT * FROM Artists WHERE name = @name
	ELSE 
		SELECT 'The artist '+ @name + ' was not found.'
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateInsert_Album]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateInsert_Album]
	-- Add the parameters for the stored procedure here
	@id INT,
	@artist_id INT,
	@name nvarchar(255),
	@al_year date,
	@al_spotify_uri nvarchar(255) = NULL,
	@al_cover_art image = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @id <>0 AND EXISTS (SELECT * FROM Artists as a WHERE a.ID = @id)
		BEGIN
		UPDATE Albums	
				SET artist_id 		= @artist_id, 
					name			= @name,
					al_year			= @al_year,
					al_spotify_uri	= @al_spotify_uri,
					al_cover_art	= @al_cover_art

				WHERE id = @id
		--SELECT @return = 'Updated'
		END
	ELSE IF EXISTS (SELECT * FROM Artists as a WHERE a.name = @name)
		BEGIN
		UPDATE Albums	
				SET artist_id 		= @artist_id, 
					name			= @name,
					al_year			= @al_year,
					al_spotify_uri	= @al_spotify_uri,
					al_cover_art	= @al_cover_art

				WHERE name	= @name
		--SELECT @return = 'Updated'
		END
	ELSE
		BEGIN
		INSERT INTO Albums
			VALUES(@artist_id, @name, @al_year, @al_spotify_uri, @al_cover_art)
		--SELECT @return = 'Inserted'
		END

		--return @return
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateInsert_Artist]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateInsert_Artist]
	-- Add the parameters for the stored procedure here
	@id INT,
	@name nvarchar(255),
	@a_bio nvarchar(max) = NULL,
	@a_website nvarchar(max) = NULL,
	@a_spotify_uri nvarchar(255) = NULL,
	@a_profile_pic image = NULL
	--@return nvarchar(255) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @id <>0 AND EXISTS (SELECT * FROM Artists as a WHERE  a.ID = @id)
		BEGIN
		UPDATE Artists	
				SET name			= @name, 
					a_bio 			= @a_bio, 
					a_website		= @a_website,
					a_spotify_uri	= @a_spotify_uri,
					a_profile_pic	= @a_profile_pic

				WHERE Artists.ID	= @id
		--SELECT @return = 'Updated'
		END
	ELSE IF EXISTS (SELECT * FROM Artists as a WHERE a.name = @name)
		BEGIN
		UPDATE Artists	
				SET name			= @name, 
					a_bio 			= @a_bio, 
					a_website		= @a_website,
					a_spotify_uri	= @a_spotify_uri,
					a_profile_pic	= @a_profile_pic

				WHERE Artists.name	= @name
		--SELECT @return = 'Updated'
		END
	ELSE
		BEGIN
		INSERT INTO Artists
			VALUES(@name, @a_bio, @a_website, @a_spotify_uri, @a_profile_pic)
		--SELECT @return = 'Inserted'
		END

		--return @return
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateInsert_Track]    Script Date: 1/24/2017 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateInsert_Track]
	-- Add the parameters for the stored procedure here
	@id INT,
	@name nvarchar(255),
	@track_spotify_uri nvarchar(255) = NULL,
	@track_length_minutes float = 0,
	@track_artist_id int,
	@can_play bit = 0,
	@track_album_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @id <>0  AND EXISTS (SELECT * FROM Artists as a WHERE a.ID = @id)
		BEGIN
		UPDATE Tracks	
				SET name					= @name,					
					track_spotify_uri		= @track_spotify_uri,
					track_length_minutes	= @track_length_minutes,
					track_artist_id			= @track_artist_id,
					can_play				= @can_play,
					track_album_id			= @track_album_id

				WHERE id = @id
		--SELECT @return = 'Updated'
		END
	ELSE IF EXISTS (SELECT * FROM Artists as a WHERE a.name = @name)
		BEGIN
		UPDATE Tracks	
				SET name					= @name,					
					track_spotify_uri		= @track_spotify_uri,
					track_length_minutes	= @track_length_minutes,
					track_artist_id			= @track_artist_id,
					can_play				= @can_play,
					track_album_id			= @track_album_id

				WHERE name	= @name
		--SELECT @return = 'Updated'
		END
	ELSE
		BEGIN
		INSERT INTO Tracks
			VALUES(@name, @track_spotify_uri, @track_length_minutes, @track_artist_id, @can_play, @track_album_id
			
			)
		--SELECT @return = 'Inserted'
		END

		--return @return
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 == can play
, 0 == can''t play' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tracks', @level2type=N'COLUMN',@level2name=N'can_play'
GO
USE [master]
GO
ALTER DATABASE [SongsAboutSQLDB] SET  READ_WRITE 
GO
