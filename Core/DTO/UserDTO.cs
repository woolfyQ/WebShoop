using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        public static implicit operator UserDTO(User user) => new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
        };
    }

}
