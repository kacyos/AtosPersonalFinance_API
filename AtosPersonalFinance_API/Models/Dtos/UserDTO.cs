using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AtosPersonalFinance_API.Models.Dtos
{
    public class CreateUserDto
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(8)]
        [PasswordPropertyText(true)]
        public string Password { get; set; }
    }

    public class LoginUserDto
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
