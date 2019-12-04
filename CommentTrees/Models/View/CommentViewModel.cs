using System.Collections.Generic;

namespace CommentTrees.Models.View
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}