using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CommentTrees.Abstract;
using CommentTrees.Models.Database;
using Dapper;

namespace CommentTrees.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly IDbConnection _dbConnection;

        public ItemRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Item>> GetAsync(int? id = default)
        {
            if (id != default)
                return await _dbConnection.QueryAsync<Item>("SelectItem", new {itemId = id},
                    commandType: CommandType.StoredProcedure);
            return await _dbConnection.QueryAsync<Item>("SelectItems", commandType: CommandType.StoredProcedure);
        }

        public Task InsertAsync(Item entry)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}