using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }


    }
}
