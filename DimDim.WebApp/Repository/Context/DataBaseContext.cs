using System;
using DimDim.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Oracle.EntityFrameworkCore;
using System.IO;

namespace DimDim.WebApp.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        
    public DbSet<Conta> Conta { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseOracle(config.GetConnectionString("FiapSmartCityConnection"));
                optionsBuilder.EnableSensitiveDataLogging();

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
