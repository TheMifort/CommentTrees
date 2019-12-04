using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommentTrees.Abstract;
using CommentTrees.Models.Database;

namespace CommentTrees.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        public Task<IEnumerable<Comment>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAsync(Predicate<Comment> predicate)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Comment customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}