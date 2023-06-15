using WineCellar.API.Models.WineTags;

namespace WineCellar.API.Models.Tags
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Value { get; set; }

        public ICollection<WineTag> Wines { get; set; }
    }
}
