using System.Text.Json.Serialization;

namespace AtosPersonalFinance_API.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string Type { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; } =
            new List<Transaction>();
    }
}
