using Microsoft.EntityFrameworkCore;
using DataLibrary;
using System.Numerics;

namespace WebAPI.Data
{
    public class Context : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>().Property(s => s.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Author>().HasKey(t => t.ID);
            modelBuilder.Entity<Book>().Property(s => s.ISBN).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().HasKey(t => t.ISBN);
        }
    }
}
