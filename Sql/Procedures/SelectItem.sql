CREATE PROCEDURE [dbo].[SelectItem]
	@itemId int
AS
	SELECT * FROM Item WHERE Id = @itemId
