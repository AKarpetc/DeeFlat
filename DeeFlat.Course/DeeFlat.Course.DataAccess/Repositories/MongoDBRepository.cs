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
            var name = typeof(T).Name;

            _collection = database.GetCollection<T>(name);
        }

        public async Task<Guid> CreateAsync(T model)
        {
            await _collection.InsertOneAsync(model);

            return model.Id;
        }

        public async Task DeleteAsync(T model)
        {
            await _collection.DeleteOneAsync(x => x.Id == model.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(x => x.Id == id)).FirstOrDefault();
        }

        public async Task<T> GetFirstWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T model)
        {
            await _collection.FindOneAndReplaceAsync(x => x.Id == model.Id, model);
        }
    }
}
