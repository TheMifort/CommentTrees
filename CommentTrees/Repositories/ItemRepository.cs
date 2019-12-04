using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommentTrees.Abstract;
using CommentTrees.Models.Database;

namespace CommentTrees.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        public Task<IEnumerable<Item>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetAsync(Predicate<Item> predicate)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Item customer)
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