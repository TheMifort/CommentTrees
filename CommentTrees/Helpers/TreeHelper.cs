using System.Collections.Generic;
using System.Linq;
using CommentTrees.Models.Database;
using CommentTrees.Models.View;

namespace CommentTrees.Helpers
{
    public static class TreeHelper
    {
        public static IEnumerable<CommentViewModel> GenerateTree(this IEnumerable<Comment> comments)
        {
            var result = new List<CommentViewModel>();

            var enumerable = comments.ToList();
            foreach (var comment in enumerable)
            {
                if (comment.ItemId != null)
                    result.Add(new CommentViewModel
                    {
                        Id = comment.Id,
                        Text = comment.Text,
                        Comments = enumerable.Where(e => e.CommentId == comment.Id)
                            .SelectMany(e => enumerable.GenerateTree(e.Id))
                    });
            }

            return result;
        }

        public static IEnumerable<CommentViewModel> GenerateTree(this IEnumerable<Comment> comments,
            int? commentId = null, int? itemId = null)
        {
            var result = new List<CommentViewModel>();

            var enumerable = comments.ToList();
            foreach (var comment in enumerable)
            {
                if (comment.Id == commentId || comment.ItemId != null && comment.ItemId == itemId)
                    result.Add(new CommentViewModel
                    {
                        Id = comment.Id,
                        Text = comment.Text,
                        Comments = enumerable.Where(e => e.CommentId == comment.Id)
                            .SelectMany(e => enumerable.GenerateTree(e.Id))
                    });
            }

            return result;
        }
    }
}