using Microsoft.EntityFrameworkCore;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Persistence.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Persistence.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly CarBookDbContext carBookDbContext;

        public RepositoryBase(CarBookDbContext carBookDbContext)
        {
            this.carBookDbContext = carBookDbContext;
        }

        public async Task AddItemAsync(T entity)
        {
            await carBookDbContext.AddAsync(entity);
            await carBookDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool v)
        {
            return v ? carBookDbContext.Set<T>().AsNoTracking() : await carBookDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetItemAsync(Expression<Func<T, bool>> predicate)
        {
            return await carBookDbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task RemoveItemAsync(T entity)
        {
             carBookDbContext.Remove(entity);
            await carBookDbContext.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(T entity)
        {
             carBookDbContext.Update(entity);
            await carBookDbContext.SaveChangesAsync();
        }
    }
}
