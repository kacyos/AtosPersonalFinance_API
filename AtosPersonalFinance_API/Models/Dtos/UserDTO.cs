using System.ComponentModel.DataAnnotations;

namespace AtosPersonalFinance_API.Models.Dtos
{
    public class userDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
