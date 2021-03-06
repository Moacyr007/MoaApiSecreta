﻿using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<TimeEntity> Times { get; set; }
        public DbSet<CampeonatoEntity> Campeonato { get; set; }
        public DbSet<PartidaEntity> Partida { get; set; }
        public DbSet<PontuacaoCampeonatoEntity> PontuacaoCampeonato { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options){
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TimeEntity>(new TimeMap().Configure);

            modelBuilder.Entity<TimeEntity>().HasData(
                new TimeEntity { Id = Guid.NewGuid(), Nome = "Palmeiras" },
                new TimeEntity { Id = Guid.NewGuid(), Nome = "Luverdense" },
                new TimeEntity { Id = Guid.NewGuid(), Nome = "Flamengo" }
            );
        }
    }
}
