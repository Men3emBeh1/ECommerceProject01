using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey>(StoreDbContext _context) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false)
        {
            return trackChanges
            ? await _context.Set<TEntity>().ToListAsync()
            : await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetAsync(TKey Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications, bool trackChanges = false)
        {
            return await ApplySpecicification(specifications).ToListAsync();
        }

        public async Task<TEntity?> GetAsync(ISpecifications<TEntity, TKey> specifications)
        {
            return await ApplySpecicification(specifications).FirstOrDefaultAsync();
        }
        public async Task<int> CountAsync(ISpecifications<TEntity, TKey> specifications)
        {
            return await ApplySpecicification(specifications).CountAsync();
        }

        private IQueryable<TEntity> ApplySpecicification(ISpecifications<TEntity, TKey> specifications)
        {
            return SpecificationEvaluator.GetQuery(_context.Set<TEntity>(), specifications);
        }
    }
}
