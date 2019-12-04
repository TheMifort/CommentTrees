CREATE PROCEDURE [dbo].[DeleteComment]
	@commentId int
AS
	WITH q AS
	(
		SELECT  Id, Item_Id,Comment_Id
		FROM    Comment
		WHERE   Id = @commentId
		UNION ALL
			SELECT  comment.Id,comment.Item_Id,comment.Comment_Id
			FROM    q
			JOIN    Comment comment
			ON      comment.Comment_Id = q.id
	)
	DELETE
	FROM    Comment
	WHERE   EXISTS
	(
		SELECT  Id,Comment_Id
		INTERSECT
		SELECT  Id,Comment_Id
		FROM    q
	)
