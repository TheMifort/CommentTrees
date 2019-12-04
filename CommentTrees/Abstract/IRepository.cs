using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentTrees.Abstract
{
    public interface IRepository<T> : IDisposable
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Predicate<T> predicate);
        Task InsertAsync(T customer);
        Task DeleteAsync(int id);
    }
}