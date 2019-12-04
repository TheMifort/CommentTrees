using CommentTrees.Models.Database;

namespace CommentTrees.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<Item> ItemRepository { get; }
        IRepository<Comment> CommentRepository { get; }
    }
}