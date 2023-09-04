/****** Script para criar tabelas******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[_tb_Template2](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Description] [nvarchar](256) NOT NULL,
	[Active] [bit] NULL DEFAULT ((1)),
	[Show] [bit] NULL DEFAULT ((1)),
	[Locked] [bit] NULL DEFAULT ((0)),
	[Deleted] [bit] NULL DEFAULT ((0)),
	[Insert_Date] [datetime] NULL DEFAULT ([dbo].[getdate2]()),
	[Insert_User] [nvarchar](256) NULL  DEFAULT ([dbo].[getuser2]()),
	[Insert_IP] [nvarchar](256) NULL,
	[Insert_Location] [nvarchar](max) NULL,
	[Update_Date] [datetime] NULL,
	[Update_User] [nvarchar](256) NULL,
	[Update_IP] [nvarchar](256) NULL,
	[Update_Location] [nvarchar](max) NULL,
	[Delete_Date] [datetime] NULL,
	[Delete_User] [nvarchar](256) NULL,
	[Delete_IP] [nvarchar](256) NULL,
	[Delete_Location] [nvarchar](max) NULL)
 