USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[AlbumGenres]    Script Date: 11/15/2016 1:47:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AlbumGenres](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[album_id] [int] NULL,
	[genre] [nvarchar](255) NULL,
 CONSTRAINT [PK_AlbumGenres] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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

USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[Albums]    Script Date: 11/15/2016 1:47:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Albums](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[artist_id] [int] NOT NULL,
	[name] [nvarchar](255) NULL,
	[al_year] [nvarchar](4) NULL,
	[al_spotify_uri] [nvarchar](255) NULL,
	[al_cover_art] [image] NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_Albums_Artists] FOREIGN KEY([artist_id])
REFERENCES [dbo].[Artists] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_Albums_Artists]
GO

USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[AlbumTracks]    Script Date: 11/15/2016 1:48:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AlbumTracks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[album_id] [int] NOT NULL,
	[track_id] [int] NOT NULL,
 CONSTRAINT [PK__AlbumTrack] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AlbumTracks]  WITH CHECK ADD  CONSTRAINT [FK__AlbumTracks_Album] FOREIGN KEY([album_id])
REFERENCES [dbo].[Albums] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AlbumTracks] CHECK CONSTRAINT [FK__AlbumTracks_Album]
GO

ALTER TABLE [dbo].[AlbumTracks]  WITH CHECK ADD  CONSTRAINT [FK__AlbumTracks_Track] FOREIGN KEY([track_id])
REFERENCES [dbo].[Tracks] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AlbumTracks] CHECK CONSTRAINT [FK__AlbumTracks_Track]
GO

USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[Genres]    Script Date: 11/15/2016 1:49:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Genres](
	[genre] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[genre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[Artists]    Script Date: 11/15/2016 1:48:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Artists](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[a_bio] [nvarchar](max) NULL,
	[a_website] [nvarchar](max) NULL,
	[a_spotify_uri] [nvarchar](255) NULL,
	[a_profile_pic] [image] NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[Lists]    Script Date: 11/15/2016 1:49:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Lists](
	[list_id] [int] IDENTITY(1,1) NOT NULL,
	[list_name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Lists] PRIMARY KEY CLUSTERED 
(
	[list_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[Tags]    Script Date: 11/15/2016 1:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tags](
	[tag_text] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[tag_text] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[Topics]    Script Date: 11/15/2016 1:50:27 PM ******/
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

	USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[TrackArtists]    Script Date: 11/15/2016 1:50:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrackArtists](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[artist_id] [int] NOT NULL,
	[track_id] [int] NOT NULL,
 CONSTRAINT [PK__ArtistTr__3214EC27A6CDC871] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TrackArtists]  WITH CHECK ADD  CONSTRAINT [FK__ArtistTra__artis__40058253] FOREIGN KEY([artist_id])
REFERENCES [dbo].[Artists] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TrackArtists] CHECK CONSTRAINT [FK__ArtistTra__artis__40058253]
GO

ALTER TABLE [dbo].[TrackArtists]  WITH CHECK ADD  CONSTRAINT [FK__ArtistTra__track__40F9A68C] FOREIGN KEY([track_id])
REFERENCES [dbo].[Tracks] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TrackArtists] CHECK CONSTRAINT [FK__ArtistTra__track__40F9A68C]
GO

USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[TrackGenres]    Script Date: 11/15/2016 1:51:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrackGenres](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[track_id] [int] NOT NULL,
	[genre] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TrackGenres] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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

USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[Tracks]    Script Date: 11/15/2016 1:51:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tracks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[track_spotify_uri] [nvarchar](255) NULL,
	[track_length_minutes] [float] NULL,
	[track_artist_id] [int] NOT NULL,
	[can_play] [nchar](1) NULL,
	[list_id] [int] NULL,
	[track_album_id] [int] NULL,
 CONSTRAINT [PK_Tracks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Tracks] ADD  CONSTRAINT [DF_Tracks_can_play]  DEFAULT (N'n') FOR [can_play]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'y == can play
, n == can''t play' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tracks', @level2type=N'COLUMN',@level2name=N'can_play'
GO

USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[TrackTags]    Script Date: 11/15/2016 1:51:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrackTags](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[tag_text] [nvarchar](50) NULL,
	[track_id] [int] NOT NULL,
 CONSTRAINT [PK_TrackTags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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

USE [SongsAboutSQLDB]
GO

/****** Object:  Table [dbo].[TrackTopics]    Script Date: 11/15/2016 1:52:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrackTopics](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[topic_id] [int] NULL,
	[track_id] [int] NOT NULL,
 CONSTRAINT [PK_TrackTopics] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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

