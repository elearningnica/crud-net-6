USE [master]
GO
IF DB_ID (N'crud-net-6') IS NOT NULL
DROP DATABASE [crud-net-6];
GO
CREATE DATABASE [crud-net-6];
GO



USE [crud-net-6]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblStudent]') AND type in (N'U'))
DROP TABLE [dbo].[tblStudent]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[StudentAddress] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_tblStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO








USE [crud-net-6]
GO
SET IDENTITY_INSERT [dbo].[tblStudent] ON 
GO
INSERT [dbo].[tblStudent] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [StudentAddress]) VALUES (1, N'John', N'Doe', CAST(N'2000-11-02' AS Date), N'jdoe@student.com', N'123412341', N'Student address 1')
GO
INSERT [dbo].[tblStudent] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [StudentAddress]) VALUES (2, N'Allan', N'Richards', CAST(N'1990-10-01' AS Date), N'arichards@student.com', N'431212341', N'Students address 2')
GO
SET IDENTITY_INSERT [dbo].[tblStudent] OFF
GO
