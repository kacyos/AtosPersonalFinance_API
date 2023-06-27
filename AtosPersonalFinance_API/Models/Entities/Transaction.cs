using System.Text.Json.Serialization;

namespace AtosPersonalFinance_API.Models.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; } = null!;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
