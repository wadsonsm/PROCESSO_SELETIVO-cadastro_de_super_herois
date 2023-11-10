using CrudSuperHeroes.Domain.Entities;
using CrudSuperHeroes.Domain.Interfaces;
using CrudSuperHeroes.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSuperHeroes.Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly CrudSuperHeroDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(CrudSuperHeroDbContext context)
        {
            this.Db = context;
            this.DbSet = this.Db.Set<TEntity>();
        }
        public virtual async Task Add(TEntity entity)
        {
           this.DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FirstAsync(x => x.Id == id);
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(int id)
        {
            var heroi = await DbSet.FirstAsync(x => x.Id == id);
            DbSet.Remove(heroi);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        
    }
}
