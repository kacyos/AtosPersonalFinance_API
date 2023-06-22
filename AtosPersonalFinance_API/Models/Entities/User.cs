using System.Text.Json.Serialization;

namespace AtosPersonalFinance_API.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; } =
            new List<Transaction>();
    }
}
