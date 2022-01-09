using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual void Create(T entity) => _set.Add(entity);

        public virtual void Delete(T entity) => _set.Remove(entity);

        public virtual void Delete(object entityKey)
        {
            var entity = ReadOne(entityKey);
            Delete(entity);
        }

        public virtual void Dispose() => _context.Dispose();

        public bool Exists(object entityKey)
        {
            return _set.Find(entityKey) != null;
        }

        public virtual IQueryable<T> ReadAll(Expression<Func<T, bool>> expression = null) => expression != null ? _set.Where(expression) : _set;

        public virtual T ReadOne(object entityKey) => _set.Find(new object[] { entityKey });

        public virtual async Task<T> ReadOneAsync(object entityKey) => await _set.FindAsync(new object[] { entityKey });

        public virtual int Save() => _context.SaveChanges();

        public virtual async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public virtual void Update(T entity)
        {
            _set.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
