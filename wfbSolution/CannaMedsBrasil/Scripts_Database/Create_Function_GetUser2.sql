
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


