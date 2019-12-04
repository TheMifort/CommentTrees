CREATE PROCEDURE [dbo].[SelectCommentByItem]
	@itemId int
AS
WITH Recursive (Id, Comment_Id, Item_Id, Text)
AS
(
    SELECT Id, Comment_Id, Item_Id, Text
    FROM Comment comment
    WHERE comment.Item_Id = @itemId
    UNION ALL
    SELECT comment.Id, comment.Comment_Id, comment.Item_Id, comment.Text
    FROM Comment comment
        JOIN Recursive r ON comment.Comment_Id = r.Id
)
SELECT Id, Comment_Id AS CommentId, Item_Id AS ItemId, Text
FROM Recursive r

