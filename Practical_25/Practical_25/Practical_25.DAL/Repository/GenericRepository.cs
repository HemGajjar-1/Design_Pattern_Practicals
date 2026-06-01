using Practical_25.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Practical_25.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Practical_25.Domain.Entities;
using System.Linq.Expressions;
namespace Practical_25.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T,bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
    }
}
