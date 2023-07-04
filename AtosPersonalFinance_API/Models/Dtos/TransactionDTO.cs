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

    public class CreateTransactionDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Type { get; set; }

        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        public decimal Value { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Date { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int CategoryId { get; set; }
    }

    public class UpdateTransactionDTO
    {
        public string Type { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public string Date { get; set; }
        public int Category_Id { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
