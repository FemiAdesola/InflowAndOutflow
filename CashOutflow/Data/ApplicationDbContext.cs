using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashOutflow.Models;
using Npgsql;


namespace CashOutflow.Data
{
    public class ApplicationDbContext : DbContext
    {
        // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        // {

        // }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config) : base(options) => _config = config;
        static ApplicationDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",true);
        }
        private readonly IConfiguration _config;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connString = _config.GetConnectionString("DefaultConnection");
            optionsBuilder
                .UseNpgsql(connString)
                // .AddInterceptors(new AppDbContextSaveChangesInterceptor())
                .UseSnakeCaseNamingConvention();
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Expenses> Expenses { get; set; }

    }
}

