using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CommentTrees.Abstract;
using CommentTrees.Models.Database;
using Dapper;

namespace CommentTrees.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly IDbConnection _dbConnection;

        public CommentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Comment>> GetAsync(int? id = default)
        {
            return await _dbConnection.QueryAsync<Comment>("SelectCommentByItem", new {itemId = id},
                commandType: CommandType.StoredProcedure);
        }

        public async Task InsertAsync(Comment entry)
        {
            await _dbConnection.ExecuteAsync("InsertComment",
                new {text = entry.Text, itemId = entry.ItemId, commentId = entry.CommentId},
                commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            await _dbConnection.ExecuteAsync("DeleteComment",
                new { commentId = id },
                commandType: CommandType.StoredProcedure);
        }
    }
}