using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task AddItemAsync(T entity);
        Task RemoveItemAsync(T entity);
        Task<T> GetItemAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(bool v);
        Task UpdateItemAsync(T entity);
    }
}
