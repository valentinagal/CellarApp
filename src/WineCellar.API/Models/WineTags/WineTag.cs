using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WineCellar.API.Models.Tags;
using WineCellar.API.Models.Wines;

namespace WineCellar.API.Models.WineTags

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
