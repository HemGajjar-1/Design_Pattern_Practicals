using Practical_26.DAL.Data;
using Practical_26.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.DAL.Repositories
{
    public interface IGenericCommandRepository<T> where T:BaseEntity
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
