using WineCellar.API.Context;
using WineCellar.API.Models;

namespace WineCellar.API.Repository
{
    public class CellarRepository : ICellarRepository
    {
        private readonly WineCellarContext _context;
        public CellarRepository(WineCellarContext context)
        {
            _context = context;
        }

        public Tag CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag;
        }

        public Wine CreateWine(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges();
            return wine;
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

        public Tag EditTag(Tag tag)
        {
            var CurrentTag = _context.Tags.SingleOrDefault(t => t.Id == tag.Id);
            CurrentTag.Value = tag.Value;
            _context.Tags.Update(CurrentTag);
            _context.SaveChanges();
            return CurrentTag;
        }

        public Wine EditWine(Wine wine)
        {
            var CurrentWine = _context.Wines.SingleOrDefault(w => w.Id == wine.Id);
            CurrentWine.Name = wine.Name;
            CurrentWine.WineMaker = wine.WineMaker;
            CurrentWine.Year = wine.Year;
            CurrentWine.Score = wine.Score;
            CurrentWine.Description = wine.Description;
            _context.Wines.Update(CurrentWine);
            _context.SaveChanges();
            return CurrentWine;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public IEnumerable<Wine> GetAllWines()
        {
            return _context.Wines.ToList();
        }

        public Tag? GetTag(Guid id) => _context.Tags.Find(id);

        public User? GetUser(Guid id) => _context.Users.Find(id);

        public Wine? GetWine(Guid id) => _context.Wines.Find(id);
        
    }
}
