using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Domain.Interfaces;

namespace Product.Infrastructure.Data
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity: BaseEntity, IAggregateRoot
    {

        protected DbContext _dbContext;
        
        public RepositoryAsync(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetRangeAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetRangeAsync(int limit, int offset)
        {
            //TODO: При работе с большими данными(особенно при большом значении offset) конструкция будет работать не оптимально
            return await _dbContext.Set<TEntity>().Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            }
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}