using CrudSuperHeroes.Domain.Entities;
using CrudSuperHeroes.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSuperHeroes.Infra.Repositories
{
    public class SuperPoderesRepository : Repository<SuperPoderes>
    {
        public SuperPoderesRepository(CrudSuperHeroDbContext context) : base(context) {}

        public override async Task<List<SuperPoderes>> GetAll()
        {
            return await Db.SuperPoderes.OrderBy(n => n.SuperPoder).ToListAsync();
        }
    }
}
