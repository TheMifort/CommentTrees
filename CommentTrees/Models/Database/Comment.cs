namespace CommentTrees.Models.Database
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ItemId { get; set; }
        public int? CommentId { get; set; }
    }
}