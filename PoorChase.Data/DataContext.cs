using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PoorChase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoorChase.Data
{
    /// <summary>
    /// DbContext for PoorChase SQL DB
    /// </summary>
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-QOG59O9;Initial Catalog=PoorChaseDB;Integrated Security=True");
        }
    }
}
