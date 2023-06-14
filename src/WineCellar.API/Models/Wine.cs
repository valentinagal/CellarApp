using System.ComponentModel.DataAnnotations.Schema;

namespace WineCellar.API.Models
{
    public class Wine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WineMaker { get; set; }
        public int Year { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }

        [ForeignKey("WineTag")]
        public ICollection<WineTag> Tags { get; set; }

    }
}
