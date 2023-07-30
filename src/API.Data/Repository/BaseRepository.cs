using API.Data.Context;
using API.Domain.Entities;
using API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private readonly DbSet<T> _dataSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();

                entity.CreateAt = DateTime.UtcNow;

                _dataSet.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(entity.Id));

                if (result == null)
                    return null;

                entity.CreateAt = result.CreateAt;
                entity.UpdateAt = DateTime.UtcNow;

                _context.Entry(result).CurrentValues.SetValues(entity);

                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
            => await _dataSet.AnyAsync(p => p.Id.Equals(id));

        public Task<T> SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(id));

                if (result == null)
                    return false;

                _dataSet.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
