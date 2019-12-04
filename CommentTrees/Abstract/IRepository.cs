using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentTrees.Abstract
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAsync(int? id = default);
        Task InsertAsync(T entry);
        Task DeleteAsync(int id);
    }
}