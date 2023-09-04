
CREATE FUNCTION [dbo].[getdate2]()
RETURNS datetime
WITH SCHEMABINDING
AS
begin
DECLARE @getdate datetime
SET @getdate = SYSDATETIMEOFFSET() AT TIME ZONE 'E. South America Standard Time'
RETURN @getdate
end
GO

CREATE FUNCTION [dbo].[getuser2]()
RETURNS nvarchar(256)
WITH SCHEMABINDING
AS
begin
DECLARE @getuser nvarchar(256)
SET @getuser = 'system@system.com'
RETURN @getuser
end
GO

CREATE TABLE [dbo].[_tb_Template](
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
 GO

 CREATE TRIGGER tg_Update_Date_tb_Template
ON _tb_Template
AFTER  UPDATE
AS
BEGIN
SET NOCOUNT ON;
update _tb_Template
set Update_Date = dbo.getdate2()
where
ID = (select i.Id from inserted i)
END
GO