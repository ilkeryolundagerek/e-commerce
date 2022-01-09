using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public interface IGenericRepository<T> where T : class
    {
        //CRUD:
        void Create(T entity);
        T ReadOne(object entityKey);
        Task<T> ReadOneAsync(object entityKey);
        IQueryable<T> ReadAll(Expression<Func<T, bool>> expression = null);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object entityKey);
        int Save();
        Task<int> SaveAsync();
        void Dispose();
        bool Exists(object entityKey);
    }
}
