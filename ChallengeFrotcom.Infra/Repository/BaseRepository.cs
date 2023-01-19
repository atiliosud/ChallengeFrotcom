using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChallengeFrotcom.Infra.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration context)
        {
            _configuration = context;
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public async Task Add(TEntity entity)
        {
            using (var connection = CreateConnection())
            {
                await connection.InsertAsync<Guid, TEntity>(entity);
            }
        }

        public async Task Delete(Guid id)
        {
            using (var connection = CreateConnection())
            {
                var entity = connection.Get<TEntity>(id);
                await connection.DeleteAsync(entity);
            }
        }

        public async Task<TEntity> Get(Guid id)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.GetAsync<TEntity>(id);
                return result;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (var connection = CreateConnection())
            {
                return await connection.GetListAsync<TEntity>();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var connection = CreateConnection())
            {
                await connection.UpdateAsync(entity);
            }
        }
    }
}
