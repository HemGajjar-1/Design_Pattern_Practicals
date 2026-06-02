using Microsoft.EntityFrameworkCore;
using Practical_26.DAL.Data;
using Practical_26.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.DAL.Repositories
{
    public class GenericCommandRepository<T> : IGenericCommandRepository<T> where T:BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericCommandRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
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
            entity.IsDeleted = true;
            entity.Status = false;
            entity.UpdatedDate = DateTime.Now;
            _dbSet.Update(entity);
        }
    }
}
