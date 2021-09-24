using DeeFlat.Abstractions.Abstractions;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.DataAccess
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DeeFlatIs4DbContext _db;
        private readonly DbSet<T> _set;

        public EfRepository(DeeFlatIs4DbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public async Task<Guid> CreateAsync(T model)
        {
            await _set.AddAsync(model);
            await _db.SaveChangesAsync();
            return model.Id;
        }

        public async Task DeleteAsync(T model)
        {
            _set.Remove(model);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _set.FirstOrDefaultAsync(x => x.Id == id);
            await DeleteAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _set.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<T> GetFirstWhereAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await _set.FirstOrDefaultAsync(predicate);
            return entities;
        }

        public async Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids)
        {
            var entities = await _set.Where(x => ids.Contains(x.Id)).ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await _set.Where(predicate).ToListAsync();
            return entities;
        }

        public async Task UpdateAsync(T model)
        {
            await _db.SaveChangesAsync();
        }

    }
}
