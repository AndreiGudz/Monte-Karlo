using Microsoft.EntityFrameworkCore;
using Monte_Karlo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<CircleParams> CircleParams { get; set; }
        public DbSet<SimulationResult> SimulationResults { get; set; }

        private string databasePath = "DataBase.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
            //optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CircleParams>()
                .HasIndex(cp => new 
                { 
                    cp.CenterX, 
                    cp.CenterY, 
                    cp.Radius, 
                    cp.Direction, 
                    cp.C, 
                    cp.TotalPoints 
                })
                .IsUnique();
        }
    }
}
