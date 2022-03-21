using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ReportsBLL.Models;

namespace ReportsBLL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<T?> FindAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression);
    }
}