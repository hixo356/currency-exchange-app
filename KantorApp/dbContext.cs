using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_window_database
{
    internal class dbContext : DbContext
    {
        public DbSet<dbStructure> Rates { get; set; }
        public dbContext()
        {
            Database.EnsureCreated();
        }
        //  Użycie istniejącej bazy danych SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=exchangeRates.db");
        }
        //  Stworzenie tabeli we właściwej bazie na podstawie stworzonej wcześniej klasy
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dbStructure>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.currency).IsRequired();
                entity.Property(e => e.rate).IsRequired();
            });
        }
    }
}
