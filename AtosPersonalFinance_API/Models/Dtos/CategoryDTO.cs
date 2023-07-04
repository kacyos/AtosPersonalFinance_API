using System.ComponentModel.DataAnnotations;

namespace AtosPersonalFinance_API.Models.Dtos
{
    public class CategoryDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string Type { get; set; } = null!;

        public string Color { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
