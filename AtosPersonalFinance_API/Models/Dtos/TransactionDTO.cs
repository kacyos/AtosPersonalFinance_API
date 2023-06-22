using System.ComponentModel.DataAnnotations;

namespace AtosPersonalFinance_API.Models.Dtos
{
    public class TransactionDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Type { get; set; }

        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        public decimal Value { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Date { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int User_Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int Category_Id { get; set; }
    }
}
