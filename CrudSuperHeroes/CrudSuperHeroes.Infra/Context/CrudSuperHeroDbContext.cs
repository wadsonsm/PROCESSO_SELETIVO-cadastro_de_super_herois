using CrudSuperHeroes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSuperHeroes.Infra.Context
{
    public class CrudSuperHeroDbContext : DbContext
    {
        public CrudSuperHeroDbContext(DbContextOptions<CrudSuperHeroDbContext> options) : base (options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroisSuperPoderes>()
                .HasOne(h => h.Herois)
                .WithMany(hs => hs.HeroisSuperPoderes)
                .HasForeignKey(hi => hi.HeroiId);

            modelBuilder.Entity<HeroisSuperPoderes>()
                .HasOne(s => s.SuperPoderes)
                .WithMany(hs => hs.HeroisSuperPoderes)
                .HasForeignKey(si => si.SuperPoderId);
        }
        public DbSet<Herois> Herois { get; set; }
        public DbSet<SuperPoderes> SuperPoderes { get; set;}
        public DbSet<HeroisSuperPoderes> HeroisSuperPoderes { get; set; }
    }
}
