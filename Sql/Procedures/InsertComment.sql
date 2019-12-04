CREATE PROCEDURE [dbo].[InsertComment]
	@text NVARCHAR(200),
	@itemId int = NULL,
	@commentId int = NULL
AS
	INSERT INTO Comment (Text,Item_Id,Comment_Id) VALUES(@text,@itemId,@commentId)