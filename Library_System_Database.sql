USE [library_system]
GO
/****** Object:  Table [dbo].[author_details]    Script Date: 6/2/2023 4:40:29 PM ******/
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
/****** Object:  Table [dbo].[category_details]    Script Date: 6/2/2023 4:40:29 PM ******/
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
/****** Object:  Table [dbo].[master_book_information]    Script Date: 6/2/2023 4:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[master_book_information](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isbn] [varchar](50) NOT NULL,
	[book_name] [varchar](255) NULL,
	[category_id] [int] NULL,
	[sub_category_id] [int] NULL,
	[author_id] [int] NULL,
	[published_year] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sub_category]    Script Date: 6/2/2023 4:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sub_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[main_category_id] [int] NULL,
	[sub_category_name] [varchar](50) NULL,
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

INSERT [dbo].[master_book_information] ([id], [isbn], [book_name], [category_id], [sub_category_id], [author_id], [published_year]) VALUES (2, N'235698', N'History', 2, 3, 1, CAST(N'2020-10-23' AS Date))
INSERT [dbo].[master_book_information] ([id], [isbn], [book_name], [category_id], [sub_category_id], [author_id], [published_year]) VALUES (3, N'2365SS', N'Science', 2, 3, 2, CAST(N'2021-10-23' AS Date))
INSERT [dbo].[master_book_information] ([id], [isbn], [book_name], [category_id], [sub_category_id], [author_id], [published_year]) VALUES (9, N'2365985', N'Figma', 1, 3, 2, CAST(N'2023-06-01' AS Date))
INSERT [dbo].[master_book_information] ([id], [isbn], [book_name], [category_id], [sub_category_id], [author_id], [published_year]) VALUES (13, N'123556G', N'HJKDDSS', 1, 4, 1, CAST(N'2023-06-02' AS Date))
SET IDENTITY_INSERT [dbo].[master_book_information] OFF
GO
SET IDENTITY_INSERT [dbo].[sub_category] ON 

INSERT [dbo].[sub_category] ([id], [main_category_id], [sub_category_name]) VALUES (3, 1, N'ZZX')
INSERT [dbo].[sub_category] ([id], [main_category_id], [sub_category_name]) VALUES (4, 2, N'NMB')
INSERT [dbo].[sub_category] ([id], [main_category_id], [sub_category_name]) VALUES (5, 3, N'NMJK')
INSERT [dbo].[sub_category] ([id], [main_category_id], [sub_category_name]) VALUES (6, 2, N'WQA')
SET IDENTITY_INSERT [dbo].[sub_category] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [unique_isbn]    Script Date: 6/2/2023 4:40:29 PM ******/
ALTER TABLE [dbo].[master_book_information] ADD  CONSTRAINT [unique_isbn] UNIQUE NONCLUSTERED 
(
	[isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[master_book_information]  WITH CHECK ADD FOREIGN KEY([sub_category_id])
REFERENCES [dbo].[sub_category] ([id])
GO
ALTER TABLE [dbo].[master_book_information]  WITH CHECK ADD  CONSTRAINT [FK_master_book_information_author_details] FOREIGN KEY([author_id])
REFERENCES [dbo].[author_details] ([id])
GO
ALTER TABLE [dbo].[master_book_information] CHECK CONSTRAINT [FK_master_book_information_author_details]
GO
ALTER TABLE [dbo].[master_book_information]  WITH CHECK ADD  CONSTRAINT [FK_master_book_information_category_details] FOREIGN KEY([category_id])
REFERENCES [dbo].[category_details] ([id])
GO
ALTER TABLE [dbo].[master_book_information] CHECK CONSTRAINT [FK_master_book_information_category_details]
GO
ALTER TABLE [dbo].[sub_category]  WITH CHECK ADD FOREIGN KEY([main_category_id])
REFERENCES [dbo].[category_details] ([id])
GO
/****** Object:  StoredProcedure [dbo].[SelectallBooks]    Script Date: 6/2/2023 4:40:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectallBooks]
AS
SELECT * FROM dbo.master_book_information
GO;
GO
