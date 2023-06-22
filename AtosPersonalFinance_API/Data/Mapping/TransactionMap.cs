using AtosPersonalFinance_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtosPersonalFinance_API.Data.Mapping
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder
                .Property(x => x.Type)
                .IsRequired()
                .HasColumnName("transaction_type")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR");

            builder
                .Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR");

            builder
                .Property(x => x.Value)
                .IsRequired()
                .HasColumnName("value")
                .HasColumnType("DECIMAL(10,2)");

            builder
                .Property(x => x.Date)
                .IsRequired()
                .HasColumnName("date")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasConstraintName("fk_transaction_user")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Transactions)
                .HasConstraintName("fk_transaction_category")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
