using CrudSuperHeroes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSuperHeroes.Domain.Interfaces
{
    public interface IRepository <TEntity> where TEntity : BaseEntity
    {
        Task Add(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Update(TEntity entity);
        Task Remove(int id);
        Task<int> SaveChanges();

    }
}
