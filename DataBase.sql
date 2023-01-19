CREATE DATABASE [Challenge_DB]
GO
USE [Challenge_DB]
GO
CREATE TABLE [dbo].[Categories](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](100) NULL,
	[creation_date] [date] NULL
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Images](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](100) NULL,
	[url] [varchar](max) NULL,
	[creation_date] [date] NULL
 CONSTRAINT [PK_images] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ImagesCategories](
	[id] [uniqueidentifier] NOT NULL,
	[imagem_id] [uniqueidentifier] NULL,
	[categorie_id] [uniqueidentifier] NULL
 CONSTRAINT [PK_ImagesCategories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ImagesCategories]  WITH CHECK ADD  CONSTRAINT [FK_ImagesCategories_Images] FOREIGN KEY([imagem_id])
REFERENCES [dbo].[Images] ([id])
GO

ALTER TABLE [dbo].[ImagesCategories] CHECK CONSTRAINT [FK_ImagesCategories_Images]
GO

ALTER TABLE [dbo].[ImagesCategories]  WITH CHECK ADD  CONSTRAINT [FK_ImagesCategories_Categories] FOREIGN KEY([categorie_id])
REFERENCES [dbo].[Categories] ([id])
GO

ALTER TABLE [dbo].[ImagesCategories] CHECK CONSTRAINT [FK_ImagesCategories_Categories]
GO
