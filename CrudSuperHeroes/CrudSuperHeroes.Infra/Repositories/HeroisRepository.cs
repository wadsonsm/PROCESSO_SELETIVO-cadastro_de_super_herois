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
    public class HeroisRepository : Repository<Herois>
    {        
        public HeroisRepository(CrudSuperHeroDbContext db) : base(db) { }
        
        public override async Task<List<Herois>> GetAll()
        {
            return await Db.Herois.Include(c => c.HeroisSuperPoderes).OrderBy(n => n.NomeHeroi).ToListAsync();
        }
        public override async Task Add(Herois heroi)
        {
            var verificaHeroi = Db.Herois.Where(n => n.NomeHeroi == heroi.Nome);            
            this.Db.Add(heroi);
            await this.Db.SaveChangesAsync();
        }
        public override async Task<Herois> GetById(int id)
        {            
            return await Db.Herois.FirstAsync(h => h.Id == id);
        }
        public override async Task Update(Herois entity)
        {
            Db.Herois.Update(entity);
            await this.Db.SaveChangesAsync();
        }
        public override async Task Remove(int id)
        {
            var heroi = await Db.Herois.FirstAsync(h => h.Id == id);
            Db.Herois.Remove(heroi);
            await this.Db.SaveChangesAsync();
        }
    }
}
