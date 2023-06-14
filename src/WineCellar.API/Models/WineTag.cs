using System.ComponentModel.DataAnnotations.Schema;

namespace WineCellar.API.Models
{
    public class WineTag
    {
        public Guid Id { get; set; }
        public Guid WineId { get; set; }
        public Guid TagId { get; set; }
        public Wine Wine { get; set; }
        public Tag Tag { get; set; }
    }
}
