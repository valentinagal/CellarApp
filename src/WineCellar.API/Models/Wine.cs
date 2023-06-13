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

        [ForeignKey("Tag")]
        public Guid TagId { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
