using Domain.Contracts;
using Domain.Models;
using Persistence.Data;
using Persistence.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private readonly ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<string, object>();
        }
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var type = typeof(TEntity).Name;

            return (IGenericRepository<TEntity, Tkey>) _repositories.GetOrAdd(type, new GenericRepository<TEntity, Tkey>(_context));
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
