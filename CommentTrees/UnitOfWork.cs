using System.Data;
using CommentTrees.Abstract;
using CommentTrees.Models.Database;
using CommentTrees.Repositories;

namespace CommentTrees
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Item> ItemRepository { get; }
        public IRepository<Comment> CommentRepository { get; }

        public UnitOfWork(IDbConnection dbConnection)
        {
            ItemRepository = new ItemRepository(dbConnection);
            CommentRepository = new CommentRepository(dbConnection);
        }
    }
}