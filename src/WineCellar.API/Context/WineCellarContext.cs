using Microsoft.EntityFrameworkCore;
using WineCellar.API.Models;

namespace WineCellar.API.Context
{
    public class WineCellarContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WineTag> WineTags { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>()
                .HasMany(w => w.Tags)
                .WithOne(t => t.Wine)
                .HasForeignKey(f => f.WineId);
            modelBuilder.Entity<Tag>()
                .HasMany(t => t.Wines)
                .WithOne(w => w.Tag)
                .HasForeignKey(f => f.TagId);

        }


    }
}
