USE [library_system]
GO
/****** Object:  Table [dbo].[author_details]    Script Date: 5/31/2023 8:11:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[author_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[author_name] [varchar](100) NULL,
	[register_number] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category_details]    Script Date: 5/31/2023 8:11:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[master_book_information]    Script Date: 5/31/2023 8:11:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[master_book_information](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isbn] [varchar](50) NOT NULL,
	[book_name] [varchar](255) NULL,
	[category_id] [int] NULL,
	[author_id] [int] NULL,
	[published_year] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[author_details] ON 

INSERT [dbo].[author_details] ([id], [author_name], [register_number]) VALUES (1, N'Dean', 123659)
INSERT [dbo].[author_details] ([id], [author_name], [register_number]) VALUES (2, N'Farook', 5236952)
INSERT [dbo].[author_details] ([id], [author_name], [register_number]) VALUES (3, N'Nazeer', 2369562)
SET IDENTITY_INSERT [dbo].[author_details] OFF
GO
SET IDENTITY_INSERT [dbo].[category_details] ON 

INSERT [dbo].[category_details] ([id], [category_name]) VALUES (1, N'Fictions')
INSERT [dbo].[category_details] ([id], [category_name]) VALUES (2, N'Nonfiction')
INSERT [dbo].[category_details] ([id], [category_name]) VALUES (3, N'Romance')
INSERT [dbo].[category_details] ([id], [category_name]) VALUES (4, N'History')
INSERT [dbo].[category_details] ([id], [category_name]) VALUES (5, N'Science Fiction')
SET IDENTITY_INSERT [dbo].[category_details] OFF
GO
SET IDENTITY_INSERT [dbo].[master_book_information] ON 

INSERT [dbo].[master_book_information] ([id], [isbn], [book_name], [category_id], [author_id], [published_year]) VALUES (1, N'1236596', N'Sand BOX', 1, 1, CAST(N'2022-10-05' AS Date))
INSERT [dbo].[master_book_information] ([id], [isbn], [book_name], [category_id], [author_id], [published_year]) VALUES (2, N'22563S6', N'History of Sand', 2, 1, CAST(N'2022-05-03' AS Date))
INSERT [dbo].[master_book_information] ([id], [isbn], [book_name], [category_id], [author_id], [published_year]) VALUES (3, N'AA2365S', N'Nile History', 2, 2, CAST(N'1994-02-05' AS Date))
SET IDENTITY_INSERT [dbo].[master_book_information] OFF
GO
ALTER TABLE [dbo].[master_book_information]  WITH CHECK ADD  CONSTRAINT [FK_master_book_information_author_details] FOREIGN KEY([id])
REFERENCES [dbo].[author_details] ([id])
GO
ALTER TABLE [dbo].[master_book_information] CHECK CONSTRAINT [FK_master_book_information_author_details]
GO
ALTER TABLE [dbo].[master_book_information]  WITH CHECK ADD  CONSTRAINT [FK_master_book_information_category_details] FOREIGN KEY([id])
REFERENCES [dbo].[category_details] ([id])
GO
ALTER TABLE [dbo].[master_book_information] CHECK CONSTRAINT [FK_master_book_information_category_details]
GO
