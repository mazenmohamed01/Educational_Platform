USE [master]
GO

/****** Object:  Database [EducationalPlatform]    Script Date: 10/16/2024 11:58:05 PM ******/
CREATE DATABASE [EducationalPlatform]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EducationalPlatform', FILENAME = N'F:\decounment\.net\data\EducationalPlatform.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EducationalPlatform_log', FILENAME = N'F:\decounment\.net\data\EducationalPlatform_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
USE [EducationalPlatform]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 10/16/2024 11:57:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10/16/2024 11:57:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](50) NULL,
	[Image] [nvarchar](max) NULL,
	[IsDelete] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 10/16/2024 11:57:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[CourseName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](8, 2) NULL,
	[level] [nvarchar](50) NULL,
	[CreationDate] [datetime] NULL,
	[Requirements] [nvarchar](max) NULL,
	[content] [nvarchar](max) NULL,
	[cate_id] [int] NULL,
	[instructor_id] [int] NULL,
	[hours] [int] NULL,
	[IsDelete] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[instructor]    Script Date: 10/16/2024 11:57:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[instructor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [varchar](50) NULL,
	[JoinDate] [datetime] NULL,
	[Gender] [varchar](10) NULL,
	[Image] [nvarchar](max) NULL,
	[IsDelete] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 10/16/2024 11:57:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[file_path] [nvarchar](max) NULL,
	[cours_id] [int] NULL,
	[LecuerNumber] [nchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regestration]    Script Date: 10/16/2024 11:57:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regestration](
	[Student_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[star_tdate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Student_id] ASC,
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 10/16/2024 11:57:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[JoinDate] [datetime] NULL,
	[Password] [varchar](max) NULL,
	[Gender] [varchar](10) NULL,
	[BirthDay] [date] NULL,
	[IsDelete] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([Id], [FullName], [Email], [Phone], [Password]) VALUES (1, N'Ahmed Ayman', N'ahmed@gmail.com', N'01157067086', N'123456789')
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CatName], [Image], [IsDelete]) VALUES (1, N'CS', N'cat-1.jpg', N'foles')
INSERT [dbo].[Categories] ([Id], [CatName], [Image], [IsDelete]) VALUES (2, N'IT', N'cat-3.jpg', N'foles')
INSERT [dbo].[Categories] ([Id], [CatName], [Image], [IsDelete]) VALUES (3, N'IS', N'cat-2.jpg', N'foles')
INSERT [dbo].[Categories] ([Id], [CatName], [Image], [IsDelete]) VALUES (6, N'MM', N'course-3.jpg', N'foles')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (1, N'cat-4.jpg', N'c++', N'xsxsxsx', CAST(400.00 AS Decimal(8, 2)), N'Beginner', CAST(N'2024-09-26T22:21:19.067' AS DateTime), N'sxsxs sxsx ', N'xsxs sxsxs xsx ', 6, 1, 20, N'foles     ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (2, N'ABTDB85C989E6831FDB887AB5933680DD4C6C4E4CAEC243F68DAC80F0F6F2106EBD.jpg', N'c++', N'wxwsx', CAST(257.00 AS Decimal(8, 2)), N'Beginner', CAST(N'2024-09-27T03:42:47.477' AS DateTime), N'xwxw', N'xwxw', 2, 1, 5, N'foles     ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (3, N'Screenshot 2022-01-27 061321.png', N'C#', N'cscsc', CAST(215.00 AS Decimal(8, 2)), N'Beginner', CAST(N'2024-09-27T03:46:27.277' AS DateTime), N'dcdc', N'dcdcd', 1, 1, 15, N'foles     ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (4, N'vlcsnap-2024-07-27-10h10m53s232.png', N'Python', N'xece', CAST(215.00 AS Decimal(8, 2)), N'Beginner', CAST(N'2024-09-27T04:13:47.393' AS DateTime), N'cdc', N'dc', 6, 1, 10, N'foles     ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (8, N'about.jpg', N'OOP', N'xxs sxsxs ', CAST(216.00 AS Decimal(8, 2)), N'Intermediate', CAST(N'2024-09-30T11:58:36.217' AS DateTime), N'asasa asa s as as a', N'xax xasa xaxa ', 3, 1, 10, N'foles     ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (9, N'course-3.jpg', N'C#', N'Together with a team of five members, we did an analysis of a library system, including the initial cost, the number of screens, their design, and the time needed to make this system work', CAST(125.15 AS Decimal(8, 2)), N'Beginner', CAST(N'2024-09-30T16:42:55.290' AS DateTime), N'sqsqs', N'qss', 6, 2, 7, N'foles     ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (10, NULL, N'C#', N'dcdc', CAST(2002.00 AS Decimal(8, 2)), N'', CAST(N'2024-10-15T02:58:08.707' AS DateTime), NULL, NULL, NULL, NULL, NULL, N'true      ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (11, N'', NULL, NULL, NULL, NULL, CAST(N'2024-10-15T02:58:12.520' AS DateTime), NULL, NULL, NULL, NULL, NULL, N'true      ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (12, N'carousel-1.jpg', N'C#', N'xxwwxw', CAST(120.00 AS Decimal(8, 2)), N'Beginner', CAST(N'2024-10-15T23:20:30.413' AS DateTime), NULL, NULL, 2, 2, 21, N'foles     ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (13, N'carousel-1.jpg', N'C#', N'xxwwxw', CAST(119.00 AS Decimal(8, 2)), N'Beginner', CAST(N'2024-10-15T23:20:43.543' AS DateTime), NULL, NULL, 2, 2, 21, N'foles     ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (14, N'course-1.jpg', N'df', NULL, CAST(125.15 AS Decimal(8, 2)), N'Beginner', CAST(N'2024-10-16T21:47:34.323' AS DateTime), NULL, NULL, 2, 1, 3, N'true      ')
INSERT [dbo].[Courses] ([Id], [Image], [CourseName], [Description], [Price], [level], [CreationDate], [Requirements], [content], [cate_id], [instructor_id], [hours], [IsDelete]) VALUES (15, N'Screenshot 2022-01-24 230244.png', N'EF', N'azaz', CAST(500.50 AS Decimal(8, 2)), N'Beginner', CAST(N'2024-10-16T23:16:13.803' AS DateTime), N'sxsx', N'sxsx', 6, 1, 23, N'true      ')
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[instructor] ON 

INSERT [dbo].[instructor] ([Id], [FullName], [Email], [Password], [JoinDate], [Gender], [Image], [IsDelete]) VALUES (1, N'Mohmed ', N'mohmed12@gmial.com', N'123', CAST(N'2015-11-12T00:00:00.000' AS DateTime), N'Male', N'team-3.jpg', N'foles     ')
INSERT [dbo].[instructor] ([Id], [FullName], [Email], [Password], [JoinDate], [Gender], [Image], [IsDelete]) VALUES (2, N'Ahmed', N'ahmed@gmail.com', N'123456789', CAST(N'2024-09-26T03:45:53.627' AS DateTime), N'Male', N'team-1.jpg', N'foles     ')
INSERT [dbo].[instructor] ([Id], [FullName], [Email], [Password], [JoinDate], [Gender], [Image], [IsDelete]) VALUES (4, NULL, NULL, NULL, CAST(N'2024-10-15T03:00:57.410' AS DateTime), NULL, NULL, N'true      ')
INSERT [dbo].[instructor] ([Id], [FullName], [Email], [Password], [JoinDate], [Gender], [Image], [IsDelete]) VALUES (5, N'nada', N'ahmedayman8905@gmail.com', N'1234', CAST(N'2024-10-16T02:55:59.940' AS DateTime), N'Female', N'team-4.jpg', N'foles     ')
SET IDENTITY_INSERT [dbo].[instructor] OFF
GO
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (1, N'', NULL, NULL)
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (2, N'lec2 computer graphics.pdf', 1, N'Lec 15                                                                                              ')
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (3, N'Doc1.pdf', 2, N'Lec 15                                                                                              ')
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (8, N'backend content.pdf', 3, NULL)
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (11, N'backend content.pdf', 3, NULL)
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (12, N'backend content.pdf', 3, NULL)
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (16, N'lec2 computer graphics.pdf', 4, N'Lec 15                                                                                              ')
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (18, N'EntityFrameworkCore.pdf', 3, NULL)
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (21, N'class diagram.drawio.pdf', 3, NULL)
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (34, N'.NET Backend Developer Road Map.pdf', 3, NULL)
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (35, N'lec2 computer graphics.pdf', 3, NULL)
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (36, N'lec2 computer graphics.pdf', NULL, N'Lec 5                                                                                               ')
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (37, NULL, NULL, NULL)
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (39, N'Doc1.pdf', 8, N'Lec 1                                                                                               ')
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (40, N'StudentPublish.pdf', 8, N'Lec 2                                                                                               ')
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (41, N'StudentPublish.pdf', 9, N'Lec 5                                                                                               ')
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (43, N'Fatmah Selim.pdf', 14, N'Lec 1                                                                                               ')
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (47, N'Doc1.pdf', 4, N'Lec 1                                                                                               ')
INSERT [dbo].[Material] ([Id], [file_path], [cours_id], [LecuerNumber]) VALUES (48, N'Fatmah Selim.pdf', 15, N'Lec 1                                                                                               ')
SET IDENTITY_INSERT [dbo].[Material] OFF
GO
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (1, 1, CAST(N'2010-12-10' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (1, 2, CAST(N'2024-09-28' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (1, 3, CAST(N'2024-09-28' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (1, 4, CAST(N'2024-09-30' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (2, 1, CAST(N'2024-09-28' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (2, 3, CAST(N'2024-09-30' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (3, 1, CAST(N'2024-09-28' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (4, 1, CAST(N'2024-09-28' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (4, 2, CAST(N'2024-09-30' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (4, 3, CAST(N'2024-09-30' AS Date))
INSERT [dbo].[Regestration] ([Student_id], [course_id], [star_tdate]) VALUES (4, 8, CAST(N'2024-09-30' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FullName], [Email], [Phone], [JoinDate], [Password], [Gender], [BirthDay], [IsDelete]) VALUES (1, N'Ahmed Ayman', N'ahmed.gmail.com', N'01156900419', CAST(N'2014-05-11T00:00:00.000' AS DateTime), N'123456789', N'male', CAST(N'2003-01-28' AS Date), N'foles     ')
INSERT [dbo].[Students] ([Id], [FullName], [Email], [Phone], [JoinDate], [Password], [Gender], [BirthDay], [IsDelete]) VALUES (2, N'aaa', N'ahmed@gmail.com', N'233434', CAST(N'2024-09-06T18:52:00.000' AS DateTime), N'123', N'Male', CAST(N'2024-10-02' AS Date), N'foles     ')
INSERT [dbo].[Students] ([Id], [FullName], [Email], [Phone], [JoinDate], [Password], [Gender], [BirthDay], [IsDelete]) VALUES (3, N'aaa', N'ahmed@gmail.com', N'011570086', CAST(N'2024-09-04T20:56:00.000' AS DateTime), N'12345', N'Male', CAST(N'2024-10-01' AS Date), N'foles     ')
INSERT [dbo].[Students] ([Id], [FullName], [Email], [Phone], [JoinDate], [Password], [Gender], [BirthDay], [IsDelete]) VALUES (4, N'mohmed ahmed', N'ahmed@gmail.com', N'0225951', CAST(N'2024-09-10T23:05:00.000' AS DateTime), N'123456', N'Male', CAST(N'2024-09-23' AS Date), N'foles     ')
INSERT [dbo].[Students] ([Id], [FullName], [Email], [Phone], [JoinDate], [Password], [Gender], [BirthDay], [IsDelete]) VALUES (5, N'Ahmed', N'ahmed@gmail.com', N'0105184', CAST(N'2024-09-03T01:00:00.000' AS DateTime), N'123456789', N'Male', CAST(N'2024-09-18' AS Date), N'foles     ')
INSERT [dbo].[Students] ([Id], [FullName], [Email], [Phone], [JoinDate], [Password], [Gender], [BirthDay], [IsDelete]) VALUES (6, N'Ahmed shendy', N'ahmed.gmail.com', N'01156900419', CAST(N'2024-10-10T22:32:32.900' AS DateTime), N'123456789', N'male', CAST(N'2003-01-28' AS Date), N'foles     ')
INSERT [dbo].[Students] ([Id], [FullName], [Email], [Phone], [JoinDate], [Password], [Gender], [BirthDay], [IsDelete]) VALUES (7, N'Ahmed Ayman', N'ahmed.gmail.com', N'01156900419', CAST(N'2014-05-11T00:00:00.000' AS DateTime), N'123456789', N'male', CAST(N'2003-01-28' AS Date), N'foles     ')
INSERT [dbo].[Students] ([Id], [FullName], [Email], [Phone], [JoinDate], [Password], [Gender], [BirthDay], [IsDelete]) VALUES (8, N'nadaaa', N'ahmed.gmail.com', N'01156900419', CAST(N'2014-05-11T00:00:00.000' AS DateTime), N'123456789', N'male', CAST(N'2003-01-28' AS Date), N'foles     ')
INSERT [dbo].[Students] ([Id], [FullName], [Email], [Phone], [JoinDate], [Password], [Gender], [BirthDay], [IsDelete]) VALUES (9, N'nada', N'ahmed.gmail.com', N'01156900419', CAST(N'2014-05-11T00:00:00.000' AS DateTime), N'123456789', N'male', CAST(N'2003-01-28' AS Date), N'foles     ')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_IsDelete]  DEFAULT ('foles') FOR [IsDelete]
GO
ALTER TABLE [dbo].[Courses] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Courses_IsDelete]  DEFAULT ('foles') FOR [IsDelete]
GO
ALTER TABLE [dbo].[instructor] ADD  DEFAULT (getdate()) FOR [JoinDate]
GO
ALTER TABLE [dbo].[instructor] ADD  CONSTRAINT [DF_instructor_IsDelete]  DEFAULT ('foles') FOR [IsDelete]
GO
ALTER TABLE [dbo].[Regestration] ADD  DEFAULT (getdate()) FOR [star_tdate]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (getdate()) FOR [JoinDate]
GO
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Students_IsDelete]  DEFAULT ('foles') FOR [IsDelete]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK__Courses__cate_id__1920BF5C] FOREIGN KEY([cate_id])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK__Courses__cate_id__1920BF5C]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK__Courses__instruc__1A14E395] FOREIGN KEY([instructor_id])
REFERENCES [dbo].[instructor] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK__Courses__instruc__1A14E395]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK__Material__cours___1CF15040] FOREIGN KEY([cours_id])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK__Material__cours___1CF15040]
GO
ALTER TABLE [dbo].[Regestration]  WITH CHECK ADD  CONSTRAINT [FK__Regestrat__cours__22AA2996] FOREIGN KEY([course_id])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Regestration] CHECK CONSTRAINT [FK__Regestrat__cours__22AA2996]
GO
ALTER TABLE [dbo].[Regestration]  WITH CHECK ADD FOREIGN KEY([Student_id])
REFERENCES [dbo].[Students] ([Id])
GO
