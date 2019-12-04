using System.Collections.Generic;

namespace CommentTrees.Models.View
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}