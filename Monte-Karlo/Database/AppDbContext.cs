// Класс, описывающий базу данных, подключение к ней, таблицы и их структуру

using Microsoft.EntityFrameworkCore;
using Monte_Karlo.Models;

namespace Monte_Karlo.DataBase
{
    public class AppDbContext : DbContext
    {
        // Таблица с параметрами окружности, для которой проводят эксперементы
        public DbSet<CircleParams> CircleParams { get; set; }

        // Таблица с результатами эксперементов
        public DbSet<SimulationResult> SimulationResults { get; set; }

        private string databasePath = "DataBase.db";

        // Указание для EF Core, что будет использоваться SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
            //optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));

        }

        // Создание индекса для CircleParams
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
