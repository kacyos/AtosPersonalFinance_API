using AtosPersonalFinance_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtosPersonalFinance_API.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(80)
                .HasColumnType("VARCHAR");

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasMaxLength(80)
                .HasColumnType("VARCHAR");

            builder.HasIndex(x => x.UserName).IsUnique();

            builder
                .Property(x => x.UserName)
                .IsRequired()
                .HasColumnName("user_name")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR");

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(100)
                .HasColumnType("VARCHAR");

            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasMaxLength(100)
                .HasColumnType("VARCHAR");
        }
    }
}
