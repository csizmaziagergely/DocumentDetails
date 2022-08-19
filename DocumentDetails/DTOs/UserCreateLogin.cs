using System.ComponentModel.DataAnnotations;

namespace DocumentDetails.DTOs
{
    public class UserCreateLogin
    {
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(4, ErrorMessage = "Username must be at least 4 characters long")]
        [MaxLength(32, ErrorMessage = "Username must be maximum 32 characters long")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [MaxLength(32, ErrorMessage = "Password must be maximum 32 characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,32}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter and one number")]
        public string Password { get; set; }
    }
}
