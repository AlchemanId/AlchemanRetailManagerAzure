CREATE PROCEDURE [dbo].[spUsernameLookup]
	@EmailAddress nvarchar(256) = 0
AS
begin
	set nocount on;
	SELECT FirstName, LastName
	from [dbo].[User]
	where EmailAddress = @EmailAddress
end