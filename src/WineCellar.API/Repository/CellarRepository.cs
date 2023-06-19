using Microsoft.EntityFrameworkCore;
using WineCellar.API.Data;
using WineCellar.API.Models.Tags;
using WineCellar.API.Models.Users;
using WineCellar.API.Models.Wines;
using WineCellar.API.Models.WineTags;

namespace WineCellar.API.Repository
{
    public class CellarRepository : ICellarRepository
    {
        private readonly WineCellarContext _context;
        public CellarRepository(WineCellarContext context)
        {
            _context = context;
        }

        public Tag CreateTag(CreateTag tag)
        {
            var newTag = new Tag
            {
                Value = tag.Value
            };
            _context.Tags.Add(newTag);
            _context.SaveChanges();
            return newTag;
        }

        public Wine CreateWine(CreateWine wine)
        {
            var newWine = new Wine
            {
                Name = wine.Name,
                WineMaker = wine.WineMaker,
                Year = wine.Year,
                Score = wine.Score,
                Description = wine.Description,
                ImageURL = wine.ImageURL,
                Tags = wine.Tags.Select(t => new WineTag {TagId = t}).ToList()
            };
            _context.Wines.Add(newWine);
            _context.SaveChanges();
            return newWine;
        }

        public WineTag CreateWineTag(WineTag wineTag)
        {
            _context.WineTags.Add(wineTag);
            _context.SaveChanges();
            return wineTag;
        }

        public Tag DeleteTag(Guid id)
        {
            var tag = _context.Tags.SingleOrDefault(t => t.Id == id);
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return tag;
        }

        public Wine DeleteWine(Guid id)
        {
            var wine = _context.Wines.SingleOrDefault(w => w.Id == id);
            _context.Wines.Remove(wine);
            _context.SaveChanges();
            return wine;
        }

        public WineTag DeleteWineTag(Guid id)
        {
            var wineTag = _context.WineTags.SingleOrDefault(wt => wt.Id == id);
            _context.WineTags.Remove(wineTag);
            _context.SaveChanges();
            return wineTag;
        }

        public Tag EditTag(CreateTag tag)
        {
            var CurrentTag = _context.Tags.SingleOrDefault(t => t.Value == tag.Value);
            CurrentTag.Value = tag.Value;
            _context.Tags.Update(CurrentTag);
            _context.SaveChanges();
            return CurrentTag;
        }

        public Wine EditWine(CreateWine wine)
        {
            var CurrentWine = _context.Wines.SingleOrDefault(w => w.Name == wine.Name);
            CurrentWine.Name = wine.Name;
            CurrentWine.WineMaker = wine.WineMaker;
            CurrentWine.Year = wine.Year;
            CurrentWine.Score = wine.Score;
            CurrentWine.Description = wine.Description;
            CurrentWine.ImageURL = wine.ImageURL;
            _context.Wines.Update(CurrentWine);
            _context.SaveChanges();
            return CurrentWine;
        }

        public WineTag EditWineTag(WineTag wineTag)
        {
            var currentTag = _context.WineTags.SingleOrDefault(wt => wt.Id == wineTag.Id);
            currentTag.WineId = wineTag.WineId;
            currentTag.TagId = wineTag.TagId;
            _context.WineTags.Update(currentTag);
            _context.SaveChanges();
            return currentTag;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public IEnumerable<Wine> GetAllWines()
        {
            return _context.Wines.Include(x => x.Tags).ThenInclude(x => x.Tag).ToList();
        }

        public IEnumerable<WineTag> GetAllWineTags()
        {
            return _context.WineTags.ToList();
        }

        public Tag? GetTag(Guid id) => _context.Tags.Find(id);

        public User? GetUser(Guid id) => _context.Users.Find(id);

        public Wine? GetWine(Guid id) => _context.Wines.Include(x => x.Tags).SingleOrDefault(a => a.Id == id);

        public WineTag? GetWineTag(Guid id) => _context.WineTags.Find(id);
    }
}
