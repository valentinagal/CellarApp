

using System.ComponentModel.DataAnnotations.Schema;

namespace WineCellar.API.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Wine")]
        public Guid WineId { get; set; }

    }
}
