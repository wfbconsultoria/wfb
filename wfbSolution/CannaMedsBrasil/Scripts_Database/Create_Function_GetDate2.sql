
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


