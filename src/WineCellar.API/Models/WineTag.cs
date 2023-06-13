using System.ComponentModel.DataAnnotations.Schema;

namespace WineCellar.API.Models
{
    public class WineTag
    {
        public Guid Id { get; set; }
        
        [ForeignKey("Wine")]

        public Guid WineId { get; set; }
        public Wine Wine { get; set; }

        [ForeignKey("Tag")]

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
