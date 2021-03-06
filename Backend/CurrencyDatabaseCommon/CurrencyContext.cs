﻿using CurrencyDatabaseCommon.DbModel;
using Microsoft.EntityFrameworkCore;

namespace CurrencyDatabaseCommon
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(DbContextOptions<CurrencyContext> options) : base(options)
        {

        }

        public DbSet<USD_AUD> USD_AUD { get; set; }
        public DbSet<USD_EUR> USD_EUR { get; set; }
        public DbSet<EUR_AUD> EUR_AUD { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USD_AUD>()
                .HasKey(e => e.Date);
                //.HasNoKey(); //EF bug !!!!

            modelBuilder.Entity<USD_EUR>()
                .HasKey(e => e.Date);
                //.HasNoKey(); //EF bug !!!!

            modelBuilder.Entity<EUR_AUD>()
                .HasKey(e => e.Date);
        }
    }
}
