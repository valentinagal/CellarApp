using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WineCellar.API.Models.Tags;
using WineCellar.API.Models.Users;
using WineCellar.API.Models.Wines;
using WineCellar.API.Models.WineTags;

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

        private static string GetConnectionString()
        {
            string jsonSettings = File.ReadAllText("appsettings.json");
            JObject configuration = JObject.Parse(jsonSettings);
            return configuration["ConnectionStrings"]["DefaultConnectionString"].ToString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(GetConnectionString());
        }


    }
}
