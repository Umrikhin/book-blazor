﻿using Microsoft.EntityFrameworkCore;
using Realty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Db.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Region> Regions { get; set; } = null!;
        public DbSet<House> Houses { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(
                new Region() { Id = 1, Nm = "Москва", GIBDD = "77" },
                new Region() { Id = 2, Nm = "Московская область", GIBDD = "50" },
                new Region() { Id = 3, Nm = "Санкт-Петербург", GIBDD = "78" }
            );
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasIndex(e => e.GIBDD).IsUnique();
            });
            modelBuilder.Entity<House>(entity =>
            {
                entity.HasIndex(e => e.Lot).IsUnique();
            });
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasIndex(e => e.NumTitul).IsUnique();
            });
        }
    }
}
