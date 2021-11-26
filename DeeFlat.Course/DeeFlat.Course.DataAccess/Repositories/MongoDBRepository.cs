using DeeFlat.Abstractions.Abstractions;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.Course.DataAccess.DBSettings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Course.DataAccess.Repositories
{
    public class MongoDBRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDBRepository(IDeeFlatCourseDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            var name = nameof(T);
           
            _collection = database.GetCollection<T>(name);
        }

        public async Task<Guid> CreateAsync(T model)
        {
            await _collection.InsertOneAsync(model);

            return model.Id;
        }

        public Task DeleteAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetFirstWhereAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}
