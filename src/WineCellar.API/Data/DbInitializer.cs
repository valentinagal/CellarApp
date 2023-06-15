using WineCellar.API.Models.Tags;

namespace WineCellar.API.Data
{
    public class DbInitializer
    {
        public static void Initialize(WineCellarContext context)
        {
            context.Database.EnsureCreated();
            if (context.Tags.Any())
            {
                return;
            }

            var tags = new Tag[]
            {
                new Tag { Id = Guid.NewGuid(), Value = "Red"},
                new Tag { Id = Guid.NewGuid(), Value = "White"},
                new Tag { Id = Guid.NewGuid(), Value = "Rosé" },
                new Tag { Id = Guid.NewGuid(), Value = "Sparkling" },
                new Tag { Id = Guid.NewGuid(), Value = "Dessert" },
                new Tag { Id = Guid.NewGuid(), Value = "Fortified" },
                new Tag { Id = Guid.NewGuid(), Value = "Dry" },
                new Tag { Id = Guid.NewGuid(), Value = "Sweet" },
                new Tag { Id = Guid.NewGuid(), Value = "Medium Dry" },
                new Tag { Id = Guid.NewGuid(), Value = "Medium Sweet" },
                new Tag { Id = Guid.NewGuid(), Value = "Organic" },
                new Tag { Id = Guid.NewGuid(), Value = "Biodynamic" },
                new Tag { Id = Guid.NewGuid(), Value = "Award-winning" },
                new Tag { Id = Guid.NewGuid(), Value = "Orange"},
                new Tag { Id = Guid.NewGuid(), Value = "Italian" },
                new Tag { Id = Guid.NewGuid(), Value = "French" },
                new Tag { Id = Guid.NewGuid(), Value = "Spanish" },
                new Tag { Id = Guid.NewGuid(), Value = "Australian" },
                new Tag { Id = Guid.NewGuid(), Value = "American" },
                new Tag { Id = Guid.NewGuid(), Value = "Chilean" },
                new Tag { Id = Guid.NewGuid(), Value = "South African" },
                new Tag { Id = Guid.NewGuid(), Value = "Argentine" },
                new Tag { Id = Guid.NewGuid(), Value = "New Zealand" },
                new Tag { Id = Guid.NewGuid(), Value = "Austrian" },
                new Tag { Id = Guid.NewGuid(), Value = "German" },
                new Tag { Id = Guid.NewGuid(), Value = "Portuguese" },
                new Tag { Id = Guid.NewGuid(), Value = "Netherlands" },
                new Tag { Id = Guid.NewGuid(), Value = "Georgian" },
                new Tag { Id = Guid.NewGuid(), Value = "Greece" },
                new Tag { Id = Guid.NewGuid(), Value = "Luxembourg" },
                new Tag { Id = Guid.NewGuid(), Value = "Uruguay" },
                new Tag { Id = Guid.NewGuid(), Value = "Turkey" }
            };

            foreach (Tag t  in tags)
            {
                context.Tags.Add(t);
            }
            context.SaveChanges();
        }
    }
}
