using System.ComponentModel.DataAnnotations;
using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
