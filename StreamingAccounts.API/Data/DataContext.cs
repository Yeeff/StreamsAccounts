﻿using Microsoft.EntityFrameworkCore;
using StreamingAccounts.Shared.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StreamingAccounts.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();

        }



    }
}