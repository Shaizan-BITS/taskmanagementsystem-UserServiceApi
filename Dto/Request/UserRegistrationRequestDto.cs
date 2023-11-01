using System.ComponentModel.DataAnnotations;

namespace UserServiceApi.Dto.Request
{
    public class UserRegistrationRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Add any other fields needed for registration
    }
}
