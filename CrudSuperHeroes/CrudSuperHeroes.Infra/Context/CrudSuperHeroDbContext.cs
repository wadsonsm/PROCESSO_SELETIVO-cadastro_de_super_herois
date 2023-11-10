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

            modelBuilder.Entity<SuperPoderes>().HasData(
                new {Id = 1,  SuperPoder = "Voa", Descricao= "pode gerar um campo de energia , permitindo que ele se mova livremente e levite" },
                new { Id = 2, SuperPoder = "Super Força", Descricao = "é a habilidade de realizar proezas sobre-humanas de força física ou exercer força física além do escopo do que um humano é capaz" }
                );
        }
        public DbSet<Herois> Herois { get; set; }
        public DbSet<SuperPoderes> SuperPoderes { get; set;}
        public DbSet<HeroisSuperPoderes> HeroisSuperPoderes { get; set; }
    }
}
