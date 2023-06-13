using Microsoft.EntityFrameworkCore;
using WineCellar.API.Models;

namespace WineCellar.API.Context
{
    public class WineCellarContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Tag>Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WineTag> WineTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>()
                .HasMany(w => w.Tags)
                .WithMany(t => t.Wines)
                .UsingEntity<>()
        }


    }
}
